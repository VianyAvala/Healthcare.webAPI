using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Models
{
    public class Doctor
    {
        public int id { get; set; }
        public string  Name { get; set; }
        public int MobileNo { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string specialization { get; set; }

        public string  Qualification { get; set; }

        public int Experience { get; set; }



    }
}
