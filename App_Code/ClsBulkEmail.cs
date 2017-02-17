using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using AjaxControlToolkit;
using System.IO;

using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ClsBulkEmail
/// </summary>
public class ClsBulkEmail
{
    DBConnection cn;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;
    SqlDataAdapter da;
    public string Action { get; set; }
    public string StartAlpha { get; set; }
    

    public DataSet Mail()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            ds = new DataSet();
            cmd.CommandText = "Bulk_Email";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@StartAlpha", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, StartAlpha));
            cmd.Connection = cn.con;
            da.Fill(ds);
            return ds;

            //return value;

        }

        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            cn.close();
        }
    }
    public int sendEmailforBulkemail(string subject, string body, string to, string from, string image, out string ErrMsg)
    {

        MailMessage email = new MailMessage(from, to);

        if (HttpContext.Current.Session["Bulkemail"] != null)
            email.Attachments.Add(new Attachment(HttpContext.Current.Session["Bulkemail"].ToString()));

        if (HttpContext.Current.Session["Bulkemail1"] != null)
            email.Attachments.Add(new Attachment(HttpContext.Current.Session["Bulkemail1"].ToString()));

        if (HttpContext.Current.Session["Bulkemail2"] != null)
            email.Attachments.Add(new Attachment(HttpContext.Current.Session["Bulkemail2"].ToString()));

        if (HttpContext.Current.Session["Bulkemail3"] != null)
            email.Attachments.Add(new Attachment(HttpContext.Current.Session["Bulkemail3"].ToString()));

        if (HttpContext.Current.Session["Bulkemail4"] != null)
            email.Attachments.Add(new Attachment(HttpContext.Current.Session["Bulkemail4"].ToString()));
        //email.Attachments.Add(new Attachment(flupld.PostedFile.InputStream, flupld.FileName));

        email.Subject = subject;
        email.IsBodyHtml = true;
        email.Body = body;
        string FileName = "";
        if (image.ToString() != "")
        {
            FileName = Path.GetFileName(image);
            Attachment attach1 = new Attachment(HttpContext.Current.Server.MapPath(image));
            /* Attach the newly created email attachment */

            email.Attachments.Add(attach1);
        }
        else
        {
        }
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
            return 1;
        }
        catch (Exception ex)
        {
            ErrMsg = ex.Message;
            return 0;
        }
    }

}