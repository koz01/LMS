<%@ Page Title="SearchBook" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchBook.aspx.cs" Inherits="LibraryManagementSysteem.SearchBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="style/style.css" rel="stylesheet" type="text/css" />

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div class="rentbook">

        <h2 style="color:#3b5998;">Search Book
        </h2>
        Book Name :
        <asp:TextBox ID="txtBookName" runat="server" CssClass="TextBox" ></asp:TextBox>
        &emsp;
    Author Name :
        <asp:TextBox ID="txtAuthor" runat="server" CssClass="TextBox"></asp:TextBox>

        <br />
        <br />
        Category :
        <asp:DropDownList ID="ddlCategory" runat="server" style="margin-left:15px;" AutoPostBack="True" CssClass="TextBox">
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="loginmodal-submit" Style="width:100px; background-color: #3b5998;" /><br />
        <br />
        <hr />
    </div>

    <div style="width: 100%;">
        <div style="float: left; width: 50%;">
            <div style="margin-left: auto; margin-right: auto; width: 900px;">
                <asp:GridView ID="grdBookList" runat="server" ForeColor="#333333"
                    GridLines="None" AutoGenerateColumns="False" HorizontalAlign="Center">
                    <Columns>

                        <asp:BoundField DataField="BookID" HeaderText="Serial" />
                        <asp:BoundField DataField="BookName" HeaderText="Name" />
                        <asp:BoundField DataField="Author" HeaderText="Author" />
                        <asp:BoundField DataField="Category" HeaderText="Type" ReadOnly="true" />
                        <asp:BoundField DataField="ISBN" HeaderText="ISBN No" />

                    </Columns>

                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </div>
        </div>

        <div style="float: right;">
            <br />
            <asp:ImageButton ID="imgBtnExport" runat="server" ImageUrl="~\Images\excel-icon.png"
                Width="50px" Height="50px" ImageAlign="Left" OnClick="imgBtnExport_Click" />
        </div>

        <div>
        </div>
    </div>
</asp:Content>
