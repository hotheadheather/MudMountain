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
    public class IndexModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public IndexModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        // public IList<Customer> Customer { get;set; }

        public PaginatedList<Customer> Customer { get; set; }

        public async Task OnGetAsync(string sortOrder,
     string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }


            CurrentFilter = searchString;


            IQueryable<Customer> customerIQ = from cu in _context.Customer
                                            select cu;
            if (!String.IsNullOrEmpty(searchString))
            {
                customerIQ = customerIQ.Where(cu => cu.LastName.Contains(searchString)
                                       || cu.FirstMidName.Contains(searchString));
            }


            switch (sortOrder)
            {
                case "name_desc":
                    customerIQ = customerIQ.OrderByDescending(cu => cu.LastName);
                    break;
                case "Date":
                    customerIQ = customerIQ.OrderBy(cu => cu.OrderDate);
                    break;
                case "date_desc":
                    customerIQ = customerIQ.OrderByDescending(cu => cu.OrderDate);
                    break;
                default:
                    customerIQ = customerIQ.OrderBy(cu => cu.LastName);
                    break;
            }

            //Customer = await customerIQ.AsNoTracking().ToListAsync();

            int pageSize = 5;
            Customer = await PaginatedList<Customer>.CreateAsync(
                customerIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
    }

