using HealthcareAppointment.Business.Services.PatientService;
using HealthcareAppointment.Models.Models.DTO;
using HealthcareAppointment.Models.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService patientService;

        public PatientsController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatient([FromQuery] PatientSpeParam patientSpeParam)
        {
            return Ok(await patientService.GetAllPartient(patientSpeParam));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetPatientById([FromRoute] Guid id, [FromQuery] bool isIncludeAppointment = false)
        {
            var patientDto = await patientService.GetPatientById(id, isIncludeAppointment);

            if(patientDto == null)
            {
                return NotFound();
            }

            return Ok(patientDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] AddPatientRequestDto addPatientRequestDto)
        {
            var patientDto = await patientService.CreatePatient(addPatientRequestDto);

            return CreatedAtAction(nameof(GetPatientById), new { id = patientDto.Id}, patientDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdatePatient([FromRoute] Guid id, [FromBody] UpdatePatientRequestDto updatePatientRequestDto)
        {
            var patientDto = await patientService.UpdatePatient(id, updatePatientRequestDto);

            if(patientDto == null)
            {
                return NotFound();
            }

            return Ok(patientDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeletePatient([FromRoute] Guid id)
        {
            var patientDto = await patientService.DeletePatient(id);

            return Ok(patientDto);
        }
    }
}
