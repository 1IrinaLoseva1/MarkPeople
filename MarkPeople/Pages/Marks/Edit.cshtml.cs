using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarkPeople.DBLayer;

namespace MarkPeople.Pages.Marks
{
    public class EditModel : PageModel
    {
        private readonly MarkPeople.DBLayer.ApplicationContext _context;

        public EditModel(MarkPeople.DBLayer.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MarkQuality MarkQuality { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MarkQuality = await _context.MarkQualities
                .Include(m => m.People).FirstOrDefaultAsync(m => m.MarkQualityId == id);

            if (MarkQuality == null)
            {
                return NotFound();
            }
           ViewData["PeopleId"] = new SelectList(_context.Peoples, "PeopleId", "PeopleName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MarkQuality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkQualityExists(MarkQuality.MarkQualityId))
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

        private bool MarkQualityExists(int id)
        {
            return _context.MarkQualities.Any(e => e.MarkQualityId == id);
        }
    }
}
