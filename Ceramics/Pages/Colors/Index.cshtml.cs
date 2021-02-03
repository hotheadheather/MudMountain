using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;

namespace Ceramics.Pages.Customers.Colors
{
    public class IndexModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public IndexModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

     

        public IList<Color> Color { get;set; }



        public async Task OnGetAsync()
        {
            Color = await _context.Color
               // .Include(c => c.ColorFamily)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
