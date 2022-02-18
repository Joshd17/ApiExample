using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Dip.Domain.Aggregates;
[BsonDiscriminator("TestItem")]
public class Audit : Aggregate
{
    public string t { get; set; }
    public Guid ObjectId { get; set; }
    public DateTime CreationDate { get; set; }
    public object Item { get; set; }
}