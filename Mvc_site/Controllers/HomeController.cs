﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_site.Models;
using System.Data.Entity;
using System.Web.Routing;

namespace Mvc_site.Controllers
{

    class Basket
    {
        List<Book> books_;
        List<int> count_;
        int sum_;
        public Basket()
        {
            books_ = new List<Book>();
            count_ = new List<int>();
        }
        public void add(Book b)
        {
            //cont_.Add(b);
            //I like kostili and bikes
            int j = -1;
            for(int i=0; i<books_.Count;i++)
            {
                if (books_[i].id == b.id)
                {
                    j = i;
                    break;
                }
            }
            if(j!=-1)
            {
                count_[j]++;
            }
            else
            {
                books_.Add(b);
                count_.Add(1);
            }
            sum_ += b.price;
        }
        public int sum
        {
            get { return sum_; }
        }
        public List<Book> books
        {
            get { return books_; }
        }
        public List<int> count
        {
            get { return count_; }
        }
    }
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        BookContext db = new BookContext();
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;
            Person person = (Person)Session[MagicConsts.CURRENT_USER];
            if (person == null)
            {
                person = new Person();
                Session[MagicConsts.CURRENT_USER] = person;
            }
            ViewBag.User = person;
            ViewBag.Kind = MagicConsts.KIND_TO_NAME;
            ViewBag.KindEnd = (int) Kind.End;
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
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
        [HttpGet] 
        public ActionResult AllPurchases()
        {
            IEnumerable<Purchase> purchases = db.Purcases;
            ViewBag.Purchases = purchases;
            return View();
        }
        [HttpGet]
        public string addToBasket(int id)
        {
            var book = db.Books.Find(id);
            if(book!=null)
            {
                getBasket().add(book);
            }
            return "adssda";
        }
        [HttpGet]
        public ActionResult showBasket()
        {
            Person person = (Person)Session[MagicConsts.CURRENT_USER];
            if (person == null)
            {
                person = new Person();
                Session[MagicConsts.CURRENT_USER] = person;
            }
            ViewBag.User = person;
            ViewBag.Kind = MagicConsts.KIND_TO_NAME;
            ViewBag.KindEnd = (int)Kind.End;
            Basket b = getBasket();
            ViewBag.basket = getBasket().books;
            ViewBag.sum = b.sum;
            ViewBag.count = b.count;
            return View();
        }
        [HttpGet]
        public ActionResult showByKind(int kind)
        {
            Person person = (Person)Session[MagicConsts.CURRENT_USER];
            if (person == null)
            {
                person = new Person();
                Session[MagicConsts.CURRENT_USER] = person;
            }
            ViewBag.User = person;
            ViewBag.Kind = MagicConsts.KIND_TO_NAME;
            ViewBag.KindEnd = (int)Kind.End;
            var Books = from b in db.Books
                         where ((int)b.kind==kind)
                         select b;
            IEnumerable<Book> books = Books;
            ViewBag.Books = books;
            ViewBag.booksKind = MagicConsts.KIND_TO_NAME[kind];
            return View();
        }
        Basket getBasket()
        {
            Basket basket = (Basket)Session[MagicConsts.BASKET];
            if (basket == null)
            {
                basket = new Basket();
                Session[MagicConsts.BASKET] = basket;
            }
            return basket;
        }
    }

}
