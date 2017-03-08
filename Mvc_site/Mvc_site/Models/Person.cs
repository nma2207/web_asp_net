using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mvc_site.Models
{
    public class Person
    {
        public int id { get; set; }

        public string name { get; set; }

        public string emal { get; set; }
        public string password { get; set; }
    }
}