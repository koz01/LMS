<%@ Page Title="RentBook" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RentBook.aspx.cs" Inherits="LibraryManagementSysteem.RentBook" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2  style="color:#3b5998;">Create Rent Book
    </h2>
    Member Name :
      <asp:TextBox ID="txtMemberName" runat="server" CssClass="TextBox"></asp:TextBox>

    <asp:ImageButton ID="btnNewMember" runat="server" ImageUrl="~\Images\user-group-icon.png" Width="30px" Height="30px" Style="position: relative; top: 20px" OnClick="btnNewMember_Click" />
    
    <asp:Label ID="category" Text="Category :" runat="server" style ="margin-left:20px;"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" Style="margin-left: 10px;" CssClass="TextBox"
        AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
    </asp:DropDownList>

    <br />

    Start Date :
    <asp:TextBox ID="txtSartDate" runat="server" Width="250px" CssClass="TextBox" Style="margin-left: 30px;" onFocus="this.blur()"></asp:TextBox>
    <asp:ImageButton ID="btnStartDate" runat="server" ImageUrl="~\Images\calendar.png" Width="30px" Height="30px" Style="position: relative; top: 20px" OnClick="btnStartDate_Click" />
    &emsp;
      Issue Date :
    <asp:TextBox ID="txtIssueDate" runat="server" CssClass="TextBox" onFocus="this.blur()"></asp:TextBox>
    <asp:ImageButton ID="btnIssueDate" runat="server" ImageUrl="~\Images\calendar.png" Width="30px" Height="30px" Style="position: relative; top: 20px" OnClick="btnIssueDate_Click" />

    <br />
    <br />

    <asp:Button ID="btnSave" runat="server" Text="Sumbit" OnClick="btnSave_Click" class="loginmodal-submit" Style="width:100px; background-color: #3b5998; margin-left: 20px;" />
    <asp:Button ID="btnAddBook" runat="server" Text="Add Book" OnClick="btnAddBook_Click" class="loginmodal-submit" Style="width:100px; background-color: #3b5998; margin-left: 20px;" />
    <br />
    <br />

    <hr />

    <asp:GridView ID="grdRentBookList" runat="server" CellPadding="4" ForeColor="#333333"
        GridLines="None" AutoGenerateColumns="false" HorizontalAlign="Left">

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

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtSartDate.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: true,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });

        });

        $(document).ready(function () {
            $("#<%=txtIssueDate.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%d/%m/%Y %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: true,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });

        });
    </script>

</asp:Content>

