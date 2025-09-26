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

        public bool Remember { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
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

            // claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Email, usuario.CorreoUsuario)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(claimsIdentity);

            // 3) AuthenticationProperties: persistente (RememberMe) o no
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = Remember,
                // Si se quiere una expiración personalizada:
                ExpiresUtc = Remember ? DateTimeOffset.UtcNow.AddDays(30) : DateTimeOffset.UtcNow.AddHours(1),
                AllowRefresh = true
            };

            // 4) Sign in (genera la cookie)
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return LocalRedirect(returnUrl);


            return RedirectToPage("/Modules/Index");
        }

    }
}
