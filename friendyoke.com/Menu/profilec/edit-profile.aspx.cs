using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

public partial class Menu_profilec_edit_profile : System.Web.UI.Page
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


       
        RadTabStrip1.Tabs.FindTabByText("home").NavigateUrl = "~/Default.aspx?menu=Home";
        RadTabStrip1.Tabs.FindTabByText("connects").NavigateUrl = "~/Default.aspx?menu=connects";
        RadTabStrip1.Tabs.FindTabByText("settings").NavigateUrl = "~/Default.aspx?menu=settings";
        string myid = Session["UserId"].ToString();

     


      
        
      


        
            

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


   
   
    protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
    {
        this.UpdateToolTip(args.Value, args.UpdatePanel);
    }
    private void UpdateToolTip(string elementID, UpdatePanel panel)
    {
        
            Control ctrl = Page.LoadControl("~/user-controls/footer.ascx");
            ctrl.ID = "whocares";
            panel.ContentTemplateContainer.Controls.Add(ctrl);
        
       
        // ProductDetails details = (ProductDetails)ctrl;
        //details.ProductID = elementID;
    }
   

   


    
    
}