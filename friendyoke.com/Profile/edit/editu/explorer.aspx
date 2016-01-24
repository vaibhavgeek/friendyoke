<%@ Page Language="C#" AutoEventWireup="true" CodeFile="explorer.aspx.cs" Inherits="PoacherHub_meadnmine_explorer" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 341px;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadCodeBlock ID="codeBlock1" runat="server">
        <script type="text/javascript">
            //<![CDATA[
            function OnClientItemSelected(sender, args) {
                var pvwImage = $get("<%= pvwImage.ClientID %>");
                var imageSrc = args.get_path();

                if (imageSrc.match(/\.(gif|jpg|png)$/gi)) {
                    pvwImage.src = imageSrc;
                    pvwImage.style.display = "";
                }
                else {
                    pvwImage.src = imageSrc;
                    pvwImage.style.display = "none";
                }
            }
            //]]>
        </script>
    </telerik:RadCodeBlock>
    <script type="text/javascript">
        //A function that will return a reference to the parent radWindow in case the page is loaded in a RadWindow object
        function getRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }
        function OnClientGridDblClick(sender, args) {
            var item = args.get_item();

            //If file (and not a folder) is selected - call the OnFileSelected method on the parent page
            if (item.get_type() == Telerik.Web.UI.FileExplorerItemType.File) {
                args.set_cancel(true);
                //Get a reference to the opener parent page using rad window
                var wnd = getRadWindow();
                var openerPage = wnd.BrowserWindow;
                //if you need the URL for the item, use get_url() instead of get_path()
                openerPage.OnFileSelected(wnd, item.get_path());

                //Close window
                wnd.close();
            }
        }
       
    </script>

    
    <table style="width:100%;">
            <tr>
                <td class="style1">

    
        <telerik:RadFileExplorer runat="server" ID="FileExplorer1"  
                                         Skin="Office2007" Height="471px" 
            Width="336px" VisibleControls="TreeView, Grid, Toolbar, ContextMenus" 
                    OnClientFileOpen="OnClientGridDblClick" 
                        OnClientItemSelected="OnClientItemSelected" TreePaneWidth="140px">
                    <Configuration   MaxUploadFileSize="4000000" />
                </telerik:RadFileExplorer>
                </td>
                <td>

    
     <fieldset style="width: 180px; height: 257px; vertical-align: top;">
                    <legend>Preview</legend>
                    
                    <img id="pvwImage" src="" runat="server" alt="" style="display: none;
                        margin: 0px; width: 173px; height: 237px; vertical-align: middle;" />
                </fieldset><fieldset style="width: 180px; height: 183px; vertical-align: top;">
                    <legend>Settings</legend>
                    The Image Must Not Exceed The size limit of 3.81 MB .
                    <br /><br />
                    We Create a thumbnail of the following image of hieght near to 230 pixels.                        
                </fieldset>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
