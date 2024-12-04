using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class ProductRepository
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Product 1", Price = 100, Description = "Description 1", Stock = 10 },
            new Product { ProductId = 2, Name = "Product 2", Price = 200, Description = "Description 2", Stock = 20 }
        };

        public List<Product> GetAllProducts() => _products;

        public Product GetProductById(int id) => _products.FirstOrDefault(p => p.ProductId == id);

        public void AddProduct(Product product)
        {
            product.ProductId = _products.Max(p => p.ProductId) + 1;
            _products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existing = GetProductById(product.ProductId);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Description = product.Description;
                existing.Stock = product.Stock;
            }
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null) _products.Remove(product);
        }
    }
}