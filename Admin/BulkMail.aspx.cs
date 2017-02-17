using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.IO;

public partial class Admin_BulkMail : System.Web.UI.Page
{
    ClsBulkEmail Email = new ClsBulkEmail();
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
            ViewState["CurrentAlphabet"] = "ALL";
            this.GenerateAlphabets();
            GridBind();

        }
    }
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {

        try
        {
            MailMessage mail = new MailMessage();
            //btnLog.Visible = true;
            Email = new ClsBulkEmail();
            StreamWriter sb;
            if (!Directory.Exists(Server.MapPath("Bulkemail")))
            {
                Directory.CreateDirectory(Server.MapPath("Bulkemail"));

            }
            string fnm = "";
            // fnm = DrpType.SelectedValue + "_" + DateTime.Now.ToString("ddMMyyyy");

            sb = File.CreateText(Server.MapPath("Bulkemail\\" + fnm + ".txt"));
            TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);

            sb.WriteLine("File Generated On:" + indianTime.ToString() + " IST");
            //  sb.WriteLine("Company Status:" + DrpType.SelectedValue);

            if (Session["Bulkemail4"] != null)
            {
                sb.WriteLine("List Of Attachments:" + Session["Bulkemail"].ToString() + "," + Session["Bulkemail1"].ToString() + "," + Session["Bulkemail2"].ToString() + "," + Session["Bulkemail3"].ToString() + "," + Session["Bulkemail4"].ToString());
            }
            else if (Session["Bulkemail3"] != null)
            {
                sb.WriteLine("List Of Attachments:" + Session["Bulkemail"].ToString() + "," + Session["Bulkemail1"].ToString() + "," + Session["Bulkemail2"].ToString() + "," + Session["Bulkemail3"].ToString());
            }
            else if (Session["Bulkemail2"] != null)
            {
                sb.WriteLine("List Of Attachments:" + Session["Bulkemail"].ToString() + "," + Session["Bulkemail1"].ToString() + "," + Session["Bulkemail2"].ToString());
            }
            else if (Session["Bulkemail1"] != null)
            {
                sb.WriteLine("List Of Attachments:" + Session["Bulkemail"].ToString() + "," + Session["Bulkemail1"].ToString());
            }
            else if (Session["Bulkemail"] != null)
            {
                sb.WriteLine("List Of Attachments:" + Session["Bulkemail"].ToString());
            }

            sb.WriteLine("1 : Email Sent Sucessfully");
            sb.WriteLine("0 : Email Not Sent Sucessfully");
            sb.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");
            sb.WriteLine("Email Address " + spaces(30) + "Name" + spaces(30) + "Status " + spaces(30) + "Attachments");
            sb.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------");

            string body;
            //body = txtBody.Text.ToString() + "<br /> <b>* This is a post-only mailing. Replies to this message are not monitored or answered. *</b>";
            body = Editor1.Text.Replace("\n", "<br />").ToString() + "<br /><br /> <b>* This is a post-only mailing. Replies to this message are not monitored or answered. *</b>";

            string FileName = "";

            FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
            if (FileName.ToString() != "")
            {
                fuAttachment.SaveAs(Server.MapPath("~/Admin/Bulkemail/" + FileName));
                String Imagpath = "~/Admin/Bulkemail/" + FileName;

                Attachment myAttachment = new Attachment(fuAttachment.FileContent, FileName);
                //MailAttachment attach = new MailAttachment(HttpContext.Current.Server.MapPath(Imagpath));

                /* Attach the newly created email attachment */
                // mail.Attachments.Add(attach);
                mail.Attachments.Add(myAttachment);
                for (int j = 0; j < grdEmail.Rows.Count; j++)
                {
                    CheckBox chk;
                    int len = 0;
                    int lencc = 0;
                    int lenname = 0;
                    chk = (CheckBox)grdEmail.Rows[j].FindControl("chkData");
                    if (chk.Checked == true)
                    {
                        //lencc = 33 - ((Label)grdEmail.Rows[j].FindControl("lblType")).Text.Length;
                        len = 44 - ((Label)grdEmail.Rows[j].FindControl("lblEmail")).Text.Length;
                        lenname = 34 - ((Label)grdEmail.Rows[j].FindControl("lblName")).Text.Length;
                        //obj.sendEmail(txtSubject.Text, txtBody.Text, ((Label)grdInside.Rows[j].FindControl("lblEmail")).Text, "test@vpdconsultants.com", flupload);



                        string errMsg = string.Empty;
                        //if (fuAttachment.HasFile)
                        //  {
                        //      string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                        //      mail.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                        //  }
                        if (Email.sendEmailforBulkemail(txtSubject.Text, body.ToString(), ((Label)grdEmail.Rows[j].FindControl("lblEmail")).Text, "info@epilpa.org", Imagpath, out errMsg) == 1)
                        {
                            sb.WriteLine(((Label)grdEmail.Rows[j].FindControl("lblEmail")).Text + spaces(len) + ((Label)grdEmail.Rows[j].FindControl("lblName")).Text + spaces(lenname) + "1");
                            txtSubject.Text = "";
                            //Editor1.Content = "";
                            Editor1.Text = "";
                        }
                        else
                        {
                            labelStatus.Text = errMsg;
                            sb.WriteLine(((Label)grdEmail.Rows[j].FindControl("lblEmail")).Text + spaces(len) + ((Label)grdEmail.Rows[j].FindControl("lblName")).Text + spaces(lenname) + "0");
                        }
                    }
                }

            }

            else
            {

                for (int j = 0; j < grdEmail.Rows.Count; j++)
                {
                    CheckBox chk;
                    int len = 0;
                    int lencc = 0;
                    int lenname = 0;
                    chk = (CheckBox)grdEmail.Rows[j].FindControl("chkData");
                    if (chk.Checked == true)
                    {
                        //lencc = 33 - ((Label)grdEmail.Rows[j].FindControl("lblType")).Text.Length;
                        len = 44 - ((Label)grdEmail.Rows[j].FindControl("lblEmail")).Text.Length;
                        lenname = 34 - ((Label)grdEmail.Rows[j].FindControl("lblName")).Text.Length;
                        //obj.sendEmail(txtSubject.Text, txtBody.Text, ((Label)grdInside.Rows[j].FindControl("lblEmail")).Text, "test@vpdconsultants.com", flupload);



                        string errMsg = string.Empty;
                        String Imagpath = "";
                        //if (fuAttachment.HasFile)
                        //  {
                        //      string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                        //      mail.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
                        //  }
                        if (Email.sendEmailforBulkemail(txtSubject.Text, body.ToString(), ((Label)grdEmail.Rows[j].FindControl("lblEmail")).Text, "info@epilpa.org", Imagpath, out errMsg) == 1)
                        {
                            sb.WriteLine(((Label)grdEmail.Rows[j].FindControl("lblEmail")).Text + spaces(len) + ((Label)grdEmail.Rows[j].FindControl("lblName")).Text + spaces(lenname) + "1");
                            txtSubject.Text = "";
                            //Editor1.Content = "";
                            Editor1.Text = "";
                        }
                        else
                        {
                            labelStatus.Text = errMsg;
                            sb.WriteLine(((Label)grdEmail.Rows[j].FindControl("lblEmail")).Text + spaces(len) + ((Label)grdEmail.Rows[j].FindControl("lblName")).Text + spaces(lenname) + "0");
                        }
                    }
                }
            }
            sb.Flush();
            sb.Close();
            labelStatus.Text = "Email sent successfully...";
        }
        catch (Exception ex)
        {

            lblError.Text = "<b>Message:</b> " + ex.Message; ;
        }

    }
    public string spaces(int i)
    {
        string spc = "";
        for (int j = 0; j < i; j++)
        {
            spc = spc + " ";
        }
        return spc;
    }

    public void GridBind()
    {
        try
        {
            Email = new ClsBulkEmail();
            objdt = new DataTable();
            objds = new DataSet();
            if (ViewState["CurrentAlphabet"].ToString() == "ALL")
            {
                Email.Action = "ALL";
            }
            else
            {
                Email.Action = "PremiumMem";
                Email.StartAlpha = (ViewState["CurrentAlphabet"].ToString());
            }
            objds = Email.Mail();
            if (objds.Tables.Count > 0)
            {
                grdEmail.DataSource = objds;
                grdEmail.DataBind();
                DivGrid.Visible = true;
                DivAddNew.Visible = true;

            }
            else
            {

            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    protected void grdEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdEmail.PageIndex = e.NewPageIndex;
        GridBind();
    }
    protected void Alphabet_Click(object sender, EventArgs e)
    {
        LinkButton lnkAlphabet = (LinkButton)sender;
        ViewState["CurrentAlphabet"] = lnkAlphabet.Text;
        this.GenerateAlphabets();
        grdEmail.PageIndex = 0;
        this.GridBind();
    }
    private void GenerateAlphabets()
    {
        List<ListItem> alphabets = new List<ListItem>();
        ListItem alphabet = new ListItem();
        alphabet.Value = "ALL";
        alphabet.Selected = alphabet.Value.Equals(ViewState["CurrentAlphabet"]);
        alphabets.Add(alphabet);
        for (int i = 65; i <= 90; i++)
        {
            alphabet = new ListItem();
            alphabet.Value = Char.ConvertFromUtf32(i);
            alphabet.Selected = alphabet.Value.Equals(ViewState["CurrentAlphabet"]);
            alphabets.Add(alphabet);
        }
        rptAlphabets.DataSource = alphabets;
        rptAlphabets.DataBind();
    }
}