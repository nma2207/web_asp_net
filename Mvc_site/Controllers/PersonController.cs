using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Mvc_site.Models;

namespace Mvc_site.Controllers
{
    public class PersonController:Controller
    {
        BookContext db = new BookContext();
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
            per.password = hash(per.password);
            db.Entry(per).State = EntityState.Added;
            db.SaveChanges();
            Session[MagicConsts.CURRENT_USER] = per;
            return "<h1 align='center' >" + per.name + ", Вы зареганы </h1>";
        }
        [HttpGet]
        public string Exit()
        {
            Person current = (Person)Session[MagicConsts.CURRENT_USER];
            string name = current.name;
            Session[MagicConsts.CURRENT_USER] = new Person();
            return "<h1 align='center'> Пока, " + name + " </h1>";
        }
        [HttpGet]
        public ActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public string Enter(Person per)
        {
            var people = from p in db.People
                         where (p.emal == per.emal)
                         select p;
            if (people.Count() == 0)
                return "Такого пользователя нет";
            if (hash(per.password) != people.First().password)
            {
                return "Неправльный пароль";
            }
            Session[MagicConsts.CURRENT_USER] = people.First();
            return "Привет, " + people.First().name;
        }
        private string hash(string pass)
        {
            int n = pass.Length;
            string new_pass = "";
            foreach (char s in pass)
            {
                new_pass += (Convert.ToChar(s + n)).ToString();
            }
            return new_pass;
        }

        //public void Execute(RequestContext requestContext)
        //{
        //        string ip = requestContext.HttpContext.Request.UserHostAddress;
        //        var response = requestContext.HttpContext.Response;
        //        response.Write("<h2> Ваш IP: " + ip + "/<h2>");
        //}

    }
}