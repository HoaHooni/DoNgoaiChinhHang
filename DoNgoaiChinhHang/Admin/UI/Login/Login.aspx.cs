using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtAccName.Text.Trim(),
                    pw = txtPW.Text.Trim();
                if (name.Equals(string.Empty))
                {
                    txtAccName.Focus();
                    throw new Exception("Tên đăng nhập không được để trống");
                }
                if (pw.Equals(string.Empty))
                {
                    txtPW.Focus();
                    throw new Exception("Mật khẩu không được để trống");
                }
                bool isLogin = new Member_BUS().login(name, pw);
                if (isLogin)
                {
                    Session["AccountName"] = name;
                    Response.Redirect("/Admin/UI/ThongKe/ThongKe.aspx");
                } else
                {
                    txtAccName.Focus();
                    throw new Exception("Tên tài khoản hoặc mật khẩu không chính xác");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
    }
}