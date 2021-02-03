using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;
using Ceramics.Pages.Models;

namespace Ceramics.Pages.Warehouses
{
    public class DeleteModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public DeleteModel(Ceramics.Models.CeramicsContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WarehouseLocation = await _context.WarehouseLocation.FindAsync(id);

            if (WarehouseLocation != null)
            {
                _context.WarehouseLocation.Remove(WarehouseLocation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
