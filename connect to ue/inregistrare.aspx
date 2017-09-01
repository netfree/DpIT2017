<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="inregistrare.aspx.cs" Inherits="connect_to_ue.inregistrare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="row">

            <%--<h1 style="margin-left: 120px" >Nume/titlu</h1>--%>
           
       <div class="col-xs-12">

                <h1> <span class="label label-info">c<img class="img-circle" src="/assets/DOWNSIZED.png" width="30" height="30" alt="o">nnect to UE</span></h1>
       </div>
     </div>

           <div class="row">
    <asp:Label ID="lbl_errors" runat="server" Text="" CssClass="alert alert-danger"></asp:Label>
    </div>

     <br/>

   <%-- <asp:Label ID="lbl_email" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>--%>

    <div class="row">
         <div class="input-group">
                            <span class="input-group-addon" >  <asp:Label ID="lbl_email" runat="server" Text="Email" Width="120"></asp:Label>  </span>
                            
                              <asp:TextBox ID="txt_email" runat="server" CssClass="input" placeholder="your_email@mail.com"></asp:TextBox>
                         </div>

    </div>

      <br />

    <%--<asp:Label ID="lbl_password" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txt_password" runat="server" placeholder="Min 6 characters"></asp:TextBox>--%>

    <div class="row">
        <div class="input-group">
                            <span class="input-group-addon"><asp:Label ID="lbl_password" runat="server" Text="Password" Width="120"></asp:Label></span>
                            
                              <asp:TextBox ID="txt_password" runat="server" CssClass="input" placeholder="min 6 char"></asp:TextBox>
         </div>
    </div>

     <br />

   <%-- <asp:Label ID="lbl_confirm_password" runat="server" Text="Confirm Password:"></asp:Label>
    <asp:TextBox ID="txt_confirm_password" runat="server" placeholder="Pls Confirm ur psw"></asp:TextBox>--%>

    <div class="row">
        <div class="input-group">
                            <span class="input-group-addon"><asp:Label ID="lbl_confirm_password" runat="server" Text="Confirm Password" Width="120"></asp:Label></span>
                            
                              <asp:TextBox ID="txt_confirm_password" runat="server" CssClass="input" placeholder="Pls Confirm ur psw" ></asp:TextBox>
        </div>
    </div>

     <br/>

    <div class="row">
        <asp:CheckBoxList ID="checkboxlist_channels" runat="server" RepeatColumns="2">
    

        </asp:CheckBoxList>

    </div>

     <br/>

    <div class="row">
        <asp:Button ID="btn_register" runat="server" Text="Register" OnClick="btn_register_Click" />
    </div>
</asp:Content>
