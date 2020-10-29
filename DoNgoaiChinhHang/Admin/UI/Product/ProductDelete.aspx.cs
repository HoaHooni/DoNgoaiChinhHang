using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Product
{
    public partial class ProductDelete : System.Web.UI.Page
    {
        
    protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            Guid id = Guid.Parse(Request.QueryString.Get("productID"));
            new Product_BUS().DeleteProduct(id);
            Response.Redirect("SanPham.aspx");
        }
    }
}