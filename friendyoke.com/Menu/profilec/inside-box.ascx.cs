using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
public partial class Profile_profilec_Achievements : System.Web.UI.UserControl
{

    Db profile = new Db();
    DataTable dt = new DataTable();
    protected void Page_Init(object sender, EventArgs e)
    {
        string uname = Request.QueryString["uname"].ToString();
        string getall = @"select [ID] from [User] where [uname] = '" + uname + "'";
        dt = new DataTable();
        dt = profile.ReturnDT(getall);
        string vid = dt.Rows[0]["ID"].ToString();

        string inhisbox = @"SELECT     Box.SID, Propic.Image, [User].uname
FROM         Box INNER JOIN
                      Propic ON Box.SID = Propic.UID INNER JOIN
                      [User] ON Box.SID = [User].ID
WHERE     (Box.MyID = " +vid+") AND (Propic.[Current] = 1)";
        DataTable dt2 = new DataTable();
        dt2 = profile.ReturnDT(inhisbox);
        foreach (DataRow m in dt2.Rows)
        {
            RadBinaryImage rbg = new RadBinaryImage();
            rbg.ResizeMode = BinaryImageResizeMode.Crop;
            rbg.Width = 85;
            rbg.Height = 85;
            rbg.CssClass = "mageaa";
            rbg.DataValue = (byte[])m["Image"];
            HyperLink hyper = new HyperLink();
            hyper.NavigateUrl = "~/Menu/profile.aspx?uname="+m["uname"]+"";
            hyper.Controls.Add(rbg);
            inbox.Controls.Add(hyper);
        }



        string isboxedby = @"SELECT     Propic.Image, [User].uname, Box.MyID
FROM         Box INNER JOIN
                      Propic ON Box.MyID = Propic.UID INNER JOIN
                      [User] ON Box.MyID = [User].ID
WHERE     (Propic.[Current] = 1) AND (Box.SID = "+vid+")";
        DataTable dt3 = new DataTable();
        dt3 = profile.ReturnDT(isboxedby);

        foreach (DataRow m in dt3.Rows)
        {
            RadBinaryImage rbg = new RadBinaryImage();
            rbg.ResizeMode = BinaryImageResizeMode.Crop;
            rbg.Width = 85;
            rbg.Height = 85;
            rbg.CssClass = "mageaa";
            rbg.DataValue = (byte[])m["Image"];
            HyperLink hyper = new HyperLink();
            hyper.NavigateUrl = "~/Menu/profile.aspx?uname=" + m["uname"] + "";
            hyper.Controls.Add(rbg);
            boxed.Controls.Add(hyper);
        }
    }
}