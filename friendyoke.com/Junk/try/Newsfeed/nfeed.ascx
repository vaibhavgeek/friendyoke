<%@ Control Language="C#" AutoEventWireup="true" CodeFile="nfeed.ascx.cs" Debug="true" Inherits="Newsfeed_nfeed" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
 
 <style type="text/css"> 
     
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
     
 </style>
 
   
    <link rel="stylesheet" type="text/css" href="lib/scroll/browser.css"/>
    <script type="text/javascript" type="text/javascript" src="lib/scroll/flexcroll.js"></script>
    
<script type="text/javascript">

    function OpenFileExplorerDialog(aid,pid,alid) {
        var wnd = $find("<%= ExplorerWindow.ClientID %>");
        wnd.setUrl("Photos/Viewer.aspx?nid=" + aid+"&pid="+pid+"&alid="+alid);
        wnd.show();
    }


   
       

        
  

window.onscroll = scroll;

function scroll() {
    if (window.pageYOffset == 80 || window.pageYOffset > 80) {
        var fyupa = $get("fyup");
        fyupa.style.display = "block";

    }
    if (window.pageYOffset < 80) { 
        var fyupa = $get("fyup");
        fyupa.style.display = "none";
    }
}

</script>

 <telerik:RadWindow runat="server" Width="1010px" VisibleStatusbar="false"
         ID="ExplorerWindow" Modal="true" Behaviors="Resize, Close, Move" 
    Title="Browse Photos Of Your Friendsss" Skin="WebBlue" AutoSize="true">
    </telerik:RadWindow>
<div style="width: 720px;">
        
                    
                    
                 <table>
                 <tr>
                 <td>
                 <script type="text/javascript">

                     function onTabSelecting(sender, args) {
                         if (args.get_tab().get_pageViewID()) {
                             args.get_tab().set_postBack(false);
                         }
                     }
                   
            
		</script>
                 <telerik:RadTabStrip OnClientTabSelecting="onTabSelecting" ID="RadTabStrip1" 
                    SelectedIndex="0" CssClass="tabStrip"
				    runat="server" MultiPageID="RadMultiPage1" Skin="Sitefinity" 
                    OnTabClick="RadTabStrip1_TabClick">
			    </telerik:RadTabStrip>
                 <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" OnPageViewCreated="RadMultiPage1_PageViewCreated" CssClass="multiPage">
			    </telerik:RadMultiPage>
                 
                 
                 <h2 class="mainheader"><asp:Label runat="server" ID="frndsn" Text="Newsfeed"></asp:Label> </h2>
                
                               
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
                
                
                 <div align="justify">
              <span style="font-size:11px;">  
               Posted  By  <%#sendname(Container.DataItem)%>
               </span>
               <span style="font-size:11px; padding-left:60px;">
               Posted On: 
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
         
                    <asp:Panel runat="server" ID="mainc">
                  
                  <a class="nfeed" style="display:<%#displayy(Container.DataItem)%>;"  href="javascript:OpenFileExplorerDialog(<%#itemd(Container.DataItem)%>,<%#pid(Container.DataItem)%>,<%#alid(Container.DataItem)%>)">
                   <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyte(Container.DataItem)%>'
                                AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/>
                   </a>
                    
            <a style="color:Black;text-decoration:none; font-size:13px;">     <%#message(Container.DataItem)%>   </a>

            </asp:Panel>
  <br /><asp:Label runat="server" ID="itemid" style="visibility:hidden;" Text='<%#itemd(Container.DataItem)%>'></asp:Label>
                          <br /> 
                           <span style="font-size:11px;">
                           <asp:LinkButton ID="vcomments" CssClass="someclasslink" runat="server" CommandName="displaycomments" Text='<%#Comment(Container.DataItem)%>' OnClientClick="div.fleXcroll.updateScrollBars()"></asp:LinkButton>&nbsp;&nbsp;
                           
                          <asp:LinkButton OnClientClick="changelike" ID="like" runat="server" CssClass="someclasslink" CommandName="like" Text='<%#like(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="phew" runat="server" CommandName="phew" CssClass="someclasslink" Text='<%#phew(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="about" runat="server" Text="About >>>>>>" CssClass="someclasslink" CommandName="displaywho"></asp:LinkButton>
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
                <h4>@ Friendyoke -> Launches </h4> New Game ABCD <br /> New App ABCD </div></div>





              <asp:Label ID="lblstatus" runat="server" Visible="false"></asp:Label>
              <div id="vaibhav" runat="server">
              <div id="mycustomscroll"  class='flexcroll'>
		
	
              
                    <telerik:RadGrid ID="RadGrid2" runat="server" CellSpacing="0" GridLines="None" 
                        AutoGenerateColumns="False" Width="215px" Skin="Office2007" 
                        HeaderStyle-BackColor="White" onload="RadGrid2_Load" PageSize="20" CssClass = "gridder"
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
                 
                 
                     
                    
                    
                   
 
 

                      

                       <telerik:RadAjaxLoadingPanel runat="server" ID="LoadingPanel1" Skin="Simple">
	    </telerik:RadAjaxLoadingPanel>   </div>










    