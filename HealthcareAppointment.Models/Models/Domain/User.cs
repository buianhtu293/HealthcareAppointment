using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Specialization { get; set; }

        public ICollection<Appointment> AppointmentPatients { get; } = new List<Appointment>();
        public ICollection<Appointment> AppointmentDoctors { get; } = new List<Appointment>();
    }
}
