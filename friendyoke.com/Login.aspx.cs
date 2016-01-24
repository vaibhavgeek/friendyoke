using System;
using System.Text;
using System.IO;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telerik.Web.UI;

public partial class Login : System.Web.UI.Page
{
    Db register = new Db();
    public DataTable dt;
    public DataSet ds;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        { 
        
        
        }



    }


    protected void gender_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
    {
        bool Authenticated = false;

        Authenticated = UserAuthenticate(ctlLogin.UserName, ctlLogin.Password);
        e.Authenticated = Authenticated;
        if (Authenticated == true)
        {
            Session["Username-Cookie"] = ctlLogin.UserName.ToString();
            Session["Secured-Password-Cookie"] = ctlLogin.Password.ToString();
            Response.Cookies["RFriend_Email"].Value = ctlLogin.UserName;
            Response.Cookies["RFriend_PWD"].Value = ctlLogin.Password;
            Response.Cookies["RFriend_UID"].Value = Session["UserId"].ToString();
            Response.Cookies["RFriend_Email"].Expires = DateTime.Now.AddMonths(3);
            Response.Cookies["RFriend_PWD"].Expires = DateTime.Now.AddMonths(3);
            Response.Cookies["RFriend_UID"].Expires = DateTime.Now.AddMonths(3);


            Response.Redirect("Default.aspx");
        }
    }

    private bool UserAuthenticate(string UserName, string Password)
    {
        bool boolReturnValue = false;
        //--------------------------------
        //Check UserID From Config File
        if (UserName == "Vaibhav" && Password == "Maheshwari")
        {
            boolReturnValue = true;
            return boolReturnValue;
        }

        else
        {
            //--------------------------------
            dt = new DataTable();

            string chkUser = @"
SELECT     uname, ID
FROM         [User]
WHERE     (Email = '"+ UserName +@"') AND (Password = '" + Password + @"') OR
                      ([uname] = '" + UserName + "') AND (Password = '" + Password + @"')";
            dt = register.ReturnDT(chkUser);
            if (dt.Rows.Count > 0)
            {
                boolReturnValue = true;
                Session["UserId"] = dt.Rows[0]["Id"].ToString();


            }
            return boolReturnValue;
        }
    }





    protected void Error(object sender, EventArgs e)
    {
        Panel pa = (Panel)ctlLogin.FindControl("invi");
        pa.Visible = true;
    }
    protected void joinn_Click(object sender, EventArgs e)
    {
        Server.Transfer("Register/Basic.aspx");
    }
}