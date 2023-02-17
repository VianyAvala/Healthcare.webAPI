using Healthcare.webAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {

        private readonly ApplicationDbContext _context;
        //private ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Create(Patient obj)
        {
            if (obj != null)
            {
                _context.patients.Add(obj);
                await _context.SaveChangesAsync();
  

            }
        }

        public async Task<Patient> Delete(int id)
        {
            var patientInDb = await _context.patients.FindAsync(id);
            if (patientInDb != null)
            {

                _context.patients.Remove(patientInDb);
                await _context.SaveChangesAsync();
                return patientInDb;
            }
            return null;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.patients.ToList();
        }

        public async Task<Patient> GetById(int id)
        {
            var patient = await _context.patients.FindAsync(id);
            if (patient != null)
            {
                return patient;

            }
            return null;
        }

        public async Task<Patient> Update(int id, Patient obj)
        {
            var patientInDb = await _context.patients.FindAsync(id);
            if(patientInDb!=null)
            {
                patientInDb.Name = obj.Name;
                patientInDb.MobileNo = obj.MobileNo;
                patientInDb.Address = obj.Address;
                _context.patients.Update(patientInDb);
                await _context.SaveChangesAsync();
                return patientInDb;
            }
            return null;
        }
    }
}
