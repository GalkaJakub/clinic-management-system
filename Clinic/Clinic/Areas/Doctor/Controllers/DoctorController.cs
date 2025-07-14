
using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Authorize(Roles = SD.Role_Doctor)]
    public class DoctorAppointmentsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorAppointmentsController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var doctorUser = await _userManager.GetUserAsync(User);
            if (doctorUser == null)
            {
                return Unauthorized();
            }

            var appointments = await _db.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.ApplicationUser)
                .Where(a => a.Doctor.ApplicationUserId == doctorUser.Id)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();

            return View(appointments);
        }

        public async Task<IActionResult> UpdateAppointment(int id)
        {
            var appointment = await _db.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                    .ThenInclude(d => d.ApplicationUser)
                .Include(a => a.PhysicalExams)
                .Include(a => a.LabExams)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

            if (appointment == null)
            {
                return NotFound();
            }

            var examSelections = await _db.ExamSelections.ToListAsync();

            var viewModel = new DoctorAppointmentVM
            {
                Appointment = appointment,
                ExamSelections = examSelections
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAppointment(DoctorAppointmentVM vm)
        {

            if (!ModelState.IsValid)
            {
                vm.ExamSelections = await _db.ExamSelections.ToListAsync();
                return View(vm);
            }

            var appointmentInDb = await _db.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == vm.Appointment.AppointmentId);

            if (appointmentInDb == null)
            {
                return NotFound();
            }

            appointmentInDb.Description = vm.Appointment.Description;
            appointmentInDb.Status = vm.Appointment.Status;

            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddPhysicalExam(int appointmentId)
        {
            var availableExams = await _db.ExamSelections
                .Where(e => e.Type == ExamType.Physical)
                .ToListAsync();

            var vm = new AddPhysicalExamVM
            {
                AppointmentId = appointmentId,
                AvailableExams = availableExams
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhysicalExam(AddPhysicalExamVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableExams = await _db.ExamSelections
                    .Where(e => e.Type == ExamType.Physical)
                    .ToListAsync();
                return View(vm);
            }

            var exam = new PhysicalExam
            {
                AppointmentId = vm.AppointmentId,
                ExamSelectionId = vm.ExamSelectionId,
                Result = vm.Result
            };

            _db.PhysicalExams.Add(exam);
            await _db.SaveChangesAsync();

            return RedirectToAction("UpdateAppointment", new { id = vm.AppointmentId });
        }

        public async Task<IActionResult> AddLabExam(int appointmentId)
        {
            var availableExams = await _db.ExamSelections
                .Where(e => e.Type == ExamType.Lab)
                .ToListAsync();

            var vm = new AddLabExamVM
            {
                AppointmentId = appointmentId,
                AvailableExams = availableExams
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddLabExam(AddLabExamVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.AvailableExams = await _db.ExamSelections
                    .Where(e => e.Type == ExamType.Lab)
                    .ToListAsync();

                return View(vm);
            }

            var labExam = new LabExam
            {
                AppointmentId = vm.AppointmentId,
                ExamSelectionId = vm.ExamSelectionId,
                DoctorsNotes = vm.DoctorsNotes,
                RequestDate = DateTime.Now,
                Status = ExamStatus.Awaiting,
                HeadLabTechnicianId = 1
            };

            _db.LabExams.Add(labExam);
            await _db.SaveChangesAsync();

            return RedirectToAction("UpdateAppointment", new { id = vm.AppointmentId });
        }


    }
}
