using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HealthcareAppointment.Models.Interfaces;
using HealthcareAppointment.Models.Models.Domain;
using HealthcareAppointment.Models.Models.DTO;

namespace HealthcareAppointment.Business.Services.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository patientRepository;
        private readonly IMapper mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            this.patientRepository = patientRepository;
            this.mapper = mapper;
        }

        public async Task<PatientDto> CreatePatient(AddPatientRequestDto addPatientRequestDto)
        {
            var patientDomain = mapper.Map<User>(addPatientRequestDto);
            patientDomain.Role = 1;

            patientDomain = await patientRepository.Create(patientDomain);

            var patientDto = mapper.Map<PatientDto>(patientDomain);

            return patientDto;
        }

        public async Task<PatientDto> DeletePatient(Guid id)
        {
            var patientDomain = await patientRepository.Delete(id);

            if (patientDomain == null)
            {
                return null;
            }

            return mapper.Map<PatientDto>(patientDomain);
        }

        public async Task<List<PatientDto>> GetAllPartient()
        {
            var userDomains = await patientRepository.GetAll();

            var patientDomain = userDomains.Where(x => x.Role == 1);

            return mapper.Map<List<PatientDto>>(patientDomain);
        }

        public async Task<PatientDto> GetPatientById(Guid id)
        {
            var patientDomain = await patientRepository.GetById(id);

            if(patientDomain == null)
            {
                return null;
            }

            return mapper.Map<PatientDto>(patientDomain);
        }

        public async Task<PatientDto> UpdatePatient(Guid id, UpdatePatientRequestDto updatePatientRequestDto)
        {
            var patientDomain = mapper.Map<User>(updatePatientRequestDto);
            patientDomain.Id = id;

            patientDomain = await patientRepository.Update(id, patientDomain);

            return mapper.Map<PatientDto>(patientDomain);
        }
    }
}
