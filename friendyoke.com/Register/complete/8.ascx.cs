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
        string urprofile = "SELECT * FROM [Networks] WHERE UID=" + id + "";
        ds = profile.ReturnDS(urprofile);
        fb.Text = ds.Tables[0].Rows[0]["Facebook"].ToString();
        twit.Text = ds.Tables[0].Rows[0]["Twitter"].ToString();
        plus.Text = ds.Tables[0].Rows[0]["Plus"].ToString();
        lin.Text = ds.Tables[0].Rows[0]["Linkedin"].ToString();

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int id = int.Parse(Session["UserID"].ToString());
        string up = @"UPDATE    Networks
SET              Facebook = '" + fb.Text + "', Twitter = '" + twit.Text + "', Plus = '" + plus.Text + "', Linkedin = '" + lin.Text + "' WHERE     (UID =" + id + ")";
        profile.DataBase(up);
    }
}