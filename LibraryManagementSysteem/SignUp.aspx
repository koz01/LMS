<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LibraryManagementSysteem.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
        <div class="signup-container" style="margin-top: 10px;">

            <h2 style="color:#3b5998;">Create New Member
            </h2>

            <div style="display: inline; color:#2F4F4F; width: 100px; float: left;">User Name :</div>
            <asp:TextBox ID="txtMemberName" runat="server" CssClass="TextBox loginmodal-container input[type=text], input[type=password]"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUser" ForeColor="Red" ErrorMessage="***"
                Display="Dynamic" ControlToValidate="txtMemberName" runat="server" />
            <br />

            <div style="display: inline; color:#2F4F4F; width: 100px; float: left;">Password :</div>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="TextBox loginmodal-container input[type=text], input[type=password] "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ErrorMessage="***"
                Display="Dynamic" ControlToValidate="txtPassword" runat="server" />
            <br />

            <div style="display: inline; color:#2F4F4F; width: 100px; float: left;">Address :</div>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="TextBox loginmodal-container input[type=text], input[type=password] "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ErrorMessage="***"
                Display="Dynamic" ControlToValidate="txtAddress" runat="server" />
            <br />
            <div style="display: inline; color:#2F4F4F; width: 100px; float: left;">City :</div>
            <asp:TextBox ID="txtCity" runat="server" CssClass="TextBox loginmodal-container input[type=text], input[type=password] "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ErrorMessage="***"
                Display="Dynamic" ControlToValidate="txtCity" runat="server" />
            <br />
            <div style="display: inline; color:#2F4F4F; width: 100px; float: left;">Phone :</div>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="TextBox loginmodal-container input[type=text], input[type=password] "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ErrorMessage="***"
                Display="Dynamic" ControlToValidate="txtPhone" runat="server" />
            <br />
            <div style="display: inline; color:#2F4F4F; width: 100px; float: left;">Email :</div>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="TextBox loginmodal-container input[type=text], input[type=password] "></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ErrorMessage="***"
                Display="Dynamic" ControlToValidate="txtEmail" runat="server" />
            <br />
            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" CssClass ="loginmodal-submit" Style="cursor: pointer; width: 100px; margin-left: 175px;" />

        </div>
    </form>
</body>
</html>
