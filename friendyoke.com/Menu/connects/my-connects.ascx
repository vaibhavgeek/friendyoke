<%@ Control Language="C#" AutoEventWireup="true" CodeFile="my-connects.ascx.cs" Inherits="Friends_ucontrols_mcon" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<div style="padding-left:15px;"> <telerik:RadWindowManager ID="RadWindowManager1" runat="server" EnableShadow="true">
        </telerik:RadWindowManager>  <h1> <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>
                <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" 
                        onneeddatasource="RadGrid1_NeedDataSource" onitemcommand="RadGrid1_ItemCommand"  AutoGenerateColumns="False" 
                        Skin="Office2007" Width="704px" AllowPaging="True" PageSize="3"  
                        >
                        <MasterTableView Width="100%"  AllowPaging="True"><PagerStyle  Mode="NumericPages" />
                <Columns>
               
                <telerik:GridTemplateColumn HeaderText="Manage Your Friends.. "  HeaderStyle-CssClass="none" UniqueName="Search Results" SortExpression="Search Results" HeaderButtonType="None" HeaderStyle-BackColor="White">
                
                <ItemTemplate>

                <input type="hidden" id="hiddenId" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
                                        runat="server" name="hiddenId" />
                  
                
                <table border="0">
                            <tr>
                                <td>
                                    <a href='<%#getHREF(Container.DataItem)%>'>
                                        <telerik:RadBinaryImage id="image" ResizeMode="Fit" runat="server"  DataValue='<%# getSRC(Container.DataItem) %>' runat="server"  border="0" height="100px" width="80px"/>
                                    </a>
                               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td> 
                               
                                
                                <td>
                                 <asp:Panel runat="server" ID="det">
                                <h1><%#name(Container.DataItem)%></h1><br />
                              
                               
                               Country&nbsp;&nbsp; : <%#country(Container.DataItem)%><br />
                                School &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <%#School(Container.DataItem)%><br />
                               Gender  &nbsp;&nbsp;&nbsp;&nbsp;: <%#gender(Container.DataItem)%><br />
                                Age&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <%#Age(Container.DataItem)%><br />
                             
                             </asp:Panel>
                             <br />
                            <telerik:RadButton runat="server" ID="remove123" Text="Remove From your Connections" CommandName="Remove">
    <Icon  PrimaryIconUrl="../Images/cancel-icon.png" /></telerik:RadButton>
                                    
                        
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
                            Follow me on:
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" 
                                            ImageUrl="~/PoacherHub/Images/website/twitter.png" 
                                            Width="19px" />
                                        &nbsp;
                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="18px" 
                                            ImageUrl="~/PoacherHub/Images/website/foodfirst-facebook.gif" 
                                            />    </td>
                        </tr>
                    </table>
                             
                           
                             
                             </telerik:RadToolTip>
                                </td>
                            </tr>
                        </table>
               
             



                </ItemTemplate>

<HeaderStyle BackColor="White" CssClass="none"></HeaderStyle>
                </telerik:GridTemplateColumn>
                
                
                </Columns>
                </MasterTableView>
                    </telerik:RadGrid>
                
                </div>