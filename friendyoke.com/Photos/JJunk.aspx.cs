using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Photos_Viewer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void loadalbum(int aid)
    {
        string getphotos = @"SELECT     Albums.Name, Albums.UID, Photos.Photo, Photos.UID AS UserID, Photos.AlbumID, Photos.ID, Albums.ID AS AID
FROM         Albums INNER JOIN
                      Photos ON Albums.ID = Photos.AlbumID
WHERE     (Photos.AlbumID = " + aid + ")";
        ViewState["AlbumC"] = aid.ToString();
        DataTable dt1 = new DataTable();
        dt1 = photos.ReturnDT(getphotos);

        RadGrid1.DataSource = dt1;
       

    }
    protected void datasource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }
    protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }
    protected void RadGrid1_ItemCommand1(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {

    }
}