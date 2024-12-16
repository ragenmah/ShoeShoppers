using ShoeShoppers.Database.Helpers;
using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages.Admin.Products
{
    public partial class ProductReviews : System.Web.UI.Page
    {
        private readonly ProductReviewService _productReviewService ;

        int productId;

        private readonly int userId;

        public ProductReviews()
        {
           
            _productReviewService = new ProductReviewService(new ProductReviewRepository());
            userId = UserHelper.GetUserIdFromCookie();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductReviews();
            }
        }

        private void LoadProductReviews()
        {
            productId = int.Parse((string)RouteData.Values["ProductId"]);

            var productReviews = _productReviewService.GetAllReviewsByProduct(productId);
            if (!(productReviews.Count > 0))
            {
                lblNoReview.Visible = true;
            }
            rptReviews.DataSource = productReviews;
            rptReviews.DataBind();
        }
        protected void rptReviews_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ReplyReview")
            {
                int reviewId = Convert.ToInt32(e.CommandArgument);

                TextBox txtReply = (TextBox)e.Item.FindControl("txtReply");

                if (txtReply != null)
                {
                    string replyContent = txtReply.Text;

                    if (!string.IsNullOrEmpty(replyContent))
                    {
                        SaveReplyToDatabase(reviewId, replyContent);

                        LoadProductReviews();
                    }
                }
            }
        }

        private void SaveReplyToDatabase(int reviewId, string replyContent)

        {
            ProductReview productReview = new ProductReview
            {
                ReviewId = reviewId,
                ResponseContent = replyContent,
                RepliedBy = userId.ToString(),
                IsReplied = true
            };

            _productReviewService.UpdateReview(productReview);
        }
    }
}