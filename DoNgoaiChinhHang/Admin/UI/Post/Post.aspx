<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="Post.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.Post.Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <link href="../../CSS/Post/Post.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ BÀI VIẾT
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="searchbar">
        <div class="searchbar-left">
            <asp:Button ID="btnAdd" runat="server" Text="Thêm bài viết mới" CssClass="btnFn" PostBackUrl="~/Admin/UI/Post/AddPost.aspx" />
            <asp:Button ID="btnRefresh" runat="server" Text="Nạp lại" CssClass="btnFn" OnClick="btnRefresh_Click" />
        </div>
        <div class="searchbar-right">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="txtSearch"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" CssClass="btnFn" OnClick="btnSearch_Click" />
        </div>
    </div>
    
    <br />
    <br />
    <asp:DataList ID="DataList1" runat="server" Width="100%">
        <ItemTemplate>
            <table cellpadding="10" class="auto-style1" style="padding: 5px">
                <tr>
                    <td style="width: 50px">
                        <asp:Image ID="Image1" Width="140" Height="140" ImageUrl='<%# Eval("ImageURL") %>' runat="server" />
                    </td>
                    <td style="vertical-align: top; text-align: left">
                        <%# Eval("PostInfo") %>
                    </td>
                    <td style="width: 50px">
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("PostID") %>' OnClick="LinkButton1_Click">Xoá</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
