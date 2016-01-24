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
        string urprofile = "SELECT * FROM [Achieve] WHERE UID=" + id + "";
        ds = profile.ReturnDS(urprofile);
        achieve.Text = ds.Tables[0].Rows[0]["Achievement"].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = Session["UserID"].ToString();
        string getupdate = @"UPDATE [Achieve] SET
                         Achievement ='" + achieve.Text + "' WHERE (UID=" + id + ")";

        profile.DataBase(getupdate);

    }
}