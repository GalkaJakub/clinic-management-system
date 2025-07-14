using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.ViewModels
{
    public class AddPhysicalExamVM
    {
        public int AppointmentId { get; set; }

        [Required]
        public string ExamSelectionId { get; set; }

        [Required]
        public string Result { get; set; }

        public List<ExamSelection> AvailableExams { get; set; }
    }

}
