<%@ Control Language="C#" AutoEventWireup="true" CodeFile="message.ascx.cs" Inherits="Space_message" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
 <link href="Sidebar/messageu/styles.css" rel="Stylesheet" />
 <link type="text/css" href="lib/jquery/jquery-ui-1.8.5.custom.css" rel="stylesheet" />	  
<div style="padding-left:0px;">
    
    
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
		<script type="text/javascript">

		    function onTabSelecting(sender, args) {
		        if (args.get_tab().get_pageViewID()) {
		            args.get_tab().set_postBack(false);
		        }
		    }
            
		</script>
        </telerik:RadScriptBlock>
		
			    
			    <telerik:RadTabStrip  ID="RadTabStrip1" 
                    SelectedIndex="0" CssClass="tabStrip"
				    runat="server" MultiPageID="RadMultiPage1" Skin="WebBlue" 
                    OnTabClick="RadTabStrip1_TabClick">
			    </telerik:RadTabStrip>			
			
               
		    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" OnPageViewCreated="RadMultiPage1_PageViewCreated" CssClass="multiPage">
			    </telerik:RadMultiPage>             
                                
                   
                  
                    </div>
                     </telerik:RadAjaxPanel>