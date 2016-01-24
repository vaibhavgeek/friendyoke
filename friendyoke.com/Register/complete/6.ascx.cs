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
        string urprofile = "SELECT * FROM [Contact] WHERE UID=" + id + "";
        ds = profile.ReturnDS(urprofile);
        web.Text = ds.Tables[0].Rows[0]["Website"].ToString();
        phone.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
        email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
        add.Text = ds.Tables[0].Rows[0]["Address"].ToString();
    
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       int id = int.Parse(Session["UserID"].ToString());
            string up = @"UPDATE    Contact
SET              Website = '" + web.Text + "', Phone = '" + phone.Text + "', Email = '" + email.Text + "', Address = '" + add.Text + "' WHERE     (UID =" + id + ")";
        profile.DataBase(up);
    }
}