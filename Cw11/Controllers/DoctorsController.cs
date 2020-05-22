using Cw11.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cw11.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {

        private readonly MyDbContext _context;

        public DoctorsController(MyDbContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            List<Doctor> Doctors = _context.Doctor.ToList();

            return Ok(Doctors);
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {

            if (_context.Find<Doctor>(doctor.IdDoctor) != null)
            {
                return NotFound("Doctor with that Id already exists");
            }

            _context.Add<Doctor>(doctor);
            _context.SaveChanges();

            return Ok("Doctor has been inserted to a database");
        }

        [HttpPut]
        public IActionResult ModifyDoctor(Doctor doctor)
        {

            Doctor toUpdate = _context.Find<Doctor>(doctor.IdDoctor);

            if (toUpdate == null)
            {
                return NotFound("There is no such doctor in a database");
            }

            toUpdate.FirstName = doctor.FirstName;
            toUpdate.LastName = doctor.LastName;
            toUpdate.Email = doctor.Email;

            _context.Update<Doctor>(toUpdate);
            _context.SaveChanges();

            return Ok("Doctor has been updated");
        }

        [HttpDelete]
        public IActionResult DeleteDoctor(Doctor doctor)
        {
            Doctor toDelete = _context.Find<Doctor>(doctor.IdDoctor);

            if (toDelete == null)
            {
                return NotFound("There is no such doctor in a database");
            }

            _context.Remove<Doctor>(toDelete);
            _context.SaveChanges();

            return Ok("Doctor has been deleted");
        }

    }
}
