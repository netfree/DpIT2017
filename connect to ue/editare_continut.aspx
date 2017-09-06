<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="editare_continut.aspx.cs" Inherits="connect_to_ue.editare_continut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>

    <h1>Add Article:</h1> <br />
    
    Title:<textarea id="txt_title" runat="server" cols="20" rows="1"></textarea>
    <br />

    Rezumat:<textarea id="txt_rezumat" runat="server" cols="20" rows="1"></textarea>
    <br />

    Content:<textarea id="txt_content" runat="server" cols="100" rows="20"></textarea>
    <br />

    <asp:Button ID="btn_submit_art" runat="server" Text="Button" OnClick="btn_submit_art_Click" Height="64px" Width="160px" />
</asp:Content>


