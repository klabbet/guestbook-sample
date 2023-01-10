using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using guestbook_sample.Models;

namespace guestbook_sample.Data
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext (DbContextOptions<GuestbookContext> options)
            : base(options)
        {
        }

        public DbSet<guestbook_sample.Models.Entry> Entry { get; set; } = default!;
    }
}
