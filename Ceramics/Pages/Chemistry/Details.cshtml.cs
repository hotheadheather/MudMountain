using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;

namespace Ceramics.Pages.Chemistry
{
    public class DetailsModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public DetailsModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        public Chem Chemistry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Chemistry = await _context.Chemistry.FirstOrDefaultAsync(m => m.ChemID == id);

            if (Chemistry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
