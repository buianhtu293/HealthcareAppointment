using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.DTO;
using HealthcareAppointment.Models.Specifications;

namespace HealthcareAppointment.Business.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<PaginationList<AppointmentDto>> GetAllAppointment(AppointmentSpeParam appointmentSpeParam);
        Task<AppointmentDto> GetAppointmentById(Guid id, bool isInclude);
        Task<AppointmentDto> CreateAppointment(AddAppointmentRequestDto addAppointmentRequestDto);
        Task<AppointmentDto> UpdateAppointment(Guid id, UpdateAppointmentRequestDto updateAppointmentRequestDto);
        Task<AppointmentDto> DeleteAppointment(Guid id);
        Task<AppointmentDto> CancelAppointment(Guid id);
        Task<PaginationList<AppointmentDto>> GetAppointmentByDoctorId(Guid doctorId, AppointmentSpeParam appointmentSpeParam);
    }
}
