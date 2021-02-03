using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;
using System;
using System.Linq;

namespace Ceramics.Models.Chemistry
{
    public class IndexModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public IndexModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }



            public string ChemCompSort { get; set; }
            public string ChemAbbrevSort { get; set; }
            public string CurrentFilter { get; set; }
            public string CurrentSort { get; set; }

            // public IList<Customer> Customer { get;set; }

            public PaginatedList<Chem> Chemistry { get; set; }

            public async Task OnGetAsync(string sortOrder,
         string currentFilter, string searchString, int? pageIndex)
            {
                CurrentSort = sortOrder;
            ChemCompSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ChemAbbrevSort = sortOrder == "Date" ? "date_desc" : "Date";
                if (searchString != null)
                {
                    pageIndex = 1;
                }
                else
                {
                    searchString = currentFilter;
                }


                CurrentFilter = searchString;


                IQueryable<Chem> chemistryIQ = from i in _context.Chemistry
                                                  select i;
                if (!String.IsNullOrEmpty(searchString))
                {
                chemistryIQ = chemistryIQ.Where(i => i.ChemComp.Contains(searchString));
                                           
                }


                switch (sortOrder)
                {
                    case "name_desc":
                    chemistryIQ = chemistryIQ.OrderByDescending(i => i.ChemComp);
                        break;
                    case "Date":
                    chemistryIQ = chemistryIQ.OrderBy(i => i.ChemAbbrev);
                        break;
                    case "date_desc":
                    chemistryIQ = chemistryIQ.OrderByDescending(i => i.ChemAbbrev);
                        break;
                    default:
                    chemistryIQ = chemistryIQ.OrderBy(i => i.ChemComp);
                        break;
                }

                //Customer = await customerIQ.AsNoTracking().ToListAsync();

                int pageSize = 5;
                Chemistry = await PaginatedList<Chem>.CreateAsync(
                    chemistryIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            }
        }
    }




