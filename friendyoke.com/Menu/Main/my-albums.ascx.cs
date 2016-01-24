using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Menu_Main_my_albums : System.Web.UI.UserControl
{
    Db fbc = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {
        
        string getalbums = "SELECT * FROM Albums WHERE UID = " + Session["UserId"];
        DataTable dt = new DataTable();
        dt = fbc.ReturnDT(getalbums);
        albums.DataSource = dt;
        albums.DataBind();
        albums.Items[0].Selected = false;
    }
    protected void albums_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string getallph = @"SELECT     Photo,ID
FROM         Photos
WHERE     (AlbumID  = " + e.Value + ")";
        DataTable dt = new DataTable();
        dt = fbc.ReturnDT(getallph);
      Grid.DataSource = dt;
        Grid.DataBind();
        fullimg.Visible = false;
        del.Visible = false;
    }
    protected void Grid_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "showpic")
        {
            fullimg.Visible = true;
            del.Visible = true;
           HiddenField hd = (HiddenField)e.Item.FindControl("phid");
           int x = int.Parse(hd.Value);
           string getpph = @"select Photo from Photos where ID="+x+"";
           DataTable dt = new DataTable();
           dt = fbc.ReturnDT(getpph);
           fullimg.DataValue = (byte[])dt.Rows[0]["Photo"];
           fullimg.Height =600;
           fullimg.Width = 450;
           fullimg.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
           fullimg.CssClass = "theimage";
           del.CommandName = x.ToString();
          
        }
    }



    protected void abs_Click(object sender, EventArgs e)
    {
        string x = del.CommandName;
        string delete = @"DELETE FROM Photos
WHERE     (ID = " + x + ")";
        fbc.DataBase(delete);
        string getallph = @"SELECT     Photo,ID
FROM         Photos
WHERE     (AlbumID  = " + albums.SelectedValue + ")";
        DataTable dt = new DataTable();
        dt = fbc.ReturnDT(getallph);
        Grid.DataSource = dt;
        Grid.DataBind();
        fullimg.Visible = false;
        del.Visible = false;
        
    }
}