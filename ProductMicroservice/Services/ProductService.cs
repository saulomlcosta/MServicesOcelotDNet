using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Data;
using ProductMicroservice.Model;
using ProductMicroservice.Services.Interface;

namespace ProductMicroservice.Services
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;
        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }


        public IEnumerable<Product> GetProductList()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public Product AddProduct(Product product)
        {
            var result = _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int id)
        {
            var filteredData = _dbContext.Products.Where(x => x.ProductId == id).FirstOrDefault();
            var result = _dbContext.Remove(filteredData);
            _dbContext.SaveChanges();
            return result != null ? true : false;
        }
      
    }
}