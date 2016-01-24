<%@ Control Language="C#" AutoEventWireup="true" CodeFile="profile.ascx.cs" Inherits="fy.Design_pro" %>
<%@ Register Src="~/Menu/Main/Newsfeed/abt.ascx" TagName="about" TagPrefix="uc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
 <script type="text/javascript" src="lib/jquery/jquery.js"></script>
    <script type="text/javascript">


        function goToByScroll(id) {
            $('html,body').animate({ scrollTop: $("#" + id).offset().top }, 'slow');
        }
       
		</script>
<asp:Panel runat="server" Width="1000px" BackColor="White" ID="Panel1">
 <div style="padding-left:10px;">

  <table>
  <tr>
  
  <td style="width:790px;">
  <telerik:RadBinaryImage runat="server" ID="propic"  Width="150px" Height="150px" CssClass="magea"  AutoAdjustImageControlSize="true" ResizeMode="Crop" />
 

 <div class="som">
  
	hiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii iiiiiiiiiiiiiii iiiihi iiiiiiiiiiiiiiiiiiiiiiiii iiiiiiiiiiiiii iiiiiiiiiiii hi iiiiiiiiiiiiiiiiiiiiiii
	<div  class="connecta">
    vaibhavgeek.blogspot.in<br />
    facebook/vaibhavgeek <br />
    twitter.com/vaibhavgeek
    </div>

  </div>

 <div  style="width:390px; float:right">
    <h3>Vaibhav Maheswhari</h3>
   <div class="abcd">
   
  
   dob &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:  <asp:Label ID="dob" runat="server"></asp:Label> <br />
     gender :  <asp:Label ID="gen" runat="server"></asp:Label> <br />
     lookin for :  <asp:Label ID="born" runat="server"></asp:Label><br />
    works @: <asp:Label ID="Label1" runat="server"></asp:Label><br />
   </div></div>
  
  </td>
  <td style="border-left: 1px solid #BB3D00;"></td>
  <td>
  <asp:Button ID="but1" runat="server" CssClass="twittertypebut" Width="180px" Text="edit profile" />
  <br /><br />
      <asp:Button ID="but2" runat="server" CssClass="twittertypebutp2" Width="180px" Text="change profile photo" />
      <br /><br />
      <asp:Button ID="but3" runat="server"  CssClass="twittertypebutp2" Width="180px" Text="privacy settings" />
     
  </td>
  </tr>
      
  </table>

 </div>

  
            <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="White" Enabled="True" Radius="15" TargetControlID="Panel1"></asp:RoundedCornersExtender>
    

 </asp:Panel><br />
 <asp:Panel runat="server" Width="1000px" BackColor="White" ID="Panel2">
 <div style="padding-left:10px;">
  <table>
  <tr>
  
  <td style="width:790px;">


  <telerik:RadToolTipManager ID="RadToolTipManager1"  OffsetY="-1" HideEvent="LeaveToolTip"
		Width="393" Height="570" ShowEvent="OnMouseOver" Animation="Fade"  runat="server" ShowCallout="false" ManualCloseButtonText="Click to Close" VisibleOnPageLoad="false" EnableShadow="true" OnAjaxUpdate="OnAjaxUpdate" RelativeTo="BrowserWindow"
		Position="BottomRight">
	</telerik:RadToolTipManager>
  <h2 class="mainheader">recent posts</h2>

  <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="400px" 
            AllowPaging="True" GridLines="None" BorderStyle="None" 
                     onneeddatasource="datasource" PageSize="20" BorderColor="White" 
            onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                         
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
               <span style="font-size:11px; padding-left:55px;">
             
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
         
                    
                  
              
                  <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyte(Container.DataItem)%>'             AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/></a>
                     <%#br(Container.DataItem)%>
            <span style="color:Black;text-decoration:none; font-size:13px;">     <%#message(Container.DataItem)%>   </span>

            
  <br /><asp:Label runat="server" ID="itemid" style="visibility:hidden;" Text='<%# DataBinder.Eval(Container.DataItem, "NID") %>'></asp:Label>
  
  <asp:Label runat="server" ID="hell" style="visibility:hidden;" Text='<%#whatthehellthisis(Container.DataItem)%>'></asp:Label>
                          <br />
                           <div style="font-size:11px; ">
                           
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
  <td>
  
  <telerik:RadTabStrip  ID="RadTabStrip1" 
                     
				    runat="server" 
                    Orientation="VerticalRight" SelectedIndex="0" 
             Width="180px" EnableEmbeddedSkins="false">
			    <Tabs>
                <telerik:RadTab runat="server" CssClass="sidebarnormal" SelectedCssClass="sidebarselected" Text="top" Selected="true" onclick="goToByScroll(&#39;form1&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server"  CssClass="sidebarnormal" SelectedCssClass="sidebarselected" Text="recent posts" onclick="goToByScroll(&#39;mimageandpic&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server"  CssClass="sidebarnormal" SelectedCssClass="sidebarselected" Text="albums" onclick="goToByScroll(&#39;eduwork&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server"  CssClass="sidebarnormal" SelectedCssClass="sidebarselected" Text="education and work" onclick="goToByScroll(&#39;photos&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server"  CssClass="sidebarnormal" SelectedCssClass="sidebarselected" Text="listening to" onclick="goToByScroll(&#39;philosophy&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server"  CssClass="sidebarnormal" SelectedCssClass="sidebarselected" Text="profile photos" onclick="goToByScroll(&#39;ement&#39;)">
                    </telerik:RadTab>
                    <telerik:RadTab runat="server"  CssClass="sidebarnormal" SelectedCssClass="sidebarselected" Text="more" onclick="goToByScroll(&#39;achieve&#39;)">
                    </telerik:RadTab>
                    
                </Tabs>
			    </telerik:RadTabStrip>
  </td>
  </tr>
  </table>
  </div>
 <asp:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" 
                                    BorderColor="White" Enabled="True" Radius="15" TargetControlID="Panel2"></asp:RoundedCornersExtender>
 </asp:Panel>
 