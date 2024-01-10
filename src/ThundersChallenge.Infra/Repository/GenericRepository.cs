

using Microsoft.EntityFrameworkCore;
using ThundersChallenge.Domain.Common;
using ThundersChallenge.Infra.Context;
using ThundersChallenge.Infra.Repository.Interface;

namespace ThundersChallenge.Infra.Repository;

public class GenericRepository<T>(InMemoryDatabaseContext databaseContext) : IGenericRepository<T> where T : BaseEntity
{
    protected readonly InMemoryDatabaseContext _databaseContext = databaseContext;

    public async Task<IEnumerable<T>> GetAllAsync()
       => await _databaseContext.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(Guid id)
        => await _databaseContext.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));

    public async Task<T> CreateAsync(T entity)
    {
        await _databaseContext.AddAsync(entity);
        await _databaseContext.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        _databaseContext.Set<T>().Remove(entity);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _databaseContext.Update(entity);
        await _databaseContext.SaveChangesAsync();
    }
}
