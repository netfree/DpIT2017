<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logare.aspx.cs" Inherits="connect_to_ue.logare" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%--     <style type="text/css">
        .center {
    margin: auto;
    width: 40%;--%>



   <div class="center">
    
    <div class="row">

        <div class="row">
              <div class="col-xs-6"> </div>
                <div class="col-xs-6 col-xs-offset-0">
                    <asp:Label ID="lbl_Message" runat="server" CssClass="alert alert-danger"></asp:Label>
                </div>
        </div>

        <div class="col-xs-4"></div>

            <div class="col-xs-4 col-xs-offset-4">

        <div class="row">

            <%--<h1 style="margin-left: 120px" >Nume/titlu</h1>--%>
            <div class="col-xs-12">

                <h1> <span class="label label-info">c<img class="img-circle" src="/assets/DOWNSIZED.png" width="30" height="30" alt="o">nnect to UE</span></h1>

            </div>

            <br />

         </div>
       
         <div class="row">
            
               
              
                     <%--<asp:Label ID="lbl_email" runat="server" Text="E-mail" CssClass="txt"></asp:Label>--%>
                        <div class="input-group">
                            <span class="input-group-addon" ><asp:Label ID="lbl_email" runat="server" Text="Email" CssClass="txt" Width="70"></asp:Label></span>
                            
                              <asp:TextBox ID="txt_email" runat="server" CssClass="input" placeholder="your_email@mail.com" ></asp:TextBox>
                         </div>
                     

           <%-- <asp:RequiredFieldValidator ID="rfv_email" runat="server" ErrorMessage="E-mail is required" ControlToValidate="txt_email" CssClass="error_message"></asp:RequiredFieldValidator></td>--%>
              
           </div>        
         <div class="row">

             
                   <br />

       
<<<<<<< HEAD
           <%--<asp:Label ID="lbl_password" runat="server" Text="Password" CssClass="txt"></asp:Label>--%>
                 <div class="input-group">
                            <span class="input-group-addon"><asp:Label ID="lbl_password" runat="server" Text="Password" CssClass="txt" Width="70" ></asp:Label></span>
                            
                              <asp:TextBox ID="txt_password" runat="server" CssClass="input" placeholder="min 6 char"></asp:TextBox>
                         </div>

            <%--<asp:TextBox ID="txt_password" runat="server" placeholder="min 6 char" CssClass="input"></asp:TextBox>--%>  
                       
=======
                <tr>
                    <td>            <asp:Label ID="lbl_password" runat="server" Text="Password" CssClass="txt"></asp:Label> </td>
            <td><asp:TextBox ID="txt_password" TextMode="Password" runat="server" CssClass="input"></asp:TextBox>            
>>>>>>> 677593ab703ae2c611298cab1967ace37c1b330e
            <%--<asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="txt_password" ErrorMessage="Password is required" CssClass="error_message"></asp:RequiredFieldValidator>--%>

               
         </div>
           
                <br />
            
            <div class="row">
                <div class="checkbox">
                <asp:CheckBox ID="checkbox_remember" runat="server" CssClass="txt"  />
                    Remember me

            </div>
    </div>
            <br />

            <div class="row">
                <div class="button">
                    <asp:Button ID="btn_login" runat="server" Text="Log in" BorderColor="Aqua" OnClick="btn_login_Click" CssClass="btn" />
                </div>
            </div>
                <br />

            <div class="row">
                <asp:LinkButton ID="link_password" runat="server" CssClass="link">Ti-ai uitat parola?</asp:LinkButton>
            </div>

           

                <div class="row">
                    <asp:LinkButton ID="link_account" runat="server"  OnClick="link_account_Click" CssClass="link">Nu ai cont? Fa-ti unul acum!</asp:LinkButton>
                </div>
       </div>
    </div>
            
</div>

    </asp:Content>
