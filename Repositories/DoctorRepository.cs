using Healthcare.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Repositories
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private readonly ApplicationDbContext _context;
        //private ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Doctor obj)
        {
            if (obj != null)
            {
                _context.Doctors.Add(obj);
                await _context.SaveChangesAsync();


            }
        }

        public async Task<Doctor> Delete(int id)
        {

            var DoctorInDb = await _context.Doctors.FindAsync(id);
            if (DoctorInDb != null)
            {

                _context.Doctors.Remove(DoctorInDb);
                await _context.SaveChangesAsync();
                return DoctorInDb;
            }
            return null;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public async Task<Doctor> GetById(int id)
        {
            var Doctor = await _context.Doctors.FindAsync(id);
            if (Doctor != null)
            {
                return Doctor;

            }
            return null;
        }

        public async Task<Doctor> Update(int id, Doctor obj)
        {
            var DoctorInDb = await _context.Doctors.FindAsync(id);
            if (DoctorInDb != null)
            {
                DoctorInDb.Name = obj.Name;
                DoctorInDb.MobileNo = obj.MobileNo;
                DoctorInDb.specialization = obj.specialization;
                DoctorInDb.Address = obj.Address;
                _context.Doctors.Update(DoctorInDb);
                await _context.SaveChangesAsync();
                return DoctorInDb;
            }
            return null;
        }
    }
}
