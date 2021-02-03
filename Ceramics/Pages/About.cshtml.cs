using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;
using Ceramics.Pages.Models.CeramicViewModels;

namespace Ceramics.Pages
{
   
    public class AboutModel : PageModel
    {
        private readonly CeramicsContext _context;

        public AboutModel(CeramicsContext context)
        {
            _context = context;
        }

        public IList<OrderDateGroup> Customer { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<OrderDateGroup> data =
                from customer in _context.Customer
                group customer by customer.OrderDate into dateGroup
                select new OrderDateGroup()
                {
                    OrderDate = dateGroup.Key,
                    CustomerCount = dateGroup.Count()
                };

            Customer = await data.AsNoTracking().ToListAsync();
        }
    }
}

