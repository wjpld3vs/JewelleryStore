using JewelleryStore.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace JewelleryStore.Pages.Auth
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }
        
        [BindProperty]
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; } = string.Empty;


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validación del modelo (Required)
            if (!ModelState.IsValid)
                return Page();

            // Buscar usuario por nombre o correo (sin filtrar por contraseña aquí)
            var usuario = await _db.Usuarios
                                       .SingleOrDefaultAsync(u =>
                                       u.NombreUsuario == Username && u.ContrasenaUsuario == Password);

            // No revelar si existe o no -> Mensaje genérico
            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña inválidos.");
                return Page();
            }

            return RedirectToPage("/Modules/Index");
        }

    }
}
