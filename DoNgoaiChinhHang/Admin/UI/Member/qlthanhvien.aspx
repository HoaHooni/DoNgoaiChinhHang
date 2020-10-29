<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="qlthanhvien.aspx.cs" Inherits="DoNgoaiChinhHang.qlthanhvien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/Member/Member.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ QUẢN LÝ THÀNH VIÊN
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b class="btnFn">QUẢN LÝ THÀNH VIÊN</b></p>
    
    
    <table border="1" cellspacing="0" class="auto-style13" >
        <tr>
            <td>&nbsp;Tên thành viên :</td>
            <td>
                <asp:TextBox ID="txt_ten" runat="server" Width="90%" ValidateRequestMode="Disabled"></asp:TextBox>
            </td>
            <td>&nbsp;SĐT:&nbsp;&nbsp;</td>
            <td>
        <asp:TextBox ID="txt_phone" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;Mật khẩu:</td>
            <td><asp:TextBox ID="txt_password" runat="server" CssClass="auto-style4" Width="90%"></asp:TextBox>
            </td>
            <td>&nbsp;Email:</td>
            <td>
        <asp:TextBox ID="txt_email" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>&nbsp;Loại thành viên:</td>
            <td>
                <asp:DropDownList ID="lstthanhvien" runat="server" Height="26px" Width="90%">
                </asp:DropDownList>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>
    
    <p style="text-align: center">
        <asp:Button ID="btn_them" runat="server" CssClass="btnFn" Text="Thêm" OnClick="btn_them_Click" />
&nbsp;
        &nbsp;&nbsp;
        <asp:Button ID="btn_sua" runat="server" Text="Sửa" CssClass="btnFn" OnClick="btn_sua_Click" />
&nbsp;&nbsp;
        <asp:Button ID="btn_tim" runat="server" CssClass="btnFn" Text="Tìm kiếm theo loại thành viên" OnClick="btn_tim_Click" />
        </p>
    
    <asp:GridView ID="dtgmember" runat="server" AutoGenerateColumns="False" CssClass="auto-style6" DataKeyNames="MemberID" OnRowDeleting="dtgmember_RowDeleting" OnSelectedIndexChanged="dtgmember_SelectedIndexChanged" CellPadding="4" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="MemberName" HeaderText="Tên thành viên" >
            <ControlStyle Width="220px" />
            </asp:BoundField>
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Password" HeaderText="Password" />
            <asp:BoundField DataField="MemberType" HeaderText="Loại thành viên" />
            <asp:CommandField HeaderText="Chọn Member" ShowSelectButton="True" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Xóa" HeaderText="Xóa bỏ" />
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#FF4D00" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
    <script type="text/javascript">
        $(() => {
            var isAdmin = ContextData.IsAdmin ? true : false;
            if (!isAdmin) {
                $('#ContentPlaceHolder_dtgmember tbody tr td:nth-child(7)').filter((index, item) => { $(item).html("<strong>Không có quyền xóa</strong>") })
            }

        });
    </script>
</asp:Content>
