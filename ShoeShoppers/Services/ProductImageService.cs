using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class ProductImageService
    {
        private ProductImageRepository _repository = new ProductImageRepository();

        // Add Product Image
        public void AddProductImage(ProductImage productImage)
        {
            _repository.AddProductImage(productImage);
        }

        // Get Product Images by ProductId
        public List<ProductImage> GetProductImages(string productId)
        {
            return _repository.GetImagesByProductId(productId);
        }

        // Update Product Image
        public void UpdateProductImage(ProductImage productImage)
        {
            _repository.UpdateProductImage(productImage);
        }

        // Delete Product Image
        public void DeleteProductImage(int imageId)
        {
            _repository.DeleteProductImage(imageId);
        }
    }
}