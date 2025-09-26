using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelleryStore.Data;

namespace JewelleryStore.Pages.Modules.Clients
{
    public class DetailsModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public DetailsModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public Clientes Clientes { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                return NotFound();
            }
            else
            {
                Clientes = clientes;
            }
            return Page();
        }
    }
}
