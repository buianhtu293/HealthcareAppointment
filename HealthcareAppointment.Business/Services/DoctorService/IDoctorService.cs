using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.DTO;
using HealthcareAppointment.Models.Specifications;

namespace HealthcareAppointment.Business.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<PaginationList<DoctorDto>> GetAllDoctor(DoctorSpeParam doctorSpeParam);
        Task<DoctorDto> GetDoctorById(Guid id, bool inClude);
        Task<DoctorDto> CreateDoctor(AddDoctorRequestDto addDoctorRequestDto);
        Task<DoctorDto> UpdateDoctor(Guid id, UpdateDoctorRequestDto updateDoctorRequestDto);
        Task<DoctorDto> DeleteDoctor(Guid id);
    }
}
