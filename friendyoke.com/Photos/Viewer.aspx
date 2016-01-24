<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeFile="Viewer.aspx.cs" Inherits="Photos_Viewer" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
   <link rel="stylesheet" type="text/css" href="../lib/Style.css"/>
    <link rel="stylesheet" type="text/css" href="../lib/viewer.css"/>
    <link rel="stylesheet" type="text/css" href="../lib/scroll/browser.css"/>
    <script type="text/javascript" src="../lib/scroll/flexcroll.js"></script>
     <link rel="stylesheet" type="text/css" href="../lib/jquery/jquery-ui-1.8.5.custom.css"/>
    
</head>

<body class="bgof">
    <form id="form1" runat="server" >
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        
</telerik:RadScriptManager>

    
    <div style="height:55px;">
    <asp:Panel style="position:absolute;left:35px;top:-55px;width:948px;height:92px;" ID="somw" Width="948px" Height="92px" runat="server" BackImageUrl="~/Images/head2.png">
<br /><br /><br />
 <span style="font-size:larger; padding-left:19px;"><a runat="server" id="anchor" style="color:Black;" class="someclasslink"><<======== Go to Albums </a><span style="padding-left:39px;"> Browsing <asp:Label runat="server" ID="uname"></asp:Label> <b><asp:Label runat="server" ID="aname"></asp:Label></b></span></span>
           
</asp:Panel>
    </div>
    
    
   
    <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="948px" style="left:30px; position:relative;">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
  
    <table style="width:100%;">
              <tr>
                  <td>
                  
                  <asp:panel CssClass="ui-state-highlight ui-corner-all" 
                        style="margin-top: 20px; padding: 0 .7em;" runat="server" Visible="false" ID="pan1" 
                       >
    <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
   Click Below on the album photos to browse photos ..
                        
      </asp:panel>
                 <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="500px" 
            AllowPaging="True" GridLines="None" 
                     onneeddatasource="datasource" PageSize="1" BorderColor="White" 
                         onitemcommand="RadGrid1_ItemCommand1" 
                          onpageindexchanged="RadGrid1_PageIndexChanged"  
            >
                            
                                      <MasterTableView Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderStyle-CssClass="nfeedradgrid" HeaderText="" UniqueName="" SortExpression="NewsFeed" HeaderStyle-BackColor="White">
                 <ItemTemplate>
                 <asp:Label runat="server" ID="hell" style="visibility:hidden;" Text='<%#whatthehellthisis(Container.DataItem)%>'></asp:Label>
                 <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1"    
                            AutoAdjustImageControlSize="true" 
                           Height="480px" Width="600px"   DataValue='<%#Eval("Photo") is DBNull ? null : Eval("Photo")%>'        ResizeMode="Fit"/>
                           <br />
                           <div style="font-size:11px; ">
                           <asp:LinkButton ID="dpcomments"  CssClass="someclasslink" runat="server" CommandName="displaycomments" Text='<%#Comment(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
                           
                          <asp:LinkButton ID="like" runat="server" CssClass="someclasslink" CommandName='<%#commandnamelike(Container.DataItem)%>' Text='<%#like(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
                          <asp:LinkButton ID="phew" runat="server" CommandName='<%#commandnamephew(Container.DataItem)%>' CssClass="someclasslink" Text='<%#phew(Container.DataItem)%>'></asp:LinkButton>&nbsp;&nbsp;
                          </div>
                            
                           
                  </ItemTemplate>
                  
                </telerik:GridTemplateColumn>
                </Columns></MasterTableView>
                <ClientSettings AllowKeyboardNavigation="true" >
                <KeyboardNavigationSettings  EnableKeyboardShortcuts="true"  AllowActiveRowCycle="true"   />


                </ClientSettings>
                    <PagerStyle Wrap="True" Position="Top"  Mode="Slider"  />
                </telerik:RadGrid> 
                  
                   
                   
                   
                    
                     </td>
                     <td style="border-left: 1px solid #BB3D00;">&nbsp;</td>
                  <td rowspan="2" valign="top" width="220px">
                   <div runat="server" id="thecbox" style="position:static;" >
                <telerik:RadTextBox ID="RadTextBox1" runat="server" TextMode="MultiLine" EmptyMessage="Press Enter to hit to post comment.." Height="40px" Width="210px">
                    </telerik:RadTextBox> <br />
                    <telerik:RadButton runat="server" ID="postcomment" Text="Post" 
            onclick="postcomment_Click"></telerik:RadButton>


             <div style="overflow:auto; height:400px;width:215px!important;" id="tobescrolled">
                     <telerik:RadGrid ID="RadGrid2" runat="server" CellSpacing="0" GridLines="None" 
                        AutoGenerateColumns="False" Width="205px" Skin="Office2007" 
                         PageSize="15"  style="border:none;" ondatabound="RadGrid1_DataBound"
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
                     </telerik:RadGrid> 
                     </div>
                     </div>
                     </td>
                  
              </tr>
              
          </table>
    
    
    
      
      
           </telerik:RadAjaxPanel>
    </asp:Panel>
   
    <asp:RoundedCornersExtender ID="Panel3_RoundedCornersExtender" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel1"></asp:RoundedCornersExtender>
    
    
    
    </form>
</body>
</html>

