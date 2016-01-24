<%@ Control Language="C#" AutoEventWireup="true" CodeFile="calendar.ascx.cs" Inherits="Space_calendar" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<link rel="stylesheet" type="text/css" href="Space/styles.css"/>

<div style="padding-left:8px;">
    
    
        <script type="text/javascript">

            /* Firefox resize scrollable content */
            function hideScrollableArea(sender, eventArgs) {
                if ($telerik.isFirefox)
                    $telerik.$('.rsContentScrollArea').css('overflow', 'hidden');
            }
            function showScrollableArea(sender, eventArgs) {
                if ($telerik.isFirefox)
                    $telerik.$('.rsContentScrollArea').css('overflow', 'auto');
            }
    
        </script>

        <telerik:RadAjaxManager runat="Server" ID="RadAjaxManager1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="RadCalendar1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadCalendar2" />
                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadCalendar2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadCalendar1" />
                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="chkDevelopment">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="chkMarketing">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="chkQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="chkQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadScheduler1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadScheduler1" LoadingPanelID="RadAjaxLoadingPanel1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Office2007" />
        <div class="example-panel">
            
            <telerik:RadSplitter runat="server" ID="RadSplitter1" PanesBorderSize="0" Width="734px"
                Height="552px" Skin="Office2007">
                <telerik:RadPane runat="Server" ID="leftPane" Width="228px" MinWidth="228" MaxWidth="300"
                    Scrolling="None" OnClientResizing="hideScrollableArea" OnClientResized="showScrollableArea"
                    OnClientExpanding="hideScrollableArea" OnClientExpanded="showScrollableArea"
                    OnClientCollapsing="hideScrollableArea" OnClientCollapsed="showScrollableArea">
                    <div class="calendar-container">
                        <telerik:RadCalendar runat="server" ID="RadCalendar1" Skin="Windows7" AutoPostBack="true"
                            EnableMultiSelect="false" DayNameFormat="FirstTwoLetters" EnableNavigation="true"
                            EnableMonthYearFastNavigation="false" OnSelectionChanged="RadCalendar1_SelectionChanged"
                            OnDefaultViewChanged="RadCalendar1_DefaultViewChanged">
                            <WeekendDayStyle CssClass="rcWeekend" />
                            <CalendarTableStyle CssClass="rcMainTable" />
                            <OtherMonthDayStyle CssClass="rcOtherMonth" />
                            <OutOfRangeDayStyle CssClass="rcOutOfRange" />
                            <DisabledDayStyle CssClass="rcDisabled" />
                            <SelectedDayStyle CssClass="rcSelected" />
                            <DayOverStyle CssClass="rcHover" />
                            <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Windows7" />
                            <ViewSelectorStyle CssClass="rcViewSel" />
                        </telerik:RadCalendar>
                        <telerik:RadCalendar runat="server" ID="RadCalendar2" Skin="Windows7" AutoPostBack="true"
                            EnableMultiSelect="false" DayNameFormat="FirstTwoLetters" EnableNavigation="false"
                            EnableMonthYearFastNavigation="false" 
                            OnSelectionChanged="RadCalendar2_SelectionChanged">
                            <WeekendDayStyle CssClass="rcWeekend" />
                            <CalendarTableStyle CssClass="rcMainTable" />
                            <OtherMonthDayStyle CssClass="rcOtherMonth" />
                            <OutOfRangeDayStyle CssClass="rcOutOfRange" />
                            <DisabledDayStyle CssClass="rcDisabled" />
                            <SelectedDayStyle CssClass="rcSelected" />
                            <DayOverStyle CssClass="rcHover" />
                            <FastNavigationStyle CssClass="RadCalendarMonthView RadCalendarMonthView_Windows7" />
                            <ViewSelectorStyle CssClass="rcViewSel" />
                        </telerik:RadCalendar>
                    </div>
                    <telerik:RadPanelBar runat="server" Skin="Windows7" ID="PanelBar" Width="220px">
						<Items>
							<telerik:RadPanelItem runat="server" Text="Calendar Labels" Expanded="true">
								<Items>
									<telerik:RadPanelItem runat="server">
										<ItemTemplate>
											<div class="rpCheckBoxPanel">
												<div>
													<asp:CheckBox ID="chkDevelopment" runat="server" Text="Development" Checked="true"
														AutoPostBack="true" OnCheckedChanged="CheckBoxes_CheckedChanged" />
												</div>
												<div>
													<asp:CheckBox ID="chkMarketing" runat="server" Text="Marketing" Checked="true" AutoPostBack="true"
														OnCheckedChanged="CheckBoxes_CheckedChanged" />
												</div>
                                                <div>
													<asp:CheckBox ID="chkQ1" runat="server" Text="Personal" Checked="true" AutoPostBack="true"
														OnCheckedChanged="CheckBoxes_CheckedChanged" />
												</div>
												<div>
													<asp:CheckBox ID="chkQ2" runat="server" Text="Work" Checked="true" AutoPostBack="true"
														OnCheckedChanged="CheckBoxes_CheckedChanged" />
												</div>
											</div>
										</ItemTemplate>
									</telerik:RadPanelItem>
								</Items>
							</telerik:RadPanelItem>
							
						</Items>
					</telerik:RadPanelBar>
                </telerik:RadPane>
                <telerik:RadSplitBar runat="server" ID="RadSplitBar2" CollapseMode="Forward" />
                <telerik:RadPane runat="Server" ID="rightPane" Scrolling="None" Width="490px">
                    <telerik:RadScheduler runat="server" ID="RadScheduler1" Skin="Windows7"
                        Height="551px" ShowFooter="false"
                        SelectedDate="2009-02-02" TimeZoneOffset="03:00:00"
                        DayStartTime="08:00:00" DayEndTime="21:00:00"                        
                        FirstDayOfWeek="Monday" LastDayOfWeek="Sunday"
                        EnableDescriptionField="true"
                        OnNavigationComplete="RadScheduler1_NavigationComplete"
                        OnAppointmentDataBound="RadScheduler1_AppointmentDataBound"
                        OnAppointmentDelete="RadScheduler1_AppointmentDelete"
                        OnAppointmentUpdate="RadScheduler1_AppointmentUpdate"
                        OnAppointmentInsert="RadScheduler1_AppointmentInsert" 
                        onappointmentcreated="RadScheduler1_AppointmentCreated">
                        <AdvancedForm Modal="true" />
                        <TimelineView UserSelectable="false" />
                        <ResourceStyles>
                            <telerik:ResourceStyleMapping Type="Calendar" Text="Development" ApplyCssClass="rsCategoryGreen" />
                            <telerik:ResourceStyleMapping Type="Calendar" Text="Marketing" ApplyCssClass="rsCategoryRed" />
                            <telerik:ResourceStyleMapping Type="Calendar" Text="Work" ApplyCssClass="rsCategoryOrange" />
                        </ResourceStyles>
                        <AppointmentTemplate>
                            <div class="rsAptSubject">
                                <%# Eval("Subject") %>
                            </div>
                            <%# Eval("Description") %>
                        </AppointmentTemplate>
         <TimeSlotContextMenuSettings EnableDefault="true" />
         <AppointmentContextMenuSettings EnableDefault="true" />
                    </telerik:RadScheduler>
                </telerik:RadPane>
            </telerik:RadSplitter>
        </div>
    
    
                    
                  
                    </div>