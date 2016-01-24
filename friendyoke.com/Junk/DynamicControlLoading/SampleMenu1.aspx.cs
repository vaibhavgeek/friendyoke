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

namespace Telerik.Web.Examples.ToolTip.TargetControlsAndAjax
{

    public partial class SampleMenuPage1 : System.Web.UI.Page
    {
        protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
        {
            this.UpdateToolTip(args.Value, args.UpdatePanel);
        }
        private void UpdateToolTip(string elementID, UpdatePanel panel)
        {
            Control ctrl = Page.LoadControl("SampleControl1.ascx");
            panel.ContentTemplateContainer.Controls.Add(ctrl);
            SampleControl1 details = (SampleControl1)ctrl;
            details.ProductID = elementID;
        }
        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
            {
                Control target = e.Item.FindControl("targetControl");
                if (!Object.Equals(target, null))
                {
                    if (!Object.Equals(this.RadToolTipManager1, null))
                    {
                        //Add the button (target) id to the tooltip manager
                        this.RadToolTipManager1.TargetControls.Add(target.ClientID, (e.Item as GridDataItem).GetDataKeyValue("ID").ToString(), true);

                    }
                }
            }
        }
        protected void RadGrid1_ItemCommand(object source, GridCommandEventArgs e)
        {
            if (e.CommandName == "Sort" || e.CommandName == "Page")
            {
                RadToolTipManager1.TargetControls.Clear();
            }

        }
    }
}