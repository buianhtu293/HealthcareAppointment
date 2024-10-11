using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models.Models.Domain
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public User PatientUser { get; set; } = null!;
        public Guid DoctorId { get; set; }
        public User DoctorUser { get; set; } = null!;
        public DateOnly Date { get; set; }
        public int Status { get; set; }
    }
}
