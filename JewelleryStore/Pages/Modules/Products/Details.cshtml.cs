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
    public class DetailsModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public DetailsModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
