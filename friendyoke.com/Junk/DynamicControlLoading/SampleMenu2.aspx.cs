using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class SampleMenuPage2 : System.Web.UI.Page
{
    private const string BASE_PATH = "~/DynamicControlLoading/";

    private string LastLoadedControl
    {
        get
        {
            return ViewState["LastLoaded"] as string;
        }
        set
        {
            ViewState["LastLoaded"] = value;
        }
    }

    private void LoadUserControl()
    {
        string controlPath = LastLoadedControl;

        if (!string.IsNullOrEmpty(controlPath))
        {
            PlaceHolder1.Controls.Clear();
            UserControl uc = (UserControl)LoadControl(controlPath);
            PlaceHolder1.Controls.Add(uc);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadUserControl();

        if (IsPostBack)
        {
            //Sleeps for 1 Seconds
            //A Fake Deley to show the UpdateProgress/ModalPopup
            System.Threading.Thread.Sleep(1000); 
        }
    }

    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        MenuItem menu = e.Item;

        string controlPath = string.Empty;

        switch (menu.Text)
        {
            case "Load Control2":
                controlPath = BASE_PATH + "SampleControl2.ascx";
                break;
            case "Load Control3":
                controlPath = BASE_PATH + "SampleControl3.ascx";
                break;
            default:
                controlPath = BASE_PATH + "SampleControl1.ascx";
                break;
        }

        LastLoadedControl = controlPath;
        LoadUserControl();
    }
}
