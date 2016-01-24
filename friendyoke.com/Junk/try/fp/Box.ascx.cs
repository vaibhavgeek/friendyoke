using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Public_Profiles_Just_Get_Feeds : System.Web.UI.UserControl
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

        string getUserScraps = "SELECT        [User].Name, [User].Image, [User].ID, s.FromID, s.Message, s.SendDate, s.SendTime, s.ID AS NID FROM            [User] INNER JOIN newsfeed AS s ON [User].ID = s.FromID WHERE        ([User].ID IN  (SELECT        SID AS ID  FROM            Box AS Friends_2  WHERE        (MyID = "+Session["UserId"]+"))) ORDER BY NID DESC";
        dt = dbClass.ReturnDT(getUserScraps);
        if (dt.Rows.Count > 0)
        {
            RadGrid1.DataSource = dt;

        }
        else
        {
            sorry.Visible = true;
            sorry.Text = "You Have Not Added anyone on your box , Just Click Browse Intrests on your top left to follow your Intrests and add People Who inspire you .";
            RadGrid1.Visible = false;
        }

    }
    public string Email(string emall)
    {
        emall = Session["UserEmail"].ToString();
        return emall;

    }

    public string getUserHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["Id"].ToString();

        return ResolveUrl("~/Profile/profile.aspx?Id=" + Id);
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
    public string sendname(object Name)
    {
        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Name"].ToString();
        return some;



    }
    public string ID(object ID)
    {
        DataRowView dRView = (DataRowView)ID;

        string id = dRView["NID"].ToString();
        return ResolveUrl("~/NewsFeed/Feed.aspx?Nid=" + id);



    }
}