<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adaugare_articol.aspx.cs" Inherits="connect_to_ue.adaugare_articol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Add Article:</h1> <br />
    
    Content:<textarea id="TextArea1" cols="20" rows="2"></textarea>
    <br />
    Check Channels: <br /> <asp:CheckBoxList ID="ckboxlist_channels" runat="server"></asp:CheckBoxList>
    <br />
    Add author: <input id="input_box" type="text" />
    <br />
    <asp:Button ID="btn_submit_art" runat="server" Text="Button" OnClick="btn_submit_art_Click" />
</asp:Content>


