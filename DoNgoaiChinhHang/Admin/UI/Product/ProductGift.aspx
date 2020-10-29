<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ProductGift.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.Product.ProductGift" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/Product/ProductGift.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-collapse: collapse;
            border-style: solid;
            border-width: 1px;
        }
        .auto-style2 {
            width: 213px;
        }
        .auto-style3 {
            width: 220px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ SẢN PHẨM/ QUÀ TẶNG
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table cellpadding="4" cellspacing="0" style="border-bottom: 1px solid black; width: 100%">
        <tr>
            <td>
                <asp:Image ID="productImg" runat="server" Width="140px" Height="140px" /></td>
            <td><asp:Label ID="txtProductInfo" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
    <br />
    <br />
    <b><i>QUÀ TẶNG</i></b>
    <br />
    <br />
    <asp:Button ID="btnBack" runat="server" Text="Quay lại" PostBackUrl="~/Admin/UI/Product/SanPham.aspx"/>
    <br />
    <br />
    <table cellpadding="5" class="auto-style1">
        <tr>
            <td class="auto-style3">Tên quà tặng</td>
            <td>
                <asp:DropDownList ID="ddlAllProduct" runat="server" Height="22px" Width="100%">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Số lượng</td>
            <td>
                <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Button ID="btnAdd" runat="server" Text="Thêm quà tặng" OnClick="btnAdd_Click" />
    <br />
    <br />
    Danh sách quà tặng<br />
    <asp:DataList ID="lstGift" runat="server" RepeatColumns="3" Width="100%">
        <ItemTemplate>
            <table cellpadding="5" class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="imgProductGift" runat="server" Width="70" Height="70" ImageUrl='<%# Eval("Image") %>' />
                    </td>
                    <td>
                        <div class="product-detail">
                            <%# Eval("GiftInfo") %>
                            <asp:HyperLink ID="linkDetail" runat="server" NavigateUrl='<%# Eval("LinkDetail") %>'>Xem chi tiết</asp:HyperLink>
                            <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" CommandArgument='<%# Eval("GiftID") %>'/>
                        </div>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
