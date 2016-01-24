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

public partial class Register_Basic : System.Web.UI.Page
{
    Db registeruser = new Db();
    public DataTable dt;
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        RadTextBox email = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("email");
        RadTextBox Uname = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("unamet");
        Button nextbutton = (Button)RadPanelBar1.FindItemByValue("Step1").FindControl("nextButton");
        dt = new DataTable();
        string emailthere = "SELECT * FROM [User] Where Email ='" + email.Text + "' OR uname = '" + Uname.Text + "'";
        dt = registeruser.ReturnDT(emailthere);
        if (dt.Rows.Count > 0)
        {
            nextbutton.Text = "Some error ocurred!";
            ViewState["Error"]= "error";
        }
    }
    protected void nextButton_Click(object sender, EventArgs e)
    {
        if (ViewState["Error"] != "error")
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
    }
    protected void nextButton2_Click(object sender, EventArgs e)
    {
        RadTextBox fName = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("fName");
        RadTextBox lName = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("lName");
        RadTextBox email = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("email");
        RadTextBox password = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("password");
        RadTextBox Uname = (RadTextBox)RadPanelBar1.FindItemByValue("Step1").FindControl("unamet");

        //Getting Step 2 content
        RadComboBox bday = (RadComboBox)RadPanelBar1.FindItemByValue("Step2").FindControl("bday");
        RadComboBox bmonth = (RadComboBox)RadPanelBar1.FindItemByValue("Step2").FindControl("drpBirthMonth");
        RadComboBox byear = (RadComboBox)RadPanelBar1.FindItemByValue("Step2").FindControl("drpBirthYear");
        RadComboBox gender = (RadComboBox)RadPanelBar1.FindItemByValue("Step2").FindControl("gen");
        RadComboBox country = (RadComboBox)RadPanelBar1.FindItemByValue("Step2").FindControl("Country");

        string bdayy = bday.SelectedItem.Text + bmonth.SelectedItem.Text + byear.SelectedItem.Text;
        string noww = DateTime.Now.Date.ToString();

        string regsteru = @"INSERT INTO [User]
                      (Name, uname, Email, Password, Country, BirthDate, Gender, RegisterDate)
VALUES     ('"+fName.Text+" "+lName.Text+"','"+Uname.Text+"','"+email.Text+"','"+chita.Text+"','"+country.SelectedItem.Text+"','"+bdayy+"','"+gender.SelectedItem.Text+"','"+noww+"')";
            registeruser.DataBase(regsteru);

        //Check User Id of the person..
            string checkid = "SELECT * FROM [User] WHERE Email ='" + email.Text + "'";
            ds = new DataSet();
            ds = registeruser.ReturnDS(checkid);
            var userid = ds.Tables[0].Rows[0]["Id"].ToString();
            Session["UserId"] = userid;

        //add justt photos album...
            string addjustpost = @"INSERT INTO Albums
                      (Name, UID)
VALUES     ('Just Post...',"+userid+")";
            registeruser.DataBase(addjustpost);

        //add event photographs album ...
            string addeventphotos = @"INSERT INTO Albums
                      (Name, UID)
VALUES     ('Event Photos'," + userid + ")";
            registeruser.DataBase(addeventphotos);
            Server.Transfer("Complete-Profile.aspx");

    }
}