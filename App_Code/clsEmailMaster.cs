using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using AjaxControlToolkit;
using System.IO;

using System.Web.UI;
using System.Web.UI.WebControls;



/// <summary>
/// Summary description for clsEmailMaster
/// </summary>
public class clsEmailMaster
{
    DBConnection objdb;
    SqlCommand objcmd;
    DataTable objdt;
    SqlDataAdapter objda;


    public string SchoolCode { get; set; }
    public string UserCode { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public int id { get; set; }
    public string Action { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    string strFileName;
    public string Attachment { get; set; }
    public DataTable In_UP_Action_Email_Master()
    {
        try
        {

            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "[Action_Email_Master]";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
            objcmd.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Type));
            objcmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Name));
            objcmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Email));
            objcmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Status));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
            objcmd.Connection = objdb.con;
            objda.Fill(objdt);
            return objdt;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            objdb.close();
        }
    }

    public DataTable Get_Email_Master()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "[GetEmailMaster]";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
            objcmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Status));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));

            objcmd.Connection = objdb.con;
            objda.Fill(objdt);
            return objdt;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            objdb.close();
        }
    }


    //******************************************************
    //For BulkMaster

    public DataTable Get_BulkEmail_Master()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "[GetEmailMaster]";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
            objcmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Status));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
            objcmd.Parameters.Add(new SqlParameter("@Type", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Type));
            objcmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Name));
            objcmd.Connection = objdb.con;
            objda.Fill(objdt);
            return objdt;
        }
        catch (Exception ex)
        {

            throw ex;
        }
        finally
        {
            objdb.close();
        }
    }

    public int sendEmailforBulkemail(string subject, string body, string to, string from,string image, out string ErrMsg)
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
        System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("info@newtechinfosoft.com", "niraj2503");
        mailclient.Host = "mail.newtechinfosoft.com";
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