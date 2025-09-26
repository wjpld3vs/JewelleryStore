using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelleryStore.Data;

namespace JewelleryStore.Pages.Modules.Products
{
    public class EditModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public EditModel(JewelleryStore.Data.AppDbContext context)
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

            var productos =  await _context.Productos.FirstOrDefaultAsync(m => m.ProductoId == id);
            if (productos == null)
            {
                return NotFound();
            }
            Productos = productos;
           ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Productos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductosExists(Productos.ProductoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}
