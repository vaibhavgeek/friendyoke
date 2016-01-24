<%@ Control Language="C#" AutoEventWireup="true" CodeFile="8.ascx.cs" Inherits="Profile_edit_editu_1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div style="padding-left:15px; padding-right:15px;">
  
    <asp:Label ID="Label1" runat="server" Text="Facebook"></asp:Label>

&nbsp;&nbsp;

<telerik:RadTextBox ID="fb" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>

    <br />
    <asp:Label ID="Label2" runat="server" Text="Twitter"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <telerik:RadTextBox ID="twit" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Google Plus"></asp:Label>
   
    <telerik:RadTextBox ID="plus" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Linked In"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;
    
    <telerik:RadTextBox ID="lin" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
   
<div style="float:right;">
<asp:Button ID="Button1" runat="server" Text="Change Social Networks"  
        CssClass="Submit" onclick="Button1_Click"/>
</div>
</div>