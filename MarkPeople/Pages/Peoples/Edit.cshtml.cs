using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarkPeople.DBLayer;

namespace MarkPeople.Pages.Peoples
{
    public class EditModel : PageModel
    {
        private readonly MarkPeople.DBLayer.ApplicationContext _context;

        public EditModel(MarkPeople.DBLayer.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public People People { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            People = await _context.Peoples
                .Include(p => p.Country).FirstOrDefaultAsync(m => m.PeopleId == id);

            if (People == null)
            {
                return NotFound();
            }
           ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "NameCountry");
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

            _context.Attach(People).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(People.PeopleId))
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

        private bool PeopleExists(int id)
        {
            return _context.Peoples.Any(e => e.PeopleId == id);
        }
    }
}
