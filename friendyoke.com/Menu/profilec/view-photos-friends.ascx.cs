using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class Menu_profilec_view_photos_friends : System.Web.UI.UserControl
{
    Db photos = new Db();
    public DataTable dt;
    public DataTable dt2;
    protected void Page_Init(object sender, EventArgs e)
    {
        dt = new DataTable();
        string uname = Request.QueryString["uname"].ToString();
        string getall = @"select [ID] from [User] where [uname] = '" + uname + "'";
        dt = photos.ReturnDT(getall);

        string id = dt.Rows[0]["ID"].ToString();
        //string id = "84";
        string getphotos = @"SELECT     TOP (5) Photo, AlbumID
FROM         Photos

WHERE     (UID = " +id+@")
        ORDER BY ID DESC
        ";
        dt2 = new DataTable();
        dt2 = photos.ReturnDT(getphotos);
        Grid.DataSource = dt2;
        Grid.DataBind();
    }
}