using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Order
{
    public partial class updateOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.QueryString["OrderID"].ToString();
            int state =int.Parse(Request.QueryString["state"].ToString());
            if(state==2) Order_BUS.updateOrder(id);
            Response.Redirect("DonHang.aspx");
        }
    }
}