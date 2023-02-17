using Healthcare.webAPI.Models;
using Healthcare.webAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Healthcare.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IRepository<Doctor> _repository;

        public DoctorController(IRepository<Doctor> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllDoctors")]
        public IEnumerable<Doctor> GetDoctors()
        {
            return _repository.GetAll();
        }

        [HttpGet]
        [Route("GetDoctorsById")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            var Doctor = await _repository.GetById(id);
            if (Doctor != null)
            {
                return Ok(Doctor);
            }
            return NotFound();

        }


        [HttpPost]
        [Route("CreateDoctor")]
        public async Task<IActionResult> CreatePatient([FromBody] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository.Create(doctor);
            return CreatedAtRoute("GetDoctorById", new { id = doctor.id }, doctor);
        }


        [HttpPut("updateDoctor/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _repository.Update(id, doctor);
            if (result != null)
            {
                return NoContent();
            }
            return NotFound("Doctor Not found");
        }

        [HttpDelete("DeleteDoctor/{id}")]

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _repository.Delete(id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound("Doctor Not found");
        }
    }
}
