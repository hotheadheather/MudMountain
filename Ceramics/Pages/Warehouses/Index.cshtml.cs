using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;
using Ceramics.Pages.Models;

namespace Ceramics.Pages.Warehouses
{
    public class IndexModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public IndexModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        public IList<WarehouseLocation> WarehouseLocation { get;set; }

        public async Task OnGetAsync()
        {
            WarehouseLocation = await _context.WarehouseLocation.ToListAsync();
        }
    }
}
