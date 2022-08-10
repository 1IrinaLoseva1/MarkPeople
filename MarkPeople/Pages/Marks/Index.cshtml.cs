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
    public class IndexModel : PageModel
    {
        private readonly MarkPeople.DBLayer.ApplicationContext _context;

        public IndexModel(MarkPeople.DBLayer.ApplicationContext context)
        {
            _context = context;
        }

        public IList<MarkQuality> MarkQuality { get;set; }

        public async Task OnGetAsync()
        {
            MarkQuality = await _context.MarkQualities
                .Include(m => m.People).ToListAsync();
        }
    }
}
