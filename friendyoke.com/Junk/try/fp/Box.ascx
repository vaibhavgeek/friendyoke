<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Box.ascx.cs" Inherits="Public_Profiles_Just_Get_Feeds" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<style type="text/css">
    .rathibaba a ,.rathibaba a:visited
    {
        color:Black; 
        text-decoration:none;
        font-size:15px;
      
        }
         .rathibaba img 
         {
            color:Black; 
        text-decoration:none; 
        height:150px;
        width:150px;
      
             }
    .jayshreeeeeee
    {
        
        
        }
    body
    {
        font-size:16px;
        
        }
    </style><br /><div style="padding-left:15px; vertical-align:top;"><asp:Label runat="server" ID="sorry" Visible="false" Text=""></asp:Label>
        <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="712px" AllowPaging="True" GridLines="None" 
                     onneeddatasource="datasource" PageSize="6" BorderColor="White">
                            
                                      <MasterTableView Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderText="" UniqueName="" HeaderStyle-BackColor="White" SortExpression="MyBox" >
                 <ItemTemplate><table>
                 <tr>
                 <td valign="top">
                 
                 <table  align="left" cellpadding="1" cellspacing="2">
                                <tr>
                                    <td >
                                        <a href='<%#getUserHREF(Container.DataItem)%>'>
                                            <asp:Image ID="image" style="margin-left:0px;" runat="server" CssClass="ppic" ImageUrl='<%#getSRC(Container.DataItem)%>' height="120px" width="110px" />  </a>
                                    </td>
                                   
                                </tr>
                            </table>
                 
                 
                 </td>
                <td valign="top">
                
                
                 <div align="justify">
                 Posted  By <%#sendname(Container.DataItem)%></b><span style="position:absolute; left:800px;">Posted On: 
                            <asp:Label ID="lblSendDate" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendDate")%>'></asp:Label>
                            &nbsp;&nbsp; <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"SendTime")%>'></asp:Label></span><br />
                           <a style="color:Black;" href='<%#ID(Container.DataItem)%>'>        <%#DataBinder.Eval(Container.DataItem, "Message")%>
                           </a>
                           </div>
                                
                                <br />
                            </div>
                            
                            </span>
                
                
                </td> 
                 
                 
                 </tr>
                 
                 </table>
                            
                           
                  </ItemTemplate>
                </telerik:GridTemplateColumn>
                </Columns></MasterTableView>
                    <PagerStyle Wrap="True"  PageSizeLabelText="New Feed Count:" />
                </telerik:RadGrid></div>