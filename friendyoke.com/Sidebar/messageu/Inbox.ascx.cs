using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Messages_Inbox : System.Web.UI.UserControl
{
    Db loadm = new Db();
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Message.SelectCommand = @"SELECT     [User].Name, [User].ID, s.Message, s.ID AS MID, s.FriendID, s.ToID, s.ReplyID, s.Subject, Propic.Image
FROM         [User] INNER JOIN
                      Message AS s ON [User].ID = s.FriendID INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     (s.ToID = "+Session["UserId"]+@") AND (Propic.[Current] = 1)
ORDER BY MID DESC";

        
    }

   
    
    public void load(int x)
    {
        string select = @"SELECT        [User].Name, [User].ID, s.Message, s.ID AS MID, s.FriendID, s.ToID, s.ReplyID, s.Subject ,  Propic.Image
FROM            [User] INNER JOIN
                         Message AS s ON [User].ID = s.FriendID INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE        (s.ToID = " + Session["UserID"] + ") AND (s.ID = " + x + ") AND (Propic.[Current] = 1) ORDER BY MID DESC";
        dt = new DataTable();
        dt = loadm.ReturnDT(select);
        RepeaterCustomerInfo.DataSource = dt;
        RepeaterCustomerInfo.DataBind();
    }

    
    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
       string f = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["MID"].ToString();
       int z = int.Parse(f);
       load(z);
    }
}