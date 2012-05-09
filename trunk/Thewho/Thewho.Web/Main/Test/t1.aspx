<%@ Page Language="C#" MasterPageFile="~/Main/Site.Master" AutoEventWireup="true" CodeBehind="t1.aspx.cs" Inherits="Thewho.Web.Main.Test.t1" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1"  runat="server" Text="Button" 
        onclick="Button1_Click" />
    <br />
<b>Cache:</b><%= cacheStr %>

</asp:Content>
