using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace JewelleryStore.Pages.Auth
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo válido.")]
        public string Email { get; set; } = string.Empty;

        // Mensaje que se muestra en la vista (genérico por seguridad)
        public string? Message { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // ========= Lugar para integrar envío de correo =========
            // Aquí debes:
            // 1) Buscar el usuario por email en la base de datos.
            // 2) Si existe, generar token seguro y guardarlo (hash) con expiración.
            // 3) Enviar correo con enlace: https://tudominio/Account/ResetPassword?userId=ID&token=TOKEN
            //
            // En este ejemplo mínimo sólo simulamos la acción y siempre devolvemos
            // un mensaje genérico para no revelar si el email existe o no.
            //
            // Ejemplo (pseudocódigo):
            // if (user != null) {
            //     var token = TokenHelpers.GenerateToken();
            //     SaveTokenHashToDatabase(user.Id, token);
            //     await _emailSender.SendAsync(user.Email, "Restablecer contraseña", bodyWithLink);
            // }
            // ==============================================================

            // Simular trabajo asíncrono pequeño:
            await Task.Delay(50);

            // Mensaje genérico (no revelar existencia del usuario)
            Message = "Si existe una cuenta asociada a ese correo, recibirás un email con instrucciones para restablecer la contraseña.";

            // Opcional: limpiar el campo para UX
            ModelState.Clear();
            Email = string.Empty;

            return Page();
        }
    }
}
