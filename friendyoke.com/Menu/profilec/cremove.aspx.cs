using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Menu_profilec_cremove : System.Web.UI.Page
{
    Db rem = new Db();

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        string uname = Request.QueryString["uname"].ToString();
        string getpic = @" SELECT     Propic.Image , [User].[ID]
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     (Propic.[Current] = 1) AND ([User].uname = '" +uname+"')";
        dt = rem.ReturnDT(getpic);
        propic.DataValue = (byte[])dt.Rows[0]["Image"];
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string uname = Request.QueryString["uname"].ToString();
        string getall = @"select [ID] from [User] where [uname] = '" + uname + "'";
        DataTable dt = new DataTable();
        dt = new DataTable();
        dt = rem.ReturnDT(getall);
        string vid = dt.Rows[0]["ID"].ToString();
        string unfriendhim = @"DELETE FROM Friends
WHERE     (FriendID = " + Session["UserId"] + @") AND (MyID = " + vid + @") OR
                      (FriendID = " + vid + @") AND (MyID = " + Session["UserId"] + @")";
        rem.DataBase(unfriendhim);
        Button1.Text = "connection removed!";
    }
}