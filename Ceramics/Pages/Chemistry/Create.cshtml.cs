using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ceramics.Models;

namespace Ceramics.Pages.Chemistry
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
        public Chem Chemistry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Chemistry.Add(Chemistry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}