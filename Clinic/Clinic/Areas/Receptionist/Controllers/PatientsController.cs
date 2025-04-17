﻿using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Clinic.Areas.Receptionist.Controllers
{

    [Area("Receptionist")]
    [Authorize(Roles = SD.Role_Receptionist)]
    public class PatientsController : Controller
    {

        private readonly ApplicationDbContext db;

        public PatientsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index(string searchString)
        {
            var patients = db.Patients.Include(x => x.Address).ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                patients = patients.Where(x => x.Name.Contains(searchString)
                || x.Surname.Contains(searchString)).ToList();
            }

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

        public IActionResult CreateAddress()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateAddress(Address model)
        {
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
                db.Addresses.Add(model);
                db.SaveChanges();
                TempData["Success"] = "Address added successfully!";
                return RedirectToAction("Create");
            }

            return View(model);
            
        }

        [HttpPost]
        public IActionResult Create(PatientVM model)
        {
            ModelState.Remove("Patient.Address");

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
