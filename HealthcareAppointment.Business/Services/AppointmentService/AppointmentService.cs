using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareAppointment.Models.Interfaces;
using HealthcareAppointment.Models.Models.Domain;
using HealthcareAppointment.Models.Models.DTO;

namespace HealthcareAppointment.Business.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
        }

        public async Task<AppointmentDto> CancelAppointment(Guid id)
        {
            var appointmentDomain = await appointmentRepository.CancelAppointment(id);

            if (appointmentDomain == null)
            {
                return null;
            }

            return mapper.Map<AppointmentDto>(appointmentDomain);
        }

        public async Task<AppointmentDto> CreateAppointment(AddAppointmentRequestDto addAppointmentRequestDto)
        {
            var appointmentDomain = mapper.Map<Appointment>(addAppointmentRequestDto);

            appointmentDomain = await appointmentRepository.Create(appointmentDomain);

            var appointmentDto = mapper.Map<AppointmentDto>(appointmentDomain);

            return appointmentDto;
        }

        public async Task<AppointmentDto> DeleteAppointment(Guid id)
        {
            var appointmentDomain = await appointmentRepository.Delete(id);

            if (appointmentDomain == null)
            {
                return null;
            }

            return mapper.Map<AppointmentDto>(appointmentDomain);
        }

        public async Task<List<AppointmentDto>> GetAllAppointment()
        {
            var appointmentDomain = await appointmentRepository.GetAll();

            return mapper.Map<List<AppointmentDto>>(appointmentDomain);
        }

        public async Task<List<AppointmentDto>> GetAppointmentByDoctorId(Guid doctorId, int pageNumber, int pageSize)
        {
            var appointmentDomains = await appointmentRepository.GetAll();

            var skipResult = (pageNumber - 1) * pageSize;

            var appointmentDoctors = appointmentDomains.Where(x => x.DoctorId == doctorId).Skip(skipResult).Take(pageSize);

            return mapper.Map<List<AppointmentDto>>(appointmentDoctors);
        }

        public async Task<AppointmentDto> GetAppointmentById(Guid id)
        {
            var appointmentDomain = await appointmentRepository.GetById(id);

            if (appointmentDomain == null)
            {
                return null;
            }

            return mapper.Map<AppointmentDto>(appointmentDomain);
        }

        public async Task<AppointmentDto> UpdateAppointment(Guid id, UpdateAppointmentRequestDto updateAppointmentRequestDto)
        {
            var appoimentDomain = mapper.Map<Appointment>(updateAppointmentRequestDto);
            appoimentDomain.Id = id;

            appoimentDomain = await appointmentRepository.Update(id, appoimentDomain);

            return mapper.Map<AppointmentDto>(appoimentDomain);
        }
    }
}
