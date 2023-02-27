<%@ Page Title="New Login" Language="C#" AutoEventWireup="true" CodeFile="NewLogin.aspx.cs" Inherits="Account_NewLogin" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
    </hgroup>

    <asp:Login runat="server" ViewStateMode="Disabled" RenderOuterTable="false" ID="NewLoginForm">
        <LayoutTemplate>
            <p class="validation-summary-errors">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
            <fieldset>
                <legend>New Login Form</legend>
                <ol>
                    <li>
                        <asp:Label ID="UsernameLabel" runat="server" AssociatedControlID="username">Username</asp:Label>
                        <asp:TextBox runat="server" ID="username" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                            CssClass="field-validation-error" ErrorMessage="Required"/>
                    </li>
                    <li>
                        <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="firstName">First Name</asp:Label>
                        <asp:TextBox runat="server" ID="firstName" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="firstName"
                            CssClass="field-validation-error" ErrorMessage="Required" />
                    </li>
                    <li>
                        <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="lastName">Last Name</asp:Label>
                        <asp:TextBox runat="server" ID="lastName" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lastName"
                            CssClass="field-validation-error" ErrorMessage="Required" />
                    </li>
                    <li>
                        <asp:Label ID="ActiveLabel" runat="server" AssociatedControlID="active">Active</asp:Label>
                        <asp:CheckBox runat="server" ID="active"/>
                    </li>
                    <li>
                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="password">Password</asp:Label>
                        <asp:TextBox runat="server" ID="Password" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password"
                            CssClass="field-validation-error" ErrorMessage="Required" />
                    </li>
                    <li>
                        <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="confirmPassword">Confirm password</asp:Label>
                        <asp:TextBox runat="server" ID="confirmPassword" TextMode="Password" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="confirmPassword"
                                CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Required" />
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="password" ControlToValidate="confirmPassword"
                                CssClass="field-validation-error" Display="Dynamic" ErrorMessage="Password and confirmation password do not match" />
                    </li>
                </ol>
                <asp:Button ID="SaveButton" runat="server" CommandName="SaveCommand" Text="Save" OnCommand="ButtonOnClick"/>
                <asp:Button ID="CancelButton" runat="server" CommandName="CancelCommand" Text="Cancel" OnCommand="ButtonOnClick"/>
            </fieldset>
        </LayoutTemplate>
    </asp:Login>
</asp:Content>
