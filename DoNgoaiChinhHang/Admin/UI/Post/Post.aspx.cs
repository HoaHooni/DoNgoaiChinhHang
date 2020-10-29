using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Post
{
    public partial class Post : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            if (!IsPostBack)
            {
                BindData(new Post_BUS().GetAllPost());
            }
        }

        private void BindData(List<DTO.Post> posts)
        {
            var objs = posts.Select((item) =>
            {
                return new
                {
                    ImageURL = "../../Img/images/" + (string.IsNullOrEmpty(item.Image) ? "noimg.png" : item.Image),
                    PostInfo = GetPostInfo(item),
                    PostID = item.PostID
                };
            });

            DataList1.DataSource = objs;
            DataList1.DataBind();
        }

        private string GetPostInfo(DTO.Post post)
        {
            string msg = "";
            msg += string.Format("<b><a class='PostName' href=\"PostDetail.aspx?postid={1}\">{0}</a></b><br/>", post.PostName.ToUpper(), post.PostID);
            msg += string.Format("<b>Ngày tạo: </b><i>{0}</i><br/>", post.CreatedDate.ToString("HH:mm:ss dd/MM/yyyy"));
            msg += "<i>" + new Post_BUS().GetRateString(post.PostID) + "</i><br/>";
            msg += string.Format("<b>Tóm tắt:</b><br/>{0}", HttpUtility.UrlDecode(post.Summary));
            return msg;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            // Xóa
            Guid postID = Guid.Parse(sender.GetType().GetProperty("CommandArgument").GetValue(sender).ToString());
            new Post_BUS().DeletePost(postID);
            BindData(new Post_BUS().GetAllPost());
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData(new Post_BUS().GetAllPost());
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string str = txtSearch.Text.Trim();
                if (str.Equals(string.Empty))
                {
                    txtSearch.Focus();
                    throw new Exception("Yêu cầu nhập nội dung tìm kiếm");
                }
                BindData(new Post_BUS().SearchPost(str));

            } catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
    }
}