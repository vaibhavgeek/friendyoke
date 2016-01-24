<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="Valbum.aspx.cs" Inherits="Photos_Valbum" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" type="text/css" href="../lib/Style.css"/>
    <link rel="stylesheet" type="text/css" href="../lib/viewer.css"/>
    <link rel="stylesheet" type="text/css" href="../lib/scroll/browser.css"/>
    <script type="text/javascript" src="../lib/scroll/flexcroll.js"></script>
     <link rel="stylesheet" type="text/css" href="../lib/jquery/jquery-ui-1.8.5.custom.css"/>
</head>
<body class="bgof">

    <form id="form1" runat="server">
<script type="text/javascript">

    function goto(location) {
        window.location = location;    }


</script>
     <div style="height:55px;">

    <asp:Panel style="position:absolute;left:35px;top:-55px;width:948px;height:92px;" ID="somw" Width="948px" Height="92px" runat="server" BackImageUrl="~/Images/head2.png">
<br /><br /><br />
 <span style="font-size:larger; padding-left:19px;"><span style="padding-left:39px;"> Browsing <b><asp:Label runat="server" ID="uname"></b></asp:Label>'s Albums </span></span>
           
</asp:Panel>
</div>
<asp:Panel ID="Panel1" runat="server" BackColor="White" Height="400px" Width="948px" style="left:30px; position:relative;">
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
  
        
    
    
    
      
      
           </telerik:RadAjaxPanel>
    </asp:Panel>
    <asp:RoundedCornersExtender ID="Panel3_RoundedCornersExtender" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel1"></asp:RoundedCornersExtender>
    
    
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>   </form>
 
</body>

</html>
