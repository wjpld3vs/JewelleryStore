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
    public class IndexModel : PageModel
    {
        private readonly JewelleryStore.Data.AppDbContext _context;

        public IndexModel(JewelleryStore.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Clientes> Clientes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Clientes = await _context.Clientes.ToListAsync();
        }
    }
}
