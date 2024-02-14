using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Domain.Base.Interfaces
{
    public interface IAsyncRepository<T> where T : class, IAggregateRoot
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<int> CountAsync(bool ignoreQueryFilters = false);
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(object keyValues, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
        Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<T> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default);
        Task<T> FirstAsync(ISpecification<T> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default);
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default);
        Task<TResult> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAllAsync(bool ignoreQueryFilter = false, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default);
        Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default);
    }
}

