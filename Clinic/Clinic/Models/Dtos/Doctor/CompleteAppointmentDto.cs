// Models/Dtos/Doctor/CompleteAppointmentDto.cs
namespace Clinic.Models.Dtos.Doctor
{
    public class CompleteAppointmentDto
    {
        public int AppointmentId { get; set; }
        public string Diagnosis { get; set; } = null!;
        // Jeśli chciałbyś dodać osobne zalecenia, możesz rozszerzyć ten DTO o: 
        // public string? Recommendations { get; set; }
    }
}