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
        RadTabStrip1.OnClientTabSelecting = "onTabSelecting";
        AddTab("feednections");
        AddPageView(RadTabStrip1.FindTabByText("feednections"));
        AddTab("follow-box");
       
        AddTab("conversations");
        AddTab("my-albums");
        AddTab("labs");
        AddTab("breaktime");
        AddTab("video-galla");
        
        



    }
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    private void AddTab(string tabName)
    {
        RadTab tab = new RadTab();
        tab.Text = tabName;
        tab.CssClass = "sidebarnormal";
        tab.SelectedCssClass = "sidebarselected";
        RadTabStrip1.Tabs.Add(tab);
    }

    protected void RadMultiPage1_PageViewCreated(object sender, RadMultiPageEventArgs e)
    {
        string userControlName = "Menu/Main/" + e.PageView.ID + ".ascx";

        Control userControl = Page.LoadControl(userControlName);
        userControl.ID = e.PageView.ID + "abcd_userControl";

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