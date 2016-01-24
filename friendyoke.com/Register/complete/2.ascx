<%@ Control Language="C#" AutoEventWireup="true" Debug="true" CodeFile="2.ascx.cs" Inherits="Profile_edit_editu_1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<div style="padding-left:15px; padding-right:15px;">
  
    <asp:Label ID="Label1" runat="server" Text="School"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<telerik:RadTextBox ID="school" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>

    <br />
    <asp:Label ID="Label2" runat="server" Text="College"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <telerik:RadTextBox ID="col" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Degree"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <telerik:RadTextBox ID="deg" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Company"></asp:Label>
    &nbsp;&nbsp;
    <telerik:RadTextBox ID="company" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Designation"></asp:Label>
<telerik:RadTextBox ID="des" runat="server" Font-Size="15px" Width="175px"></telerik:RadTextBox><br />
<div style="float:right;">
<asp:Button ID="Button1" runat="server" Text="Change Education and Work"  
        CssClass="Submit" onclick="Button1_Click"/>
</div>
</div>


