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
    public class IndexModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public IndexModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Compras> Compras { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Compras = await _context.Compras
                .Include(c => c.IdProveedorNavigation).ToListAsync();
        }
    }
}
