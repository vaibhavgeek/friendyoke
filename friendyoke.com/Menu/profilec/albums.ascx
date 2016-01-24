<%@ Control Language="C#" AutoEventWireup="true" CodeFile="albums.ascx.cs" Debug="true" Inherits="Profile_profilec_Achievements" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

 <table>
 <tr>
    
 <td valign="top" style="width:340px;">
 <center>
     <telerik:RadComboBox ID="albums" runat="server" DataTextField="Name" 
         DataValueField="ID" onselectedindexchanged="albums_SelectedIndexChanged" AutoPostBack="true" >
         
     </telerik:RadComboBox> </center>
     <asp:Repeater ID="Grid" runat="server" onitemcommand="Grid_ItemCommand" DataMember="ID">
     <ItemTemplate>
           
     <asp:LinkButton runat="server" ID="abs" CommandName='<%#id(Container.DataItem)%>'>
     <telerik:RadBinaryImage runat="server" id="ph"  DataValue='<%#propics(Container.DataItem)%>' Height="80px" Width="80px" ResizeMode="Crop" />
    </asp:LinkButton>
   

     </ItemTemplate>
     </asp:Repeater>
     

     

 </td>
  <td  style="border-left: 1px solid #BB3D00;"></td>
 <td  valign="top" style="width:440px;">
 <telerik:RadBinaryImage ID="fullimg" runat="server" />
 
 </td>
 </tr>
 </table>
 
