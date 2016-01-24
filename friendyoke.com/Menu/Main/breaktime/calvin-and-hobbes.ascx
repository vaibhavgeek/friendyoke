<%@ Control Language="C#" AutoEventWireup="true" CodeFile="calvin-and-hobbes.ascx.cs" Inherits="Menu_Main_breaktime_calvin_and_hobbes" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<telerik:RadGrid ID="DataList1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" CellSpacing="0" GridLines="None" PageSize="1" ShowHeader="false" >
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>

<ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column"></ExpandCollapseColumn>
<Columns>
<telerik:GridTemplateColumn>
<ItemTemplate>
            <center><asp:Image Width="700" ID="Image1" ImageUrl='<%# Bind("Name", "~/Menu/Main/breaktime/calvin/{0}") %>' runat="server" />
               </center> <br />
                
            </ItemTemplate>


</telerik:GridTemplateColumn>
</Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>
    <PagerStyle Mode="Slider" />

<FilterMenu EnableImageSprites="False"></FilterMenu>

<HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default"></HeaderContextMenu>
</telerik:RadGrid>
calvin and hobbes is made by bill watterson , personally i love calvin .. a great kid isn't he? 

