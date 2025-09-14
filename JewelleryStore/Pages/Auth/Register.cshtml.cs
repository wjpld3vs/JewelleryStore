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

        [Required]
        [BindProperty]
        [StringLength(100, MinimumLength = 3)]
        public string Usuario { get; set; } = string.Empty;

        [Required]
        [BindProperty]
        [StringLength(100, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; } = string.Empty;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (String.IsNullOrEmpty(Usuario))
            {
                ModelState.AddModelError(string.Empty, "El nombre de usuario está en blanco");
                return Page();
            }
            else
            {
                // Verificar duplicado sencillo (case-sensitive)
                bool exists = await _db.Usuario.AnyAsync(u => u.NombreUsuario == Usuario);
                if (exists)
                {
                    ModelState.AddModelError(string.Empty, "El nombre de usuario ya existe.");
                    return Page();
                }
            }


            if (String.IsNullOrEmpty(Usuario) || String.IsNullOrEmpty(Contrasena))
            {
                ModelState.AddModelError("Error", "Nombre de usuario o contraseña nulos");
                return Page();
            }
            else
            {
                // **Registro sin PasswordHasher**: almacenamos la contraseña tal como llegó (inseguro)
                var usuario = new Usuario
                {
                    NombreUsuario = Usuario,
                    ContrasenaUsuario = Contrasena // <- texto plano
                };

                _db.Usuario.Add(usuario);
                await _db.SaveChangesAsync();

                Message = "Usuario registrado correctamente. Ahora puedes iniciar sesión.";
                return RedirectToPage("/Auth/Index");
               
            }

        }
    }
}
