<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="articles_page.aspx.cs" Inherits="connect_to_ue.articles_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <asp:ListBox ID="lb_my_channels" runat="server" CssClass="list-group" OnSelectedIndexChanged="lb_my_channels_SelectedIndexChanged"></asp:ListBox>


    <asp:Label ID="lbl_msg" runat="server" Text="Nothing Yet."></asp:Label>
    <br />

<asp:Repeater ID="rpt_list_articles" runat="server">
    <HeaderTemplate>
        <table>
            <tr><th>Here we list all articles:</th></tr>
        
    </HeaderTemplate>

    <ItemTemplate>
        <tr>
            <td>Titlu: <%#Eval("Titlu") %></td>
        </tr>
        <tr>
            <td>Continut: <%#Eval("Continut") %></td>
        </tr>
        <tr>
            <td>Autor: <%#Eval("Autor") %></td>
        </tr>

    </ItemTemplate>

    <FooterTemplate>
        </table>
    </FooterTemplate>

</asp:Repeater>


</asp:Content>

