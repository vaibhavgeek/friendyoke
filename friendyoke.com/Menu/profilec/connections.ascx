<%@ Control Language="C#" AutoEventWireup="true" Debug="true" CodeFile="connections.ascx.cs" Inherits="Profile_profilec_Achievements" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="sidemeyaaarright">
 <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">

		<script type="text/javascript">
		    function rowSelected(sender, args) {
		        var key = args.getDataKeyValue("ID");
		        var panel = $find("<%=RadXmlHttpPanel1.ClientID %>");
		        panel.set_value(key);
		    }
		</script>

	</telerik:RadScriptBlock>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
		<AjaxSettings>
			
		    <telerik:AjaxSetting AjaxControlID="Repeater2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="Repeater2" LoadingPanelID="LoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="RadGrid2">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="RadGrid2" LoadingPanelID="LoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
		</AjaxSettings>
	</telerik:RadAjaxManager>
	
	
    <table>
    <tr>
    <td valign="top">
    <telerik:RadGrid ID="RadGrid1" Skin="Default" OnNeedDataSource="RadGrid1_NeedDataSource"
				Width="300px" AllowSorting="True" AllowPaging="True" runat="server"
				AutoGenerateColumns="False" GridLines="None" AllowFilteringByColumn="True"  CellSpacing="0" >
				<MasterTableView ClientDataKeyNames="ID" Width="100%" Summary="RadGrid table">
					<Columns>
						<telerik:GridBoundColumn DataField="ID" Visible="false">
						</telerik:GridBoundColumn>
						<telerik:GridBoundColumn DataField="Name" HeaderText="all connections" UniqueName="Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" ShowFilterIcon="false" FilterControlWidth="155px">
						</telerik:GridBoundColumn>
						
					</Columns>
				</MasterTableView>
				<PagerStyle Mode="Slider" PageButtonCount="10" />
				<ClientSettings EnableRowHoverStyle="true" Selecting-AllowRowSelect="true" ClientEvents-OnRowSelected="rowSelected">
				</ClientSettings>
			</telerik:RadGrid>
    
    </td>
    <td valign="top">
    <telerik:RadXmlHttpPanel ID="RadXmlHttpPanel1" runat="server" OnServiceRequest="XmlHttpPanel_ServiceRequest"
				RenderMode="Block">
				
                <table>
                <tr>
                <td valign="top">
					<asp:Panel runat="server" ID="propic"></asp:Panel>
                
                </td>
                <td valign="top">
                <asp:Label ID="Name" runat="server"  Style="font-size: x-large;">
									</asp:Label> <br />
                                    <asp:Label CssClass="info" ID="uname" runat="server"></asp:Label>
					<asp:Panel runat="server" ID="addcontrols">
                    
                    </asp:Panel>
                    <div style="vertical-align:bottom;">
                    <asp:Button runat="server" ID="addasfrnd" CssClass="twittertypebutp2" 
                                    Visible="false" onclick="addasfrnd_Click">
                               
                                </asp:Button>
                                <br />
                                 <asp:Button runat="server" ID="addbox"  CssClass="twittertypebutp2"  
                                    Visible="false" onclick="addbox_Click">
                                 </asp:Button> </div>
                </td>
                </tr>
                </table>
					
                    
						
                               
                                


								
                               
                                
                                
                               
							
							
								
								
								
								
								
								
							
						
					
				
			</telerik:RadXmlHttpPanel>
    
    </td>
    </tr>
    
    </table>
			

		
	<asp:Label runat="server" ID="lblError"></asp:Label>
			
		
                
                
                    





</div>