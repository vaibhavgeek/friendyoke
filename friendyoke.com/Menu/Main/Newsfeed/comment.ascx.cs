using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace fy
{
    public partial class SampleControl1 : System.Web.UI.UserControl
    {


        public string what
        {
            get
            {
                
                return (string)ViewState["NID"];
            }
            set
            {

                ViewState["NID"] = value;

            }
        }

        Db dbClass = new Db();
        public DataTable dt;
        public DataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
         
        

           // Button1.Text = this.ProductID;
        }
        protected void Page_Init(object sender, EventArgs e)
        { 
  
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            string wtf = what;
            if (wtf.StartsWith("calbum"))
            {
                int detid = int.Parse(wtf.Substring(6));
                string getcomments = @"SELECT     [User].Name, [User].ID, AlbumComments.ID AS CID, AlbumComments.Comment, AlbumComments.AID, AlbumComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      AlbumComments ON [User].ID = AlbumComments.UID INNER JOIN
                      Propic ON AlbumComments.UID = Propic.UID
WHERE     (AlbumComments.AID = " + detid + @") AND (Propic.[Current] = 1)
ORDER BY CID";
                RadGrid2.DataSource = dbClass.ReturnDT(getcomments);




            }
            else if (wtf.StartsWith("cphoto"))
            {
                int detid = int.Parse(wtf.Substring(6));
                string getcomments = @"SELECT     [User].Name, [User].ID, PhotoComments.ID AS CID, PhotoComments.Comment, PhotoComments.PID, PhotoComments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      PhotoComments ON [User].ID = PhotoComments.UID INNER JOIN
                      Propic ON PhotoComments.UID = Propic.UID
WHERE     (Propic.[Current] = 1) AND (PhotoComments.PID = " + detid + @")
ORDER BY CID";
                RadGrid2.DataSource = dbClass.ReturnDT(getcomments);


            }
            else
            {
                int detid = int.Parse(wtf.Substring(8));
                string getcomments = @"SELECT     [User].Name, [User].ID, Comments.ID AS CID, Comments.Comment, Comments.ItemID, Comments.UID, Propic.Image, Propic.[Current]
FROM         [User] INNER JOIN
                      Comments ON [User].ID = Comments.UID INNER JOIN
                      Propic ON Comments.UID = Propic.UID
WHERE     (Comments.ItemID = " + detid + @") AND (Propic.[Current] = 1)
ORDER BY CID";
                RadGrid2.DataSource = dbClass.ReturnDT(getcomments);

            }
            //this.SqlDataSource1.SelectParameters["NID"].DefaultValue = this.NID;
            this.DataBind();
        }
        protected void RadGrid2_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
           
        }
        protected void RadGrid2_DataBound(object sender, EventArgs e)
        {

            //  ScriptManager.RegisterClientScriptInclude(Page, Page.GetType(), "galery", "lib/scroll/flexcroll.js");
            //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmpasd", togeth, false);
           // thecbox.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", "<script type='text/javascript'>fleXenv.fleXcrollMain('tobescrolled');</script>", false);


        }
        protected void postcomment_Click(object sender, EventArgs e)
        {
            if (RadTextBox1.Text == "")
            {
            }
            else
            {
                string wtf = what;
                int z = int.Parse(Session["UserID"].ToString());
                string conntenn = RadTextBox1.Text;
                conntenn = conntenn.Replace("\n", "<br/>");
                conntenn = conntenn.Replace("\r", "&nbsp;&nbsp;");
                if (wtf.StartsWith("calbum"))
                {
                    int detid = int.Parse(wtf.Substring(6));
                    string me = @"INSERT INTO AlbumComments (AID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                    dbClass.DataBase(me);
                    // return "album" + dRView["AlID"].ToString();

                }
                else if (wtf.StartsWith("cphoto"))
                {
                    int detid = int.Parse(wtf.Substring(6));
                    string me = @"INSERT INTO PhotoComments (PID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                    dbClass.DataBase(me);
                    // return "photo" + dRView["AlID"].ToString();
                }
                else
                {
                    int detid = int.Parse(wtf.Substring(8));
                    string me = @"INSERT INTO Comments (ItemID, UID, Comment)VALUES 
                    ('" + detid + "', " + z + ", '" + conntenn + "')";
                    dbClass.DataBase(me);
                    //  r
                }
               // bindit();
               // RadGrid1.DataBind();

               
                RadGrid2.DataSource = dt;
                RadGrid2.DataBind();
              //  thecbox.Visible = true;
                RadTextBox1.Text = "";
            }
        }
}
}