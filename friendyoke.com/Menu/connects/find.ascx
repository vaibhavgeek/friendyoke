<%@ Control Language="C#" AutoEventWireup="true" CodeFile="find.ascx.cs" Inherits="Friends_ucontrols_csearch" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<link type="text/css" href="../lib/jquery/jquery-ui-1.8.5.custom.css" rel="stylesheet" />	
		

<div style="padding-left:15px;">
    <asp:panel CssClass="ui-state-error ui-corner-all" style="padding: 0 .7em;" runat="server" 
                        ID="error" Width="625px" Height="19px">
    <span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span> 
     Following Error Occoured :  The name field cannot be blank .
                        
      </asp:panel>
     
      
      
      <asp:panel CssClass="ui-state-highlight ui-corner-all" 
                        style="margin-top: 20px; padding: 0 .7em;" runat="server" ID="error0" 
                        Width="628px" Height="23px">
    <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
     No Match For the Name you entered . Try his first name only .
                        
      </asp:panel>
        &nbsp;<table>
                 <tr>
                 <td>
                  <asp:Label ID="lblname" runat="server" Text="Name : **"></asp:Label><br />
                     <telerik:RadTextBox ID="RadTextBox1" Runat="server" 
                        EmptyMessage="Name Of the Friend" Width="125px" 
                        >
                    </telerik:RadTextBox>
                 
                 </td>
                 <td> &nbsp;
                   <asp:Label ID="lblcountry" runat="server" Text="Country :"></asp:Label><br />&nbsp;<telerik:RadTextBox 
                         ID="RadTextBox2" Runat="server" 
                        EmptyMessage="Which Country He live In " Width="125px" 
                        >
                    </telerik:RadTextBox>
                 
                 </td>
                 <td>
                  &nbsp;
                   <asp:Label ID="Label1" runat="server" Text="Company :"></asp:Label><br />&nbsp;<telerik:RadTextBox 
                         ID="RadTextBox3" Runat="server" 
                         Width="125px">
                    </telerik:RadTextBox>
                 
                 </td>
                 <td>
                   <asp:Label ID="Label2" runat="server" Text="Education Institution :"></asp:Label><br /> 
                     <telerik:RadTextBox ID="RadTextBox4" Runat="server" 
                         Width="125px" >
                    </telerik:RadTextBox>
                 
                 </td>
                 <td>
                   <br />
                &nbsp; <asp:Button   ID="Button1" CssClass="twittertypebutp2" runat="server" onclick="Button1_Click" 
                         Text="Search People" Width="121px"/>
                 
                 </td>
                 </tr>
                 
                  
                   
                 
                 </table>
    
               


                   
    
                 
    
                    <telerik:RadGrid ID="SearchResultList" runat="server" GridLines="None" 
                        onneeddatasource="RadGrid1_NeedDataSource" AutoGenerateColumns="False" 
                        Skin="Office2007" Width="657px" 
                        AllowPaging="True" PageSize="5" onitemevent="SearchResultList_ItemEvent" 
                        onpageindexchanged="SearchResultList_PageIndexChanged" 
                        onpagesizechanged="SearchResultList_PageSizeChanged">
                        <MasterTableView Width="100%" AllowPaging="True"><PagerStyle/>

<CommandItemSettings ExportToPdfText="Export to Pdf"></CommandItemSettings>

                <Columns>
               
                <telerik:GridTemplateColumn HeaderText="Search Results" UniqueName="Search Results" SortExpression="Search Results" >
                
                <ItemTemplate>
                <script type="text/javascript">
                    function OpenPositionedWindow(url, windowName) {
                        var oWnd = window.radopen(url, windowName);
                    }
                    function openRadWindow(ID) {
                        var oWnd = radopen("Wconnect.aspx?Id=" + ID, "RadWindow1");

                    }
		</script>
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
                             <input type="button" onclick="openRadWindow('<%#Id(Container.DataItem)%>'); return false;" value="Ask 2 Connect" />
                             
                             <asp:Button runat="server" ID="block" Text="Block" CommandName="Block" />
                             
                          
							
                        <telerik:RadWindowManager Title="Send Connection Request"  ID="RadWindowManager1" runat="server" Behaviors="Close , Move" Modal="True" Skin="Office2007" AutoSize="True" VisibleStatusbar="False" VisibleTitlebar="True" ShowContentDuringLoad="False">
		</telerik:RadWindowManager>
                               <telerik:RadToolTip runat="server" ID="detailstooltip" TargetControlID="det"  Position="MiddleRight" Animation="Resize" RelativeTo="Element" Skin="Office2007" Width="400px" Sticky="True">
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
                            <td>City</td>

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
                            <td valign="top">
                            Follow me on:
                                        <asp:ImageButton ID="ImageButton1" runat="server" Height="19px" 
                                            ImageUrl="~/Images/website/twitter.png" 
                                            Width="19px" />
                                        &nbsp;
                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="18px" 
                                            ImageUrl="~/Images/website/foodfirst-facebook.gif" 
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
                        <HeaderStyle CssClass="none" BackColor="White" />
                    </telerik:RadGrid>
                  
                   &nbsp;
        <asp:LinkButton runat="server" ID="pr" Font-Size="X-Small" ForeColor="Black">Priroty</asp:LinkButton>
        <telerik:RadToolTip runat="server" ID="prtooltip" Skin="Office2007" RelativeTo="Element" 
                        TargetControlID="pr" Position="MiddleLeft">
        Priroty Sequence Is - 
        Name ,
        Country , 
        Company ,
        School .
        </telerik:RadToolTip>
                  
                </div>