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

public partial class Photos_Add_Album : System.Web.UI.Page
{
    Db newalbum = new Db();
    public DataTable dt;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void justadd_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {

    }
    protected void postfeed_Click(object sender, EventArgs e)
    {
        Random ran = new Random();
        int arbit = ran.Next();
        string inserintoalbums = @"INSERT INTO Albums (UID,Random,Name)
                                    VALUES(" + Session["UserId"] + "," + arbit + ",'" + TextBox1.Text + "')";

        newalbum.DataBase(inserintoalbums);
        string getalbumid = "SELECT ID FROM Albums WHERE Random = " + arbit + "";
        dt = new DataTable();
        dt = newalbum.ReturnDT(getalbumid);
        int albumid = (int)dt.Rows[0]["ID"];

        Random random2 = new Random();
        int namona = random2.Next();
        for (int q = 0; q < RadAsyncUpload1.UploadedFiles.Count; q++)
        {
            using (Stream stream = RadAsyncUpload1.UploadedFiles[q].InputStream)
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO Photos (Photo,UID,AlbumID,Random) VALUES (@img,"+Session["UserId"]+","+albumid+","+namona+")", connection);
                    cmd.Parameters.Add("@img", imageData);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

               
            }
        }
        string getp = "SELECT TOP (1) ID FROM Photos WHERE Random = "+namona+"";
        ds = new DataSet();
        ds = newalbum.ReturnDS(getp);
        int photoid = (int)ds.Tables[0].Rows[0]["ID"];
        string conntenn = maincontent.Text;
        conntenn = conntenn.Replace("\n", "<br/>");
        conntenn = conntenn.Replace("\r", "&nbsp;&nbsp;");
        string intonewsfeed = @"INSERT INTO newsfeed (FromID,Message,P,AlID,SendDate,SendTime) 
                                VALUES (" + Session["UserId"] + ",'" + conntenn + "'," + photoid + "," + albumid + ",'" + System.DateTime.Now.Date.Day.ToString() + "/" + DateTime.Now.Date.Month.ToString() + "' , '" + System.DateTime.Now.ToShortTimeString() + "')";
        newalbum.DataBase(intonewsfeed);


    }
}