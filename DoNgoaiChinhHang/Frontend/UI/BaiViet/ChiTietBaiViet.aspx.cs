using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Frontend.UI.BaiViet
{
    public partial class ChiTietBaiViet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            Post_BUS pb = new Post_BUS();

            Guid postID = Guid.Parse(Request.QueryString.Get("postid"));
            DTO.Post post = pb.GetPostByID(postID);
            lblPostName.Text = post.PostName;
            lblPostSummary.Text = HttpUtility.UrlDecode(post.Summary);
            ImgPost.ImageUrl = "../../../Admin/Img/images/" + (string.IsNullOrEmpty(post.Image) ? "noimg.png" : HttpUtility.UrlDecode(post.Image));
            lblPostContent.Text = HttpUtility.UrlDecode(post.Content);

            List<DTO.Post> relatedPost = pb.GetRelatedPosts(post.RelatedPosts);
            if (relatedPost != null && relatedPost.Count != 0)
            {

                var source = relatedPost.Select((item) =>
                {
                    return new
                    {
                        ImageRelatedPost = "../../../Admin/Img/images/" + (string.IsNullOrEmpty(item.Image) ? "noimg.png" : HttpUtility.UrlDecode(item.Image)),
                        LinkDetail = "ChiTietBaiViet.aspx?postid=" + item.PostID,
                        RelatedPostName = item.PostName
                    };
                });
                dataListRelatedPost.DataSource = source;
                dataListRelatedPost.DataBind();
            }
        }
    }
}