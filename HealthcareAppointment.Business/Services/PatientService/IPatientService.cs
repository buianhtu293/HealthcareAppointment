using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.DTO;
using HealthcareAppointment.Models.Specifications;

namespace HealthcareAppointment.Business.Services.PatientService
{
    public interface IPatientService
    {
        Task<PaginationList<PatientStatusDto>> GetAllPartient(PatientSpeParam patientSpeParam);
        Task<PatientDto> GetPatientById(Guid id, bool isInclude);
        Task<PatientDto> CreatePatient(AddPatientRequestDto addPatientRequestDto);
        Task<PatientDto> UpdatePatient(Guid id, UpdatePatientRequestDto updatePatientRequestDto);
        Task<PatientDto> DeletePatient(Guid id);
    }
}
