using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;


public class People
{
    [BsonId]
    public ObjectId Id{get; set;}

    [BsonElement("name")]
    public string? Name{get; set;}

    [BsonElement("count")]
    public int Count{get; set;}
}