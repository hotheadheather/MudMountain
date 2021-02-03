using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;

namespace Ceramics.Pages.Chemistry
{
    public class EditModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public EditModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Chemistry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChemistryExists(Chemistry.ChemID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChemistryExists(int id)
        {
            return _context.Chemistry.Any(e => e.ChemID == id);
        }
    }
}
