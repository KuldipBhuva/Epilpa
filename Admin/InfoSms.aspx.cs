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

public partial class Admin_InfoSms : System.Web.UI.Page
{
    Admin admin = new Admin();
    ClsStandard objStd = new ClsStandard();
    DataTable objdt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Login_ID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            griduser.Visible = true;
            Gridbind();
            txtDate.Text = System.DateTime.Now.ToShortDateString();
            ShowMessageCredit();
            ddlCat_SelectedIndexChanged(sender, null);

        }
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        if (txtDetails.Text != "")
        {
            txtMessage.Text = "Dear Member," + Environment.NewLine + "This is to inform that" + Environment.NewLine + txtDetails.Text;
        }





    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (txtDetails.Text != "")
            {
                objdt = new DataTable();
                int Count = 0;
                int messageCount = 0;
                string Student = "";
                string MobileNO = "";
                string FinalMessage = "";
                foreach (GridViewRow li in griduser.Rows)
                {
                    Label lblStudentID = (Label)li.FindControl("lblstudent");
                    Label lblMobile = (Label)li.FindControl("lblMobile");
                    CheckBox cb = (CheckBox)li.FindControl("chkStudent");
                    if (objdt.Rows.Count == 0)
                    {
                        if (cb != null && cb.Checked)
                        {
                            Student = Student + lblStudentID.Text + ",";
                            MobileNO = MobileNO + lblMobile.Text + ",";
                            Count = Count + 1;
                        }
                    }
                }

                if (lblCredit.Text != "" || lblCredit.Text != "No Credits Available. Please Buy Credits.")
                {
                    string[] NoofMessage = lblCredit.Text.Split(':');
                    messageCount = Convert.ToInt32(NoofMessage[1].ToString());
                }
                else { ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "test", "alert('Message Credit is not Available');", true); }
                if (messageCount >= Count)
                {
                    //objStd.Std_id = Convert.ToInt32(DropDownListStandard.SelectedValue);
                    //objStd.Action = "I";
                    //objStd.Student_Id = Student.Remove(Student.Length - 1);
                    //objdt = objStd.Insert_Regular_SMS();

                    //Final Deliver// FinalMessage = FinalMessage + "Dear Member," + Environment.NewLine + "This is to inform that" + Environment.NewLine + txtDetails.Text + Environment.NewLine + "On " + Environment.NewLine + txtDate2.Text + " at " + ddlhour.SelectedValue;
                    FinalMessage = FinalMessage + "Dear Member," + Environment.NewLine + "This is to inform that" + Environment.NewLine + txtDetails.Text;

                    /*For Multiple Number */
                    MobileNO = MobileNO.Remove(MobileNO.Length - 1);

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
                    Response.Write("<script>alert('SMS Send SucessFully...!!!!');</script>");
                    clear();
                    /**********************/

                    //DataSet ds = new DataSet();
                    //ds = objStd.SendSMSViaXML(ret);
                    //if (ds.Tables.Count > 0)
                    //{
                    //    DataTable NewTable = objStd.NewSendSMS(System.DateTime.Now.ToString("dd/MM/yyyy").ToString().Replace('-', '/'));
                    //    if (NewTable.Rows.Count > 0)
                    //    {
                    //        //GrdMsgStatus.DataSource = NewTable;
                    //        //   GrdMsgStatus.DataBind();
                    //    }
                    //    else
                    //    {
                    //        //GrdMsgStatus.DataSource = null;
                    //        // GrdMsgStatus.DataBind();
                    //    }
                    //}
                    //else
                    //{
                    //    // GrdMsgStatus.DataSource = null;
                    //    // GrdMsgStatus.DataBind();
                    //}

                }

                else
                {
                    ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "test", "alert('Message Credit is not Available');", true);
                    //imgbtnCal.Focus();
                }
            }
            else
            {

            }
            // clear();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnCancle_Click(object sender, ImageClickEventArgs e)
    {

    }






    public void Gridbind()
    {
        try
        {
            admin = new Admin();
            objdt = new DataTable();
            admin.UserType = ddlCat.SelectedValue.ToString();
            admin.Action = "SMS";
            objdt = admin.Logininfo();
            if (objdt.Rows.Count > 0)
            {
                griduser.DataSource = objdt;
                griduser.DataBind();
                //  GridView grd = new GridView("griduser").FindControl;

            }
            else
            {
                griduser.DataSource = null;
                griduser.DataBind();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void ShowMessageCredit()
    {
        lblCredit.Text = objStd.MessageCredit();
    }

    public void clear()
    {
        txtDate.Text = "";
        txtMessage.Text = "";
        txtDetails.Text = "";
    }
    protected void griduser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griduser.PageIndex = e.NewPageIndex;
        Gridbind();
    }
    protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        griduser.Visible = true;
        Gridbind();
    }
}