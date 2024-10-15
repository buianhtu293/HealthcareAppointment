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
    public class PatientRepository : BaseRepository<User, Guid>, IPatientRepository
    {
        public PatientRepository(HealthcareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
