using Dip.Application;
using Dip.Domain;
using Dip.Domain.Repositories;
using Dip.Infrastructure.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dip.Infrastructure
{
    public class MongoRepository<T> : IRepository<T> where T  : Aggregate
    {
        private readonly MongoContext _mongoContext;

        public MongoRepository(MongoContext mongoContext)
        {
            _mongoContext = mongoContext;
        }

        public Task Add(T entity, CancellationToken ctx = default)
        {
            return _mongoContext.GetCollection<T>(nameof(entity)).ReplaceOneAsync(x => x.Id == entity.Id, entity, cancellationToken: ctx);
        }

        public void AddRange(IEnumerable<Aggregate> entities)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public bool Contains(ISpecification<Aggregate> specification = null)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Expression<Func<Aggregate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Contains(ISpecification<T> specification = null)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(ISpecification<Aggregate> specification = null)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Aggregate, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(ISpecification<T> specification = null)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aggregate> Find(ISpecification<Aggregate> specification = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(ISpecification<T> specification = null)
        {
            throw new NotImplementedException();
        }

        public Aggregate FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Aggregate entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Aggregate> entities)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Aggregate entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        T IRepository<T>.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
