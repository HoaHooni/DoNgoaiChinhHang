<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site.Master" AutoEventWireup="true" CodeBehind="PostDetail.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.Post.PostDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1, .auto-style3 {
            width: 100%;
            border-collapse: collapse;
            border: 1px solid #000000;
        }

        .auto-style3{
            border-width: 3px;
        }

        .auto-style1 tr td{
            border: 1px solid black;
        }

        .auto-style3 tr td{
            border: none;
        }

        .auto-style2 {
            width: 200px;
        }

        .dataList{
            width: 100%;
        }
        .auto-style4 {
            width: 100%;
            border-collapse: collapse;
            border-style: solid;
            border-width: 1px;
        }
    </style>
    <script src="../../JS/PostDetail.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    ĐỒ NGOẠI CHÍNH HÃNG/ BÀI VIẾT/ CHI TIẾT BÀI VIẾT
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <br />
    <br />
    <asp:Button runat="server" ID="btnBack" Text="Quay lại" OnClick="btnBack_Click"/>
    <asp:Button runat="server" ID="btnSave" Text="Lưu lại" OnClick="btnSave_Click"/>
    <br />
    <br />

    <table cellpadding="5" class="auto-style1">
        <tr>
            <td class="auto-style2"><strong>Tên bài viết:</strong></td>
            <td>
                <asp:TextBox ID="txtTenBaiViet" runat="server" width="95%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2"><strong>Ngày tạo:</strong></td>
            <td>
                <asp:TextBox ID="txtNgayTao" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2"><strong>Ảnh đại điện:</strong></td>
            <td>
                <asp:Image ID="imgProduct" runat="server" Width="140px" Height="140px"/>
                <br />
                <asp:TextBox ID="txtImgURL" Width="95%" ReadOnly="true" runat="server"></asp:TextBox>
                <input type="button" value="Chọn ảnh" onclick="BrowseServer();"
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>Tóm tắt</strong>
                <br />
                <br />
                <asp:TextBox class="ckeditor" ID="txtSummary" runat="server" TextMode="MultiLine" ValidateRequestMode="Disabled"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>Nội dung bài viết:</strong>
                <br />
                <br />
                <asp:TextBox class="ckeditor" ID="txtDetail" runat="server" TextMode="MultiLine" ValidateRequestMode="Disabled"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2"><strong>Các bài viết liên quan<br /></strong>
                <asp:Label ID="lblEmpty" runat="server"></asp:Label>
                <br />
                <asp:Button ID="btnAddRelatedPost" runat="server" Text="Thêm bài viết liên quan" OnClick="btnAddRelatedPost_Click" />
                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                <br />
                <br />
                <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
                    <ItemTemplate>
                        <table cellpadding="5" class="auto-style4" style="border: none">
                            <tr>
                                <td style="border: none">
                                    <asp:Image ID="Image1" runat="server" Width="170" ImageUrl='<%# "../../Img/images/" + (string.IsNullOrEmpty(Eval("Image").ToString()) ? "noimg.png" : Eval("Image")) %>' />
                                </td>
                                <td style="border: none">
                                    <a href='<%# "PostDetail.aspx?postid=" + Eval("PostID") %>'><%# Eval("PostName") %></a>
                                    <br />
                                    <asp:Button ID="btnDeleteRelatedPost" runat="server" Text="Xoá" CommandArgument='<%# Eval("PostID") %>' OnClick="btnDeleteRelatedPost_Click"/>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
    <script src="../../../Plugin/ckeditor/ckeditor.js"></script>
    <script src="../../../Plugin/ckfinder/ckfinder_v1.js"></script>
</asp:Content>
