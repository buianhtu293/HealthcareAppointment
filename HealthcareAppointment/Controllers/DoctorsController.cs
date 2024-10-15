using HealthcareAppointment.Business.Services.DoctorService;
using HealthcareAppointment.Business.Services.PatientService;
using HealthcareAppointment.Models.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctor() 
        {
            return Ok(await doctorService.GetAllDoctor());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetDoctorById([FromRoute] Guid id)
        {
            var doctorDto = await doctorService.GetDoctorById(id);

            if (doctorDto == null)
            {
                return NotFound();
            }

            return Ok(doctorDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] AddDoctorRequestDto addDoctorRequestDto)
        {
            var doctorDto = await doctorService.CreateDoctor(addDoctorRequestDto);

            return CreatedAtAction(nameof(GetDoctorById), new { id = doctorDto.Id }, doctorDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateDoctor([FromRoute] Guid id, [FromBody] UpdateDoctorRequestDto updateDoctorRequestDto)
        {
            var doctorDto = await doctorService.UpdateDoctor(id, updateDoctorRequestDto);

            if (doctorDto == null)
            {
                return NotFound();
            }

            return Ok(doctorDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteDoctor([FromRoute] Guid id)
        {
            var doctorDto = await doctorService.DeleteDoctor(id);

            return Ok(doctorDto);
        }
    }
}
