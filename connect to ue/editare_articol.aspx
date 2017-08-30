<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="editare_articol.aspx.cs" Inherits="connect_to_ue.editare_articol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<asp:CheckBoxList ID="checkboxlist_channels" runat="server"></asp:CheckBoxList>

<asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click" />

</asp:Content>
