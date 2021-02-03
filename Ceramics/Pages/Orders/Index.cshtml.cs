using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;

namespace Ceramics.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public IndexModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Order
                .Include(o => o.Color)
                .Include(o => o.Customer).ToListAsync();
        }
    }
}
