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
    public class DeleteModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public DeleteModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Color = await _context.Color.FindAsync(id);

            if (Color != null)
            {
                _context.Color.Remove(Color);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
