using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class ProductService
    {
        private ProductRepository _repository = new ProductRepository();

        public List<Product> GetAllProducts() => _repository.GetAllProducts();

        public Product GetProductById(int id) => _repository.GetProductById(id);

        public void AddProduct(Product product) => _repository.AddProduct(product);

        public void UpdateProduct(Product product) => _repository.UpdateProduct(product);

        public void DeleteProduct(int id) => _repository.DeleteProduct(id);
    }
}