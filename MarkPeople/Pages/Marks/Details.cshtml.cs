using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MarkPeople.DBLayer;

namespace MarkPeople.Pages.Marks
{
    public class DetailsModel : PageModel
    {
        private readonly MarkPeople.DBLayer.ApplicationContext _context;

        public DetailsModel(MarkPeople.DBLayer.ApplicationContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
