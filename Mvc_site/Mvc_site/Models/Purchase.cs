using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc_site.Models
{
    public class Purchase
    {
        public int id { get; set; }
        public string person { get; set; }
        public string address { get; set; }
        public int bookId { get; set; }
        public DateTime date { get; set; }

    }
}