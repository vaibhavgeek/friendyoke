<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default22.aspx.cs" Inherits="Default22" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<style type="text/css">
		
	</style>
</head>
<body>
	<form id="form1" runat="server">
	<div>
		<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
		</telerik:RadScriptManager>
		<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
            DefaultLoadingPanelID="RadAjaxLoadingPanel1">
			<AjaxSettings>
				<telerik:AjaxSetting AjaxControlID="RadPanelBar1">
					<UpdatedControls>
						<telerik:AjaxUpdatedControl ControlID="RadMultiPage1" />
					</UpdatedControls>
				</telerik:AjaxSetting>
			</AjaxSettings>
		</telerik:RadAjaxManager>
		
        
        
        
        
        <table>
        <tr>
        <td>
        <asp:Panel ID="Panel4" runat="server" BackColor="White"  Width="232px"  
                                    > 
        <telerik:RadPanelBar Style="margin-left: 8px;" ID="RadPanelBar1" runat="server" Skin="Office2007"
			Width="210px" OnItemClick="RadPanelBar1_ItemClick" OnClientItemClicking="OnClientItemClicking">
			<Items>
				<telerik:RadPanelItem runat="server" Owner="RadPanelBar1" Text="Speak & Listen.."
					Expanded="True">
					<Items>
						<telerik:RadPanelItem runat="server" Owner="" Selected="True" Text="Friends News Feed"
							Value="nfeed">
						</telerik:RadPanelItem>
						<telerik:RadPanelItem runat="server" Owner="" Text="Following Public Profiles" Value="try">
						</telerik:RadPanelItem>
					</Items>
				</telerik:RadPanelItem>
			</Items>
		</telerik:RadPanelBar>
        </asp:Panel>
        </td>
        <td>
        <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="750px">
        <telerik:RadMultiPage ID="RadMultiPage1" runat="server" OnPageViewCreated="RadMultiPage1_PageViewCreated">
		</telerik:RadMultiPage>
        </asp:Panel>
        </td>
        </tr>
        </table>
        
        
        
		<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
            Skin="Default">
        </telerik:RadAjaxLoadingPanel>
		
		<telerik:RadCodeBlock ID="RadCodeBlock" runat="server">
			<script type="text/javascript">

				function OnClientItemClicking(sender, args) {

					var multiPage = $find("<%=RadMultiPage1.ClientID%>");
					var item = args.get_item();
					var itemt = item.get_value();
					if(multiPage.get_pageViews().get_count() > 0) {

						if(multiPage.findPageViewByID(itemt)) {
							var pageView = multiPage.findPageViewByID(itemt);
							pageView.set_selected(true);
							pageView.show();
							item.set_postBack(false);
						}
					}

				}
			</script>
		</telerik:RadCodeBlock>
	</div>
	</form>
</body>
</html>
