<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cremove.aspx.cs" Inherits="Menu_profilec_cremove" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../lib/style.css"/>
</head>
<body>
<script type="text/javascript">

    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.RadWindow; //Will work in Moz in all cases, including clasic dialog      
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow; //IE (and Moz as well)      
        return oWindow;
    }

    function Close() {
        GetRadWindow().Close();
    }  
      
    </script>
    <form id="form1" runat="server">
      <div id="sidemeyaaarright" runat="server">
    remove connection .. are you sure of it?
   <center> <telerik:RadBinaryImage runat="server" ID="propic"  Width="100px" Height="100px" CssClass="magea"  AutoAdjustImageControlSize="true" ResizeMode="Crop" />
   </center><div>  
    <asp:Button ID="Button1" CssClass="twittertypebut" runat="server" 
                  Text="confirm remove connection" onclick="Button1_Click" />
    <asp:Button ID="Button2" CssClass="twittertypebutp2" runat="server" Text="Close" OnClientClick="Close();return false;" />
                 </div>
               => reload profile for changes to take effects
    </div>
    </form>
</body>
</html>
