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
        string urprofile = "SELECT * FROM [Political] WHERE UID=" + id + "";
        ds = profile.ReturnDS(urprofile);
        rel.Text = ds.Tables[0].Rows[0]["Religion"].ToString();
        quote.Text = ds.Tables[0].Rows[0]["Quote"].ToString();
        life.Text = ds.Tables[0].Rows[0]["Life"].ToString();
        pol.Text = ds.Tables[0].Rows[0]["Political"].ToString();
        
        

    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id = Session["UserID"].ToString();
        string getupdate = @"UPDATE [Political] SET
                         Religion ='" + rel.Text + "' , Quote = '" + quote.Text + "', Life = '" + life.Text + "',Political='" + pol.Text + "' WHERE (UID="+id+")";

       profile.DataBase(getupdate);
    
    }
}