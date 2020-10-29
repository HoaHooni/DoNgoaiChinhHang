using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BUS;
using DTO;
namespace DoNgoaiChinhHang
{
    public partial class qlthanhvien : System.Web.UI.Page
    {
        Member m = new Member();
        Member_BUS mb = new Member_BUS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccountName"] == null)
            {
                Response.Redirect("../Login/Login.aspx");
            }
            if (!IsPostBack)
            {
                lstthanhvien.Items.Add("Admin");
                lstthanhvien.Items.Add("User");
                if (!IsAdmin())
                {
                    btn_sua.Enabled = false;
                    btn_them.Enabled = false;
                }
            }
            hienthi();
        }
        private void hienthi()
        {
            dtgmember.DataSource = mb.ShowMember(IsAdmin());
            dtgmember.DataBind();
        }

        private bool IsAdmin()
        {
            string accName = Session["AccountName"].ToString();
            if (accName.Trim().ToLower().Equals("admin"))
            {
                return true;
            }
            return false;
        }

        protected void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                m.MemberName = txt_ten.Text.Trim();
                m.Password = txt_password.Text.Trim();
                m.Phone = txt_phone.Text.Trim();
                m.Email = txt_email.Text.Trim();
                if (m.MemberName.Equals(string.Empty))
                {
                    txt_ten.Focus();
                    throw new Exception("Tên thành viên không được để trống");
                }
                if (m.Password.Equals(string.Empty))
                {
                    txt_password.Focus();
                    throw new Exception("Mật khẩu không được để trống");
                }
                if (lstthanhvien.Text == "Admin")
                {
                    m.MemberType = 1;
                }
                else if (lstthanhvien.Text == "User")
                {
                    m.MemberType = 0;
                }
                if (mb.IsDuplicateUserName(m.MemberName))
                {
                    txt_ten.Focus();
                    throw new Exception("Tên thành viên bị trùng");
                }
                else
                {
                    mb.InsertMember(m.MemberName, m.Phone, m.Email, m.Password, m.MemberType);
                    hienthi();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }

        protected void dtgmember_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid matv = Guid.Parse(dtgmember.DataKeys[e.RowIndex].Value.ToString());
            if (matv.Equals(Guid.Parse("12B6664D-EC88-4179-927E-78F54A55386B"))){
                Response.Write("<script>alert('Không thể xóa tài khoản admin')</script>");
            }
            else
            {
                mb.deleteMember(matv.ToString());
                hienthi();
            }
        }


        protected void btn_sua_Click(object sender, EventArgs e)
        {
            int k = dtgmember.SelectedIndex;
            if (k == -1)
            {
                Response.Write("<script>alert('Ban chưa chọn thành viên cần sửa')</script>");

            }
            else
            {
                m.MemberName = txt_ten.Text.Trim();
                m.Password = txt_password.Text.Trim();
                m.Phone = txt_phone.Text.Trim();
                m.Email = txt_email.Text.Trim();
                if (lstthanhvien.Text == "Admin")
                {
                    m.MemberType = 1;
                }
                else if (lstthanhvien.Text == "User")
                {
                    m.MemberType = 0;
                }
                string ma = dtgmember.Rows[k].Cells[0].Text.Trim();
                mb.updateMember(Guid.Parse(ma), m.MemberName, m.Phone, m.Email, m.Password, m.MemberType);
                hienthi();
            }


        }

        protected void dtgmember_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = dtgmember.SelectedIndex;
            txt_email.Text = dtgmember.Rows[k].Cells[2].Text.Trim();
            if (txt_email.Text == "&nbsp;") txt_email.Text = "";
            txt_ten.Text = HttpUtility.HtmlDecode(dtgmember.Rows[k].Cells[0].Text);
            if (txt_ten.Text == "&nbsp;") txt_ten.Text = "";
            txt_phone.Text = dtgmember.Rows[k].Cells[1].Text.Trim();
            txt_password.Text = dtgmember.Rows[k].Cells[3].Text.Trim();

        }

        protected void btn_tim_Click(object sender, EventArgs e)
        {
            if (lstthanhvien.Text == "Admin")
            {
                m.MemberType = 1;
            }
            else if (lstthanhvien.Text == "User")
            {
                m.MemberType = 0;
            }

            dtgmember.DataSource = mb.searchMember(m.MemberType, IsAdmin());
            dtgmember.DataBind();
        }
    }
}