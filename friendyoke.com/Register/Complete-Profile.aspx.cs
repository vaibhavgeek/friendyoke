using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
public partial class Register_Complete_Profile : System.Web.UI.Page
{
    Db regsiter1 = new Db();
    public DataTable dt;
    protected void Page_Init(object sender, EventArgs e)
    {
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {


            int uid = int.Parse(Session["UserID"].ToString());

            string getall = "select * from Achieve where UID = " + uid;
            dt = new DataTable();
            dt = regsiter1.ReturnDT(getall);
            if (dt.Rows.Count > 0)
            {

               
            }
            else {
                string achievementsql = @"INSERT INTO Achieve
                      (UID)
VALUES     (" + uid + ")";

                string contactsql = @"INSERT INTO Contact
                      (UID)
VALUES     (" + uid + ")";
                string ementsql = @"INSERT INTO Ement
                      (UID)
VALUES     (" + uid + ")";
                string networkssql = @"INSERT INTO Networks
                      (UID)
VALUES     (" + uid + ")";
                string politicalsql = @"INSERT INTO Political
                      (UID)
VALUES     (" + uid + ")";
                string tastesql = @"INSERT INTO Taste
                      (UID)
VALUES     (" + uid + ")";
                string propicsql = @"INSERT INTO Propic
                      (UID , [Current])
VALUES     (" + uid + " , 1 )";
                string mimagesql = @"INSERT INTO Mimage
                      (UID)
VALUES     (" + uid + ")";
                string myfrindmesql = @"INSERT INTO Friends
                      (MyID, FriendID, FriendStatus, FriendShipDate)
VALUES     (" + uid + "," + uid + ",1,'" + DateTime.Now.Date.ToString() + "')";


                regsiter1.DataBase(achievementsql);
                regsiter1.DataBase(contactsql);
                regsiter1.DataBase(ementsql);
                regsiter1.DataBase(networkssql);
                regsiter1.DataBase(politicalsql);
                regsiter1.DataBase(tastesql);
                regsiter1.DataBase(propicsql);
                regsiter1.DataBase(mimagesql);
                regsiter1.DataBase(myfrindmesql);

            }
        }
    }
    protected void RadPanelBar1_ItemClick(object sender, Telerik.Web.UI.RadPanelBarEventArgs e)
    {

        RadPageView pager = new RadPageView();
        pager.ID = e.Item.Value.ToString();
        pager.Selected = true;
        RadMultiPage1.PageViews.Add(pager);
    }
    protected void RadMultiPage1_PageViewCreated(object sender, Telerik.Web.UI.RadMultiPageEventArgs e)
    {
        Control userControl = Page.LoadControl("complete/" + e.PageView.ID.ToString() + ".ascx");
        userControl.ID = e.PageView.ID.ToString() + "usercontrol";
        e.PageView.Selected = true;
        e.PageView.Controls.Add(userControl);
    }
   
}