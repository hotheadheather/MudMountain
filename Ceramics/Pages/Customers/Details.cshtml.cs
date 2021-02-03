using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;

namespace Ceramics.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public DetailsModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer
                       .Include(cu => cu.Orders)
                           .ThenInclude(o => o.Color)
                       .AsNoTracking()
                       .FirstOrDefaultAsync(m => m.ID == id);

           // Customer = await _context.Customer.FirstOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
