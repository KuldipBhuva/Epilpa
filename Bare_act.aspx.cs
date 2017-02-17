using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bare_Act12 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) != "Yes")
        {
            Response.Redirect("index.aspx?login=no");
        }
    }
}