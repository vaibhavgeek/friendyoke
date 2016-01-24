<%@ Control Language="C#" AutoEventWireup="true" CodeFile="my-albums.ascx.cs" Inherits="Menu_Main_my_albums" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

 

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
 <table>
 <tr>
    
 <td valign="top" style="width:350px;">
 <center>
     <telerik:RadComboBox ID="albums" runat="server" DataTextField="Name" 
         DataValueField="ID" onselectedindexchanged="albums_SelectedIndexChanged" AutoPostBack="true" >
         
     </telerik:RadComboBox> </center>
     <asp:Repeater ID="Grid" runat="server" onitemcommand="Grid_ItemCommand" DataMember="ID">
     <ItemTemplate>
          
     <asp:LinkButton runat="server" ID="abs" CommandName="showpic" CausesValidation="false" >
     <telerik:RadBinaryImage runat="server" id="ph"  DataValue='<%#Eval("Photo") is DBNull ? null : Eval("Photo")%>' Height="80px" Width="80px" ResizeMode="Crop" />
    </asp:LinkButton>
   <asp:HiddenField runat="server" ID="phid"  Value='<%# DataBinder.Eval(Container.DataItem, "ID") %>' />

     </ItemTemplate>
     </asp:Repeater>
     

     

 </td>
  <td  style="border-left: 1px solid #BB3D00;"></td>
 <td  valign="top" style="width:450px;">
 <telerik:RadBinaryImage ID="fullimg" runat="server" />
 <asp:LinkButton runat="server" ID="del" Text="Delete" 
         onclick="abs_Click" Visible="false" ></asp:LinkButton>
 </td>
 </tr>
 </table>
 </telerik:RadAjaxPanel>	  
