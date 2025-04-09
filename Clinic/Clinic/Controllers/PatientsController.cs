using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    public class PatientsController : Controller
    {

        private readonly ApplicationDbContext db;

        public PatientsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var patients = db.Patients.Include(x => x.Adress).ToList();
            return View(patients);
        }

        public IActionResult Create()
        {
            var model = new PatientVM
            {
                Patient = new Patient(),
                Addresses = db.Addresses.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(PatientVM model)
        {

            // TODO: Find out why patient is never valid
            if (ModelState.IsValid)
            {

                db.Patients.Add(model.Patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            model.Addresses = db.Addresses.ToList();
            return View(model);
        }
    }
}
