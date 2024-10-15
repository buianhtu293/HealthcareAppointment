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
    public class DoctorRepository : BaseRepository<User, Guid>, IDoctorRepository
    {
        public DoctorRepository(HealthcareDbContext dbContext) : base(dbContext)
        {
        }
    }
}
