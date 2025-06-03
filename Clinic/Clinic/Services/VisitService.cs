// Services/VisitService.cs
using Clinic.Data;
using Clinic.Enums;
using Clinic.Models;
using Clinic.Models.Dtos.Doctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Services
{
    public class VisitService : IVisitService
    {
        private readonly ApplicationDbContext _db;

        public VisitService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Appointment>> GetVisitsForDoctorAsync(
            int doctorId,
            AppointmentStatus? status,
            DateTime? from,
            DateTime? to
        )
        {
            var query = _db.Appointments
                           .Include(a => a.Patient)
                           .Include(a => a.LabExams)
                           .Include(a => a.PhysicalExams)
                           .Where(a => a.DoctorId == doctorId);

            if (status.HasValue)
                query = query.Where(a => a.Status == status.Value);

            if (from.HasValue)
                query = query.Where(a => a.AppointmentDate! >= from.Value);

            if (to.HasValue)
                query = query.Where(a => a.AppointmentDate! <= to.Value);

            return await query
                         .OrderBy(a => a.AppointmentDate)
                         .ToListAsync();
        }

        public async Task CompleteVisitAsync(CompleteAppointmentDto dto, int doctorId)
        {
            var appointment = await _db.Appointments
                                       .FirstOrDefaultAsync(a => a.AppointemntId == dto.AppointmentId);

            if (appointment is null)
                throw new KeyNotFoundException($"Nie znaleziono wizyty o Id = {dto.AppointmentId}.");

            if (appointment.DoctorId != doctorId)
                throw new UnauthorizedAccessException("Nie masz dostępu do tej wizyty.");

            appointment.Diagnosis = dto.Diagnosis;
            appointment.Status = AppointmentStatus.ZAL;

            _db.Appointments.Update(appointment);
            await _db.SaveChangesAsync();
        }

        public async Task CancelVisitAsync(int appointmentId, string reason, int doctorId)
        {
            var appointment = await _db.Appointments
                                       .FirstOrDefaultAsync(a => a.AppointemntId == appointmentId);

            if (appointment is null)
                throw new KeyNotFoundException($"Nie znaleziono wizyty o Id = {appointmentId}.");

            if (appointment.DoctorId != doctorId)
                throw new UnauthorizedAccessException("Nie masz dostępu do tej wizyty.");

            appointment.Status = AppointmentStatus.ANUL;
            // Jeśli chcesz przechować powód, dodaj w klasie Appointment pole CancellationReason i ustaw je tutaj:
            // appointment.CancellationReason = reason;

            _db.Appointments.Update(appointment);
            await _db.SaveChangesAsync();
        }

        public async Task CreateLabOrdersAsync(CreateLabOrdersDto dto, int doctorId)
        {
            var appointment = await _db.Appointments
                                       .FirstOrDefaultAsync(a => a.AppointemntId == dto.AppointmentId);

            if (appointment is null)
                throw new KeyNotFoundException($"Nie znaleziono wizyty o Id = {dto.AppointmentId}.");

            if (appointment.DoctorId != doctorId)
                throw new UnauthorizedAccessException("Nie masz dostępu do tej wizyty.");

            foreach (var labItem in dto.LabTests)
            {
                var labExam = new LabExam
                {
                    AppointmentId = dto.AppointmentId,
                    // Zwróć uwagę na to, jakie właściwości masz w LabExam:
                    // Zakładam, że masz co najmniej: ExamShortcut, Notes, Status, AppointmentId
                    ExamShortcut = labItem.TestCode,
                    Notes = labItem.Notes,
                    Status = LabExamStatus.ZLE,
                    // Możesz chcieć dodać pole np. OrderedByDoctorId = doctorId lub podobne,
                    // jeśli w modelu LabExam istnieje takie pole.
                };

                await _db.LabExams.AddAsync(labExam);
            }

            await _db.SaveChangesAsync();
        }

        public async Task CreatePhysicalOrderAsync(CreatePhysicalOrderDto dto, int doctorId)
        {
            var appointment = await _db.Appointments
                                       .FirstOrDefaultAsync(a => a.AppointemntId == dto.AppointmentId);

            if (appointment is null)
                throw new KeyNotFoundException($"Nie znaleziono wizyty o Id = {dto.AppointmentId}.");

            if (appointment.DoctorId != doctorId)
                throw new UnauthorizedAccessException("Nie masz dostępu do tej wizyty.");

            var physioExam = new PhysicalExam
            {
                AppointmentId = dto.AppointmentId,
                // Tutaj dodaj inne wymagane pola, np. jeśli masz PropertyCode, Notes, itp.
                Status = PhysicalExamStatus.ZLE
            };

            await _db.PhysicalExams.AddAsync(physioExam);
            await _db.SaveChangesAsync();
        }
    }
}
