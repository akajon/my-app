using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Utilizator
    {
        public int id { get; set; }
        public string coordinator_name { get; set; }
        public string username { get; set; }
        public string passwd { get; set; }
    }
}