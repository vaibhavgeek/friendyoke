using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class Default22 : System.Web.UI.Page
{
  

  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            RadPageView pager = new RadPageView();
            pager.ID = RadPanelBar1.SelectedItem.Value.ToString();
            pager.Selected = true;
            RadMultiPage1.PageViews.Add(pager);
        }
    }
    protected void RadPanelBar1_ItemClick(object sender, Telerik.Web.UI.RadPanelBarEventArgs e)
    {

        RadPageView pager = new RadPageView();
        pager.ID = e.Item.Value.ToString();
        pager.Selected = true;
        RadMultiPage1.PageViews.Add(pager);
    }
    protected void RadMultiPage1_PageViewCreated(object sender, Telerik.Web.UI.RadMultiPageEventArgs e)
    {
        Control userControl = Page.LoadControl( e.PageView.ID.ToString() + ".ascx");
        userControl.ID = e.PageView.ID.ToString() + "usercontrol";
        e.PageView.Selected = true;
        e.PageView.Controls.Add(userControl);
    }
}