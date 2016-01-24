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

namespace fy
{
    public partial class Menu_profilec_recent_posts : System.Web.UI.UserControl
    {
        Db dbClass = new Db();
        public DataTable dt;
        public DataSet ds;
        public void bindit()
        {
            string uname = Request.QueryString["uname"].ToString();
            string getall = @"select [ID] from [User] where [uname] = '" + uname + "'";
            dt = new DataTable();
            dt = dbClass.ReturnDT(getall);
            string vid = dt.Rows[0]["ID"].ToString();
            string getfeed = @"SELECT     TOP (10) newsfeed.FromID, newsfeed.Message, newsfeed.SendDate, newsfeed.SendTime, newsfeed.P, newsfeed.ID AS NID, [User].Name, Propic.Image AS profilepic, 
                      Photos.Photo, Albums.Name AS aname, Albums.ID AS aid, [User].ID, newsfeed.AlID
FROM         newsfeed INNER JOIN
                      [User] ON newsfeed.FromID = [User].ID INNER JOIN
                      Propic ON newsfeed.FromID = Propic.UID INNER JOIN
                      Photos ON newsfeed.P = Photos.ID INNER JOIN
                      Albums ON Photos.AlbumID = Albums.ID
WHERE     ([User].ID = "+vid+@") AND (Propic.[Current] = 1)
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
                string somep = dt.Rows.Count.ToString() + " comments";
                return somep;
                //return "album" + dRView["AlID"].ToString();
            }
            else if (dRView["AlID"] is DBNull == false)
            {
                string getcvalue = "SELECT * FROM AlbumComments WHERE AID = " + (int)dRView["AlID"] + "";
                dt = dbClass.ReturnDT(getcvalue);
                string somep = dt.Rows.Count.ToString() + " comments";
                return somep;
                //return "album" + dRView["AlID"].ToString();
            }
            else if (dRView["P"].ToString() != "1")
            {
                string getcvalue = "SELECT * FROM PhotoComments WHERE PID = " + (int)dRView["P"] + "";
                dt = dbClass.ReturnDT(getcvalue);
                string somep = dt.Rows.Count.ToString() + " comments";
                return somep;
                //return "photo" + dRView["P"].ToString();
            }
            else
            {
                string getcvalue = "SELECT * FROM Comments WHERE ItemID = " + (int)dRView["NID"] + "";
                dt = dbClass.ReturnDT(getcvalue);
                string somep = dt.Rows.Count.ToString() + " comments";
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

                        string somep = "unphew(" + dt.Rows.Count.ToString() + ")";
                        return somep;
                    }
                    else
                    {
                        string somepa = "phew it!(" + dt.Rows.Count.ToString() + ")";
                        return somepa;
                    }
                }
                string abc = "phew it!(" + dt.Rows.Count.ToString() + ")";
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

                        string somep = "unphew(" + dt.Rows.Count.ToString() + ")";
                        return somep;
                    }
                    else
                    {
                        string somepa = "phew It!(" + dt.Rows.Count.ToString() + ")";
                        return somepa;
                    }
                }
                string abc = "phew it!(" + dt.Rows.Count.ToString() + ")";
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

                        string somep = "unphew(" + dt.Rows.Count.ToString() + ")";
                        return somep;
                    }
                    else
                    {
                        string somepa = "phew it!(" + dt.Rows.Count.ToString() + ")";
                        return somepa;
                    }
                }
                string abc = "phew it!(" + dt.Rows.Count.ToString() + ")";
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

                        string somep = "unphew(" + dt.Rows.Count.ToString() + ")";
                        return somep;
                    }
                    else
                    {
                        string somepa = "phew it!(" + dt.Rows.Count.ToString() + ")";
                        return somepa;
                    }
                }
                return "phew it!(" + dt.Rows.Count.ToString() + ")";
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
                return "album : " + dRView["aname"].ToString();

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

                        string somep = "unlike(" + dt.Rows.Count.ToString() + ")";
                        return somep;
                    }
                    else
                    {
                        string somepa = "like(" + dt.Rows.Count.ToString() + ")";
                        return somepa;
                    }
                }
                return "like(" + dt.Rows.Count.ToString() + ")";
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

                        string somep = "unlike(" + dt.Rows.Count.ToString() + ")";
                        return somep;
                    }
                    else
                    {
                        string somepa = "like(" + dt.Rows.Count.ToString() + ")";
                        return somepa;
                    }
                }
                return "like(" + dt.Rows.Count.ToString() + ")";
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

                        string somep = "lnlike(" + dt.Rows.Count.ToString() + ")";
                        return somep;
                    }
                    else
                    {
                        string somepa = "like(" + dt.Rows.Count.ToString() + ")";
                        return somepa;
                    }
                }
                return "like(" + dt.Rows.Count.ToString() + ")";
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

                        string somep = "unlike(" + dt.Rows.Count.ToString() + ")";
                        return somep;
                    }
                    else
                    {
                        string somepa = "like(" + dt.Rows.Count.ToString() + ")";
                        return somepa;
                    }
                }
                return "like(" + dt.Rows.Count.ToString() + ")";
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
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {

           

            
        }
        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {

            if (e.CommandName == "phew")
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
                    lk.Text = "unphew(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "unphew(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "unphew(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "phew it!(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "phew it!(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "phew it!(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "unlike(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "unlike(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "unlike(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "like(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "like(" + dt.Rows.Count.ToString() + ")";
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
                    lk.Text = "like(" + dt.Rows.Count.ToString() + ")";
                    lk.CommandName = "like";
                    //  r
                }


            }

        }
        protected void datasource(object sender, GridNeedDataSourceEventArgs e)
        {
            bindit();
        }
      

    }
}