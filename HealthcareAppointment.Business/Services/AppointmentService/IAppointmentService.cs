using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.DTO;

namespace HealthcareAppointment.Business.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<List<AppointmentDto>> GetAllAppointment();
        Task<AppointmentDto> GetAppointmentById(Guid id);
        Task<AppointmentDto> CreateAppointment(AddAppointmentRequestDto addAppointmentRequestDto);
        Task<AppointmentDto> UpdateAppointment(Guid id, UpdateAppointmentRequestDto updateAppointmentRequestDto);
        Task<AppointmentDto> DeleteAppointment(Guid id);
        Task<AppointmentDto> CancelAppointment(Guid id);
        Task<List<AppointmentDto>> GetAppointmentByDoctorId(Guid doctorId, int pageNumber, int pageSize);
    }
}
