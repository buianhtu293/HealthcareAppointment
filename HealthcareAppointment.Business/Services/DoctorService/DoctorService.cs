using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareAppointment.Models.Interfaces;
using HealthcareAppointment.Models.Models.Domain;
using HealthcareAppointment.Models.Models.DTO;

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

        public async Task<List<DoctorDto>> GetAllDoctor()
        {
            var userDomains = await doctorRepository.GetAll();

            var doctorDomain = userDomains.Where(x => x.Role == 0);

            return mapper.Map<List<DoctorDto>>(doctorDomain);
        }

        public async Task<DoctorDto> GetDoctorById(Guid id)
        {
            var doctorDomain = await doctorRepository.GetById(id);

            if (doctorDomain == null)
            {
                return null;
            }

            return mapper.Map<DoctorDto>(doctorDomain);
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
