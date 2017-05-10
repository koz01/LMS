<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmail.aspx.cs" Inherits="LibraryManagementSysteem.SendEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server" style="width:900px; margin-top:150px; margin-left:200px;">
        <div class="loginmodal-container" >
            <table>

                <tr>
                    <td>
                     <h3 style="text-align:center; color:#3b5998;">Forget your password?</h3> 
                     <p style="color:#2F4F4F;">Enter your email address to send your password.
                     You may need to check your Email.</p>
                    </td>
                  
                </tr>

                <tr>                 
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="example@gmail.com" TextMode="Email" CssClass="TextBox loginmodal-container input[type=text], input[type=password], input[type=email] " />
                         <asp:RequiredFieldValidator ID="rfvUser" ForeColor="Red" ErrorMessage="Please enter Email" ControlToValidate="txtEmail" runat="server" />
                    </td>
                </tr>

                <tr>

                    <td>
                        <asp:Button ID="btnSend" OnClick="btnSend_Click"  runat="server" Text="Sumbit" class="loginmodal-submit" Style="cursor: pointer; 
                                        width:150px; margin:auto;" />

                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
