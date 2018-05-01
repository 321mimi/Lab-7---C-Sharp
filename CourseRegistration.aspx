<%@ Page Title="Algonquin College Course Registration" Language="C#" AutoEventWireup="true" CodeFile="CourseRegistration.aspx.cs" Inherits="CourseRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%: Title %></title>
    <link rel="stylesheet" href="/App_Themes/SiteStyles.css"/>
</head>
<body>
    <h1><%: Title %></h1>
    <form id="form1" runat="server" Visible="True">
        Student Name: 
        <asp:TextBox ID="name" runat="server" CssClass="input"></asp:TextBox>

        <asp:RadioButtonList ID="studentType" runat="server" RepeatLayout="Flow"  RepeatDirection="Horizontal">
            <asp:ListItem Value="Full Time" Selected="True"></asp:ListItem>
            <asp:ListItem Value="Part Time"></asp:ListItem>
            <asp:ListItem Value="Co-op"></asp:ListItem>
        </asp:RadioButtonList>

        <p>Following courses are currently available for registration</p>
        <asp:Label ID="error" runat="server" Visible="False" CssClass="error"></asp:Label>
        <asp:CheckBoxList ID="chklst" runat="server" />
        <asp:Button ID="submit" runat="server" CssClass="button" Text="Submit" OnClick="submit_Click" />
    </form>
    <asp:Label ID="studentName" runat="server"></asp:Label>
    <asp:Label ID="studentStatus" runat="server"></asp:Label>
    <asp:Table ID="table" CssClass="table" runat="server" />
</body>
</html>
