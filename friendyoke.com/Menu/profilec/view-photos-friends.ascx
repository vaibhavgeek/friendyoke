<%@ Control Language="C#" AutoEventWireup="true" CodeFile="view-photos-friends.ascx.cs" Inherits="Menu_profilec_view_photos_friends" %>
 <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
 
 <asp:Repeater ID="Grid" runat="server" DataMember="ID">
 <HeaderTemplate>
 <table>
 <tr>

 </HeaderTemplate>
   <ItemTemplate>
        <td>
   <div style="border-left-color:Gray; border-left-style:solid; border-bottom-width:medium; height:140px;">
    &nbsp;
     <telerik:RadBinaryImage runat="server" id="ph" style="width:140px !important;" DataValue='<%#Eval("Photo") is DBNull ? null : Eval("Photo")%>' Height="140px" Width="140px" ResizeMode="Crop" /> 
     &nbsp;&nbsp; </div> 
     </td>  
     </ItemTemplate>
     <FooterTemplate>
     </tr>
     </table>
     </FooterTemplate>
 </asp:Repeater>