using Dip.Domain.Aggregates;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip.Infrastructure.Contexts
{
    public class MongoContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;

        public MongoContext(MongoClient client)
        {
            _client = client;
            _db = _client.GetDatabase("database");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }
        public IMongoCollection<DecisionInPrinciple> DipCollection => _db.GetCollection<DecisionInPrinciple>("dip");
    }
}
