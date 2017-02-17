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
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class inq_form : System.Web.UI.Page
{
    BusinessObject Library = new BusinessObject();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["ISLogin"]) != "Yes")
        {
            Response.Redirect("index.aspx?login=no");
        }
    }
    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("inq_form.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //string RegID = "Select UserID from M_User Where UEmailID='" + txtEmailID.Text.Trim() + "'";

        //string mMailServer;
        
            string mTo;
            string mFrom;
            string mMsg;
            string mSubject;
            //int mPort;

            string subject;
            string body;
            string to = "info@epilpa.org";
            string from = "info@epilpa.org";

            string ErrMsg1;

            MailMessage email = new MailMessage(from, to);
            //   Image img = http://localhost:1900/Epilpa31Decnew/images/symbol.jpg
            // string path = Server.MapPath(@"images/symbol.jpg");
            // LinkedResource logo = new LinkedResource(path);
            //  logo.ContentId = "Company Logo";
            //AlternateView Av1 = AlternateView.CreateAlternateViewFromString("<html><body><img src=cid:companylogo/><br></body></html>");
            //  Av1.LinkedResources.Add(logo);
            // MailMessage MAIL = new MailMessage(from, to);

            //email.Attachments.Add(new Attachment(flupld.PostedFile.InputStream, flupld.FileName));
            email.Subject = "Registration";
            email.IsBodyHtml = true;

            email.Body = "<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><B>Registration ID : </B>" + Session["RegID"].ToString() + "<br><b>Sub : </b>" + txtSub.Text + "<br><br><b>Quiry : </b>" + txtQuiry.Text + "</font>";
            string FileName1 = "";
            SmtpClient mailclient = new SmtpClient();
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("info@epilpa.org", "BYJ^$#@3");
            mailclient.Host = "smtp.epilpa.org";
            mailclient.Port = 25;
            mailclient.Timeout = 100000;

            mailclient.UseDefaultCredentials = false;
            mailclient.Credentials = basicAuthenticationInfo;
            ErrMsg1 = string.Empty;

            try
            {
                mailclient.Send(email);
                //return 1;
            }
            catch (Exception ex)
            {
                ErrMsg1 = ex.Message;
                //return 0;
            }


        
    }

   
   
   
}
