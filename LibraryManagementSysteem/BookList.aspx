<%@ Page Title="BookList" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="LibraryManagementSysteem.BookList" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="style/style.css" rel="stylesheet" type="text/css"/>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

    <div style="margin-left: auto; margin-right: auto; width: 100%">
        <asp:GridView ID="grdBookList" runat="server" ForeColor="#333333" OnRowDataBound="OnRowDataBound"
            GridLines="None" AutoGenerateColumns="False" HorizontalAlign="Center" OnSelectedIndexChanged="OnSelectedIndexChanged">
            <Columns>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chk" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="BookID" HeaderText="Serial" />
                <asp:BoundField DataField="BookName" HeaderText="Name" />
                <asp:BoundField DataField="Author" HeaderText="Author" />
                <asp:BoundField DataField="Category" HeaderText="Type" ReadOnly="true" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN No" />
                <asp:BoundField DataField="AutoKey" HeaderText="Autokey" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol">

                    <HeaderStyle CssClass="hiddencol"></HeaderStyle>

                    <ItemStyle CssClass="hiddencol"></ItemStyle>
                </asp:BoundField>

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
    <div>
        <asp:Button ID="btnSubmit" runat="server" class="loginmodal-submit" Style="width: 100px; background-color: #3b5998; margin-left: 60px;" 
            Text="Submit" OnClick="btnSubmit_Click" />
    </div>

    <br />
    <br />
</asp:Content>
