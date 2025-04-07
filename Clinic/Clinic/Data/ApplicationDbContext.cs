using Clinic.Enums;
using Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<User> Users {  get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ExamSelection> ExamSelections { get; set; }
        public DbSet<LabExam> LabExams { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PhysicalExam> PhysicalExams { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Receptionist> Receptionists { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<LabTechnician> LabTechnicians { get; set; }
        public DbSet<HeadLabTechnician> HeadLabTechnicians { get; set; }

        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<LabExam>()
                .HasOne(x => x.Appointment)
                .WithMany(x => x.LabExams)
                .HasForeignKey(x => x.AppointmentId);

            modelBuilder.Entity<PhysicalExam>()
                .HasOne(x => x.Appointment)
                .WithMany(x => x.PhysicalExams)
                .HasForeignKey(x => x.AppointmentId);

            modelBuilder.Entity<ExamSelection>().Property(x => x.Type).HasConversion<string>();
            modelBuilder.Entity<Appointment>().Property(x => x.Status).HasConversion<string>();
            modelBuilder.Entity<LabExam>().Property(x => x.Status).HasConversion<string>();

            modelBuilder.Entity<ExamSelection>().HasData(
                new ExamSelection { Shortcut = "krew", Name = "Pobieranie krwi", Type=ExamType.Lab},
                new ExamSelection { Shortcut = "cukier", Name = "Sprawdzenie poziomu cukru we krwi", Type=ExamType.Physical}
                );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {UserId= 1, Name = "Jakub", Surname= "Gałka", NPWZ = 32 ,PasswordHash = "user1", Login="Jakub" }
                );
            modelBuilder.Entity<Receptionist>().HasData(
                new Receptionist { UserId = 2, Name = "Wiktor", Surname = "Gruszka", PasswordHash = "user2", Login = "Wiktor" }
                );
            modelBuilder.Entity<HeadLabTechnician>().HasData(
                new HeadLabTechnician { UserId = 3, Name = "Jakub", Surname = "Gnela", PasswordHash = "user3", Login = "Jakub" }
                );
            modelBuilder.Entity<LabTechnician>().HasData(
                new LabTechnician { UserId = 4, Name = "Kacper", Surname = "Czerniak", PasswordHash = "user4", Login = "Kacper" }
                );
            modelBuilder.Entity<Admin>().HasData(
                new Admin { UserId = 5, Name = "Michał", Surname = "Sikora", PasswordHash = "user5", Login = "Michał" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId = 1, Name = "Gabriel", Surname = "Drabik", AdressId = 1, PESEL = "65110414558" },
                new Patient { PatientId = 2, Name = "Michael", Surname = "Brown", AdressId =2, PESEL = "57752850000" },
                new Patient { PatientId = 3, Name = "Emma", Surname = "Taylor", AdressId = 3, PESEL = "18204590000" },
                new Patient { PatientId = 4, Name = "John", Surname = "Brown", AdressId = 4, PESEL = "87673060000" },
                new Patient { PatientId = 5, Name = "Emma", Surname = "Taylor", AdressId = 5, PESEL = "99339650000" },
                new Patient { PatientId = 6, Name = "Anna", Surname = "Brown", AdressId = 6, PESEL = "73435320000" });

            modelBuilder.Entity<Address>().HasData(
                new Address{ AdressId = 1, City = "Gliwice", Street = "Akademicka", HomeNumber = "304" },
                new Address{ AdressId = 2, City = "Warsaw", Street = "Pine", HomeNumber = "26D" },
                new Address{ AdressId = 3, City = "Warsaw", Street = "Oak", HomeNumber = "25C" },
                new Address{ AdressId = 4, City = "Wroclaw", Street = "High", HomeNumber = "53A" },
                new Address{ AdressId = 5, City = "Poznan", Street = "Oak", HomeNumber = "42D" },
                new Address{ AdressId = 6, City = "Krakow", Street = "Pine", HomeNumber = "97B" }
                );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { AppointemntId = 1, RegistrationDate = new DateTime(2025, 4, 7), PatientId = 1, DoctorId = 1, AppointmentDate= new DateTime(2025, 4, 15),
                Description= "ból głowy", Status = AppointmentStatus.Awaiting, ReceptionistId = 2,  },
                new Appointment { AppointemntId = 2, RegistrationDate = new DateTime(2025, 4, 4), PatientId = 2, DoctorId = 1, AppointmentDate= new DateTime(2025, 4, 21),
                Description= "ból zeba", Status = AppointmentStatus.Awaiting, ReceptionistId = 2,  },
                new Appointment { AppointemntId = 3, RegistrationDate = new DateTime(2025, 4, 2), PatientId = 4, DoctorId = 1, AppointmentDate= new DateTime(2025, 4, 17),
                Description= "Gorączka i mocny ból głowy", Status = AppointmentStatus.Awaiting, ReceptionistId = 2}
                );
            modelBuilder.Entity<LabExam>().HasData(
                new LabExam { LabExamId = 1, AppointmentId = 1, ExamSelectionId = "Blood", Status = ExamStatus.Awaiting, LabTechnicianId = 4, RequestDate = 
                new DateTime(2025, 4, 3), HeadLabTechnicianId = 3},
                new LabExam { LabExamId = 2, AppointmentId = 1, ExamSelectionId = "XR", Status = ExamStatus.Awaiting, LabTechnicianId = 4, RequestDate = 
                new DateTime(2025, 4, 1), HeadLabTechnicianId = 3}
                );
            modelBuilder.Entity<ExamSelection>().HasData(
                new ExamSelection { Shortcut = "Gen", Name = "General Checkup", Type = ExamType.Physical},
                new ExamSelection { Shortcut = "Blood", Name = "Blood Test", Type = ExamType.Lab},
                new ExamSelection { Shortcut = "XR", Name = "X-Ray", Type = ExamType.Lab}
                );
            modelBuilder.Entity<PhysicalExam>().HasData(
            new PhysicalExam { PhisicalExamId = 1, AppointmentId = 1, ExamSelectionId = "Gen", Result = "All good"}
        );
        }
    }
}
