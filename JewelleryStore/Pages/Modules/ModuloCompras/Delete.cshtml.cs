using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelleryStore.Data;

namespace JewelleryStore.Pages.Modules.ModuloCompras
{
    public class DeleteModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public DeleteModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Compras Compras { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compras = await _context.Compras.FirstOrDefaultAsync(m => m.CompraId == id);

            if (compras == null)
            {
                return NotFound();
            }
            else
            {
                Compras = compras;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compras = await _context.Compras.FindAsync(id);
            if (compras != null)
            {
                Compras = compras;
                _context.Compras.Remove(Compras);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
