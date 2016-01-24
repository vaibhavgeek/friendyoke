<%@ Control Language="C#" AutoEventWireup="true" CodeFile="recent-posts.ascx.cs" Inherits="fy.Menu_profilec_recent_posts" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>




<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="750px" 
            AllowPaging="True" GridLines="None" BorderStyle="None" 
                     onneeddatasource="datasource" PageSize="10" BorderColor="White" 
            onitemcommand="RadGrid1_ItemCommand"
                         
        >
                            
                                      <MasterTableView DataKeyNames="NID" Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderStyle-CssClass="nfeedradgrid" HeaderText="" UniqueName="" SortExpression="NewsFeed" HeaderStyle-BackColor="White">
                 <ItemTemplate>
                 <table  style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                 <tr>
                 <td valign="top" style="border-style: none; border-width: 0px; border-top-color: #FFFFFF">
                 
             
                                        <a href='Profile/profile.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                                        <telerik:RadBinaryImage ID="sompropic" CssClass="magea" style="margin-left:0px;" runat="server"  DataValue='<%#propics(Container.DataItem)%>' Height="65px" Width="55px" ResizeMode="Crop" />
                                        </a>
                                 
                 
                 
                 </td>
                <td valign="top" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                
                 <%#albumcolor(Container.DataItem)%>

                
                 <div align="justify">
              <span style="font-size:11px;">  
               Posted  By <%# DataBinder.Eval(Container.DataItem, "Name") %>
               </span>
               <span style="font-size:11px; float:right; text-align:right; width:450px;">
             
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
         
                    
                  
              
                  <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyte(Container.DataItem)%>'             AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/></a>
                     <%#br(Container.DataItem)%>
            <span style="color:Black;text-decoration:none; font-size:13px;">     <%#message(Container.DataItem)%>   </span>

            
  <br /><asp:Label runat="server" ID="itemid" style="visibility:hidden;" Text='<%# DataBinder.Eval(Container.DataItem, "NID") %>'></asp:Label>
  
  <asp:Label runat="server" ID="hell" style="visibility:hidden;" Text='<%#whatthehellthisis(Container.DataItem)%>'></asp:Label>
                          <br />
                           
                           </div>
                              
                             
                     
                    
                  
                          
                                  
               
                
                </td> 
                 
                 
                 </tr>
                 
                 </table>
                            
                           
                  </ItemTemplate>
                  
                </telerik:GridTemplateColumn>
                </Columns></MasterTableView>
                    <PagerStyle Wrap="True"  Mode="Slider" PageSizeLabelText="New Feed Count:" />
                </telerik:RadGrid>