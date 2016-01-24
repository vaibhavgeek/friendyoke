using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class Ement_games : System.Web.UI.UserControl
{
    protected void Page_Init(object sender, EventArgs e)
    {
       // AddTab("Tetris");
        //AddPageView(RadTabStrip1.FindTabByText("Tetris"));
       // AddTab("Pacman");
      //  AddTab("Hexagon");
       // AddTab("Tic-Tac-Toe");
       // AddTab("Simon");
    
    }
    
    private void AddTab(string tabName)
    {
        RadTab tab = new RadTab();
        tab.Text = tabName;
        R1.Tabs.Add(tab);
    }

   protected void RadMultiPage2_PageViewCreated(object sender, RadMultiPageEventArgs e)
    {
        string userControlName = "Sidebar/gamesu/Files/" + e.PageView.ID + ".ascx";

        Control userControl = Page.LoadControl(userControlName);
        userControl.ID = e.PageView.ID + "_userControl";

        e.PageView.Controls.Add(userControl);
    }

    private void AddPageView(RadTab tab)
    {
        RadPageView pageView = new RadPageView();
        pageView.ID = tab.Text;
        RadMultiPage5.PageViews.Add(pageView);

        tab.PageViewID = pageView.ID;
    }
    
    protected void RadTabStrip1_TabClick(object sender, RadTabStripEventArgs e)
    {
        AddPageView(e.Tab);
        e.Tab.PageView.Selected = true;
    }
}
