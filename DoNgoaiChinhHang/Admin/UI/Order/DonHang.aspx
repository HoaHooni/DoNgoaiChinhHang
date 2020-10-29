<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="DonHang.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.Order.DonHang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="2">Tất cả</asp:ListItem>
        <asp:ListItem Value="0">Đã xử lý</asp:ListItem>
        <asp:ListItem Value="1">Mới</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Tìm kiếm" />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="labMes" runat="server" BackColor="White" CssClass="color"></asp:Label>
    <br />
    <style>
        .color{
            color:red;
        }
    </style>
&nbsp;<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="1146px" >
        <Columns>
            <asp:BoundField DataField="OrderCode" HeaderText="Mã đơn hàng" />
            <asp:BoundField DataField="CustomerName" HeaderText="Tên khách hàng" />
            <asp:BoundField DataField="CustomerPhone" HeaderText="Số điện thoại KH" />
            <asp:BoundField DataField="Note" HeaderText="Ghi chú" />
            <asp:CheckBoxField DataField="IsHidden" HeaderText="Ẩn tên" />
            <asp:BoundField DataField="PayMethod" HeaderText="Phương thức thanh toán" />
            <asp:BoundField DataField="State" HeaderText="Trạng thái" />
            <asp:BoundField DataField="CreateDate" HeaderText="Ngày tạo" />
            <asp:BoundField DataField="CompletedDate" HeaderText="Ngày xử lý" />
            <asp:HyperLinkField DataNavigateUrlFields="LinkDetail" HeaderText="Chi tiết" Text="Detail" />
            <asp:HyperLinkField DataNavigateUrlFields="linkUpdate" DataTextField="textUpdate" />
        </Columns>
    </asp:GridView>
    <br />
</asp:Content>
