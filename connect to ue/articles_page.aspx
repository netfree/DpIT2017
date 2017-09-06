<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="articles_page.aspx.cs" Inherits="connect_to_ue.articles_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="center">
            <div class="row">

                <%--<h1 style="margin-left: 120px" >Nume/titlu</h1>--%>
                <div class="col-xs-12">

                        <h1> <span class="label label-info">c<img class="img-circle" src="/assets/DOWNSIZED.png" width="30" height="30" alt="o">nnect to UE</span></h1>
    
                </div>

                    <br />

            </div>

            
       </div>

<div class="row" style="margin-top: 30px">

    <div class="col-xs-3">
        <asp:ListBox  ID="lb_my_channels" runat="server" OnSelectedIndexChanged="lb_my_channels_SelectedIndexChanged" ></asp:ListBox> <br />
        <asp:ListBox ID="lb_not_my_channels" runat="server" OnSelectedIndexChanged="lb_not_my_channels_SelectedIndexChanged"></asp:ListBox>

    </div>
    
    <div id ="ana" runat="server"></div>
    
     <div class="col-xs-9">
            <div class="panel panel-default panel-danger" ID="div_subscibe" runat="server">
              <div class="panel-heading">
                <h3 class="panel-title">Subscribe Here!</h3>
              </div>
              <div class="panel-body">
                Some link to make u subscribe to: <%= getPublicChannel() %> . <br />
                <asp:Button ID="btn_subscribe" runat="server" Text="Subscribe" OnClick="btn_subscribe_Click" />
              </div>
            </div>

    <asp:Repeater ID="rpt_list_articles" runat="server">
        <HeaderTemplate>
        
       
        </HeaderTemplate>

        <ItemTemplate>

            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title"><%#Eval("Titlu") %> by @<%#Eval("Autor") %></h3>
              </div>
              <div class="panel-body">
                <%#Eval("Rezumat") %> <br />
                <a href ="/vizualizare_articol?articol=<%#Eval("Id") %>"> Show More...</a>
              </div>
            </div>

     

        </ItemTemplate>

        <FooterTemplate>
            
        </FooterTemplate>

    </asp:Repeater>
</div>

    </div>

</asp:Content>

