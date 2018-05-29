using System;
using Xunit;
using DisplayProducts.DAL;
using DisplayProducts.Models;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTestProducts
{
    public class UnitTestProducts
    {
        [Fact]
        public void TestAllProducts()
        {
            DataAccessLayer objDal = new DataAccessLayer();
            IEnumerable<Product> products = objDal.GetProducts();
            int productsCount = products.Count();
            Assert.Equal(1000, productsCount);
        }

        [Fact]
        public void TestProductsByPrice()
        {
            DataAccessLayer objDal = new DataAccessLayer();
            IEnumerable<Product> products = objDal.GetProductsByPrice(980);
            Product productsCount = products.FirstOrDefault(i => i.Name == "Metoclopramide");
            Assert.Equal(982.84, productsCount.price);
        }

        [Fact]
        public void TestProductsByPriceRange()
        {
            DataAccessLayer objDal = new DataAccessLayer();
            IEnumerable<Product> products = objDal.GetProductsByPriceRange(500,600);
            Product productsCount = products.FirstOrDefault(i => i.Name == "Simvastatin");
            Assert.Equal(507.08, productsCount.price);
        }
        
        [Fact]
        public void TestProductsByName()
        {
            DataAccessLayer objDal = new DataAccessLayer();
            IEnumerable<Product> products = objDal.GetProductsByName("Potassium Chloride");
            Product productsCount = products.FirstOrDefault();
            Assert.Equal(74, productsCount.Productid);
        }

        [Fact]
        public void TestProductsByFantasticAttribute()
        {
            DataAccessLayer objDal = new DataAccessLayer();
            IEnumerable<Product> products = objDal.GetProductsByFantasticAttribute(true);
            Product productsCount = products.FirstOrDefault(i => i.Productid == 2);
            Assert.Equal("370-04-2494", productsCount.sku);
        }

        [Fact]
        public void TestProductsByRatingAttribute()
        {
            DataAccessLayer objDal = new DataAccessLayer();
            IEnumerable<Product> products = objDal.GetProductsByRatingAttribute(3);
            Product productsCount = products.FirstOrDefault(i => i.Productid == 367);
            Assert.Equal(746.63, productsCount.price);
        }

        [Fact]
        public void TestProductsByRatingAttrRange()
        {
            DataAccessLayer objDal = new DataAccessLayer();
            IEnumerable<Product> products = objDal.GetProductsByRatingAttrRange(3, 3.5);
            Product productsCount = products.FirstOrDefault(i => i.Productid == 385);
            Assert.Equal("992-24-7727", productsCount.sku);
        }

    }
}
