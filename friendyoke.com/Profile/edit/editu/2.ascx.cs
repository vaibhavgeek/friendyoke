using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Telerik.Web.UI;

public partial class Profile_edit_editu_1 : System.Web.UI.UserControl
{
    Db profile = new Db();
    public DataSet ds;
    protected void Page_Init(object sender, EventArgs e)
    {
        string id = Session["UserID"].ToString();
        ds = new DataSet();
        string urprofile = "SELECT * FROM [User] WHERE ID=" + id + "";
        ds = profile.ReturnDS(urprofile);
        school.Text = ds.Tables[0].Rows[0]["School"].ToString();
        col.Text = ds.Tables[0].Rows[0]["College"].ToString();
        company.Text = ds.Tables[0].Rows[0]["Company"].ToString();
        deg.Text = ds.Tables[0].Rows[0]["Degree"].ToString();
        des.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
        
    
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        
        string id = Session["UserID"].ToString();
        string getupdate = @" UPDATE [User] SET
                         College ='" + col.Text + "' , School = '" + school.Text + "', Company ='" + company.Text + "' , Degree ='" + deg.Text + "' , Designation='" + des.Text + "' WHERE (ID = "+id+")";

        profile.DataBase(getupdate);
    }
}