using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models.Models.DTO
{
    public class AddPatientRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Specialization { get; set; }
    }
}
