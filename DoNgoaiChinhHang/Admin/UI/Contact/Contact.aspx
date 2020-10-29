<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.Contact.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/Contact/Contact.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ THÔNG TIN LIÊN HỆ
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <p style="font-size:large">
        <b aria-atomic="True" class="btnFn">Liên hệ</b>
    </p>
    <table cellpadding="5" class="auto-style9" align="center">
        <tr>
            <td class="auto-style10">Tên shop</td>
            <td>
        <asp:TextBox ID="txt_ten" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Địa chỉ</td>
            <td>
        <asp:TextBox ID="txt_diachih" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Địa chỉ kho</td>
            <td>
        <asp:TextBox ID="txt_diachikho" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Hotline</td>
            <td>
        <asp:TextBox ID="txt_hotline" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Email</td>
            <td>
        <asp:TextBox ID="txt_email" runat="server"  Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Website</td>
            <td>
        <asp:TextBox ID="txt_website" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btn_sua" runat="server" Text="Sửa" CssClass="btnFn" Width="70px" OnClick="btn_sua_Click"  />
            </td>
        </tr>
    </table>
    </asp:Content>
