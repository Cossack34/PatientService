using Microsoft.EntityFrameworkCore;
using PatientService.Core.Abstractions.Repositories;
using PatientService.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.DataAccess.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _dbContext;
        private readonly DbSet<T> _entitySet;
        public EfRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
        }

        /// <summary>
        /// Запросить все сущности в базе
        /// </summary>
        /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
        /// <returns>IQueryable массив сущностей</returns>
        public virtual IQueryable<T> GetAll(bool asNoTracking = false)
        {
            return asNoTracking ? _entitySet.AsNoTracking() : _entitySet;
        }

        /// <summary>
        /// Запросить все сущности в базе
        /// </summary>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <param name="asNoTracking">Вызвать с AsNoTracking</param>
        /// <returns>Список сущностей</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAll().ToListAsync();
        }

        /// <summary>
        /// Получить сущность по ID
        /// </summary>
        /// <param name="id">ID сущности</param>
        /// <returns>сущность</returns>
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entitySet.FindAsync((object)id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids)
        {
            var entities = await _dbContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
            return entities;
        }
    }
}
