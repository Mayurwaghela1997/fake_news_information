using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //This is the Master page which is going to be constant in all the other pages. 
        //eg:- Fact check Heading in Red Background is added on aspx page of MasterPage
    }
}
