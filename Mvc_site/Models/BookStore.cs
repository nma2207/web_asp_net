using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mvc_site.Models
{
    public class BookStore
    {
        public class BookDbInitializer: DropCreateDatabaseAlways<BookContext>
        {
            protected override void Seed(BookContext db)
            {
                db.Books.Add(new Book{name="Война и мир1 ", author="Толстой", price=1000});
                db.Books.Add(new Book{name="Война и мир 2", author="Толстой", price=1100});
                db.Books.Add(new Book{name="Война и мир 3", author="Толстой", price=1010});
                db.Books.Add(new Book{name="Война и мир 4", author="Толстой", price=1001});

                base.Seed(db);
            }

        }
    }
}