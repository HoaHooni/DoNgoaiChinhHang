<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DoNgoaiChinhHang.Admin.UI.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 30%;
            border-collapse: collapse;
            border: 1px solid #000000;
        }
        .auto-style2 {
            text-align: justify;
        }
        .formLogin{
            background-image: url("../../Img/bg_login.gif");
            height: 100vh;
            background-size: 100% 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="formLogin">
        <div style="text-align:center">
            <br />
            <br />
            <asp:Image ID="imgLogo" runat="server" Width="200px" ImageUrl="~/Admin/Img/dongoaichinhhang.png" />
            <br />
            <br />
            <h3>Đăng nhập vào trang quản trị</h3>
            <br />
            <table cellpadding="5" cellspacing="1" class="auto-style1" align="center">
                <tr>
                    <td style="text-align: left">Tên Tài khoản</td>
                    <td>
                        <asp:TextBox ID="txtAccName" runat="server" Width="98%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: left">Mật khẩu</td>
                    <td><asp:TextBox ID="txtPW" runat="server" Width="98%" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" />
                    </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
