using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.ViewModels
{
    public class AddLabExamVM
    {
        public int AppointmentId { get; set; }

        [Required]
        public string ExamSelectionId { get; set; }

        public string? DoctorsNotes { get; set; }

        public List<ExamSelection> AvailableExams { get; set; }
    }

}
