using ShoeShoppers.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Repository
{
    public class ProductReviewRepository
    {


        private readonly SqlConnection _connection;

        public ProductReviewRepository()
        {
            _connection = DatabaseConnection.Instance.GetConnection();
        }

        public List<ProductReview> GetAllReviews()
        {
            var reviews = new List<ProductReview>();
            string query = "SELECT pr.*, r.ReplyId, r.ResponseContent, r.RepliedAt, r.RepliedBy FROM ProductReviews pr LEFT JOIN Replies r ON pr.ReplyId = r.ReplyId;";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reviews.Add(new ProductReview
                        {
                            ReviewId = (int)reader["ReviewId"],
                            Rating = (int)reader["Rating"],
                            Comment = reader["Comment"]?.ToString(),
                            ProductId = (int)reader["ProductId"],
                            UserId = (int)reader["UserId"],
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsReplied = (bool)reader["IsReplied"],
                           Reply=new Reply
                           {
                               RepliedAt = reader["RepliedAt"] as DateTime?,
                               RepliedBy = reader["RepliedBy"]?.ToString(),
                               ResponseContent = reader["ResponseContent"]?.ToString()
                           }
                        });
                    }
                }
            }

            return reviews;
        }
        public List<ProductReview> GetAllReviewsByProduct(int productId)
        {
            var reviews = new List<ProductReview>();
            string query = "SELECT pr.ReviewId, pr.Rating, pr.Comment, pr.ProductId, pr.CreatedAt, pr.IsReplied, pr.RepliedAt, pr.RepliedBy, pr.ResponseContent, u.FirstName, u.LastName, u.Email,r.ReplyId, r.ResponseContent, r.RepliedAt, r.RepliedBy" +
                " FROM ProductReviews pr INNER JOIN Users u ON pr.UserId = u.UserId WHERE pr.ProductId = @ProductId LEFT JOIN Replies r ON pr.ReplyId = r.ReplyId;";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ProductId", productId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reviews.Add(new ProductReview
                        {
                            ReviewId = (int)reader["ReviewId"],
                            Rating = (int)reader["Rating"],
                            Comment = reader["Comment"]?.ToString(),
                            ProductId = (int)reader["ProductId"],
                            CreatedAt = (DateTime)reader["CreatedAt"],
                            IsReplied = (bool)reader["IsReplied"],
                            Reply = new Reply
                            {
                                RepliedAt = reader["RepliedAt"] as DateTime?,
                                RepliedBy = reader["RepliedBy"]?.ToString(),
                                ResponseContent = reader["ResponseContent"]?.ToString()
                            },
                            User = new User
                            {
                                FirstName = reader["FirstName"]?.ToString(),
                                LastName = reader["LastName"]?.ToString(),
                                Email = reader["Email"]?.ToString()
                            }
                        });
                    }
                }
            }

            return reviews;
        }


        public int AddReply(string replyContent, string repliedBy) {
            string insertReplyQuery = @"
                    INSERT INTO Replies (ResponseContent, RepliedBy)
                    VALUES (@ResponseContent, @RepliedBy);
                    SELECT SCOPE_IDENTITY();";
            using (SqlCommand cmd = new SqlCommand(insertReplyQuery, _connection))
            {
                cmd.Parameters.AddWithValue("@ResponseContent", replyContent);
                cmd.Parameters.AddWithValue("@RepliedBy", repliedBy);
                cmd.ExecuteNonQuery();
                int replyId = Convert.ToInt32(cmd.ExecuteScalar());

                return replyId;
            }

        }

        public int AddReview(ProductReview review)
        {
            string query = "INSERT INTO ProductReviews (Rating, Comment, ProductId, UserId,ReplyId ) VALUES (@Rating, @Comment, @ProductId, @UserId, @ReplyId);";

            int replyId = AddReply(review.Reply.ResponseContent, review.Reply.RepliedBy);

            if (replyId > 0)
            {
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.Parameters.AddWithValue("@Rating", review.Rating);
                    cmd.Parameters.AddWithValue("@Comment", review.Comment);
                    cmd.Parameters.AddWithValue("@ProductId", review.ProductId);
                    cmd.Parameters.AddWithValue("@UserId", review.UserId);
                    cmd.Parameters.AddWithValue("@ReplyId", replyId);
                    cmd.ExecuteNonQuery();

                }
                return 1;
            }
            return 0;

        }

        public void UpdateReview(ProductReview review)
        {
            string query = "UPDATE ProductReviews SET  IsReplied = @IsReplied, RepliedAt = @RepliedAt, RepliedBy = @RepliedBy, ResponseContent = @ResponseContent WHERE ReviewId = @ReviewId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
         
                cmd.Parameters.AddWithValue("@IsReplied", review.IsReplied);
                cmd.Parameters.AddWithValue("@RepliedAt", DateTime.Now);
                cmd.Parameters.AddWithValue("@RepliedBy", review.RepliedBy);
                cmd.Parameters.AddWithValue("@ResponseContent", review.ResponseContent);
                cmd.Parameters.AddWithValue("@ReviewId", review.ReviewId);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteReview(int reviewId)
        {
            string query = "DELETE FROM ProductReviews WHERE ReviewId = @ReviewId";

            using (SqlCommand cmd = new SqlCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@ReviewId", reviewId);
                cmd.ExecuteNonQuery();
            }
        }


    }
}