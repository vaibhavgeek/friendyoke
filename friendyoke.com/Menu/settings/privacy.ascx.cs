using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Menu_settings_privacy2 : System.Web.UI.UserControl
{
    Db sett = new Db();
     DataTable dt = new DataTable();
     protected void Page_Init(object sender, EventArgs e)
     {
         if (!Page.IsPostBack)
         {
             gset();
         }
         // key ==>
         /*
          * contact = info
          * posts = recent-posts
          * more = connections
          *  eduwork = inside-box 
          *  photos = albums
          */
     }
    public void gset()
    {
        string getsettings = @"SELECT     contact, more, eduwork, photos, posts , messageh , addfyoke
FROM         [User]
WHERE     (ID = "+Session["UserId"]+")";
        dt = sett.ReturnDT(getsettings);
       RadioButtonList4.SelectedIndex =  (int)dt.Rows[0]["contact"];

        RadioButtonList5.SelectedIndex = (int)dt.Rows[0]["more"];

       RadioButtonList2.SelectedIndex=  (int)dt.Rows[0]["eduwork"];

        RadioButtonList3.SelectedIndex = (int)dt.Rows[0]["photos"];

       RadioButtonList1.SelectedIndex =  (int)dt.Rows[0]["posts"];

       RadioButtonList6.SelectedIndex = (int)dt.Rows[0]["messageh"];

       RadioButtonList7.SelectedIndex = (int)dt.Rows[0]["addfyoke"];


    }
    protected void Button1_Click(object sender, EventArgs e)
    {


         
        string updatee = @"UPDATE    [User]
SET              contact = " + RadioButtonList4.SelectedItem.Value + ", more = " + RadioButtonList5.SelectedItem.Value + @",
eduwork = " + RadioButtonList2.SelectedItem.Value + ",messageh = "+RadioButtonList6.SelectedItem.Value+", addfyoke = "+RadioButtonList7.SelectedItem.Value+" ,photos = " + RadioButtonList3.SelectedItem.Value + ", posts = " + RadioButtonList1.SelectedItem.Value + " WHERE     (ID = " + Session["UserId"] + ")";
        sett.DataBase(updatee);
        Button2.Text = "settings saved :)";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        gset();
        Button2.Text = "load saved settings";
    }
}