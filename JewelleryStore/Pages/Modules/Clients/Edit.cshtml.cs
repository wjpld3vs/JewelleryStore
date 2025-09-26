using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelleryStore.Data;

namespace JewelleryStore.Pages.Modules.Clients
{
    public class EditModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public EditModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clientes Clientes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes =  await _context.Clientes.FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }
            Clientes = clientes;
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

            _context.Attach(Clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(Clientes.ClienteId))
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

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
