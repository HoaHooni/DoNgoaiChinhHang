<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="ManufacturerAndOrigin.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.ManuAndOrigin.ManufacturerAndOrigin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            vertical-align: top;
        }

        .auto-style2 {
            text-align: center;
        }

        .auto-style3 {
            width: 100%;
            border-collapse: collapse;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ NSX & XUẤT XỨ
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <table cellpadding="5" cellspacing="0" class="auto-style1">
        <tr>
            <td>
                <asp:TextBox ID="txtNSX" runat="server" Width="100%" CssClass="inputStandard"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:TextBox ID="txtXuatXu" runat="server" Width="100%" CssClass="inputStandard"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Button ID="btnAddNSX" runat="server" CssClass="btnFn" Text="Thêm mới nhà sản xuất" OnClick="btnAddNSX_Click" />
            </td>
            <td>&nbsp;</td>
            <td class="auto-style2">
                <asp:Button ID="btnAddXuatXu" runat="server" CssClass="btnFn" Text="Thêm mới xuất xứ" OnClick="btnAddXuatXu_Click" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align:top">
                <asp:DataList ID="dataListNSX" runat="server" CssClass="tbStandard">
                    <ItemTemplate>
                        <div style="padding: 5px"><%# Eval("ManufacturerName") %></div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td>&nbsp;</td>
            <td style="vertical-align:top">
                <asp:DataList ID="dataListXuatXu" runat="server" CssClass="tbStandard">
                    <ItemTemplate>
                        <div style="padding: 5px"><%# Eval("OriginName") %></div>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>

</asp:Content>
