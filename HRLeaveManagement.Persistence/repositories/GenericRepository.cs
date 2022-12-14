using HRLeaveManagement.Application.Persistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly HRLeaveManagementDbContext dbContext;
        public GenericRepository(HRLeaveManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            await dbContext.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }
        public async Task<T> Get(int id)
        {
            return await dbContext.Set<T>().FindAsync();
        }
        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await dbContext.Set<T>().ToListAsync();
        }
        public async Task Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
