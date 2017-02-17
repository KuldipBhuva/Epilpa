using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["ISLogin"]) == "Yes")
            {
                lblusername.Text = Session["UName"].ToString();
                lbtnLogOut.Text = "LogOut";
                lblprofile.Visible = true;
                lbtnLogOut.Visible = true;
            }
            else 
            {
                lblusername.Text = "Guest";
                lbtnLogOut.Text = "LogIn";
                lbtnLogOut.PostBackUrl = "index.aspx";

            }
           

        }
    }
    protected void lbtnLogOut_Click(object sender, EventArgs e)
    {
        Session["ISLogin"] = "No";
        Response.Redirect("index.aspx");
    }
    protected void lblprofile_Click(object sender, EventArgs e)
    {
        Response.Redirect("Myprofile.aspx");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) == "Yes")
        {
            Response.Redirect("constitution.aspx");

        }
        else
        {
            Response.Write("<script>alert('Please Login First...!!!!');</script>");

        }
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) == "Yes")
        {
            Response.Redirect("news.aspx");

        }
        else
        {
            Response.Write("<script>alert('Please Login First...!!!!');</script>");

        }
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) == "Yes")
        {
            Response.Redirect("Bulliten.aspx");

        }
        else
        {
            Response.Write("<script>alert('Please Login First...!!!!');</script>");

        }
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) == "Yes")
        {
            Response.Redirect("Annual_Reports.aspx");

        }
        else
        {
            Response.Write("<script>alert('Please Login First...!!!!');</script>");

        }
    }
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) == "Yes")
        {
            Response.Redirect("inq_form.aspx");

        }
        else
        {
            Response.Redirect("inq_form.aspx");


        }
    }
    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) == "Yes")
        {
            Response.Redirect("events.aspx");

        }
        else
        {
            Response.Redirect("events.aspx");


        }
    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) == "Yes")
        {
            Response.Redirect("bare_act3.aspx");

        }
        else
        {
            Response.Redirect("bare_act3.aspx");

        }
    }
}
