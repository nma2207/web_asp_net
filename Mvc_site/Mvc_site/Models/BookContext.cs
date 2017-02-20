using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mvc_site.Models
{
    public class BookContext: DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Purchase> purcases { get; set; }
    }
}