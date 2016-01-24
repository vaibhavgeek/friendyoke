<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="SampleMenu1.aspx.cs" Inherits="Telerik.Web.Examples.ToolTip.TargetControlsAndAjax.SampleMenuPage1" %>
<%@ Register Src="SampleControl1.ascx" TagName="SampleControl1" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sample Menu - UpdateProgress</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
      
        <telerik:RadToolTipManager ID="RadToolTipManager1" OffsetY="-1" HideEvent="ManualClose"
		Width="250" Height="350" runat="server" EnableShadow="true" OnAjaxUpdate="OnAjaxUpdate" RelativeTo="Element"
		Position="MiddleRight">
	</telerik:RadToolTipManager>
    
<telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="False" 
            CellSpacing="0" DataSourceID="SqlDataSource1" GridLines="None" 
        onitemcommand="RadGrid1_ItemCommand" onitemdatabound="RadGrid1_ItemDataBound">
<MasterTableView DataKeyNames="ID" DataSourceID="SqlDataSource1">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="Name" 
            FilterControlAltText="Filter Name column" HeaderText="Name" 
            SortExpression="Name" UniqueName="Name">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Email" 
            FilterControlAltText="Filter Email column" HeaderText="Email" 
            SortExpression="Email" UniqueName="Email">
        </telerik:GridBoundColumn>
       <telerik:GridTemplateColumn>
       <ItemTemplate>
       <asp:HyperLink ID="targetControl" runat="server" NavigateUrl="#" Text='<%# Eval("Name") %>'></asp:HyperLink>
       </ItemTemplate>
       </telerik:GridTemplateColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
</telerik:RadGrid>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:maindb1ConnectionString %>" 
            SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>

    </form>
</body>
</html>