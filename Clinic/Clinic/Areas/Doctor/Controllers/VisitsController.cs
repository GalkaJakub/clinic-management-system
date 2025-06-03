// Areas/Doctor/Controllers/VisitsController.cs
using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.Dtos.Doctor;
using Clinic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Clinic.Areas.Doctor.Controllers
{
    [Area("Doctor")]
    [Route("Doctor/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Doctor")] // Jeśli Twoja rola ma inną nazwę, zmień "Doctor" np. na "LEK"
    public class VisitsController : ControllerBase
    {
        private readonly IVisitService _visitService;
        private readonly ApplicationDbContext _dbContext;

        public VisitsController(IVisitService visitService,
                                ApplicationDbContext dbContext)
        {
            _visitService = visitService;
            _dbContext = dbContext;
        }

        /// <summary>
        /// GET: /Doctor/Visits/Index?status=REJ&from=2025-06-01&to=2025-06-30
        /// Pobiera listę wizyt dla zalogowanego lekarza, z opcjonalnym filtrem.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(
            [FromQuery] AppointmentStatus? status,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to)
        {
            // 1. Pobierz Id aktualnego ApplicationUser (Identity):
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized("Brak zalogowanego użytkownika.");

            // 2. Znajdź w tabeli Doctors wpis, którego ApplicationUserId = userId:
            var doctor = await _dbContext.Doctors
                                         .FirstOrDefaultAsync(d => d.ApplicationUserId == userId);
            if (doctor is null)
                return Unauthorized("Zalogowany użytkownik nie jest lekarzem.");

            // 3. Wywołaj serwis, przekazując doctor.DoctorId:
            var visits = await _visitService.GetVisitsForDoctorAsync(
                doctor.DoctorId!.Value, // DoctorId jest nullable, ale już sprawdziliśmy, że nie jest null
                status,
                from,
                to
            );

            return Ok(visits);
        }

        /// <summary>
        /// POST: /Doctor/Visits/Complete/{appointmentId}
        /// Body: { "appointmentId": 123, "diagnosis": "..." }
        /// Zamyka wizytę – ustawia Diagnosis i Status = ZAL.
        /// </summary>
        [HttpPost("{appointmentId}")]
        public async Task<IActionResult> Complete(
            int appointmentId,
            [FromBody] CompleteAppointmentDto dto)
        {
            if (appointmentId != dto.AppointmentId)
                return BadRequest("Id wizyty w URL i w ciele żądania muszą być takie same.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized();

            var doctor = await _dbContext.Doctors
                                         .FirstOrDefaultAsync(d => d.ApplicationUserId == userId);
            if (doctor is null)
                return Unauthorized();

            await _visitService.CompleteVisitAsync(dto, doctor.DoctorId!.Value);
            return NoContent();
        }

        /// <summary>
        /// POST: /Doctor/Visits/CreateLabOrders/{appointmentId}
        /// Body: { "appointmentId": 123, "labTests": [ { "testCode": "...", "notes": "..." } ] }
        /// Zamawia badania laboratoryjne.
        /// </summary>
        [HttpPost("{appointmentId}")]
        public async Task<IActionResult> CreateLabOrders(
            int appointmentId,
            [FromBody] CreateLabOrdersDto dto)
        {
            if (appointmentId != dto.AppointmentId)
                return BadRequest("Id wizyty w URL i w body muszą się zgadzać.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized();

            var doctor = await _dbContext.Doctors
                                         .FirstOrDefaultAsync(d => d.ApplicationUserId == userId);
            if (doctor is null)
                return Unauthorized();

            await _visitService.CreateLabOrdersAsync(dto, doctor.DoctorId!.Value);
            return NoContent();
        }

        /// <summary>
        /// POST: /Doctor/Visits/CreatePhysicalOrder/{appointmentId}
        /// Body: { "appointmentId": 123 }
        /// Zamawia badanie fizjoterapeutyczne.
        /// </summary>
        [HttpPost("{appointmentId}")]
        public async Task<IActionResult> CreatePhysicalOrder(
            int appointmentId,
            [FromBody] CreatePhysicalOrderDto dto)
        {
            if (appointmentId != dto.AppointmentId)
                return BadRequest("Id wizyty w URL i body muszą się zgadzać.");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized();

            var doctor = await _dbContext.Doctors
                                         .FirstOrDefaultAsync(d => d.ApplicationUserId == userId);
            if (doctor is null)
                return Unauthorized();

            await _visitService.CreatePhysicalOrderAsync(dto, doctor.DoctorId!.Value);
            return NoContent();
        }

        /// <summary>
        /// POST: /Doctor/Visits/Cancel/{appointmentId}
        /// Body: { "reason": "powód anulowania" }
        /// Anuluje wizytę (ustawia Status = ANUL).
        /// </summary>
        [HttpPost("{appointmentId}")]
        public async Task<IActionResult> Cancel(
            int appointmentId,
            [FromBody] CancelAppointmentDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId is null)
                return Unauthorized();

            var doctor = await _dbContext.Doctors
                                         .FirstOrDefaultAsync(d => d.ApplicationUserId == userId);
            if (doctor is null)
                return Unauthorized();

            await _visitService.CancelVisitAsync(appointmentId, dto.Reason, doctor.DoctorId!.Value);
            return NoContent();
        }
    }
}
