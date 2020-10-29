<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.Order.OrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style7 {
            width: 100%;
        }
        .auto-style10 {
            text-align: left;
            width: 213px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <strong>
    <br />
    </strong>
    <asp:DataList ID="DataList1" runat="server">
        <ItemTemplate>
            <table class="auto-style7">
                <tr>
                    <td class="auto-style10"><strong>Mã đơn</strong></td>
                    <td><%# Eval("OrderID") %></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>Tên khách hàng</strong></td>
                    <td><%# Eval("CustomerName") %></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>SDT</strong></td>
                    <td><%# Eval("CustomerPhone") %></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>Địa chỉ</strong></td>
                    <td><%# Eval("CustomerAddress") %></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>Note</strong></td>
                    <td><%# Eval("Note") %></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>Ẩn tên</strong></td>
                    <td><input type="checkbox" checked="<%# Eval("IsHidden") %>" disabled="disabled" /></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>Thanh toán</strong></td>
                    <td><%# Eval("PayMethod") %></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>Ngày tạo</strong></td>
                    <td><%# Eval("CreatedDate") %></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>Ngày xử lý</strong></td>
                    <td><%# Eval("CompletedDate") %></td>
                </tr>
                <tr>
                    <td class="auto-style10"><strong>Đã xử lý</strong></td>
                    <td>
                        <%# Eval("State") %>
                        <%# Eval("LinkState") %>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <strong>
    <br />
    <br />
    Danh sách sản phẩm<br />
    &nbsp;</strong><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:ImageField DataImageUrlField="Image" HeaderText="Hình ảnh" ControlStyle-Width="120">
            </asp:ImageField>
            <asp:BoundField DataField="ProductName" HeaderText="Tên sản phẩm" />
            <asp:BoundField DataField="OriginName" HeaderText="Nguồn gốc" />
            <asp:BoundField DataField="ManufacturerName" HeaderText="Nhà cung cấp" />
            <asp:BoundField DataField="Quantity" HeaderText="Số lượng" />
            <asp:BoundField DataField="Price" HeaderText="Giá" />
        </Columns>
    </asp:GridView>
    <br />
        <asp:Label ID="lblSum" runat="server" Text="Label"></asp:Label>
        <br />
        <a href="DonHang.aspx" style="text-decoration:none"><span style="font-weight:bold;">Trở lại</span></a>
        <br /><br /><br />
    </asp:Content>
