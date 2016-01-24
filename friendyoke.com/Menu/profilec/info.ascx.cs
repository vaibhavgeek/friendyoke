using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Profile_profilec_Achievements : System.Web.UI.UserControl
{
    Db profile = new Db();
    DataTable dt = new DataTable();
    protected void Page_Init(object sender, EventArgs e)
    {
        string uname = Request.QueryString["uname"].ToString();
        string getall = @"select [ID] from [User] where [uname] = '" + uname + "'";
        dt = new DataTable();
        dt = profile.ReturnDT(getall);
        string vid = dt.Rows[0]["ID"].ToString();

        string getdetails = @"SELECT     [User].workmore, [User].Degree, [User].Designation, [User].College, [User].School, [User].Company, [User].City, [User].Country, Contact.Website, Contact.Phone, 
                      Contact.Email, Contact.Address, Ement.Movies, Ement.Books, Ement.Music, Ement.Television, Ement.Sports, Political.Life, Political.Political, Political.Religion, 
                      Taste.Food
FROM         [User] INNER JOIN
                      Contact ON [User].ID = Contact.UID INNER JOIN
                      Ement ON [User].ID = Ement.UID INNER JOIN
                      Political ON [User].ID = Political.UID INNER JOIN
                      Taste ON [User].ID = Taste.UID
WHERE     ([User].ID = " + vid + ")";

        dt = profile.ReturnDT(getdetails);




        
            if (dt.Rows[0]["College"] is DBNull == false)
            {
                Label lbl = new Label();
                Label lbl2 = new Label();
                lbl.Text = "college :";
                lbl2.Text = " " + dt.Rows[0]["Degree"].ToString() + " @ " + dt.Rows[0]["College"].ToString();

                edu.Controls.Add(lbl);
                edu.Controls.Add(lbl2);
            }
            if (dt.Rows[0]["School"] is DBNull == false)
            {
                Label lbl = new Label();
                Label lbl2 = new Label();
                lbl.Text = "<br>" + "school &nbsp;:";
                lbl2.Text = " " + dt.Rows[0]["School"].ToString();

                edu.Controls.Add(lbl);
                edu.Controls.Add(lbl2);
            }
        
        if (dt.Rows[0]["Company"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "company  &nbsp; &nbsp; &nbsp; :";
            lbl2.Text = " is "+dt.Rows[0]["Designation"] + " @ " + dt.Rows[0]["Company"].ToString();

            work.Controls.Add(lbl);
            work.Controls.Add(lbl2);
        }
        else
        {
            Label lbl = new Label();
            lbl.Text = "is currently studying";
            work.Controls.Add(lbl);
           
        }
        if (dt.Rows[0]["workmore"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> has worked at:";
            lbl2.Text = " " + dt.Rows[0]["workmore"].ToString();

            work.Controls.Add(lbl);
            work.Controls.Add(lbl2);
        }
     

       
        if (dt.Rows[0]["Phone"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "phone  &nbsp;&nbsp;&nbsp; :";
            lbl2.Text = " " + dt.Rows[0]["Phone"].ToString();

            contact.Controls.Add(lbl);
            contact.Controls.Add(lbl2);
        }
        if (dt.Rows[0]["Address"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br>" + "address &nbsp; :";
            lbl2.Text = " " + dt.Rows[0]["Address"].ToString() + " , " + dt.Rows[0]["City"].ToString() + " , " + dt.Rows[0]["Country"].ToString();

            contact.Controls.Add(lbl);
            contact.Controls.Add(lbl2);
        }
        if (dt.Rows[0]["Website"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "website&nbsp;&nbsp;:";
            lbl2.Text = " <a target='_blank' href='" + dt.Rows[0]["Website"] + "'>" + dt.Rows[0]["Website"] + "</a>";

            know.Controls.Add(lbl);
            know.Controls.Add(lbl2);
        }

        if (dt.Rows[0]["Email"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> email  &nbsp;&nbsp;&nbsp;&nbsp;:";
            lbl2.Text = " " + dt.Rows[0]["Email"].ToString();

            know.Controls.Add(lbl);
            know.Controls.Add(lbl2);
        }

        if (dt.Rows[0]["Movies"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "movies &nbsp;&nbsp;&nbsp;:";
            lbl2.Text = " " + dt.Rows[0]["Movies"].ToString();


            ement.Controls.Add(lbl);
            ement.Controls.Add(lbl2);
        }
        if (dt.Rows[0]["Music"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> music  &nbsp; &nbsp;&nbsp;&nbsp;:";
            lbl2.Text = " " + dt.Rows[0]["Music"].ToString();


            ement.Controls.Add(lbl);
            ement.Controls.Add(lbl2);
        }
        if (dt.Rows[0]["Television"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> television :";
            lbl2.Text = " " + dt.Rows[0]["Television"].ToString();


            ement.Controls.Add(lbl);
            ement.Controls.Add(lbl2);
        }

        if (dt.Rows[0]["Books"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "books :";
            lbl2.Text = " " + dt.Rows[0]["Books"].ToString();

            intrests.Controls.Add(lbl);
            intrests.Controls.Add(lbl2);
        }
        if (dt.Rows[0]["Sports"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> sports :";
            lbl2.Text = " " + dt.Rows[0]["Sports"].ToString();

            intrests.Controls.Add(lbl);
            intrests.Controls.Add(lbl2);
        }


        if (dt.Rows[0]["Life"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "on life &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;:";
            lbl2.Text = " " + dt.Rows[0]["Life"].ToString();

            philosophy.Controls.Add(lbl);
            philosophy.Controls.Add(lbl2);
        }
        if (dt.Rows[0]["Political"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> on politics :";
            lbl2.Text = " " + dt.Rows[0]["Political"].ToString();

            philosophy.Controls.Add(lbl);
            philosophy.Controls.Add(lbl2);
        }

        if (dt.Rows[0]["Religion"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "religion :";
            lbl2.Text = " " + dt.Rows[0]["Religion"].ToString();

            about.Controls.Add(lbl);
            about.Controls.Add(lbl2);
        }
        if (dt.Rows[0]["Food"] is DBNull == false)
        {
            Label lbl = new Label();
            Label lbl2 = new Label();
            lbl.Text = "<br> food &nbsp;&nbsp;&nbsp;&nbsp;:";
            lbl2.Text = " " + dt.Rows[0]["Food"].ToString();

            about.Controls.Add(lbl);
            about.Controls.Add(lbl2);
        }


        if (dt.Rows[0]["College"] is DBNull && dt.Rows[0]["School"] is DBNull)
        {
           
            eedu.Visible = false;
        
        }
        if (dt.Rows[0]["Company"] is DBNull && dt.Rows[0]["workmore"] is DBNull)
        {
            
            wwork.Visible = false;

        }
        if (dt.Rows[0]["Phone"] is DBNull && dt.Rows[0]["Address"] is DBNull)
        {
            
            ccontact.Visible = false;

        }
        if (dt.Rows[0]["Website"] is DBNull && dt.Rows[0]["Email"] is DBNull)
        {
            
            kknow.Visible = false;

        }
        if (dt.Rows[0]["Books"] is DBNull && dt.Rows[0]["Sports"] is DBNull)
        {

            iint.Visible = false;

        }
        if (dt.Rows[0]["Movies"] is DBNull && dt.Rows[0]["Music"] is DBNull && dt.Rows[0]["Television"] is DBNull)
        {

            eement.Visible = false;

        }
        if (dt.Rows[0]["Life"] is DBNull && dt.Rows[0]["Political"] is DBNull)
        {

            pilo.Visible = false;

        }
        if (dt.Rows[0]["Religion"] is DBNull && dt.Rows[0]["Food"] is DBNull)
        {
           
            abat.Visible = false;

        }


       
    }
}