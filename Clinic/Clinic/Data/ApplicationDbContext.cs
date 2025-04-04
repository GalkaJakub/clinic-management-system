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
                new Doctor {UserId= 1, Name = "Jakub", Surname= "Gałka", NPWZ = 32 ,PasswordHash = "user1" }
                );
            modelBuilder.Entity<Receptionist>().HasData(
                new Receptionist { UserId = 2, Name = "Wiktor", Surname = "Gruszka", PasswordHash = "user2" }
                );
            modelBuilder.Entity<HeadLabTechnician>().HasData(
                new HeadLabTechnician { UserId = 3, Name = "Jakub", Surname = "Gnela", PasswordHash = "user3" }
                );
            modelBuilder.Entity<LabTechnician>().HasData(
                new LabTechnician { UserId = 4, Name = "Kacper", Surname = "Czerniak", PasswordHash = "user4" }
                );
            modelBuilder.Entity<Admin>().HasData(
            new Admin { UserId = 5, Name = "Michał", Surname = "Sikora", PasswordHash = "user5" }
            );
        }
    }
}
