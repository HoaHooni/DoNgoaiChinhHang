using BUS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.ThongKe
{
    public partial class ThongKe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            ThongKe_BUS tkb = new ThongKe_BUS();

            // Đơn hàng mới
            List<DTO.Order> orders = tkb.GetOrderNew();
            var source = orders.Select((item) =>
            {
                return new
                {
                    OrderInfo = string.Format("<div class='card'><div>KH: {0}</div><div>SĐT: {3}</div><div>Ngày tạo: {1} </div><div><a href='{2}'>Xem chi tiết</a></div></div>",
                    item.CustomerName, item.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"), "../Order/OrderDetail.aspx?OrderID="+item.OrderID, item.CustomerPhone)
                };
            });
            dataListOrderNew.DataSource = source;
            dataListOrderNew.DataBind();

            //SP còn nhiều
            List<DTO.Product> products = tkb.GetProduct_MaxQuantity();
            var source2 = products.Select((item) =>
            {
                return new
                {
                    Image = "../../Img/images/" + (string.IsNullOrEmpty(item.Image) ? "noimg.png" : item.Image),
                    ProductInfo = string.Format("<div><div><b>{0}</b></div><div>Giá: {1}đ</div><div>SL: {2}</div><div><a href=\"{3}\">Xem chi tiết</a></div></div>", 
                    item.ProductName.Trim(), item.Price.ToString("0,0", CultureInfo.CurrentCulture), item.Quantity.ToString("0,0", CultureInfo.CurrentCulture),
                    "../Product/ProductDetail.aspx?productid="+item.ProductID)
                };
            });
            dataListProductQuantityMax.DataSource = source2;
            dataListProductQuantityMax.DataBind();

            //SP còn ít
            products = tkb.GetProduct_MinQuantity();
            var source3 = products.Select((item) =>
            {
                return new
                {
                    Image = "../../Img/images/" + (string.IsNullOrEmpty(item.Image) ? "noimg.png" : item.Image),
                    ProductInfo = string.Format("<div><div><b>{0}</b></div><div>Giá: {1}đ</div><div>SL: {2}</div><div><a href=\"{3}\">Xem chi tiết</a></div></div>",
                    item.ProductName.Trim(), item.Price.ToString("0,0", CultureInfo.CurrentCulture), item.Quantity.ToString("0,0", CultureInfo.CurrentCulture),
                    "../Product/ProductDetail.aspx?productid=" + item.ProductID)
                };
            });
            dataListProductQuantityMin.DataSource = source3;
            dataListProductQuantityMin.DataBind();

            //ĐƠn hàng giá trị cao nhất
            dataListOrderValue.DataSource = tkb.GetOrderValue();
            dataListOrderValue.DataBind();

            //SP đánh giá
            dataListProductRate.DataSource = tkb.GetProductRate();
            dataListProductRate.DataBind();

            //Bài viết đánh giá
            dataListPostRate.DataSource = tkb.GetPostRate();
            dataListPostRate.DataBind();
        }
    }
}