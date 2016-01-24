using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

public partial class Sidebar_Notification : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        dt = new DataTable();

        string get = @"SELECT     Notifications.NText, Notifications.FromID, Notifications.ToID, Propic.Image,Notifications.Type, Notifications.[Read]
FROM         Notifications INNER JOIN
                      Propic ON Notifications.FromID = Propic.UID
WHERE     (Propic.[Current] = 1) AND (Notifications.ToID = " +Session["UserId"]+@")
ORDER BY Notifications.[Read] DESC";
        dt = dbClass.ReturnDT(get);
        RadGrid1.DataSource = dt;

    }
    public string message(object somefuck)
    {
        DataRowView dRView = (DataRowView)somefuck;
        int x =  (int)dRView["Type"];
        if (dRView["Type"] is DBNull)
        {
            return null;

        }
        else if (x == 0)
        {
            return "Someperson notified you";

        }
        else
        {
            return "";
        }
    }
}