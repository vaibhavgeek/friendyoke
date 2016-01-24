<%@ Control Language="C#" AutoEventWireup="true" CodeFile="leftm.ascx.cs" Inherits="Design_leftm" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %><asp:Panel ID="Panel4" runat="server" BackColor="White"  Width="229px"  
                                    > <telerik:RadPanelBar ID="RadPanelBar1" Runat="server" Skin="Office2007" 
    Width="210px">
    <Items>
        <telerik:RadPanelItem runat="server" NavigateUrl="~/PoacherHub/newsfeed.aspx" 
            Owner="RadPanelBar1" Text="News Feed">
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Owner="RadPanelBar1" PostBack="False" 
            PreventCollapse="True" Text="Messages">
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Expanded="True" Text="Knock Knowledge">
            <Items>
                <telerik:RadPanelItem runat="server" Owner="" Text="Quiz And Earn Points">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Owner="" Text="Manage Knowledge Pages">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Owner="" Text="Become An Author and Earn">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Expanded="True" Owner="RadPanelBar1" 
            Text="More At Groupster">
            <Items>
                <telerik:RadPanelItem runat="server" 
                    NavigateUrl="~/PoacherHub/more/breaktime.aspx" Text="Break-Time">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Free Sms from Your Phone (India)">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="SnapDeals Free Coupons">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Expanded="True" Text="My Space">
            <Items>
                <telerik:RadPanelItem runat="server" Text="Manage Groups">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="My Box (Photos,Videos &amp; .etc)">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Owner="" Text="My Diary (Blog)">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" 
                    NavigateUrl="~/PoacherHub/meadnmine/calender.aspx" Text="My Calender">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Expanded="True" Owner="RadPanelBar1" 
            PostBack="False" Text=" Games And Apllications">
            <Items>
                <telerik:RadPanelItem runat="server" Owner="" Text="Games">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Owner="" Text="Application">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Expanded="True" Owner="RadPanelBar1" 
            PostBack="False" Text="Groupster Gallery">
            <Items>
                <telerik:RadPanelItem runat="server" Owner="" Text="Video Gallery">
                </telerik:RadPanelItem>
                <telerik:RadPanelItem runat="server" Text="Music Hub">
                </telerik:RadPanelItem>
            </Items>
        </telerik:RadPanelItem>
        <telerik:RadPanelItem runat="server" Text="Friends Online">
            <ItemTemplate>
                <div style="color: #000000">
                    &nbsp;&nbsp;&nbsp;Images Of Online Friends</div>
            </ItemTemplate>
        </telerik:RadPanelItem>
    </Items>
</telerik:RadPanelBar>

</asp:Panel><asp:RoundedCornersExtender ID="Panel3_RoundedCornersExtender" runat="server" 
                                    BorderColor="ActiveBorder" Enabled="True" Radius="15" TargetControlID="Panel4">
                                </asp:RoundedCornersExtender>

