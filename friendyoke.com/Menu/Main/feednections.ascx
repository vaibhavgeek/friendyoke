<%@ Control Language="C#" AutoEventWireup="true" Debug="true" CodeFile="feednections.ascx.cs" Inherits="fy.Newsfeed_Newsfeed" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register Src="~/Menu/Main/Newsfeed/abt.ascx" TagName="about" TagPrefix="uc2" %>

    

 <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        </telerik:RadWindowManager>

<telerik:RadToolTipManager ID="RadToolTipManager1"  OffsetX="255" HideEvent="LeaveToolTip"
		Width="393" Height="565" ShowEvent="OnClick"  RelativeTo="Element" Sticky="true" Position="BottomRight" Animation="Fade"  runat="server" ShowCallout="false" ManualCloseButtonText="Click to Close" VisibleOnPageLoad="false" EnableShadow="true" OnAjaxUpdate="OnAjaxUpdate"
		>
	</telerik:RadToolTipManager>

   


   

    
<div style="padding-left:5px;">


    <table>
    <tr>
    <td style="width:400px !important; ">
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" 
        MultiPageID="RadMultiPage1"  EnableEmbeddedSkins="false" SelectedIndex="0" >
        
        <Tabs>
            <telerik:RadTab runat="server" Text="Wazz up?" Selected="True" CssClass="theusualtabs">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="Photo" CssClass="theusualtabstwo">
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
 
 <telerik:RadButton ID="createalbum" runat="server"  Text="Create Album" 
    Icon-PrimaryIconUrl="~/Images/website/add2al.png"  ButtonType="LinkButton" 
         
   >
</telerik:RadButton>
 </td>
 <td>
 <telerik:RadButton ID="addtoalbum" runat="server"  
    Text="Add to Album" 
    Icon-PrimaryIconUrl="~/Images/website/album.png"  ButtonType="LinkButton"   
    >
</telerik:RadButton>
 </td>
 </tr>
 </table>
Describe Photo:
            </telerik:RadPageView>
            
        </telerik:RadMultiPage>
     

      
        
        <asp:TextBox runat="server" CssClass="tbber" ID="maincontent" 
    TextMode="MultiLine" Width="400px"></asp:TextBox>  <br /> 
    <div style="float:right;">
       <asp:Button ID="postfeed" runat="server" Text="Post" CssClass="twittertypebut"  
                         onclick="postfeed_Click"></asp:Button>
                         </div>
                         <h2 class="mainheader" style="width:400px;">
                 <asp:Label runat="server" ID="frndsn" Text="Newsfeed"></asp:Label> </h2>
                
                               
                 <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                     CssClass="rathibaba" Width="400px"  style="outline:none;" 
            AllowPaging="True" GridLines="None" BorderStyle="None" 
                     onneeddatasource="datasource" PageSize="25" BorderColor="White" 
            onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound" 
                         
        >
                            
                                      <MasterTableView DataKeyNames="NID" Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderStyle-CssClass="nfeedradgrid" HeaderText="" UniqueName="" SortExpression="NewsFeed" HeaderStyle-BackColor="White">
                 <ItemTemplate>
                 <table  style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                 <tr>
                 <td valign="top" style="border-style: none; border-width: 0px; border-top-color: #FFFFFF">
                 
             
                                        <a href='Menu/profile.aspx?uname=<%# DataBinder.Eval(Container.DataItem, "uname") %>'>
                                        <telerik:RadBinaryImage ID="sompropic" CssClass="magea" style="margin-left:0px;" runat="server"  DataValue='<%#propics(Container.DataItem)%>' Height="65px" Width="55px" ResizeMode="Crop" />
                                        </a>
                                 
                 
                 
                 </td>
                <td valign="top" style="border-style:none; border-width: 0px; border-top-color: #FFFFFF">
                
                 <%#albumcolor(Container.DataItem)%>

                
                 <div align="justify">
              <span style="font-size:11px;">  
               Posted  By <%# DataBinder.Eval(Container.DataItem, "Name") %>
               </span>
               <span style="font-size:11px; padding-left:30px;">
             
          <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
      &nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label> &nbsp; 
      <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick='<%#deletepostconfrim(Container.DataItem)%>' CommandName='<%#deletepostcommand(Container.DataItem)%>' ImageUrl="~/Images/Delete.gif" Visible='<%#deletebut(Container.DataItem)%>' />
      </span>
      
     
                         
                          
      <br />
         
                    
                  
              
                  <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1" DataValue='<%#photobyte(Container.DataItem)%>'             AutoAdjustImageControlSize="true" Width='<%#w(Container.DataItem)%>' Height='<%#h(Container.DataItem)%>'          ResizeMode="Fit"/></a>
                     <%#br(Container.DataItem)%>
            <span style="color:Black;text-decoration:none; font-size:13px;">     <%#message(Container.DataItem)%>   </span>

            
  <br /><asp:Label runat="server" ID="itemid" style="visibility:hidden;" Text='<%# DataBinder.Eval(Container.DataItem, "NID") %>'></asp:Label>
  
  <asp:Label runat="server" ID="hell" style="visibility:hidden;" Text='<%#whatthehellthisis(Container.DataItem)%>'></asp:Label>
                          <br />
                           <div style="font-size:11px; ">
                           <asp:LinkButton ID="comment" runat="server"  CssClass="someclasslink"  Text='<%#Comment(Container.DataItem)%>'></asp:LinkButton>
                           &nbsp;
                          <asp:LinkButton ID="like" runat="server" CssClass="someclasslink" CommandName='<%#commandnamelike(Container.DataItem)%>' Text='<%#like(Container.DataItem)%>'></asp:LinkButton>&nbsp;
                          <asp:LinkButton ID="phew" runat="server" CommandName='<%#commandnamephew(Container.DataItem)%>' CssClass="someclasslink" Text='<%#phew(Container.DataItem)%>'></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="abt" runat="server" CssClass="someclasslink" Text="expand"></asp:LinkButton>&nbsp;
                        <asp:LinkButton ID="abc" runat="server" CssClass="someclasslink" Text=">>>"></asp:LinkButton>
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
    <td valign="top" style="width:410px !important; ">
    <asp:Panel runat="server" ID="tploader"></asp:Panel>
    
    
        
    
   

    

   
    
    
    
    
    </td>
    
    </tr>
    </table>

    
        
        
        </div>



