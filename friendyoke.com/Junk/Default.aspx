<%@ Page Language="C#" AutoEventWireup="false" CodeFile="Default.aspx.cs" Inherits="Telerik.AJAXExamplesCSharp.AJAX.Examples.Common.LoadingUserControls._Default" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register src="user-controls/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="user-controls/footer.ascx" tagname="footer" tagprefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    
    <link rel="stylesheet" type="text/css" href="lib/style.css"/>
    
    <link href="Space/messageu/styles.css" rel="Stylesheet" />
    <link rel="stylesheet" type="text/css" href="Space/styles.css"/>
    
</head>
<body class="body">
    <form id="mainForm" runat="server">
<table style="margin: auto;">
<tr>
<td style=" height:65px;">

    <uc1:Header ID="Header1" runat="server" />

</td>
</tr>
<tr>
<td>

<telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>

            
    
            <table>
            <tr>
            <td valign="top">
                <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" 
                    >
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadPanelBar1">
                            <UpdatedControls>
                                <telerik:AjaxUpdatedControl ControlID="Panel1" LoadingPanelID="LoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadPanelBar1" />
                                
                                
                            </UpdatedControls>
                        </telerik:AjaxSetting>
                    </AjaxSettings>
                </telerik:RadAjaxManager>

            <asp:Panel ID="Panel4" runat="server" BackColor="White"  Width="232px"  
                                    > 
                                     
           <telerik:RadPanelBar  style="margin-left:8px;" ID="RadPanelBar1" Runat="server" Skin="Office2007" 
    Width="210px" onitemclick="RadPanelBar1_ItemClick">
    <Items>
        <telerik:RadPanelItem runat="server" 
            Owner="RadPanelBar1" Text="Speak &amp; Listen.." Expanded="True" PostBack="false">
            <Items>
                <telerik:RadPanelItem runat="server" Owner="" 
                   Text="Friends News Feed" Value="1" Selected="true">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" 
                     Owner="" 
                    Text="Following Public Profiles" Value="2">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Text="My Space.." Expanded="True" PostBack="false">
            
            <Items>
                <telerik:RadPanelItem runat="server" 
                    Owner="" PostBack="True" PreventCollapse="True" Text="Messages" Value="3">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" 
                    Owner="" Text="My Albums" Value="4">
                </telerik:RadPanelItem>
                
                <telerik:RadPanelItem runat="server" Text="'labs' &amp; 'apps'" Value="6">
                </telerik:RadPanelItem>
                
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Expanded="True" Text="Entertainment" 
            PostBack="False">
            <Items>
                <telerik:RadPanelItem runat="server" 
                    NavigateUrl="" Owner="" Text="Break-Time" Value="7">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" NavigateUrl="" 
                    Owner="" Text="Video Gallery" Value="8">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Games" 
                    NavigateUrl="" Value="9">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Text="Friends Online" PostBack="false">
            <ItemTemplate>
                <div style="color: #000000">
                    &nbsp;&nbsp;&nbsp;Images Of Online Friends</div>
            </ItemTemplate>
        </telerik:RadPanelItem>
    </Items>
</telerik:RadPanelBar>
<asp:RoundedCornersExtender ID="Panel3_RoundedCornersExtender" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel4">
                                </asp:RoundedCornersExtender>
<asp:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel2">
                                </asp:RoundedCornersExtender></asp:Panel> </td>
            <td valign="top">
       <asp:Panel ID="Panel2" runat="server" BackColor="White" Width="750px">
         <asp:Panel ID="Panel1" runat="server" BackColor="White" Width="750px">
                   </asp:Panel> </asp:Panel>
                   
                                 
                     </td>
            </tr>
            </table>
               
           
               
       
    <telerik:RadAjaxLoadingPanel ID="LoadingPanel1" runat="server" 
        Skin="Sitefinity" Direction="LeftToRight" BackgroundPosition="Center" >
        
    </telerik:RadAjaxLoadingPanel>
        
</td>
</tr>
<tr>
<td>
<uc2:footer ID="footer1" runat="server" />
</td>
</tr>
</table>

    </form>
</body>
</html>
