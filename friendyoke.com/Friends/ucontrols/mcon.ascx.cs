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

public partial class Friends_ucontrols_mcon : System.Web.UI.UserControl
{
    Db view = new Db();
    public DataSet ds;
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

    }






    protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        if (!object.Equals(Session["UserId"], null))
        {
            if (e.CommandName == "Remove")
            {


                string SenderFriendId = ((HtmlInputHidden)e.Item.FindControl("hiddenId")).Value;
                string MyID = Session["UserId"].ToString();
                string AcceptFriendQuery = "DELETE FROM Friends WHERE MyID=" + MyID + " AND FriendID=" + SenderFriendId + " OR (MyID = " + SenderFriendId + ") AND (FriendID = " + MyID + ")";
                view.DataBase(AcceptFriendQuery);
                RadGrid1.Rebind();
                Response.Redirect("~/Friends/Default.aspx");

            }
        }
    }

    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

        string friends = @"SELECT     [User].Email, [User].Name, [User].Country, [User].College, [User].Relationship, [User].BirthDate, [User].School, [User].Company, [User].Gender, [User].City, [User].ID, 
                      Propic.Image, [User].uname
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     ([User].ID IN
                          (SELECT     MyID AS ID
                            FROM          Friends
                            WHERE      (FriendID = "+Session["UserId"]+@") AND (FriendStatus = 1) AND (FriendID <> MyID))) AND (Propic.[Current] = 1) OR
                      ([User].ID IN
                          (SELECT     FriendID AS ID
                            FROM          Friends AS Friends_1
                            WHERE      (MyID = " + Session["UserId"] + @") AND (FriendStatus = 1) AND (FriendID <> MyID))) AND (Propic.[Current] = 1)
ORDER BY [User].Name";
        DataTable dt = new DataTable();
        dt = view.ReturnDT(friends);

        RadGrid1.DataSource = dt;
    }
    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["Id"].ToString();
        return ResolveUrl("~/Profile/profile.aspx?Id=" + Id);
    }

    public byte[] getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        byte[] ImageName = (byte[])dRView["Image"];

        return ImageName;
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
        string some ="";
        return some;

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