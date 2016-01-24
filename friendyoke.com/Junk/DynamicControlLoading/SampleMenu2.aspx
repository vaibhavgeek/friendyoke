<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SampleMenu2.aspx.cs" Inherits="SampleMenuPage2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sample Menu - ModalPopupExtender</title>
    <style type="text/css">
        .modalBackground
        {
            background-color:#dcdcdc;
            filter:alpha(opacity=60);
            opacity:0.60;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
            <Items>
                <asp:MenuItem Text="File">
                    <asp:MenuItem Text="Load Control1"></asp:MenuItem>
                    <asp:MenuItem Text="Load Control2"></asp:MenuItem>
                    <asp:MenuItem Text="Load Control3"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
        </asp:Menu>
        <br />
        <br />
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Menu1" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:Panel ID="Panel1" runat="server" style="background-color:#ffffff;display:none;width:400px">
            <div style="padding:8px">
                <h2>Loading...</h2>
            </div>
        </asp:Panel>
        <ajaxToolKit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="Panel1" PopupControlID="Panel1" BackgroundCssClass="modalBackground" DropShadow="true" />
        <script type="text/javascript">

            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_initializeRequest(initializeRequest);
            prm.add_endRequest(endRequest);

            var _postBackElement;

            function initializeRequest(sender, e)
            {
                if (prm.get_isInAsyncPostBack())
                {
                    e.set_cancel(true);
                }

                _postBackElement = e.get_postBackElement();

                if (_postBackElement.id.indexOf('Menu1') > -1)
                {
                    $find('ModalPopupExtender1').show();
                }
            }

            function endRequest(sender, e)
            {
                if (_postBackElement.id.indexOf('Menu1') > -1)
                {
                    $find('ModalPopupExtender1').hide();
                }
            }
        </script>
    </form>
</body>
</html>