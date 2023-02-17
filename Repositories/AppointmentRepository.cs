using Healthcare.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Repositories
{
    public class AppointmentRepository : IRepository<Appointment>
    {
        private readonly ApplicationDbContext _context;
        //private ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Appointment obj)
        {
            if (obj != null)
            {
                _context.Appointments.Add(obj);
                await _context.SaveChangesAsync();


            }
        }

        public async Task<Appointment> Delete(int id)
        {
            var AppointmentInDb = await _context.Appointments.FindAsync(id);
            if (AppointmentInDb != null)
            {

                _context.Appointments.Remove(AppointmentInDb);
                await _context.SaveChangesAsync();
                return AppointmentInDb;
            }
            return null;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public async Task<Appointment> GetById(int id)
        {
            var Appointment = await _context.Appointments.FindAsync(id);
            if (Appointment != null)
            {
                return Appointment;

            }
            return null;
        }

        public async Task<Appointment> Update(int id, Appointment obj)
        {
            var AppointmentInDb = await _context.Appointments.FindAsync(id);
            if (AppointmentInDb != null)
            {
                AppointmentInDb.Doctor = obj.Doctor;
                AppointmentInDb.AppointmentDate = obj.AppointmentDate;
                AppointmentInDb.AppointmentTime = obj.AppointmentTime;
                _context.Appointments.Update(AppointmentInDb);
                await _context.SaveChangesAsync();
                return AppointmentInDb;

            }
            return null;
        }
    }
}
