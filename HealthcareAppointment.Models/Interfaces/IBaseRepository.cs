using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthcareAppointment.Models.Specifications;

namespace HealthcareAppointment.Models.Interfaces
{
    public interface IBaseRepository<T, P>
    {
        Task<PaginationList<T>> GetAll(ISpecification<T> spec);
        Task<T?> GetById(P id, ISpecification<T> spec);
        Task<T> Create(T entity);
        Task<T?> Update(P id, T entity);
        Task<T?> Delete(P id);
    }
}
