using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Data.Data;
using HealthcareAppointment.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointment.Data.Repositories
{
    public class BaseRepository<T, P> : IBaseRepository<T, P> where T : class
    {
        private readonly HealthcareDbContext dbContext;

        public BaseRepository(HealthcareDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> Create(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> Delete(P id)
        {
            var entity = await dbContext.Set<T>().FindAsync(id);
            if(entity == null)
            {
                return null;
            }

            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(P id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T?> Update(P id, T entity)
        {
            var existingEntity = await dbContext.Set<T>().FindAsync(id);

            if(existingEntity == null)
            {
                return null;
            }

            dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync();

            return existingEntity;
        }
    }
}
