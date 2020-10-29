<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Site.Master" AutoEventWireup="true" CodeBehind="KienThucLamDep.aspx.cs" Inherits="DoNgoaiChinhHang.Frontend.UI.BaiViet.KienThucLamDep" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/BaiViet/BaiViet.css" rel="stylesheet" />
    <form id="form1" runat="server">
    <h2 class="pageName">Tư vấn làm đẹp</h2>
        <br />
    <div class="content">
        <asp:DataList ID="dataListPost" runat="server" >
            <ItemTemplate>
                <table cellpadding="5" style="width: 100%; border-collapse: collapse" class="item-post">
                    <tr>
                        <td style="width: 150px; text-align:center">
                            <asp:Image Width="140" Height="140" ID="ImgPost" runat="server" CssClass="imgPost" ImageUrl='<%# Eval("Image") %>' />
                        </td>
                        <td style="vertical-align: top; padding: 5px;">
                            <div class="title-post">
                                <a href='<%# Eval("LinkDetail") %>'><%# Eval("PostName") %></a>
                            </div>
                            <div class="summary-post">
                                <%# Eval("Summary") %>
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</asp:Content>
