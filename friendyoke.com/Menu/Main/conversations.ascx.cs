using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using AjaxControlToolkit.Design;
using AjaxControlToolkit;
public partial class Space_message : System.Web.UI.UserControl
{
    public string who;
    Db db = new Db();
    public DataTable dt;
    protected void Page_Init(object sender, EventArgs e)
    {
        ptb.Visible = false;
        send.Visible = false;

       


    }
    protected void Page_Load(object sender, EventArgs e)
    {


    }



    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        string getco = @"SELECT     ID, a, b, ReadStatus
FROM         Conversation
WHERE     (a = "+Session["UserId"]+@") OR
                      (b = " + Session["UserId"] + @")";
        dt = new DataTable();
        dt = db.ReturnDT(getco);
        RadGrid1.DataSource = dt;

    }
    public string name(object hi)
    {
        DataRowView dRView = (DataRowView)hi;
        int disuid;
        if (dRView["a"].ToString() == Session["UserId"].ToString())
        {
            disuid = (int)(dRView["b"]);
        }
        else
        {
            disuid = (int)(dRView["a"]);
        }
        string getname = @"SELECT     Name
FROM         [User]
WHERE     (ID = "+ disuid +")";
        dt = new DataTable();
        dt = db.ReturnDT(getname);
        return dt.Rows[0]["Name"].ToString();
    }
   public byte[] aphoto(object hi)
    {
        DataRowView dRView = (DataRowView)hi;
        int disuid;
        if (dRView["a"].ToString() == Session["UserId"].ToString())
        {
            disuid = (int)(dRView["b"]);
        }
        else
        {
            disuid = (int)(dRView["a"]);
        }
        string getname = @"SELECT     Image
FROM         [Propic]
WHERE     (UID = " + disuid + ") AND ([Current] = 1) ";
        dt = new DataTable();
        dt = db.ReturnDT(getname);
        return (byte[])dt.Rows[0]["Image"];
    }
    public string message(object hi)
    {
        DataRowView dRView = (DataRowView)hi;
        string rstat = dRView["ReadStatus"].ToString();
        string me;
        if (dRView["a"].ToString() == Session["UserId"].ToString())
        {
            me = "a";
            
        }
        else
        {
            me = "b";
        }
        who = me;
        if (rstat.StartsWith("a") && me == "a" )
        { rstat =  rstat.Substring(1);
        return rstat + " unread messages";
        }
        else if (rstat.StartsWith("b") && me == "b")
        {
            rstat = rstat.Substring(1);
            return rstat + " unread messages";
        }
        else
        {
            return "no unread messages";
        }
         }
    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
            Label hd = (Label)e.Item.FindControl("hid");
           string cid = hd.Text;
          
           loadcomments(cid);
        
        
    }
   
   
    public void loadcomments(string mainid)
    {
        string getallmessages = @"SELECT     Propic.Image, Message.Message, Message.UID
FROM         Message INNER JOIN
                      Propic ON Message.UID = Propic.UID
WHERE     (Propic.[Current] = 1) AND (Message.CID = " + mainid + @")
ORDER BY Message.ID ASC";
        ccid.Text = mainid;
        dt = new DataTable();
        dt = db.ReturnDT(getallmessages);
        for (int x = 0; x < dt.Rows.Count; x++)
        {
            Panel panel = new Panel();
            RoundedCornersExtender rnd = new RoundedCornersExtender();


            panel.ID = x.ToString();
            rnd.TargetControlID = x.ToString();
            rnd.Radius = 5;
            panel.BackColor = System.Drawing.Color.FromArgb(239, 239, 241);

            RadBinaryImage rbg = new RadBinaryImage();
            rbg.Height = 35;
            rbg.Width = 35;
            rbg.DataValue = (byte[])dt.Rows[x]["Image"];
            rbg.ResizeMode = BinaryImageResizeMode.Crop;
            rbg.CssClass = "sidemeyaaar";
            panel.Controls.Add(rbg);

            Label lbl = new Label();
            lbl.CssClass = "sidemeyaaarright";
            lbl.Text = dt.Rows[x]["Message"].ToString();
            panel.Controls.Add(lbl);



            messageloader.Controls.Add(rnd);


            messageloader.Controls.Add(panel);

        }
        ptb.Visible = true;
        send.Visible = true;
    }
    protected void send_Click(object sender, EventArgs e)
    {
        if (ptb.Text != "")
        {
            string insertmessage = @"INSERT INTO Message
                      (UID, CID, Message,Who)
VALUES     (" + Session["UserId"] + "," + ccid.Text + ",N'" + ptb.Text + "','" + who + "')";

            db.DataBase(insertmessage);
         loadcomments(ccid.Text);
         ptb.Text = "";

         ptb.Visible = true;
         send.Visible = true;
        }
    }
    
    
}