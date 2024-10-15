using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Data.Data;
using HealthcareAppointment.Models.Interfaces;
using HealthcareAppointment.Models.Models.Domain;

namespace HealthcareAppointment.Data.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment, Guid>, IAppointmentRepository
    {
        private readonly HealthcareDbContext dbContext;

        public AppointmentRepository(HealthcareDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Appointment?> CancelAppointment(Guid id)
        {
            var existingAppointment = await dbContext.Appointments.FindAsync(id);

            if (existingAppointment == null)
            {
                return null;
            }

            existingAppointment.Status = 2;

            await dbContext.SaveChangesAsync();

            return existingAppointment;
        }
    }
}
