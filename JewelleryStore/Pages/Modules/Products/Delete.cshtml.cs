using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelleryStore.Data;

namespace JewelleryStore.Pages.Modules.Products
{
    public class DeleteModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public DeleteModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Productos Productos { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FirstOrDefaultAsync(m => m.ProductoId == id);

            if (productos == null)
            {
                return NotFound();
            }
            else
            {
                Productos = productos;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productos = await _context.Productos.FindAsync(id);
            if (productos != null)
            {
                Productos = productos;
                _context.Productos.Remove(Productos);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
