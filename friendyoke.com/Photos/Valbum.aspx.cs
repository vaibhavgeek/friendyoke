using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
public partial class Photos_Valbum : System.Web.UI.Page
{
    Db phhotos = new Db();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string det = Request.QueryString["uid"].ToString();
        string checkif = "SELECT * FROM Friends WHERE (MyId=" + Session["UserId"].ToString() + " and FriendId=" + det + " and FriendStatus =1) OR (MyId=" + det + " and FriendId=" + Session["UserId"].ToString() + " and FriendStatus =1)";
        DataTable dt = new DataTable();
        dt = phhotos.ReturnDT(checkif);
        if (dt.Rows.Count > 0)
        {
            string getalbums = @"SELECT     Albums.Name, Albums.UID, Albums.ID, Albums.Random, [User].Name AS Uname
FROM         Albums INNER JOIN
                      [User] ON Albums.UID = [User].ID
WHERE     (Albums.UID = "+det+")";
            DataTable dt2 = new DataTable();
            dt2 = phhotos.ReturnDT(getalbums);
            uname.Text = dt2.Rows[0]["Uname"].ToString();
            for(int x= 0;x<dt2.Rows.Count;x++)
            {
                RadBinaryImage img = new RadBinaryImage();
                string getph = @"SELECT     TOP (1) AlbumID, Photo, UID , ID
FROM         Photos
WHERE     (AlbumID = "+dt2.Rows[x]["ID"]+")";


                DataTable dynamica = new DataTable();
                dynamica = phhotos.ReturnDT(getph);
                if (dynamica.Rows.Count > 0)
                {
                   
                    img.DataValue = (byte[])dynamica.Rows[0]["Photo"];
                    img.Width = Unit.Pixel(300);
                    img.Height = Unit.Pixel(100);
                    img.ResizeMode = BinaryImageResizeMode.Fit;
                    img.CssClass = "alimg";
                    img.Attributes.Add("onclick", "goto('Viewer.aspx?determiner=album" + dt2.Rows[x]["ID"] + "')");
                    Panel1.Controls.Add(img);
                } 
            }
        }
    }
}