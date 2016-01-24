using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class Public_Profiles_Just_Get_Feeds : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void bindit()
    {

        string getfeed = @"SELECT     [User].Name AS Uname, [User].Image, [User].ID AS Expr2, s.FromID, s.Message, s.SendDate, s.SendTime, s.ID AS NID, s.P, s.AlID, Propic.Image AS profilepic, Photos.*, 
                      Albums.*
FROM         [User] INNER JOIN
                      newsfeed AS s ON [User].ID = s.FromID INNER JOIN
                      Propic ON s.FromID = Propic.UID INNER JOIN
                      Photos ON s.P = Photos.ID INNER JOIN
                      Albums ON Photos.AlbumID = Albums.ID
WHERE     ([User].ID IN
                          (SELECT     SID AS ID
                            FROM          Box AS Friends_2
                            WHERE      (MyID = "+Session["UserId"]+@"))) AND (Propic.[Current] = 1)
ORDER BY NID DESC";

        dt = dbClass.ReturnDT(getfeed);

        if (dt.Rows.Count > 0)
        {
            RadGrid1.DataSource = dt;

        }
        else
        {
            RadGrid1.Visible = false;
            //frndsn.Text = "You do not have any newsfeed,ask your friends to connect , share and enjoy! ";
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

        if (dRView["P"].ToString() != "1" && dRView["AlID"] is DBNull == false)
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
    protected void datasource(object sender, GridNeedDataSourceEventArgs e)
    {
        bindit();
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
            string getcvalue = "SELECT * FROM [LikeAlbums] WHERE NID = " + (int)dRView["AlID"] + "";
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
    {
        DataRowView dRView = (DataRowView)somebr;
        if (dRView["P"].ToString() == "1")
        { return ""; }
        else { return "<br/>"; }
    }
    public string whatthehellthisis(object paruldidi)
    {
        DataRowView dRView = (DataRowView)paruldidi;
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

    protected void RadGrid2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        string feedwala = @"SELECT     TOP (5) [User].Name, [User].ID, Propic.Image
FROM         [User] INNER JOIN
                      Box AS s ON [User].ID = s.SID INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     (Propic.[Current] = 1)
ORDER BY NEWID()";
        dt = new DataTable();
        dt = dbClass.ReturnDT(feedwala);
        RadGrid2.DataSource = dt;
    }
}