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
using System.Data;
using System.Data.SqlClient;

public partial class Profile_edit_editu_1 : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataSet ds;
    protected void Page_Init(object sender, EventArgs e)
    {



        int uid = int.Parse(Session["UserId"].ToString());
        ds = new DataSet();
        string urprofile = "SELECT * FROM [Propic] WHERE UID=" + uid + " AND [Current] = 1";
        ds = dbClass.ReturnDS(urprofile);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Image"].ToString() != "")
            {
                something.Visible = true;
                var image = ds.Tables[0].Rows[0]["Image"];
                Thumbnail.DataValue = (byte[])image;
                Thumbnail.Width = Unit.Pixel(550);
                Thumbnail.Height = Unit.Pixel(410);
            }
            else
            {
                something.Visible = false;
            }
        }
        else
        {

            something.Visible = false;
        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {


    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        int uid = int.Parse(Session["UserId"].ToString());
        something.Visible = true;
        string changetozero = "Update Propic set [Current] = 0 Where UID = "+uid+"";
        dbClass.DataBase(changetozero);
        SqlConnection connection = new
         SqlConnection(@"Data Source=V-PC\SQLEXPRESS;Initial Catalog=maindb1;Integrated Security=True");
        try
        {
            connection.Open();



            SqlCommand cmd = new SqlCommand("insert into Propic (Image , UID , [Current]) Values("
              + "@img ," + uid + ",1)", connection);
            cmd.Parameters.Add("@img", Thumbnail.DataValue);

            cmd.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }



    }
    protected void AsyncUpload1_FileUploaded(object sender, FileUploadedEventArgs e)
    {
        Thumbnail.Width = Unit.Pixel(550);
        Thumbnail.Height = Unit.Pixel(410);



        using (Stream stream = e.File.InputStream)
        {
            byte[] imageData = new byte[stream.Length];
            stream.Read(imageData, 0, (int)stream.Length);
            Thumbnail.DataValue = imageData;
        }


    }
    protected void RadButton1_Click(object sender, EventArgs e)
    {

    }

}