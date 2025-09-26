using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JewelleryStore.Data;

namespace JewelleryStore.Pages.Modules.Clients
{
    public class CreateModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public CreateModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Clientes Clientes { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Clientes.Add(Clientes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
