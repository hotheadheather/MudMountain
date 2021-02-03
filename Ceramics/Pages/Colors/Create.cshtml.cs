using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ceramics.Models;

namespace Ceramics.Pages.Customers.Colors
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
            return Page();
        }

        [BindProperty]
        public Color Color { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Color.Add(Color);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}