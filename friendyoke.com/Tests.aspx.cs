using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Telerik.Web.UI;

using System.IO;

public partial class Tests : System.Web.UI.Page
{
    Db getn = new Db();
    public DataTable dt;
    
    protected void Page_Load(object sender, EventArgs e)
    { }
   
}