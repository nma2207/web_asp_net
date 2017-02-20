using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_site.Models;

namespace Mvc_site.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            IEnumerable<Book> books = db.books;
            ViewBag.Books = books;

            return View();
        }

    }
}
