<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="abc.aspx.cs" Inherits="connect_to_ue.abc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" style="width: 800px;height:800px"></asp:TextBox>
    <ajaxToolkit:HtmlEditorExtender ID="HtmlEditorExtender1" runat="server" EnableSanitization ="false" TargetControlID="TextBox1" DisplaySourceTab="true" DisplayPreviewTab="true">
         <Toolbar> 
                <ajaxToolkit:Undo />
                <ajaxToolkit:Redo />
                <ajaxToolkit:Bold />
                <ajaxToolkit:Italic />
                <ajaxToolkit:Underline />
                <ajaxToolkit:StrikeThrough />
                <ajaxToolkit:Subscript />
                <ajaxToolkit:Superscript />
                <ajaxToolkit:JustifyLeft />
                <ajaxToolkit:JustifyCenter />
                <ajaxToolkit:JustifyRight />
                <ajaxToolkit:JustifyFull />
                <ajaxToolkit:InsertOrderedList />
                <ajaxToolkit:InsertUnorderedList />
                <ajaxToolkit:CreateLink />
                <ajaxToolkit:UnLink />
                <ajaxToolkit:RemoveFormat />
                <ajaxToolkit:SelectAll />
                <ajaxToolkit:UnSelect />
                <ajaxToolkit:Delete />
                <ajaxToolkit:Cut />
                <ajaxToolkit:Copy />
                <ajaxToolkit:Paste />
                <ajaxToolkit:BackgroundColorSelector />
                <ajaxToolkit:ForeColorSelector />
                <ajaxToolkit:FontNameSelector />
                <ajaxToolkit:FontSizeSelector />
                <ajaxToolkit:Indent />
                <ajaxToolkit:Outdent />
                <ajaxToolkit:InsertHorizontalRule />
                <ajaxToolkit:HorizontalSeparator />
                <ajaxToolkit:InsertImage />
            </Toolbar>

    </ajaxToolkit:HtmlEditorExtender>
</asp:Content>
