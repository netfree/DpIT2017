<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dashboard_admin.aspx.cs" Inherits="connect_to_ue.dashboard_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListBox ID="lb_my_articles" runat="server" OnSelectedIndexChanged="lb_my_articles_SelectedIndexChanged"></asp:ListBox>
    <br /><asp:LinkButton ID="linkbutton_add" runat="server" OnClick="linkbutton_add_Click">Or add a new article instead...</asp:LinkButton>
</asp:Content>
