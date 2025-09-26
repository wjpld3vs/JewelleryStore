using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelleryStore.Data;

namespace JewelleryStore.Pages.Modules.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public DetailsModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public Categorias Categorias { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorias = await _context.Categorias.FirstOrDefaultAsync(m => m.CategoriaId == id);
            if (categorias == null)
            {
                return NotFound();
            }
            else
            {
                Categorias = categorias;
            }
            return Page();
        }
    }
}
