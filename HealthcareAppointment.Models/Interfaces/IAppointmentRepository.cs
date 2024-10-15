using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Models.Domain;

namespace HealthcareAppointment.Models.Interfaces
{
    public interface IAppointmentRepository : IBaseRepository<Appointment, Guid>
    {
        public Task<Appointment?> CancelAppointment(Guid id);
    }
}
