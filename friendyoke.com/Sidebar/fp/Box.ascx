<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Box.ascx.cs" Inherits="Public_Profiles_Just_Get_Feeds" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">

        function OpenFileExplorerDialog(aid) {
            var wnd = $find("<%= ExplorerWindow.ClientID %>");
            wnd.setUrl("Photos/Viewer.aspx?determiner=" + aid);
            wnd.show();
            wnd.maximize();
        }
        </script>
        </telerik:RadScriptBlock>
        <telerik:RadWindow runat="server"  VisibleStatusbar="false"
         ID="ExplorerWindow" Modal="true" Behaviors="Maximize,Close,Move" 
    Title="Browse Photos Of Your Friendsss" Skin="WebBlue" ShowContentDuringLoad="true" InitialBehaviors="Maximize">
    </telerik:RadWindow>
    <table>
    <tr>
    <td>
    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="500px" 
            AllowPaging="True" GridLines="None" 
                     onneeddatasource="datasource" PageSize="10" BorderColor="White" 
                         
            >
                            
                                      <MasterTableView Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderStyle-CssClass="nfeedradgrid" HeaderText="" UniqueName="" SortExpression="NewsFeed" HeaderStyle-BackColor="White">
                 <ItemTemplate>
                 <table bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                 <tr>
                 <td valign="top" bordercolor="White" style="border-style: none; border-width: 0px; border-top-color: #FFFFFF">
                 
             
                                        <a href='Profile/profile.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                                        <telerik:RadBinaryImage ID="sompropic" style="margin-left:0px;" runat="server" CssClass="ppic" DataValue='<%#propics(Container.DataItem)%>' Height="70px" Width="70px" ResizeMode="Fit" />
                                        </a>
                                 
                 
                 
                 </td>
                <td valign="top" bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                
                 <%#albumcolor(Container.DataItem)%>

                
                 <div align="justify">
              <span style="font-size:11px;">  
               Posted  By <%# DataBinder.Eval(Container.DataItem, "UName") %>
               </span>
               <span style="font-size:11px; padding-left:60px;">
               Posted On: 
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
         
                    
                  
                  <a class="nfeed" style="display:<%#displayy(Container.DataItem)%>;"  href="javascript:OpenFileExplorerDialog('<%#det(Container.DataItem)%>')"><telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyte(Container.DataItem)%>'             AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/></a>
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
                    <PagerStyle Wrap="True"  PageSizeLabelText="New Feed Count:" />
                </telerik:RadGrid>
    </td>
    <td style="border-left: 1px solid #BB3D00;"></td>
    <td valign="top">
    Promoted People on friendyoke.com 
    <telerik:RadGrid ID="RadGrid2" Visible="false" runat="server" CellSpacing="0" GridLines="None" 
                AllowPaging="True" AutoGenerateColumns="False" 
              
                PageSize="2" HorizontalAlign="Center" VirtualItemCount="2" Skin="Office2007" 
                           Width="190px" 
                            FooterStyle-ForeColor="White" 
            >
                
                <MasterTableView TableLayout="Fixed">
                
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn  HeaderStyle-CssClass="nfeedradgrid" FilterControlAltText="Filter TemplateColumn column" 
                            UniqueName="TemplateColumn" >
                            <ItemTemplate>
                            
                           <table>
                          <tr>
                          
                          <td>
                           <%# DataBinder.Eval(Container.DataItem, "Name") %>
                          
                          </td>
                          
                          
                          </tr> 
                          <tr>
                          <td align="center">
                          <a href='Profile/profile.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                                        <telerik:RadBinaryImage ID="sompropic" style="margin-left:0px;" runat="server" CssClass="ppic" DataValue='<%# DataBinder.Eval(Container.DataItem, "Image") %>' Height="100px" Width="100px" ResizeMode="Fit" />
                                        </a>
                          </td>
                          
                          </tr>
                          <tr>
                          <td>
                          <telerik:RadButton runat="server" ID="click" Text="Follow Him"></telerik:RadButton>
                          </td>
                          </tr>
                           </table>
                       
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                            <PagerStyle Mode="NumericPages" PageButtonCount="3" />
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
                <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                </HeaderContextMenu>
            </telerik:RadGrid></td>
    </tr>
    
    </table>

