<%@ Control Language="C#" AutoEventWireup="true" CodeFile="6.ascx.cs" Inherits="Profile_edit_editu_1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div style="padding-left:15px; padding-right:15px;">
  
    <asp:Label ID="Label6" runat="server" Text="Website"></asp:Label>



&nbsp;<telerik:RadTextBox ID="web" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>

    <br />
    <asp:Label ID="Label7" runat="server" Text="Phone"></asp:Label>
    
    
    
    &nbsp;&nbsp;&nbsp;
    
    
    
    <telerik:RadTextBox ID="phone" runat="server"  Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>
   
    
   
   
   
    
   
    &nbsp;&nbsp;&nbsp;&nbsp;
   
    
   
   
   
    
   
    <telerik:RadTextBox ID="email" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Address"></asp:Label>
   
    
   
    &nbsp;<telerik:RadTextBox ID="add" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
     
  
<div style="float:right;">
<asp:Button ID="Button2" runat="server" Text="Change Contact Information"  
        CssClass="Submit" onclick="Button1_Click"/>
</div>
</div>