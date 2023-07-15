
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Model;
using ProductMicroservice.Services.Interface;
namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService _productService)
        {
            productService = _productService;
        }
        [HttpGet]
        public IEnumerable<Product> ProductList()
        {
            var productList = productService.GetProductList();
            return productList;
        }
        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return productService.GetProductById(id);
        }
        [HttpPost]
        public Product AddProduct(Product product)
        {
            return productService.AddProduct(product);
        }
        [HttpPut]
        public Product UpdateProduct(Product product)
        {
            return productService.UpdateProduct(product);
        }
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            return productService.DeleteProduct(id);
        }
    }
}