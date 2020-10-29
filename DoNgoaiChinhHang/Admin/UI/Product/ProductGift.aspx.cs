using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Product
{
    public partial class ProductGift : System.Web.UI.Page
    {
        private Guid proID;
        private DTO.Product product;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            proID = Guid.Parse(Request.QueryString.Get("productID"));
            product = Product_BUS.GetEntityByID<DTO.Product>(proID);
            if (!IsPostBack)
            {
                txtProductInfo.Text = GetProductInfo();
                productImg.ImageUrl = "../../Img/images/" + (string.IsNullOrEmpty(product.Image) ? "noimg.png" : product.Image);
                //btnBack.Attributes.Add("onClick", "javascript:history.back(); return false;");
                LoadGift();
                //Load DropDownList tất cả sp
                List<DTO.Product> allProduct = Product_BUS.getAllProduct();
                ddlAllProduct.DataSource = allProduct;
                ddlAllProduct.DataTextField = "ProductName";
                ddlAllProduct.DataValueField = "ProductID";
                ddlAllProduct.DataBind();
            }

        }

        private string GetProductInfo()
        {
            List<Manufacturer> lstManu = CommonBUS.GetAllManufacturer();
            List<Origin> lstOrigin = CommonBUS.GetAllOrigin();
            string info = "";
            info += "Tên sản phẩm: <b>" + product.ProductName + "</b><br>";
            info += "<br>Nhà SX: <b>" + Product_BUS.GetManufacturerName(product.ManufacturerID, lstManu) + "</b><br>";
            info += "<br>Xuất xứ: <b>" + Product_BUS.GetOriginName(product.OriginID, lstOrigin) + "</b><br>";
            info += "<br>Giá bán: <b>" + product.Price.ToString("0,0", CultureInfo.CurrentCulture) + "đ</b><br>";

            return info;
        }

        private void LoadGift()
        {
            List<DTO.GiftAndQuantity> lst = Product_BUS.GetGiftByProductID(proID);
            var obj = lst.Select((item, index) =>
            {
                return new
                {
                    ProductName = item.Gift.ProductName,
                    Price = item.Gift.Price.ToString("0,0", CultureInfo.CurrentCulture),
                    Quantity = item.Quantity + "",
                    Image = "../../Img/images/" + item.Gift.Image,
                    LinkDetail = "ProductDetail.aspx?productID=" + item.Gift.ProductID,
                    LinkDelete = "",
                    GiftInfo = "Tên sản phẩm: <b>" + item.Gift.ProductName + "</b>"
                        + "<br/>Giá: <b>" + item.Gift.Price.ToString("0,0", CultureInfo.CurrentCulture) + "đ"
                        + "<br/>Số lượng tặng: <b>" + item.Quantity + "</b>"
                        + "<br/>",
                    GiftID = item.GiftID
                };
            });
            lstGift.DataSource = obj;
            lstGift.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Guid giftID = Guid.Parse(sender.GetType().GetProperty("CommandArgument").GetValue(sender).ToString());
            new Product_BUS().DeleteGift(giftID);
            LoadGift();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Guid productGiftID = Guid.Parse(ddlAllProduct.SelectedValue);
                string quantityStr = txtQuantity.Text.Trim();
                int quantity = 0;
                if (quantityStr.Equals(string.Empty))
                {
                    txtQuantity.Focus();
                    throw new Exception("Số lượng sản phẩm của quà tặng không được để trống");
                }

                if (!int.TryParse(quantityStr, out quantity))
                {
                    txtQuantity.Focus();
                    throw new Exception("Số lượng sản phẩm của quà tặng phải ở định dạng số");

                }

                Gift gift = new Gift();
                gift.GiftID = Guid.NewGuid();
                gift.ProductID = proID;
                gift.ProductGiftID = productGiftID;
                gift.Quantity = quantity;

                new Product_BUS().AddGift(gift);
                LoadGift();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}