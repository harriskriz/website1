<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" enableEventValidation="false" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    <nav>
        <ul id="menu">
            <li><asp:Button ID="AddNewLoginButton" runat="server" CommandName="AddNewLoginCommand" Text="Add New Login" OnCommand="ButtonOnClick"/></li>
            <li>
                <asp:DropDownList ID="ReportTypes" runat="server" />
            </li>
            <li><asp:Button ID="ExportButton" runat="server" CommandName="ExportCommand" Text="Export" OnCommand="ButtonOnClick"/></li>
            <li><asp:Button ID="LogoutButton" runat="server" CommandName="LogoutCommand" Text="Logout" OnCommand="ButtonOnClick"/></li>
        </ul>
        <CR:CrystalReportViewer ID="ReportViewer" runat="server" AutoDataBind="true" />
    </nav>
    <asp:Repeater ID="users" runat="server">
        <HeaderTemplate>
            <table>
                <tr>
                    <th scope="col">Username</th>
                    <th scope="col">First Name</th>
                    <th scope="col">Last Name</th>
                    <th scope="col">Active</th>
                    <th scope="col">Last Modified By</th>
                    <th scope="col">Last Modified Date</th>
                    <th scope="col">Action</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="username" runat="server" Text='<%# Eval("username") %>' />
                </td>
                <td>
                    <asp:Label ID="firstName" runat="server" Text='<%# Eval("first_name") %>' />
                </td>
                <td>
                    <asp:Label ID="lastName" runat="server" Text='<%# Eval("last_name") %>' />
                </td>
                <td>
                    <asp:Label ID="active" runat="server" Text='<%# Eval("status_code") %>' />
                </td>
                <td>
                    <asp:Label ID="lastModifiedBy" runat="server" Text='<%# Eval("updated_by") %>' />
                </td>
                <td>
                    <asp:Label ID="lastModifiedDate" runat="server" Text='<%# Eval("updated_date") %>' />
                </td>
                <td>
                    <asp:Button runat="server" onCommand="ButtonOnClick" CommandName="EditCommand" Text="Edit" CommandArgument='<%#Eval("user_id")%>'/>
                </td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>