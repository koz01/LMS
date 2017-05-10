<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryManagementSysteem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
        <div class="loginmodal-container" style="margin-top: 150px;">
            <table style="width: 100%;">


                <tr>
                    <td style="color: #2F4F4F;">Username:
  
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="TextBox loginmodal-container input[type=text], input[type=password] " />
                    </td>

                    <td>
                        <asp:RequiredFieldValidator ID="rfvUser" ErrorMessage="Invalid UserName" runat="server" ControlToValidate="txtUserName" Display="Dynamic"
                            EnableClientScript="false" ForeColor="Red"/>
                    </td>
                </tr>
                <tr>
                    <td style="color: #2F4F4F;">Password:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPWD" runat="server" CssClass="TextBox loginmodal-container input[type=text], input[type=password]" />

                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvPWD" ErrorMessage="Invalid Password" runat="server" ControlToValidate="txtPWD" Display="Dynamic"
                            EnableClientScript="false" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" OnClick="btnSumbit_Click" runat="server" Text="Login" class="loginmodal-submit" Style="width: 120px; margin-left: 19px;" />
                        <asp:LinkButton ID="btnForgetPasword" CssClass="LinkButton" style="color:blue;" OnClick="btnForgetPasword_Click" CausesValidation="False" runat="server">Forget Password?</asp:LinkButton>
                        |
                         <asp:LinkButton ID="btnsingUp" CssClass="LinkButton" style="color:blue;" OnClick="btnsingUp_Click" CausesValidation="False" runat="server" > Sing Up</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
