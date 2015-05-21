using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace APIWrapper
{
    public class ProductService
    {
        private string BaseUrl { get; set; }
        private HttpClient client { get; set; }


        public ProductService()
        {
            client = new HttpClient();
            BaseUrl = "http://myproductswebapi.azurewebsites.net/api/products";
        }

        public async Task<List<Product>> GetProducts(Expression<Func<Product, object>> parameters)
        {
            string requestedParametersString = Utilities.GetProps(parameters);
            HttpResponseMessage response = await client.GetAsync(this.BaseUrl + "?fields=" + requestedParametersString);
            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadAsAsync<List<Product>>();
                return products;
            }
            return new List<Product>();
        }

        public async Task<Product> GetProduct(int id,Expression<Func<Product, object>> parameters)
        {
            string requestedParametersString = Utilities.GetProps(parameters);
            HttpResponseMessage response = await client.GetAsync(this.BaseUrl + "/" + id + "?fields=" + requestedParametersString);
            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadAsAsync<Product>();
                return product;
            }
            return new Product();
        }

    }
}
