<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="editare_articol.aspx.cs" Inherits="connect_to_ue.editare_articol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<p>Te rog selecteaza canalele:</p> <br />

<asp:CheckBoxList ID="checkboxlist_channels" runat="server"></asp:CheckBoxList>

<br />

<asp:LinkButton ID="linkbutton_redirect" runat="server" OnClick="linkbutton_redirect_Click">Daca vrei sa modifici continutul, click aici</asp:LinkButton>

<br />
    Make it public?
<br />

<asp:CheckBox ID="ckbox_public" Text="Public" runat="server" /> 

<br />

<asp:Button ID="btn_submit" runat="server" Text="Salveaza modificarile" OnClick="btn_submit_Click" />

</asp:Content>
