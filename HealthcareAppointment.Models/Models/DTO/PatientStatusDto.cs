using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models.Models.DTO
{
    public class PatientStatusDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Specialization { get; set; }
    }
}
