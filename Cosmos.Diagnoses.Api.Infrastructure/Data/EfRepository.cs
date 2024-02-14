using Ardalis.Specification.EntityFrameworkCore;
using Ardalis.Specification;
using Cosmos.Diagnoses.Api.Domain.Base.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Diagnoses.Api.Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class, IAggregateRoot
    {
        protected readonly CosmosContext _context;

        public EfRepository(CosmosContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(spec, ignoreQueryFilter).CountAsync(cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CountAsync(bool ignoreQueryFilters = false)
        {
            if (ignoreQueryFilters)
            {
                return await _context.Set<T>().IgnoreQueryFilters().CountAsync();
            }
            else
            {
                return await _context.Set<T>().CountAsync();
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T> FirstAsync(ISpecification<T> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(spec, ignoreQueryFilter).FirstAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(spec, ignoreQueryFilter).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TResult> FirstOrDefaultAsync<TResult>(ISpecification<T, TResult> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(spec, ignoreQueryFilter).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _context.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _context.Set<T>().FindAsync(keyValues, cancellationToken);
        }
        public async Task<T> GetByIdAsync(object keyValues, CancellationToken cancellationToken = default)
        {
            return await _context.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<T> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _context.Set<T>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(bool ignoreQueryFilter = false, CancellationToken cancellationToken = default)
        {
            if (ignoreQueryFilter)
            {
                return await _context.Set<T>().IgnoreQueryFilters().ToListAsync(cancellationToken);
            }
            else
            {
                return await _context.Set<T>().ToListAsync(cancellationToken);
            }

        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(spec, ignoreQueryFilter).ToListAsync(cancellationToken);
        }

        public async Task<List<TResult>> ListAsync<TResult>(ISpecification<T, TResult> spec, bool ignoreQueryFilter = false, CancellationToken cancellationToken = default)
        {
            return await ApplySpecification(spec, ignoreQueryFilter).ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec, bool ignoreQueryFilter = false)
        {
            if (ignoreQueryFilter)
            {
                return SpecificationEvaluator.Default.GetQuery(_context.Set<T>().IgnoreQueryFilters().AsQueryable(), spec);
            }
            else
            {
                return SpecificationEvaluator.Default.GetQuery(_context.Set<T>().AsQueryable(), spec);
            }
        }

        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> spec, bool ignoreQueryFilter = false)
        {
            if (spec is null) throw new ArgumentNullException("Specification is required");
            if (spec.Selector is null) throw new SelectorNotFoundException();

            if (ignoreQueryFilter)
            {
                return SpecificationEvaluator.Default.GetQuery(_context.Set<T>().IgnoreQueryFilters().AsQueryable(), spec);
            }
            else
            {
                return SpecificationEvaluator.Default.GetQuery(_context.Set<T>().AsQueryable(), spec);
            }
        }
    }
}
