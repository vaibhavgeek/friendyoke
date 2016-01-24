using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Extensions.MediaRss;
using Google.YouTube;
using Google.GData.YouTube;
using System.Text;
using System.Data;
using Telerik.Web.UI;

public partial class Ement_videog : System.Web.UI.UserControl
{
    private string YouTubeChampionshipChannel;

    private string YouTubeDeveloperKey;
    public string YouTubeMovieID;
    public DataTable dtVideoData = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    private void CreateVideoFeed(string s)
    {
        YouTubeRequestSettings settings = new YouTubeRequestSettings("most_viewed", YouTubeDeveloperKey);
        YouTubeRequest request = new YouTubeRequest(settings);

        //Link to the feed we wish to read from
        string feedUrl = String.Format("http://gdata.youtube.com/feeds/api/videos?q=" + s);

        dtVideoData.Columns.Add("Title");
       
        dtVideoData.Columns.Add("DateUploaded");


        dtVideoData.Columns.Add("VideoID");
        dtVideoData.Columns.Add("Duration");

        DataRow drVideoData;

        Feed<Video> videoFeed = request.Get<Video>(new Uri(feedUrl));

        //Iterate through each video entry and store details in DataTable
        foreach (Video videoEntry in videoFeed.Entries)
        {
            drVideoData = dtVideoData.NewRow();

            drVideoData["Title"] = videoEntry.Title;
           
            drVideoData["DateUploaded"] = videoEntry.Updated.ToShortDateString();


            drVideoData["VideoID"] = videoEntry.YouTubeEntry.VideoId;
            drVideoData["Duration"] = videoEntry.YouTubeEntry.Duration.Seconds.ToString();

            dtVideoData.Rows.Add(drVideoData);
        }

        RadGrid1.DataSource = dtVideoData;
        RadGrid1.DataBind();

    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        //Pass User Name to the YouTube link


        //Add the YouTube Developer keys.
        //Register a Developer Key at: http://code.google.com/apis/youtube/dashboard

        YouTubeDeveloperKey = "AI39si6-oxMy3ko835hyp7awIwbZH2iVzXqA8RZGb2qeT_ka0Yvvkzmir5TOz1Ik-GYswkKpGTwZRhDIgXM71uANEG6E5kkuZQ";

        CreateVideoFeed(TextBox1.Text);

        //Assign the first video details on page load.
        if (String.IsNullOrEmpty(YouTubeMovieID))
        {
            YouTubeMovieID = dtVideoData.Rows[0]["VideoID"].ToString();

        }

    }
    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        YouTubeMovieID = e.CommandArgument.ToString();



    }
    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {


        if (e.Item.ItemType == GridItemType.Item || e.Item.ItemType == GridItemType.AlternatingItem)
        {
            DataRowView drVideo = (DataRowView)e.Item.DataItem;

            Button showVideo = (Button)e.Item.FindControl("btnShowVideo");
            Literal title = (Literal)e.Item.FindControl("Title");
           


            Literal duration = (Literal)e.Item.FindControl("Duration");

            showVideo.CommandArgument = drVideo["VideoID"].ToString();
            title.Text = drVideo["Title"].ToString();
            


            string durat = drVideo["Duration"].ToString();
            int d = int.Parse(durat);
            int s = d / 60;
            int r = d % 60;
            duration.Text = s.ToString() + " Min " + r.ToString() + " Sec";

        }

    }



    protected void RadGrid1_PageIndexChanged(object sender, GridPageChangedEventArgs e)
    {
        CreateVideoFeed(TextBox1.Text);
        int currentpage = RadGrid1.CurrentPageIndex;
        RadGrid1.CurrentPageIndex = currentpage + 1;

    }
}