<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HOME.ascx.cs" Inherits="Space_message" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


    

<asp:RoundedCornersExtender ID="RoundedCornersExtender3" runat="server" 
                                    BorderColor="White" Enabled="True" Radius="15" TargetControlID="Panel3"></asp:RoundedCornersExtender>

  <asp:RoundedCornersExtender ID="RoundedCornersExtender2" runat="server" 
                                    BorderColor="White" Enabled="True" Radius="15" TargetControlID="Panel2"></asp:RoundedCornersExtender>
            <asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="White" Enabled="True" Radius="15" TargetControlID="Panel1"></asp:RoundedCornersExtender>
    


<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
		<script type="text/javascript">

		    function onTabSelecting(sender, args) {
		        if (args.get_tab().get_pageViewID()) {
		            args.get_tab().set_postBack(false);
		        }
		    }
            
		</script>
        </telerik:RadScriptBlock>
  
<table>
 <tr>
 <td align="left" valign="top" style="width:180px">
 <asp:Panel runat="server" BackColor="White" ID="Panel1">
     <telerik:RadTabStrip ID="RadTabStrip1" runat="server" EnableEmbeddedSkins="False"  
           Width="180px" Orientation="VerticalLeft" SelectedIndex="0"  MultiPageID="RadMultiPage1" OnTabClick="RadTabStrip1_TabClick" >
         
     </telerik:RadTabStrip>
     
     
 
     
 
 </asp:Panel>
 <br />
 <asp:Panel runat="server" CssClass="bottompane" BackColor="White" ID="Panel3">
     
  <a href="#">embed friendyoke!</a> 
                                       <a href="#">help</a> <br />
                                        
                                       <a href="#"> in store </a> 

                                       
                                       
                                        
                                        copyright &copy; friendyoke.com 
                                        designed by <a target="_blank" href="http://vaibhavgeek.blogspot.in/"> vaibhav maheshwari </a>
 
 </asp:Panel>
 </td>
 <td valign="top">

 <asp:Panel runat="server" Width="800px" BackColor="White" ID="Panel2">
 <telerik:RadMultiPage ID="RadMultiPage1" SelectedIndex="0" runat="server" OnPageViewCreated="RadMultiPage1_PageViewCreated">
              

		</telerik:RadMultiPage> 
 
 

 </asp:Panel>
 
 </td>
 </tr>
 
 </table>

 <telerik:RadAjaxManagerProxy ID="RadAjaxManagerProxy1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadTabStrip1">
            <UpdatedControls>
                
                
                <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" 
                    UpdatePanelRenderMode="Inline" />
                
                
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>