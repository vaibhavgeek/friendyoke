using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
namespace fy
{
    public partial class about : System.Web.UI.UserControl
    {
        public string abcd
        {
            get
            {

                return (string)ViewState["abc"];
            }
            set
            {

                ViewState["abc"] = value;

            }
        }
        Db dbclass = new Db();
        DataSet ds = new DataSet();
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string wtf = abcd;
            if (wtf.StartsWith("c"))
            {
                ptb.Visible = true;
                Post.Visible = true;
                DataTable dt = new DataTable();
                if (wtf.StartsWith("calbum"))
                {
                    int detid = int.Parse(wtf.Substring(6));
                    string getcomments = @"SELECT    [User].Name, [User].ID, AlbumComments.ID AS CID, AlbumComments.Comment, AlbumComments.AID, AlbumComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      AlbumComments ON [User].ID = AlbumComments.UID INNER JOIN
                      Propic ON AlbumComments.UID = Propic.UID
WHERE     (AlbumComments.AID = " + detid + @") AND (Propic.[Current] = 1)
ORDER BY CID";
                    dt = dbclass.ReturnDT(getcomments);




                }
                else if (wtf.StartsWith("cphoto"))
                {
                    int detid = int.Parse(wtf.Substring(6));
                    string getcomments = @"SELECT     [User].Name, [User].ID, PhotoComments.ID AS CID, PhotoComments.Comment, PhotoComments.PID, PhotoComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      PhotoComments ON [User].ID = PhotoComments.UID INNER JOIN
                      Propic ON PhotoComments.UID = Propic.UID
WHERE     (Propic.[Current] = 1) AND (PhotoComments.PID = " + detid + @")
ORDER BY CID";

                    dt = dbclass.ReturnDT(getcomments);


                }
                else
                {
                    int detid = int.Parse(wtf.Substring(8));
                    string getcomments = @"SELECT     [User].Name, [User].ID, Comments.ID AS CID, Comments.Comment, Comments.ItemID, Comments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      Comments ON [User].ID = Comments.UID INNER JOIN
                      Propic ON Comments.UID = Propic.UID
WHERE     (Comments.ItemID =  " + detid + @") AND (Propic.[Current] = 1)
ORDER BY CID";
                    dt = dbclass.ReturnDT(getcomments);

                }
                foreach (DataRow m in dt.Rows)
                {

                    RadBinaryImage img = new RadBinaryImage();
                    img.DataValue = (byte[])m["Image"];
                    img.Width =35;
                    img.Height = 35;
                    img.ResizeMode = BinaryImageResizeMode.Crop;
                    img.CssClass = "magea";


                    Label name = new Label();
                    name.Text = "~" + m["Name"].ToString() + "<br>";
                    name.ForeColor = System.Drawing.Color.Black;

                    Label cmnnt = new Label();
                    cmnnt.Text ="<b>"+ m["Comment"].ToString()+"</b>";
                    cmnnt.ForeColor = System.Drawing.Color.Black;

                    Table tb = new Table();
                    TableRow tr = new TableRow();

                    TableCell cell = new TableCell();
                    cell.Controls.Add(img);
                    cell.VerticalAlign = System.Web.UI.WebControls.VerticalAlign.Top;
                    tr.Cells.Add(cell);


                    TableCell cmnt = new TableCell();
                    cmnt.Controls.Add(name);
                    cmnt.Controls.Add(cmnnt);
                    cell.VerticalAlign = System.Web.UI.WebControls.VerticalAlign.Top;
                    tr.Cells.Add(cmnt);

                    tb.Rows.Add(tr);
                    emptypanel.Controls.Add(tb);
                }
               
            
            }
           else if (wtf.StartsWith("phewnlike"))
            {
                ptb.Visible = false;
                Post.Visible = false;
                DataTable dt2 = new DataTable();
                DataTable dt3 = new DataTable();
                string m = wtf.Substring(9);

                if (m.StartsWith("album"))
                {
                    int detid = int.Parse(m.Substring(5));
                    string getphew = @"SELECT     Propic.Image
FROM         PhewAlbums INNER JOIN
                      Propic ON PhewAlbums.UID = Propic.UID
WHERE     (PhewAlbums.AID = " + detid + ") AND (Propic.[Current] = 1)";

                    string getlike = @"SELECT     Propic.Image
FROM         LikeAlbums INNER JOIN
                      Propic ON LikeAlbums.UID = Propic.UID
WHERE     (LikeAlbums.AID = " + detid + ") AND (Propic.[Current] = 1)";

                    dt3 = dbclass.ReturnDT(getlike);
                    dt2 = dbclass.ReturnDT(getphew);
                    



                }
                else if (m.StartsWith("photo"))
                {
                    int detid = int.Parse(m.Substring(5));
                    string getphew = @"SELECT     Propic.Image
FROM         PhewPhotos INNER JOIN
                      Propic ON PhewPhotos.UID = Propic.UID
WHERE     (PhewPhotos.PID = " + detid + ") AND (Propic.[Current] = 1)";
                    string getlike = @"SELECT     Propic.Image
FROM         LikePhotos INNER JOIN
                      Propic ON LikePhotos.UID = Propic.UID
WHERE     (LikePhotos.PID = " + detid + ") AND (Propic.[Current] = 1)";

                    dt3 = dbclass.ReturnDT(getlike);
                    dt2 = dbclass.ReturnDT(getphew);


                }
                else
                {
                    int detid = int.Parse(m.Substring(7));
                    string getphew = @"SELECT     Propic.Image
FROM         Phew INNER JOIN
                      Propic ON Phew.UID = Propic.UID
WHERE     (Phew.NID = " + detid + ") AND (Propic.[Current] = 1)";

                    string getlike = @"SELECT     Propic.Image
FROM         [Like] INNER JOIN
                      Propic ON [Like].UID = Propic.UID
WHERE     ([Like].NID = " + detid + ") AND (Propic.[Current] = 1)";

                    dt3 = dbclass.ReturnDT(getlike);
                    dt2 = dbclass.ReturnDT(getphew);

                }

                if (dt3.Rows.Count > 0)
                {
                    Label likedby = new Label();
                    likedby.Text = "post is likd by :-" + "<br>";
                    likedby.CssClass = "alitbig";
                    emptypanel.Controls.Add(likedby);
                    if (dt3.Rows.Count > 0)
                    {
                        foreach (DataRow a in dt3.Rows)
                        {
                            RadBinaryImage img = new RadBinaryImage();
                            img.DataValue = (byte[])a["Image"];
                            img.Width = 50;
                            img.Height = 50;
                            img.CssClass = "magea";
                            img.ResizeMode = BinaryImageResizeMode.Crop;
                            //img.ID = x.ToString();
                            emptypanel.Controls.Add(img);

                        }
                        Label br = new Label();
                        br.Text =  "<br>";
                        emptypanel.Controls.Add(br);
                    }
                    
                }

                if (dt2.Rows.Count > 0)
                {

                    Label phewdby = new Label();
                    phewdby.Text = "post is phewd by :-" + "<br>";
                    phewdby.CssClass = "alitbig";
                    emptypanel.Controls.Add(phewdby);
                    foreach (DataRow a in dt2.Rows)
                    {
                        RadBinaryImage img = new RadBinaryImage();
                        img.DataValue = (byte[])a["Image"];
                        img.Width = 50;
                        img.Height =50;
                        img.CssClass = "magea";
                        img.ResizeMode = BinaryImageResizeMode.Crop;
                        //img.ID = x.ToString();
                        emptypanel.Controls.Add(img);

                    }

                }
               
            
            }


            else if (wtf.StartsWith("aalbum"))
            {
                ptb.Visible = false;
                Post.Visible = false;
                int detid = int.Parse(wtf.Substring(6));
                string selectallph = @"SELECT     newsfeed.AlID, newsfeed.Message, Photos.Photo
FROM         newsfeed INNER JOIN
                      Photos ON newsfeed.AlID = Photos.AlbumID
WHERE     (Photos.AlbumID = " + detid + ")";


                DataTable dt = new DataTable();
                dt = dbclass.ReturnDT(selectallph);
                Label lbl = new Label();
                lbl.Text = dt.Rows[0]["Message"].ToString() + "<br/>";
                lbl.CssClass = "alitbig";
                emptypanel.Controls.Add(lbl);

                for (int x = 0; x < dt.Rows.Count; x++)
                {

                    RadBinaryImage img = new RadBinaryImage();
                    img.DataValue = (byte[])dt.Rows[x]["Photo"];
                    img.Width = 115;
                    img.Height = 117;
                    img.ResizeMode = BinaryImageResizeMode.Crop;
                    img.ID = x.ToString();
                    emptypanel.Controls.Add(img);

                }



                //text above photo
                //loads albumid 117 * 117
                //3 photos in one time..




            }
            else if (wtf.StartsWith("aphoto"))
            {
                ptb.Visible = false;
                Post.Visible = false;
                int detid = int.Parse(wtf.Substring(6));
                string getphotontext = @"SELECT     newsfeed.Message, newsfeed.P , Photos.Photo
FROM         newsfeed INNER JOIN
                      Photos ON newsfeed.P = Photos.ID
WHERE     (Photos.ID = " + detid + ")";
                DataTable dt = new DataTable();
                dt = dbclass.ReturnDT(getphotontext);
                Label lbl = new Label();
                lbl.Text = dt.Rows[0]["Message"].ToString() + "<br/>";
                RadBinaryImage img = new RadBinaryImage();
                img.DataValue = (byte[])dt.Rows[0]["Photo"];
                img.CssClass = "theimage";
                img.ResizeMode = BinaryImageResizeMode.Fit;
                Random rnd = new Random();
                int k = rnd.Next();
                img.ID = k.ToString();
                lbl.CssClass = "alitbig";
                emptypanel.Controls.Add(img);
                img.Width = 370;
                img.Height = 480;
                //text above photo
                //loads photo id
                // loads phoos -- 350 * depends upon phptograph


            }
            else
            {
                ptb.Visible = false;
                Post.Visible = false;
                int detid = int.Parse(wtf.Substring(8));
                string getnewsfeed = @"SELECT     Message
FROM         newsfeed
WHERE     (ID = " + detid + ")";
                DataTable dt = new DataTable();
                dt = dbclass.ReturnDT(getnewsfeed);

                Label lbl = new Label();
                lbl.Text = dt.Rows[0]["Message"].ToString() + "<br/>";
                lbl.CssClass = "bigfont";
                emptypanel.Controls.Add(lbl);
            }
            //this.SqlDataSource1.SelectParameters["NID"].DefaultValue = this.NID;
            //this.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Post_Click(object sender, EventArgs e)
        {
            ptb.Visible = true;
            Post.Visible = true;
            if (ptb.Text == "")
            {
            }
            else
            {
                string wtf = abcd;
                int z = int.Parse(Session["UserID"].ToString());
                string conntenn = ptb.Text;
                conntenn = conntenn.Replace("\n", "<br/>");
                conntenn = conntenn.Replace("\r", "&nbsp;&nbsp;");
                if (wtf.StartsWith("calbum"))
                {
                    int detid = int.Parse(wtf.Substring(6));
                    string me = @"INSERT INTO AlbumComments (AID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                    dbclass.DataBase(me);
                    // return "album" + dRView["AlID"].ToString();

                }
                else if (wtf.StartsWith("cphoto"))
                {
                    int detid = int.Parse(wtf.Substring(6));
                    string me = @"INSERT INTO PhotoComments (PID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                    dbclass.DataBase(me);
                    // return "photo" + dRView["AlID"].ToString();
                }
                else
                {
                    int detid = int.Parse(wtf.Substring(8));
                    string me = @"INSERT INTO Comments (ItemID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                    dbclass.DataBase(me);
                }
                ptb.Text = "";
            }
        }
        
            
        
}
}