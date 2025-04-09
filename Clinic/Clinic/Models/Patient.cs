using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "PESEL is required.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "PESEL must be exactly 11 digits.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "PESEL must contain only digits.")]
        public string PESEL { get; set; }


        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+$", ErrorMessage = "Name must start with a capital letter and contain only letters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [RegularExpression(@"^[A-ZĄĆĘŁŃÓŚŹŻ][a-ząćęłńóśźż]+$", ErrorMessage = "Surname must start with a capital letter and contain only letters.")]
        public string Surname { get; set; }
        public int AdressId { get; set; }
        public Address Adress { get; set; }
    }
}
