using Clinic.Enums;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Appointment
    {
        [Key]
        public int AppointemntId { get; set; }
        public string Description { get; set; }
        public string? Diagnosis { get; set; }
        public AppointmentStatus Status { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int ReceptionistId { get; set; }
        public Receptionist? Receptionist { get; set; }
        public ICollection<LabExam>? LabExams { get; set; }
        public ICollection<PhysicalExam>? PhysicalExams { get; set; }

    }
}
