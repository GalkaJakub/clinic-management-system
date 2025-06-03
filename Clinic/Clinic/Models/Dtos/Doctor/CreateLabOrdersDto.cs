// Models/Dtos/Doctor/CreateLabOrdersDto.cs
namespace Clinic.Models.Dtos.Doctor
{
    public class LabOrderItemDto
    {
        public string TestCode { get; set; } = null!;
        public string? Notes { get; set; }
    }

    public class CreateLabOrdersDto
    {
        public int AppointmentId { get; set; }
        public List<LabOrderItemDto> LabTests { get; set; } = new();
    }
}
