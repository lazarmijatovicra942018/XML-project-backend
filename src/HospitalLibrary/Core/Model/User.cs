using AirplaneTicketingLibrary.Core.Enum;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel.DataAnnotations;

namespace AirplaneTicketingLibrary.Core.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public String Username { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public Role Role { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }  
        public String PlaceOfLiving { get; set; }
    }
}
