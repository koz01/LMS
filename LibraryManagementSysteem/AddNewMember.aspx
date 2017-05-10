<%@ Page Title="AddNewMember" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddNewMember.aspx.cs" Inherits="LibraryManagementSysteem.AddNewMember" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="style/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2 style="color: #3b5998;">Create New Member
    </h2>
    Member Name :
    <asp:TextBox ID="txtSrchFirstName" runat="server" CssClass="TextBox"></asp:TextBox>
    &emsp;
    City :
    <asp:TextBox ID="txtSrchCity" runat="server" CssClass="TextBox"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" class="loginmodal-submit" Style="width: 100px; background-color: #3b5998;" />
    <br />
    <br />
    Select Member :
    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="TextBox"
        AutoPostBack="True" OnSelectedIndexChanged="ddlEmployee_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <hr />

    <div style="width: 100%;">
        <div style="float: left; width: 50%;">

            Registration ID :
            <asp:TextBox ID="txtMemberId" runat="server" CssClass="TextBox" onFocus="this.blur()"></asp:TextBox>

            <br />

            User Role :
            <asp:DropDownList ID="ddlUserRole" OnSelectedIndexChanged="ddlUserRole_SelectedIndexChanged" Style="margin-left: 35px;
                            margin-top:5px;" runat="server" CssClass="TextBox" AutoPostBack="True">
            </asp:DropDownList>
            <br />

            Member Name :
            <asp:TextBox ID="txtMemberName" runat="server" CssClass="TextBox" style="margin-top:10px;"></asp:TextBox>
            <br />

           Password :
            <asp:TextBox ID="txtPassword" runat="server" CssClass="TextBox" Style="width: 255px; margin-left:35px; height: 35px;" TextMode="Password"></asp:TextBox>
            Active
            <asp:CheckBox ID="chkActive" runat="server" Style="vertical-align: middle" />
            <br />

            <asp:Button ID="btnSave" runat="server" Text="Sumbit" OnClick="btnSave_Click" class="loginmodal-submit" Style="width: 100px; background-color: #3b5998;" />
            <asp:Button ID="btnDelete" runat="server" Text="Remove" OnClick="btnDelete_Click" class="loginmodal-submit" Style="width: 100px; background-color: #3b5998;" />
            <br />
            <hr />
            <div style="float: left; width:900px;">
                <asp:GridView ID="GridView1" runat="server" CellPadding="6" ForeColor="#333333"
                     style="margin-left: 1px;"
                    GridLines="None" AutoGenerateColumns="false" HorizontalAlign="Center">

                    <Columns>
                        <asp:BoundField DataField="MemberID" HeaderText="Member ID" />
                        <asp:BoundField DataField="MemberName" HeaderText="Name" />
                         <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="City" HeaderText="City" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="Phone" HeaderText="Phone" />

                    </Columns>

                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Left" />
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

            Email :
            <asp:TextBox ID="txtEmail" TextMode="Email" Style="height: 40px; margin-left:10px;" runat="server" CssClass="TextBox"></asp:TextBox>
            <br />

            Phone :
            <asp:TextBox ID="txtPhone" runat="server" style="margin-left:5px;" CssClass="TextBox"></asp:TextBox>
            <br />

            City :
            <asp:TextBox ID="txtCity" runat="server" style="margin-left:20px;" CssClass="TextBox"></asp:TextBox>
            <br />
            Address : <asp:TextBox ID="txtAddress" Style="height: 50px;" runat="server" CssClass="TextBox"></asp:TextBox>
            <br />

        </div>

    </div>

</asp:Content>

