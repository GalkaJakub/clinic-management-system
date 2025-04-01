using Clinic.Enums;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class ExamSelection
    {
        [Key]
        public int ExamSelectionId { get; set; }
        public ExamType Type { get; set; }
        public string? Name { get; set; }
    }
}
