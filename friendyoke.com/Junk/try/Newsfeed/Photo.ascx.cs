using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.SqlClient;
using System.Data;
public partial class Newsfeed_Photo : System.Web.UI.UserControl
{
    Db insertp = new Db();
    public DataSet ds;
    public DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void justadd_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {   
       
    }
    protected void post_Click(object sender, EventArgs e)
    {
        int uid = int.Parse(Session["UserId"].ToString());
        Random ran = new Random();
        int arbit = ran.Next();
        string getjuspostsql = @"SELECT     ID
FROM         Albums
WHERE     (Name = 'Just Post..') AND (UID = " + uid + ")";

        ds = new DataSet();
        ds = insertp.ReturnDS(getjuspostsql);

        int albummid = (int)ds.Tables[0].Rows[0]["ID"];

        using (Stream stream = justadd.UploadedFiles[0].InputStream)
        {
            
            byte[] imageData = new byte[stream.Length];
            stream.Read(imageData, 0, (int)stream.Length);
            SqlConnection connection = new
        SqlConnection(@"Data Source=V-PC\SQLEXPRESS;Initial Catalog=maindb1;Integrated Security=True");
            try
            {
               // INSERT INTO table_name
//VALUES (value1, value2, value3,...)
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into Photos (Photo , UID , AlbumID , Random) values  "
                  + "(@img," + uid + ", "+albummid+" , "+arbit+")", connection);
                cmd.Parameters.Add("@img", imageData);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

        }
        string selectarbit = "Select * From Photos WHERE Random = "+arbit+"";
        dt = new DataTable();
        dt = insertp.ReturnDT(selectarbit);
        int phid = int.Parse(dt.Rows[0]["ID"].ToString());
        string ins2nfeed = "insert into newsfeed (P,FromID) values ("+phid+","+Session["UserId"]+")";
        insertp.DataBase(ins2nfeed);
       
    }
    protected void createalbum_Click(object sender, EventArgs e)
    {
        RadWindow window1 = new RadWindow();
        window1.NavigateUrl = "../Photos/Add-Album.aspx";
        window1.Modal = true;
       
        window1.VisibleOnPageLoad = true;
        window1.Width = 500;
        window1.Height = 300;
        llooader.Controls.Add(window1); 
    }
    protected void addtoalbum_Click(object sender, EventArgs e)
    {
        RadWindow window1 = new RadWindow();
        window1.NavigateUrl = "../Photos/Add-Photo-Album.aspx";
        window1.Modal = true;

        window1.VisibleOnPageLoad = true;
        window1.Width = 500;
        window1.Height = 300;
        llooader.Controls.Add(window1); 
    }
}