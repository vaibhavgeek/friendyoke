using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Friends_ucontrols_csearch : System.Web.UI.UserControl
{
    Db dbClass = new Db();
    public DataTable dt;
    protected void Page_Init(object sender, EventArgs e)
    {
            error0.Visible = false;
            SearchResultList.Visible = false;
            error.Visible = false;
        
    }
   
    public string getHREF(object sURL)
    {
        DataRowView dRView = (DataRowView)sURL;
        string Id = dRView["Id"].ToString();
        return ResolveUrl("~/Profile/profile.aspx?Id=" + Id);
    }

    public byte[] getSRC(object imgSRC)
    {
        DataRowView dRView = (DataRowView)imgSRC;
        byte[] ImageName = (byte[])dRView["Image"];
        if (dRView["Image"] is DBNull)
        {
            return ImageName;
        }
        else
        {
            return ImageName;
        }
    }
    public string name(object Name)
    {
        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Name"].ToString();
        return some;

    }
    public string company(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Company"].ToString();
        return some;

    }

    public string School(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["School"].ToString();
        return some;

    }
    public string gender(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Gender"].ToString();
        return some;

    }
    public string Age(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["BirthDate"].ToString();
        string parsed = some.Substring(5);
        return parsed;

    }
    public string country(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Country"].ToString();
        return some;

    }
    public string about(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["City"].ToString();
        return some;

    }
    public string reletion(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Relationship"].ToString();
        return some;

    }
    public string Id(object Name)
    {

        DataRowView dRView = (DataRowView)Name;
        string some = dRView["Id"].ToString();
        return some;

    }
    protected void RadGrid1_NeedDataSource(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {

    }
    protected void SearchResultList_ItemEvent(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (RadTextBox1.Text == "")
        {
            error.Visible = true;
            SearchResultList.Visible = false;
            error0.Visible = false;

        }

        else
        {
            error.Visible = false;

            LoadData();
        }

    }




    public void LoadData()
    {

        if (RadTextBox1.Text != "")
        {
            string name = RadTextBox1.Text;
            string GetSearchResult = @"SELECT     [User].Name, [User].Country, [User].RegisterDate, [User].College, [User].Relationship, [User].BirthDate, [User].School, [User].Company, [User].Gender, [User].City, 
                      [User].ID, [User].uname, [User].Phone, [User].Degree, [User].Designation, Propic.Image
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     ([User].Name LIKE '"+ name + "%') AND (Propic.[Current] = 1)";
            dt = dbClass.ReturnDT(GetSearchResult);
            if (dt.Rows.Count > 0)
            {
                SearchResultList.DataSource = dt;
                SearchResultList.DataBind();
                SearchResultList.Visible = true;
                error0.Visible = false;


            }
            else if (dt.Rows.Count == 0)
            {
                SearchResultList.Visible = false;
                error0.Visible = true;

            }

        }
        if (RadTextBox2.Text != "")
        {
            string name = RadTextBox1.Text;
            string GetSearchResult = @"SELECT     [User].Name, [User].Country, [User].RegisterDate, [User].College, [User].Relationship, [User].BirthDate, [User].School, [User].Company, [User].Gender, [User].City, 
                      [User].ID, [User].uname, [User].Phone, [User].Degree, [User].Designation, Propic.Image
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     ([User].Name LIKE '"+ name + "') AND (Propic.[Current] = 1) AND Country like '" + RadTextBox2.Text + "'";
            dt = dbClass.ReturnDT(GetSearchResult);
            if (dt.Rows.Count > 0)
            {
                SearchResultList.DataSource = dt;
                SearchResultList.DataBind();
                SearchResultList.Visible = true;
                error0.Visible = false;

            }
            else if (dt.Rows.Count == 0)
            {
                error0.Visible = true;

            }

        }
        if (RadTextBox3.Text != "")
        {
            string name = RadTextBox1.Text;
            string GetSearchResult = @"SELECT     [User].Name, [User].Country, [User].RegisterDate, [User].College, [User].Relationship, [User].BirthDate, [User].School, [User].Company, [User].Gender, [User].City, 
                      [User].ID, [User].uname, [User].Phone, [User].Degree, [User].Designation, Propic.Image
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     ([User].Name LIKE '"+ name + "') AND (Propic.[Current] = 1) AND Country like '" + RadTextBox2.Text + "%' AND Company like'" + RadTextBox3.Text + "%'";
            dt = dbClass.ReturnDT(GetSearchResult);
            if (dt.Rows.Count > 0)
            {
                SearchResultList.DataSource = dt;
                SearchResultList.DataBind();
                SearchResultList.Visible = true;



            }
            else if (dt.Rows.Count == 0)
            {
                error0.Visible = true;

            }

        }
        if (RadTextBox4.Text != "")
        {
            string name = RadTextBox1.Text;
            string GetSearchResult = @"SELECT     [User].Name, [User].Country, [User].RegisterDate, [User].College, [User].Relationship, [User].BirthDate, [User].School, [User].Company, [User].Gender, [User].City, 
                      [User].ID, [User].uname, [User].Phone, [User].Degree, [User].Designation, Propic.Image
FROM         [User] INNER JOIN
                      Propic ON [User].ID = Propic.UID
WHERE     ([User].Name LIKE '" + name + "') AND (Propic.[Current] = 1) AND Country like '" + RadTextBox2.Text + "%' AND Company like '" + RadTextBox3.Text + "%' AND School like '" + RadTextBox4.Text + "%'";
            dt = dbClass.ReturnDT(GetSearchResult);
            if (dt.Rows.Count > 0)
            {
                SearchResultList.DataSource = dt;
                SearchResultList.DataBind();
                SearchResultList.Visible = true;
                error0.Visible = false;

            }
            else if (dt.Rows.Count == 0)
            {
                error0.Visible = true;

            }
        }

        if (SearchResultList.Visible == true)
        {
            error0.Visible = false;
            error.Visible = false;
        }
    }

    protected void SearchResultList_PageIndexChanged(object source, Telerik.Web.UI.GridPageChangedEventArgs e)
    {
        LoadData();
    }
    protected void SearchResultList_PageSizeChanged(object source, Telerik.Web.UI.GridPageSizeChangedEventArgs e)
    {
        LoadData();
    }

  
}