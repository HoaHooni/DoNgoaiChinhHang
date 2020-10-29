<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Site.Master" AutoEventWireup="true" CodeBehind="My_pham_dac_tri.aspx.cs" Inherits="Master_nguoidung.My_pham_dac_tri" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .list-product{
            margin-left:40px;
        }
        .list-product img{
            
        }
        .content-left{
            margin-left: 28px;
            background-color:white;
        }
        .LinkImg img{
            height: 140px;
            width: 140px;
        }
        .item-product{
            padding: 5px;
            margin: 5px;
        }
    </style>
   <b>MỸ PHẨM ĐẶC TRỊ</b> <br />
Dòng mỹ phẩm đặc trị tại dongoaichinhhang.com phân phối chính thức luôn nhận được sự ủng hộ nhiệt tình của Quý Khách hàng như: trị rụng tóc, thuốc mọc tóc, trị mụn, trị nám, giảm mỡ bụng, giảm cân… được cung cấp từ những thương hiệu uy tín trên thế giới. Cam kết hàng chính hãng 100% - đảm bảo chất lượng. Quý khách có thể đặt hàng toàn quốc - Giao hàng nhanh – nhận hàng tại nhà. Dịch vụ chăm sóc khách hàng tận tình trước - trong - sau khi mua hàng. Bảo vệ người mua hoàn tiền 300% - nếu phát hiện hàng giả, hàng nhái, hàng kém chất lượng.<br />
    <br />
&nbsp;
    <div class="list-products">
        <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" RepeatColumns="5">
            <ItemTemplate>
                <table class="item-product">
                    <tr>   
                        <td style="width:97px">
                            <asp:HyperLink  runat="server" ID="hyperlink1" CssClass="LinkImg" ImageUrl='<%# Eval("Image") %>'></asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Literal Text='<%# Eval("ProductName") %>' runat="server"></asp:Literal></td>
                    </tr>
                     <tr>
                        <td><h3 style="color:red"><asp:Literal Text='<%# Eval("Price") %>' runat="server"></asp:Literal></h3></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>

    </div>
</asp:Content>
