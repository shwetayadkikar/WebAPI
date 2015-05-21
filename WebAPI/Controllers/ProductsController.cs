using APIWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebAPI.JsonContracResolver;

namespace WebAPI.Controllers
{
   
    public class ProductsController : ApiController
    {
        private List<Product> _productsRepository = new Product[] { new Product(){ Id = 1, Category ="Cakes", isAvailable=true, UnitsInStock = 10, Name = "Plum Cake", Price = 250.70, ShelfLife = 3},
            new Product{ Id = 2, Category ="Snacks", isAvailable=true, UnitsInStock = 5, Name = "Egg Rolls", Price = 50, ShelfLife = 1}
            }.ToList();
        // GET api/products
        public JsonResult<List<Product>> Get(string fields= "")
        {
            _productsRepository.ForEach(x => x.SetSerializableProperties(fields));

            return Json(_productsRepository, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver()
            });
        }

        // GET api/products/5
        public JsonResult<Product> Get(int id, string fields="")
        {
            var product = _productsRepository.Find(x => x.Id == id);
            product.SetSerializableProperties(fields);
            return Json(product, new Newtonsoft.Json.JsonSerializerSettings()
            {
                ContractResolver = new ShouldSerializeContractResolver()
            });
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
