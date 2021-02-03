using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ceramics.Models;

namespace Ceramics.Pages.Orders
{
    public class CreateModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public CreateModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ColorID"] = new SelectList(_context.Color, "ColorID", "ColorID");
        ViewData["CustomerID"] = new SelectList(_context.Customer, "ID", "FirstMidName");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Order.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}