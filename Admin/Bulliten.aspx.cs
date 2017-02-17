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

public partial class Admin_Bulliten : System.Web.UI.Page
{
    clsbulletin Bullet = new clsbulletin();
    DataTable objdt = new DataTable();
    DataSet objds = new DataSet();
    public BusinessObject Library = new BusinessObject();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_ID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        pnl.Visible = false;
        pnlcategory.Visible = false;
        FillGridEmail();
        FillGrid();
        FillGridcat();
    }

    private void FillGrid()
    {
        //GVBulliten.DataSource = Library.getDataset("Select * from M_Bulletin Order by BulletinID desc");
        //GVBulliten.DataBind();
        try
        {
            objdt = new DataTable();
            Bullet = new clsbulletin();
            Bullet.Action = "Grid";
            objdt = Bullet.GetBullettin();
            if (objdt.Rows.Count > 0)
            {
                GVBulliten.DataSource = objdt;
                GVBulliten.DataBind();
            }
            else
            {
                GVBulliten.DataSource = null;
                GVBulliten.DataBind();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    private void FillGridEmail()
    {
        //GVBulliten.DataSource = Library.getDataset("Select * from M_Bulletin Order by BulletinID desc");
        //GVBulliten.DataBind();
        try
        {
            objdt = new DataTable();
            Bullet = new clsbulletin();
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

    private void FillGridcat()
    {
        try
        {
            objdt = new DataTable();
            Bullet = new clsbulletin();
            Bullet.Action = "CategoryGrid";
            objdt = Bullet.GetBullettin();
            if (objdt.Rows.Count > 0)
            {
                grdcategory.DataSource = objdt;
                grdcategory.DataBind();

            }
            else
            {
                grdcategory.DataSource = null;
                grdcategory.DataBind();

            }

        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    protected void LBAdd_Click(object sender, EventArgs e)
    {
        pnl.Visible = true;
        txtBulletinTitle.Text = "";
        lblPnlTitle.Text = "Add New Record";
        HFCommand.Value = "AddNew";

    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        string sql;
        string AnnualReportID = "";
        string sFileName = FUBuletinFile.FileName;
        if (HFCommand.Value == "AddNew")
        {


            if (sFileName.ToString() != "")
            {
                sFileName = Uploader(sFileName, AnnualReportID);

            }
            Bullet = new clsbulletin();
            objdt = new DataTable();
            Bullet.BuletinFile = sFileName;
            Bullet.BulletinTitle = txtBulletinTitle.Text;
            Bullet.Action = "insert";
            objdt = Bullet.GetBullettin();
            if (objdt.Rows[0][0].ToString() == "1")
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
                    email.Subject = "New Bulletin-" + txtBulletinTitle .Text+ "";
                    email.IsBodyHtml = true;
                    email.Body = "<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><b>Hello Customer,</b><br><br><br>This is to Inform That The New Bulletin has been  Added <BR> Please Refer Our Web-Site<BR><BR><br><b>From,<br>www.epilpa.org<BR>(Team)</b><br></font>";
                   
                 //   email.Body = "<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><b>Hello Customer,</b><br><br><br> is Added<BR><BR><BR><br><b>From,<br>www.epilpa.org<BR>(Team)</b><br></font>";
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
                lblinsert.Visible = true;
                lblinsert.Text = "Data Insert SucessFully..!!!!";
                FillGrid();


            }






        }

        //{
        //    BulletinID = GVBulliten.SelectedDataKey.Value.ToString();
        //    if ((sFileName == "" || sFileName == null))
        //    {
        //        sFileName = hpfile.Text;
        //    }
        //    else
        //    {
        //        sFileName = Uploader(sFileName, BulletinID);
        //        if (File.Exists(Server.MapPath("Upload/" + hpfile.Text)))
        //        {
        //            File.Delete(Server.MapPath("Upload/" + hpfile.Text));
        //        }
        //    }
        //    sql = "Update M_Bulletin Set BulletinTitle='" + txtBulletinTitle.Text.Trim().Replace("'", "''") + "',BuletinFile='" + sFileName.Replace("'", "''") + "' Where BulletinID=" + BulletinID;

        //}
        //Library.execNonQueryB(sql);


    }

    private string Uploader(string sFileName, string AnnualReportID)
    {


        string[] filetype = sFileName.Split('.');
        string abc = filetype[0].ToString();
        string fileext = filetype[filetype.GetUpperBound(0)];
        // string sPath = Server.MapPath("Upload") + "/" + AnnualReportID + "." + fileext;
        string sPath = Server.MapPath("Upload") + "/Bulliten_" + abc + Convert.ToDateTime(DateTime.Now).ToString("dd-MMM-yyyy H-mm-ss").Trim() + "." + fileext;

        if (!(sFileName == "" || sFileName == null))
        {
            FUBuletinFile.PostedFile.SaveAs(sPath);
            sFileName = "Bulliten_" + abc + Convert.ToDateTime(DateTime.Now).ToString("dd-MMM-yyyy H-mm-ss").Trim() + "." + fileext;
            //sFileName = "" + AnnualReportID + "." + fileext;
        }
        return sFileName;
    }

    protected void btnCancle_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Bulliten.aspx");
    }

    protected void GVBulliten_SelectedIndexChanged(object sender, EventArgs e)
    {

        objdt = new DataTable();
        Bullet = new clsbulletin();
        Bullet.Action = "BYid";
        Bullet.BulletinID = Convert.ToInt32(GVBulliten.SelectedDataKey.Value);
        objdt = Bullet.GetBullettin();
        if (objdt.Rows.Count > 0)
        {
            pnl.Visible = true;
            RequiredFieldValidator2.Enabled = false;
            txtBulletinTitle.Text = objdt.Rows[0]["BulletinTitle"].ToString();
            hpfile.Text = objdt.Rows[0]["BuletinFile"].ToString();
            hpfile.NavigateUrl = "Upload/" + objdt.Rows[0]["BuletinFile"].ToString();
            HFCommand.Value = "Update";
        }
        //string sql = "Select * from M_Bulletin Where BulletinID=" + GVBulliten.SelectedDataKey.Value;
        //DataTable dt = Library.getDataset(sql).Tables[0];


    }

    protected void GVBulliten_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Kdelete")
        {
            //objdt = new DataTable();
            //Bullet = new clsbulletin();
            Bullet.BulletinID = Convert.ToInt32(e.CommandArgument.ToString());
            Bullet.Action = "Delete";
            objds = Bullet.GetButtetinn();
            FillGrid();
        }
    }

    protected void Lnkcategory_Click(object sender, EventArgs e)
    {
        pnlcategory.Visible = true;
    }

    protected void imgsubmitcat_Click(object sender, ImageClickEventArgs e)
    {
        if (HFCommand.Value == "Update")
        {

            Bullet = new clsbulletin();
            DataTable objdt = new DataTable();
            objds = new DataSet();
            Bullet.Action = "Update";
            Bullet.catname = txtcatname.Text;
            objdt = Bullet.GetBullettin();
            if (objdt.Rows[0][0] == "1")
            {
                lblinsert.Visible = true;
                lblinsert.Text = "Update Sucessfully";
            }
            else
            {

            }


            //string BulletinID = grdcategory.SelectedDataKey.Value.ToString();
            //string sql = "update categorymaster  set catname ='" + tsxtcatname.Text + "' where catid = " + BulletinID + "";
            //Library.execNonQueryB(sql);
            //pnlcategory.Visible = false;
        }

        else
        {
            Bullet = new clsbulletin();
            DataTable objdt = new DataTable();
            objds = new DataSet();
            Bullet.Action = "Insert1";
            Bullet.catname = txtcatname.Text;
            objdt = Bullet.GetBullettin();
            if (objdt.Rows[0][0] == "1")
            {
                lblinsert.Text = "Insert SucessFully...!!!!";
                lblinsert.Visible = true;


            }
            else
            {

            }
            FillGridcat();

            //string sql = "Insert Into categorymaster (catname)values ('" + txtcatname.Text + "')";
            //Library.execNonQueryB(sql);
            //FillGridcat();
            //pnlcategory.Visible = false;
        }
    }

    protected void imgcancelcat_Click(object sender, ImageClickEventArgs e)
    {
        txtcatname.Text = "";
    }

    protected void grdcategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Kdelete")
        {
            Bullet = new clsbulletin();
            DataTable objdt = new DataTable();
            objds = new DataSet();
            Bullet.Action = "Deletecat";
            Bullet.catid = Convert.ToInt32(e.CommandArgument.ToString());
            objdt = Bullet.GetBullettin();
            if (objdt.Rows[0][0] == "1")
            {
                Response.Write("<script>alert('Data Deleted SucessFully...!!!!');</script>");


            }

            FillGridcat();
        }
    }


    protected void grdcategory_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Bullet = new clsbulletin();
        DataTable dt = new DataTable();
        objds = new DataSet();
        Bullet.Action = "Edit";
        Bullet.catid = Convert.ToInt32(grdcategory.SelectedDataKey.Value);
        dt = Bullet.GetBullettin();
        if (dt.Rows.Count > 0)
        {
            //int id = grdcategory.SelectedDataKey.Value;
            //string sql = "Select * from categorymaster Where catid=" + grdcategory.SelectedDataKey.Value;
            //DataTable dt = Library.getDataset(sql).Tables[0];
            pnl.Visible = false;
            pnlcategory.Visible = true;
            RequiredFieldValidator2.Enabled = false;
            txtcatname.Text = dt.Rows[0]["catname"].ToString();
            HFCommand.Value = "Update";
        }
    }
}
