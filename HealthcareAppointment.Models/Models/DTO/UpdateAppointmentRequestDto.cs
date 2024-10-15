using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.Domain;

namespace HealthcareAppointment.Models.Models.DTO
{
    public class UpdateAppointmentRequestDto
    {
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public int Status { get; set; }
    }
}
