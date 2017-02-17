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
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Globalization;


public partial class Admin_Manage_Members : System.Web.UI.Page
{
    clsmanagemeb members = new clsmanagemeb();
    BusinessObject Library = new BusinessObject();
    DataTable objdt = new DataTable();
    ClsStandard objStd = new ClsStandard();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_ID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        // pnlEmode.Visible = false;
        FillGrid();
        dtRegFrom.Attributes.Add("readonly", "readonly");
        dtRegTo.Attributes.Add("readonly", "readonly");


    }

    private void FillGrid()
    {
        try
        {
            objdt = new DataTable();
            members = new clsmanagemeb();
            members.Action = "Fetch";
            objdt = members.FetchGrid();
            if (objdt.Rows.Count > 0)
            {
                GVMembers.DataSource = objdt;
                GVMembers.DataBind();
            }
            else
            {
                GVMembers.DataSource = null;
                GVMembers.DataBind();
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
        ShowMessageCredit();
        //GVMembers.DataSource = Library.getDataset("Select * from M_User Order by UserID desc");
        //GVMembers.DataBind();

    }

    public void ShowMessageCredit()
    {
        lblCredit.Text = objStd.MessageCredit();
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //string sql = "Update M_User set UEmailID='" + lblEmailID.Text + "', PhoneOffice='" + lblPhoneOffice.Text + "', 
        //Fax='" + lblFax.Text + "', Residence='" + lblResidence.Text + "', Mobile='" + lblMobile.Text + "',
        //Active='" + ddlActive.SelectedValue.ToString() + "', RegDate='" + dtRegFrom.CalendarDate.ToString() + "',ExpDate='" + dtRegTo.CalendarDate.ToString() + "' Where UserID=" + GVMembers.SelectedDataKey.Value;
        //Library.execNonQueryB(sql);

        string mMailServer;
        objdt = new DataTable();
        members = new clsmanagemeb();
        members.Action = "Update";
        members.Active = ddlActive.SelectedValue.ToString();
        members.RegDate = Convert.ToDateTime(dtRegFrom.Text.ToString());
        members.ExpDate = Convert.ToDateTime(dtRegTo.Text.ToString());
        //members.UserID = Convert.ToInt32(GVMembers.SelectedDataKey.Value);
        members.UserID = Convert.ToInt32(lblMemberID.Text);
        members.Company = lblCompany.Text;
        members.OAddress = lblOAddress.Text;
        members.PhoneOffice = lblPhoneOffice.Text;
        members.Residence = lblResidence.Text;
        members.UName = lblMemberName.Text;
        members.UserType = lblMemberType.SelectedValue;
        members.UAddress = lblAddress.Text;
        members.NatureOfActivity = lblNatureOfActivity.Text;
        members.YearOfStart = lblYearOfStart.Text;
        members.Premium_Member = RBLpremium.SelectedValue;
        members.Mobile = lblMobile.Text;
        members.UEmailID = lblEmailID.Text;

        objdt = members.FetchGrid();
        if (objdt.Rows[0][0].ToString() == "1")
        {
            Response.Write("<script>alert('Data Update SucessFully...!!!!');</script>");
            pnlEmode.Visible = false;

        }
        //string mMailServer;

        //***************************************
        //string mTo;
        //string mFrom;
        //string mMsg;
        //string mSubject;
        ////************************************
        //int mPort;
        //// ************************************
        //mTo = GVMembers.Rows[GVMembers.SelectedIndex].Cells[2].Text;
        //mFrom = "info@newtechinfosoft.com";
        //mSubject = "Registration information of www.epilpa.org";
        //mMsg = "<font size='2' face='verdana, arial, helvetica, sans-serif'><b>hello customer,</b><br><br><br>Your registration date is From :<b>" + dtRegFrom.CalendarDate.ToString() + "</b> To :<b>" + dtRegTo.CalendarDate.ToString() + "</b><br><br><b>from,<br>www.epilpa.org<br>(team)</b></font>";
        ////************************************
        //mMailServer = "mail.newtechinfosoft.com";
        //mPort = 25;

        //MailMessage message = new MailMessage(mFrom, mTo, mSubject, mMsg);
        //MailAddress maddress = new MailAddress(mFrom, "Admin- epilpa.org");
        //message.From = maddress;
        //SmtpClient mySmtpClient = new SmtpClient(mMailServer, mPort);
        //mySmtpClient.UseDefaultCredentials = true;
        //message.IsBodyHtml = true;
        //// mySmtpClient.Send(message);
        //// ************************************
        //Library.sendmail(mTo, mFrom, "BYJ^$#@3", mSubject, mMsg);
        // ************************************


        if (ddlActive.SelectedValue == "Yes")
        {


            //string subject;
            //string body;
            //string to = lblEmailID.Text;
            //string from = "info@epilpa.org";
            //string image;
            //string ErrMsg;
            ////int RegID = Convert.ToInt32(txtsrno.Text.Trim());
            //MailMessage email = new MailMessage(from, to);


            ////email.Attachments.Add(new Attachment(flupld.PostedFile.InputStream, flupld.FileName));

            //email.Subject = "Registration";
            //email.IsBodyHtml = true;
            //// email.Body = "<font size='2' face='Verdana, Arial, Helvetica, sans-serif'><b>Hello Customer,</b><br><br><br>Thank you for registration on our website www.epilpa.org<BR><BR> Your RegistrationID is :" + (RegID) + "<BR><BR> It takes some time to acivate your Account. <BR><BR> You will be updated through E-Mail<BR><br><b>From,<br>www.epilpa.org<BR>(Team)</b></font>";
            //email.Body = "<font size='2' face='verdana, arial, helvetica, sans-serif'><b> Dear " + lblMemberName.Text + ",</b><br><br><br>We are glad to inform you that your registration details are verified and login is activated" + Environment.NewLine + "Your accounts details are as following. </b><br><br> Membership No.:" + lblMemberID.Text + Environment.NewLine + "</br>, Member ship Type : " + lblMemberType.SelectedValue + Environment.NewLine + " </b> , Password : " + lblEmailID.Text + Environment.NewLine + " </br>, Membership Expiry Date : " + Convert.ToDateTime(dtRegFrom.Text.ToString()) + Environment.NewLine + "Regards </br> Epilpa Team.";



            ////  string FileName = "";
            ////if (image.ToString() != "")
            ////{
            ////    FileName = Path.GetFileName(image);
            ////    Attachment attach1 = new Attachment(HttpContext.Current.Server.MapPath(image));
            ////    /* Attach the newly created email attachment */

            ////    email.Attachments.Add(attach1);
            ////}
            ////else
            ////{
            ////}
            //SmtpClient mailclient = new SmtpClient();
            //System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential("info@epilpa.org", "BYJ^$#@3");
            //mailclient.Host = "smtp.epilpa.org";
            //mailclient.Port = 25;
            //mailclient.Timeout = 100000;

            //mailclient.UseDefaultCredentials = false;
            //mailclient.Credentials = basicAuthenticationInfo;
            //ErrMsg = string.Empty;

            //try
            //{
            //    mailclient.Send(email);
            //    //return 1;
            //}
            //catch (Exception ex)
            //{
            //    ErrMsg = ex.Message;
            //    //return 0;
            //}



            //FillGrid();
            ////int Count = 0;
            ////int messageCount = 0;
            //////  string Student = "";
            ////string MobileNO = "";
            ////string FinalMessage = "";
            ////if (lblCredit.Text != "")
            ////{
            ////    string[] NoofMessage = lblCredit.Text.Split(':');
            ////    messageCount = Convert.ToInt32(NoofMessage[1].ToString());
            ////}
            ////if (messageCount >= Count)
            ////{

            ////    FinalMessage = FinalMessage + " Branch Students are informed to attend their classes regularly otherwise action will be taken as per GTU norms.";

            ////    // FinalMessage = FinalMessage + " Your details are registered successfully. Membership id:" +txtid.Text+ "Login will be activated after approval from admin. Regards EPILPA TEAM ";



            ////    /*For Multiple Number */
            ////    MobileNO = lblMobile.Text;

            ////    //string ret = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<URLsmsSendsms>\r\n  <SMSAuthentication>\r\n    <UserID>modasa_engg@yahoo.co.in</UserID>\r\n    <Password>modasa009</Password>\r\n  </SMSAuthentication>\r\n  <StartSMSSend>\r\n    <SenderID Text=\"GECMOD\">\r\n      [Message]\r\n    </SenderID>\r\n  </StartSMSSend>\r\n</URLsmsSendsms>";
            ////    string ret = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<URLsmsSendsms>\r\n  <SMSAuthentication>\r\n    <UserID>reubs2@rediffmail.com</UserID>\r\n    <Password>Newtech009</Password>\r\n  </SMSAuthentication>\r\n  <StartSMSSend>\r\n    <SenderID Text=\"REUBSS\">\r\n      [Message]\r\n    </SenderID>\r\n  </StartSMSSend>\r\n</URLsmsSendsms>";

            ////    string str1 = "<SendSMS>\r\n        <SMStext>";
            ////    string str2 = "</SMStext>\r\n        <Recipients>";
            ////    string str3 = "</Recipients>\r\n      </SendSMS>";
            ////    string str4 = "";

            ////    str4 = str4 + str1 + FinalMessage + str2 + MobileNO + str3 + "\r\n";

            ////    /**********************/
            ////    ret = ret.Replace("[Message]", str4);
            ////    DataSet ds = new DataSet();
            ////    ds = objStd.SendSMSViaXML(ret);
            ////    /**********************/

            ////}

            //int Count = 0;
            //int messageCount = 0;
            ////  string Student = "";
            //string MobileNO = "";
            //string FinalMessage = "";

            //if (lblCredit.Text != "")
            //{
            //    string[] NoofMessage = lblCredit.Text.Split(':');
            //    messageCount = Convert.ToInt32(NoofMessage[1].ToString());
            //}
            //if (messageCount >= Count)
            //{
            //    //SMS.Action = "I";
            //    //SMS.Student_Id = txtsrno.Text;
            //    //Objdt = SMS.Insert_Exam_Fee_SMS();

            //    FinalMessage = FinalMessage + "Your account login is activated." + Environment.NewLine + "Membership Id: " + lblMemberID.Text + "" + Environment.NewLine + "Membership Type: " + lblMemberType.SelectedValue + Environment.NewLine + "Regards" + Environment.NewLine + "EPILPA TEAM";



            //    // FinalMessage = FinalMessage + " Your details are registered successfully. Membership id:" +txtid.Text+ "Login will be activated after approval from admin. Regards EPILPA TEAM ";



            //    /*For Multiple Number */
            //    MobileNO = lblMobile.Text;

            //    //string ret = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<URLsmsSendsms>\r\n  <SMSAuthentication>\r\n    <UserID>modasa_engg@yahoo.co.in</UserID>\r\n    <Password>modasa009</Password>\r\n  </SMSAuthentication>\r\n  <StartSMSSend>\r\n    <SenderID Text=\"GECMOD\">\r\n      [Message]\r\n    </SenderID>\r\n  </StartSMSSend>\r\n</URLsmsSendsms>";
            //    string ret = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<URLsmsSendsms>\r\n  <SMSAuthentication>\r\n    <UserID>info@epilpa.org</UserID>\r\n    <Password>epilpa009</Password>\r\n  </SMSAuthentication>\r\n  <StartSMSSend>\r\n    <SenderID Text=\"EPILPA\">\r\n      [Message]\r\n    </SenderID>\r\n  </StartSMSSend>\r\n</URLsmsSendsms>";

            //    string str1 = "<SendSMS>\r\n        <SMStext>";
            //    string str2 = "</SMStext>\r\n        <Recipients>";
            //    string str3 = "</Recipients>\r\n      </SendSMS>";
            //    string str4 = "";

            //    str4 = str4 + str1 + FinalMessage + str2 + MobileNO + str3 + "\r\n";

            //    /**********************/
            //    ret = ret.Replace("[Message]", str4);
            //    DataSet ds = new DataSet();
            //    ds = objStd.SendSMSViaXML(ret);
            //    /**********************/
            //}
        }


    }


    protected void btnCancle_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Manage_Members.aspx");
    }

    protected void GVMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            DataTable dt = new DataTable();
            members = new clsmanagemeb();
            members.UserID = Convert.ToInt32(GVMembers.SelectedDataKey.Value);
            members.Action = "Byid";
            dt = members.FetchGrid();
            byte[] img = null;
            if (dt.Rows.Count > 0)
            {

                pnlEmode.Visible = true;
                Session["UserID"] = Convert.ToInt32(GVMembers.SelectedDataKey.Value);
                lblMemberID.Text = dt.Rows[0]["UserID"].ToString();
                lblMemberName.Text = dt.Rows[0]["UName"].ToString();
                lblAddress.Text = dt.Rows[0]["UAddress"].ToString();
                lblEmailID.Text = dt.Rows[0]["UEmailID"].ToString();
                lblMemberType.SelectedValue = dt.Rows[0]["UserType"].ToString();
                if (lblMemberType.SelectedValue == "Life Membership")
                {
                    trexpdate.Visible = false;
                }
                lblSr.Text = dt.Rows[0]["SrNo"].ToString();
                //lblBankName.Text = dt.Rows[0]["BankName"].ToString();
                //lblChequeNo.Text = dt.Rows[0]["ChequeNo"].ToString();
                //lblPayment.Text = dt.Rows[0]["PaymentType"].ToString();
                if (dt.Rows[0]["RegDate"].ToString() != "")
                {
                    string dtRegFrom1 = "";
                    dtRegFrom1 = dt.Rows[0]["RegDate"].ToString();
                    dtRegFrom.Text = Convert.ToDateTime(dtRegFrom1, CultureInfo.CurrentCulture).ToString("MM dd yyyy");

                    //  dtRegFrom.Text = dt.Rows[0]["RegDate"].ToString();
                }
                else
                {
                    string dtRegFrom1 = "";
                    dtRegFrom1 = dt.Rows[0]["RegDate"].ToString();
                    dtRegFrom.Text = Convert.ToDateTime(DateTime.Now, CultureInfo.CurrentCulture).ToString("MM dd yyyy");
                    // dtRegFrom.Text = System.DateTime.Now.ToString();
                }
                Button1_Click1(null, null);
                if (dt.Rows[0]["ExpDate"].ToString() != "")
                {
                    string dtRegTo1 = "";
                    dtRegTo1 = dt.Rows[0]["ExpDate"].ToString();
                    dtRegTo.Text = Convert.ToDateTime(dtRegTo1, CultureInfo.CurrentCulture).ToString("MM dd yyyy");
                    if (lblMemberType.SelectedValue == "Life Membership")
                    {
                        trexpdate.Visible = false;
                    }
                    else
                    {
                        trexpdate.Visible = true;
                    }
                }
                else
                {
                    trexpdate.Visible = true;
                }
                ddlSex.SelectedValue = dt.Rows[0]["Sex"].ToString();
                lblCompany.Text = dt.Rows[0]["Company"].ToString();
                lblOAddress.Text = dt.Rows[0]["OAddress"].ToString();
                lblYearOfStart.Text = dt.Rows[0]["YearOfStart"].ToString();
                lblNatureOfActivity.Text = dt.Rows[0]["NatureOfActivity"].ToString();
                lblPhoneOffice.Text = dt.Rows[0]["PhoneOffice"].ToString();
                lblFax.Text = dt.Rows[0]["Fax"].ToString();
                lblResidence.Text = dt.Rows[0]["Residence"].ToString();
                lblMobile.Text = dt.Rows[0]["Mobile"].ToString();
                lblAdFeeRs.Text = dt.Rows[0]["AdFeeRs"].ToString();
                lblMeFeeRs.Text = dt.Rows[0]["MeFeeRs"].ToString();
                lblAcYear.Text = dt.Rows[0]["AcYear"].ToString();
                RBLpremium.SelectedValue = dt.Rows[0]["premium_Member"].ToString();
                //Response.ContentType = dt.Rows[0]["PhotoName"].ToString();
                //Response.BinaryWrite(byte[])dt.Rows[0][""])
                //img = ((byte[])dt.Rows[0]["PhotoData"]);
                //Image2.ImageUrl = img.ToString();
                // Byte[] fileData = (Byte[])Session["FileData"];

                //  byteArrayToImage(( Byte[])dt.Rows[0]["PhotoData"]);
                if (dt.Rows[0]["PhotoData"].ToString() != "")
                {
                    byte[] bytes = (byte[])dt.Rows[0]["PhotoData"];
                    string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                    Image2.ImageUrl = "data:image/png;base64," + base64String;
                }
                if (dt.Rows[0]["PhotoData1"].ToString() != "")
                {

                    byte[] bytes1 = (byte[])dt.Rows[0]["PhotoData1"];
                    string base64String1 = Convert.ToBase64String(bytes1, 0, bytes1.Length);
                    Image1.ImageUrl = "data:image/png;base64," + base64String1;
                }

                ddlActive.SelectedValue = dt.Rows[0]["Active"].ToString();
                string regFrom, regTo;
                regFrom = dt.Rows[0]["RegDate"].ToString();
                regTo = dt.Rows[0]["ExpDate"].ToString();
                //if (regFrom != "")
                //{
                //    dtRegFrom.CalendarDate = Convert.ToDateTime(regFrom);
                //}
                //else
                //{
                //    dtRegFrom.CalendarDate = System.DateTime.Now.Date;
                //}

                //if (regTo != "")
                //{
                //    dtRegTo.CalendarDate = Convert.ToDateTime(regTo);
                //}
                //else
                //{
                //    //dtRegTo.CalendarDate = Convert.ToDateTime("31/03/2010");
                //    dtRegTo.CalendarDateString = "31.03.2010";
                //    //dtRegTo.CalendarDate = System.DateTime.Now.Date.AddYears(1);
                //}
            }
        }
        catch (Exception)
        {

            throw;
        }
        //string sql = "Select * from M_User Where UserID=" + GVMembers.SelectedDataKey.Value;
        //DataTable dt = Library.getDataset(sql).Tables[0];




    }

    protected void GVMembers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "Kdelete")
        {
            DataTable dt = new DataTable();
            members = new clsmanagemeb();
            members.UserID = Convert.ToInt32(e.CommandArgument);
            members.Action = "Delete";
            dt = members.FetchGrid();
            // Library.execNonQueryB(sql);
            FillGrid();
        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void Exportexcel_Click(object sender, ImageClickEventArgs e)
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Customers.xls"));
        Response.ContentType = "application/ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        GVMembers.AllowPaging = false;
        GVMembers.DataBind();
        //Change the Header Row back to white color
        GVMembers.HeaderRow.Style.Add("background-color", "#FFFFFF");
        //Applying stlye to gridview header cells
        for (int i = 0; i < GVMembers.HeaderRow.Cells.Count; i++)
        {
            GVMembers.HeaderRow.Cells[i].Style.Add("background-color", "#507CD1");
        }
        int j = 1;
        //This loop is used to apply stlye to cells based on particular row
        foreach (GridViewRow gvrow in GVMembers.Rows)
        {
            gvrow.BackColor = Color.White;
            if (j <= GVMembers.Rows.Count)
            {
                if (j % 2 != 0)
                {
                    for (int k = 0; k < gvrow.Cells.Count; k++)
                    {
                        gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                    }
                }
            }
            j++;
        }
        GVMembers.RenderControl(htw);
        Response.Write(sw.ToString());
        Response.End();
    }

    public void byteArrayToImage(byte[] byteArrayIn)
    {
        System.Drawing.Image newImage;

        //string strFileName = GetTempFolderName() + strFile_Name;

        using (MemoryStream stream = new MemoryStream(byteArrayIn))
        {
            newImage = System.Drawing.Image.FromStream(stream);
            //newImage.Save(strFileName);
            Image2.Attributes.Add("src", "");
            Page_Load(null, null);
        }
    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            if (Validation1() == 1)
            {
                members = new clsmanagemeb();
                objdt = new DataTable();
                members.Action = "ExpDateChk";
                members.UserID = Convert.ToInt32(Session["UserID"]);
                string dtRegTo2 = "";
                dtRegTo2 = Convert.ToDateTime(dtRegFrom.Text, CultureInfo.CurrentCulture).ToString("MM dd yyyy");
                members.RegDate = Convert.ToDateTime(dtRegTo2);
                objdt = members.FetchGrid();
                if (objdt.Rows.Count > 0)
                {
                    if (objdt.Rows[0]["UserType"].ToString() != "Life Membership")
                    {
                        string dtRegTo1 = "";
                        dtRegTo1 = objdt.Rows[0]["ExpDate"].ToString();
                        dtRegTo.Text = Convert.ToDateTime(dtRegTo1, CultureInfo.CurrentCulture).ToString("MM dd yyyy");
                        //dtRegTo.Text = objdt.Rows[0]["ExpDate"].ToString();
                        //   trexpdate.Visible = true;
                        // pnlEmode.Visible = true;
                        dtRegTo.Focus();
                    }
                }
                else
                {
                    trexpdate.Visible = false;
                    //  pnlEmode.Visible = true;
                    // Response.Write("<script>alert('There Is No Expeiry Date For Life Members...!!!!');</script>");


                }

            }

        }
        catch (Exception)
        {

            throw;
        }
    }

    public int Validation1()
    {
        if (dtRegFrom.Text.ToString() == "")
        {
            Response.Write("<script>alert('Please Fill First Reg Date...!!!!');</script>");
            return 0;
        }
        return 1;
    }


    protected void ddlActive_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GVMembers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label Lableid = (Label)e.Row.FindControl("Lableid");
            if (objdt.Rows.Count > 0)
            {
                for (int i = 0; i <= GVMembers.Rows.Count; i++)
                {
                    if (objdt.Rows[i]["Active"].ToString() == "Yes")
                    {
                        Lableid.ForeColor = System.Drawing.Color.YellowGreen;
                    }
                    else
                    {
                        Lableid.ForeColor = System.Drawing.Color.Red;

                    }
                }
            }
        }
    }
}
