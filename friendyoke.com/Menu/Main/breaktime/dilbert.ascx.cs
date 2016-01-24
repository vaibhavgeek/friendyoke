using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Telerik.Web.UI;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Collections;


public partial class Menu_Main_breaktime_dilbert : System.Web.UI.UserControl
{
    protected void Page_Init(object sender, EventArgs e)
    {
        ListImages();
    }

    private void ListImages()
    {
        DirectoryInfo dir = new DirectoryInfo(MapPath("~/Menu/Main/breaktime/dilbert/"));
        FileInfo[] file = dir.GetFiles();
        ArrayList list = new ArrayList();
        foreach (FileInfo file2 in file)
        {
            if (file2.Extension == ".jpg" || file2.Extension == ".jpeg" || file2.Extension == ".gif")
            {
                list.Add(file2);
            }
        }
        DataList1.DataSource = list;
        DataList1.DataBind();
    }
}