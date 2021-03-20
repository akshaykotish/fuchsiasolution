<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PTE_VG.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Kotish/Styles/Glow.css" rel="stylesheet" />
    <link href="Kotish/Styles/Design.css" rel="stylesheet" />
    <link href="Kotish/Styles/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="loginbox animated pulse">
                <div class="fs">

                </div>
                <div class="loginarea">
                    <h3>Login</h3>
                    <div>
                        Email/Contact
                    </div>
                    <div>
                            <asp:TextBox ID="Email" runat="server" TextMode="SingleLine" Placeholder="Email"></asp:TextBox>
                    </div>
                    <div>
                        Password
                    </div>
                    <div>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
                    </div>
                    <div>
                             <asp:Button ID="Login_btn" runat="server" CssClass="buttons" BackColor="WhiteSmoke" Text="Login" OnClick="Login_Click" />
                    </div>
                </div>
            </div>
             <span class="my_loog glow chngs">Designed by <b>Akshay Kotish & Co.</b></span>
        </div>
    </form>
</body>
</html>
