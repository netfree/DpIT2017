<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="adaugare_articol.aspx.cs" Inherits="connect_to_ue.adaugare_articol" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="lbl_error" runat="server" Text=""></asp:Label>

    <h1>Add Article:</h1> <br />
    
    <div class="input-group">
        <span class="input-group-addon"><asp:Label ID="Label1" runat="server" Text="Title:" CssClass="txt" Width="70"></asp:Label></span>
        <textarea id="txt_title" runat="server" cols="100" rows="2"></textarea>
    </div>

    <br />

<<<<<<< HEAD
    <div class="input-group" >
        <span class="input-group-addon"><asp:Label ID="lbl_email" runat="server" Text="Content:" CssClass="txt" Width="70"></asp:Label></span>
        <textarea id="txt_content" runat="server" cols="100" rows="15"></textarea>
    </div>

    <br />
    <%--Check Channels: <br /> <asp:CheckBoxList ID="ckboxlist_channels" runat="server"></asp:CheckBoxList>
    <br />--%>
   
    <div class="row"> 
        <span class="label label-success">Post it!<asp:Button ID="btn_submit_art" runat="server" class="btn-lg" OnClick="btn_submit_art_Click" /></span>
=======
    Rezumat (maximum 255 characters):<textarea id="txt_rezumat" runat="server" cols="20" rows="5"></textarea>
    <br />

    Content:<textarea id="txt_content" runat="server" cols="100" rows="20"></textarea>
    <br />
>>>>>>> 728aa692acbba865b35844e5ca95173e668df65f

    </div>
</asp:Content>


