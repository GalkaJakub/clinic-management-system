using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string PESEL { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int AdressId { get; set; }
        public Address Adress { get; set; }
    }
}
