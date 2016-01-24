using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Net.Mail;
using System.Threading;
using Google.Contacts;
using Google.GData.Client;
using Google.GData.Contacts;
using Google.GData.Extensions;
using Telerik.Web.UI;
public partial class Register_Find_Freinds : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnContacts_Click(object sender, EventArgs e)
    {
        //Provide Login Information
        ViewState["hello"] = txtPassword.Text;
        RequestSettings rsLoginInfo = new RequestSettings("", txtEmail.Text, txtPassword.Text);
        rsLoginInfo.AutoPaging = true;

        // Fetch contacts and dislay them in ListBox
        ContactsRequest cRequest = new ContactsRequest(rsLoginInfo);
        Feed<Contact> feedContacts = cRequest.GetContacts();
        foreach (Contact gmailAddresses in feedContacts.Entries)
        {

            foreach (EMail emailId in gmailAddresses.Emails)
            {
                RadListBoxItem item = new RadListBoxItem();
                item.Text = emailId.Address;
                RadListBoxSource.Items.Add(item);
            }
        }
    }
    public Boolean sendemail(String strFrom, string fromm , string pass, string strTo, string strSubject, string strBody, string strAttachmentPath, bool IsBodyHTML)
    {
        Array arrToArray;
        char[] splitter = { ';' };
        arrToArray = strTo.Split(splitter);
        MailMessage mm = new MailMessage();
        mm.From = new MailAddress(strFrom);
        mm.Subject = strSubject;
        mm.Body = strBody;
        mm.IsBodyHtml = IsBodyHTML;
        mm.ReplyTo = new MailAddress("friendyoke@gmail.com");
        foreach (string s in arrToArray)
        {
            mm.To.Add(new MailAddress(s));
        }
        if (strAttachmentPath != "")
        {
            try
            {
                //Add Attachment
                Attachment attachFile = new Attachment(strAttachmentPath);
                mm.Attachments.Add(attachFile);
            }
            catch { }
        }
        SmtpClient smtp = new SmtpClient();
        try
        {
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true; //Depending on server SSL Settings true/false
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = fromm;
            //NetworkCred.Password = "fuckfacebook123";
            NetworkCred.Password = pass;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;//Specify your port No;
            smtp.Send(mm);
            return true;

        }
        catch
        {
            mm.Dispose();
            smtp = null;
            return false;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        foreach(RadListBoxItem it in RadListBoxDestination.Items)
        {
            sendemail("friendyoke@gmail.com", txtEmail.Text, ViewState["hello"].ToString(), it.Text, "Hello your friend " + txtEmail.Text + " has invited you to join!!", @"<p>Hello your friend " + txtEmail.Text + @" has invited you to join!!</p> <h3>Join Friendyoke.com Now <a href='www.friendyoke.com'>--->JOIN FRIENDYOKE!!!<------</a></h3>", "", true);
            
        }

    }
  
}