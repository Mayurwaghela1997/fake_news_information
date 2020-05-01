using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Creating a class ITEM and creating the variables as in JSON file
public class Item
{
    public string url;
    public string source;
    public string claim;
    public string claim_url;
    public string Labeldata;
    public DateTime datetime;
    public string author;
}

public partial class _Default : System.Web.UI.Page
{
    List<string> urls = new List<string>();
    List<string> OriginalDecision = new List<string>();
    List<string> PublishedDate = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        string json;
        //Reading JSON file using JSON package
        using (System.IO.StreamReader r = new System.IO.StreamReader("E://Koblenz//Student Job//Hiwi//sample.json"))
        {
            json = r.ReadToEnd();
            List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
        }
        dynamic array = JsonConvert.DeserializeObject(json);
        //adding each data in an array.
        foreach (var item in array)
        {
            //Label1.Text += item.claim + "/n";
            urls.Add(item.claim_url.ToString());
            OriginalDecision.Add(item.label.ToString());
            PublishedDate.Add(item.date.ToString());
        }
        urlIframe.Src = "https://www.facebook.com/plugins/post.php?href=https%3A%2F%2Fwww.facebook.com%2Fthiruavai.seithi.1%2Fvideos%2Fvb.100035273200456%2F172082453977527%2F%3Ftype%3D2%26theater&width=500&show_text=true&height=409&appId";
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        changeurl();  //Calling changeurl function on every Next button click.      
    }

    //Creating a function which will change the url and inserts the user data into Database.
    public void changeurl()
    {
        //taking believability and priorknowldege data from user.
        float Pindex = float.Parse(priorKnowledgeslider.Value);
        float Bindex = float.Parse(believabilitySlider.Value);
        //resetting the slider values to 0.
        believabilitySlider.Value = "0";
        priorKnowledgeslider.Value = "0";
        try
        {
            //creating SQL connection with Database.
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-I6TAGKP;Initial Catalog=FactcheckDB;Integrated Security=True");
            string SourceUrl = urlIframe.Src.ToString();
            int x = int.Parse(Label1.Text);
            string OD = OriginalDecision[x];
            string PD = PublishedDate[x];
            string username = Session["uid"].ToString();
            string query1 = "insert into UserData values('" + username + "',"+ Bindex +", "+ Pindex +" , '"+ SourceUrl +"', '"+OD+"', '"+PD+"')";
            //opening an SQL connection
            con1.Open();
            //Executing the Query
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            cmd1.ExecuteNonQuery();
            //Closing the SQL Connection.
            con1.Close();
        }
        catch{ }

        //Chaning the URLS in Iframe.
        int c = int.Parse(Label1.Text) + 1;
        Label1.Text = c.ToString();
        try
        {
            if (urls[c].Contains("twitter"))
            {
                urls[c] = "https://twitframe.com/show?url=" + urls[c]; //Twitter API Gateway (Parameter - Original URL)
            }
            else if (urls[c].Contains("facebook"))
            {
                urls[c] = "https://www.facebook.com/plugins/post.php?href=" + urls[c]; //Facebook API Gateway (Parameter - Original URL)
            }
            else if (urls[c].Contains("youtube"))
            {
                string[] splittedurl = urls[c].Split(new string[] { "?v=" }, 2, StringSplitOptions.None); //URL Parsing for getting Video ID 
                urls[c] = "https://www.youtube.com/embed/" + splittedurl[1]; // YouTube API Gateway. (Parameter - YouTube Video ID)
            }
            try
            {
                urlIframe.Src = urls[c]; //Changung the Iframe Source
            }
            catch{ }
        }
        catch
        {
            lblThanks.Visible = true; //Showing Thanks message on completion of JSON file
            divContent.Visible = false; 
        }
    }
}