using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareAppointment.Models.Interfaces;
using HealthcareAppointment.Models.Models.Domain;
using HealthcareAppointment.Models.Models.DTO;
using HealthcareAppointment.Models.Specifications;
using ShareKernel.Enum;

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

        public async Task<PaginationList<AppointmentDto>> GetAllAppointment(AppointmentSpeParam appointmentSpeParam)
        {
            var spec = new BaseSpecification<Appointment>(x =>
                (appointmentSpeParam.Statuses.Contains((Status)x.Status)) &&
                (appointmentSpeParam.FromDate == DateOnly.MinValue || x.Date >= appointmentSpeParam.FromDate) &&
                (appointmentSpeParam.ToDate == DateOnly.MaxValue || x.Date <= appointmentSpeParam.ToDate)
            );

            if (appointmentSpeParam.IsDescending)
            {
                spec.AddOrderByDescending(x => x.Date);
            }
            else
            {
                spec.AddOrderByAscending(x => x.Date);
            }

            int skip = (appointmentSpeParam.pageIndex - 1) * appointmentSpeParam.pageSize;
            int take = appointmentSpeParam.pageSize;

            spec.ApplyPaging(take, skip);

            var appointmentDomain = await appointmentRepository.GetAll(spec);

            var result = mapper.Map<PaginationList<AppointmentDto>>(appointmentDomain);

            return result;
        }

        public async Task<PaginationList<AppointmentDto>> GetAppointmentByDoctorId(Guid doctorId, AppointmentSpeParam appointmentSpeParam)
        {
            var spec = new BaseSpecification<Appointment>();
            if(appointmentSpeParam.Statuses == null)
            {
                spec = new BaseSpecification<Appointment>(x =>
                 x.DoctorId == doctorId &&
                 //(appointmentSpeParam.Statuses.Contains((Status)x.Status)) &&
                 (appointmentSpeParam.FromDate == DateOnly.MinValue || x.Date >= appointmentSpeParam.FromDate) &&
                 (appointmentSpeParam.ToDate == DateOnly.MaxValue || x.Date <= appointmentSpeParam.ToDate)
             );
            }
            else
            {
                spec = new BaseSpecification<Appointment>(x =>
                 x.DoctorId == doctorId &&
                 (appointmentSpeParam.Statuses.Contains((Status)x.Status)) &&
                 (appointmentSpeParam.FromDate == DateOnly.MinValue || x.Date >= appointmentSpeParam.FromDate) &&
                 (appointmentSpeParam.ToDate == DateOnly.MaxValue || x.Date <= appointmentSpeParam.ToDate)
             );
            }
            

            if (appointmentSpeParam.IsDescending)
            {
                spec.AddOrderByDescending(x => x.Date);
            }
            else
            {
                spec.AddOrderByAscending(x => x.Date);
            }

            int skip = (appointmentSpeParam.pageIndex - 1) * appointmentSpeParam.pageSize;
            int take = appointmentSpeParam.pageSize;

            spec.ApplyPaging(take, skip);

            var appointmentDomain = await appointmentRepository.GetAll(spec);

            var result = mapper.Map<PaginationList<AppointmentDto>>(appointmentDomain);

            return result;
        }

        public async Task<AppointmentDto> GetAppointmentById(Guid id, bool isInclude)
        {
            var spec = new BaseSpecification<Appointment>();
            if (isInclude)
            {
                spec.AddInclude(x => x.PatientUser);
                spec.AddInclude(x => x.DoctorUser);
            }

            var appointmentDomain = await appointmentRepository.GetById(id, spec);

            if(appointmentDomain == null)
            {
                return null;
            }

            var result = mapper.Map<AppointmentDto>(appointmentDomain);

            return result;
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
