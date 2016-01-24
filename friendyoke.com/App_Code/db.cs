using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DataBaseClass
/// </summary>
public class Db
{
    SqlDataAdapter da;
    
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();

    public Db()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void DataBase(string Query)
    {
        using (SqlConnection con = new SqlConnection(@"Data Source=V-PC\SQLEXPRESS;Initial Catalog=maindb1;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = Query;
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    public DataSet ReturnDS(string Query)
    {
        ds = new DataSet();
        using (SqlConnection con = new SqlConnection(@"Data Source=V-PC\SQLEXPRESS;Initial Catalog=maindb1;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = Query;
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return ds;
            }
        }
    }
    public DataTable ReturnDT(string Query)
    {
        dt = new DataTable();
        using (SqlConnection con = new SqlConnection(@"Data Source=V-PC\SQLEXPRESS;Initial Catalog=maindb1;Integrated Security=True"))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = Query;
                cmd.Connection = con;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return dt;
            }
        }
    }
}
