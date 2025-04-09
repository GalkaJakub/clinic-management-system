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

        public IActionResult CreateAppointment()
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
        public IActionResult CreateAppointment(AppointmentVM model)
        {
            if (ModelState.IsValid)
            {
                model.Appointment.Status = AppointmentStatus.Awaiting;
                model.Appointment.RegistrationDate = DateTime.Now;
                // TODO: Current Receptionist Id in the future
                model.Appointment.ReceptionistId = db.Receptionists.First().UserId;
                db.Appointments.Add(model.Appointment);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            model.Patients = db.Patients.ToList();
            model.Doctors = db.Doctors.ToList();
            return View(model);
        }

        public IActionResult UpdateAppointment(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);
            if (appointment == null)
                return NotFound();
            var model = new AppointmentVM
            {
                Appointment = appointment,
                Doctors = db.Doctors.ToList(),
                Patients = db.Patients.ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateAppointment(AppointmentVM model)
        {
            if (ModelState.IsValid)
            {
                var newAppointment = model.Appointment;
                var appointment = db.Appointments.Find(newAppointment.AppointemntId);
                if (appointment != null)
                {
                    appointment.AppointmentDate = newAppointment.AppointmentDate;
                    appointment.DoctorId = newAppointment.DoctorId;
                    appointment.Description = newAppointment.Description;
                    appointment.PatientId = newAppointment.PatientId;
                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            model.Patients = db.Patients.ToList();
            model.Doctors = db.Doctors.ToList();
            return View(model);
        }

        public IActionResult DeleteAppointment(int appointmentId)
        {
            var appointment = db.Appointments.Find(appointmentId);
            if (appointment != null)
            {
                db.Appointments.Remove(appointment);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
