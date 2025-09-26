using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelleryStore.Data;
using Microsoft.AspNetCore.Authorization;

namespace JewelleryStore.Pages.Modules.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public IndexModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Proveedores> Proveedores { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Proveedores = await _context.Proveedores.ToListAsync();
        }
    }
}
