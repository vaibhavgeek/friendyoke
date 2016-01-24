<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Status.ascx.cs" Inherits="Newsfeed_Status" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


 <asp:TextBox runat="server" style="-webkit-border-radius: 6px;" ID="maincontent" Height="75px" 
    TextMode="MultiLine" Width="500px"></asp:TextBox>  <br /> 
       <telerik:RadButton ID="postfeed" runat="server" Text="Post" Skin="Default" Width="80px" 
                         onclick="postfeed_Click">
       </telerik:RadButton>                   