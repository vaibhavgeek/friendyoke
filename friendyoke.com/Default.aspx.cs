using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

namespace fy
{
    public partial class Default2 : System.Web.UI.Page
    {

        DataTable dt = new DataTable();
        Db dbc = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!object.Equals(Request.Cookies["RFriend_Email"], null)) && (!object.Equals(Request.Cookies["RFriend_PWD"], null)) && (!object.Equals(Request.Cookies["RFriend_UID"], null)))
            {
                if ((!object.Equals(Request.Cookies["RFriend_Email"].Value, "")) && (!object.Equals(Request.Cookies["RFriend_PWD"].Value, "")) && (!object.Equals(Request.Cookies["RFriend_UID"], "")))
                {
                    Session["UserEmail"] = Request.Cookies["RFriend_Email"].Value;
                    Session["Password"] = Request.Cookies["RFriend_PWD"].Value;
                    Session["UserId"] = Request.Cookies["RFriend_UID"].Value;

                }
                else
                {

                }
            }
            else
            {
                Response.Redirect(ResolveUrl("~/Login.aspx"));
               
            }
            if (!Page.IsPostBack)
            {
                dt = new DataTable();
                string getuname = "select [uname] from [User] where id=" + Session["UserId"] + "";
                dt = dbc.ReturnDT(getuname);
                string uname = dt.Rows[0]["uname"].ToString();
                RadTabStrip2.Tabs.FindTabByValue("profile").NavigateUrl = "~/Menu/profile.aspx?uname=" + uname + "";


                if (Request.QueryString["menu"] == null)
                {
                    AddTab("Home");
                    AddPageView(RadTabStrip1.FindTabByText("Home"));
                    RadTabStrip1.SelectedIndex = 0;
                    AddTab("connects");
                    AddTab("settings");
                    
                }
                else
                {
                    string menu = Request.QueryString["menu"].ToString();
                    AddTab("Home");
                   
                   
                    AddTab("connects");
                    AddTab("settings");
                    AddPageView(RadTabStrip1.FindTabByText(menu));
                    RadTabStrip1.FindTabByText(menu).Selected = true;
                }
                
               
                
            }
        }
        protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
        {
            this.UpdateToolTip(args.Value, args.UpdatePanel);
        }
        private void UpdateToolTip(string elementID, UpdatePanel panel)
        {
           
                Control ctrl = Page.LoadControl("~/user-controls/footer.ascx");
                panel.ContentTemplateContainer.Controls.Add(ctrl);
                // ProductDetails details = (ProductDetails)ctrl;
                //details.ProductID = elementID;
            

        }
        private void AddTab(string tabName)
        {
            RadTab tab = new RadTab();
            tab.Text = tabName;
            tab.CssClass = "menutem";
            RadTabStrip1.Tabs.Add(tab);
        }

        protected void RadMultiPage1_PageViewCreated(object sender, RadMultiPageEventArgs e)
        {
            string userControlName = "Menu/" + e.PageView.ID + ".ascx";

            Control userControl = Page.LoadControl(userControlName);
            userControl.ID = e.PageView.ID + "what_userControl";

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



        protected void try_TabClick(object sender, RadTabStripEventArgs e)
        {
            
                Session["UserId"] = null;
                Response.Cookies["RFriend_Email"].Value = null;
                Response.Cookies["RFriend_UID"].Value = null;
                Response.Cookies["RFriend_PWD"].Value = null;
                Session.Abandon();

                System.Web.Security.FormsAuthentication.SignOut();
                Response.Redirect(ResolveUrl("~/Login.aspx"));
            
        }
}
}