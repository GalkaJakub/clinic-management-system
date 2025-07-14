using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Clinic.Areas.HeadLabTechnician.Controllers
{

    [Area("HeadLabTechnician")]
    [Authorize(Roles = SD.Role_HeadLabTechnician)]
    public class HeadLabExamsController : Controller
    {

        private ApplicationDbContext db;
        public HeadLabExamsController(ApplicationDbContext db)
        {
            this.db = db;
            
        }

        public async Task<IActionResult> Index(string searchString, int? pageIndex, int pageSize = 10)
        {
            ViewData["CurrentFilter"] = searchString;

            IQueryable<LabExam> labExamsQuery = db.LabExams
                .Include(x => x.LabTechnician)
                .ThenInclude(x => x.ApplicationUser)
                .Where(x => x.Status == ExamStatus.InProgress || x.Status == ExamStatus.Completed || x.Status == ExamStatus.Disapproved);

            
            if (!string.IsNullOrEmpty(searchString))
            {
                labExamsQuery = labExamsQuery.Where(x =>
                    x.LabTechnician.ApplicationUser.Name.Contains(searchString) ||
                    x.LabTechnician.ApplicationUser.Surname.Contains(searchString) ||
                    x.Status.ToString().Contains(searchString));
            }


            int pageNumber = pageIndex ?? 1;
            var paginatedExams = await PaginatedList<LabExam>.CreateAsync(labExamsQuery, pageNumber, pageSize);

            return View(paginatedExams);
        }

        public IActionResult HeadLabExam(int labExamId)
        {

            var labExam = db.LabExams
                .Include(x => x.ExamSelection)
                .Include(x => x.Appointment)
                .FirstOrDefault(x => x.LabExamId == labExamId);

            var model = new LabExamVM
            {
                LabExam = labExam,
                ExamSelection = labExam?.ExamSelection
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult HeadLabExam(LabExamVM model)
        {

            ModelState.Remove("LabExam.Appointment");
            ModelState.Remove("LabExam.LabTechnician");
            ModelState.Remove("LabExam.HeadLabTechnician");
            ModelState.Remove("LabExam.ExamSelection");

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors });
                foreach (var error in errors)
                {
                    Console.WriteLine($"Key: {error.Key}, Errors: {string.Join(", ", error.Errors)}");
                }
            }

            if (ModelState.IsValid)
            {
                var newLabExam = model.LabExam;
                var labExam = db.LabExams.Find(newLabExam.LabExamId);
                if (labExam != null)
                {

                    labExam.DoctorsNotes = newLabExam.DoctorsNotes;
                    labExam.RequestDate = newLabExam.RequestDate;
                    labExam.Result = newLabExam.Result;
                    labExam.ExamDate = newLabExam.ExamDate;
                    labExam.HeadLabNotes = newLabExam.HeadLabNotes;
                    labExam.AcceptDate = newLabExam.AcceptDate;
                    labExam.Status = ExamStatus.Completed;

                    labExam.AppointmentId = newLabExam.AppointmentId;
                    labExam.LabTechnicianId = newLabExam.LabTechnicianId;
                    labExam.HeadLabTechnicianId = newLabExam.HeadLabTechnicianId;
                    labExam.ExamSelectionId = newLabExam.ExamSelectionId;



                    db.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Lab exam is null");
                }
                return RedirectToAction(nameof(Index));
            }



            return View(model);
        }

        [HttpPost]
        public IActionResult Disapprove(LabExamVM model)
        {
            var labExamId = model.LabExam.LabExamId;
            var notes = model.LabExam.HeadLabNotes;

            var labExam = db.LabExams.FirstOrDefault(x => x.LabExamId == labExamId);
            if (labExam != null)
            {
                labExam.Status = ExamStatus.Disapproved;
                labExam.HeadLabNotes = notes;
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
