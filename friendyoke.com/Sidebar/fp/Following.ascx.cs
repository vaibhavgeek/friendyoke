using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Public_Profiles_Suscribed_Feeds : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void datasource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        bindit();
    }
    public void bindit()
    {

        string getUserScraps = @"SELECT     [User].Name, [User].ID, s.MyID, s.SID, s.ID AS NID, [User].Email, [User].Country, [User].RegisterDate, [User].College, [User].BirthDate, [User].Relationship, 
                      [User].School, [User].Company, [User].Gender, [User].City, Networks.Facebook, Networks.Linkedin, Networks.Twitter, Networks.Plus, [User].Degree, [User].Phone, 
                      [User].uname, [User].Status, [User].Designation, Propic.Image
FROM         [User] INNER JOIN
                      Box AS s ON [User].ID = s.SID INNER JOIN
                      Networks ON [User].ID = Networks.UID INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     ([User].ID IN
                          (SELECT     s.SID AS ID
                            FROM          Box AS Friends_2
                            WHERE      (MyID = " + Session["UserId"] + @") AND (s.SID <> " + Session["UserId"] + @"))) AND (Propic.[Current] = 1)
ORDER BY NID DESC";
        dt = dbClass.ReturnDT(getUserScraps);
        if (dt.Rows.Count > 0)
        {
            followingpp.DataSource = dt;

        }
        else
        {
            followin.Text = "You Are Currently Following 0 People";
        }

    }
    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["Id"].ToString();
        return ResolveUrl("~/Profile/profile.aspx?Id=" + Id);
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
    protected void followingpp_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {

    }
}