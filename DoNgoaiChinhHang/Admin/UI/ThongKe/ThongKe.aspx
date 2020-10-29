<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ThongKe.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.ThongKe.ThongKe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../CSS/ThongKe/ThongKe.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            border-collapse: collapse;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ THỐNG KÊ
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row row-order-new">
        <div class="row-title">Đơn hàng mới</div>
        <div class="row-content">

            <asp:DataList ID="dataListOrderNew" runat="server" RepeatColumns="4" Width="100%">
                <ItemTemplate>
                    <%# Eval("OrderInfo") %>
                </ItemTemplate>
            </asp:DataList>

        </div>
    </div>
    <br />
    <div class="row row-product-quantity-max">
        <div class="row-title">Sản phẩm có số lượng còn nhiều nhất</div>
        <div class="row-content">
            <asp:DataList ID="dataListProductQuantityMax" runat="server" RepeatColumns="5   ">
                <ItemTemplate>
                    <table class="card table">
                        <tbody>
                            <tr>
                                <td class="ignore" style="width: 75px;">
                                    <asp:Image ID="imgProduct" runat="server" Width="70" ImageUrl='<%# Eval("Image") %>' />
                                </td>
                                <td class="ignore">
                                    <%# Eval("ProductInfo") %>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <br />
    <div class="row row-product-quantity-min">
        <div class="row-title">Sản phẩm có số lượng còn ít nhất</div>
        <div class="row-content">
            <asp:DataList ID="dataListProductQuantityMin" runat="server" RepeatColumns="5">
                <ItemTemplate>
                    <table class="card table">
                        <tbody>
                            <tr>
                                <td class="ignore" style="width: 75px;">
                                    <asp:Image ID="imgProduct" runat="server" Width="70" ImageUrl='<%# Eval("Image") %>' />
                                </td>
                                <td class="ignore">
                                    <%# Eval("ProductInfo") %>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <br />
    <div class="row row-order-value">
        <div class="row-title">Đơn hàng có giá trị cao nhất</div>
        <div class="row-content">
            <asp:DataList ID="dataListOrderValue" runat="server" RepeatColumns="5">
                <ItemTemplate>
                    <%# Eval("OrderInfo") %>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <br />
    <div class="row row-product-rate">
        <div class="row-title">Sản phẩm có trung bình đánh giá từ khách hàng tốt nhất</div>
        <div class="row-content">
            <asp:DataList ID="dataListProductRate" runat="server" RepeatColumns="5">
                <ItemTemplate>
                    <table class="card table">
                        <tbody>
                            <tr>
                                <td style="width: 75px">
                                    <asp:Image ID="imgProduct" runat="server" Width="70px" ImageUrl='<%# "../../Img/images/" + (string.IsNullOrEmpty(Eval("Image").ToString()) ? "noimg.png" : HttpUtility.UrlDecode(Eval("Image").ToString())) %>' />
                                </td>
                                <td>
                                    <div><b><%# Eval("ProductName") %></b></div> 
                                    <div>Giá: <%# Eval("Price") %>đ</div>
                                    <div>Đánh giá: <%# Eval("Rank") %>/5 sao.</div>
                                    <div><a href='<%# "../Product/ProductDetail.aspx?productid=" + Eval("ProductID") %>'>Xem chi tiết</a></div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <br />
    <div class="row row-post-rate">
        <div class="row-title">Bài viết có trung bình đánh giá từ khách hàng tốt nhất</div>
        <div class="row-content">
            <asp:DataList ID="dataListPostRate" runat="server" RepeatColumns="4">
                <ItemTemplate>
                    <table class="card table">
                        <tbody>
                            <tr>
                                <td style="width: 75px">
                                    <asp:Image ID="imgPost" Width="70px" runat="server" ImageUrl='<%# "../../Img/images/" + (string.IsNullOrEmpty(Eval("Image").ToString()) ? "noimg.png" : HttpUtility.UrlDecode(Eval("Images").ToString()) ) %>' />
                                </td>
                                <td>
                                    <div><b><%# Eval("PostName") %></b></div>
                                    <div>Đánh giá: <%# Eval("Rank") %>/5 sao.</div>
                                    <div><a href='<%# "../../Post/PostDetail.aspx?OrderID=" + Eval("PostID") %>'>Xem chi tiết</a></div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <br />
    <script type="text/javascript">
        $(() => {
            $('#ContentPlaceHolder_dataListProductQuantityMax tr td:not(td.ignore)').css('width', '20%');
            $('#ContentPlaceHolder_dataListProductQuantityMin tr td:not(td.ignore)').css('width', '20%');
        })
    </script>
</asp:Content>
