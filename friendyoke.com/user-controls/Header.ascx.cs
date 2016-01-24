using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
public partial class Design_Header : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
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
        if (!object.Equals(Session["UserId"], null))
        {
            string getpimage = @"SELECT     [User].ID, Propic.Image
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     (Propic.[Current] = 1) AND ([User].ID = "+Session["UserID"]+")";
            dt = new DataTable();
            dt = dbClass.ReturnDT(getpimage);
            if (dt.Rows[0]["Image"] is DBNull == false)
            {
                propic.Attributes.Add("onclick", "goto('Profile/profile.aspx?id="+dt.Rows[0]["ID"]+"')");
              propic.DataValue =  (byte[])dt.Rows[0]["Image"];
             
            }

        }
        else
        {
            RadToolBar1.FindButtonByCommandName("logout").Text = "Login";
        }
    }

    protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
    {
        this.UpdateToolTip(args.Value, args.UpdatePanel);
    }
    private void UpdateToolTip(string elementID, UpdatePanel panel)
    {
        Control ctrl = Page.LoadControl("Sidebar/Notification.ascx");
        panel.ContentTemplateContainer.Controls.Add(ctrl);
        // ProductDetails details = (ProductDetails)ctrl;
        //details.ProductID = elementID;
    }
   
    protected void click(object sender, RadToolBarEventArgs e)
    {
        if (RadToolBar1.FindButtonByCommandName("logout").Text == "Login")
        {

            Response.Redirect(ResolveUrl("~/Login.aspx"));

        }
        else if (RadToolBar1.FindButtonByCommandName("logout").Text == "Log Out")
        {
            if (e.Item == RadToolBar1.FindButtonByCommandName("logout"))
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

    protected void RadComboBox2_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
    {
        
        string id = e.Value.ToString();
        Response.Redirect("~/Profile/profile.aspx?Id="+id);
    }
}
