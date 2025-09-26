using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JewelleryStore.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
           
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Registrar evento opcional: IP, user
            // _logger.LogInformation("User {User} logged out", User?.Identity?.Name);

            // Borra la cookie de autenticaci�n y finaliza la sesi�n
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Opcional: limpiar cookies adicionales si las usas (ej. session cookie)
            Response.Cookies.Delete(".AspNetCore.Session"); // si usas session middleware

            return RedirectToPage("/Auth/Index");
        }
    }
}

