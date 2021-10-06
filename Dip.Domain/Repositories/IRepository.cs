using Dip.Application;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Dip.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindById(int id);

        IEnumerable<TEntity> Find(ISpecification<TEntity> specification = null);

        Task Add(TEntity entity, CancellationToken cancellationToken = default);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        bool Contains(ISpecification<TEntity> specification = null);
        bool Contains(Expression<Func<TEntity, bool>> predicate);

        int Count(ISpecification<TEntity> specification = null);
        int Count(Expression<Func<TEntity, bool>> predicate);
    }
}
