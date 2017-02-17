using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Businessobj;

public partial class index : System.Web.UI.Page
{
    Admin Admin = new Admin();
    DataSet objds = new DataSet();
    DataTable objdt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {


    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (validation() == 1)
        {
            try
            {
                objdt = new DataTable();
                objds = new DataSet();
                Admin = new Admin();
                Admin.AdminUserName = txtlogingid.Text;
                Admin.AdminUserPassword = txtpassword.Text;
                Admin.Action = "GetLog";
                objdt = Admin.Logininfo();
                if (objdt.Rows.Count > 0)
                {
                    Session.Timeout = 60;
                    Session["Login_ID"] = "admin";
                    Response.Redirect("Manage_Members.aspx");
                }
                else
                {
                    lblLoginError.Visible = true;
                    lblLoginError.Text = "Incorrect UserName or Password...!!!!";
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
    //string sqlloging = "Select AdminUserName from AdminSetting where AdminUserName='" + txtlogingid.Text + "' AND AdminUserPassword='" + txtpassword.Text + "' ";
    //string LoginValues = Library.getSingleValue(sqlloging);
    //if (LoginValues != "")
    //{
    //      Session.Timeout = 60;
    //    Session["Login_ID"] = LoginValues;
    //    Response.Redirect("Manage_Members.aspx");

    //}
    //else
    //{
    //    lblLoginError.Text = "Use valid username and password";
    //    lblLoginError.Visible = true;
    //    Session["Login_ID"] = null;
    //}

    public int validation()
    {
        if (txtlogingid.Text == "")
        {
            lblLoginError.Text = "Please Enter Login id";
            return 0;
        }
        if (txtpassword.Text == "")
        {
            lblLoginError.Text = "Please Enter Password";
            return 0;
        }
        return 1;


    }
}
