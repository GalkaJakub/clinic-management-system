// Models/Dtos/Doctor/CreatePhysicalOrdersDto.cs
namespace Clinic.Models.Dtos.Doctor
{
    public class CreatePhysicalOrderDto
    {
        public int AppointmentId { get; set; }
        // Dodaj tu inne pola, jeśli Twoja encja PhysicalExam wymaga dodatkowych danych
        // np. public string? ExerciseCode { get; set; }
    }
}