<%@ Control Language="C#" AutoEventWireup="true" CodeFile="connect-req.ascx.cs" Inherits="Friends_ucontrols_connect" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div style="padding-left:15px;">  <h1> <asp:Label ID="Label1" runat="server" Text=""></asp:Label></h1>
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
                    GridLines="None" Skin="Office2007" onitemcommand="RadGrid1_ItemCommand" 
                    onneeddatasource="RadGrid1_NeedDataSource">
                    <MasterTableView Width="100%" AllowPaging="True"><PagerStyle AlwaysVisible="True" />
                <Columns>
               
                <telerik:GridTemplateColumn HeaderText="Following People Want 2 Connect With u" UniqueName="Search Results" SortExpression="Search Results" >
                
                <ItemTemplate>

                <input type="hidden" id="hiddenId" value='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
                                        runat="server" name="hiddenId" />
                  
                
                <table border="0">
                            <tr>
                                <td>
                                    <a href='<%#getHREF(Container.DataItem)%>'>
                                        <asp:Image id="image" ImageUrl='<%# getSRC(Container.DataItem) %>' runat="server"  border="0" height="140px" width="100px"/>
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
                            <asp:Button ID="AcceptButton" runat="server" ToolTip="Accept" Text="Accept" CommandName="Accept" />
                                    <asp:Button ID="Deny" runat="server" ToolTip="Deny" Text="Deny" CommandName="Deny" />
                        
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
                            <td>My Dairy: <a href="#" >Some Link</a> <br /><br />
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
                </telerik:GridTemplateColumn>
                </Columns>
                </MasterTableView>
                </telerik:RadGrid></div>