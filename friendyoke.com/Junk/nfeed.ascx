<%@ Control Language="C#" AutoEventWireup="true" CodeFile="nfeed.ascx.cs" Debug="true" Inherits="Newsfeed_nfeed" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

 
 <style type="text/css"> 
   
		  .tbber
     {
         height:55px;
         
         }
         
 .commentboxer
 { background-color:White;
 }
 
         .gridder 
         { width:215px !important;
             
             }
            .mainheader 
{
    border-bottom-style: solid; border-bottom-width: medium; border-bottom-color: #959485
    }
     .RadUpload input.ruFakeInput
        {
            display: none;
        }
        .RadUpload input.ruBrowse
        {
            width: 115px;
        } 
        .RadUpload span.ruFileWrap input.ruButtonHover
        {
            background-position: 100% -46px;
        }
        .RadUpload input.ruButton
        {
            background-position: 0 -46px;
        }
        .relative1
        {
             width:120px !important;
            }
            
 </style>
 
   
   
    

    <div runat="server">
<script type="text/javascript">

    function OpenFileExplorerDialog(aid,pid,alid) {
        var wnd = $find("<%= ExplorerWindow.ClientID %>");
        wnd.setUrl("Photos/Viewer.aspx?nid=" + aid+"&pid="+pid+"&alid="+alid);
        wnd.show();
        wnd.maximize();
    }



    function openRadWinofalbum() {
       
        var oWnd = window.radopen("Photos/Add-Album.aspx", null);
        oWnd.show();
    }

    function openRadWinofadd() {
        window.radopen("Photos/Add-Photo-Album.aspx", null);
    }
        
  


}

</script>

</div>
 <telerik:RadWindow runat="server"  VisibleStatusbar="false"
         ID="ExplorerWindow" Modal="true" Behaviors="Maximize,Close,Move" 
    Title="Browse Photos Of Your Friendsss" Skin="WebBlue" ShowContentDuringLoad="true" InitialBehaviors="Maximize">
    </telerik:RadWindow>
<div style="width: 720px;">
        
                    
                    
                 <table>
                 <tr>
                 <td style="width:490px !important;">
                 
                 <telerik:RadTabStrip ID="RadTabStrip1" 
                 
				    runat="server" MultiPageID="Blow" Skin="WebBlue" SelectedIndex="0" 
                    >
                     <Tabs>
                         <telerik:RadTab runat="server"  Text="Status" PageViewID="Blow1">
                         </telerik:RadTab>
                         <telerik:RadTab runat="server" Text="Photo" PageViewID="Blow2">
                         </telerik:RadTab>
                         <telerik:RadTab runat="server" Text="Event" PageViewID="Blow3">
                         </telerik:RadTab>
                     </Tabs>
			    </telerik:RadTabStrip>
                 <br /><telerik:RadMultiPage ID="Blow" runat="server">

                     <telerik:RadPageView ID="Blow1" runat="server">
                     

                     </telerik:RadPageView>
			         <telerik:RadPageView ID="Blow2" runat="server">
                    

 
 <asp:Panel ID="llooader" runat="server">
 </asp:Panel>

 <table>
 <tr>
 <td>
 <telerik:RadAsyncUpload ID="justadd" runat="server" 
    onfileuploaded="justadd_FileUploaded"  Width="100px" CssClass="relative1" MaxFileInputsCount="1"  AllowedFileExtensions="jpeg,jpg,gif,png,bmp" >
<Localization Select="Just Add Photo"/>
     
</telerik:RadAsyncUpload>
 </td>
 <td>
 
 <telerik:RadButton ID="createalbum" runat="server" OnClientClicked="openRadWinofalbum" Text="Create new Album" 
    Icon-PrimaryIconUrl="~/Images/website/add2al.png" 
    onclick="createalbum_Click">
</telerik:RadButton>
 </td>
 <td>
 <telerik:RadButton ID="addtoalbum" runat="server"  OnClientClicked="openRadWinofadd"
    Text="Add to already added Album" 
    Icon-PrimaryIconUrl="~/Images/website/album.png" 
    onclick="addtoalbum_Click">
</telerik:RadButton>
 </td>
 </tr>
 
 </table>

 
 


Describe Photo:
 





                     </telerik:RadPageView>
                     <telerik:RadPageView ID="Blow3" runat="server">
                     Event Name : <asp:TextBox runat="server" ID="TextBox1"></asp:TextBox><br />
                     <telerik:RadAsyncUpload ID="RadAsyncUpload1" runat="server" 
    onfileuploaded="justadd_FileUploaded"  MaxFileInputsCount="1"  
                             AllowedFileExtensions="jpeg,jpg,gif,png,bmp" 
                             >
<Localization Select="Add Event Photo"/>
     
</telerik:RadAsyncUpload>

                     Describe Event:
                     </telerik:RadPageView>
			    </telerik:RadMultiPage>
                     
                  <asp:TextBox runat="server" CssClass="tbber" style="-webkit-border-radius: 6px;" ID="maincontent" 
    TextMode="MultiLine" Width="490px"></asp:TextBox>  <br /> 
       <telerik:RadButton ID="postfeed" runat="server" Text="Post" Skin="Default" Width="80px" 
                         onclick="postfeed_Click">
       </telerik:RadButton>                

                 
                 <h2 class="mainheader" style="width:480px;">
                 <asp:Label runat="server" ID="frndsn" Text="Newsfeed"></asp:Label> </h2>
                
                               
                 <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="500px" AllowPaging="True" GridLines="None" 
                     onneeddatasource="datasource" PageSize="10" BorderColor="White" 
                         onitemcommand="RadGrid1_ItemCommand1">
                            
                                      <MasterTableView Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderStyle-CssClass="nfeedradgrid" HeaderText="" UniqueName="" SortExpression="NewsFeed" HeaderStyle-BackColor="White">
                 <ItemTemplate>
                 <table bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                 <tr>
                 <td valign="top" bordercolor="White" style="border-style: none; border-width: 0px; border-top-color: #FFFFFF">
                 
             
                                        <a href='<%#getUserHREF(Container.DataItem)%>'>
                                        <telerik:RadBinaryImage ID="sompropic" style="margin-left:0px;" runat="server" CssClass="ppic" DataValue='<%#propics(Container.DataItem)%>' Height="70px" Width="70px" ResizeMode="Fit" />
                                        </a>
                                 
                 
                 
                 </td>
                <td valign="top" bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                
                 <%#albumcolor(Container.DataItem)%>

                
                 <div align="justify">
              <span style="font-size:11px;">  
               Posted  By  <%#sendname(Container.DataItem)%>
               </span>
               <span style="font-size:11px; padding-left:60px;">
               Posted On: 
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
         
                    <asp:Panel runat="server" ID="mainc">
                  
                  <a class="nfeed" style="display:<%#displayy(Container.DataItem)%>;"  href="javascript:OpenFileExplorerDialog(<%#itemd(Container.DataItem)%>,<%#pid(Container.DataItem)%>,<%#alid(Container.DataItem)%>)"><telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyte(Container.DataItem)%>'             AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/></a>
                    <br />
            <span style="color:Black;text-decoration:none; font-size:13px;">     <%#message(Container.DataItem)%>   </span>

            </asp:Panel>
  <br /><asp:Label runat="server" ID="itemid" style="visibility:hidden;" Text='<%#itemd(Container.DataItem)%>'></asp:Label>
                          <br /> 
                           <span style="font-size:11px;">
                           <asp:LinkButton  CssClass="someclasslink" runat="server" CommandName="displaycomments" Text='<%#Comment(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
                           
                          <asp:Button ID="like" runat="server" CssClass="someclasslink" CommandName="like" Text='<%#like(Container.DataItem)%>'></asp:Button>&nbsp;&nbsp;
                          <asp:Button ID="phew" runat="server" CommandName="phew" CssClass="someclasslink" Text='<%#phew(Container.DataItem)%>'></asp:Button>&nbsp;&nbsp;
                          
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
                 <td style="border-left: 1px solid #BB3D00;">
                 
                     
                 </td>
                 <td valign="top">
                
              <asp:Panel runat="server" ID="comment" Visible="false" style="position:fixed;">
               
                <div style="position:absolute;">
                <div id="fyup" style="display:none; position:absolute;top:-100px;">
                <h4>@ Friendyoke -> Links.. </h4> New Game ABCD <br /> New App ABCD </div></div>





              <asp:Label ID="lblstatus" runat="server" Visible="false"></asp:Label>
              <div id="vaibhav" runat="server">
              <div id="mycustomscroll"  class='flexcroll'>
		
	
              
                    <telerik:RadGrid ID="RadGrid2" runat="server" CellSpacing="0" GridLines="None" 
                        AutoGenerateColumns="False" Width="215px" Skin="Office2007" 
                        HeaderStyle-BackColor="White" PageSize="20" CssClass = "gridder"
                     >
                        
                        <MasterTableView HeaderStyle-CssClass="commentboxer" Width="215px">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" 
                                    HeaderStyle-BackColor="ActiveBorder" UniqueName="loadit">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td  bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF" valign="top">
                                                <a href='#'>
                                        <telerik:RadBinaryImage ID="sompropic" style="margin-left:0px;" runat="server" DataValue='<%#DataBinder.Eval(Container.DataItem, "Image") %>' Height="25px" Width="25px" ResizeMode="Fit" />
                                             </a>
                                                    
                                                </td>
                                                <td  bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                                    <br />
                                                    <b><%#DataBinder.Eval(Container.DataItem, "Comment") %></b>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="ActiveBorder" />
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                            <HeaderStyle CssClass="commentboxer" />
                        </MasterTableView>
                        <HeaderStyle BackColor="White" />

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
                     </telerik:RadGrid></div>
                    </div>
                     
                     <asp:Panel runat="server" ID="tbforcomment">

                    <telerik:RadTextBox ID="RadTextBox1" runat="server" TextMode="MultiLine" Width="220px">
                    </telerik:RadTextBox>
                    <br />
                         <asp:Button runat="server" ID="post" Text="Post" 
                             onclick="post_Click"  />
                     </asp:Panel>
                     </asp:Panel>
                     
               
                
                </td>
                     
                 </tr>
                 </table>
                 
                 
                     
                    
                    
                   
 
 

                      

                          </div>










    