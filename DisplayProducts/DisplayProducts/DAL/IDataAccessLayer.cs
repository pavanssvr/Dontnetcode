using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisplayProducts.Models;
using Autofac;

namespace DisplayProducts.DAL
{
    interface IDataAccessLayer
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProductsByPrice(double price);
        IEnumerable<Product> GetProductsByPriceRange(double minPrice, double maxPrice);
        IEnumerable<Product> GetProductsByName(string name);
        IEnumerable<Product> GetProductsByFantasticAttribute(bool value);
        IEnumerable<Product> GetProductsByRatingAttribute(double value);
        IEnumerable<Product> GetProductsByRatingAttrRange(double minValue, double maxValue);
    }
}
