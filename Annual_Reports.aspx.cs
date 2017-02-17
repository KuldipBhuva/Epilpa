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

public partial class Annual_Reports : System.Web.UI.Page
{
    ClsReport report = new ClsReport();
    DataTable objdt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) != "Yes")
        {
            Response.Redirect("index.aspx?login=no");
        }
        FillGrid();
    }
    private void FillGrid()
    {
        try
        {
            objdt = new DataTable();
            report = new ClsReport();
            report.Action = "Grid";
            objdt = report.GetReport();
            if (objdt.Rows.Count > 0)
            {
                GVAnnualReport.DataSource = objdt;
                GVAnnualReport.DataBind();
            }
            else
            {
                GVAnnualReport.DataSource = null;
                GVAnnualReport.DataBind();
            }

        }
        catch (Exception)
        {

            throw;
        }

    }
}
