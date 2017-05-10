<%@ Page Title="AddNewBook" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewBook.aspx.cs" Inherits="LibraryManagementSysteem.AddNewBook" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 style="color: #3b5998;">Insert information of New Book
    </h2>
    <br />

    <div style="width: 100%;">

        <div style="float: left; width: 60%;">
            <table>
                <tr>
                    <td>Serial Number :
                        <asp:TextBox ID="txtSerialNo" runat="server" Style="margin-left: 10px;" onFocus="this.blur()" CssClass="TextBox"></asp:TextBox>

                        <asp:RequiredFieldValidator runat="server" ID="reqSerial" ControlToValidate="txtSerialNo"
                            ErrorMessage="Serial is required" ForeColor="Red" />

                    </td>
                </tr>

                <tr>
                    <td>Book Name :
                        <asp:TextBox ID="txtBookName" runat="server" Style="margin-left: 20px;" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="reqName" ControlToValidate="txtBookName"
                            ErrorMessage="Name is required!" ForeColor="Red" />

                    </td>
                </tr>

                <tr>
                    <td>Author:
                        <asp:TextBox ID="txtAuthor" runat="server" Style="margin-left: 55px;" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="reqAuthor" ControlToValidate="txtAuthor"
                            ErrorMessage="Author is required!" ForeColor="Red" />
                    </td>
                </tr>
                <tr>
                    <td>ISBN:
                        <asp:TextBox ID="txtISBN" runat="server" Style="margin-left: 70px;" CssClass="TextBox"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td>Select Category :
            <asp:DropDownList ID="ddlAddCategory" runat="server" CssClass="TextBox" OnSelectedIndexChanged="ddlAddCategory_SelectedIndexChanged"
                AutoPostBack="True">
            </asp:DropDownList>
                        <br />

                    </td>
                </tr>
            </table>
        </div>

        <div style="float: right; width: 40%;">

            <asp:Image ID="imgBook" runat="server" Height="225px" ImageUrl="~/Images/books.jpg" Width="225px" />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="TextBox" />
            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" class="loginmodal-submit" Style="width: 100px; background-color: #3b5998;" />

        </div>


    </div>

    <asp:Button ID="btnSaveNewBook" runat="server" class="loginmodal-submit" Style="width: 100px; background-color: #3b5998;" Text="Submit" OnClick="btnSaveNewBook_Click" />

    <br />
    <br />
    <hr />

</asp:Content>

