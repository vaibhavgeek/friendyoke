<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit-profile.aspx.cs" Inherits="Telerik.AJAXExamplesCSharp.AJAX.Examples.Common.LoadingUserControls.Profile_edit_edit_profile" %>

<%@ Register src="../../user-controls/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="../../user-controls/footer.ascx" tagname="footer" tagprefix="uc2" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../lib/style.css"/>
    <link rel="stylesheet" type="text/css" href="../profile.css"/>
</head>
<body class="body">
    <form id="mainform" runat="server" method="post">
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    <div>
    <table style="margin: auto;">
    <tr>
    <td style=" height:65px;">
    
        <uc1:Header ID="Header1" runat="server" />
    
    </td>
    </tr>


    <tr>
    <td>
    
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="LoadingPanel1">
   
    <table>
    <tr>
    <td valign="top">
    <asp:Panel ID="Panel4" runat="server" BackColor="White"  Width="232px"  
                                    > 
           <telerik:RadPanelBar  style="margin-left:8px;" ID="RadPanelBar1" Runat="server" Skin="Office2007" 
    Width="210px" onitemclick="RadPanelBar1_ItemClick" OnClientItemClicking="OnClientItemClicking">
    <Items>
        <telerik:RadPanelItem runat="server" Text="Edit - Profile" Expanded="true" PostBack="false">
            <Items>
                <telerik:RadPanelItem runat="server" Text="Mimage" Value="1">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Education and Work" Value="2">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Philosophy" Value="3">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Entertainment and Intrests" Value="4">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Achievements" Value="5">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Contact Information" Value="6">
                </telerik:RadPanelItem>
                
                <telerik:RadPanelItem runat="server" Text="Social Networks" Value="8">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Change Profile Picture" Value="9">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Text="Add to Profile" Expanded="true" PostBack="false">
            <Items>
                <telerik:RadPanelItem runat="server" Text="Add Location" Value="10">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Add Event" Value="11">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
    </Items>
</telerik:RadPanelBar><asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel4"></asp:RoundedCornersExtender><asp:RoundedCornersExtender ID="Panel3_RoundedCornersExtender" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel1"></asp:RoundedCornersExtender></asp:Panel>
    </td>
    <td valign="top">
    <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="750px">
              <telerik:RadMultiPage ID="RadMultiPage1" runat="server" OnPageViewCreated="RadMultiPage1_PageViewCreated">
		</telerik:RadMultiPage>     </asp:Panel>

    </td>
    </tr>
    
    </table>

 </telerik:RadAjaxPanel>
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel1" runat="server" 
        Skin="Sitefinity" Direction="LeftToRight" BackgroundPosition="Center" >
        
    </telerik:RadAjaxLoadingPanel>

     </td>
    </tr>


    <tr>
    <td>
        <telerik:RadCodeBlock ID="RadCodeBlock" runat="server">
			<script type="text/javascript">

			    function OnClientItemClicking(sender, args) {

			        var multiPage = $find("<%=RadMultiPage1.ClientID%>");
			        var item = args.get_item();
			        var itemt = item.get_value();
			        if (multiPage.get_pageViews().get_count() > 0) {

			            if (multiPage.findPageViewByID(itemt)) {
			                var pageView = multiPage.findPageViewByID(itemt);
			                pageView.set_selected(true);
			                pageView.show();
			                item.set_postBack(false);
			            }
			        }

			    }
			</script>
		</telerik:RadCodeBlock>
        <uc2:footer ID="footer1" runat="server" />
    </td>
    </tr>
    </table>
    </div>
    
    </form>
</body>
</html>
