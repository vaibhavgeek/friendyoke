<%@ Control Language="C#" AutoEventWireup="true" CodeFile="10.ascx.cs" Inherits="Profile_edit_editu_1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<div style="padding-left:15px; padding-right:15px;">
  
<asp:Label ID="Label1" runat="server" Text="Name Of the Event"></asp:Label><br />
<telerik:RadTextBox ID="name" Runat="server" Font-Size="15px" Width="175px">
</telerik:RadTextBox><br />
<asp:Label ID="Label2" runat="server" Text="Describe the event?"></asp:Label>
    <br />
    
<telerik:RadTextBox ID="describe" Runat="server" Font-Size="15px" Width="285px" 
        Height="150px" TextMode="MultiLine" onkeyup="messageKeyUp();" MaxLength="500"  >
</telerik:RadTextBox><br />




</div>
