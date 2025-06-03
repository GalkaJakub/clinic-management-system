// Services/IVisitService.cs
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.Dtos.Doctor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public interface IVisitService
    {
        /// <summary>
        /// Pobiera wszystkie wizyty dla danego lekarza (z opcjonalnym filtrem po statusie i zakresie dat).
        /// </summary>
        Task<IEnumerable<Appointment>> GetVisitsForDoctorAsync(
            int doctorId,
            AppointmentStatus? status,
            DateTime? from,
            DateTime? to
        );

        /// <summary>
        /// Zamyka wizytę – zapisuje diagnozę i ustawia status = ZAL.
        /// </summary>
        Task CompleteVisitAsync(CompleteAppointmentDto dto, int doctorId);

        /// <summary>
        /// Anuluje wizytę – ustawia status = ANUL, opcjonalnie można tu logować powód.
        /// </summary>
        Task CancelVisitAsync(int appointmentId, string reason, int doctorId);

        /// <summary>
        /// Tworzy rekordy badania laboratoryjnego powiązane z wizytą.
        /// </summary>
        Task CreateLabOrdersAsync(CreateLabOrdersDto dto, int doctorId);

        /// <summary>
        /// Tworzy rekord badania fizjoterapeutycznego powiązane z wizytą.
        /// </summary>
        Task CreatePhysicalOrderAsync(CreatePhysicalOrderDto dto, int doctorId);
    }
}
