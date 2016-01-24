using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class Profile_profilec_Achievements : System.Web.UI.UserControl
{
    Db fbc = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Page_Init(object sender, EventArgs e)
    {
       

         string uname = Request.QueryString["uname"].ToString();
        string getuid = "select [ID] from [User] where [uname] = '"+uname+"'";
        DataSet ds = new DataSet();
        ds = fbc.ReturnDS(getuid);
        string uidd = ds.Tables[0].Rows[0]["ID"].ToString();
        Session["VID"] = uidd;


        string getalbums = "SELECT * FROM Albums WHERE UID = " +uidd;
        DataTable dt = new DataTable();
        dt = fbc.ReturnDT(getalbums);
        albums.DataSource = dt;
        albums.DataBind();

        RadComboBoxItem item = new RadComboBoxItem();
        item.Value = "propic";
        item.Text = "Profile Photos";
        albums.Items.Add(item);

        RadComboBoxItem item2 = new RadComboBoxItem();
        item2.Value = "select";
        item2.Text = "Select Album";
        albums.Items.Add(item2);

        int d = albums.Items.Count;
        albums.Items[d-1].Selected = true;
    }
    public byte[] propics(object propic)
    {
        DataRowView dRView = (DataRowView)propic;
        if (dRView.Row.Table.Columns.Contains("Photo") == true)
        {
            return (byte[])dRView["Photo"];
        }
        else if (dRView.Row.Table.Columns.Contains("Image") == true)
        {
            return (byte[])dRView["Image"];
        }
        else { return null; }

        //dRView.Columns.Contains(columnName);
    /*
        try{
        //dRView["Photo"] is DBNull == false;
        
            return (byte[])dRView["Photo"];
        }
        catch{
        //dRView["Image"] is DBNull == false
        
        return (byte[])dRView["Image"];
        }*/
     

    }
   public string id(object vaibhav)
    {
        DataRowView dRView = (DataRowView)vaibhav;


        if (dRView.Row.Table.Columns.Contains("Photo") == true)
        {
            return "photo" + dRView["ID"].ToString();
        }
        else if (dRView.Row.Table.Columns.Contains("Image") == true)
        {
            return "propic" + dRView["ID"].ToString();
        }
        else { return null; }
       /*
        if (dRView["Photo"] is DBNull == false)
        {
            return "photo" + dRView["ID"].ToString();

        }
        else if (dRView["Image"] is DBNull == false)
        {
            return "propic" + dRView["ID"].ToString();
        }
        else
        {
            return null;
        }*/
    }
    protected void albums_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (e.Value == "propic")
        {
            string getprofilephotos = @"SELECT    ID, Image
FROM         Propic
WHERE     (UID = "+Session["VID"].ToString()+")";
            DataTable dt = new DataTable();
            dt = fbc.ReturnDT(getprofilephotos);
            Grid.DataSource = dt;
            Grid.DataBind();
            fullimg.Visible = false;
        }

        else if (e.Value == "select")
        { 
        
        }
        else
        {
            string getallph = @"SELECT     Photo,ID
FROM         Photos
WHERE     (AlbumID  = " + e.Value + ")";
            DataTable dt = new DataTable();
            dt = fbc.ReturnDT(getallph);
            Grid.DataSource = dt;
            Grid.DataBind();
            fullimg.Visible = false;

        }
    }
    protected void Grid_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.StartsWith("photo"))
        {
            fullimg.Visible = true;
          
           
            int x = int.Parse(e.CommandName.Substring(5));
            string getpph = @"select Photo from Photos where ID=" + x + "";
            DataTable dt = new DataTable();
            dt = fbc.ReturnDT(getpph);
            fullimg.DataValue = (byte[])dt.Rows[0]["Photo"];
            fullimg.Height = 600;
            fullimg.Width = 450;
            fullimg.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
            fullimg.CssClass = "theimage";
          

        }
        else if (e.CommandName.StartsWith("propic"))
        {
            fullimg.Visible = true;


            int x = int.Parse(e.CommandName.Substring(6));
            string getpph = @"select [Image] from [propic] where ID=" + x + "";
            DataTable dt = new DataTable();
            dt = fbc.ReturnDT(getpph);
            fullimg.DataValue = (byte[])dt.Rows[0]["Image"];
            fullimg.Height = 600;
            fullimg.Width = 450;
            fullimg.ResizeMode = Telerik.Web.UI.BinaryImageResizeMode.Fit;
            fullimg.CssClass = "theimage";
        }
    }



 
}