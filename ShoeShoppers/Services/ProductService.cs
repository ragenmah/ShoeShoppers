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
        private  ProductRepository _repository;

        // Dependency Injection through Constructor
        public ProductService(ProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // Fetch all products
        public List<Product> GetAllProducts() => _repository.GetAllProducts();

        // Fetch a product by its ID
        public Product GetProductById(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid Product ID", nameof(id));
            return _repository.GetProductById(id);
        }

        // Add a new product
        public void AddProduct(Product product)
        {
            ValidateProduct(product);
            _repository.AddProduct(product);
        }

        // Update an existing product
        public void UpdateProduct(Product product)
        {
            if (product.ProductId <= 0) throw new ArgumentException("Invalid Product ID", nameof(product.ProductId));
            ValidateProduct(product);
            _repository.UpdateProduct(product);
        }

        // Delete a product by ID
        public void DeleteProduct(int id)
        {
            if (id <= 0) throw new ArgumentException("Invalid Product ID", nameof(id));
            _repository.DeleteProduct(id);
        }

        // Private method to validate product data
        private void ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                throw new ArgumentException("Product name cannot be null or empty", nameof(product.ProductName));

            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than zero", nameof(product.Price));

            if (product.StockQuantity < 0)
                throw new ArgumentException("Stock quantity cannot be negative", nameof(product.StockQuantity));

            if (product.CategoryId <= 0)
                throw new ArgumentException("Invalid category ID", nameof(product.CategoryId));
        }
    }
}