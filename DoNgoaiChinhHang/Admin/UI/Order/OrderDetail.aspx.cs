using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Order
{
    public partial class OrderDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String id = Request.QueryString["OrderID"].ToString();
            Order_BUS order_BUS = new Order_BUS();
            DTO.Order order = Order_BUS.GetEntityByID<DTO.Order>(Guid.Parse(id));
            List<DTO.Order> lst = new List<DTO.Order>();
            lst.Add(order);
            var obj = lst.Select((item, index) =>
            {
                return new
                {
                    OrderID = item.OrderCode,
                    CustomerName = item.CustomerName,
                    CustomerPhone = item.CustomerPhone,
                    CustomerAddress = item.CustomerAddress,
                    Note = item.Note,
                    IsHidden = (item.IsHidden) ? "checked" : "",
                    PayMethod = (item.PayMethod == 1) ? "Thanh toán tiền mặt" : "Thanh toán qua thẻ tín dụng",
                    CreatedDate = item.CreatedDate.ToString("HH:mm dd/MM/yyyy"),
                    State = (item.State == 1) ? "Đã xử lý" : "Mới",
                    CompletedDate = item.CompletedDate.ToString("HH:mm dd/MM/yyyy"),
                    LinkState = (item.State == 1) ? "" : "<a href = \"updateOrder.aspx?OrderID=" + item.OrderID + "&state=" + item.State + "\"> Chuyển thành đã xử lý </a> "
                };
            });
            DataList1.DataSource = obj;
            DataList1.DataBind();

            GridView2.DataSource = Order_BUS.getOrderDetailById(id);
            GridView2.DataBind();
            Int32 sum = Order_BUS.getSumOrderDetailById(id) ;


            String s = String.Format("{0:0,0 vnđ}", sum);

            lblSum.Text = "Tổng tiền : " + s;
        }
    }
}