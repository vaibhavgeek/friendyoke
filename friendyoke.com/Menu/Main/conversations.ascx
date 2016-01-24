<%@ Control Language="C#" AutoEventWireup="true" CodeFile="conversations.ascx.cs" Inherits="Space_message" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
 <link href="Menu/Main/iPhone/bluecool.css" rel="stylesheet" type="text/css" />

    
         
    
        
<telerik:RadWindow ID="RadWindow1" runat="server" Modal="True" 
    OpenerElementID="nmessage" NavigateUrl="~/Menu/Main/Newsfeed/new-message.aspx">
</telerik:RadWindow>
        
        
 
 
            <center><a  id="nmessage"  style="padding-left:3px; padding-right:3px; text-decoration:none;" class="theusualtabs">new message</a></center>
            
            
            
        
     <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
   
 <table>
 <tr>
 <td style="width:370px;" valign="top">
   
         
     <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
         CellSpacing="0" GridLines="None" ShowHeader="false" 
         onneeddatasource="RadGrid1_NeedDataSource" EnableEmbeddedSkins="false" 
         onitemcommand="RadGrid1_ItemCommand" style="outline:none; border:none;" >
     <MasterTableView>
     <Columns>
     <telerik:GridTemplateColumn>
     <ItemTemplate>
     
     
      <asp:LinkButton runat="server" ID="lnk">
     <div class="trial">
     <div class="abc">
   
     <telerik:RadBinaryImage ResizeMode="Crop" DataValue='<%#aphoto(Container.DataItem)%>' ID="Image1" runat="server" Height="55px" 
                                         Width="55px" />
     
    <a style="text-transform:lowercase !important; ">   <%#name(Container.DataItem)%> </a> <br /><a class="info">  <%#message(Container.DataItem)%></a>

    
    

  </div> </div>
       </asp:LinkButton>
     <asp:Label ID="hid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>' style="display:none; visibility:hidden;" />
     </ItemTemplate>
     
     </telerik:GridTemplateColumn>
     
     </Columns>
     </MasterTableView>
     </telerik:RadGrid>
 </td>
  
 <td valign="top" style="width:450px;">
<asp:Label ID="ccid" runat="server" style="display:none; visibility:hidden;" />
 <asp:Panel runat="server" ID="messageloader"   >
 
 </asp:Panel>
  
    <telerik:RadTextBox ID="ptb" runat="server"  TextMode="MultiLine"
        EmptyMessage="Click to comment on the post.." Visible="false" CssClass="ptb" Height="35px" Width="400px" 
       >
                    </telerik:RadTextBox>
                    <asp:Button ID="send" runat="server" Text="send"  
        CssClass="commentpost" onclick="send_Click" Visible="false">
                        </asp:Button>
 </td>
 </tr>
 </table>
 	 
     </telerik:RadAjaxPanel>