using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Profile_edit_editu_1 : System.Web.UI.UserControl
{
    Db profile = new Db();
    public DataSet ds;
    protected void Page_Init(object sender, EventArgs e)
    {
        string id = Session["UserID"].ToString();
        ds = new DataSet();
        string urprofile = "SELECT * FROM [Ement] WHERE UID=" + id + "";
        ds = profile.ReturnDS(urprofile);
        mov.Text = ds.Tables[0].Rows[0]["Movies"].ToString();
        music.Text = ds.Tables[0].Rows[0]["Music"].ToString();
        books.Text = ds.Tables[0].Rows[0]["Books"].ToString();
        pol.Text = ds.Tables[0].Rows[0]["Television"].ToString();
        sports.Text = ds.Tables[0].Rows[0]["Sports"].ToString();



    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = Session["UserID"].ToString();
        string getupdate = @"UPDATE [Ement] SET
                         Movies ='" + mov.Text + "' , Music = '" + music.Text + "', Books = '" + books.Text + "',Television='" + pol.Text + "' , Sports = '"+sports.Text+"'  WHERE (UID=" + id + ")";

        profile.DataBase(getupdate);

    }
}