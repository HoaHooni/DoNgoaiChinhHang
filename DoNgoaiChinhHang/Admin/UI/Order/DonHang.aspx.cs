using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Order
{
    public partial class DonHang : System.Web.UI.Page
    {
        int sta;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            List<DTO.Order> lst = Order_BUS.getAllOrder();
            var obj = lst.Select((item, index) =>
            {
                return new
                {
                    OrderCode = item.OrderCode,
                    CustomerName = item.CustomerName,
                    CustomerPhone = item.CustomerPhone,
                    CustomerAddress = item.CustomerAddress,
                    Note = item.Note,
                    IsHidden = (item.IsHidden)? true: false,
                    PayMethod = (item.PayMethod==1)?"Thanh toán tiền mặt":"Thanh toán qua thẻ tín dụng",
                    CreateDate = item.CreatedDate.ToString("HH:mm dd/MM/yyyy"),
                    State = (item.State==1)?"Đã xử lý":"Mới",
                    CompletedDate = item.CompletedDate.ToString("HH:mm dd/MM/yyyy"),
                    LinkDetail = "OrderDetail.aspx?OrderID=" + item.OrderID,
                    textUpdate = (item.State == 1) ? "" : "Xử lý",
                    linkUpdate = (item.State == 1) ? "" : "updateOrder.aspx?OrderID=" + item.OrderID + "&state=" + item.State
                };
            });
            GridView1.DataSource = obj;
            GridView1.DataBind();

           
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            sta = DropDownList1.SelectedIndex ;
            if (sta == 0) Page_Load(sender,e);
            else
            {

                List<DTO.Order> lst = Order_BUS.getOrderbyState(sta);
                var obj = lst.Select((item, index) =>
                {
                    return new
                    {
                        OrderCode = item.OrderCode,
                        CustomerName = item.CustomerName,
                        CustomerPhone = item.CustomerPhone,
                        CustomerAddress = item.CustomerAddress,
                        Note = item.Note,
                        IsHidden = (item.IsHidden) ? true : false,
                        PayMethod = (item.PayMethod == 1) ? "Thanh toán tiền mặt" : "Thanh toán qua thẻ tín dụng",
                        CreateDate = Convert.ToString(item.CreatedDate),
                        State = (item.State == 1) ? "Đã xử lý" : "Mới",
                        CompletedDate = Convert.ToString(item.CompletedDate),
                        LinkDetail = "OrderDetail.aspx?OrderID=" + item.OrderID,
                        textUpdate = (item.State == 1) ? "" : "Xử lý xong",
                        linkUpdate = (item.State == 1) ? "" : "updateOrder.aspx?OrderID=" + item.OrderID + "&state=" + item.State
                    };
                });
                GridView1.DataSource = obj;
                GridView1.DataBind();
            }
        }


        protected void DropDownList1_TextChanged1(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string key = txtSearch.Text;
            if (key.Equals(""))
            {
                labMes.Text = "Tìm kiếm rỗng";
            }
            else
            {
                labMes.Text = "";
            }

            List<DTO.Order> lst = Order_BUS.getOrderByKey(key);
            if(lst!=null)
            
            {
                var obj = lst.Select((item, index) =>
                {
                    return new
                    {
                        OrderCode = item.OrderCode,
                        CustomerName = item.CustomerName,
                        CustomerPhone = item.CustomerPhone,
                        CustomerAddress = item.CustomerAddress,
                        Note = item.Note,
                        IsHidden = (item.IsHidden) ? true : false,
                        PayMethod = (item.PayMethod == 1) ? "Thanh toán tiền mặt" : "Thanh toán qua thẻ tín dụng",
                        CreateDate = Convert.ToString(item.CreatedDate),
                        State = (item.State == 1) ? "Đã xử lý" : "Mới",
                        CompletedDate = Convert.ToString(item.CompletedDate),
                        LinkDetail = "OrderDetail.aspx?OrderID=" + item.OrderID,
                        textUpdate = (item.State == 1) ? "" : "Xử lý xong",
                        linkUpdate = (item.State == 1) ? "" : "updateOrder.aspx?OrderID=" + item.OrderID + "&state=" + item.State
                    };
                });
                GridView1.DataSource = obj;
                GridView1.DataBind();
                labMes.Text = "";
            }else
            {
                labMes.Text = "Không có hoá đơn có thông tin: " + key;
               
            }
            


        }

    
    }
}