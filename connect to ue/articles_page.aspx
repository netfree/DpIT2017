<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="articles_page.aspx.cs" Inherits="connect_to_ue.articles_page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<asp:Repeater ID="Repeater1" runat="server">

    <%--<ItemTemplate>

         <div>

             <table>

                 <tr><td><%#Eval("Nume") %></td></tr>
              
             </table>

         </div>

     </ItemTemplate>    --%>       
    
    
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


</asp:Content>

