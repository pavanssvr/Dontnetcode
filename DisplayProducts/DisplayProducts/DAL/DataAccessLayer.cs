using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using DisplayProducts.Models;
using Autofac;

namespace DisplayProducts.DAL
{
    public class DataAccessLayer : IDataAccessLayer
    {
        MongoClient mongoClient;
        IMongoDatabase mongoDB;
        public DataAccessLayer()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            mongoDB = mongoClient.GetDatabase("mydb", null);
        }
        public IEnumerable<Product> GetProducts()
        {
            return mongoDB.GetCollection<Product>("Products").Find(i => i.Productid > 0).ToList();
        }

        public IEnumerable<Product> GetProductsByPrice(double price)
        {
            return mongoDB.GetCollection<Product>("Products").Find(i => i.price >= price).ToList();
        }
        
        public IEnumerable<Product> GetProductsByPriceRange(double minPrice,double maxPrice)
        {
            return mongoDB.GetCollection<Product>("Products").Find(i => i.price >= minPrice && 
                                                                        i.price <= maxPrice).ToList();
        }

        public IEnumerable<Product> GetProductsByName(string name)
        {
            return mongoDB.GetCollection<Product>("Products").Find(i => i.Name.ToLower() == name.ToLower()).ToList();
        }

        public IEnumerable<Product> GetProductsByFantasticAttribute(bool value)
        {
            return mongoDB.GetCollection<Product>("Products").Find(i => i.attribute.fantastic.value == value).ToList();
        }

        public IEnumerable<Product> GetProductsByRatingAttribute(double value)
        {
            return mongoDB.GetCollection<Product>("Products").Find(i => i.attribute.rating.value == value).ToList();
        }

        public IEnumerable<Product> GetProductsByRatingAttrRange(double minValue, double maxValue)
        {
            return mongoDB.GetCollection<Product>("Products").Find(i => i.attribute.rating.value >= minValue &&
                                                                        i.attribute.rating.value <= maxValue).ToList();
        }
    }
}
