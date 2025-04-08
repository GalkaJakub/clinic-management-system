using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext db;

        public AppointmentsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var appointments = db.Appointments.Include(x => x.Doctor).Include(x => x.Patient).ToList();
            return View(appointments);
        }

        public IActionResult Create()
        {
            var model = new AppointmentVM
            {
                Appointment = new Appointment(),
                Patients = db.Patients.ToList(),
                Doctors = db.Doctors.ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AppointmentVM model)
        {
            if (ModelState.IsValid)
            {
                model.Appointment.Status = AppointmentStatus.Awaiting;
                model.Appointment.RegistrationDate = DateTime.Now;
                // TODO: Current Receptionist Id in the future
                model.Appointment.ReceptionistId = db.Receptionists.First().UserId;
                db.Appointments.Add(model.Appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            model.Patients = db.Patients.ToList();
            model.Doctors = db.Doctors.ToList();
            return View(model);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
