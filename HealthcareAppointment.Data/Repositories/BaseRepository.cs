using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Data.Data;
using HealthcareAppointment.Models.Interfaces;
using HealthcareAppointment.Models.Specifications;
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

        public async Task<PaginationList<T>> GetAll(ISpecification<T> spec)
        {
            var entities = dbContext.Set<T>().AsQueryable();

            if(spec.Fillter != null)
            {
                entities = entities.Where(spec.Fillter);
            }

            if(spec.OrderByAscending != null)
            {
                entities = entities.OrderBy(spec.OrderByAscending);
            }

            if(spec.OrderByDescending != null)
            {
                entities = entities.OrderByDescending(spec.OrderByDescending);
            }

            var totalRecords = await entities.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalRecords / spec.Take);

            if (spec.IsPagingEnable)
            {
                entities = entities.Skip(spec.Skip).Take(spec.Take);
            }

            var items = await entities.ToListAsync();

            var pageNumber = spec.Skip / spec.Take + 1;

            var result = new PaginationList<T>(items, pageNumber, totalPages, totalRecords);
            return result;
        }

        public async Task<T?> GetById(P id, ISpecification<T> spec)
        {
            var entities = dbContext.Set<T>().AsQueryable();

            if (spec.Fillter != null)
            {
                entities = entities.Where(spec.Fillter);
            }

            if (spec.Includes != null && spec.Includes.Count > 0)
            {
                foreach( var item in spec.Includes)
                {
                    entities = entities.Include(item);
                }
            }

            var entity = await entities.FirstOrDefaultAsync(x => EF.Property<P>(x, "Id").Equals(id));

            return entity;
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
