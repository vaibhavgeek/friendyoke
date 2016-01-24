<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Complete-Profile.aspx.cs" Inherits="Register_Complete_Profile" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register src="../user-controls/footer.ascx" tagname="footer" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
  <link rel="stylesheet" type="text/css" href="register.css"/>
  <link rel="stylesheet" type="text/css" href="../lib/style.css"/>
  <link type="text/css" href="../lib/jquery/jquery-ui-1.8.5.custom.css" rel="stylesheet" />
</head>
<body class="body">
    <form id="form1" runat="server"  >
    
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
   <telerik:radformdecorator runat="server" ID="decorate" 
    DecoratedControls="Buttons" Skin="Default" Width="194px" />
    <table style="margin: auto;">
    <tr>
    <td colspan="2">
      <div style="height:70px;">  
<asp:Panel  ID="somw" runat="server" style='position:absolute;left:13px;
top:-21px;width:984px;height:83px' Height="83px" Width="984px" BackImageUrl="~/Images/header.png">
<br />
    <div >
    <table>
    <tr>
    <td>
    <div style="position:relative; top: -10px; left: 11px;"><h3 style="font-size:22px;"><b>Friendyoke</b></h3> </div>
    </td>
    
    <td style="text-align:right; width:790px;">
      
   
<telerik:RadMenu ID="RadMenu1" Runat="server" Skin="Default" 
                  style="top: 5px; left: 106px">
        <Items>
            <telerik:RadMenuItem runat="server" Text="Step1 &gt; Enter Basic Information" 
                 Enabled="false" >
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server"  Text="Step 2 &gt; Complete Your Profile" 
                Value="3" Selected="true">
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server"  Text="Step 3 &gt; Find Friends" Value="4" Enabled="false" >
            </telerik:RadMenuItem>
            <telerik:RadMenuItem runat="server" Text="Stpe 4 &gt; Start yoking " Enabled="false" >
            </telerik:RadMenuItem>
        </Items>
    </telerik:RadMenu>
       </td>
    </tr>
    
    </table>
        
    </div>
        
          </asp:Panel>
        </div>
    
        
          
</td>
    </tr>
    <tr>
    <td>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" LoadingPanelID="LoadingPanel1">
    <table>
    <tr>
    
    <td valign="top" class="style1">
    
   
   
        <asp:Panel ID="Panel4" runat="server" BackColor="White"  Width="232px"  
                                    > 
           <telerik:RadPanelBar  style="margin-left:8px;" ID="RadPanelBar1" Runat="server" Skin="Office2007" 
    Width="210px" onitemclick="RadPanelBar1_ItemClick" OnClientItemClicking="OnClientItemClicking">
    <Items>
        <telerik:RadPanelItem runat="server" Text="Complete - Your Profile" 
            Expanded="true" PostBack="false">
            <Items>
                <telerik:RadPanelItem runat="server" Text="Add Profile Picture" Value="9">
                </telerik:RadPanelItem>
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
            </Items>
        </telerik:RadPanelItem>
    </Items>
</telerik:RadPanelBar><asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel4"></asp:RoundedCornersExtender><asp:RoundedCornersExtender ID="Panel3_RoundedCornersExtender" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel1"></asp:RoundedCornersExtender></asp:Panel></td>
    <td valign="top">
    <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="750px">
    <div style="padding-left:15px;">
    <asp:panel CssClass="ui-state-highlight ui-corner-all" 
                        style="margin-top: 20px; padding: 0 .7em;" runat="server" ID="error0" 
                        Width="628px" Height="23px">
    <span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
     Use the left panel to navigate and complete your profile, u can do this later also ..
                        
      </asp:panel>
      <center>
      <asp:Button runat="server" ID="but" CssClass="facebook" Text="facebook signup magic" PostBackUrl="https://www.facebook.com/dialog/oauth/?
    client_id=389477487741720
    &redirect_uri=http://friendyoke.com/open.php&scope=user_activities,user_about_me,user_birthday,user_education_history,user_hometown,user_interests,user_location,user_relationships,user_religion_politics,user_website,user_work_history
">

</asp:Button></center>
      
      </div>
              <telerik:RadMultiPage ID="RadMultiPage1" runat="server" OnPageViewCreated="RadMultiPage1_PageViewCreated">
		</telerik:RadMultiPage> <br />
        <div style="float:right; padding-right:15px;">    
              <telerik:RadButton ID="Button2" NavigateUrl="~/Register/Find-Freinds.aspx"  ButtonType="LinkButton" runat="server" Text="Skip this Step" 
                 ></telerik:RadButton>
              <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
              </telerik:RadScriptManager>
        </div></asp:Panel>
    </td>
    
    </tr>
    
    </table>
    </telerik:RadAjaxPanel>
    </td>


    
    </tr>
    <tr>
    <td valign="top" class="style1" colspan="2">
    </td>
    </tr>
    <tr>
    <td colspan="2">
        <uc1:footer ID="footer1" runat="server" />
        </td>
    </tr>
    </table> </form>
    </body>
    </html>