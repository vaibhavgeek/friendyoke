using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PoacherHub_meadnmine_explorer : System.Web.UI.Page
{
    Db profile = new Db();
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        string idd = Session["UserId"].ToString();
        int id = int.Parse(idd);

        string urprofile = "SELECT * FROM [User] WHERE ID=" + id + "";
        ds = profile.ReturnDS(urprofile);
        string email = ds.Tables[0].Rows[0]["Email"].ToString();
        string name = ds.Tables[0].Rows[0]["Name"].ToString();
        FileExplorer1.Configuration.DeletePaths = new string[] { "~/Database/Users/" + email + "/" + name + "/Photos/Mimages" };
        FileExplorer1.Configuration.ViewPaths = new string[] { "~/Database/Users/" + email + "/" + name + "/Photos/Mimages" };
        FileExplorer1.Configuration.UploadPaths = new string[] { "~/Database/Users/" + email + "/" + name + "/Photos/Mimages" };
    }
}