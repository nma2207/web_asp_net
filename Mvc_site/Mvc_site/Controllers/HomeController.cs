using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_site.Models;
using System.Data.Entity;
using System.Web.Routing;

namespace Mvc_site.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        BookContext db = new BookContext();

        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;

            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpGet]
        public ActionResult Reg()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AllPersons()
        {
            IEnumerable<Person> persons = db.People;
            ViewBag.People = persons;
            return View();
        }
        [HttpPost]
        public string Reg(Person per)
        {
            db.Entry(per).State = EntityState.Added;
            db.SaveChanges();
            return "<h1 align='center' >" + per.name +", Вы зареганы </h1>";
        }
        [HttpGet]
        public string square(int a, int b)
        {
            return "<h1 align='center'> "+a+"*"+b+"="+(a * b)+"</h1>";
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.date = DateTime.Now;
            db.Purcases.Add(purchase);
            db.SaveChanges();
            return "Спасибо, " + purchase.person + ", за покупку!";

        }

    }

}
