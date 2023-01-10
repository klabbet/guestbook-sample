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
    public class IndexModel : PageModel
    {
        private readonly guestbook_sample.Data.GuestbookContext _context;

        public IndexModel(guestbook_sample.Data.GuestbookContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Entry != null)
            {
                Entry = await _context.Entry.ToListAsync();
            }
        }
    }
}
