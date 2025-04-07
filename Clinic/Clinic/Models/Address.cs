using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Address
    {
        [Key]
        public int AdressId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public int? ApartNumber { get; set; }
        public Patient Patient { get; set; }

    }
}
