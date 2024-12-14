using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Services
{
    public class ProductReviewService
    {
        private ProductReviewRepository _repository = new ProductReviewRepository();

        public ProductReviewService(ProductReviewRepository productReviewRepository)
        {
            _repository = productReviewRepository;
        }

        public int AddReview(ProductReview review)
        {
          return  _repository.AddReview(review);
        }

        
        public List<ProductReview> GetAllReviews()
        {
            return _repository.GetAllReviews();
        }

        public List<ProductReview> GetAllReviewsByProduct(int productId)
        {
            return _repository.GetAllReviewsByProduct( productId);
        }


        public void UpdateReview(ProductReview review)
        {
            _repository.UpdateReview( review);
        }

        public void DeleteReview(int reviewId)
        {
            _repository.DeleteReview( reviewId);
        }
    }
}