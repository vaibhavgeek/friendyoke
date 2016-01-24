using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;

public partial class Messages_Compose : System.Web.UI.UserControl
{
    Db vaibhav = new Db();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string friends = @"SELECT     [User].Name, [User].ID, Propic.Image
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     ([User].ID IN
                          (SELECT     MyID AS ID
                            FROM          Friends
                            WHERE      (FriendID ="+Session["UserID"]+@") AND (FriendStatus = 1) AND (FriendID <> MyID))) AND (Propic.[Current] = 1) OR
                      ([User].ID IN
                          (SELECT     FriendID AS ID
                            FROM          Friends AS Friends_1
                            WHERE      (MyID = " + Session["UserID"] + @") AND (FriendStatus = 1) AND (FriendID <> MyID))) AND (Propic.[Current] = 1)
ORDER BY [User].Name";
        SqlDataSource2.SelectCommand = friends;
    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {
     
        
        string f = Search_People2.SelectedValue;
        
        int g = int.Parse(f);
        string send = "INSERT INTO Message   (ToID, FriendID, Message,Subject) VALUES  (" + g + "," + Session["UserId"] + ",'" + MailBodyEditor.Content + "','" + SubjectTextBox.Text + "')";
        vaibhav.DataBase(send);
        
        Panel1.Visible = true;





    }
}
       

        
    
