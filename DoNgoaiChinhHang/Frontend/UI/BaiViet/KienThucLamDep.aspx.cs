using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Frontend.UI.BaiViet
{
    public partial class KienThucLamDep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            List<DTO.Post> posts = new Post_BUS().GetNewPost();
            var source = posts.Select((item) =>
            {
                return new { 
                    Image = "../../../Admin/Img/images/" + (string.IsNullOrEmpty(item.Image) ? "noimg.png" : HttpUtility.UrlDecode(item.Image)),
                    PostName = item.PostName,
                    Summary = HttpUtility.UrlDecode(item.Summary),
                    LinkDetail = "ChiTietBaiViet.aspx?postid=" + item.PostID
                };
            });
            dataListPost.DataSource = source;
            dataListPost.DataBind();
        }
    }
}