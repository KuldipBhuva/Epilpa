using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Admin_ExpDate : System.Web.UI.Page
{
    Admin EXPSMS = new Admin();
    DataTable objdt = new DataTable();
    DataSet objds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Login_ID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            GridBind();
        }
    }
    public void GridBind()
    {
        try
        {
            objds = new DataSet();
            EXPSMS = new Admin();
            EXPSMS.Action = "ExpDateSMS";
            objds = EXPSMS.GetAdminSetting();
            if (objds.Tables.Count > 0)
            {
                grdMuser.DataSource = objdt;
                grdMuser.DataBind();
            }
            else
            {
                grdMuser.DataSource = null;
                grdMuser.DataBind();
            }
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnCancle_Click(object sender, ImageClickEventArgs e)
    {

    }
}