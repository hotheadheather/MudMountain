using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ceramics.Models;

namespace Ceramics.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly Ceramics.Models.CeramicsContext _context;

        public EditModel(Ceramics.Models.CeramicsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Customer = await _context.Customer.FirstOrDefaultAsync(m => m.ID == id);

            Customer = await _context.Customer.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var customerToUpdate = await _context.Customer.FindAsync(id);

            if (await TryUpdateModelAsync<Customer>(
             customerToUpdate,
             "customer",
             cu => cu.FirstMidName, cu => cu.LastName, cu => cu.OrderDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
