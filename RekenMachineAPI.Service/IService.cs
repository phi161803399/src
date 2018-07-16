using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RekenMachineAPI.Service
{
    public interface IService<T>
    {
        //DAPPER
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(int id);
        void OverrideEntityTypeName(string entityTypeName);

        //EF
        IQueryable<T> GetEf();        
        Task<T> GetAsyncEf(int id);
        void Add(T entity);
        void Delete(T entity);
        T Attach(T entity);
        Task<int> SaveChangesAsync();        
    }
}