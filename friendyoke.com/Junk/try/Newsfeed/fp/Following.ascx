<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Following.ascx.cs" Inherits="Public_Profiles_Suscribed_Feeds" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %><div style="padding-left:15px; vertical-align:top;">

<h3><asp:Label ID="followin" Text="People You Are Following" runat="server"></asp:Label></h3>
<style type="text/css">
    .rathibaba a ,.rathibaba a:visited
    {
        color:Black; 
        text-decoration:none;
      
        }
    .jayshreeeeeee
    {
        
        
        }
    
    </style>
    <telerik:RadGrid ID="followingpp" runat="server" AutoGenerateColumns="False" 
                    Skin="Office2007" CssClass="rathibaba" Width="712px" AllowPaging="True" GridLines="None" 
                     onneeddatasource="datasource" PageSize="6" BorderColor="White" >
                            
                                      <MasterTableView Width="100%" >
                <Columns>
               
                
                
               
                <telerik:GridTemplateColumn HeaderText="" HeaderStyle-CssClass="jayshreeeeeee" UniqueName="MyBox" SortExpression="MyBox" HeaderStyle-BackColor="White" HeaderStyle-Height="0px">
                 <ItemTemplate><table>
                 <tr>
                 <td>
                 
                 <a href='<%#getHREF(Container.DataItem)%>'>
                                            <asp:Image ID="image" style="margin-left:0px;" runat="server" CssClass="ppic" ImageUrl='<%#getSRC(Container.DataItem)%>' height="120px" width="110px" />  </a>
                 </td>
                 <td>
                 <asp:Panel runat="server" ID="det">
                                <h1><%#name(Container.DataItem)%></h1><br />
                              
                               
                               Country&nbsp;&nbsp; : <%#country(Container.DataItem)%><br />
                                School &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <%#School(Container.DataItem)%><br />
                               Gender  &nbsp;&nbsp;&nbsp;&nbsp;: <%#gender(Container.DataItem)%><br />
                                Age&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <%#Age(Container.DataItem)%><br />
                             
                             </asp:Panel>
            <telerik:RadToolTip runat="server" ID="detailstooltip" TargetControlID="det"  Position="MiddleRight" Animation="Resize" RelativeTo="Element" Skin="Outlook" Width="400px" Sticky="True">
                             <table style="width:100%;">
                        <tr>
                            <td class="style4">
                                
                                
                           <table>
                           <tr>
                           <td>
                           Comapany :
                           </td>
                           <td>
                          <%#company(Container.DataItem)%>
                           </td>
                           </tr>
                           <tr>
                            <td>About Me :</td>

                            <td> <%#about(Container.DataItem)%></td>

                            </tr>
                            <tr>
                            <td>
                            Relationship Status:
                            
                            </td>
                            <td>
                            <%#reletion(Container.DataItem)%>
                            
                            </td>
                            </tr>

                            </table>

                             
                             
                             </td>
                            <td>
                       Facebook :
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" 
                                            ImageUrl="~/Images/website/foodfirst-facebook.gif" 
                                            Width="19px" />
                                        &nbsp;<br /><br />Twitter:
                                       &nbsp;&nbsp;&nbsp; <asp:ImageButton ID="ImageButton2" runat="server" Height="18px" 
                                            ImageUrl="~/Images/website/twitter.png" 
                                            />    </td>
                        </tr>
                    </table>
                             
                           
                             
                             </telerik:RadToolTip><br /> <telerik:RadButton runat="server" ID="remove123" Text="Remove From Box">
    <Icon  PrimaryIconUrl="../Images/cancel-icon.png" /></telerik:RadButton>    </td>
                 </tr>
                 
                 </table>
                            
                           
                  </ItemTemplate>
                </telerik:GridTemplateColumn>
                </Columns></MasterTableView>
                    <PagerStyle Wrap="True"  PageSizeLabelText="New Feed Count:" />
                </telerik:RadGrid>
    
</div>