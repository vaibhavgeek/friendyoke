<%@ Control Language="C#" AutoEventWireup="true" Debug="true" CodeFile="Newsfeed.ascx.cs" Inherits="Newsfeed_Newsfeed" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<link rel="stylesheet" type="text/css" href="lib/Newsfeed.css"/>
<link rel="stylesheet" type="text/css" href="lib/scroll/browser.css"/>
<script type='text/javascript' src="lib/scroll/flexcroll.js"></script>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">




   




    
<div style="padding-left:15px;">
<telerik:RadWindow runat="server"  VisibleStatusbar="false"
         ID="ExplorerWindow" Modal="true" Behaviors="Maximize,Close,Move" 
    Title="Browse Photos Of Your Friendsss" EnableEmbeddedSkins="false" ShowContentDuringLoad="true" InitialBehaviors="Maximize">
    </telerik:RadWindow>

    <table>
    <tr>
    <td style="width:490px;">
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
        MultiPageID="RadMultiPage1"  EnableEmbeddedSkins="false" SelectedIndex="0">
        
        <Tabs>
            <telerik:RadTab runat="server" Text="Wazz up?" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Photo">
            </telerik:RadTab>
            
        </Tabs>
        
    </telerik:RadTabStrip>
     
    <telerik:RadMultiPage ID="RadMultiPage1" Runat="server" 
        SelectedIndex="0">
            <telerik:RadPageView id="RadPageView1" runat="server" style="margin-top:8px;"></telerik:RadPageView>
            <telerik:RadPageView id="RadPageView2" runat="server" style="margin-top:8px;">
           
                

 <table>
 <tr>
 <td>
 <telerik:RadAsyncUpload ID="justadd" runat="server" 
      Width="100px" CssClass="relative1" MaxFileInputsCount="1"  AllowedFileExtensions="jpeg,jpg,gif,png,bmp" >
<Localization Select="Just Add Photo"/>
     
</telerik:RadAsyncUpload>
 </td>
 <td>
 
 <telerik:RadButton ID="createalbum" runat="server"  Text="Create new Album" 
    Icon-PrimaryIconUrl="~/Images/website/add2al.png"  ButtonType="LinkButton" 
         NavigateUrl="javascript:openRadWinofalbum()" 
   >
</telerik:RadButton>
 </td>
 <td>
 <telerik:RadButton ID="addtoalbum" runat="server"  
    Text="Add to already added Album" 
    Icon-PrimaryIconUrl="~/Images/website/album.png"  ButtonType="LinkButton"  NavigateUrl="javascript:openRadWinofadd()" 
    >
</telerik:RadButton>
 </td>
 </tr>
 </table>
Describe Photo:
            </telerik:RadPageView>
            
        </telerik:RadMultiPage>
     

      
        
        <asp:TextBox runat="server" CssClass="tbber" ID="maincontent" 
    TextMode="MultiLine" Width="490px"></asp:TextBox>  <br /> 
       <telerik:RadButton ID="postfeed" runat="server" Text="Post" Skin="Default" Width="80px" 
                         onclick="postfeed_Click"></telerik:RadButton>

                         <h2 class="mainheader" style="width:480px;">
                 <asp:Label runat="server" ID="frndsn" Text="Newsfeed"></asp:Label> </h2>
                
                               
                 <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="500px" 
            AllowPaging="True" GridLines="None" 
                     onneeddatasource="datasource" PageSize="20" BorderColor="White" 
                         onitemcommand="RadGrid1_ItemCommand1" 
            onpageindexchanged="RadGrid1_PageIndexChanged">
                            
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
               Posted  By <%# DataBinder.Eval(Container.DataItem, "Name") %>
               </span>
               <span style="font-size:11px; padding-left:60px;">
               Posted On: 
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
         
                    
                  
                  <a class="nfeed" style="display:<%#displayy(Container.DataItem)%>;"  href="javascript:OpenFileExplorerDialog('<%#det(Container.DataItem)%>')">
                  <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyte(Container.DataItem)%>'             AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/></a>
                     <%#br(Container.DataItem)%>
            <span style="color:Black;text-decoration:none; font-size:13px;">     <%#message(Container.DataItem)%>   </span>

            
  <br /><asp:Label runat="server" ID="itemid" style="visibility:hidden;" Text='<%# DataBinder.Eval(Container.DataItem, "NID") %>'></asp:Label>
  <asp:Label runat="server" ID="hell" style="visibility:hidden;" Text='<%#whatthehellthisis(Container.DataItem)%>'></asp:Label>
                          <br />
                           <div style="font-size:11px; ">
                           <asp:LinkButton ID="dpcomments"  CssClass="someclasslink" runat="server" CommandName="displaycomments" Text='<%#Comment(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
                           
                          <asp:LinkButton ID="like" runat="server" CssClass="someclasslink" CommandName='<%#commandnamelike(Container.DataItem)%>' Text='<%#like(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="phew" runat="server" CommandName='<%#commandnamephew(Container.DataItem)%>' CssClass="someclasslink" Text='<%#phew(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
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
    <td valign="top">
    

    
    <div runat="server" id="thecbox" style="position:fixed;">
   <telerik:RadTextBox ID="RadTextBox1" runat="server" TextMode="MultiLine" EmptyMessage="Click to comment on the post.." Height="40px" Width="210px">
                    </telerik:RadTextBox><br />
                    <telerik:RadButton runat="server" ID="postcomment" Text="Post" 
            onclick="postcomment_Click"></telerik:RadButton>
    <div style="overflow:auto; height:500px;width:215px!important;" id="tobescrolled">

    <telerik:RadGrid ID="RadGrid2" runat="server" CellSpacing="0" GridLines="None" 
                        AutoGenerateColumns="False" Width="205px" Skin="Office2007" 
                         PageSize="35" ondatabound="RadGrid2_DataBound"  style="border:none;" 
                     >
                        
                        <MasterTableView Width="205px" HeaderStyle-CssClass="nfeedradgrid">
                            
                            
                            
                            <Columns>
                                <telerik:GridTemplateColumn 
                                    HeaderStyle-BackColor="ActiveBorder" UniqueName="loadit">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td  bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF" valign="top">
                                                <a href='#'>
                                        <telerik:RadBinaryImage ID="sompropic" style="margin-left:0px;" runat="server" DataValue='<%#DataBinder.Eval(Container.DataItem, "Image") %>' Height="35px" Width="35px" ResizeMode="Fit" />
                                             </a>
                                                    
                                                </td>
                                                <td  bordercolor="White" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                                                    <%#DataBinder.Eval(Container.DataItem, "Name") %>
                                                    <br />
                                                   <b> <div style="width:150px !important;"><%#DataBinder.Eval(Container.DataItem, "Comment") %></div></b>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    
                                </telerik:GridTemplateColumn>
                            </Columns>
                            
                           
                        </MasterTableView>
                       <ClientSettings>
                       
                       
                        
                       </ClientSettings>
                     </telerik:RadGrid></div>
        
   
     
                    
                     

                         </div>
    
        
    
   

    

   
    
    
    
    
    </td>
    
    </tr>
    </table>

    
        
        
        </div>

</telerik:RadAjaxPanel>

<div id="someid" runat="server">
<script type="text/javascript">

    function OpenFileExplorerDialog(aid) {
        var wnd = $find("<%= ExplorerWindow.ClientID %>");
        wnd.setUrl("Photos/Viewer.aspx?determiner=" + aid);
        wnd.show();
        wnd.maximize();
    }

   
    function openRadWinofalbum() {

      //  var wnd = $find("<%= ExplorerWindow.ClientID %>");
      //  wnd.setUrl("Photos/Add-Album.aspx");
      //  wnd.show();
       // wnd.maximize();
       

    }

    function openRadWinofadd() {
      
      //  var wnd = $find("<%= ExplorerWindow.ClientID %>");
      //  wnd.setUrl("Photos/Add-Photo-Album.aspx");
       // wnd.show();
      //  wnd.maximize();
    }

       
        </script>
    




</div>