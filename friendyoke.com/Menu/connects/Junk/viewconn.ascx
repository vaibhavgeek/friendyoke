<%@ Control Language="C#" AutoEventWireup="true" CodeFile="viewconn.ascx.cs" Inherits="Friends_ucontrols_viewconn" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<div  style="padding-left:15px;" class="page">
        <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" 
                        onneeddatasource="RadGrid1_NeedDataSource" AutoGenerateColumns="False" 
                        Skin="Office2007" Width="699px" AllowPaging="True" PageSize="3"  
                        >
                        <MasterTableView Width="100%"  AllowPaging="True"><PagerStyle  Mode="NumericPages" />
                <Columns>
               
                <telerik:GridTemplateColumn HeaderText="Search Results"  HeaderStyle-CssClass="none" UniqueName="Search Results" SortExpression="Search Results" HeaderButtonType="None" HeaderStyle-BackColor="White">
                
                <ItemTemplate>
                
                <table border="0">
                            <tr>
                                <td>
                                   
                                        <asp:Image id="image" ImageUrl='<%# getSRC(Container.DataItem) %>' runat="server"  border="0" height="100px" width="80px"/>
                                  
                              </td> 
                               
                                
                                <td>
                                 
                                <h3><%#name(Container.DataItem)%></h3>
                              
                               
                               Country&nbsp;&nbsp; : <%#country(Container.DataItem)%><br />
                                School &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <%#School(Container.DataItem)%><br />
                               Gender  &nbsp;&nbsp;&nbsp;&nbsp;: <%#gender(Container.DataItem)%><br />
                                Age&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: <%#Age(Container.DataItem)%><br />
                             
                           
                               
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