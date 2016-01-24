<%@ Control Language="C#" AutoEventWireup="true" Debug="true" CodeFile="5.ascx.cs" Inherits="Profile_edit_editu_1" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div style="padding-left:15px; padding-right:15px;">
  
    <asp:Label ID="Label6" runat="server" Text="Your Laurels.."></asp:Label>

    <br />

<asp:TextBox ID="achieve" runat="server" TextMode="MultiLine" Height="158px" 
        Width="459px" Font-Size="15px"></asp:TextBox>

    <br />
    <div style="float:right;">
<asp:Button ID="Button2" runat="server" Text="Change Achievements"  
        CssClass="Submit" onclick="Button1_Click"/>
</div>
    </div>