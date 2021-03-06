﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.Product.ProductDetail" ValidateRequest="false" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/Product/ProductDetail.css" rel="stylesheet" />
    <script src="../../JS/ProductDetail.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ SẢN PHẨM/ CHI TIẾT
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Lưu lại" OnClick="btnAdd_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnBack" runat="server" Text="Quay lại" PostBackUrl="~/Admin/UI/Product/SanPham.aspx" />
    <br />
    <br />
            <table runat="server" cellpadding="5" class="auto-style1">
        <tr>
            <td class="auto-style3">Tên sản phẩm</td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server" Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Mã sản phẩm</td>
            <td>
                <asp:TextBox ID="txtProductCode" runat="server"  Width="90%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Thể loại</td>
            <td>
                <asp:CheckBoxList ID="ckCategory" runat="server" DataTextField="CategoryName" RepeatColumns="3"  OnLoad="ckCategory_DataBinding" DataValueField="CategoryID"></asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Giá bán</td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Số lượng</td>
            <td>
                <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Nhà sản xuất</td>
            <td>
                <asp:DropDownList ID="txtNhaSX" runat="server" Width="200px" DataValueField="ManufacturerID" DataTextField="ManufacturerName" ></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Xuất xứ</td>
            <td><asp:DropDownList ID="txtXuatXu" runat="server" Width="200px" DataValueField="OriginID" DataTextField="OriginName"></asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td class="auto-style3">Ảnh đại diện</td>
            <td>
                <asp:Image ID="imgProduct" runat="server" Width="140px" Height="140px"/>
                <br />
                <asp:TextBox ID="txtImgURL" Width="100%" ReadOnly="true" runat="server"></asp:TextBox>
                <input type="button" value="Chọn ảnh" onclick="BrowseServer();"
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Chế độ ship</td>
            <td>
                <asp:RadioButton ID="radFreeShip" runat="server" GroupName="ShipMode" Text="Miễn phí Ship" />
                <br />
                <asp:RadioButton ID="radQuantityShip" runat="server" GroupName="ShipMode" Text="Miễn phí khi mua từ nhiều sản phẩm trở lên" />
                &nbsp;:&nbsp;
                <asp:TextBox ID="txtNumShip" runat="server" Width="136px" TextMode="Number"></asp:TextBox>&nbsp;sản phẩm</td>
        </tr>
        <tr>
            <td class="auto-style3">Thông tin khuyến mại</td>
            <td>
                <asp:CheckBox ID="chkSale" runat="server" Text="Áp dụng khuyến mại" />
                <br />
                <br />
                Giảm ngay
                <asp:TextBox ID="txtAmountSale" runat="server" TextMode="Number"></asp:TextBox>
                đ/sp khi mua từ 
                <asp:TextBox ID="txtQuantitySale" runat="server" Width="132px" TextMode="Number"></asp:TextBox>
                sản phẩm</td>
        </tr>
    </table>
    
    <br />
    <h2>NỘI DUNG TÓM TẮT GIỚI THIỆU SẢN PHẨM</h2>
    <asp:TextBox ID="txtSummary" runat="server" CssClass="ckeditor" TextMode="MultiLine" ValidateRequestMode="Disabled"></asp:TextBox>
    <h2>NỘI DUNG GIỚI THIỆU SẢN PHẨM</h2>
    <asp:TextBox ID="txtDetail" runat="server" CssClass="ckeditor" TextMode="MultiLine" ValidateRequestMode="Disabled"></asp:TextBox>
    <script src="../../../Plugin/ckeditor/ckeditor.js"></script>
    <script src="../../../Plugin/ckfinder/ckfinder_v1.js"></script>
</asp:Content>
