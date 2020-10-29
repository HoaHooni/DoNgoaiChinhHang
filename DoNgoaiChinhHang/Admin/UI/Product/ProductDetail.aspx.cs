using BUS;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Product
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        private int mode;
        private Guid proID;
        private string modeSave;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            if (!IsPostBack)
            {
                Product_BUS product_BUS = new Product_BUS();
                proID = Guid.Parse(Request.QueryString.Get("productID"));

                List<DTO.Manufacturer> manus = CommonBUS.GetAllManufacturer();
                List<DTO.Origin> origins = CommonBUS.GetAllOrigin();
                List<DTO.Category> categories = product_BUS.GetAllCategory();
                DTO.Product sp = Product_BUS.GetEntityByID<DTO.Product>(proID);

                txtProductName.Text = sp.ProductName.Trim();
                txtProductCode.Text = sp.ProductCode.Trim();
                txtQuantity.Text = sp.Quantity.ToString();
                txtPrice.Text = sp.Price.ToString();
                txtImgURL.Text = string.IsNullOrEmpty(HttpUtility.UrlDecode(sp.Image)) ? "" : "/Admin/Img/images/" + HttpUtility.UrlDecode(sp.Image);
                imgProduct.ImageUrl = "../../Img/images/" + (string.IsNullOrEmpty(HttpUtility.UrlDecode(sp.Image)) ? "noimg.png" : HttpUtility.UrlDecode(sp.Image));
                txtNhaSX.DataSource = manus;
                txtNhaSX.SelectedValue = sp.ManufacturerID.ToString();
                txtNhaSX.DataBind();
                txtXuatXu.DataSource = origins;
                txtXuatXu.SelectedValue = sp.OriginID.ToString();
                txtXuatXu.DataBind();
                txtSummary.Text = string.IsNullOrEmpty(sp.Summary) ? "" : HttpUtility.UrlDecode(sp.Summary.Trim());
                txtDetail.Text = string.IsNullOrEmpty(sp.Content) ? "" : HttpUtility.UrlDecode(sp.Content.Trim());
                ckCategory.DataSource = categories;
                //
                ckCategory.DataBind();
                radFreeShip.Checked = sp.Ship == 0;
                radQuantityShip.Checked = sp.Ship != 0;
                txtNumShip.Text = sp.Ship == 0 ? "" : sp.Ship.ToString();
                chkSale.Checked = sp.IsSale;
                txtAmountSale.Text = sp.IsSale ? sp.AmountSale.ToString() : "";
                txtQuantitySale.Text = sp.IsSale ? sp.QuantitySale.ToString() : "";
            }
        }

        protected void ckCategory_DataBinding(object sender, EventArgs e)
        {
            List<Category> cagories = new Product_BUS().GetCategoriesByProductID(Guid.Parse(Request.QueryString.Get("productID")));
            foreach (ListItem item in ckCategory.Items)
            {
                foreach(Category category in cagories)
                {
                    if (category.CategoryID.Equals(Guid.Parse(item.Value)))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                proID = Guid.Parse(Request.QueryString.Get("productID"));
                string productName = txtProductName.Text.Trim(),
                    productCode = txtProductCode.Text.Trim(),
                    price = txtPrice.Text.Trim(),
                    quantity = txtQuantity.Text.Trim(),
                    imgURL = Request.Form.Get("ctl00$ContentPlaceHolder$txtImgURL").Trim(),
                    content = txtDetail.Text.Trim(),
                    summary = txtSummary.Text.Trim(),
                    numShip = txtNumShip.Text.Trim(),
                    amountSale = txtAmountSale.Text.Trim(),
                    quatitySale = txtQuantity.Text.Trim();

                bool freeShp = radFreeShip.Checked,
                    isSale = chkSale.Checked;

                Guid manuID = Guid.Parse(txtNhaSX.SelectedValue),
                    oriID = Guid.Parse(txtXuatXu.SelectedValue);



                int outTmp;

                if (productName.Equals(string.Empty))
                {
                    txtProductName.Focus();
                    throw new Exception("Tên sản phẩm không được để trống");
                }

                if (productCode.Equals(string.Empty))
                {
                    txtProductCode.Focus();
                    throw new Exception("Mã sản phẩm không được để trống");
                }
                if (imgURL.Equals(string.Empty))
                {
                    throw new Exception("Ảnh sản phẩm không được để trống");
                }
                if (price.Equals(string.Empty) || !int.TryParse(price, out outTmp))
                {
                    txtPrice.Focus();
                    throw new Exception("Giá sản phẩm không được để trống và định dạnh số nguyên");
                }
                if (quantity.Equals(string.Empty) || !int.TryParse(quantity, out outTmp))
                {
                    txtQuantity.Focus();
                    throw new Exception("Số lượng sản phẩm không được để trống và định dạnh số nguyên");
                }
                if(!freeShp && numShip.Equals(string.Empty) && !int.TryParse(numShip, out outTmp))
                {
                    txtNumShip.Focus();
                    throw new Exception("Số lượng tối thiểu sản phẩm mua để được miễn phí ship không được để trống và đúng định dạng số nguyên");
                }

                if (isSale)
                {
                    if(amountSale.Equals(string.Empty) || !int.TryParse(amountSale, out outTmp))
                    {
                        txtAmountSale.Focus();
                        throw new Exception("Số lượng tiền giảm khuyến mại không được để trống");
                    }

                    if(quatitySale.Equals(string.Empty) || !int.TryParse(quatitySale, out outTmp))
                    {
                        txtQuantitySale.Focus();
                        throw new Exception("Số lượng sản phẩm mua để đạt được khuyến mại không được để trống và đúng định dạng số nguyên");
                    }
                }
                DTO.Product product = new DTO.Product();
                product.ProductID = proID;
                product.ProductName = productName;
                product.Price = int.Parse(price);
                product.Quantity = int.Parse(quantity);
                product.ManufacturerID = manuID;
                product.OriginID = oriID;
                product.ProductCode = productCode;
                product.Image = imgURL.Substring(imgURL.LastIndexOf("/") +1 , imgURL.Length - imgURL.LastIndexOf("/") - 1);
                product.Content = HttpUtility.UrlEncode(content);
                product.Summary = HttpUtility.UrlEncode(summary);
                product.Ship = freeShp ? 0 : int.Parse(numShip);
                product.IsSale = isSale;
                if (isSale)
                {
                    product.AmountSale = int.Parse(amountSale);
                    product.QuantitySale = int.Parse(quatitySale);
                }

                List<Guid> categories = new List<Guid>();
                foreach(ListItem item in ckCategory.Items)
                {
                    if (item.Selected)
                    {
                        categories.Add(Guid.Parse(item.Value));
                    }
                }
                new Product_BUS().UpdateProduct(product, categories);
                Response.Write("<script>alert('Cập nhật thành công')</script>");

            } catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"')</script>");
            }
        }
    }
}