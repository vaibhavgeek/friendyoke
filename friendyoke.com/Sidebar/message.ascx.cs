using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Space_message : System.Web.UI.UserControl
{
    protected void Page_Init(object sender, EventArgs e)
    {

        AddTab("Inbox");
        AddPageView(RadTabStrip1.FindTabByText("Inbox"));
        AddTab("Compose");
        AddTab("Sent-Messages");
        RadTabStrip1.OnClientTabSelecting = "onTabSelecting";



    }
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    private void AddTab(string tabName)
    {
        RadTab tab = new RadTab();
        tab.Text = tabName;
        RadTabStrip1.Tabs.Add(tab);
    }

    protected void RadMultiPage1_PageViewCreated(object sender, RadMultiPageEventArgs e)
    {
        string userControlName = "Sidebar/messageu/" + e.PageView.ID + ".ascx";

        Control userControl = Page.LoadControl(userControlName);
        userControl.ID = e.PageView.ID + "_userControl";

        e.PageView.Controls.Add(userControl);
    }

    private void AddPageView(RadTab tab)
    {
        RadPageView pageView = new RadPageView();
        pageView.ID = tab.Text;
        RadMultiPage1.PageViews.Add(pageView);
        tab.PageViewID = pageView.ID;
    }

    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        AddPageView(e.Tab);
        e.Tab.PageView.Selected = true;
    }


}