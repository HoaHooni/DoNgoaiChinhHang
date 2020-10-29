using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BUS;

namespace Master_nguoidung
{
    public partial class My_pham_dac_tri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DTO.Product> lst = Product_BUS.getAllProduct();
            var source = lst.Select((item) =>
            {
                return new
                {
                    Image = "../../../Admin/Img/images/" + (string.IsNullOrEmpty(item.Image) ? "noimg.png" : HttpUtility.UrlDecode(item.Image)),
                    Summary = HttpUtility.UrlDecode(item.Summary),
                    Price = item.Price.ToString() + "đ",
                    ProductID = item.ProductID,
                    ProductName = item.ProductName
                };
            });

            DataList1.DataSource = source;
            DataList1.DataBind();
        }
    }
}