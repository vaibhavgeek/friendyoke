<%@ Control Language="C#" AutoEventWireup="true" CodeFile="follow-box.ascx.cs" Inherits="Newsfeed_fp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">

    
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
                    SelectedIndex="0"  
				    runat="server" MultiPageID="RadMultiPage1" CssClass="thetabstripp" EnableEmbeddedSkins="false"
                    OnTabClick="RadTabStrip1_TabClick">
			    </telerik:RadTabStrip>			
			
               
		    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" OnPageViewCreated="RadMultiPage1_PageViewCreated" CssClass="multiPage">
			    </telerik:RadMultiPage>             
                                
                   
                  
                   
                    </telerik:RadAjaxPanel>