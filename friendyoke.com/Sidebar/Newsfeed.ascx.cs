using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telerik.Web.UI;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
public partial class Newsfeed_Newsfeed : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
       
      
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        thecbox.Visible = false;
    }
    protected void postfeed_Click(object sender, EventArgs e)
    {
        if (RadTabStrip1.SelectedIndex == 0)
        {
            if (maincontent.Text == "" || maincontent.Text == null)
            {

            }
            else
            {
                string conntenn = maincontent.Text;
                conntenn = conntenn.Replace("\n", "<br/>");
                conntenn = conntenn.Replace("\r", "&nbsp;&nbsp;");
                string postScrap = @"Insert INTO newsfeed (FromId,Message,SendDate,SendTime,P) 
                                    VALUES('" + Session["UserId"].ToString() + "','" + conntenn + "','" + System.DateTime.Now.Date.Day.ToString() + "/" + DateTime.Now.Date.Month.ToString() + "' , '" + System.DateTime.Now.ToShortTimeString() + "',1)";
                dbClass.DataBase(postScrap);
                maincontent.Text = "";
            }
        }
        else if (RadTabStrip1.SelectedIndex == 1)
        {
            int uid = int.Parse(Session["UserId"].ToString());
            Random ran = new Random();
            int arbit = ran.Next();
            string getjuspostsql = @"SELECT     ID
FROM         Albums
WHERE     (Name = 'Just Post..') AND (UID = " + uid + ")";

            ds = new DataSet();
            ds = dbClass.ReturnDS(getjuspostsql);

            int albummid = (int)ds.Tables[0].Rows[0]["ID"];

            using (Stream stream = justadd.UploadedFiles[0].InputStream)
            {

                byte[] imageData = new byte[stream.Length];
                stream.Read(imageData, 0, (int)stream.Length);
                SqlConnection connection = new
            SqlConnection(@"Data Source=V-PC\SQLEXPRESS;Initial Catalog=maindb1;Integrated Security=True");
                try
                {
                    // INSERT INTO table_name
                    //VALUES (value1, value2, value3,...)
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Photos (Photo , UID , AlbumID , Random) values  "
                      + "(@img," + uid + ", " + albummid + " , " + arbit + ")", connection);
                    cmd.Parameters.Add("@img", imageData);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

            }
            string selectarbit = "Select * From Photos WHERE Random = " + arbit + "";
            dt = new DataTable();
            dt = dbClass.ReturnDT(selectarbit);
            int phid = int.Parse(dt.Rows[0]["ID"].ToString());
            string conntenn = maincontent.Text;
            conntenn = conntenn.Replace("\n", "<br/>");
            conntenn = conntenn.Replace("\r", "&nbsp;&nbsp;");
            string ins2nfeed = "insert into newsfeed (P,FromID,Message,SendDate,SendTime) values (" + phid + "," + Session["UserId"] + ",'" + conntenn + "','" + System.DateTime.Now.Date.Day.ToString() + "/" + DateTime.Now.Date.Month.ToString() + "' , '" + System.DateTime.Now.ToShortTimeString() + "')";
            dbClass.DataBase(ins2nfeed);

        }
    }
    protected void createalbum_Click(object sender, EventArgs e)
    {

    }
    protected void addtoalbum_Click(object sender, EventArgs e)
    {

    }
    public void bindit()
    {
        string getfeed = @"SELECT     newsfeed.FromID, newsfeed.Message, newsfeed.SendDate, newsfeed.SendTime, newsfeed.P, newsfeed.ID AS NID, [User].Name, Propic.Image AS profilepic, Photos.Photo, 
                      Albums.Name AS aname, Albums.ID AS aid, [User].ID, newsfeed.AlID
FROM         newsfeed INNER JOIN
                      [User] ON newsfeed.FromID = [User].ID INNER JOIN
                      Propic ON newsfeed.FromID = Propic.UID INNER JOIN
                      Photos ON newsfeed.P = Photos.ID INNER JOIN
                      Albums ON Photos.AlbumID = Albums.ID
WHERE     ([User].ID IN
                          (SELECT     MyID AS ID
                            FROM          Friends AS Friends_2
                            WHERE      (FriendID = " + Session["UserId"] + @") AND (FriendStatus = 1))) AND (Propic.[Current] = 1)  OR
                      ([User].ID IN
                          (SELECT     FriendID AS ID
                            FROM          Friends AS Friends_1
                            WHERE      (MyID = " + Session["UserId"] + @") AND (FriendStatus = 1))) AND (Propic.[Current] = 1) 
ORDER BY NID DESC";

        dt = dbClass.ReturnDT(getfeed);

        if (dt.Rows.Count > 0)
        {
            RadGrid1.DataSource = dt;

        }
        else
        {
            RadGrid1.Visible = false;
            frndsn.Text = "You do not have any newsfeed,ask your friends to connect , share and enjoy! ";
        }

    }
    //Public Strings For Radgrid1
    public string displayy(object commnet)
    {
        DataRowView dRView = (DataRowView)commnet;
        if (dRView["Photo"] is DBNull)
        {
            return "none";
        }
        else
        {
            return "";
        }
    }
    public string Comment(object commnet)
    {
        DataRowView dRView = (DataRowView)commnet;
        DataTable dt = new DataTable();

        if (dRView["P"].ToString() != "1" && dRView["AlID"]  is  DBNull == false)
        {
            string getcvalue = "SELECT * FROM AlbumComments WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            string somep = dt.Rows.Count.ToString() + " Comments";
            return somep;
            //return "album" + dRView["AlID"].ToString();
        }
        else if (dRView["AlID"] is DBNull == false)
        {
            string getcvalue = "SELECT * FROM AlbumComments WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            string somep = dt.Rows.Count.ToString() + " Comments";
            return somep;
            //return "album" + dRView["AlID"].ToString();
        }
        else if (dRView["P"].ToString() != "1")
        {
            string getcvalue = "SELECT * FROM PhotoComments WHERE PID = " + (int)dRView["P"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            string somep = dt.Rows.Count.ToString() + " Comments";
            return somep;
            //return "photo" + dRView["P"].ToString();
        }
        else
        {
            string getcvalue = "SELECT * FROM Comments WHERE ItemID = " + (int)dRView["NID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            string somep = dt.Rows.Count.ToString() + " Comments";
            return somep;
            //return "comment" + dRView["NID"].ToString();
        }
        
      /*  string k = dRView["NID"].ToString();
        int f = int.Parse(k);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);
        //For Comments
        DataTable dt = new DataTable();
        string getcvalue = "SELECT * FROM Comments WHERE ItemID = " + f + "";
        dt = dbClass.ReturnDT(getcvalue);
        string somep = dt.Rows.Count.ToString() + " Comments";
        return somep;*/

    }
    public string det(object ruchitadi)
    {
        DataRowView dRView = (DataRowView)ruchitadi;
        if (dRView["P"].ToString() != "1" && dRView["AlID"] is DBNull == false)
        {
            return "album" + dRView["AlID"].ToString();

        }
        else if (dRView["AlID"] is DBNull == false)
        {
            return "album" + dRView["AlID"].ToString();
        }
        else if (dRView["P"].ToString() != "1")
        {
            return "photo" + dRView["P"].ToString();
        }
        else
        {
            return "comment" + dRView["NID"].ToString();
        }
    }
    public string phew(object phew)
    {
        DataRowView dRView = (DataRowView)phew;
        DataTable dt = new DataTable();
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);
    

        if (dRView["P"].ToString() != "1" && dRView["AlID"] is DBNull == false)
        {

            string getcvalue = "SELECT * FROM PhewAlbums WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "Unphew(" + dt.Rows.Count.ToString() + ")";
                    return somep;
                }
                else
                {
                    string somepa = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                    return somepa;
                }
            }
            string abc = "Phew It!(" + dt.Rows.Count.ToString() + ")";
            return abc;
            // return "album" + dRView["AlID"].ToString();

        }
        else if (dRView["AlID"] is DBNull == false)
        {

            string getcvalue = "SELECT * FROM PhewAlbums WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "Unphew(" + dt.Rows.Count.ToString() + ")";
                    return somep;
                }
                else
                {
                    string somepa = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                    return somepa;
                }
            }
            string abc = "Phew It!(" + dt.Rows.Count.ToString() + ")";
            return abc;
            //return "album" + dRView["AlID"].ToString();
        }
        else if (dRView["P"].ToString() != "1")
        {
            string getcvalue = "SELECT * FROM PhewPhotos WHERE PID = " + (int)dRView["P"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "Unphew(" + dt.Rows.Count.ToString() + ")";
                    return somep;
                }
                else
                {
                    string somepa = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                    return somepa;
                }
            }
            string abc = "Phew It!(" + dt.Rows.Count.ToString() + ")";
            return abc;
            // Phew Photos
        }
        else
        {
            string getcvalue = "SELECT * FROM Phew WHERE NID = " + (int)dRView["NID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "Unphew(" + dt.Rows.Count.ToString() + ")";
                    return somep;
                }
                else
                {
                    string somepa = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                    return somepa;
                }
            }
            return "Phew It!(" + dt.Rows.Count.ToString() + ")";
           // return "comment" + dRView["NID"].ToString();
        }
        
        
        
        
        /* string k = dRView["NID"].ToString();
        int f = int.Parse(k);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);

        //For Phew
        DataTable dt = new DataTable();

        string getcvalue = "SELECT * FROM Phew WHERE NID = " + f + "";
        dt = dbClass.ReturnDT(getcvalue);
        foreach (DataRow row in dt.Rows)
        {
            if (userii.ToString() == row["UID"].ToString())
            {

                string somep = "Unphew(" + dt.Rows.Count.ToString() + ")";
                return somep;
            }
            else
            {
                string somepa = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                return somepa;
            }
        }
        return "Phew It!(" + dt.Rows.Count.ToString() + ")";
        */
    }
    public string albumcolor(object like)
    {
        DataRowView dRView = (DataRowView)like;
        if (dRView["AlID"] is DBNull)
        {
            return null;



        }
        else
        {
            return "<h4 style='width:370px;' class='mainheader'> New Album!: <span style='font-size:18px;'>" + dRView["aname"].ToString() + "</span></h4>";

        }
    }
    public string like(object like)
    {
        DataRowView dRView = (DataRowView)like;
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);
        if (dRView["P"].ToString() != "1" && dRView["AlID"] is DBNull == false)
        {

            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [LikeAlbums] WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "Unlike(" + dt.Rows.Count.ToString() + ")";
                    return somep;
                }
                else
                {
                    string somepa = "Like(" + dt.Rows.Count.ToString() + ")";
                    return somepa;
                }
            }
            return "Like(" + dt.Rows.Count.ToString() + ")";
            //return "album" + dRView["AlID"].ToString();

        }
        else if (dRView["AlID"] is DBNull == false)
        {
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [LikeAlbums] WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "Unlike(" + dt.Rows.Count.ToString() + ")";
                    return somep;
                }
                else
                {
                    string somepa = "Like(" + dt.Rows.Count.ToString() + ")";
                    return somepa;
                }
            }
            return "Like(" + dt.Rows.Count.ToString() + ")";
            //return albums...
        }
        else if (dRView["P"].ToString() != "1")
        {
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [LikePhotos] WHERE PID = " + (int)dRView["P"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "Unlike(" + dt.Rows.Count.ToString() + ")";
                    return somep;
                }
                else
                {
                    string somepa = "Like(" + dt.Rows.Count.ToString() + ")";
                    return somepa;
                }
            }
            return "Like(" + dt.Rows.Count.ToString() + ")";
            //return "photo" + dRView["P"].ToString();
        }
        else
        {
            DataTable dt = new DataTable();

            string getcvalue = "SELECT * FROM [Like] WHERE NID = " + (int)dRView["NID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "Unlike(" + dt.Rows.Count.ToString() + ")";
                    return somep;
                }
                else
                {
                    string somepa = "Like(" + dt.Rows.Count.ToString() + ")";
                    return somepa;
                }
            }
            return "Like(" + dt.Rows.Count.ToString() + ")";
            //return "comment" + dRView["NID"].ToString();
        }
       /* string n = dRView["NID"].ToString();
        int o = int.Parse(n);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);

        //For Phew
        DataTable dt = new DataTable();

        string getcvalue = "SELECT * FROM [Like] WHERE NID = " + o + "";
        dt = dbClass.ReturnDT(getcvalue);
        foreach (DataRow row in dt.Rows)
        {
            if (userii.ToString() == row["UID"].ToString())
            {

                string somep = "Unlike(" + dt.Rows.Count.ToString() + ")";
                return somep;
            }
            else
            {
                string somepa = "Like(" + dt.Rows.Count.ToString() + ")";
                return somepa;
            }
        }
        return "Like(" + dt.Rows.Count.ToString() + ")";
        */
    }
    public string commandnamelike(object bitch)
    {
        DataRowView dRView = (DataRowView)bitch;
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);
        if (dRView["P"].ToString() != "1" && dRView["AlID"] is DBNull == false)
        {
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [LikeAlbums] WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "unlike";
                    return somep;
                }
                else
                {
                    string somepa = "like";
                    return somepa;
                }
            }
            return "like";
            // return "album" + dRView["AlID"].ToString();

        }
        else if (dRView["AlID"] is DBNull == false)
        {
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [LikeAlbums] WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "unlike";
                    return somep;
                }
                else
                {
                    string somepa = "like";
                    return somepa;
                }
            }
            return "like";

           // return "album" + dRView["AlID"].ToString();
        }
        else if (dRView["P"].ToString() != "1")
        {
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [LikePhotos] WHERE PID = " + (int)dRView["P"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "unlike";
                    return somep;
                }
                else
                {
                    string somepa = "like";
                    return somepa;
                }
            }
            return "like";
           // return "photo" + dRView["P"].ToString();
        }
        else
        {
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [Like] WHERE NID = " + (int)dRView["NID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "unlike";
                    return somep;
                }
                else
                {
                    string somepa = "like";
                    return somepa;
                }
            }
            return "like";
           // return "comment" + dRView["NID"].ToString();
        }
        
        /* string n = dRView["NID"].ToString();
        int o = int.Parse(n);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);
        //For Phew
        DataTable dt = new DataTable();
        string getcvalue = "SELECT * FROM [Like] WHERE NID = " + o + "";
        dt = dbClass.ReturnDT(getcvalue);
        foreach (DataRow row in dt.Rows)
        {
            if (userii.ToString() == row["UID"].ToString())
            {

                string somep = "unlike";
                return somep;
            }
            else
            {
                string somepa = "like";
                return somepa;
            }
        }
        return "like";
        */
    
    }
    public string commandnamephew(object urvashi)
    {
        DataRowView dRView = (DataRowView)urvashi;
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);

        if (dRView["P"].ToString() != "1" && dRView["AlID"] is DBNull == false)
        {
            DataTable dt = new DataTable();

            string getcvalue = "SELECT * FROM PhewAlbums WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "unphew";
                    return somep;
                }
                else
                {
                    string somepa = "phew";
                    return somepa;
                }
            }
            return "phew";
            //return "album" + dRView["AlID"].ToString();

        }
        else if (dRView["AlID"] is DBNull == false)
        {
            DataTable dt = new DataTable();

            string getcvalue = "SELECT * FROM PhewAlbums WHERE AID = " + (int)dRView["AlID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "unphew";
                    return somep;
                }
                else
                {
                    string somepa = "phew";
                    return somepa;
                }
            }
            return "phew";
           // return "album" + dRView["AlID"].ToString();
        }
        else if (dRView["P"].ToString() != "1")
        {
            DataTable dt = new DataTable();

            string getcvalue = "SELECT * FROM PhewPhotos WHERE PID = " + (int)dRView["P"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "unphew";
                    return somep;
                }
                else
                {
                    string somepa = "phew";
                    return somepa;
                }
            }
            return "phew";
          //  return "photo" + dRView["P"].ToString();
        }
        else
        {
            DataTable dt = new DataTable();

            string getcvalue = "SELECT * FROM Phew WHERE NID = " + (int)dRView["NID"] + "";
            dt = dbClass.ReturnDT(getcvalue);
            foreach (DataRow row in dt.Rows)
            {
                if (userii.ToString() == row["UID"].ToString())
                {

                    string somep = "unphew";
                    return somep;
                }
                else
                {
                    string somepa = "phew";
                    return somepa;
                }
            }
            return "phew";
         //  return "comment" + dRView["NID"].ToString();
        }
        
        
        
        /*string k = dRView["NID"].ToString();
        int f = int.Parse(k);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);

        //For Phew
        DataTable dt = new DataTable();

        string getcvalue = "SELECT * FROM Phew WHERE NID = " + f + "";
        dt = dbClass.ReturnDT(getcvalue);
        foreach (DataRow row in dt.Rows)
        {
            if (userii.ToString() == row["UID"].ToString())
            {

                string somep = "unphew";
                return somep;
            }
            else
            {
                string somepa = "phew";
                return somepa;
            }
        }
        return "phew";*/
    }
    public string pid(object somefuck)
    {
        DataRowView dRView = (DataRowView)somefuck;

        if (dRView["P"] is DBNull)
        {
            return null;



        }
        else
        {
            return dRView["P"].ToString();

        }
    }
    public string alid(object somefuck)
    {
        DataRowView dRView = (DataRowView)somefuck;

        if (dRView["aid"] is DBNull)
        {
            return null;



        }
        else
        {
            return dRView["aid"].ToString();

        }
    }
    public byte[] propics(object propic)
    {
        DataRowView dRView = (DataRowView)propic;

        if (dRView["profilepic"] is DBNull)
        {
            return null;

        }
        else
        {
            return (byte[])dRView["profilepic"];

        }
    }
    public byte[] photobyte(object bytes)
    {
        DataRowView dRView = (DataRowView)bytes;

        if (dRView["Photo"] is DBNull)
        {
            return null;



        }
        else
        {
            return (byte[])dRView["Photo"];

        }
    }
    public int w(object width)
    {
        DataRowView dRView = (DataRowView)width;
        if (dRView["Photo"] is DBNull)
        {
            return 0;


        }
        else { return 250; }
    }
    public int h(object hi)
    {
        DataRowView dRView = (DataRowView)hi;

        if (dRView["Photo"] is DBNull)
        {
            return 0;

        }
        else { return 250; }

    }
    public string message(object message)
    {
        DataRowView dRView = (DataRowView)message;
        string m = dRView["Message"].ToString();

        return m;

    }
    public string itemd(Object Item)
    {
        DataRowView dRView = (DataRowView)Item;

        string id = dRView["NID"].ToString();
        return id;

    }
    public string br(object somebr)
    {    DataRowView dRView = (DataRowView)somebr;
    if (dRView["P"].ToString() == "1")
    {return""; }
    else { return "<br/>"; } 
    }
   public string whatthehellthisis(object paruldidi)
    {
        DataRowView dRView = (DataRowView)paruldidi;
        if (dRView["P"].ToString() != "1" && dRView["AlID"] is DBNull == false)
        {
            return "album"+ dRView["AlID"].ToString();
        
        }
        else if (dRView["AlID"] is DBNull == false)
        { 
            return "album" + dRView["AlID"].ToString();
        }
        else if (dRView["P"].ToString() != "1")
        {
            return "photo" + dRView["P"].ToString();
        }
        else {
            return "comment" + dRView["NID"].ToString();
        }

    }
    protected void RadGrid1_ItemCommand1(object sender, GridCommandEventArgs e)
    {

        if (e.CommandName == "displaycomments")
        {
            
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("hell");
            string wtf = k.Text;
            RadGrid2.Columns.FindByUniqueName("loadit").FooterText = k.Text;
            DataTable dt = new DataTable();
            thecbox.Visible = true;

            if(wtf.StartsWith("album"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string getcomments = @"SELECT     [User].Name, [User].ID, AlbumComments.ID AS CID, AlbumComments.Comment, AlbumComments.AID, AlbumComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      AlbumComments ON [User].ID = AlbumComments.UID INNER JOIN
                      Propic ON AlbumComments.UID = Propic.UID
WHERE     (AlbumComments.AID = "+detid+@") AND (Propic.[Current] = 1)
ORDER BY CID";
                

                dt = dbClass.ReturnDT(getcomments);
                if (dt.Rows.Count == 0)
                {
                    RadGrid2.Visible = false;
                    RadTextBox1.EmptyMessage = "Be the 1st to comment";
                }
                else
                {
                    RadGrid2.DataSource = dt;
                    RadGrid2.DataBind();
                }

            }
            else if (wtf.StartsWith("photo"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string getcomments = @"SELECT     [User].Name, [User].ID, PhotoComments.ID AS CID, PhotoComments.Comment, PhotoComments.PID, PhotoComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      PhotoComments ON [User].ID = PhotoComments.UID INNER JOIN
                      Propic ON PhotoComments.UID = Propic.UID
WHERE     (Propic.[Current] = 1) AND (PhotoComments.PID = " + detid + @")
ORDER BY CID";


                dt = dbClass.ReturnDT(getcomments);
                if (dt.Rows.Count == 0)
                {
                    RadGrid2.Visible = false;
                    RadTextBox1.EmptyMessage = "Be the 1st to comment";
                }
                else
                {
                    RadGrid2.DataSource = dt;
                    RadGrid2.DataBind();

                }
            }
            else
            {
                int detid = int.Parse(wtf.Substring(7));
                string getcomments = @"SELECT     [User].Name, [User].ID, Comments.ID AS CID, Comments.Comment, Comments.ItemID, Comments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      Comments ON [User].ID = Comments.UID INNER JOIN
                      Propic ON Comments.UID = Propic.UID
WHERE     (Comments.ItemID = " + detid + @") AND (Propic.[Current] = 1)
ORDER BY CID";

                dt = dbClass.ReturnDT(getcomments);
                if (dt.Rows.Count == 0)
                {
                    RadGrid2.Visible = false;
                    RadTextBox1.EmptyMessage = "Be the 1st to comment";
                }
                else
                {
                    RadTextBox1.EmptyMessage = "Click to comment on the post..";
                    RadGrid2.Visible = true;
                    RadGrid2.DataSource = dt;
                    RadGrid2.DataBind();
                }
            }
            
            /*int itemid = int.Parse(k.Text);
           
            DataTable dt = new DataTable();
            string getc = @"SELECT     [User].Name, [User].ID, Comments.ID AS CID, Comments.Comment, Comments.ItemID, Comments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      Comments ON [User].ID = Comments.UID INNER JOIN
                      Propic ON Comments.UID = Propic.UID
WHERE     (Comments.ItemID = " + itemid + @") AND (Propic.[Current] = 1)
ORDER BY CID";
            dt = dbClass.ReturnDT(getc);
           
            if (dt.Rows.Count == 0)
            {
                RadGrid2.Columns.FindByUniqueName("loadit").FooterText = k.Text;
            }
            else
            {
                RadGrid2.Columns.FindByUniqueName("loadit").FooterText = k.Text;
                RadGrid2.DataSource = dt;
                RadGrid2.DataBind();         
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>fleXenv.updateScrollBars();</script>", false);
           */
        }
        else if (e.CommandName == "phew")
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("hell");
            LinkButton lk = (LinkButton)dataItem.FindControl("phew");
            string wtf = k.Text;
            int z = int.Parse(Session["UserID"].ToString());
            if (wtf.StartsWith("album"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "INSERT INTO PhewAlbums (UID , AID)VALUES (" + z + "," + detid + ")";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM PhewAlbums WHERE AID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Unphew(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "unphew";
               // return "album" + dRView["AlID"].ToString();

            }
            else if (wtf.StartsWith("photo"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "INSERT INTO PhewPhotos (UID , PID)VALUES (" + z + "," + detid + ")";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM PhewPhotos WHERE PID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Unphew(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "unphew";
               // return "photo" + dRView["AlID"].ToString();
            }
            else 
            {
                int detid = int.Parse(wtf.Substring(7));
                string iphew = "INSERT INTO Phew (UID , NID)VALUES (" + z + "," + detid + ")";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM Phew WHERE NID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Unphew(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "unphew";
              //  return "usual comment" + dRView["P"].ToString();
            }
           
           // int itemid = int.Parse(k.Text);
           
           /* int z = int.Parse(Session["UserID"].ToString());
            string iphew = "INSERT INTO Phew (UID , NID)VALUES (" + z + "," + itemid + ")";
            dbClass.DataBase(iphew);

            LinkButton lk = (LinkButton)dataItem.FindControl("phew");

            //How Much..
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM Phew WHERE NID = " + itemid + "";
            dt = dbClass.ReturnDT(getcvalue);
            lk.Text = "Unphew(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "unphew";*/

        }
        else if (e.CommandName == "unphew")
        {
            // DELETE FROM Persons
            //WHERE LastName='Tjessem' AND FirstName='Jakob'
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("hell");
            LinkButton lk = (LinkButton)dataItem.FindControl("phew");
            string wtf = k.Text;
            int z = int.Parse(Session["UserID"].ToString());
            if (wtf.StartsWith("album"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "DELETE FROM PhewAlbums WHERE UID = " + z + " AND  AID = " + detid + "";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM PhewAlbums WHERE AID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "phew";
               // return "album" + dRView["AlID"].ToString();

            }
            else if (wtf.StartsWith("photo"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "DELETE FROM PhewPhotos WHERE UID = " + z + " AND  PID = " + detid + "";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM PhewPhotos WHERE PID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "phew";
                // return "photo" + dRView["AlID"].ToString();
            }
            else
            {
                int detid = int.Parse(wtf.Substring(7));
                string iphew = "DELETE FROM Phew WHERE UID = " + z + " AND  NID = " + detid + "";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM Phew WHERE NID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "phew";
                //  r
            }
            /*int itemid = int.Parse(k.Text);
            int X = int.Parse(Session["UserId"].ToString());
            string unphewup = "DELETE FROM Phew WHERE NID = " + itemid + " AND UID = " + X + "";
            dbClass.DataBase(unphewup);

            LinkButton lk = (LinkButton)dataItem.FindControl("phew");
            //How Much
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM Phew WHERE NID = " + itemid + "";
            dt = dbClass.ReturnDT(getcvalue);
            lk.Text = "Phew It!(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "phew";

            */


        }
        else if (e.CommandName == "like")
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("hell");
            LinkButton lk = (LinkButton)dataItem.FindControl("like");
            string wtf = k.Text;
            int z = int.Parse(Session["UserID"].ToString());
            if (wtf.StartsWith("album"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "INSERT INTO [LikeAlbums] (UID , AID)VALUES (" + z + "," + detid + ")";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM [LikeAlbums] WHERE AID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Unlike(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "unlike";
                // return "album" + dRView["AlID"].ToString();

            }
            else if (wtf.StartsWith("photo"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "INSERT INTO [LikePhotos] (UID , PID)VALUES (" + z + "," + detid + ")";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM [LikePhotos] WHERE PID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Unlike(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "unlike";
                // return "photo" + dRView["AlID"].ToString();
            }
            else
            {
                int detid = int.Parse(wtf.Substring(7));
                string iphew = "INSERT INTO [Like] (UID , NID)VALUES (" + z + "," + detid + ")";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM [Like] WHERE NID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Unlike(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "unlike";
                //  r
            }
            
            
            
            /*int itemid = int.Parse(k.Text);
            
            int z = int.Parse(Session["UserID"].ToString());
            string iphew = "INSERT INTO [Like] (UID , NID)VALUES (" + z + "," + itemid + ")";
            dbClass.DataBase(iphew);

            LinkButton lk = (LinkButton)dataItem.FindControl("like");

            //How Much..
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [Like] WHERE NID = " + itemid + "";
            dt = dbClass.ReturnDT(getcvalue);
            lk.Text = "Unlike(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "unlike";*/

        }
        else if (e.CommandName == "unlike")
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("hell");
            LinkButton lk = (LinkButton)dataItem.FindControl("like");
            string wtf = k.Text;
            int z = int.Parse(Session["UserID"].ToString());
            if (wtf.StartsWith("album"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "DELETE FROM [LikeAlbums] WHERE AID = " + detid + " AND UID = " + z + "";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM [LikeAlbums] WHERE AID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Like(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "like";
                // return "album" + dRView["AlID"].ToString();

            }
            else if (wtf.StartsWith("photo"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "DELETE FROM [LikePhotos] WHERE PID = " + detid + " AND UID = " + z + "";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM [LikePhotos] WHERE PID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Like(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "like";
                // return "photo" + dRView["AlID"].ToString();
            }
            else
            {
                int detid = int.Parse(wtf.Substring(7));
                string iphew = "DELETE FROM [Like] WHERE NID = " + detid + " AND UID = " + z + "";
                dbClass.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM [Like] WHERE NID = " + detid + "";
                dt = dbClass.ReturnDT(getcvalue);
                lk.Text = "Like(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "like";
                //  r
            }

           /* int itemid = int.Parse(k.Text);
            int X = int.Parse(Session["UserId"].ToString());
            string unphewup = "DELETE FROM [Like] WHERE NID = " + itemid + " AND UID = " + X + "";
            dbClass.DataBase(unphewup);

            LinkButton lk = (LinkButton)dataItem.FindControl("like");
            //How Much
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [Like] WHERE NID = " + itemid + "";
            dt = dbClass.ReturnDT(getcvalue);
            lk.Text = "Like(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "like";*/

        }
    }
    protected void datasource(object sender, GridNeedDataSourceEventArgs e)
    {
        bindit();
    }
    protected void RadGrid2_DataBound(object sender, EventArgs e)
    {
        
      //  ScriptManager.RegisterClientScriptInclude(Page, Page.GetType(), "galery", "lib/scroll/flexcroll.js");
      //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmpasd", togeth, false);
        thecbox.Visible = true;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>fleXenv.fleXcrollMain('tobescrolled');</script>", false);
        

    }
    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        thecbox.Visible = false;
    }
    protected void postcomment_Click(object sender, EventArgs e)
    {
        if (RadTextBox1.Text == "")
        {
        }
        else
        {
            string wtf = RadGrid2.Columns.FindByUniqueName("loadit").FooterText;
            int z = int.Parse(Session["UserID"].ToString());
            string conntenn = RadTextBox1.Text;
            conntenn = conntenn.Replace("\n", "<br/>");
            conntenn = conntenn.Replace("\r", "&nbsp;&nbsp;");
            if (wtf.StartsWith("album"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string me = @"INSERT INTO AlbumComments (AID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                dbClass.DataBase(me);
                // return "album" + dRView["AlID"].ToString();

            }
            else if (wtf.StartsWith("photo"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string me = @"INSERT INTO PhotoComments (PID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                dbClass.DataBase(me);
                // return "photo" + dRView["AlID"].ToString();
            }
            else
            {
                int detid = int.Parse(wtf.Substring(7));
                string me = @"INSERT INTO Comments (ItemID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                dbClass.DataBase(me);
                //  r
            }
            bindit();
            RadGrid1.DataBind();
           
            RadGrid2.Columns.FindByUniqueName("loadit").FooterText = wtf;
            RadGrid2.DataSource = dt;
            RadGrid2.DataBind();
            thecbox.Visible = true;
            RadTextBox1.Text = "";
        }
    }
}