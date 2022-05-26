using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Angajat
    {
        public int cnp { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string pic { get; set; }
        public string legetimation_number { get; set; }
        public string department { get; set; }
        public string schedule_start { get; set; }
        public string schedule_end { get; set; }
        public string security_code { get; set; }
        public string registration_number { get; set; }
        public string access { get; set; }
        public string cnp_access_granted { get; set; }
        public string data_access_granted { get; set; }


    }
}