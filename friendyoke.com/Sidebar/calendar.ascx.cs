using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.Calendar;
using System.Collections.Generic;

public partial class Space_calendar : System.Web.UI.UserControl
{
    public Dictionary<int, string> checkBoxIDs;

    protected void Page_Init(object sender, EventArgs e)
    {
        XmlSchedulerProvider provider;
        provider = new XmlSchedulerProvider(Server.MapPath("~/Database/Admin/Calendar/patanahiyaar@google.com/72548065.xml"), true);
        RadScheduler1.Provider = provider;
        RadScheduler1.DataBind();


    }
    private void Page_Load(object sender, EventArgs e)
    {
        keya();


        if (!IsPostBack)
        {
            RadCalendar1.SelectedDate = RadScheduler1.SelectedDate;
            SyncCalendars();
        }
    }
    public void keya()
    {
        checkBoxIDs = new Dictionary<int, string>();
        checkBoxIDs.Add(1, "chkDevelopment");
        checkBoxIDs.Add(2, "chkMarketing");
        checkBoxIDs.Add(3, "chkQ1");
        checkBoxIDs.Add(4, "chkQ2");
    }

    protected void RadScheduler1_NavigationComplete(object sender, SchedulerNavigationCompleteEventArgs e)
    {
        RadCalendar1.FocusedDate = RadScheduler1.SelectedDate;
        SyncCalendars();
    }

    protected void RadCalendar1_DefaultViewChanged(object sender, DefaultViewChangedEventArgs e)
    {
        SyncCalendars();
    }

    private void SyncCalendars()
    {
        RadCalendar2.FocusedDate = RadCalendar1.FocusedDate.AddMonths(1);
    }

    protected void RadCalendar1_SelectionChanged(object sender, SelectedDatesEventArgs e)
    {
        if (RadCalendar1.SelectedDates.Count > 0)
        {
            RadScheduler1.SelectedDate = RadCalendar1.SelectedDate;
            RadCalendar2.SelectedDate = RadCalendar1.SelectedDate;
        }
    }

    protected void RadCalendar2_SelectionChanged(object sender, SelectedDatesEventArgs e)
    {
        if (RadCalendar2.SelectedDates.Count > 0)
        {
            RadScheduler1.SelectedDate = RadCalendar2.SelectedDate;
            RadCalendar1.SelectedDate = RadCalendar2.SelectedDate;
        }
    }

    protected void RadScheduler1_AppointmentDataBound(object sender, SchedulerEventArgs e)
    {
        RadCalendarDay radCalendarDay = new RadCalendarDay(RadCalendar1);
        radCalendarDay.Date = e.Appointment.Start;
        radCalendarDay.ItemStyle.CssClass = "DayWithAppointments";
        RadCalendar1.SpecialDays.Add(radCalendarDay);
        RadCalendar2.SpecialDays.Add(radCalendarDay);

        e.Appointment.Visible = false;
        keya();
        foreach (int key in checkBoxIDs.Keys)
        {
            CheckBox chkBox = PanelBar.Items[0].Items[0].FindControl(checkBoxIDs[key]) as CheckBox;


            if (chkBox.Checked)
            {
                Resource userRes = e.Appointment.Resources.GetResource("Calendar", key.ToString());
                if (userRes != null)
                {
                    e.Appointment.Visible = true;
                }
            }
        }

    }
    protected void RadScheduler1_AppointmentDelete(object sender, SchedulerCancelEventArgs e)
    {
        RadCalendar1.SpecialDays.Clear();
        RadCalendar2.SpecialDays.Clear();
    }
    protected void RadScheduler1_AppointmentUpdate(object sender, AppointmentUpdateEventArgs e)
    {
        RadCalendar1.SpecialDays.Clear();
        RadCalendar2.SpecialDays.Clear();
    }
    protected void RadScheduler1_AppointmentInsert(object sender, SchedulerCancelEventArgs e)
    {
        if (e.Appointment.Resources.Count < 1)
            e.Appointment.Resources.Add(RadScheduler1.Resources.GetResource("Calendar", "1"));
    }
    protected void CheckBoxes_CheckedChanged(object sender, EventArgs e)
    {
        RadScheduler1.Rebind();
    }

    protected void RadScheduler1_AppointmentCreated(object sender, AppointmentCreatedEventArgs e)
    {

    }
}