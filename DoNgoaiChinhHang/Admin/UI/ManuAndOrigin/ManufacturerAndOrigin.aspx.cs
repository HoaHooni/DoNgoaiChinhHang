using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoNgoaiChinhHang.Admin.UI.ManuAndOrigin
{
    public partial class ManufacturerAndOrigin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            ManuAndOrigin_BUS mob = new ManuAndOrigin_BUS();
            List<Manufacturer> manus = ManuAndOrigin_BUS.GetAllManufacturer();
            List<Origin> origins = ManuAndOrigin_BUS.GetAllOrigin();
            dataListNSX.DataSource = manus;
            dataListNSX.DataBind();
            dataListXuatXu.DataSource = origins;
            dataListXuatXu.DataBind();
        }

        protected void btnAddNSX_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtNSX.Text.Trim();
                if (name.Equals(string.Empty))
                {
                    txtNSX.Focus();
                    throw new Exception("Yêu cầu nhập tên nhà sản xuất trước khi thêm");
                }
                List<Manufacturer> manus = ManuAndOrigin_BUS.GetAllManufacturer();
                foreach(Manufacturer i in manus)
                {
                    if (i.ManufacturerName.Trim().ToLower().Equals(name.ToLower()))
                    {
                        txtNSX.Focus();
                        throw new Exception("Tên nhà sản xuất bị trùng");
                    }
                }
                new ManuAndOrigin_BUS().InsertManu(name);
                BindData();
                txtNSX.Text = "";
                txtNSX.Focus();
                Response.Write("<script>alert('Thêm thành công')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        protected void btnAddXuatXu_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtXuatXu.Text.Trim();
                if (name.Equals(string.Empty))
                {
                    txtXuatXu.Focus();
                    throw new Exception("Yêu cầu nhập tên xuất xứ trước khi thêm");
                }
                List<Origin> origins = ManuAndOrigin_BUS.GetAllOrigin();
                foreach (Origin i in origins)
                {
                    if (i.OriginName.Trim().ToLower().Equals(name.ToLower()))
                    {
                        txtNSX.Focus();
                        throw new Exception("Tên xuất xứ bị trùng");
                    }
                }
                new ManuAndOrigin_BUS().InsertOrigin(name);
                BindData();
                txtXuatXu.Text = "";
                txtXuatXu.Focus();
                Response.Write("<script>alert('Thêm thành công')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
    }
}