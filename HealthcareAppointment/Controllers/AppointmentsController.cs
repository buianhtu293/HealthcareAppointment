using HealthcareAppointment.Business.Services.AppointmentService;
using HealthcareAppointment.Models.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAppointment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointment()
        {
            return Ok(await appointmentService.GetAllAppointment());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetAppointmentById([FromRoute] Guid id)
        {
            var appointmentDto = await appointmentService.GetAppointmentById(id);

            if (appointmentDto == null)
            {
                return NotFound();
            }

            return Ok(appointmentDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AddAppointmentRequestDto addAppointmentRequestDto)
        {
            var appointmentDto = await appointmentService.CreateAppointment(addAppointmentRequestDto);

            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointmentDto.Id }, appointmentDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAppointment([FromRoute] Guid id, [FromBody] UpdateAppointmentRequestDto updateAppointmentRequestDto)
        {
            var appointmentDto = await appointmentService.UpdateAppointment(id, updateAppointmentRequestDto);

            if (appointmentDto == null)
            {
                return NotFound();
            }

            return Ok(appointmentDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAppointment([FromRoute] Guid id)
        {
            var appointmentDto = await appointmentService.DeleteAppointment(id);

            return Ok(appointmentDto);
        }

        [HttpPatch]
        [Route("{id:Guid}/cancel")]
        public async Task<IActionResult> CancelAppointment([FromRoute] Guid id)
        {
            var appointmentDto = await appointmentService.CancelAppointment(id);

            return Ok(appointmentDto);
        }

        [HttpGet]
        [Route("{doctorId:Guid}/search")]
        public async Task<IActionResult> GetAppointmentByDoctorId([FromRoute] Guid doctorId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        {
            var appointmentDtos = await appointmentService.GetAppointmentByDoctorId(doctorId, pageNumber, pageSize);

            return Ok(appointmentDtos);
        }
    }
}
