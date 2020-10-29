using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Post
{
    public partial class PostDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            if (!IsPostBack)
            {
                Response.Write("<script>sessionStorage['ReloadImg'] = 'false';</script>");
                BindData();
            }
        }

        private void BindData()
        {
            Guid postID = Guid.Parse(Request.QueryString.Get("postid"));
            DTO.Post post = Post_BUS.GetEntityByID<DTO.Post>(postID);
            txtTenBaiViet.Text = post.PostName.Trim();
            txtNgayTao.Text = post.CreatedDate.ToString("HH:mm:ss dd/MM/yyyy");
            imgProduct.ImageUrl = "../../Img/images/" + (string.IsNullOrEmpty(HttpUtility.UrlDecode(post.Image)) ? "noimg.png" : HttpUtility.UrlDecode(post.Image));
            txtImgURL.Text = (string.IsNullOrEmpty(HttpUtility.UrlDecode(post.Image)) ? "" : "/Admin/Img/images/" + HttpUtility.UrlDecode(post.Image));
            txtSummary.Text = string.IsNullOrEmpty(post.Summary) ? "" : HttpUtility.UrlDecode(post.Summary.Trim());
            txtDetail.Text = string.IsNullOrEmpty(post.Content) ? "" : HttpUtility.UrlDecode(post.Content.Trim());
            BindRelatedPosts(GetRelatedPosts(post.RelatedPosts));
            lblEmpty.Text = GetRelatedPosts(post.RelatedPosts).Count == 0 ? "Không có bài viết liên quan" : "";
            BindDropDownList(new Post_BUS().GetAllPost(post.PostID, post.RelatedPosts));
            SetSessionForRelatedPost(post.RelatedPosts);
            Response.Write(string.Format("<script>sessionStorage['ImageURL'] = '{0}' </script>", string.IsNullOrEmpty(HttpUtility.UrlDecode(post.Image)) ? "noimg.png" : HttpUtility.UrlDecode(post.Image)));
        }

        private void SetSessionForRelatedPost(string str)
        {
            List<string> lst = new List<string>();
            if (!string.IsNullOrEmpty(str))
            {
                if (str.IndexOf(';').Equals(0))
                {
                    str = str.Substring(1, str.Length - 1);
                }
                lst = str.Split(';').ToList<string>();
            }
            Session["RelatedPosts"] = lst;
        }

        private void BindRelatedPosts(List<DTO.Post> posts)
        {
            DataList1.DataSource = posts;
            DataList1.DataBind();
        }

        private void BindDropDownList(List<DTO.Post> post)
        {
            DropDownList1.DataSource = post;
            DropDownList1.DataTextField = "PostName";
            DropDownList1.DataValueField = "PostID";
            DropDownList1.DataBind();
        }

        private List<DTO.Post> GetRelatedPosts(string lstRelatedPostIDs)
        {
            List<DTO.Post> posts = new Post_BUS().GetRelatedPosts(lstRelatedPostIDs);
            if (posts == null)
            {
                return new List<DTO.Post>();
            }
            return posts;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

            Response.Redirect("Post.aspx");
        }

        protected void btnAddRelatedPost_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {

                Guid postID = Guid.Parse(Request.QueryString.Get("postid"));
                Guid relatedPostID = Guid.Parse(DropDownList1.SelectedValue);
                DTO.Post post = Post_BUS.GetEntityByID<DTO.Post>(postID);
                List<string> lstPost = (List<string>)Session["RelatedPosts"];
                bool isAdd = true;
                if (post.RelatedPosts != null)
                {
                    if (lstPost.Contains(relatedPostID.ToString().ToLower()) || post.PostID.Equals(relatedPostID))
                    {
                        isAdd = false;
                    }
                }
                if (!isAdd)
                {
                    Response.Write("<script>" +
                        "sessionStorage['ReloadImg'] = true;" +
                        "alert('Bài  viết liên quan muốn thêm đã có trong danh sách bài viết liên quan hoặc trùng với bài viết hiện tại'); </script>");
                }
                else
                {

                    lstPost.Add(relatedPostID.ToString());
                    string str = string.Join(";", lstPost.ToArray());
                    SetSessionForRelatedPost(str);
                    BindRelatedPosts(GetRelatedPosts(str));
                    BindDropDownList(new Post_BUS().GetAllPost(post.PostID, str));
                    Response.Write("<script>sessionStorage['ReloadImg'] = 'true';</script>");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Post_BUS bus = new Post_BUS();
                DTO.Post newPost = new DTO.Post();
                newPost.PostID = Guid.Parse(Request.QueryString.Get("postid"));
                string postName = txtTenBaiViet.Text.Trim(),
                    imgURL = Request.Form.Get("ctl00$ContentPlaceHolder$txtImgURL"),
                    summary = txtSummary.Text.Trim(),
                    content = txtDetail.Text.Trim();
                if (string.IsNullOrEmpty(postName))
                {
                    txtTenBaiViet.Focus();
                    throw new Exception("Tên bài viết không được để trống");
                }
                if (bus.IsDuplicatePostName(newPost.PostID, postName))
                {
                    txtTenBaiViet.Focus();
                    throw new Exception("Tên bài viết bị trùng");
                }
                if (string.IsNullOrEmpty(imgURL))
                {
                    throw new Exception("Bài viết chưa có ảnh");
                }
                newPost.PostName = postName;
                newPost.Image = imgURL.Substring(imgURL.LastIndexOf('/') + 1, imgURL.Length - imgURL.LastIndexOf('/') - 1);
                newPost.Content = content;
                newPost.Summary = summary;
                newPost.RelatedPosts = string.Join(";", ((List<string>)Session["RelatedPosts"]));
                bus.UpdatePost(newPost);
                Response.Write("<script>alert('Cập nhật thành công')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(\"" + ex.Message + "\")</script>");
            }
        }

        protected void btnDeleteRelatedPost_Click(object sender, EventArgs e)
        {
            // xóa bài viết liên quan
            List<string> lstPost = (List<string>)Session["RelatedPosts"];
            Guid relatedPostID = Guid.Parse(sender.GetType().GetProperty("CommandArgument").GetValue(sender).ToString());
            Guid postID = Guid.Parse(Request.QueryString.Get("postid"));
            DTO.Post post = Post_BUS.GetEntityByID<DTO.Post>(postID);
            lstPost.Remove(relatedPostID.ToString());
            string str = string.Join(";", lstPost.ToArray());
            SetSessionForRelatedPost(str);
            BindRelatedPosts(GetRelatedPosts(str));
            BindDropDownList(new Post_BUS().GetAllPost(post.PostID, str));
        }
    }
}