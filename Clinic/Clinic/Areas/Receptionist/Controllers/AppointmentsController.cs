using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Areas.Receptionist.Controllers
{
    [Area("Receptionist")]
    [Authorize(Roles = SD.Role_Receptionist)]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public AppointmentsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Index(string patientName, string doctorName)
        {
            var appointments = db.Appointments.Include(x => x.Doctor).ThenInclude(x => x.ApplicationUser).Include(x => x.Patient).ToList();

            if (!String.IsNullOrEmpty(patientName))
            {
                appointments = appointments.Where(x => (x.Patient.Name + " " + x.Patient.Surname).ToLower().Contains(patientName.ToLower())).ToList();
            }

            if (!String.IsNullOrEmpty(doctorName))
            {
                appointments = appointments.Where(x => (x.Doctor.ApplicationUser.Name + " " + x.Doctor.ApplicationUser.Surname).ToLower().Contains(doctorName.ToLower())).ToList();
            }

            return View(appointments);
        }

        public IActionResult CreateAppointment()
        {
            var model = new AppointmentVM
            {
                Appointment = new Appointment(),
                Patients = db.Patients.ToList(),
                Doctors = db.Doctors.Include(x => x.ApplicationUser).ToList(),
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

                var userId = userManager.GetUserId(User);
                var recpetionist = db.Receptionists.FirstOrDefault(x => x.ApplicationUserId == userId);
                if (recpetionist != null)
                    model.Appointment.ReceptionistId = recpetionist.ReceptionistId;
                else
                    return NotFound();


                db.Appointments.Add(model.Appointment);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            model.Patients = db.Patients.ToList();
            model.Doctors = db.Doctors.Include(x => x.ApplicationUser).ToList();
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
                Doctors = db.Doctors.Include(x => x.ApplicationUser).ToList(),
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
            model.Doctors = db.Doctors.Include(x => x.ApplicationUser).ToList();
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
