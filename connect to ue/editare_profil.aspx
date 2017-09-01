<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="editare_profil.aspx.cs" Inherits="connect_to_ue.editare_profil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:CheckBoxList ID="checkboxlist_channels" runat="server"></asp:CheckBoxList>
    <asp:Button ID="btn_submit" runat="server" Text="Button" OnClick="btn_submit_Click" />
</asp:Content>
