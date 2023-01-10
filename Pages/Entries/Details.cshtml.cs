using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using guestbook_sample.Data;
using guestbook_sample.Models;

namespace guestbook_sample.Pages.Entries
{
    public class DetailsModel : PageModel
    {
        private readonly guestbook_sample.Data.GuestbookContext _context;

        public DetailsModel(guestbook_sample.Data.GuestbookContext context)
        {
            _context = context;
        }

      public Entry Entry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Entry == null)
            {
                return NotFound();
            }

            var entry = await _context.Entry.FirstOrDefaultAsync(m => m.Id == id);
            if (entry == null)
            {
                return NotFound();
            }
            else 
            {
                Entry = entry;
            }
            return Page();
        }
    }
}
