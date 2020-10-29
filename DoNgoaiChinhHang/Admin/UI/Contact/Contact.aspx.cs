using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.Contact
{
    public partial class Contact : System.Web.UI.Page
    {
        public DTO.Contact ct = new DTO.Contact();
        Contact_BUS ctb = new Contact_BUS();
        List<DTO.Contact> lst = Contact_BUS.getAllContact();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            if (!IsPostBack)
            {
                HienThi();
            }
        }

        private void HienThi()
        {
            txt_ten.Text = lst[0].ContactName.Trim();
            txt_website.Text = lst[0].Website.Trim();
            txt_diachih.Text = lst[0].Addressh.Trim();
            txt_diachikho.Text = lst[0].WarehouseAddress.Trim();
            txt_email.Text = lst[0].Email.Trim();
            txt_hotline.Text = lst[0].Hotline.Trim();
        }
        protected void btn_sua_Click(object sender, EventArgs e)
        {
            ct.ContactName = txt_ten.Text.Trim();
            ct.Addressh = txt_diachih.Text.Trim();
            ct.Addressh = txt_diachih.Text.Trim();
            ct.WarehouseAddress = txt_diachikho.Text.Trim();
            ct.Website = txt_website.Text.Trim();
            ct.Hotline = txt_hotline.Text.Trim();
            ct.Email = txt_email.Text.Trim();
            Response.Write("<script>alert('Sửa thành công')</script>");
            ctb.UpdateContact(ct.ContactName, ct.Addressh, ct.WarehouseAddress, ct.Hotline, ct.Email, ct.Website);
            List<DTO.Contact> lst = Contact_BUS.getAllContact();
            HienThi();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            txt_diachih.Text = "";
            txt_diachikho.Text = "";
            txt_email.Text = "";
            txt_hotline.Text = "";
            txt_ten.Text = "";
            txt_website.Text = "";

        }
    }
}