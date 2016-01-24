<%@ Control Language="C#" AutoEventWireup="true" CodeFile="videog.ascx.cs" Inherits="Ement_videog" %>
 <%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
            <div style="padding-left:15px">  
    <asp:TextBox ID="TextBox1" runat="server" Width="611px"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" CssClass="Submit" onclick="Button1_Click" Text="Search" />
    
   

         
        
            <table style="width:100%;">
                <tr>
                    <td valign="top"><iframe  src="http://www.youtube.com/embed/<%=YouTubeMovieID%>" style="height: 360px; width: 500px" 
              >
                </iframe>
                        
                    </td>
                    <td style="border-left: 1px solid #BB3D00;">
                 
                     
                 </td>
                
                    <td>
                     
            <telerik:RadGrid ID="RadGrid1" runat="server" CellSpacing="0" GridLines="None" 
                AllowPaging="True" AutoGenerateColumns="False" 
                onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                PageSize="2" HorizontalAlign="Center" VirtualItemCount="2" Skin="Hay" 
                            onpageindexchanged="RadGrid1_PageIndexChanged" Width="190px" 
                            FooterStyle-ForeColor="White">
                
                <MasterTableView TableLayout="Fixed">
                
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px" />
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px" />
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                            UniqueName="TemplateColumn" HeaderText="Watch and Share Videos">
                            <ItemTemplate>
                            
                           
                       <asp:Button ID="btnShowVideo" runat="server" Text="Watch Video" />
                            
                            <br>
                            <strong>
                                <asp:Literal ID="Title" runat="server"></asp:Literal></strong>
                            
                            
                            <br />
                         
                            
                            Duration :<asp:Literal ID="Duration" runat="server"></asp:Literal>
                            <br />
                            <br />
                        
                        <img style="width:170px; height:150px;" src="http://img.youtube.com/vi/<%# DataBinder.Eval(Container.DataItem,"VideoID")%>/0.jpg" />
                        
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
            </telerik:RadGrid>
                          
                       
                 
            
            
                </td>
                   
                </tr>
                
            </table>
         
         </div>