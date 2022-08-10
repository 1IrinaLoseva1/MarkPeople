using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MarkPeople.DBLayer;

namespace MarkPeople.Pages.Marks
{
    public class CreateModel : PageModel
    {
        private readonly MarkPeople.DBLayer.ApplicationContext _context;

        public CreateModel(MarkPeople.DBLayer.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PeopleId"] = new SelectList(_context.Peoples, "PeopleId", "PeopleName");
            return Page();
        }

        [BindProperty]
        public MarkQuality MarkQuality { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MarkQualities.Add(MarkQuality);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
