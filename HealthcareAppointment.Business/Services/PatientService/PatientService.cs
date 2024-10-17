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
            patientDomain.Role = (int)Role.Patient;

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

        public async Task<PaginationList<PatientStatusDto>> GetAllPartient(PatientSpeParam patientSpeParam)
        {
            var spec = new BaseSpecification<User>(x =>
                (string.IsNullOrWhiteSpace(patientSpeParam.Search) || x.Name.Contains(patientSpeParam.Search.EncodingUTF8())) &&
                (x.Role == (int)Role.Patient)
            );

            if (patientSpeParam.IsDescending)
            {
                spec.AddOrderByDescending(x => x.Name);
            }
            else
            {
                spec.AddOrderByAscending(x => x.Name);
            }

            int skip = (patientSpeParam.pageIndex -1) * patientSpeParam.pageSize;
            int take = patientSpeParam.pageSize;
            spec.ApplyPaging(take, skip);

            var patientDomain = await patientRepository.GetAll(spec);
            var result = mapper.Map<PaginationList<PatientDto>>(patientDomain);

            var result2 = mapper.Map<PaginationList<PatientStatusDto>>(result);

            return result2;
        }

        public async Task<PatientDto> GetPatientById(Guid id, bool isInclude)
        {
            User? patient;
            var spec = new BaseSpecification<User>(x => x.Role == (int)Role.Patient);

            if (isInclude)
            {
                spec.AddInclude(x => x.AppointmentPatients);
                patient = await patientRepository.GetById(id,spec);
            }
            else
            {
                patient = await patientRepository.GetById(id, spec);
            }

            if (patient == null)
            {
                return null;
            }

            var result = mapper.Map<PatientDto>(patient);
            return result;
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
