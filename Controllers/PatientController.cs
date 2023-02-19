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
    public class PatientController : ControllerBase
    {
        private readonly IRepository<Patient> _repository;

        public PatientController(IRepository<Patient> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllPatients")]
        public IEnumerable<Patient> GetPatients()
        {
            return _repository.GetAll();
        }

        [HttpGet]
        [Route("GetPatientById")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _repository.GetById(id);
            if (patient != null)
            {
                return Ok(patient);
            }
            return NotFound();

        }

        [HttpPost]
        [Route("CreatePatient")]
        public async Task<IActionResult> CreatePatient([FromBody] Patient patient) 
         {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository.Create(patient);
            return CreatedAtRoute("GetPatientById", new { id = patient.id }, patient);
          }


        [HttpPut("updatePatient/{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _repository.Update(id, patient);
            if(result!=null)
            {
                return NoContent();
            }
            return NotFound("Patient Not found");
        }

        [HttpDelete("DeletePatient/{id}")]

        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _repository.Delete(id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound("Patient Not found");
        }


    }
}
