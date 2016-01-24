using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Friends_ucontrols_viewconn : System.Web.UI.UserControl
{
    Db view = new Db();
    public DataSet ds;
    public DataTable dt;
    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

        string friends = "SELECT  Email, Name, Country, [Image], College,  Relationship, BirthDate, School, Company, Gender,   City, ID FROM            [User] WHERE        (ID IN (SELECT        MyID AS ID FROM            Friends WHERE        (FriendID = " + Session["UserID"] + ") AND (FriendStatus = 1) AND (FriendID <> MyID))) OR (ID IN (SELECT        FriendID AS ID FROM            Friends Friends_1 WHERE        (MyID = " + Session["UserID"] + ") AND (FriendStatus = 1) AND (FriendID <> MyID))) ORDER BY Name";
        DataTable dt = new DataTable();
        dt = view.ReturnDT(friends);
        RadGrid1.DataSource = dt;
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

        return "";

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
        string some = "";
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