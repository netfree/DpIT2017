<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adaugare_articol.aspx.cs" Inherits="connect_to_ue.adaugare_articol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>

    <h1>Add Article:</h1> <br />
    
    Title:<textarea id="txt_title" runat="server" cols="20" rows="2"></textarea>
    <br />

    Rezumat (maximum 255 characters):<textarea id="txt_rezumat" runat="server" cols="20" rows="5"></textarea>
    <br />

    Content:<textarea id="txt_content" runat="server" cols="100" rows="20"></textarea>
    <br />

    <asp:Button ID="btn_submit_art" runat="server" Text="Button" OnClick="btn_submit_art_Click" />
</asp:Content>


