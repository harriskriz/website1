<%@ Page Title="Log in Form" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Account_Login" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>
    
    <h2>Use a local account to log in</h2>
    <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" ID="LoginForm">
        <LayoutTemplate>
            <p class="validation-summary-errors">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
            <fieldset>
                <legend>Log in Form</legend>
                <ol>
                    <li>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="username">User name</asp:Label>
                        <asp:TextBox runat="server" ID="UserName" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName" CssClass="field-validation-error" ErrorMessage="The user name field is required." />
                    </li>
                    <li>
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="password">Password</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password" CssClass="field-validation-error" ErrorMessage="The password field is required." />
                    </li>
                </ol>
                <asp:Button ID="loginButton" runat="server" CommandName="LoginCommand" Text="Log in" OnCommand="ButtonOnClick"/>
            </fieldset>
        </LayoutTemplate>
    </asp:Login>

</asp:Content>