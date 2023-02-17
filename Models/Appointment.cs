using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Models
{
    public class Appointment
    {
        public int id { get; set; }

        public Patient patient { get; set; }

        public int Patientid { get; set; }

        public Doctor Doctor { get; set; }

        public int Doctorid { get; set; }

        public string PatientName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string Problem { get; set; }

        public string specilization { get; set; }
    }
}
