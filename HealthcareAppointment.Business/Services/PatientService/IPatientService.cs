using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.DTO;

namespace HealthcareAppointment.Business.Services.PatientService
{
    public interface IPatientService
    {
        Task<List<PatientDto>> GetAllPartient();
        Task<PatientDto> GetPatientById(Guid id);
        Task<PatientDto> CreatePatient(AddPatientRequestDto addPatientRequestDto);
        Task<PatientDto> UpdatePatient(Guid id, UpdatePatientRequestDto updatePatientRequestDto);
        Task<PatientDto> DeletePatient(Guid id);
    }
}
