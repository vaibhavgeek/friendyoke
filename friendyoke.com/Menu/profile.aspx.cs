using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
public partial class Menu_profile : System.Web.UI.Page
{
   public DataTable dt;
   
   Db pro = new Db();
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

        dt = new DataTable();
        string getuname = "select [uname] from [User] where id=" + Session["UserId"] + "";
        dt = pro.ReturnDT(getuname);
        string myuname = dt.Rows[0]["uname"].ToString();
        RadTabStrip2.Tabs.FindTabByValue("profile").NavigateUrl = "~/Menu/profile.aspx?uname=" + myuname + "";


        RadTabStrip3.OnClientTabSelecting = "onTabSelecting";
        RadTabStrip1.Tabs.FindTabByText("home").NavigateUrl = "~/Default.aspx?menu=Home";
        RadTabStrip1.Tabs.FindTabByText("connects").NavigateUrl = "~/Default.aspx?menu=connects";
        RadTabStrip1.Tabs.FindTabByText("settings").NavigateUrl = "~/Default.aspx?menu=settings";
        string uname = Request.QueryString["uname"].ToString();
        string getall = @"select [ID] from [User] where [uname] = '"+uname+"'";
        dt = new DataTable();
        dt = pro.ReturnDT(getall);
        string vid = dt.Rows[0]["ID"].ToString();
        string myid = Session["UserId"].ToString();

        string getstatus = @"SELECT     MyID, FriendID, FriendStatus
FROM         Friends
WHERE     (MyID = "+ myid+@") AND (FriendID = "+vid+@") OR
                      (MyID = "+vid+@") AND (FriendID = "+ myid+@")";
         DataTable dt2 = new DataTable();
        dt2 = pro.ReturnDT(getstatus);

        DataTable dt3 = new DataTable();
        string getboxstat = @"SELECT     MyID, SID, FollowDate, FollowStatus
FROM         Box
WHERE     (MyID = "+myid+") AND (SID = "+vid+")";
        dt3 = pro.ReturnDT(getboxstat);


        string getme = @"SELECT     [User].Name, [User].BirthDate, [User].Gender, [User].Country, [User].RegisterDate, [User].City, 
                      [User].Status, [User].uname, [User].Degree,  Propic.Image,  
                      Networks.Facebook, Networks.Twitter, Contact.Website,[User].[looking for]
                      
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID INNER JOIN
                      
                      Networks ON [User].ID = Networks.UID INNER JOIN
                      Contact ON [User].ID = Contact.UID 
                      
WHERE     (Propic.[Current] = 1) AND ([User].ID = " + vid + ")";
        DataTable pri = new DataTable();
        pri = pro.ReturnDT(getme);
        if (pri.Rows[0]["Image"] is DBNull == false)
        {
            propic.DataValue = (byte[])pri.Rows[0]["Image"];
        } dob.Text = pri.Rows[0]["BirthDate"].ToString();
        gen.Text = pri.Rows[0]["Gender"].ToString();
        web.Text = pri.Rows[0]["Website"].ToString();
        fb.Text = pri.Rows[0]["Facebook"].ToString();
        twit.Text = pri.Rows[0]["Twitter"].ToString();
        if (pri.Rows[0]["Status"] is DBNull)
        {
            som.Text = "has not yet put a state of mind(SOM)";
        }
        else
        {
            som.Text = pri.Rows[0]["Status"].ToString();
        } name.Text = pri.Rows[0]["Name"].ToString();
        un.Text = pri.Rows[0]["uname"].ToString();
            

        if (myid == vid)
        {
            
            if (!Page.IsPostBack)
            {
                
                AddTab("info");
                AddPageView(RadTabStrip3.FindTabByText("info"));
                AddTab("recent-posts");
                AddTab("connections");
                AddTab("inside-box");
                AddTab("albums");
               // key ==>
                /*
                 * contact = info
                 * posts = recent-posts
                 * more = connections
                 *  eduwork = inside-box 
                 *  photos = albums
                 */
            }

           

            but1.Text = "edit profile";
            but1.CommandName = "ep";
            
            but2.Text = "change profile picture";
            but2.CommandName = "cpp";

            RadWindow rnd = new RadWindow();
            rnd.NavigateUrl = "~/Menu/profilec/cpp.aspx";
            rnd.Visible = true;
            rnd.OpenerElementID = "but2";
            rnd.EnableEmbeddedSkins = false;
            rnd.VisibleStatusbar = false;
            rnd.VisibleTitlebar = true;
            rnd.Modal = true;
            rnd.AutoSize = true;
            Panel2.Controls.Add(rnd);

            but3.Text = "privacy settings";
            but3.CommandName = "ps";
        //urself
        }
        else if (dt2.Rows.Count > 0)
        {
            int n = (int)dt2.Rows[0]["FriendStatus"];
            string ida = dt2.Rows[0]["MyID"].ToString();
            string idb = dt2.Rows[0]["FriendID"].ToString();
            switch (n)
            {
                case 0:
                    if (ida == Session["UserId"].ToString())
                    {
                        // i sent the request , i can cancel it
                        if (dt3.Rows.Count > 0)
                        {
                            but2.Text = "remove from box";
                            but2.CommandName = "rfb";
                            //added to box .. remove from box 
                        }
                       
                    }
                    else
                    {
                        if (!Page.IsPostBack)
                        {
                            AddTab("info");
                            AddPageView(RadTabStrip3.FindTabByText("info"));
                            AddTab("recent-posts");
                            AddTab("connections");
                            AddTab("inside-box");
                            AddTab("albums");
                            // i have the request i can accecpt it
                            if (dt3.Rows.Count > 0)
                            {
                                but2.Text = "remove from box";
                                but2.CommandName = "rfb";
                                //added to box .. remove from box 
                            }
                        }
                        
                    }
                    break;
                case 1:
                    if (!Page.IsPostBack)
                    {
                        AddTab("info");
                        AddPageView(RadTabStrip3.FindTabByText("info"));
                        AddTab("recent-posts");
                        AddTab("connections");
                        AddTab("inside-box");
                        AddTab("albums");
                    }
                    but1.Text = "view photos";
                     but1.ID = "vp";
                     RadToolTipManager2.TargetControls.Add("vp");
                    
                    but2.Text = "message him";
                    but2.CommandName = "mh";

                    but3.Text = "remove from connections";
                    but3.CommandName = "rfc";
                    // he is a friend
                    if (dt3.Rows.Count > 0)
                    {
                        but2.Text = "remove from box";
                        but2.CommandName = "rfb";
                        //added to box .. remove from box 
                    }
                    break;


            }
         
           
            
        }
        else
        {
            if (dt3.Rows.Count > 0)
            {
                //added to box .. remove from box 
            }
            // key ==>
            /*
             * contact = info
             * posts = recent-posts
             * more = connections
             *  eduwork = inside-box 
             *  photos = albums
             */
            string getsettings = @"SELECT     addfyoke, messageh, contact, more, photos, posts , eduwork
FROM         [User]
WHERE     (ID = " +vid+")";

            DataTable asd = new DataTable();
            asd = pro.ReturnDT(getsettings);

           

            if (!Page.IsPostBack)
            {
                if ((int)asd.Rows[0]["contact"] == 0)
                {
                    AddTab("info");
                    AddPageView(RadTabStrip3.FindTabByText("info"));
                }
                if ((int)asd.Rows[0]["posts"] == 0)
                {
                    AddTab("recent-posts");
                }
                if ((int)asd.Rows[0]["more"] == 0)
                {
                    AddTab("connections");
                }
                if ((int)asd.Rows[0]["eduwork"] == 0)
                {
                    AddTab("inside-box");
                }
                if ((int)asd.Rows[0]["photos"] == 0)
                {
                    AddTab("albums");
                }
              //  AddTab("info");
              //  AddPageView(RadTabStrip3.FindTabByText("info"));
               // AddTab("recent-posts");
              //  AddTab("connections");
               // AddTab("inside-box");
               // AddTab("albums");
                // i have the request i can accecpt it
                if (dt3.Rows.Count > 0)
                {
                    but2.Text = "remove from box";
                    but2.CommandName = "rfb";
                    //added to box .. remove from box 
                }
            }
            but1.Text = "add on friendyoke";
            but1.CommandName = "aof";

            but2.Text = "add to box";
            but2.CommandName = "atb";

            but3.Text = "message him";
            but3.CommandName = "mh";
        // he is random
           
           
        }

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


    private void AddTab(string tabName)
    {
        RadTab tab = new RadTab();
        tab.Text = tabName;
        tab.CssClass = "sidebarnormal";
        tab.SelectedCssClass = "sidebarselected";
        RadTabStrip3.Tabs.Add(tab);
    }

    protected void RadMultiPage1_PageViewCreated(object sender, RadMultiPageEventArgs e)
    {
        string userControlName = "profilec/" + e.PageView.ID + ".ascx";

        Control userControl = Page.LoadControl(userControlName);
        userControl.ID = e.PageView.ID + "dev_userControl";

        e.PageView.Controls.Add(userControl);
    }
    protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
    {
        this.UpdateToolTip(args.Value, args.UpdatePanel);
    }
    private void UpdateToolTip(string elementID, UpdatePanel panel)
    {
        if (elementID.StartsWith("notifi"))
        {
            Control ctrl = Page.LoadControl("~/user-controls/footer.ascx");
            ctrl.ID = "whocares";
            panel.ContentTemplateContainer.Controls.Add(ctrl);
        }
        else
        {
            Control ctrl = Page.LoadControl("~/Menu/profilec/view-photos-friends.ascx");
            ctrl.ID = "idomoron";
            panel.ContentTemplateContainer.Controls.Add(ctrl);
        }
        // ProductDetails details = (ProductDetails)ctrl;
        //details.ProductID = elementID;
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


   
    protected void but1_Click(object sender, EventArgs e)
    {
        if (but1.CommandName == "ep")
        {
            Response.Redirect(ResolveUrl("~/Menu/profilec/edit-profile.aspx"));
        }
    }
    protected void but2_Click(object sender, EventArgs e)
    {
        if (but2.CommandName == "cpp")
        {
           /* RadWindow rnd = new RadWindow();
            rnd.NavigateUrl = "~/Menu/profilec/cpp.aspx";
            rnd.Visible = true;
            rnd.VisibleOnPageLoad = true;
            rnd.EnableEmbeddedSkins = false;
            rnd.VisibleStatusbar = false;
            rnd.VisibleTitlebar = true;
            rnd.Modal = true;
            rnd.AutoSize = true;*/
            //Panel2.Controls.Add(rnd);
        }
    }
    protected void but3_Click(object sender, EventArgs e)
    {
        if (but3.CommandName == "ps")
        {
            Response.Redirect(ResolveUrl("~/Default.aspx?menu=settings"));
           
        
        }
        if (but3.CommandName == "rfc")
        {
           /* string uname = Request.QueryString["uname"].ToString();
            RadWindow rnd = new RadWindow();
            rnd.NavigateUrl = "~/Menu/profilec/cremove.aspx?uname="+uname+"";
            rnd.Visible = true;
            rnd.VisibleOnPageLoad = true;
            rnd.EnableEmbeddedSkins = false;
            rnd.VisibleStatusbar = false;
            rnd.VisibleTitlebar = true;
            rnd.Modal = true;
            rnd.Height = 245;
            rnd.Width = 320;
           
            Panel2.Controls.Add(rnd);*/
        
        }
    }
}