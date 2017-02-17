using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


public partial class FRegistration : System.Web.UI.Page
{
    Registration clsreg = new Registration();
    DataTable objdt = new DataTable();
    DataTable Objdt = new DataTable();
    DataSet objds = new DataSet();
    ClsStandard objStd = new ClsStandard();
    clsSMS SMS = new clsSMS();
    HttpPostedFile postFile;
    static string strFile_Name;

    static byte[] bt;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblMess.Text = "";
        txtsrno.Enabled = true;
        if (!IsPostBack)
        {
            if (Upload1.HasFile || (hdnPhotoName.Value != "" && hdnPhotoData.Value != ""))
            {
                if (Upload1.HasFile)
                {
                    string filename = Upload1.FileName;
                    string ext = Path.GetExtension(filename);


                    Stream fs = Upload1.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    string Final = "data:image/png;base64," + base64String;

                    hdnPhotoName.Value = filename;
                    hdnPhotoData.Value = Final;
                    hdnPhotoType.Value = ext;

                    Image1.ImageUrl = Final;
                }
                else
                {
                    if (hdnPhotoName.Value != "" && hdnPhotoData.Value != "")
                    {
                        Image1.ImageUrl = hdnPhotoData.Value;

                    }
                }
            }
            if (Upload2.HasFile || (hdnIdname.Value != "" && HdnIdData.Value != ""))
            {
                if (Upload2.HasFile)
                {
                    string filename = Upload2.FileName;
                    string ext = Path.GetExtension(filename);


                    Stream fs = Upload2.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    string Final = "data:image/png;base64," + base64String;

                    hdnIdname.Value = filename;
                    HdnIdData.Value = Final;
                    hdnIdType.Value = ext;

                    Image2.ImageUrl = Final;
                }
                else
                {
                    if (hdnIdname.Value != "" && HdnIdData.Value != "")
                    {
                        Image2.ImageUrl = HdnIdData.Value;

                    }
                }
            }
            ShowMessageCredit();
            SrNobind();            
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            if (validation() == 1)
            {
                clsreg = new Registration();
                objdt = new DataTable();
                objds = new DataSet();
                clsreg.UserID = Convert.ToInt32(txtid.Text);
                clsreg.UserType = ddlMemberType.SelectedValue;
                clsreg.YearOfStart = txtYearOfStart.Text;
                clsreg.UAddress = txtAddress.Text;
                clsreg.Sex = ddlSex.SelectedValue;
                clsreg.Residence = txtResidence.Text;
                //  clsreg.AcYear = txtAcYear.Text;
                //  clsreg.AdFeeRs = txtAdFeeRs.Text;
                clsreg.Company = txtCompany.Text;
                clsreg.Fax = txtFax.Text;
                //  clsreg.MeFeeRs = txtMeFeeRs.Text;
                clsreg.Mobile = txtMobile.Text;
                clsreg.NatureOfActivity = txtNatureOfActivity.Text;
                clsreg.OAddress = txtOAddress.Text;
                clsreg.PhoneOffice = txtPhoneOffice.Text;
                clsreg.UName = txtMemberName.Text;
                clsreg.UEmailID = txtEmailID.Text;
                clsreg.CBankBranch = txtbankbranch.Text;
                clsreg.CBankName = txtbank.Text;
                clsreg.CCHqueAmount = txtcqAmount.Text;
                clsreg.SrNo = Convert.ToInt32(txtsrno.Text);
                if (txtCqdate.Text != "")
                {
                    clsreg.CChqueDate = Convert.ToDateTime(txtCqdate.Text);
                }
                clsreg.CChqueNo = txtcqnumber.Text;
                if (Upload1.HasFile || (hdnPhotoName.Value != "" && hdnPhotoData.Value != ""))
                {
                    if (Upload1.HasFile)
                    {
                        string filename = Upload1.FileName;
                        string ext = Path.GetExtension(filename);


                        #region imageconvert
                        Stream fs = Upload1.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        clsreg.PhotoData = bytes;
                        #endregion

                        #region imageconvert
                        Stream fs1 = Upload2.PostedFile.InputStream;
                        BinaryReader br1 = new BinaryReader(fs1);
                        Byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);
                        clsreg.PhotoData1 = bytes1;
                        #endregion
                        //Stream fs = Upload1.PostedFile.InputStream;
                        //BinaryReader br = new BinaryReader(fs);
                        //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        //string Final = "data:image/png;base64," + base64String;
                        //postFile = this.Upload1.PostedFile;
                        //bt = ReadImageFile(postFile.FileName, new string[] { ".GIF", ".gif", ".jpg", ".bmp" });
                        hdnPhotoName.Value = filename;
                        //clsreg.PhotoData =bytes[0];
                        hdnPhotoType.Value = ext;
                        //Image1.ImageUrl = Final;
                    }
                    else
                    {
                        if (hdnPhotoName.Value != "" && hdnPhotoData.Value != "")
                        {
                            Image1.ImageUrl = hdnPhotoData.Value;
                        }
                    }


                    clsreg.PhotoName = hdnPhotoName.Value;
                    // clsreg.PhotoData = ;

                }

                //if (Upload2.HasFile || (hdnIdname.Value != "" && HdnIdData.Value != ""))
                //{
                //    if (Upload2.HasFile)
                //    {
                //        string filename = Upload2.FileName;
                //        string ext = Path.GetExtension(filename);


                //        Stream fs = Upload2.PostedFile.InputStream;+
                //        BinaryReader br = new BinaryReader(fs);
                //        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                //        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                //        string Final = "data:image/png;base64,"  base64String;

                //        hdnIdname.Value = filename;
                //        HdnIdData.Value = Final;
                //        hdnIdType.Value = ext;

                //        Image2.ImageUrl = Final;
                //    }
                //    else
                //    {
                //        if (hdnIdname.Value != "" && HdnIdData.Value != "")
                //        {
                //            Image2.ImageUrl = HdnIdData.Value;

                //        }
                //    }
                //}
                clsreg.Action = "InsertReg";
                objdt = clsreg.Registration1();
                if (objdt.Rows[0][0].ToString() == "1")
                {
                    //===================For Members EMAIL ======================
                    //==============================================================

                    string subject;
                    string body;
                    string to = txtEmailID.Text;
                    string from = "info@epilpa.org";

                    string ErrMsg;
                    int RegID = Convert.ToInt32(txtsrno.Text.Trim());
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
                    email.Body = "<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><b>Hello Customer,</b><br><br><br>Thank you for registration on our website www.epilpa.org<BR><BR> Your RegistrationID is :" + (RegID) + "<BR><BR> It takes some time to acivate your Account. <BR><BR> You will be updated through E-Mail<BR><br><b>From,<br>www.epilpa.org<BR>(Team)</b><br><img src=\"cid:images/logo.jpg\"></font>";
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
                    //=====================================================
                    //=====================================================



                    //===========================For Admin EMAIL ======================
                    //==================================================================

                    string subject1;
                    string body1;
                    string to1 = "info@epilpa.org";
                    string from1 = "info@epilpa.org";
                    string image1;
                    string ErrMsg1;
                    int RegID1 = Convert.ToInt32(txtsrno.Text.Trim());
                    MailMessage email1 = new MailMessage(from1, to1);


                    //email.Attachments.Add(new Attachment(flupld.PostedFile.InputStream, flupld.FileName));

                    email1.Subject = "Registration";
                    email1.IsBodyHtml = true;
                    email1.Body = "<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><b>Hello Admin,</b><br><br><br>One new Registration on our website www.epilpa.org<BR><BR>Member RegistrationID is :" + (RegID) + "<BR><BR>  <BR><BR> <BR><br><b>From,<br>www.epilpa.org<BR>(Team)</b></font>";

                    string FileName1 = "";
                    //if (image.ToString() != "")
                    //{
                    //    FileName = Path.GetFileName(image);
                    //    Attachment attach1 = new Attachment(HttpContext.Current.Server.MapPath(image));
                    //    /* Attach the newly created email attachment */

                    //    email.Attachments.Add(attach1);
                    //}
                    //else
                    //{
                    //}
                    SmtpClient mailclient1 = new SmtpClient();
                    System.Net.NetworkCredential basicAuthenticationInfo1 = new System.Net.NetworkCredential("info@epilpa.org", "BYJ^$#@3");
                    mailclient.Host = "smtp.epilpa.org";
                    mailclient.Port = 25;
                    mailclient.Timeout = 100000;

                    mailclient.UseDefaultCredentials = false;
                    mailclient.Credentials = basicAuthenticationInfo;
                    ErrMsg1 = string.Empty;

                    try
                    {
                        mailclient.Send(email1);
                        //return 1;
                    }
                    catch (Exception ex)
                    {
                        ErrMsg1 = ex.Message;
                        //return 0;
                    }


                    //===================SMS============================================
                    //===================================================================


                    int Count = 0;
                    int messageCount = 0;
                    //  string Student = "";
                    string MobileNO = "";
                    string FinalMessage = "";

                    if (lblCredit.Text != "")
                    {
                        string[] NoofMessage = lblCredit.Text.Split(':');
                        if (NoofMessage[1].ToString() != "")
                        {
                            messageCount = Convert.ToInt32(NoofMessage[1].ToString());
                        }
                    }
                    if (messageCount >= Count)
                    {
                        SMS.Action = "I";
                        SMS.Student_Id = txtsrno.Text;
                        Objdt = SMS.Insert_Exam_Fee_SMS();

                        FinalMessage = FinalMessage + "Your details are registered successfully." + Environment.NewLine + "Registration id: " + txtsrno.Text + "" + Environment.NewLine + "Login will be activated after approval" + Environment.NewLine + "from admin." + Environment.NewLine + "Regards" + Environment.NewLine + "EPILPA TEAM";

                        // FinalMessage = FinalMessage + " Your details are registered successfully. Membership id:" +txtid.Text+ "Login will be activated after approval from admin. Regards EPILPA TEAM ";



                        /*For Multiple Number */
                        MobileNO = txtMobile.Text;

                        //string ret = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<URLsmsSendsms>\r\n  <SMSAuthentication>\r\n    <UserID>modasa_engg@yahoo.co.in</UserID>\r\n    <Password>modasa009</Password>\r\n  </SMSAuthentication>\r\n  <StartSMSSend>\r\n    <SenderID Text=\"GECMOD\">\r\n      [Message]\r\n    </SenderID>\r\n  </StartSMSSend>\r\n</URLsmsSendsms>";
                        string ret = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<URLsmsSendsms>\r\n  <SMSAuthentication>\r\n    <UserID>info@epilpa.org</UserID>\r\n    <Password>epilpa009</Password>\r\n  </SMSAuthentication>\r\n  <StartSMSSend>\r\n    <SenderID Text=\"EPILPA\">\r\n      [Message]\r\n    </SenderID>\r\n  </StartSMSSend>\r\n</URLsmsSendsms>";

                        string str1 = "<SendSMS>\r\n        <SMStext>";
                        string str2 = "</SMStext>\r\n        <Recipients>";
                        string str3 = "</Recipients>\r\n      </SendSMS>";
                        string str4 = "";

                        str4 = str4 + str1 + FinalMessage + str2 + MobileNO + str3 + "\r\n";

                        /**********************/
                        ret = ret.Replace("[Message]", str4);
                        DataSet ds = new DataSet();
                        ds = objStd.SendSMSViaXML(ret);
                        /**********************/






                        //    //=====================================================================
                        //    //=====================================================================


                    }

                    //  Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('This E-mail or UserId is Already Exists...!!!!');</script>");

                }
                Response.Write("<script>alert('Thanks For Registration...!!!!');</script>");
                Clear();


            }
        }




        //else
        //{
        //    lblMess.Text = "You are already registered with us with this E-Mail ID";
        //}
        catch (Exception ex)
        {

            throw ex;
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

    public void ShowMessageCredit()
    {
        lblCredit.Text = objStd.MessageCredit();
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("FRegistration.aspx");

    }

    public int validation()
    {
        //if (txtid.Text == "")
        //{
        //    lblMess.Text = "Please Fill Id";
        //    return 0;

        //}
        if (txtMemberName.Text == "")
        {
            lblMess.Text = "Please Fill Name";
            return 0;

        }
        if (txtEmailID.Text == "")
        {
            lblMess.Text = "Please Fill EMail_id";
            return 0;

        }
        if (txtMobile.Text == "")
        {
            lblMess.Text = "Please Fill Mobile Number";
            return 0;

        }
        //if (Upload1.FileName == "")
        //{
        //    lblMess.Text = "Please Upload Your Photo";
        //    return 0;
        //}
        //if (Upload2.FileName == "")
        //{
        //    lblMess.Text = "Please Upload Your Photo ID";
        //    return 0;
        //}

        return 1;

    }

    public void Clear()
    {
        txtid.Text = "";
        ddlMemberType.SelectedIndex = 0;
        txtYearOfStart.Text = "";
        txtAddress.Text = "";
        ddlSex.SelectedIndex = 0;
        txtResidence.Text = "";
        // txtAdFeeRs.Text = "";
        txtCompany.Text = "";
        txtFax.Text = "";
        // txtMeFeeRs.Text = "";
        txtMobile.Text = "";
        txtNatureOfActivity.Text = "";
        txtOAddress.Text = "";
        txtPhoneOffice.Text = "";
        txtMemberName.Text = "";
        txtEmailID.Text = "";
    }

    public byte[] ReadImageFile(string PostedFileName, string[] filetype)
    {
        bool isAllowedFileType = false;
        try
        {
            FileInfo file = new FileInfo(PostedFileName);

            strFile_Name = file.Name;

            foreach (string strExtensionType in filetype)
            {
                if (strExtensionType == file.Extension)
                {
                    isAllowedFileType = true;
                    break;
                }
            }
            if (isAllowedFileType)
            {
                FileStream fs = new FileStream(PostedFileName, FileMode.Open, FileAccess.Read);

                BinaryReader br = new BinaryReader(fs);

                byte[] image = br.ReadBytes((int)fs.Length);

                br.Close();

                fs.Close();

                return image;
            }
            return null;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void SrNobind()
    {
        try
        {
            clsreg = new Registration();
            objdt = new DataTable();
            clsreg.Action = "SrNo";
            objdt = clsreg.Registration1();
            if (objdt.Rows.Count > 0)
            {
                txtsrno.Text = objdt.Rows[0]["id"].ToString();
                txtid.Text = objdt.Rows[0]["id"].ToString();
                //txtsrno.Enabled = false;
                txtid.Enabled = false;
            }
            else
            {

            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void ddlpaymentMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlpaymentMode.SelectedValue == "Cash")
        {
            divtype.Visible = false;
            trutr.Visible = false;
        }
        else if (ddlpaymentMode.SelectedValue == "RTGS(NEFT)")
        {
            divtype.Visible = false;
            trutr.Visible = true;
        }
        else
        {
            divtype.Visible = true;
            trutr.Visible = false;


        }
    }

    public string imglogo { get; set; }
}