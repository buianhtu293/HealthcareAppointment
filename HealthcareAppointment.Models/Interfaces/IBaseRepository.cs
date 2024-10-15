using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Models.Interfaces
{
    public interface IBaseRepository<T, P>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(P id);
        Task<T> Create(T entity);
        Task<T?> Update(P id, T entity);
        Task<T?> Delete(P id);
    }
}
