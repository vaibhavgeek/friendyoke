<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fp.ascx.cs" Inherits="Newsfeed_fp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div style="padding-left:15px;">
    

		<script type="text/javascript">

		    function onTabSelecting(sender, args) {
		        if (args.get_tab().get_pageViewID()) {
		            args.get_tab().set_postBack(false);
		        }
		    }
            
		</script>

		<div class="spreadSheet">
		    <div class="bottomSheetFrame">
			    
			    <telerik:RadTabStrip OnClientTabSelecting="onTabSelecting" ID="RadTabStrip1" 
                    SelectedIndex="0" CssClass="tabStrip"
				    runat="server" MultiPageID="RadMultiPage1" Skin="Sitefinity" 
                    OnTabClick="RadTabStrip1_TabClick">
			    </telerik:RadTabStrip>			
			</div>
		</div>
               
		    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" OnPageViewCreated="RadMultiPage1_PageViewCreated" CssClass="multiPage">
			    </telerik:RadMultiPage>             
                                
                   
                  
                    </div>