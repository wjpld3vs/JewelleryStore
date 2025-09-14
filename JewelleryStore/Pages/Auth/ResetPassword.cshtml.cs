using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace JewelleryStore.Pages.Auth
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingrese un correo v�lido.")]
        public string Email { get; set; } = string.Empty;

        // Mensaje que se muestra en la vista (gen�rico por seguridad)
        public string? Message { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // ========= Lugar para integrar env�o de correo =========
            // Aqu� debes:
            // 1) Buscar el usuario por email en la base de datos.
            // 2) Si existe, generar token seguro y guardarlo (hash) con expiraci�n.
            // 3) Enviar correo con enlace: https://tudominio/Account/ResetPassword?userId=ID&token=TOKEN
            //
            // En este ejemplo m�nimo s�lo simulamos la acci�n y siempre devolvemos
            // un mensaje gen�rico para no revelar si el email existe o no.
            //
            // Ejemplo (pseudoc�digo):
            // if (user != null) {
            //     var token = TokenHelpers.GenerateToken();
            //     SaveTokenHashToDatabase(user.Id, token);
            //     await _emailSender.SendAsync(user.Email, "Restablecer contrase�a", bodyWithLink);
            // }
            // ==============================================================

            // Simular trabajo as�ncrono peque�o:
            await Task.Delay(50);

            // Mensaje gen�rico (no revelar existencia del usuario)
            Message = "Si existe una cuenta asociada a ese correo, recibir�s un email con instrucciones para restablecer la contrase�a.";

            // Opcional: limpiar el campo para UX
            ModelState.Clear();
            Email = string.Empty;

            return Page();
        }
    }
}
