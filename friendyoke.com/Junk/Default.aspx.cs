using System;
using System.Data;
using System.Web.UI;


namespace Telerik.AJAXExamplesCSharp.AJAX.Examples.Common.LoadingUserControls
{
    public partial class _Default : System.Web.UI.Page
    {

        private void Page_Load(object sender, System.EventArgs e)
        {
            if (LatestLoadedControlName != null)
            {
                LoadUserControl(LatestLoadedControlName);
            }
            else
            {
                LoadUserControl("Newsfeed/nfeed.ascx");
            }
                
            
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.Load += new System.EventHandler(this.Page_Load);
            LoadUserControl("Newsfeed/nfeed.ascx");
            LoadUserControl("Ement/videog.ascx");
            LoadUserControl("Space/labs.ascx");
            Panel1.Controls.Clear();
        }
        #endregion





        public void LoadUserControl(string controlName)
        {
            if (LatestLoadedControlName != null)
            {
                Control previousControl = Panel1.FindControl(LatestLoadedControlName.Split('.')[0]);
                if (!Object.Equals(previousControl, null))
                {
                    this.Panel1.Controls.Remove(previousControl);
                }
            }
            Random ran = new Random();
            int x = ran.Next();
            string userControlID = x.ToString() +  controlName.Split('.')[0];
            Control targetControl = Panel1.FindControl(userControlID);
            if (Object.Equals(targetControl, null))
            {
                UserControl userControl = (UserControl)this.LoadControl(controlName);
                //slashes and tildes are forbidden
                userControl.ID = userControlID.Replace("/", "").Replace("~", "");
                this.Panel1.Controls.Add(userControl);
                LatestLoadedControlName = controlName;
            }
        }


        private string LatestLoadedControlName
        {
            get
            {
                return (string)ViewState["LatestLoadedControlName"];
            }
            set
            {
                ViewState["LatestLoadedControlName"] = value;
            }
        }





        protected void RadPanelBar1_ItemClick(object sender, Web.UI.RadPanelBarEventArgs e)
        {
            Panel1.Controls.Clear();
           
            if (e.Item.Value == "1")
            {
                LoadUserControl("Newsfeed/nfeed.ascx");
            }
            if (e.Item.Value == "2")
            {
                LoadUserControl("Space/labs.ascx");
            }
            if (e.Item.Value == "3")
            {
                LoadUserControl("Space/labs.ascx");
            }
            if (e.Item.Value == "4")
            {
                LoadUserControl("Space/labs.ascx");
            }
            if (e.Item.Value == "6")
            {
                LoadUserControl("Space/labs.ascx");

            } if (e.Item.Value == "7")
            {
                LoadUserControl("Space/labs.ascx");

            } if (e.Item.Value == "8")
            {
                LoadUserControl("Ement/videog.ascx");
            }
            if (e.Item.Value == "9")
            {
                LoadUserControl("Space/labs.ascx");
            }
            if (e.Item.Value == "10")
            {
                LoadUserControl("Space/labs.ascx");
            } 
        }
        
            

    }
}