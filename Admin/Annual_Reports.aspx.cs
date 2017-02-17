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
using System.IO;
using Businessobj;
using System.Net.Mail;


public partial class Admin_Annual_Reports : System.Web.UI.Page
{
    ClsReport report = new ClsReport();
    clsAnnualrpt annual = new clsAnnualrpt();
    DataTable objdt = new DataTable();
    DataSet objds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_ID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        pnl.Visible = false;
        FillGridEmail();
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

    protected void LBAdd_Click(object sender, EventArgs e)
    {
        pnl.Visible = true;
        txtAnnualReportTitle.Text = "";
        hpfile.Text = "";
        lblPnlTitle.Text = "Add New Record";
        HFCommand.Value = "AddNew";
    }

    private void FillGridEmail()
    {
        //GVBulliten.DataSource = Library.getDataset("Select * from M_Bulletin Order by BulletinID desc");
        //GVBulliten.DataBind();
        try
        {
            objdt = new DataTable();
            clsbulletin Bullet = new clsbulletin();
            Bullet.Action = "Email_id";
            objdt = Bullet.GetBullettin();
            if (objdt.Rows.Count > 0)
            {
                gvmemberEmail.DataSource = objdt;
                gvmemberEmail.DataBind();
            }
            else
            {
                gvmemberEmail.DataSource = null;
                gvmemberEmail.DataBind();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        string sql;
        string AnnualReportID = "";
        string sFileName = FUAnnualReportFile.FileName;
        if (HFCommand.Value == "AddNew")
        {

            annual = new clsAnnualrpt();
            objds = new DataSet();
            objdt = new DataTable();
            DataTable objdt1 = new DataTable();

            // AnnualReportID = Library.getSingleValue("select max(AnnualReportID)+1 from M_AnnualReport");

            //sql = "Insert Into M_AnnualReport (AnnualReportTitle,AnnualReportFile)values ('" + txtAnnualReportTitle.Text.Trim().Replace("'", "''") + "','" + sFileName.Replace("'", "''") + "')";


            annual.Action = "Insert";
            if (sFileName != "")
            {
                sFileName = Uploader(sFileName, AnnualReportID);


            }
            annual.AnnualReportFile = sFileName;
            annual.AnnualReportTitle = txtAnnualReportTitle.Text;
            objds = annual.insertAnnual();

            if (objds.Tables.Count > 0)
            {
                objdt = objds.Tables[0];
                objdt1 = objds.Tables[1];

                //if (objdt.Rows.Count > 0)
                //{
                //    AnnualReportID = objdt.Rows[0]["AnnualReportID"].ToString();
                //}


                if (objdt1.Rows[0][0].ToString() == "1")
                {
                    for (int i = 0; i < gvmemberEmail.Rows.Count; i++)
                    {
                        Label lblemail = (Label)gvmemberEmail.Rows[i].FindControl("lblemail");
                        string subject;
                        string body;
                        string to = lblemail.Text;
                        string from = "info@epilpa.org";

                        string ErrMsg;
                        //  int RegID = Convert.ToInt32(txtsrno.Text.Trim());
                        MailMessage email = new MailMessage(from, to);
                        email.Subject = "New Annual Report- "+txtAnnualReportTitle.Text+"" ;
                        email.IsBodyHtml = true;
                        email.Body = "<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><b>Hello Customer,</b><br><br><br>This is to Inform That New Annual Report has been  Added <BR> Please Refer Our Web-Site<BR><BR><br><b>From,<br>www.epilpa.org<BR>(Team)</b><br></font>";
                        string FileName = "";
                        SmtpClient mailclient = new SmtpClient();
                        System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("info@epilpa.org", "BYJ^$#@3");
                        mailclient.Host = "smtp.epilpa.org";
                        mailclient.Port = 25;
                        mailclient.Timeout = 100000;

                        mailclient.UseDefaultCredentials = false;
                        mailclient.Credentials = basicAuthenticationInfo;
                        ErrMsg = string.Empty;


                        try
                        {
                            mailclient.Send(email);
                            //return 1;
                        }
                        catch (Exception ex)
                        {
                            ErrMsg = ex.Message;
                            //return 0;
                        }
                    }
                    Label1.Visible = true;
                    Label1.Text = "Insert Sucessfully..!!!!";
                }
            }

        }
        else
        {

            // AnnualReportID = 

            annual.AnnualReportID = Convert.ToInt32(GVAnnualReport.SelectedDataKey.Value.ToString());
            if ((sFileName == "" || sFileName == null))
            {
                sFileName = hpfile.Text;
            }
            else
            {
                sFileName = Uploader(sFileName, AnnualReportID);
                if (File.Exists(Server.MapPath("Upload/" + hpfile.Text)))
                {
                    File.Delete(Server.MapPath("Upload/" + hpfile.Text));
                }
            }
            annual.AnnualReportFile = sFileName;
            annual.AnnualReportTitle = txtAnnualReportTitle.Text;
            annual.Action = "Update";
            objds = annual.insertAnnual();

        }
        // Library.execNonQueryB(sql);
        FillGrid();
    }

    private string Uploader(string sFileName, string AnnualReportID)
    {


        string[] filetype = sFileName.Split('.');
        string abc = filetype[0].ToString();
        string fileext = filetype[filetype.GetUpperBound(0)];
        //string sPath = Server.MapPath("Upload") + "/AnnualReport_" + AnnualReportID + "." + fileext;
        string sPath = Server.MapPath("Upload") + "/AnnualReport_" + abc + Convert.ToDateTime(DateTime.Now).ToString("dd-MMM-yyyy H-mm-ss").Trim() + "." + fileext;
        if (!(sFileName == "" || sFileName == null))
        {
            FUAnnualReportFile.PostedFile.SaveAs(sPath);
            sFileName = "AnnualReport_" + abc + Convert.ToDateTime(DateTime.Now).ToString("dd-MMM-yyyy H-mm-ss").Trim() + "." + fileext;
            // sFileName = "AnnualReport_" + AnnualReportID + "." + fileext;
        }
        return sFileName;
    }

    //protected void btnCancle_Click(object sender, ImageClickEventArgs e)
    //{
    //    Response.Redirect("Annual_Reports.aspx");
    //}
    //protected void GVAnnualReport_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string sql = "Select * from M_AnnualReport Where AnnualReportID=" + GVAnnualReport.SelectedDataKey.Value;
    //  //  DataTable dt = Library.getDataset(sql).Tables[0];

    //    pnl.Visible = true;
    //    RequiredFieldValidator2.Enabled = false;
    //    txtAnnualReportTitle.Text = dt.Rows[0]["AnnualReportTitle"].ToString();
    //    hpfile.Text = dt.Rows[0]["AnnualReportFile"].ToString();
    //    hpfile.NavigateUrl = "Upload/" + dt.Rows[0]["AnnualReportFile"].ToString();

    //   HFCommand.Value = "Update";
    //}
    protected void GVAnnualReport_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Kdelete")
        {
            //string filename = Library.getSingleValue("Select AnnualReportFile From M_AnnualReport Where AnnualReportID=" + e.CommandArgument.ToString());
            //if (File.Exists(Server.MapPath("Upload/" + filename)))
            //{
            //    File.Delete(Server.MapPath("Upload/" + filename));
            //}

            //string sql = "delete from M_AnnualReport where AnnualReportID=" + e.CommandArgument.ToString();
            //Library.execNonQueryB(sql);
            annual.AnnualReportID = Convert.ToInt32(e.CommandArgument.ToString());
            annual.Action = "Delete";
            objds = annual.insertAnnual();

            FillGrid();
        }
    }

    protected void btnCancle_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Annual_Reports.aspx");
    }

    protected void GVAnnualReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clsAnnualrpt annual = new clsAnnualrpt();
            objds = new DataSet();
            annual.AnnualReportID = Convert.ToInt32(GVAnnualReport.SelectedDataKey.Value);
            annual.Action = "GetRpt";
            objds = annual.insertAnnual();
            if (objds.Tables.Count > 0)
            {
                objdt = objds.Tables[0];
                pnl.Visible = true;
                RequiredFieldValidator2.Enabled = false;
                txtAnnualReportTitle.Text = objdt.Rows[0]["AnnualReportTitle"].ToString();
                hpfile.Text = objdt.Rows[0]["AnnualReportFile"].ToString();
                hpfile.NavigateUrl = "Upload/" + objdt.Rows[0]["AnnualReportFile"].ToString();

                HFCommand.Value = "Update";
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
