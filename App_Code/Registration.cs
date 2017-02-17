using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
//using Dataobj;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Registration
/// </summary>
public class Registration
{

    DBConnection cn;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;
    SqlDataAdapter da;
    public int UserID { get; set; }
    public string UName { get; set; }
    public string UAddress { get; set; }
    public string UEmailID { get; set; }
    public string UserType { get; set; }
    //   public DateTime? EntryDate { get; set; }
    public string Sex { get; set; }
    public string Company { get; set; }
    public string OAddress { get; set; }
    public string YearOfStart { get; set; }
    public string NatureOfActivity { get; set; }
    public string PhoneOffice { get; set; }
    public string Fax { get; set; }
    public string Residence { get; set; }
    public string Mobile { get; set; }
    public string AdFeeRs { get; set; }
    public string MeFeeRs { get; set; }
    public string AcYear { get; set; }
    public string Action { get; set; }
    public byte[] PhotoData { get; set; }
    public string PhotoName { get; set; }
    public string PhotoType { get; set; }
    public byte[] PhotoData1 { get; set; }
    public string PhotoName1 { get; set; }
    public string PhotoType1 { get; set; }
    public string CBankBranch { get; set; }
    public string CBankName { get; set; }
    public string CPaymentType { get; set; }
    public string CCHqueAmount { get; set; }
    public DateTime? CChqueDate { get; set; }
    public string CChqueNo { get; set; }
    public int SrNo { get; set; }


    //
    // TODO: Add constructor logic here
    public DataTable Registration1()
    {

        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            dt = new DataTable();
            cmd.CommandText = "Action_Registration";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@UName", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UName));
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@UAddress", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UAddress));
            cmd.Parameters.Add(new SqlParameter("@UEmailID", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UEmailID));
            cmd.Parameters.Add(new SqlParameter("@UserType", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserType));
            //   cmd.Parameters.Add(new SqlParameter("@EntryDate", SqlDbType.DateTime, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, EntryDate));
            cmd.Parameters.Add(new SqlParameter("@Sex", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Sex));
            cmd.Parameters.Add(new SqlParameter("@Company", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Company));
            cmd.Parameters.Add(new SqlParameter("@OAddress", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, OAddress));
            cmd.Parameters.Add(new SqlParameter("@YearOfStart", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, YearOfStart));
            cmd.Parameters.Add(new SqlParameter("@NatureOfActivity", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, NatureOfActivity));
            cmd.Parameters.Add(new SqlParameter("@PhoneOffice", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, PhoneOffice));
            cmd.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Fax));
            cmd.Parameters.Add(new SqlParameter("@Mobile", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Mobile));
            cmd.Parameters.Add(new SqlParameter("@AdFeeRs", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AdFeeRs));
            cmd.Parameters.Add(new SqlParameter("@MeFeeRs", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, MeFeeRs));
            cmd.Parameters.Add(new SqlParameter("@AcYear", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AcYear));
            cmd.Parameters.Add(new SqlParameter("@Residence", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Residence));
            cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserID));
            cmd.Parameters.Add(new SqlParameter("@PhotoData", SqlDbType.Binary, 5000000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, PhotoData));
            cmd.Parameters.Add(new SqlParameter("@PhotoName", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, PhotoName));
            cmd.Parameters.Add(new SqlParameter("@PhotoType", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, PhotoType));
            cmd.Parameters.Add(new SqlParameter("@PhotoData1", SqlDbType.Binary, 5000000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, PhotoData1));
            cmd.Parameters.Add(new SqlParameter("@PhotoName1", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, PhotoName1));
            cmd.Parameters.Add(new SqlParameter("@PhotoType1", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, PhotoType1));
            cmd.Parameters.Add(new SqlParameter("@CBankName", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, CBankName));
            cmd.Parameters.Add(new SqlParameter("@CBankBranch", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, CBankBranch));
            cmd.Parameters.Add(new SqlParameter("@CChqueNo", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, CChqueNo));
            cmd.Parameters.Add(new SqlParameter("@CChqueDate", SqlDbType.DateTime, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, CChqueDate));
            cmd.Parameters.Add(new SqlParameter("@CCHqueAmount", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, CCHqueAmount));
            cmd.Parameters.Add(new SqlParameter("@CPaymentType", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, CPaymentType));
            cmd.Parameters.Add(new SqlParameter("@SrNo", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SrNo));

            cmd.Connection = cn.con;
            da.Fill(dt);
            return dt;

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
    public void sendmail(string mTo, string mFrom, string Pws, string mSubject, string mMsg)
    {
        MailMessage Email = new MailMessage(mFrom, mTo + "," + mFrom);

        // Set Mail subject and body text
        Email.Subject = mSubject;
        Email.Body = mMsg;
        Email.IsBodyHtml = true;
        // Create SmtpClient object
        SmtpClient mailClient = new SmtpClient();

        // Create object to store authentication username and password
        System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(mFrom, Pws);

        // Set mail server address
        mailClient.Host = "smtp1.mail.pw";

        // Do not use default security credentials
        mailClient.UseDefaultCredentials = false;

        // Do use those specified above
        mailClient.Credentials = basicAuthenticationInfo;

        // Send e-mail
        // mailClient.Send(Email);
    }
    //
}
