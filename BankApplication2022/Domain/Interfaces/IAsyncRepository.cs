using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAsyncRepository<T> where T : class
    {
        T GetByIdAsync(Guid Id);
        IList<T> ListAllAsync();
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
    }
}
