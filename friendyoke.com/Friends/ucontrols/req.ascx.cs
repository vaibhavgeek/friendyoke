using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading;

public partial class Friends_ucontrols_connect : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (!object.Equals(Session["UserId"], null))
        {
            if (e.CommandName == "Accept")
            {
                string SenderFriendId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                string MyID = Session["UserId"].ToString();
                string AcceptFriendQuery = "Update Friends set FriendStatus=1 where MyId=" + SenderFriendId + " AND FriendId=" + MyID + "";
                dbClass.DataBase(AcceptFriendQuery);
                RadGrid1.Rebind();
                Response.Redirect("~/Friends/Friend-Requests.aspx");

            }
            if (e.CommandName == "Deny")
            {
                string SenderFriendId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                string MyID = Session["UserId"].ToString();
                string AcceptFriendQuery = "Update Friends set FriendStatus=2 where MyId=" + SenderFriendId + " AND FriendId=" + MyID + "";
                dbClass.DataBase(AcceptFriendQuery);
                RadGrid1.Rebind();
                Response.Redirect("~/Friends/Friend-Requests.aspx");
            }
        }

    }
    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        string getFriendRequestQuery = "Select * FROM [User] where Id IN (SELECT MyId as Id FROM Friends WHERE FriendId=" + Session["UserId"] + " AND FriendStatus=0) ";
        dt = dbClass.ReturnDT(getFriendRequestQuery);
        if (dt.Rows.Count > 0)
        {
            RadGrid1.DataSource = dt;
            Label1.Text = "";
        }
        else
        {
            RadGrid1.Visible = false;
            Label1.Text = "No Friend Requests ";
        }
    }
    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["Id"].ToString();
        return ResolveUrl("~/PoacherHub/profile.aspx?Id=" + Id);
    }

    public string getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        string ImageName = dRView["Image"].ToString();
        if (ImageName == "" || ImageName == null)
        {
            return ResolveUrl(@"~/PoacherHub/Images/User/a1.jpg");
        }
        else
        {
            return ResolveUrl(dRView["Image"].ToString());
        }
    }
    public string name(object Name)
    {
        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Name"].ToString();
        return some;

    }
    public string company(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Company"].ToString();
        return some;

    }

    public string School(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["School"].ToString();
        return some;

    }
    public string gender(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Gender"].ToString();
        return some;

    }
    public string Age(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["BirthDate"].ToString();
        return some;

    }
    public string country(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Country"].ToString();
        return some;

    }
    public string about(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
       
        return "";

    }
    public string reletion(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Relationship"].ToString();
        return some;

    }
    public string Id(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Id"].ToString();
        return some;

    }
}