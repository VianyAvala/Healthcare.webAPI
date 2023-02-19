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
    public class AppointmentController : ControllerBase
    {
        private readonly IRepository<Appointment> _repository;

        public AppointmentController(IRepository<Appointment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetAllAppoinments")]
        public IEnumerable<Appointment> GetDoctors()
        {
            return _repository.GetAll();
        }

        [HttpGet]
        [Route("GetAppointmentById")]
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
        [Route("CreateAppointment")]
        public async Task<IActionResult> CreateAppointment([FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _repository.Create(appointment);
            return CreatedAtRoute("GetAppointmentById", new { Id = appointment.id }, appointment);
        }


        [HttpPut("updateAppointment/{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _repository.Update(id, appointment);
            if (result != null)
            {
                return NoContent();
            }
            return NotFound("Appointment Not found");
        }

        [HttpDelete("DeleteAppointment/{id}")]

        public async Task<IActionResult> Deleteappointment(int id)
        {
            var result = await _repository.Delete(id);
            if (result != null)
            {
                return Ok();
            }
            return NotFound("Appointment Not found");
        }
    }
}
