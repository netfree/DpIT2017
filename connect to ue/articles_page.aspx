<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="articles_page.aspx.cs" Inherits="connect_to_ue.articles_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<asp:Repeater ID="Repeater1" runat="server">

     <HeaderTemplate>
              <table>
              <tr>
                 <th>Nume Canale</th>
              </tr>
          </HeaderTemplate>

          <ItemTemplate>
          <tr>
              <td>
                <asp:Label runat="server" ID="Label1" 
                    text='<%# Eval("Nume") %>' />
              </td>
          </tr>
          </ItemTemplate>


          <FooterTemplate>
              </table>
          </FooterTemplate>   
              
</asp:Repeater>


<<<<<<< HEAD
    <asp:ListBox ID="lb_my_channels" runat="server"></asp:ListBox>
=======
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
>>>>>>> f3a064615bb06db62e8a6a34c4b351866bff045d


</asp:Content>

