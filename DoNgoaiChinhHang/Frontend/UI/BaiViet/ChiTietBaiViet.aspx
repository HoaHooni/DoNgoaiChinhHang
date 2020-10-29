<%@ Page Title="" Language="C#" MasterPageFile="~/Frontend/Site.Master" AutoEventWireup="true" CodeBehind="ChiTietBaiViet.aspx.cs" Inherits="DoNgoaiChinhHang.Frontend.UI.BaiViet.ChiTietBaiViet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../css/BaiViet/ChiTietBaiViet.css" rel="stylesheet" />
    <div class="title-post">
        <asp:Label ID="lblPostName" runat="server"></asp:Label>
    </div>
    <br />
    <div class="inner-post">
        <div class="summary-post">
            <asp:Label ID="lblPostSummary" runat="server"></asp:Label>
        </div>
        <div class="img-post">
            <asp:Image ID="ImgPost" Width="600" runat="server" />
        </div>
        <div class="content-post">
            <asp:Label ID="lblPostContent" runat="server"></asp:Label>
        </div>
        <br />
        <br />
        <h1><b>Bài viết liên quan</b></h1>
        <br />
        <div class="related-post">
            <asp:DataList ID="dataListRelatedPost" runat="server" RepeatColumns="4">
                <ItemTemplate>
                    <div class="item-related-post">
                        <div class="img-related-post">
                            <asp:Image ID="Image1" runat="server" Width="150" ImageUrl='<%# Eval("ImageRelatedPost") %>' />
                        </div>
                        <div>
                            <a href='<%# Eval("LinkDetail") %>'><%# Eval("RelatedPostName") %></a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
