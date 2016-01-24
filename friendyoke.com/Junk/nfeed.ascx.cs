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

public partial class Newsfeed_nfeed : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
    public DataSet ds;
    protected void Page_Init(object sender, EventArgs e)
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
        if (!object.Equals(Session["UserId"], null))
        {
            foreach (GridItem i in RadGrid1.Items)
            {



                Label k = (Label)i.FindControl("itemid");
                int f = int.Parse(k.Text);

                string userid = Session["UserId"].ToString();
                int userii = int.Parse(userid);
                //For Comments
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM Comments WHERE ItemID = " + f + "";
                dt = dbClass.ReturnDT(getcvalue);
                LinkButton comment = (LinkButton)i.FindControl("vcomments");
                comment.Text = dt.Rows.Count.ToString() + " Comments";

                //For Phew
                DataTable dt2 = new DataTable();
                string getphewvalue = "SELECT * FROM Phew WHERE NID = " + f + "";
                dt = dbClass.ReturnDT(getcvalue);
                LinkButton phew1 = (LinkButton)i.FindControl("phew");
                if (phew1.Text.StartsWith("Unphew"))
                {
                    phew1.CommandName = "unphew";
                }


                DataTable dt3 = new DataTable();
                string checkphewme = "SELECT * FROM Phew WHERE NID = " + f + "AND UID = " + userii + "";

                //For Likes
                LinkButton like = (LinkButton)i.FindControl("like");
                string likevalue = "SELECT * FROM [Like] WHERE NID = " + f + "";
                DataTable dt4 = new DataTable();
                dt4 = dbClass.ReturnDT(likevalue);
                LinkButton likk = (LinkButton)i.FindControl("like");
                if (likk.Text.StartsWith("Unlike"))
                {
                    likk.CommandName = "unlike";
                }


            }
            
        }
        else
        {

            Response.Redirect("~/Login.aspx");
        }
       
        
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
        else if (RadTabStrip1.SelectedIndex == 2)
        { 
        
        
        }
        
    }
   
    protected void justadd_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {

    }
    
    protected void createalbum_Click(object sender, EventArgs e)
    {

       
    }
    protected void addtoalbum_Click(object sender, EventArgs e)
    {
        
    
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }
    /*public string Email(string emall)
    {
        emall = Session["UserEmail"].ToString();
        return emall;

    }*/
    public string getUserHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["Id"].ToString();

        return ResolveUrl("~/Profile/profile.aspx?Id=" + Id);
    }


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
        string k= dRView["NID"].ToString();
            int f = int.Parse(k);
            string userid = Session["UserId"].ToString();
            int userii = int.Parse(userid);
            //For Comments
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM Comments WHERE ItemID = " + f + "";
            dt = dbClass.ReturnDT(getcvalue);
            string somep = dt.Rows.Count.ToString() + " Comments";
            return somep;
               
    }
    public string phew(object phew)
    {
        DataRowView dRView = (DataRowView)phew;
        string k = dRView["NID"].ToString();
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
            return "<h4 class='mainheader'> New Album!: <span style='font-size:18px;'>" + dRView["aname"].ToString() + "</span></h4>";

        }
    }
    public string like(object like)
    {
        DataRowView dRView = (DataRowView)like;
        string n = dRView["NID"].ToString();
        int o = int.Parse(n);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);

        //For Phew
        DataTable dt = new DataTable();

        string getcvalue = "SELECT * FROM [Like] WHERE NID = " + o +"";
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

    } 
  public  string pid(object somefuck)
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
      
         if(dRView["Photo"] is DBNull)
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



     /* if (m.StartsWith("<img "))
        {
            string id = dRView["NID"].ToString();
            string k = m.Substring(17);
            int f = k.Length;
            char[] t ={ '>' ,'/' ,'"',';'
                      };

            string bol = k.TrimEnd(t);
            int intEnd = bol.IndexOf('"');

            string pic = bol.Remove(intEnd);
            string s = "<a class='nfeed' href='Space/Cloud/Cloud.aspx?pic=" + pic + "&nid=" + id + "'><img src='" + pic + "' /></a>";

            return s;

        }*/
  
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
    public string itemd(Object Item)
    {
        DataRowView dRView = (DataRowView)Item;

        string id = dRView["NID"].ToString();
        return id;

    }

    protected void datasource(object source, GridNeedDataSourceEventArgs e)
    {
        bindit(); foreach (GridItem i in RadGrid1.Items)
        {



            Label k = (Label)i.FindControl("itemid");
            int f = int.Parse(k.Text);

            string userid = Session["UserId"].ToString();
            int userii = int.Parse(userid);
            //For Comments
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM Comments WHERE ItemID = " + f + "";
            dt = dbClass.ReturnDT(getcvalue);
            LinkButton comment = (LinkButton)i.FindControl("vcomments");
            comment.Text = dt.Rows.Count.ToString() + " Comments";

            //For Phew
            DataTable dt2 = new DataTable();
            string getphewvalue = "SELECT * FROM Phew WHERE NID = " + f + "";
            dt = dbClass.ReturnDT(getcvalue);
            LinkButton phew1 = (LinkButton)i.FindControl("phew");
            if (phew1.Text.StartsWith("Unphew"))
            {
                phew1.CommandName = "unphew";
            }


            DataTable dt3 = new DataTable();
            string checkphewme = "SELECT * FROM Phew WHERE NID = " + f + "AND UID = " + userii + "";

            //For Likes
            LinkButton like = (LinkButton)i.FindControl("like");
            string likevalue = "SELECT * FROM [Like] WHERE NID = " + f + "";
            DataTable dt4 = new DataTable();
            dt4 = dbClass.ReturnDT(likevalue);
            LinkButton likk = (LinkButton)i.FindControl("like");
            if (likk.Text.StartsWith("Unlike"))
            {
                likk.CommandName = "unlike";
            }


        }
       
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
                            WHERE      (FriendID = " + Session["UserId"] + @") AND (FriendStatus = 1))) AND (Propic.[Current] = 1) OR
                      ([User].ID IN
                          (SELECT     FriendID AS ID
                            FROM          Friends AS Friends_1
                            WHERE      (MyID = " +Session["UserId"]+@") AND (FriendStatus = 1))) AND (Propic.[Current] = 1)
ORDER BY NID DESC";
        
        dt = dbClass.ReturnDT(getfeed);

        if (dt.Rows.Count > 0)
        {
            RadGrid1.DataSource = dt;

        }
        else
        {
            RadGrid1.Visible = false;
            frndsn.Text = "Please Send Request To Your Friends On Friendyoke to view any Newsfeed";
        }

    }

    protected void RadGrid1_ItemCommand1(object sender, GridCommandEventArgs e)
    {
       
    

        if (e.CommandName == "displaycomments")
        {
            comment.Visible = true;
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("itemid");
            int itemid = int.Parse(k.Text);

            Db dbClass = new Db();
            DataTable dt = new DataTable();
            string getc = @"SELECT     [User].Name, [User].ID, Comments.ID AS CID, Comments.Comment, Comments.ItemID, Comments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      Comments ON [User].ID = Comments.UID INNER JOIN
                      Propic ON Comments.UID = Propic.UID
WHERE     (Comments.ItemID = "+itemid+@") AND (Propic.[Current] = 1)
ORDER BY CID";
               dt = dbClass.ReturnDT(getc);
            RadGrid2.Columns.FindByUniqueName("loadit").HeaderText = "Comments";
            if (dt.Rows.Count == 0)
            {
                
                lblstatus.Visible = true;
                lblstatus.Text = "No Comments";
                RadGrid2.Columns.FindByUniqueName("loadit").FooterText = k.Text;
                vaibhav.Visible = false;
              


            }
            else
            {
                lblstatus.Visible = false;
                RadGrid2.Columns.FindByUniqueName("loadit").FooterText = k.Text;
                RadGrid2.DataSource = dt;
                RadGrid2.DataBind();
                vaibhav.Visible = true;
                
            }
            
        }
        else if (e.CommandName == "phew")
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("itemid");
            int itemid = int.Parse(k.Text);
            comment.Visible = false;
            int z = int.Parse(Session["UserID"].ToString());
            string iphew = "INSERT INTO Phew (UID , NID)VALUES (" + z + "," + itemid + ")";
            dbClass.DataBase(iphew);

            LinkButton lk = (LinkButton)dataItem.FindControl("phew");

            //How Much..
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM Phew WHERE NID = " + itemid + "";
            dt = dbClass.ReturnDT(getcvalue);
            lk.Text = "Unphew(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "unphew";


            
            
                
                
              
                    
                
                
            


        }
        else if (e.CommandName == "unphew")
        { 
      // DELETE FROM Persons
//WHERE LastName='Tjessem' AND FirstName='Jakob'
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("itemid");
            int itemid = int.Parse(k.Text);
            int X = int.Parse(Session["UserId"].ToString());
            string unphewup = "DELETE FROM Phew WHERE NID = "+itemid+" AND UID = "+X+"";
            dbClass.DataBase(unphewup);

            LinkButton lk = (LinkButton)dataItem.FindControl("phew");
            //How Much
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM Phew WHERE NID = " + itemid + "";
            dt = dbClass.ReturnDT(getcvalue);
            lk.Text = "Phew It!(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "phew";



        
        }
        else if (e.CommandName == "like")
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("itemid");
            int itemid = int.Parse(k.Text);
            comment.Visible = false;
            int z = int.Parse(Session["UserID"].ToString());
            string iphew = "INSERT INTO [Like] (UID , NID)VALUES (" + z + "," + itemid + ")";
            dbClass.DataBase(iphew);

            LinkButton lk = (LinkButton)dataItem.FindControl("like");

            //How Much..
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [Like] WHERE NID = " + itemid + "";
            dt = dbClass.ReturnDT(getcvalue);
            lk.Text = "Unlike(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "unlike";
        
        }
        else if (e.CommandName == "unlike")
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            Label k = (Label)dataItem.FindControl("itemid");
            int itemid = int.Parse(k.Text);
            int X = int.Parse(Session["UserId"].ToString());
            string unphewup = "DELETE FROM [Like] WHERE NID = " + itemid + " AND UID = " + X + "";
            dbClass.DataBase(unphewup);

            LinkButton lk = (LinkButton)dataItem.FindControl("like");
            //How Much
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [Like] WHERE NID = " + itemid + "";
            dt = dbClass.ReturnDT(getcvalue);
            lk.Text = "Like(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "like";

        }
    }
    protected void post_Click(object sender, EventArgs e)
    {
        if (RadTextBox1.Text == "")
        { 
        }
        else
        {
            Db dbClass = new Db();
            string l = RadGrid2.Columns.FindByUniqueName("loadit").FooterText;
            string s = Session["UserID"].ToString();
            int f = int.Parse(s);
            int itemid = int.Parse(l);
            string me = "INSERT INTO Comments (ItemID, UID, Comment)VALUES ('" + l + "', " + f + ", '" + RadTextBox1.Text.ToString() + "')";
            dbClass.DataBase(me);

            bindit();
            RadGrid1.DataBind();
            lblstatus.Visible = false;
            RadGrid2.Columns.FindByUniqueName("loadit").FooterText = l;
            RadGrid2.DataSource = dt;
            RadGrid2.DataBind();
            vaibhav.Visible = true;
            RadTextBox1.Text = "";
        }
    }
    protected void RadGrid2_Load(object sender, EventArgs e)
    {

    }

}