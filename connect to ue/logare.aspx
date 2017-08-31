<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logare.aspx.cs" Inherits="connect_to_ue.logare" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%--     <style type="text/css">
        .center {
    margin: auto;
    width: 40%;--%>





    <div class="center">
        <asp:Label ID="lbl_Message" runat="server" CssClass="error_message"></asp:Label>

        <div >
            <h1 style="margin-left: 120px" >Nume/titlu</h1>
            <table>
                <tr>
                    <td> <asp:Label ID="lbl_email" runat="server" Text="E-mail" CssClass="txt"></asp:Label></td>
                    <td> <asp:TextBox ID="txt_email" runat="server" CssClass="input"></asp:TextBox>
           <%-- <asp:RequiredFieldValidator ID="rfv_email" runat="server" ErrorMessage="E-mail is required" ControlToValidate="txt_email" CssClass="error_message"></asp:RequiredFieldValidator></td>--%>
                </tr>
         
           
            
       
                <tr>
                    <td>            <asp:Label ID="lbl_password" runat="server" Text="Password" CssClass="txt"></asp:Label> </td>
            <td><asp:TextBox ID="txt_password" TextMode="Password" runat="server" CssClass="input"></asp:TextBox>            
            <%--<asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="txt_password" ErrorMessage="Password is required" CssClass="error_message"></asp:RequiredFieldValidator>--%>
            </td>
                    </tr>
                </table>
           
            

            <asp:CheckBox ID="checkbox_remember" runat="server" Text="Remember me" CssClass="txt"  />
        </div>
    
            <br />


            <asp:Button ID="btn_login" runat="server" Text="Connect to U.E." OnClick="btn_login_Click" CssClass="btn" />
                <br />
            <asp:LinkButton ID="link_password" runat="server" CssClass="link">Ti-ai uitat parola?</asp:LinkButton>
        
            <br />

            <asp:LinkButton ID="link_account" runat="server"  OnClick="link_account_Click" CssClass="link">Nu ai cont? Fa-ti unul acum!</asp:LinkButton>
</div>
            


    </asp:Content>
