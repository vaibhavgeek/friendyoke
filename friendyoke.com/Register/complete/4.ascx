<%@ Control Language="C#" AutoEventWireup="true" CodeFile="4.ascx.cs" Inherits="Profile_edit_editu_1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div style="padding-left:15px; padding-right:15px;">
  
    <asp:Label ID="Label6" runat="server" Text="Movies"></asp:Label>

&nbsp;&nbsp;&nbsp;

<telerik:RadTextBox ID="mov" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>

    <br />
    <asp:Label ID="Label7" runat="server" Text="Music"></asp:Label>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    <telerik:RadTextBox ID="music" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Books"></asp:Label>
   
    
   
    &nbsp;&nbsp;&nbsp;&nbsp;
   
    
   
    <telerik:RadTextBox ID="books" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Television"></asp:Label>
   
    
   
    <telerik:RadTextBox ID="pol" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
     <asp:Label ID="Label1" runat="server" Text="Sports"></asp:Label>
   
    
   
    &nbsp;&nbsp;&nbsp;&nbsp;
   
    
   
    <telerik:RadTextBox ID="sports" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
  
<div style="float:right;">
<asp:Button ID="Button2" runat="server" Text="Chnage Enterntainment and Intrests"  
        CssClass="Submit" onclick="Button1_Click"/>
</div>
</div>