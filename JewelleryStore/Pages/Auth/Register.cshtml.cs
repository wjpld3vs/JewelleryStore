using JewelleryStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JewelleryStore.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly AppDbContext _db;

        public RegisterModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public string? Message { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        [BindProperty]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "El nombre de usuario debe tener un m�nimo de 10 caracteres")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contrase�a es obligatoria.")]
        [BindProperty]
        [StringLength(500, MinimumLength = 8, ErrorMessage = "La contrase�a debe tener un m�nimo de 8 caracteres")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = string.Empty;


        [Compare("Contrasena", ErrorMessage = "Las contrase�as no coinciden.")]
        [BindProperty]
        [StringLength(500, MinimumLength = 8, ErrorMessage = "La contrase�a debe tener un m�nimo de 8 caracteres")]
        [DataType(DataType.Password)]
        public string ConfirmarContrasena { get; set; } = string.Empty;


        [Required(ErrorMessage = "El correo electr�nico es obligatorio.")]
        [BindProperty]
        [EmailAddress(ErrorMessage = "El correo electr�nico no es v�lido.")]
        public string Correo { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (string.IsNullOrEmpty(Usuario))
            {
                ModelState.AddModelError(string.Empty, "El nombre de usuario est� en blanco");
                return Page();
            }
            else
            {
                // Verificar duplicado sencillo (case-sensitive)
                bool exists = await _db.Usuarios.AnyAsync(u => u.NombreUsuario == Usuario || u.CorreoUsuario == Correo);
                if (exists)
                {
                    ModelState.AddModelError(string.Empty, "El nombre de usuario o el correo ya existe.");
                    return Page();
                }
            }


            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Contrasena) || string.IsNullOrEmpty(Correo))
            {
                ModelState.AddModelError("Error", "Nombre de usuario, contrase�a o correo nulos nulos");
                return Page();
            }
            else
            {
                // **Registro sin PasswordHasher**: almacenamos la contrase�a tal como lleg� (inseguro)
                var usuario = new Usuarios
                {
                    NombreUsuario = Usuario,
                    ContrasenaUsuario = Contrasena, // texto plano
                    CorreoUsuario = Correo,
                    Recordar = true
                };

                _db.Usuarios.Add(usuario);
                await _db.SaveChangesAsync();

                Message = "Usuario registrado correctamente. Ahora puedes iniciar sesi�n.";
                return RedirectToPage("/Auth/Index");
               
            }

        }
    }
}
