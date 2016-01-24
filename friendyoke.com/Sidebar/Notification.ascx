<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Notification.ascx.cs" Inherits="Sidebar_Notification" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<link href="../lib/Style.css" rel="stylesheet" type="text/css" />




<telerik:RadGrid  ID="RadGrid1" runat="server" AllowPaging="True" PageSize="5"
            OnNeedDataSource="RadGrid1_NeedDataSource" AutoGenerateColumns="False" 
        CellSpacing="0" GridLines="None" Skin="Default" ShowHeader="false">
             <PagerStyle Mode="NextPrev" />
            <MasterTableView TableLayout="Fixed">
            <Columns>
            <telerik:GridTemplateColumn>
            <ItemTemplate>
            
            <div class="mainitem">

            <div style="background-color:LightGrey;">
           <a href="#" class="rmTemplateLink rmVideo">
           <telerik:RadBinaryImage Height="55px" Width="55px" ResizeMode="Crop" runat="server" ID="imgpro" DataValue='<%# DataBinder.Eval(Container.DataItem, "Image") %>' />
	
	<span class="rmTitle"> <%#message(Container.DataItem)%> </span>
	<span class="rmInfo">&quot;<%# DataBinder.Eval(Container.DataItem, "NText") %>' /></span>
</a>

</div>
            </div>
            </ItemTemplate>
            
            
            
            </telerik:GridTemplateColumn>
            
            </Columns>
            
            </MasterTableView>
             
            
           
    </telerik:RadGrid>




