using Clinic.Enums;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }

    }
}
