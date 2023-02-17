using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Models
{
    public class Patient
    {
        public int id { get; set; }

        public string Name { get; set; }

        public int MobileNo { get; set; }
        //public int Age { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }

        public string password { get; set; }

    }
}
