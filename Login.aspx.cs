using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //creating SQL connection with Database.
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-I6TAGKP;Initial Catalog=FactcheckDB;Integrated Security=True");
        try
        {

            string username = txtUsername.Text;
            //Query to check if username already exists in Database or not.
            string query1 = "Select UserName from UserData where UserName = '" + username + "'";
            //Opening SQL connection
            con.Open();
            //Executing Query
            SqlCommand cmd = new SqlCommand(query1, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.HasRows)
            {
                //Showing error message if username exists in Database
                LabelError.Text = "Username already exist, Please choose a different username";
            }
            else
            {
                //Storing username in Session for further use
                Session["uid"] = username;
                //redirectiing to main page
                Response.Redirect("Default.aspx");
            }
            con.Close();
            
        }
        catch { }
    }
}