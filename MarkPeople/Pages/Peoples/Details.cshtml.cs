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
    public class DetailsModel : PageModel
    {
        private readonly MarkPeople.DBLayer.ApplicationContext _context;

        public DetailsModel(MarkPeople.DBLayer.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}
