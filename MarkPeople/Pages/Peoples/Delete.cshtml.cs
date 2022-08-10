using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MarkPeople.DBLayer;

namespace MarkPeople.Pages.Peoples
{
    public class DeleteModel : PageModel
    {
        private readonly MarkPeople.DBLayer.ApplicationContext _context;

        public DeleteModel(MarkPeople.DBLayer.ApplicationContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            People = await _context.Peoples.FindAsync(id);

            if (People != null)
            {
                _context.Peoples.Remove(People);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
