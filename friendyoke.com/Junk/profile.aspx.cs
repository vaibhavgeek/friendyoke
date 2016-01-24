using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
using System.Data;
public partial class Profile_images_profile : System.Web.UI.Page
{
    Db profile = new Db();
    public DataSet ds;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"].ToString();
        string myd = Session["UserId"].ToString();
       
        string checkboxreq = @"SELECT     MyID, SID, FollowDate, FollowStatus, ID
FROM         Box
WHERE     (MyID = "+myd+") AND (SID = "+id+")";
        DataTable chboc = new DataTable();
        chboc = profile.ReturnDT(checkboxreq);
        if (chboc.Rows.Count != 0)
        {
            RadButton addbox = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("addbox");
            addbox.Text = "Remove From Box";
            addbox.CommandName = "rfb";
        
        }

        string asked2connect = @"SELECT   * FROM         Friends
WHERE     (MyID = " + Session["UserId"] + ") AND (FriendID = "+ id +")";
        DataTable dt3 = new DataTable();
        dt3 = profile.ReturnDT(asked2connect);
        if (dt3.Rows.Count > 0)
        {
            RadButton editprofile = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("friendreq");
            editprofile.CommandName = "rempen";
            editprofile.Text = "Cancel Pending Connect Req?";

        }

        string chkfriendRequest = @"SELECT * FROM Friends WHERE  (MyId=" + id + " and FriendId=" + Session["UserId"].ToString() + ")";
        DataTable dt1 = new DataTable();
        dt1 = profile.ReturnDT(chkfriendRequest);
        if (dt1.Rows.Count > 0)
        {
            if (id == Session["UserId"].ToString())
            {
                RadPanelBar1.FindItemByValue("connect").Text = "Personalize Profile";
                RadButton editprofile = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("friendreq");
                editprofile.Text = "Edit Your Profile";
                editprofile.CommandName = "ep";

                RadButton addbox = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("addbox");
                addbox.Text = "Change Profile Picture";
                addbox.CommandName = "cpp";

                RadButton message = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("message");
                message.Text = "Privacy Settings";
                message.CommandName = "pst";

            }

           else if (dt1.Rows[0]["FriendStatus"].ToString() == "1")
            {
                RadButton editprofile = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("friendreq");
                editprofile.Text = "Remove Connection";
                editprofile.CommandName = "unfriend";
               

                RadButton addbox = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("addbox");
                addbox.Visible = false;

                RadButton message = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("message");
                message.Text = "Message";
                message.CommandName = "ms";

            }
           else if (dt1.Rows[0]["FriendStatus"].ToString() == "0")
            {
                RadButton editprofile = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("friendreq");
                editprofile.Text = "Accept Connection";
                editprofile.CommandName = "befriend";
             

                RadButton addbox = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("addbox");
               

                RadButton message = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("message");
                message.Text = "Message";
                message.CommandName = "ms";

            }

        }


       
       
      

          
          DataSet udet = new DataSet();
          string urprofile = @"SELECT     Name,City, ID, Country, College, School, Company, Gender, Degree, uname, Designation, BirthDate
FROM         [User]
WHERE     (ID =" + id + ")";
          udet = profile.ReturnDS(urprofile);
          Label name = (Label)RadPanelBar1.FindItemByValue("bi").FindControl("nm");
          Label dob = (Label)RadPanelBar1.FindItemByValue("bi").FindControl("dob");
          Label gen = (Label)RadPanelBar1.FindItemByValue("bi").FindControl("gen");
          Label born = (Label)RadPanelBar1.FindItemByValue("bi").FindControl("born");
          name.Text = udet.Tables[0].Rows[0]["Name"].ToString();
          dob.Text = udet.Tables[0].Rows[0]["BirthDate"].ToString();
          gen.Text = udet.Tables[0].Rows[0]["Gender"].ToString();
          born.Text = udet.Tables[0].Rows[0]["City"].ToString();

        //Education And Work ...

          if (udet.Tables[0].Rows[0]["College"] is DBNull && udet.Tables[0].Rows[0]["School"] is DBNull && udet.Tables[0].Rows[0]["Designation"] is DBNull && udet.Tables[0].Rows[0]["Company"] is DBNull && udet.Tables[0].Rows[0]["Degree"] is DBNull)
          {
              eduwork.Visible = false;
              RadTabStrip1.FindTabByText("Education and Work").Visible = false;
          
          }
          else
          {
              if (udet.Tables[0].Rows[0]["School"] is DBNull)
              {
                  school.Text = ": Not disclosed by user";

              }
              else
              {
                  school.Text = ": " + udet.Tables[0].Rows[0]["School"].ToString();

              }

              if (udet.Tables[0].Rows[0]["College"] is DBNull)
              {
                  collegea.Text = ": Not disclosed by user";
              }
              else
              {
                  collegea.Text = ": " + udet.Tables[0].Rows[0]["College"].ToString();
              }


              if (udet.Tables[0].Rows[0]["Degree"] is DBNull)
              {
                  degree.Text = ": Not disclosed by user";
              }
              else
              {
                  degree.Text = ": " + udet.Tables[0].Rows[0]["Degree"].ToString();
              }

              if (udet.Tables[0].Rows[0]["Company"] is DBNull)
              {
                  company.Text = ": Not disclosed by user";
              }
              else
              {
                  company.Text = ": " + udet.Tables[0].Rows[0]["Company"].ToString();
              }

              if (udet.Tables[0].Rows[0]["Designation"] is DBNull)
              {
                  college.Text = ": Not disclosed by user";
              }
              else
              {
                  college.Text = ": " + udet.Tables[0].Rows[0]["Designation"].ToString();
              }
          }

          DataSet profilepic = new DataSet();
          string propicsql = @"SELECT     Image
FROM         Propic
WHERE     (UID = " + id + ") AND ([Current] = 1)";
          profilepic = profile.ReturnDS(propicsql);
          if (profilepic.Tables[0].Rows[0]["Image"] is DBNull == false)
          {
              RadBinaryImage prop = (RadBinaryImage)RadPanelBar1.FindItemByValue("bi").FindControl("profilepicture");
              prop.DataValue = (byte[])profilepic.Tables[0].Rows[0]["Image"];
          }
          DataSet mimage = new DataSet();
          string mimagesql = @"SELECT     Image, Desciption
FROM         Mimage
WHERE     (UID = "+id+")";
          mimage = profile.ReturnDS(mimagesql);
          if (mimage.Tables[0].Rows[0]["Image"] is DBNull)
          {
              mimageandpic.Visible = false;
              RadTabStrip1.FindTabByText("Mimage").Visible = false;
          }
          else
          {
              mmimage.DataValue = (byte[])mimage.Tables[0].Rows[0]["Image"];
             
               
          }

          string getallbumsofuser = @"SELECT     Name, UID, ID
FROM         Albums
WHERE     (UID = "+id+")";
        /*
          string getalbums = @"SELECT  TOP (1)  Albums.Name, Albums.UID, Albums.ID, Photos.Photo
FROM         Albums INNER JOIN
                      Photos ON Albums.ID = Photos.AlbumID
WHERE     (Albums.UID = " +id+")";
          DataSet displaypics = new DataSet();
          displaypics = profile.ReturnDS(getalbums);

          RadBinaryImage A01 = new RadBinaryImage();
          A01.DataValue = (byte[])displaypics.Tables[0].Rows[0]["Photo"];
          A01.Width = 150;
          A01.Height = 150;
          A01.ResizeMode = BinaryImageResizeMode.Fit;
          photos.Controls.Add(A01);
        */

          DataTable evntsofmylife = new DataTable();
          string evntoflifesql = @"SELECT     ID, EventName, Description, UID, Image
FROM         Events
WHERE     (UID = "+id+")";
          evntsofmylife = profile.ReturnDT(evntoflifesql);
          if (evntsofmylife.Rows.Count > 0)
          {
              Repeater1.DataSource = evntsofmylife;
              Repeater1.DataBind();
              
          }
          else
          {
              eventlife.Visible = false;
              RadTabStrip1.FindTabByText("Events in Life").Visible = false;
          }

          DataSet philo = new DataSet();
          string philosql = @"SELECT     Religion, Life, Political, Quote
FROM         Political
WHERE     (UID = "+id+")";
          philo = profile.ReturnDS(philosql);
          if (philo.Tables[0].Rows[0]["Religion"] is DBNull && philo.Tables[0].Rows[0]["Life"] is DBNull && philo.Tables[0].Rows[0]["Quote"] is DBNull && philo.Tables[0].Rows[0]["Political"] is DBNull)
          {
              philosophy.Visible = false;
              RadTabStrip1.FindTabByText("Philosophy").Visible = false;

          }
          else
          {
              if (philo.Tables[0].Rows[0]["Religion"] is DBNull)
              {

                  rel.Text = ": Not disclosed by user";

              }
              else
              {
                  rel.Text = ": " + philo.Tables[0].Rows[0]["Religion"].ToString();

              }

              if (philo.Tables[0].Rows[0]["Life"] is DBNull)
              {
                  life.Text = ": Not disclosed by user";
              }
              else
              {
                  life.Text = ": " + philo.Tables[0].Rows[0]["Life"].ToString();
              }


              if (philo.Tables[0].Rows[0]["Quote"] is DBNull)
              {
                  qute.Text = ": Not disclosed by user";
              }
              else
              {
                  qute.Text = ": " + philo.Tables[0].Rows[0]["Quote"].ToString();
              }

              if (philo.Tables[0].Rows[0]["Political"] is DBNull)
              {
                  politics.Text = ": Not disclosed by user";
              }
              else
              {
                  politics.Text = ": " + philo.Tables[0].Rows[0]["Political"].ToString();
              }

             
          }

          
          DataSet eement = new DataSet();
          string ementsql = @"SELECT    Movies, Sports, Television, Music, Books
FROM         Ement
WHERE     (UID = "+id+")";
          eement = profile.ReturnDS(ementsql);
          if (eement.Tables[0].Rows[0]["Sports"] is DBNull && eement.Tables[0].Rows[0]["Television"] is DBNull && eement.Tables[0].Rows[0]["Music"] is DBNull && eement.Tables[0].Rows[0]["Books"] is DBNull)
          {
              ement.Visible = false;
              RadTabStrip1.FindTabByText("Entertainment and Intrests").Visible = false;

          }
          else
          {
              if (eement.Tables[0].Rows[0]["Movies"] is DBNull)
              {

                 movies.Text = ": Not disclosed by user";

              }
              else
              {
                  movies.Text = ": " + eement.Tables[0].Rows[0]["Movies"].ToString();

              }

              if (eement.Tables[0].Rows[0]["Books"] is DBNull)
              {
                  books.Text = ": Not disclosed by user";
              }
              else
              {
                  books.Text = ": " + eement.Tables[0].Rows[0]["Books"].ToString();
              }


              if (eement.Tables[0].Rows[0]["Music"] is DBNull)
              {
                  music.Text = ": Not disclosed by user";
              }
              else
              {
                  music.Text = ": " + eement.Tables[0].Rows[0]["Music"].ToString();
              }

              if (eement.Tables[0].Rows[0]["Television"] is DBNull)
              {
                  tel.Text = ": Not disclosed by user";
              }
              else
              {
                  tel.Text = ": " + eement.Tables[0].Rows[0]["Television"].ToString();
              }

              if (eement.Tables[0].Rows[0]["Sports"] is DBNull)
              {
                  sports.Text = ": Not disclosed by user";
              }
              else
              {
                  sports.Text = ": " + eement.Tables[0].Rows[0]["Sports"].ToString();
              }


          }

          DataSet achievve = new DataSet();
          string achievesql = @"SELECT     Achievement
FROM         Achieve
WHERE     (UID = "+id+")";
          achievve = profile.ReturnDS(achievesql);
          if (achievve.Tables[0].Rows[0]["Achievement"] is DBNull)
          {
              achieve.Visible = false;
              RadTabStrip1.FindTabByText("Achievements").Visible = false;

          }
          else
          {
              achievements.Text = achievve.Tables[0].Rows[0]["Achievement"].ToString();
          }

          DataSet coninfo = new DataSet();
          string coninfosql = @"SELECT     Website, Phone, Email, Address
FROM         Contact
WHERE     (UID = " + id + ")";
          coninfo = profile.ReturnDS(coninfosql);
          if (coninfo.Tables[0].Rows[0]["Website"] is DBNull && coninfo.Tables[0].Rows[0]["Phone"] is DBNull && coninfo.Tables[0].Rows[0]["Email"] is DBNull && coninfo.Tables[0].Rows[0]["Address"] is DBNull)
          {
              contactme.Visible = false;
              RadTabStrip1.FindTabByText("Contact Information").Visible = false;

          }
          else
          {
              if (coninfo.Tables[0].Rows[0]["Website"] is DBNull)
              {

                  web.Text = ": Not disclosed by user";

              }
              else
              {
                  web.Text = ": <a class='someclasslink' href='" + coninfo.Tables[0].Rows[0]["Website"].ToString() + "' target='_blank'>" + coninfo.Tables[0].Rows[0]["Website"].ToString() + "</a>";

              }

              if (coninfo.Tables[0].Rows[0]["Phone"] is DBNull)
              {
                 phone.Text = ": Not disclosed by user";
              }
              else
              {
                  phone.Text = ": " + coninfo.Tables[0].Rows[0]["Phone"].ToString();
              }


              if (coninfo.Tables[0].Rows[0]["Address"] is DBNull)
              {
                 add.Text = ": Not disclosed by user";
              }
              else
              {
                 add.Text = ": " + coninfo.Tables[0].Rows[0]["Address"].ToString();
              }

              if (coninfo.Tables[0].Rows[0]["Email"] is DBNull)
              {
                  email.Text = ": Not disclosed by user";
              }
              else
              {
                  email.Text = ": <a class='someclasslink' href='mailto:" + coninfo.Tables[0].Rows[0]["Email"].ToString() + "'>" + coninfo.Tables[0].Rows[0]["Email"].ToString() + "</a>";
              }

            


          }

     }
    public byte[] photobyte(object propic)
    {
        DataRowView dRView = (DataRowView)propic;

        if (dRView["Image"] is DBNull)
        {
            return null;

        }
        else
        {
            return (byte[])dRView["Image"];

        }
    }
    protected void friendreq_Click(object sender, EventArgs e)
    {
        RadButton editprofile = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("friendreq");
        string id = Request.QueryString["id"].ToString();
        string myd = Session["UserId"].ToString();
        if (editprofile.CommandName == "ep")
        {
            Response.Redirect("edit/edit-profile.aspx");
        }
        if (editprofile.CommandName == "befriend")
        {
           
       
            string AcceptFriendQuery = "Update Friends set FriendStatus=1 where MyId=" + id + " AND FriendId=" + myd + "";
            profile.DataBase(AcceptFriendQuery);
            Response.Redirect("profile.aspx?Id=" + id);
        }
        if(editprofile.CommandName == "rempen")
        {
            string delereq = @"DELETE 
FROM         Friends
WHERE     (MyID = "+myd+") AND (FriendID = "+id+")";
            profile.DataBase(delereq);
            Response.Redirect("profile.aspx?Id=" + id);
        }
        if (editprofile.CommandName == "ask")
        {
            
            string chkfriendRequest = @"SELECT * FROM Friends WHERE (MyId=" + Session["UserId"].ToString() + " and FriendId=" + id + ") OR (MyId=" + id + " and FriendId=" + Session["UserId"].ToString() + ")";
            DataTable dt1 = new DataTable();
            dt1 = profile.ReturnDT(chkfriendRequest);
            if (dt1.Rows.Count > 0)
            {
                
                if (dt1.Rows[0]["FriendStatus"].ToString() == "0")
                {
                    editprofile.Text = "Connection Request Pending";
                    
                }
                if (dt1.Rows[0]["FriendStatus"].ToString() == "2")
                {
                    editprofile.Text = "Connection Request deny";
                 
                }

            }
            else
            {
                string friendRequest = "Insert INTO Friends (MyId,FriendId) VALUES(" + Session["UserId"].ToString() + "," + id + ")";
                profile.DataBase(friendRequest);
                editprofile.Text = "Connection Request Sent";
                editprofile.Enabled = false;

                
            }
        }
            if (editprofile.CommandName == "unfriend")
        {
          
            string unfriendhim = @"DELETE FROM Friends
WHERE     (FriendID = "+Session["UserId"]+@") AND (MyID = "+id+@") OR
                      (FriendID = " + id + @") AND (MyID = " + Session["UserId"] + @")";
            profile.DataBase(unfriendhim);
            Response.Redirect("profile.aspx?Id=" + id);
        }
    }
    
    protected void but2_Click(object sender, EventArgs e)
    {
        
        RadButton addbox = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("addbox");
        if (addbox.CommandName == "addb")
        {
            string id = Request.QueryString["id"].ToString();
            int iid = int.Parse(id);
            string date = System.DateTime.Now.Date.ToString();
            string addtobox = "INSERT INTO Box (MyID, SID, FollowDate, FollowStatus) VALUES (" + Session["UserId"] + "," + iid + "," + "'" + date + "'" + ", 1)";
            profile.DataBase(addtobox);
            Response.Redirect("profile.aspx?Id=" + id);
        }
        if (addbox.CommandName == "rfb")
        {
            string id = Request.QueryString["id"].ToString();
            int iid = int.Parse(id);
            string remove = @"
DELETE FROM Box
WHERE     (MyID = "+Session["UserID"]+") AND (SID = "+iid+")";
            profile.DataBase(remove);
            Response.Redirect("profile.aspx?Id=" + id);
        }
        if(addbox.CommandName == "cpp")
        {
            RadWindow window1 = new RadWindow();
            window1.NavigateUrl = "profilec/pro-pic-change.aspx";
            window1.Modal = true;

            window1.VisibleOnPageLoad = true;
            window1.Width = 310;
            window1.Height = 560;
            RadAjaxPanel1.Controls.Add(window1);
        }
    }
    protected void but3_Click(object sender, EventArgs e)
    {
        RadButton message = (RadButton)RadPanelBar1.FindItemByValue("buttons").FindControl("message");
        if (message.CommandName == "pst")
        {

        }
        if (message.CommandName == "ms")
        {

        }
    }



    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        string id = Request.QueryString["id"].ToString();
        string friendlistsql = @"SELECT     Name, City , ID
FROM         [User]
WHERE     (ID IN
                          (SELECT     MyID AS ID
                            FROM          Friends
                            WHERE      (FriendID = " + id + @") AND (FriendStatus = 1) AND (FriendID <> MyID))) OR
                      (ID IN
                          (SELECT     FriendID AS ID
                            FROM          Friends AS Friends_1
                            WHERE      (MyID = " + id + @") AND (FriendStatus = 1) AND (FriendID <> MyID)))
ORDER BY Name";
        DataTable dt = new DataTable();
        dt = profile.ReturnDT(friendlistsql);
        if (dt.Rows.Count > 0)
        {
            RadGrid1.DataSource = dt;
        }
        else
        {
            RadGrid1.Visible = false;
            
            lblError.Text = "The Person has no friends till date";
            lblError.ForeColor = System.Drawing.Color.Green;
          
        }
    }
    protected void XmlHttpPanel_ServiceRequest(object sender, RadXmlHttpPanelEventArgs e)
    {
        string val = e.Value;
        string getfrndet = @"SELECT   [User].ID,  [User].Email, [User].Name, [User].Country, [User].College, [User].Relationship, [User].BirthDate, [User].School, [User].Company, [User].Gender, [User].City, 
                      [User].Designation, [User].Degree, [User].uname, [User].RegisterDate, [User].Status, Propic.Image, Contact.Website, Networks.Linkedin, Networks.Facebook, 
                      Networks.Twitter, Networks.Plus
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID INNER JOIN
                      Contact ON [User].ID = Contact.UID INNER JOIN
                      Networks ON [User].ID = Networks.UID
WHERE     ([User].ID = " + val + ") AND (Propic.[Current] = 1)";
        DataTable table = new DataTable();
        table = profile.ReturnDT(getfrndet);
        
            this.Repeater2.DataSource = table;
            this.Repeater2.DataBind();
        
    }
    public void ask2connect(int toid)
    {

        if (!object.Equals(Session["UserId"], null))
        {
            if (Object.Equals(Session["UserId"], toid))
            {
                lblError.Text = "Your own profile";
                lblError.Visible = true;
            }
            else
            {
                string chkfriendRequest = @"SELECT * FROM Friends WHERE (MyId=" + Session["UserId"].ToString() + " and FriendId=" + toid + ") OR (MyId=" + toid + " and FriendId=" + Session["UserId"].ToString() + ")";
                DataTable dt1 = new DataTable();
                dt1 = profile.ReturnDT(chkfriendRequest);
                if (dt1.Rows.Count > 0)
                {
                    if (dt1.Rows[0]["FriendStatus"].ToString() == "1")
                    {
                        lblError.Text = "Already in friend list";
                        lblError.Visible = true;
                    }
                    if (dt1.Rows[0]["FriendStatus"].ToString() == "0")
                    {
                        lblError.Text = "Friend Request Pending";
                        lblError.Visible = true;
                    }
                    if (dt1.Rows[0]["FriendStatus"].ToString() == "2")
                    {
                        lblError.Text = "Friend Request deny";
                        lblError.Visible = true;
                    }

                }
                else
                {
                    string friendRequest = "Insert INTO Friends (MyId,FriendId) VALUES(" + Session["UserId"].ToString() + "," + toid + ")";
                    profile.DataBase(friendRequest);
                    lblError.Text = "Friend Request Send";
                    lblError.Visible = true;
                }
            }
        }
    }
    
    public void addtobox(int SID)
    {
        string date = System.DateTime.Now.Date.ToString();
        string addtobox = "INSERT INTO Box (MyID, SID, FollowDate, FollowStatus) VALUES (" + Session["UserId"] + "," + SID + "," + "'" + date + "'" + ", 1)";
        profile.DataBase(addtobox);
    }
    protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "connect")
        {
            ask2connect(int.Parse(RadXmlHttpPanel1.Value));
        
        }
    }
    protected void RadGrid2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        string id = Request.QueryString["id"].ToString();
        DataTable dt = new DataTable();
        string getfeed = @"SELECT     newsfeed.FromID, newsfeed.Message, newsfeed.SendDate, newsfeed.SendTime, newsfeed.P, newsfeed.ID AS NID, [User].Name, Propic.Image AS profilepic, 
                      Photos.Photo, Albums.Name AS aname, Albums.ID AS aid, [User].ID, newsfeed.AlID
FROM         newsfeed INNER JOIN
                      [User] ON newsfeed.FromID = [User].ID INNER JOIN
                      Propic ON newsfeed.FromID = Propic.UID INNER JOIN
                      Photos ON newsfeed.P = Photos.ID INNER JOIN
                      Albums ON Photos.AlbumID = Albums.ID
WHERE     ([User].ID IN
                          (SELECT     MyID AS ID
                            FROM          Friends AS Friends_2
                            WHERE      (FriendID = " + id + @") AND (FriendStatus = 1))) AND (Propic.[Current] = 1) AND (newsfeed.FromID = " + id + @") OR
                      ([User].ID IN
                          (SELECT     FriendID AS ID
                            FROM          Friends AS Friends_1
                            WHERE      (MyID = " + id + @") AND (FriendStatus = 1))) AND (Propic.[Current] = 1) AND (newsfeed.FromID = " + id + @")
ORDER BY NID DESC";

        dt = profile.ReturnDT(getfeed);

        if (dt.Rows.Count > 0)
        {
            RadGrid2.DataSource = dt;

        }
        else
        {
            RadGrid2.Visible = false;
            lbl.Text = "This Person has not posted, not yet...";
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
    public byte[] photobyt(object bytes)
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
    public string getUserHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["Id"].ToString();

        return ResolveUrl("~/Profile/profile.aspx?Id=" + Id);
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
    
    
}

