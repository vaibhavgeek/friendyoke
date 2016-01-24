using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class Photos_Viewer : System.Web.UI.Page
{
    Db photos = new Db();
    public DataSet ds;
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            string det = Request.QueryString["determiner"].ToString();
                RadGrid2.Columns.FindByUniqueName("loadit").FooterText = det;


            string id = det.Substring(5);
            int pid = int.Parse(id);
            loadphotocomments(pid);
        } 
                
            
        
    }
    public string Comment(object commnet)
    {
        DataRowView dRView = (DataRowView)commnet;
        DataTable dt = new DataTable();

       
       
            string getcvalue = "SELECT * FROM PhotoComments WHERE PID = " + (int)dRView["P"] + "";
            dt = photos.ReturnDT(getcvalue);
            string somep = dt.Rows.Count.ToString() + " Comments";
            return somep;
            //return "photo" + dRView["P"].ToString();
       

        /*  string k = dRView["NID"].ToString();
          int f = int.Parse(k);
          string userid = Session["UserId"].ToString();
          int userii = int.Parse(userid);
          //For Comments
          DataTable dt = new DataTable();
          string getcvalue = "SELECT * FROM Comments WHERE ItemID = " + f + "";
          dt = photos.ReturnDT(getcvalue);
          string somep = dt.Rows.Count.ToString() + " Comments";
          return somep;*/

    }  
    public string phew(object phew)
    {
        DataRowView dRView = (DataRowView)phew;
        DataTable dt = new DataTable();
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);


        
        
            string getcvalue = "SELECT * FROM PhewPhotos WHERE PID = " + (int)dRView["P"] + "";
            dt = photos.ReturnDT(getcvalue);
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
       
            // return "comment" + dRView["NID"].ToString();
        }




        /* string k = dRView["NID"].ToString();
        int f = int.Parse(k);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);

        //For Phew
        DataTable dt = new DataTable();

        string getcvalue = "SELECT * FROM Phew WHERE NID = " + f + "";
        dt = photos.ReturnDT(getcvalue);
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

    public string like(object like)
{
        DataRowView dRView = (DataRowView)like;
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);
        
           DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [LikePhotos] WHERE PID = " + (int)dRView["P"] + "";
            dt = photos.ReturnDT(getcvalue);
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
           
            //return "comment" + dRView["NID"].ToString();
        
        /* string n = dRView["NID"].ToString();
         int o = int.Parse(n);
         string userid = Session["UserId"].ToString();
         int userii = int.Parse(userid);

         //For Phew
         DataTable dt = new DataTable();

         string getcvalue = "SELECT * FROM [Like] WHERE NID = " + o + "";
         dt = photos.ReturnDT(getcvalue);
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
    
    public string commandnamelike(object bitch)
    {
        DataRowView dRView = (DataRowView)bitch;
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);
        
           DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [LikePhotos] WHERE PID = " + (int)dRView["P"] + "";
            dt = photos.ReturnDT(getcvalue);
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
        

        /* string n = dRView["NID"].ToString();
        int o = int.Parse(n);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);
        //For Phew
        DataTable dt = new DataTable();
        string getcvalue = "SELECT * FROM [Like] WHERE NID = " + o + "";
        dt = photos.ReturnDT(getcvalue);
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

       
            DataTable dt = new DataTable();

            string getcvalue = "SELECT * FROM PhewPhotos WHERE PID = " + (int)dRView["P"] + "";
            dt = photos.ReturnDT(getcvalue);
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
       



        /*string k = dRView["NID"].ToString();
        int f = int.Parse(k);
        string userid = Session["UserId"].ToString();
        int userii = int.Parse(userid);

        //For Phew
        DataTable dt = new DataTable();

        string getcvalue = "SELECT * FROM Phew WHERE NID = " + f + "";
        dt = photos.ReturnDT(getcvalue);
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
    public void loadalbum(int aid)
    {
        string getphotos = @"SELECT     Photos.ID AS P, Albums.Name, Albums.UID, Photos.Photo, Photos.UID AS UserID, Photos.AlbumID as AID, Photos.ID
FROM         Albums INNER JOIN
                      Photos ON Albums.ID = Photos.AlbumID
WHERE     (Photos.AlbumID = " + aid + ")";
        
        DataTable dt1 = new DataTable();
        dt1 = photos.ReturnDT(getphotos);
        RadGrid1.DataSource = dt1;
        
      //  RadRotator1.DataSource = dt1;
      //  RadRotator1.DataBind();
        
    }
    public void loadalbumcomments(int x)
    {
       
        string getcomments = @"SELECT     [User].Name, [User].ID, AlbumComments.ID AS CID, AlbumComments.Comment, AlbumComments.AID, AlbumComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      AlbumComments ON [User].ID = AlbumComments.UID INNER JOIN
                      Propic ON AlbumComments.UID = Propic.UID
WHERE     (AlbumComments.AID = " + x + @") AND (Propic.[Current] = 1)
ORDER BY CID";


        dt = photos.ReturnDT(getcomments);
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
    public void loadphotocomments(int abcd)
    {

        
        string getcomments = @"SELECT     [User].Name, [User].ID, PhotoComments.ID AS CID, PhotoComments.Comment, PhotoComments.PID, PhotoComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      PhotoComments ON [User].ID = PhotoComments.UID INNER JOIN
                      Propic ON PhotoComments.UID = Propic.UID
WHERE     (Propic.[Current] = 1) AND (PhotoComments.PID = " + abcd + @")
ORDER BY CID";


        dt = photos.ReturnDT(getcomments);
        if (dt.Rows.Count == 0)
        {
            RadGrid2.Visible = false;
            RadTextBox1.EmptyMessage = "Be the 1st to comment";
        }
        else
        {
            RadGrid2.Visible = true;
            RadTextBox1.EmptyMessage = "Press Enter to hit to post comment..";
            RadGrid2.DataSource = dt;
            RadGrid2.DataBind();

        }
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
                photos.DataBase(me);
                // return "album" + dRView["AlID"].ToString();

            }
            else if (wtf.StartsWith("photo"))
            {
                int detid = int.Parse(wtf.Substring(5));
                string me = @"INSERT INTO PhotoComments (PID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                photos.DataBase(me);
                // return "photo" + dRView["AlID"].ToString();
            }
            else
            {
                int detid = int.Parse(wtf.Substring(7));
                string me = @"INSERT INTO Comments (ItemID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                photos.DataBase(me);
                //  r
            }


            RadGrid2.Columns.FindByUniqueName("loadit").FooterText = wtf;
            RadGrid2.DataSource = dt;
            RadGrid2.DataBind();

            RadTextBox1.Text = "";
        }
    }




    protected void datasource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        string det = Request.QueryString["determiner"].ToString();
    //    RadGrid2.Columns.FindByUniqueName("loadit").FooterText = det;


        string id = det.Substring(5);
        int pid = int.Parse(id);
        string getalidfrmph = @"SELECT     Photos.Photo, Photos.AlbumID, Albums.Name, Albums.UID, [User].Name AS Uname
FROM         Photos INNER JOIN
                      Albums ON Photos.AlbumID = Albums.ID INNER JOIN
                      [User] ON Photos.UID = [User].ID
WHERE     (Photos.AlbumID  = " + id + ")";

        dt = new DataTable();
        dt = photos.ReturnDT(getalidfrmph);
        aname.Text = dt.Rows[0]["Name"].ToString();
        uname.Text = dt.Rows[0]["Uname"].ToString()  + "'s Album :";
        anchor.Attributes.Add("href", "Valbum.aspx?uid="+dt.Rows[0]["UID"].ToString()+"");

        int ax = (int)dt.Rows[0]["AlbumID"];
        loadalbum(ax);
        //RadBinaryImage1.DataValue = (byte[])dt.Rows[0]["Photo"];
        //anchor.Attributes.Add("href", "Valbum.aspx?uid=" + (int)dt.Rows[0]["UID"] + "");
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
           

           
                int detid = int.Parse(wtf.Substring(5));
                string getcomments = @"SELECT     [User].Name, [User].ID, PhotoComments.ID AS CID, PhotoComments.Comment, PhotoComments.PID, PhotoComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      PhotoComments ON [User].ID = PhotoComments.UID INNER JOIN
                      Propic ON PhotoComments.UID = Propic.UID
WHERE     (Propic.[Current] = 1) AND (PhotoComments.PID = " + detid + @")
ORDER BY CID";

                thecbox.Visible = true;
                dt = photos.ReturnDT(getcomments);
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
           
            
            /*int itemid = int.Parse(k.Text);
           
            DataTable dt = new DataTable();
            string getc = @"SELECT     [User].Name, [User].ID, Comments.ID AS CID, Comments.Comment, Comments.ItemID, Comments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      Comments ON [User].ID = Comments.UID INNER JOIN
                      Propic ON Comments.UID = Propic.UID
WHERE     (Comments.ItemID = " + itemid + @") AND (Propic.[Current] = 1)
ORDER BY CID";
            dt = photos.ReturnDT(getc);
           
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
            
            
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "INSERT INTO PhewPhotos (UID , PID)VALUES (" + z + "," + detid + ")";
                photos.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM PhewPhotos WHERE PID = " + detid + "";
                dt = photos.ReturnDT(getcvalue);
                lk.Text = "Unphew(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "unphew";
               // return "photo" + dRView["AlID"].ToString();
            
           // int itemid = int.Parse(k.Text);
           
           /* int z = int.Parse(Session["UserID"].ToString());
            string iphew = "INSERT INTO Phew (UID , NID)VALUES (" + z + "," + itemid + ")";
            photos.DataBase(iphew);

            LinkButton lk = (LinkButton)dataItem.FindControl("phew");

            //How Much..
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM Phew WHERE NID = " + itemid + "";
            dt = photos.ReturnDT(getcvalue);
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
           
           
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "DELETE FROM PhewPhotos WHERE UID = " + z + " AND  PID = " + detid + "";
                photos.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM PhewPhotos WHERE PID = " + detid + "";
                dt = photos.ReturnDT(getcvalue);
                lk.Text = "Phew It!(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "phew";
                // return "photo" + dRView["AlID"].ToString();
            
            /*int itemid = int.Parse(k.Text);
            int X = int.Parse(Session["UserId"].ToString());
            string unphewup = "DELETE FROM Phew WHERE NID = " + itemid + " AND UID = " + X + "";
            photos.DataBase(unphewup);

            LinkButton lk = (LinkButton)dataItem.FindControl("phew");
            //How Much
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM Phew WHERE NID = " + itemid + "";
            dt = photos.ReturnDT(getcvalue);
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
            
            
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "INSERT INTO [LikePhotos] (UID , PID)VALUES (" + z + "," + detid + ")";
                photos.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM [LikePhotos] WHERE PID = " + detid + "";
                dt = photos.ReturnDT(getcvalue);
                lk.Text = "Unlike(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "unlike";
                // return "photo" + dRView["AlID"].ToString();
            
            
            
            
            
            /*int itemid = int.Parse(k.Text);
            
            int z = int.Parse(Session["UserID"].ToString());
            string iphew = "INSERT INTO [Like] (UID , NID)VALUES (" + z + "," + itemid + ")";
            photos.DataBase(iphew);

            LinkButton lk = (LinkButton)dataItem.FindControl("like");

            //How Much..
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [Like] WHERE NID = " + itemid + "";
            dt = photos.ReturnDT(getcvalue);
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
           
            
                int detid = int.Parse(wtf.Substring(5));
                string iphew = "DELETE FROM [LikePhotos] WHERE PID = " + detid + " AND UID = " + z + "";
                photos.DataBase(iphew);
                //How Much 
                DataTable dt = new DataTable();
                string getcvalue = "SELECT * FROM [LikePhotos] WHERE PID = " + detid + "";
                dt = photos.ReturnDT(getcvalue);
                lk.Text = "Like(" + dt.Rows.Count.ToString() + ")";
                lk.CommandName = "like";
                // return "photo" + dRView["AlID"].ToString();
            

           /* int itemid = int.Parse(k.Text);
            int X = int.Parse(Session["UserId"].ToString());
            string unphewup = "DELETE FROM [Like] WHERE NID = " + itemid + " AND UID = " + X + "";
            photos.DataBase(unphewup);

            LinkButton lk = (LinkButton)dataItem.FindControl("like");
            //How Much
            DataTable dt = new DataTable();
            string getcvalue = "SELECT * FROM [Like] WHERE NID = " + itemid + "";
            dt = photos.ReturnDT(getcvalue);
            lk.Text = "Like(" + dt.Rows.Count.ToString() + ")";
            lk.CommandName = "like";*/

        }
    }
 public string whatthehellthisis(object paruldidi)
 {
     DataRowView dRView = (DataRowView)paruldidi;
     
     
         return "photo" + dRView["P"].ToString();
     

 }

 protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
 {
     thecbox.Visible = false;
 }
 protected void RadGrid1_DataBound(object sender, EventArgs e)
 {
     thecbox.Visible = true;
     ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>fleXenv.fleXcrollMain('tobescrolled');</script>", false);
        
 }
}