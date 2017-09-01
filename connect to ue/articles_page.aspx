<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="articles_page.aspx.cs" Inherits="connect_to_ue.articles_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="row" style="margin-top: 30px">

    <asp:ListBox CssClass="col-xs-3" ID="lb_my_channels" runat="server" OnSelectedIndexChanged="lb_my_channels_SelectedIndexChanged"></asp:ListBox>


    <asp:Repeater ID="rpt_list_articles" runat="server">
        <HeaderTemplate>
        
        <div class="col-xs-9">
        
        </HeaderTemplate>

        <ItemTemplate>

            <div class="panel panel-default">
              <div class="panel-heading">
                <h3 class="panel-title"><%#Eval("Titlu") %> by @<%#Eval("Autor") %></h3>
              </div>
              <div class="panel-body">
                <%#Eval("Continut") %>
              </div>
            </div>

     

        </ItemTemplate>

        <FooterTemplate>
            </div>
        </FooterTemplate>

    </asp:Repeater>

    </div>

</asp:Content>

