using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirlineRWebApi.VM
{
    public class Register
    {
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public Nullable<long> Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}