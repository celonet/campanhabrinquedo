﻿using MongoDB.Bson.Serialization.Attributes;

namespace Transporte.Full
{
    public class Age : Rastreabillity
    {
        public Age(int year, string value) : base(year) => Value = value;

        [BsonElement("value")]
        public string Value { get; set; }
    }
}