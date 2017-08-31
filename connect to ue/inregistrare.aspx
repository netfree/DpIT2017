<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inregistrare.aspx.cs" Inherits="connect_to_ue.inregistrare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <asp:Label ID="lbl_errors" runat="server" Text=""></asp:Label>
    
    <asp:Label ID="lbl_email" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lbl_password" runat="server" Text="Password:" ></asp:Label>
    <asp:TextBox ID="txt_password" runat="server" TextMode="Password"></asp:TextBox>

     <br />
    <asp:Label ID="lbl_confirm_password" runat="server" Text="Confirm Password:"></asp:Label>
    <asp:TextBox ID="txt_confirm_password" runat="server" TextMode="Password"></asp:TextBox>

    <asp:CheckBoxList ID="checkboxlist_channels" runat="server" RepeatColumns="2">


    </asp:CheckBoxList>

    <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click" />
    
</asp:Content>
