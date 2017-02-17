using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Globalization;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Xml;

public partial class Admin_Undeliver : System.Web.UI.Page
{
    DataTable Objdt = new DataTable();
    DataTable Objdt2 = new DataTable();
    clsUndeliverDeliver Deliver = new clsUndeliverDeliver();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Login_ID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            txtDateCalender.Attributes.Add("readonly", "readonly");
        }
    }
    protected void imgbtnCal_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtDateCalender.Text != " ")
            {

                string Date = txtDateCalender.Text;
                DataTable NewTable = Deliver.NewUndeliveredSMS(Date);
                if (NewTable.Rows.Count > 0)
                {
                    GrdMsgStatus.DataSource = NewTable;
                    GrdMsgStatus.DataBind();
                    txtDateCalender.Text = "";
                    lblMsg.Text = "";

                }
                else
                {
                    GrdMsgStatus.DataSource = null;
                    GrdMsgStatus.DataBind();
                }
            }
        }



        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnViewCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtDateCalender.Text = "";
            lblMsg.Text = "";
            GrdMsgStatus.DataSource = null;
            GrdMsgStatus.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void txtDateCalender_TextChanged(object sender, EventArgs e)
    {

    }
}