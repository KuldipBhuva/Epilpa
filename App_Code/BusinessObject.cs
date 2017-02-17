using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Net.Mail;
//using Dataobj;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BusinessObject
/// </summary>
/// 
namespace Businessobj
{
    
    public class BusinessObject
    {
        DataObject dataobj = new DataObject();
        SqlCommand cmd = new SqlCommand();
        DataSet ds;
        public static int PageSize;
        public BusinessObject()
        {
            //
            // TODO: Add constructor logic here
            //
            
        }
        public int GetPageSize()
        {
           return PageSize = Convert.ToInt16(ConfigurationManager.AppSettings["PageSize"].ToString());
        }

        //public void FillGrid(GridView gv,string sql)
        //{
        //    cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.Text;
        //    ds = dataobj.getDataset();
        //    gv.DataSource = ds;
        //    gv.DataBind();
        //}
        //public DataTable getSingleValue()
        //{
        //    cmd = new SqlCommand();
        //    return dataobj.getSingleValue();
        //}
        //public DataSet getDataset(string query)
        //{
        //    cmd = new SqlCommand(query);
        //    //cmd.CommandType = CommandType.StoredProcedure;
        //    return dataobj.getDataset(cmd);
        //}

        //public string execNonQueryB(string sql)
        //{

        //    cmd = new SqlCommand(sql);

        //    // set the sql command type
        //    cmd.CommandType = CommandType.Text;

        //    // pass to execute command on sql server
        //    return dataobj.execNonQuery(cmd);
        //}
        //this function for fill up the checkbox list

        public void sendmail(string mTo, string mFrom, string Pws,string mSubject, string mMsg)
        {
            MailMessage Email = new MailMessage(mFrom, mTo + "," + mFrom);

            // Set Mail subject and body text
            Email.Subject = mSubject;
            Email.Body = mMsg;
            Email.IsBodyHtml = true;
            // Create SmtpClient object
            SmtpClient mailClient = new SmtpClient();

            // Create object to store authentication username and password
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(mFrom,Pws);

            // Set mail server address
            mailClient.Host = "smtp1.mail.pw";

            // Do not use default security credentials
            mailClient.UseDefaultCredentials = false;

            // Do use those specified above
            mailClient.Credentials = basicAuthenticationInfo;

            // Send e-mail
           // mailClient.Send(Email);
        }

    }
    

}
