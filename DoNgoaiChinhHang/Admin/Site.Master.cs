using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            else
            {
                string accName = Session["AccountName"].ToString().ToUpper();
                txtAccName.Text = accName.ToString().ToUpper();
                Response.Write("<script>var ContextData = {IsAdmin: "+(accName.ToLower().Equals("admin") ? "true" : "false")+"};</script>");

            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["AccountName"] = null;
            Response.Redirect("../Login/Login.aspx");
        }
    }
}