using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;
using Ceramics.Pages.Models;

namespace Ceramics.Pages.Warehouses
{
    public class EditModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public EditModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WarehouseLocation WarehouseLocation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WarehouseLocation = await _context.WarehouseLocation.FirstOrDefaultAsync(m => m.ID == id);

            if (WarehouseLocation == null)
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

            _context.Attach(WarehouseLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarehouseLocationExists(WarehouseLocation.ID))
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

        private bool WarehouseLocationExists(int id)
        {
            return _context.WarehouseLocation.Any(e => e.ID == id);
        }
    }
}
