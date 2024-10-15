using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.DTO;

namespace HealthcareAppointment.Business.Services.DoctorService
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> GetAllDoctor();
        Task<DoctorDto> GetDoctorById(Guid id);
        Task<DoctorDto> CreateDoctor(AddDoctorRequestDto addDoctorRequestDto);
        Task<DoctorDto> UpdateDoctor(Guid id, UpdateDoctorRequestDto updateDoctorRequestDto);
        Task<DoctorDto> DeleteDoctor(Guid id);
    }
}
