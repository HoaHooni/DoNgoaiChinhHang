<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="SanPham.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.Product.SanPham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/Product/Product.css" rel="stylesheet" />
    <script type="text/javascript">
        function DeleteProduct(id, name) {
            if (confirm("Bạn có chắc chắn muốn xóa sản phẩm \"" + name + "\" này không?")) {
                alert("Đã xóa sản phẩm thành công");
                location.href = location.origin + "/Admin/UI/Product/ProductDelete.aspx?productID=" + id;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ SẢN PHẨM
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="searchbar">
        <div class="searchbar-left">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btlThem" PostBackUrl="~/Admin/UI/Product/AddProduct.aspx" />
            <asp:Button ID="btnLamMoi" runat="server" Text="Nạp lại" CssClass="btlThem" OnClick="btnLamMoi_Click" />
        </div>
        <div class="searchbar-right">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btnSearch" OnClick="btnSearch_Click" />
        </div>
    </div>
    <br />
    <br />
    <asp:DataList ID="DataList1" runat="server" Width="100%">
        <ItemTemplate>
            <table cellpadding="5" cellspacing="0" class="auto-style2">
                <tr>
                    <td style="width: 150px">
                        <asp:Image ID="Image1" runat="server" CssClass="product-img" ImageUrl='<%# Eval("Image").ToString() %>' />
                    </td>
                    <td style="vertical-align: top;">
                        <a class="produtc-name" href='<%# Eval("LinkEdit").ToString() %>'><%# Eval("ProductName") %></a>
                        <div class="produtc-manufacturer">Hãng SX: <i><%# Eval("ManufacturerName") %></i>&nbsp;&nbsp;&nbsp;Xuất xứ: <i><%# Eval("OriginName") %></i></div>
                        <div class="product-category">Loại hàng: <%# Eval("CategoryInfo") %></div>
                        <div class="produtc-price">Giá bán: <%# Eval("Price") %>đ</div>
                        <div class="produtc-rate"><i><%# Eval("Rate") %></i></div>
                        <div class="produtc-quantity">Số lượng: <%# Eval("Quantity").ToString() %> sp</div>
                        <div class="produtc-sale"><i><%# Eval("Sale").ToString() %></i></div>
                        <div class="produtc-summary"><%# Eval("Summary").ToString() %></div>
                    </td>
                    <td width="83">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="product-edit" NavigateUrl='<%# Eval("LinkEdit").ToString() %>'>Xem chi tiết</asp:HyperLink>
                    </td>
                    <td width="62">
                        <asp:HyperLink ID="HyperLink3" runat="server" CssClass="product-gift" NavigateUrl='<%# Eval("LinkGift").ToString() %>'>Quà tặng</asp:HyperLink>
                    </td>
                    <td width="41">
                        <input type="button" value="Xóa" class="btnXoa" onclick="<%# Eval("FnDelete").ToString().Trim()%>" />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>

    <br />
    <br />
    <br />
</asp:Content>
