using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DisplayProducts.Models
{
    public class Product
    {
        public ObjectId _id { get; set; }

        [BsonElement("id")]
        public int Productid { get; set; }

        [BsonElement("sku")]
        public string sku { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("price")]
        public double price { get; set; }

        [BsonElement("attribute")]
        public attribute attribute { get; set; }
    }

    public class attribute
    {
        public fantastic fantastic { get; set; }
        public rating rating { get; set; }
    }
    public class fantastic
    {
        [BsonElement("value")]
        public bool value { get; set; }

        [BsonElement("type")]
        public int type { get; set; }

        [BsonElement("name")]
        public string name { get; set; }
    }
    public class rating
    {
        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("type")]
        public string type { get; set; }

        [BsonElement("value")]
        public double value { get; set; }
               
    }
}

