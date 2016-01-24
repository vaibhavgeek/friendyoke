<%@ Control Language="C#" AutoEventWireup="true" CodeFile="3.ascx.cs" Inherits="Profile_edit_editu_1" %>




<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div style="padding-left:15px; padding-right:15px;">
  
    <asp:Label ID="Label6" runat="server" Text="Religion"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<telerik:RadTextBox ID="rel" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>

    <br />
    <asp:Label ID="Label7" runat="server" Text="How u define life?"></asp:Label>
    
    <telerik:RadTextBox ID="life" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Quotes.."></asp:Label>
   
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <telerik:RadTextBox ID="quote" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="On Politics"></asp:Label>
   
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <telerik:RadTextBox ID="pol" runat="server" TextMode="MultiLine" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
  
<div style="float:right;">
<asp:Button ID="Button2" runat="server" Text="Change Philosphy"  
        CssClass="Submit" onclick="Button1_Click"/>
</div>
</div>




