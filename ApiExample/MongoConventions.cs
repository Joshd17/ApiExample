using Dip.Application.Features.Dip.Queries;
using Dip.Domain.Aggregates;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace ApiExample;
public static class MongoConventions
{
    public static IServiceCollection AddMongoConventions(this IServiceCollection coll)
    {
        MongoDefaults.GuidRepresentation = GuidRepresentation.Standard;

        if (!BsonClassMap.IsClassMapRegistered(typeof(DecisionInPrinciple)))
        {
            BsonClassMap.RegisterClassMap<DecisionInPrinciple>(c =>
            {
                c.AutoMap();
                c.SetIgnoreExtraElements(true);
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(Audit)))
        {
            BsonClassMap.RegisterClassMap<Audit>(c =>
            {
                c.AutoMap();
                c.SetIgnoreExtraElements(true);
            });
        }

        if (!BsonClassMap.IsClassMapRegistered(typeof(DipsWithAudits)))
        {
            BsonClassMap.RegisterClassMap<DipsWithAudits>(c =>
            {
                c.AutoMap();
                c.SetIgnoreExtraElements(true);
            });
        }


        if (!BsonClassMap.IsClassMapRegistered(typeof(DipCreatedEvent)))
        {
            BsonClassMap.RegisterClassMap<DipCreatedEvent>(c =>
            {
                c.AutoMap();
                c.SetIgnoreExtraElements(true);
            });
        }

        return coll;
    }
}
