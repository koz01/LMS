<%@ Page Title="IssueBook" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="IssueBook.aspx.cs" Inherits="LibraryManagementSysteem.IssueBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <h2  style="color:#3b5998;">Search Issue Rent Book
    </h2>

    Book Name :
        <asp:TextBox ID="txtBookName" runat="server" CssClass="TextBox"></asp:TextBox>
    Member : 
         <asp:TextBox ID="txtAuthor" runat="server" CssClass="TextBox"></asp:TextBox>
    <br />
    <br />
    Category :
         <asp:DropDownList ID="ddlCategory" CssClass="TextBox" Style="margin-left: 20px;" runat="server" AutoPostBack="True">
         </asp:DropDownList>
    &emsp;
        
    Issue Book :
    <asp:CheckBox ID="chkIssue" Style="vertical-align: middle" runat="server" />
    &emsp;
    Rent Book :
    <asp:CheckBox ID="chkRent" Style="vertical-align: middle" runat="server" />
    &emsp;

    <br />
    <br />
    &emsp;
        <asp:Button ID="btnRentSearch" class="loginmodal-submit" Style="width:100px; background-color: #3b5998;" runat="server" Text="Search" OnClick="btnSearch_Click" />
        <asp:Button ID="btnRestore" class="loginmodal-submit" Style="width:100px; background-color: #3b5998;" runat="server" Text="Restore" OnClick="btnRestore_Click" />
    <br />

    <hr />

    <div style="width: 100%;">
        <div style="float: left; width: 80%;">
            <div style="margin-left: auto; margin-right: auto; width: 1000px;">
                <asp:GridView ID="grdBookList" runat="server" ForeColor="#333333" OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                    GridLines="None" AutoGenerateColumns="False" HorizontalAlign="Center">
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="memberId" HeaderText="Member" />
                        <asp:BoundField DataField="bookId" HeaderText="Book" />
                        <asp:BoundField DataField="CategoryId" HeaderText="Type" ReadOnly="true" />
                        <asp:BoundField DataField="StartDate" HeaderText="Start Date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="IssueDate" HeaderText="Issue Date" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="AutoKey" HeaderText="Autokey" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                        <asp:BoundField DataField="NumberOfDay" HeaderText="Day" />

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
