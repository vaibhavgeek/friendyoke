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
    protected void Page_Load(object sender, EventArgs e)
    {

        
    }
    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        string unaid = Request.QueryString["uname"].ToString();
        string getuserid = "select [ID] from [User] where [uname] = '"+unaid+"'";
        
        DataTable z = new DataTable();
        z = profile.ReturnDT(getuserid);

        string id = z.Rows[0]["ID"].ToString();

        string friendlistsql = @"SELECT     Name, City , ID
FROM         [User]
WHERE     (ID IN
                          (SELECT     MyID AS ID
                            FROM          Friends
                            WHERE      (FriendID = " + id + @") AND (FriendStatus = 1) AND (FriendID <> MyID))) OR
                      (ID IN
                          (SELECT     FriendID AS ID
                            FROM          Friends AS Friends_1
                            WHERE      (MyID = " + id + @") AND (FriendStatus = 1) AND (FriendID <> MyID)))
ORDER BY Name";
        DataTable dt = new DataTable();
        dt = profile.ReturnDT(friendlistsql);
        if (dt.Rows.Count > 0)
        {
            RadGrid1.DataSource = dt;
        }
        else
        {
            RadGrid1.Visible = false;

            lblError.Text = "this person has no connections as of now";
            lblError.ForeColor = System.Drawing.Color.Green;

        }
    }
    protected void XmlHttpPanel_ServiceRequest(object sender, RadXmlHttpPanelEventArgs e)
    {
        Session["LoadingUserValue"] = e.Value;
        string val = e.Value;
        string myid = Session["UserId"].ToString();

        string getstatus = @"SELECT     MyID, FriendID, FriendStatus
FROM         Friends
WHERE     (MyID = " + myid + @") AND (FriendID = " + val + @") OR
                      (MyID = " + val + @") AND (FriendID = " + myid + @")";
        DataTable dt2 = new DataTable();
        dt2 = profile.ReturnDT(getstatus);

        DataTable dt3 = new DataTable();
        string getboxstat = @"SELECT     MyID, SID, FollowDate, FollowStatus
FROM         Box
WHERE     (MyID = " + myid + ") AND (SID = " + val + ")";
        dt3 = profile.ReturnDT(getboxstat);


         if (dt2.Rows.Count > 0)
        {
            int n = (int)dt2.Rows[0]["FriendStatus"];
            string ida = dt2.Rows[0]["MyID"].ToString();
            string idb = dt2.Rows[0]["FriendID"].ToString();
            switch (n)
            {
                case 0:
                    if (ida == Session["UserId"].ToString())
                    {
                        addasfrnd.Visible = true;
                        addasfrnd.Text = "cancel connect request";
                        Session["friend"] = "ccr";
                        
                        // i sent the request , i can cancel it
                      
                        if (dt3.Rows.Count > 0)
                        {
                            addbox.Visible = true;
                            addbox.Text = "remove from box";
                            Session["box"] = "rfb";
                            //added to box .. remove from box 
                        }
                       
                    }
                    else
                    {
                        addasfrnd.Visible = true;
                        addasfrnd.Text = "accept connect request";
                        Session["friend"] = "acr";
                        // i have the request i can accecpt it
                        if (dt3.Rows.Count > 0)
                        {
                            addbox.Visible = true;
                            addbox.Text = "remove from box";
                            Session["box"] = "rfb";
                            //added to box .. remove from box 
                        }
                        
                    }
                    break;
                case 1:
                    // he is a friend


                    addasfrnd.Visible = true;
                    addasfrnd.Text = "in your connections";
                    addbox.Visible = false;
                    if (dt3.Rows.Count > 0)
                    {
                        addbox.Visible = true;
                        addbox.Text = "remove from box";
                        Session["box"] = "rfb";
                        //added to box .. remove from box 
                    }
                    break;


            }
         
           
            
        }
        else
        {
            if (dt3.Rows.Count > 0)
            {
                addbox.Visible = true;
                addbox.Text = "remove from box";
                Session["box"] = "rfb";
                //added to box .. remove from box 
            }
            addasfrnd.Visible = true;
            addasfrnd.Text = "ask to connect";
            Session["friend"] = "atc";
        // he is random
           
           
        }



         string getfrndet = @"SELECT     [User].ID, [User].[uname], [User].Name, [User].Country, [User].Relationship, [User].BirthDate, [User].Gender, [User].City, Propic.Image, [User].College, [User].School, [User].Company, 
                      [User].[looking for]
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     ([User].ID = " + val + ") AND (Propic.[Current] = 1)";
        DataTable table = new DataTable();
        table = profile.ReturnDT(getfrndet);
        Name.Text = table.Rows[0]["Name"].ToString();
        uname.Text = "<a href='profile.aspx?uname="+table.Rows[0]["uname"].ToString()+"'> @ "+ table.Rows[0]["uname"].ToString() + "</a>";
        if (table.Rows[0]["Image"] is DBNull == false)
        {
            RadBinaryImage rbg = new RadBinaryImage();
            rbg.ResizeMode = BinaryImageResizeMode.Crop;
            rbg.Height = 230;
            rbg.Width = 177;
            rbg.DataValue = (byte[])table.Rows[0]["Image"];
            rbg.CssClass = "sidemeyaaar";
            propic.Controls.Add(rbg);
        }
        if (table.Rows[0]["College"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "college :";
            lbl2.Text = table.Rows[0]["College"].ToString();

            addcontrols.Controls.Add(lbl);
            addcontrols.Controls.Add(lbl2);
        }
        if (table.Rows[0]["School"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> school :";
            lbl2.Text = table.Rows[0]["School"].ToString();

            addcontrols.Controls.Add(lbl);
            addcontrols.Controls.Add(lbl2);
        }
        if (table.Rows[0]["Company"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> works at :";
            lbl2.Text = table.Rows[0]["Company"].ToString();

            addcontrols.Controls.Add(lbl);
            addcontrols.Controls.Add(lbl2);
        }
        if (table.Rows[0]["BirthDate"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> born on :";
            lbl2.Text = table.Rows[0]["BirthDate"].ToString();

            addcontrols.Controls.Add(lbl);
            addcontrols.Controls.Add(lbl2);
        }
        if (table.Rows[0]["Gender"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> gender :";
            lbl2.Text = table.Rows[0]["Gender"].ToString();

            addcontrols.Controls.Add(lbl);
            addcontrols.Controls.Add(lbl2);
        }
        if (table.Rows[0]["Country"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br>" + "lives in &nbsp; :";
            lbl2.Text = table.Rows[0]["City"].ToString() +  table.Rows[0]["Country"].ToString();

            addcontrols.Controls.Add(lbl);
            addcontrols.Controls.Add(lbl2);
        }
        if (table.Rows[0]["Relationship"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br>" + "relationship :";
            lbl2.Text = table.Rows[0]["Relationship"].ToString();

            addcontrols.Controls.Add(lbl);
            addcontrols.Controls.Add(lbl2);
        }
        if (table.Rows[0]["looking for"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br>" + "looking for :";
            lbl2.Text = table.Rows[0]["looking for"].ToString();

            addcontrols.Controls.Add(lbl);
            addcontrols.Controls.Add(lbl2);
        }


    }
    

    public void addtobox(int SID )
    {
        string date = System.DateTime.Now.Date.ToString();
        string addtobox = "INSERT INTO Box (MyID, SID, FollowDate, FollowStatus) VALUES (" + Session["UserId"] + "," + SID + "," + "'" + date + "'" + ", 1)";
        profile.DataBase(addtobox);
        
    }
   
    protected void addasfrnd_Click(object sender, EventArgs e)
    {
        if (Session["friend"].ToString() == "ccr")
        {
            string ccr = @"DELETE FROM Friends
WHERE     (MyID = "+Session["UserID"]+") AND (FriendID = 113) AND (FriendStatus = 0)";
            profile.DataBase(ccr);
        //cancel connect request
        }
        if (Session["friend"].ToString() == "atc")
        {
            string atc =@"INSERT INTO Friends
                      (MyID, FriendID, FriendStatus)
VALUES     ("+Session["UserID"]+", "+RadXmlHttpPanel1.Value+", 0)";
            profile.DataBase(atc);
            //ask to connect 
        }
        if (Session["friend"].ToString() == "acr")
        {
            string acr = @"UPDATE    Friends
SET              FriendStatus = 1
WHERE     (FriendID = "+Session["UserId"]+") AND (FriendStatus = 0) AND (MyID = "+RadXmlHttpPanel1.Value+")";
            profile.DataBase(acr);
            //accept connect request
        }
    }
    protected void addbox_Click(object sender, EventArgs e)
    {
      
        if ( Session["box"].ToString() == "rfb")
        {
            string delbox = @"DELETE FROM Box
WHERE     (MyID = " + Session["UserId"] + ") AND (SID = " + Session["LoadingUserValue"].ToString() + ")";
            profile.DataBase(delbox);
        }
        else 
        {
            addtobox(int.Parse(Session["LoadingUserValue"].ToString()));
        }
    }
}