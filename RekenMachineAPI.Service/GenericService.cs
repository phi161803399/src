using System.Collections.Generic;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace RekenMachineAPI.Service
{
    public class GenericService<T> : IService<T> where T : class
    {
        private string _entity;
        public IBaseService BaseService { get; set; }        

        public GenericService()
        {
            var pluralizationService = PluralizationService.CreateService(new CultureInfo("en-US"));
            _entity = pluralizationService.Pluralize(typeof(T).Name);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await BaseService.WithConnection(
                async c => await c.QueryAsync<T>($"select * from {_entity}"));
        }

        public IQueryable<T> GetEf()
        {
            return BaseService.DbContext.Set<T>();
        }

        public async Task<T> GetAsync(int id)
        {
            return await BaseService.WithConnection(
                async c => await c.QueryFirstOrDefaultAsync<T>($"select * from {_entity} where id = {id}"));
        }

        public async Task<T> GetAsyncEf(int id)
        {
            return await BaseService.DbContext.Set<T>().FindAsync(id);
        }

        public void Add(T entity)
        {
            BaseService.DbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            BaseService.DbContext.Set<T>()
                .Remove(BaseService.DbContext.Set<T>().Attach(entity));
        }

        public T Attach(T entity)
        {
            return BaseService.DbContext.Set<T>().Attach(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await BaseService.DbContext.SaveChangesAsync();
        }

        public void OverrideEntityTypeName(string entityTypeName)
        {
            _entity = entityTypeName;
        }
    }
}