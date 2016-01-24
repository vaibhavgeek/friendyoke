using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Design_footer : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((!object.Equals(Request.Cookies["RFriend_Email"], null)) && (!object.Equals(Request.Cookies["RFriend_PWD"], null)) && (!object.Equals(Request.Cookies["RFriend_UID"], null)))
        {
            if ((!object.Equals(Request.Cookies["RFriend_Email"].Value, "")) && (!object.Equals(Request.Cookies["RFriend_PWD"].Value, "")) && (!object.Equals(Request.Cookies["RFriend_UID"], "")))
            {
                Session["UserEmail"] = Request.Cookies["RFriend_Email"].Value;
                Session["Password"] = Request.Cookies["RFriend_PWD"].Value;
                Session["UserId"] = Request.Cookies["RFriend_UID"].Value;

            }
            else
            {

            }
        }
        
      

    }
}