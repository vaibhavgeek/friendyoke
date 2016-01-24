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
public partial class Photos_Add_Photo_Album : System.Web.UI.Page
{
    Db addphotoalbum = new Db();
    protected void Page_Load(object sender, EventArgs e)
    {
        string getalbums = "SELECT * FROM Albums WHERE UID = "+Session["UserId"]+" AND Name <> 'Just Post..'";
       DataTable dt = new DataTable();
        dt = addphotoalbum.ReturnDT(getalbums);
        DropDownList1.DataSource = dt;
        DropDownList1.DataBind();
    }
    protected void justadd_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
    {

    }
    protected void postfeed_Click(object sender, EventArgs e)
    {
        int aid = int.Parse(DropDownList1.SelectedValue);
        for (int x = 0; x < RadAsyncUpload1.UploadedFiles.Count; x++)
        {
            using (Stream stream = RadAsyncUpload1.UploadedFiles[x].InputStream)
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO Photos (Photo,UID,AlbumID) VALUES (@img," + Session["UserId"] + "," + aid + ")", connection);
                    cmd.Parameters.Add("@img", imageData);
                    cmd.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }
            }  
        }
        string getmainphoto = "SELECT TOP (1) ID FROM Photos WHERE AlbumID = " + aid + " ORDER BY ID DESC";
        DataSet ds = new DataSet();
        ds = addphotoalbum.ReturnDS(getmainphoto);
        int photoid = (int)ds.Tables[0].Rows[0]["ID"];
        string intonewsfeed = @"INSERT INTO newsfeed (FromID,Message,P,SendDate,SendTime,AlID) 
                                VALUES (" + Session["UserId"] + ",'Has Added <b>" + RadAsyncUpload1.UploadedFiles.Count.ToString() + "</b> Photo/s To Album <b>" + DropDownList1.SelectedItem.Text + "</b>'," + photoid + ",'" + System.DateTime.Now.Date.Day.ToString() + "/" + DateTime.Now.Date.Month.ToString() + "' , '" + System.DateTime.Now.ToShortTimeString() + "',"+aid+")";
        addphotoalbum.DataBase(intonewsfeed);
    }
}