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
    public class DetailsModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public DetailsModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        public Color Color { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = await _context.Color.FirstOrDefaultAsync(m => m.ColorID == id);

            if (Color == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
