using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.Product
{
    public partial class SanPham : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            if (!IsPostBack)
            {
                BindData(Product_BUS.getAllProduct());
                txtSearch.Text = "";
            }
        }

        private void BindData(List<DTO.Product> lst)
        {
            List<DTO.Manufacturer> lstManu = Product_BUS.GetAllManufacturer();
            List<DTO.Origin> lstOrigin = Product_BUS.GetAllOrigin();
            var obj = lst.Select((item, index) =>
            {
                return new
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Price = item.Price.ToString("0,0", CultureInfo.CurrentCulture),
                    Summary = HttpUtility.UrlDecode(item.Summary),
                    ManufacturerName = Product_BUS.GetManufacturerName(item.ManufacturerID, lstManu),
                    OriginName = Product_BUS.GetOriginName(item.OriginID, lstOrigin),
                    Quantity = item.Quantity.ToString("0,0", CultureInfo.CurrentCulture),
                    Image = "../../Img/images/" + (string.IsNullOrEmpty(item.Image) ? "noimg.png" : item.Image),
                    LinkEdit = "ProductDetail.aspx?productID=" + item.ProductID,
                    LinkSale = "ProductSale.aspx?productID=" + item.ProductID,
                    LinkGift = "ProductGift.aspx?productID=" + item.ProductID,
                    LinkDelete = "ProductDelete.aspx?productID=" + item.ProductID,
                    FnDelete = "DeleteProduct('" + item.ProductID.ToString().Trim() + "', '" + item.ProductName.ToString() + "')",
                    Rate = new Product_BUS().GetRateString(item.ProductID),
                    Sale = !item.IsSale ? "Không có khuyến mại" : "Khuyến mại: Giảm " + item.AmountSale.ToString("0,0", CultureInfo.CurrentCulture)
                    + " đ khi mua từ " + item.QuantitySale + " sp trở lên",
                    CategoryInfo = GetCategoriesOfProduct(item.ProductID)
                };
            });
            DataList1.DataSource = obj;
            DataList1.DataBind();
        }

        private string GetCategoriesOfProduct(Guid proID)
        {
            string res = "Không có";
            List<Category> categories = new Product_BUS().GetCategoriesByProductID(proID);
            if(categories.Count != 0)
            {
                res = "";
                foreach(Category item in categories)
                {
                    res += "<br/>&nbsp;&nbsp;&nbsp;-" + item.CategoryName;
                }
            }
            return res;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string content = txtSearch.Text.Trim();
            List<DTO.Product> products = new Product_BUS().SearchProduct(content);
            BindData(products);
        }

        protected void btnLamMoi_Click(object sender, EventArgs e)
        {
            BindData(Product_BUS.getAllProduct());
            txtSearch.Text = "";
        }
    }
}