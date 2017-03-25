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
            return "<h1 align='center' >" + per.name + ", Вы зареганы </h1>";
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