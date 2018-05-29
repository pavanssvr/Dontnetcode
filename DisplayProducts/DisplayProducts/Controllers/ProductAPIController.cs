using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DisplayProducts.DAL;
using DisplayProducts.Models;
using Microsoft.AspNetCore.Mvc;

namespace DisplayProducts.Controllers
{
    [Route("api/Product")]
    public class ProductAPIController : Controller
    {
        IDataAccessLayer objDal;

        public ProductAPIController(DataAccessLayer dal)
        {
            //objDal = new DataAccessLayer();
            objDal = dal;
        }

        //api/Product/
        [HttpGet]
        public IActionResult Get()
        {
            var product = objDal.GetProducts();
            return Products(product);
        }

        //api/Product/980
        [Route("{price:double}")]
        public IActionResult Get(double price)
        {
            var product = objDal.GetProductsByPrice(price);
            return Products(product);
        }

        //api/Product/min/500/max/600
        [Route("min/{minPrice:double}/max/{maxPrice:double}")]
        public IActionResult Get(double minPrice, double maxPrice)
        {
            var product = objDal.GetProductsByPriceRange(minPrice,maxPrice);
            return Products(product);
        }

        //api/Product/Acetaminophen
        [Route("{name:alpha}")]
        public IActionResult Get(string name)
        {
            var product = objDal.GetProductsByName(name);
            return Products(product);
        }

        //api/Product/Attribute/Fantastic/true
        [Route("Attribute/Fantastic/{value:bool}")]
        public IActionResult Get(bool value)
        {
            var product = objDal.GetProductsByFantasticAttribute(value);
            return Products(product);
        }

        //api/Product/Attribute/Rating/3
        [Route("Attribute/Rating/{value:double}")]
        public IActionResult Getvalues(double value)
        {
            var product = objDal.GetProductsByRatingAttribute(value);
            return Products(product);
        }

        //api/Product/Attribute/Rating/min/3/max/3.5
        [Route("Attribute/Rating/min/{minValue:double}/max/{maxValue:double}")]
        public IActionResult Getvalues(double minValue, double maxValue)
        {
            var product = objDal.GetProductsByRatingAttrRange(minValue, maxValue);
            return Products(product);
        }

        public IActionResult Products(IEnumerable<Product> product)
        {
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }
    }
}
