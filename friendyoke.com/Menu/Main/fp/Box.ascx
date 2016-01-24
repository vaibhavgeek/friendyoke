<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Box.ascx.cs" Inherits="fy.Public_Profiles_Just_Get_Feeds" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/Menu/Main/Newsfeed/abt.ascx" TagName="about" TagPrefix="uc2" %>


<telerik:RadToolTipManager ID="RadToolTipManager1"  OffsetY="-1" HideEvent="LeaveToolTip"
		Width="393" Height="570" ShowEvent="OnMouseOver" Animation="Fade"  runat="server" ShowCallout="false" ManualCloseButtonText="Click to Close" VisibleOnPageLoad="false" EnableShadow="true" OnAjaxUpdate="OnAjaxUpdate" RelativeTo="BrowserWindow"
		Position="BottomRight">
	</telerik:RadToolTipManager>


   


   

    
<div style="padding-left:2px;">


    <table>
    <tr>
    <td style="width:400px !important; ">
    
     
    
     

      
        
        <div class="sidemeyaaarright">
         
         <h2><asp:Label runat="server" ID="noone"></asp:Label></h2>
         </div>
    
                         
                
                               
                 <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="400px" 
            AllowPaging="True" GridLines="None" 
                     onneeddatasource="datasource" PageSize="20" BorderColor="White" 
            onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                         
        >
                            
                                      <MasterTableView DataKeyNames="NID" Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderStyle-CssClass="nfeedradgrid" HeaderText="" UniqueName="" SortExpression="NewsFeed" HeaderStyle-BackColor="White">
                 <ItemTemplate>
                 <table bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                 <tr>
                 <td valign="top" bordercolor="White" style="border-style: none; border-width: 0px; border-top-color: #FFFFFF">
                 
             
                                        <a href='Profile/profile.aspx?Id=<%# DataBinder.Eval(Container.DataItem, "ID") %>'>
                                        <telerik:RadBinaryImage ID="sompropic" CssClass="magea" style="margin-left:0px;" runat="server"  DataValue='<%#propics(Container.DataItem)%>' Height="65px" Width="55px" ResizeMode="Crop" />
                                        </a>
                                 
                 
                 
                 </td>
                <td valign="top" bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                
                 <%#albumcolor(Container.DataItem)%>

                
                 <div align="justify">
              <span style="font-size:11px;">  
               Posted  By <%# DataBinder.Eval(Container.DataItem, "Name") %>
               </span>
               <span style="font-size:11px; padding-left:55px;">
             
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
         
                    
                  
              
                  <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyte(Container.DataItem)%>'             AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/></a>
                     <%#br(Container.DataItem)%>
            <span style="color:Black;text-decoration:none; font-size:13px;">     <%#message(Container.DataItem)%>   </span>

             <br />
 <asp:Label runat="server" ID="itemid" style="visibility:hidden;" Text='<%# DataBinder.Eval(Container.DataItem, "NID") %>'></asp:Label>
  
  <asp:Label runat="server" ID="hell" style="visibility:hidden;" Text='<%#whatthehellthisis(Container.DataItem)%>'></asp:Label>
                          <br />
                           <div style="font-size:11px;">
                               <asp:LinkButton ID="abt" runat="server" CssClass="someclasslink" Text="expand"></asp:LinkButton>
                        
                          </div>
                           </div>
                              
                             
                     
                    
                  
                          
                                  
               
                
                </td> 
                 
                 
                 </tr>
                 
                 </table>
                            
                           
                  </ItemTemplate>
                  
                </telerik:GridTemplateColumn>
                </Columns></MasterTableView>
                    <PagerStyle Wrap="True"  Mode="Slider" PageSizeLabelText="New Feed Count:" />
                </telerik:RadGrid>
    
    </td>
    <td style="border-left: 1px solid #BB3D00;"></td>
    <td valign="top" style="width:400px !important; ">
    
    <div class="fb-send" data-href="http://www.vaibhavgeek.blogspot.com/" data-font="verdana"></div>
    
        
    
   

    

   
    
    
    
    
    </td>
    
    </tr>
    </table>

    
        
        
        </div>
