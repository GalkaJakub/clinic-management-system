using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


namespace Clinic.Areas.LabTechnician.Controllers
{
    [Area("LabTechnician")]
    [Authorize(Roles = SD.Role_LabTechnician)]
    public class LabExamsController : Controller
    {
        private readonly ApplicationDbContext db;

        public LabExamsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var labExams = db.LabExams.Include(x => x.LabTechnician).ThenInclude(x => x.ApplicationUser).ToList();

            return View(labExams);
        }


        public IActionResult LabExam(int labExamId)
        {

            var labExam = db.LabExams
                .Include(x => x.ExamSelection)
                .FirstOrDefault(x => x.LabExamId == labExamId);

            var model = new LabExamVM
            {
                LabExam = labExam,
                ExamSelection = labExam?.ExamSelection
            };
            return View(model);
        }

    }
}
