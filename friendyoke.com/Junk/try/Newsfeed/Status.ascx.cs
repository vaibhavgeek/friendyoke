using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Newsfeed_Status : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void postfeed_Click(object sender, EventArgs e)
    {
        if (maincontent.Text == "" || maincontent.Text == null)
        { 
        
        }
        else
        {
            string conntenn = maincontent.Text;
            conntenn = conntenn.Replace("\n", "<br/>");
            conntenn = conntenn.Replace("\r", "&nbsp;&nbsp;");
            string postScrap = @"Insert INTO newsfeed (FromId,Message,SendDate,SendTime,P) 
                                    VALUES('" + Session["UserId"].ToString() + "','" + conntenn + "','" + System.DateTime.Now.Date.Day.ToString() + "/" +DateTime.Now.Date.Month.ToString() + "' , '" + System.DateTime.Now.ToShortTimeString() + "',1)";
            dbClass.DataBase(postScrap);
            maincontent.Text = "";
        }
    }
}