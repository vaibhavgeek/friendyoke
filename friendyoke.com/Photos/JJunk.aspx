<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JJunk.aspx.cs" Inherits="Photos_Viewer" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><link rel="stylesheet" type="text/css" href="../lib/Style.css"/>
    <link rel="stylesheet" type="text/css" href="../lib/viewer.css"/>
    <link rel="stylesheet" type="text/css" href="../lib/scroll/browser.css"/>
    <script type="text/javascript" src="../lib/scroll/flexcroll.js"></script>
     <link rel="stylesheet" type="text/css" href="../lib/jquery/jquery-ui-1.8.5.custom.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    
    <td><telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="500px" 
            AllowPaging="True" GridLines="None" 
                     onneeddatasource="datasource" PageSize="1" BorderColor="White" 
                         onitemcommand="RadGrid1_ItemCommand1">
                            <PagerStyle Position="Top" />
                                      <MasterTableView Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderStyle-CssClass="nfeedradgrid" HeaderText="" UniqueName="" SortExpression="NewsFeed" HeaderStyle-BackColor="White">
                 <ItemTemplate>
                 
                 
                  <telerik:RadBinaryImage runat="server" ID="RadBinaryImage1"    
                            AutoAdjustImageControlSize="true" 
                           Height="480px" Width="600px"          ResizeMode="Fit"/>
                   
           
                             
                     
                    
                  
                          
                                  
               
                
                
                            
                           
                  </ItemTemplate>
                  
                </telerik:GridTemplateColumn>
                </Columns></MasterTableView>
                    
                </telerik:RadGrid></td>
    
    <td style="border-left: 1px solid #BB3D00;"></td>
    
    <td> <telerik:RadTextBox ID="RadTextBox1" runat="server" TextMode="MultiLine" EmptyMessage="Press Enter to hit to post comment.." Height="40px" Width="210px">
                    </telerik:RadTextBox> 
                    <telerik:RadButton runat="server" ID="postcomment" Text="Post" 
            onclick="postcomment_Click"></telerik:RadButton>
                     <telerik:RadGrid ID="RadGrid2" runat="server" CellSpacing="0" GridLines="None" 
                        AutoGenerateColumns="False" Width="205px" Skin="Office2007" 
                         PageSize="15"  style="border:none;"
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
                     </telerik:RadGrid> </td>
    
    </tr> 
     </table>
    </div>
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    </form>
</body>
</html>
