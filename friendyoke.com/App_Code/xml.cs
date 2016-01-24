using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


/// <summary>
/// Summary description for xml
/// </summary>
public class xml
{
	public xml()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void xmldbwrite(string Query)
    
    {

        TextWriter new1 = new StreamWriter(@"F:\\inetpub\\wwwroot\\pcher\\Admin\\Database\\db.xml");
        new1.Write(Query);
        new1.Flush();
        new1.Close();
    
    }

    public void xmldbread()
    {
        XDocument xmlDoc = XDocument.Load(@"F:\\inetpub\\wwwroot\\pcher\\Admin\\Database\\db.xml");


    }


}