using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Caching;
using Telerik.Web.UI;

public partial class Register_Basic : System.Web.UI.UserControl
{
    Db registeruser = new Db();
    public DataTable dt;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void nextButton_Click(object sender, EventArgs e)
    {
        RadTextBox email = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("email");
        RadTextBox Uname = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("unamet");
        dt = new DataTable();
        string emailthere = "SELECT * FROM [User] Where Email ='" + email.Text + "' OR uname = '" + Uname.Text + "'";
        dt = registeruser.ReturnDT(emailthere);
        RadTextBox password = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("password");
        RadTextBox cpassword = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("cpassword");
        Label errorr12 = (Label)RadPanelBar1.FindItemByValue("Step1").FindControl("e2");

        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["Email"] == email.Text)
            {

                errorr12.Visible = true;
                errorr12.Text = "Please Enter another Email , This email already exists ";
            }
            else
            {

                errorr12.Visible = true;
                errorr12.Text = "Please Enter another User Name , This Username already exists ";
            }
        }
        else if (password.Text != cpassword.Text)
        {
            errorr12.Text = "Passwords Do Not Match";
        }
        else
        {

            chita.Visible = false;
            chita.Text = password.Text;
            int selectedIndex = RadPanelBar1.SelectedItem.Index;
            RadPanelBar1.Items[selectedIndex].Expanded = false;
            RadPanelBar1.Items[selectedIndex].Enabled = false;
            RadPanelBar1.Items[selectedIndex].Selected = false;
            RadPanelBar1.Items[selectedIndex + 1].Selected = true;
            RadPanelBar1.Items[selectedIndex + 1].Expanded = true;
            RadPanelBar1.Items[selectedIndex + 1].Enabled = true;

        }
    }
    protected void nextButton2_Click(object sender, EventArgs e)
    {



    }
}