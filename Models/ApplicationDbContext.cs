using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        public DbSet<Patient>  patients{ get; set; }
        public DbSet<Doctor>Doctors { get; set; }
        public DbSet <Appointment> Appointments { get; set; }
    }
}
