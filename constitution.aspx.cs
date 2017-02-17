using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class constitution : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["ISLogin"]) != "Yes")
            {
                Response.Redirect("index.aspx?login=no");
                Session["ISLogin"] = "No";

            }
            else
            {

            }
        }
    }
}