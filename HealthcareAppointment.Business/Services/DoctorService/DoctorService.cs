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
using ShareKernel.CoreService;
using ShareKernel.Enum;

namespace HealthcareAppointment.Business.Services.DoctorService
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository doctorRepository;
        private readonly IMapper mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            this.doctorRepository = doctorRepository;
            this.mapper = mapper;
        }
        public async Task<DoctorDto> CreateDoctor(AddDoctorRequestDto addDoctorRequestDto)
        {
            var doctorDomain = mapper.Map<User>(addDoctorRequestDto);
            doctorDomain.Role = 0;

            doctorDomain = await doctorRepository.Create(doctorDomain);

            var doctorDto = mapper.Map<DoctorDto>(doctorDomain);

            return doctorDto;
        }

        public async Task<DoctorDto> DeleteDoctor(Guid id)
        {
            var doctorDomain = await doctorRepository.Delete(id);

            if (doctorDomain == null)
            {
                return null;
            }

            return mapper.Map<DoctorDto>(doctorDomain);
        }

        public async Task<PaginationList<DoctorDto>> GetAllDoctor(DoctorSpeParam doctorSpeParam)
        {
            var spec = new BaseSpecification<User>(x =>
                (string.IsNullOrWhiteSpace(doctorSpeParam.Search) || x.Name.Contains(doctorSpeParam.Search.EncodingUTF8())) &&
                (x.Role == (int)Role.Doctor)
            );

            if (doctorSpeParam.IsDescending)
            {
                spec.AddOrderByDescending(x => x.Name);
            }
            else
            {
                spec.AddOrderByAscending(x => x.Name);
            }

            int skip = (doctorSpeParam.pageIndex - 1) * doctorSpeParam.pageSize;
            int take = doctorSpeParam.pageSize;
            spec.ApplyPaging(take, skip);

            var doctorDomain = await doctorRepository.GetAll(spec);
            var result = mapper.Map<PaginationList<DoctorDto>>(doctorDomain);

            return result;
        }

        public async Task<DoctorDto> GetDoctorById(Guid id, bool isInclude)
        {
            User? doctor;
            var spec = new BaseSpecification<User>(x => x.Role == (int)Role.Doctor);

            if (isInclude)
            {
                spec.AddInclude(x => x.AppointmentDoctors);
                doctor = await doctorRepository.GetById(id, spec);
            }
            else
            {
                doctor = await doctorRepository.GetById(id, spec);
            }

            if(doctor == null)
            {
                return null;
            }

            var result = mapper.Map<DoctorDto>(doctor);
            return result;
        }

        public async Task<DoctorDto> UpdateDoctor(Guid id, UpdateDoctorRequestDto updateDoctorRequestDto)
        {
            var doctorDomain = mapper.Map<User>(updateDoctorRequestDto);
            doctorDomain.Id = id;

            doctorDomain = await doctorRepository.Update(id, doctorDomain);

            return mapper.Map<DoctorDto>(doctorDomain);
        }
    }
}
