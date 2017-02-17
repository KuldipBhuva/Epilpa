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


public partial class index : System.Web.UI.Page
{
    // public BusinessObject Library = new BusinessObject();
    DataObject clsobj = new DataObject();
    DataTable objdt = new DataTable();
    DataSet objds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        if (validation() == 1)
        {
            try
            {

                clsobj = new DataObject();

                objdt = new DataTable();
                DataTable objdt1 = new DataTable();
                DataTable objdt2 = new DataTable();
                DataSet objds = new DataSet();
                clsobj.UserID = Convert.ToInt32(txtRegID.Text);
                clsobj.UEmailID = txtEmailID.Text;
                clsobj.Action = "Login";
                //clsobj.Arg = "Sucess";
                objds = clsobj.getSingleValue();
                if (objds.Tables.Count > 0)
                {

                    Session["RegID"] = txtRegID.Text.Trim();
                    Session["EMail"] = txtEmailID.Text.Trim();
                    objdt = objds.Tables[0];
                    objdt1 = objds.Tables[1];
                    objdt2 = objds.Tables[2];
                    if (objdt.Rows.Count > 0)
                    {
                        if (objdt1.Rows.Count > 0)
                        {
                            Session["ISLogin"] = "Yes";
                            Session["UName"] = objdt.Rows[0]["UName"];
                            Session["RegID"] = txtRegID.Text.Trim();
                            Session["EMail"] = txtEmailID.Text.Trim();
                            //  Response.Redirect("Bulliten.aspx");
                            Response.Redirect("constitution.aspx");
                            //Response.Redirect("../Epilpa31Decnew/Myprofile.aspx");
                        }
                        else
                        {
                            lblMess.Text = "Your account is not Active. Plz Contact EPILPA Administrator for further details.";
                            Session["ISLogin"] = "No";


                        }
                        if (objdt2.Rows.Count > 0)
                        {
                            Session["ISLogin"] = "Yes";
                            Session["UName"] = objdt.Rows[0]["UName"];
                            Session["RegID"] = txtRegID.Text.Trim();
                            Session["EMail"] = txtEmailID.Text.Trim();
                            Response.Redirect("Myprofile.aspx");


                        }
                        else
                        {
                            // Response.Redirect("Bulliten.aspx");
                            lblMess.Text = "Your account is not Active. Plz Contact EPILPA Administrator for further details.";
                            Session["ISLogin"] = "No";


                        }
                    }
                    else
                    {
                        lblMess.Text = "Incorrect UserId or Password...!!!!";
                    }
                }
            }


            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Session["UName"] = sqlval1;
        //Session["ISLogin"] = "Yes";
        // sql = "Select UserID from M_User Where UserID=" + txtRegID.Text.Trim() + " and UEmailID='" + txtEmailID.Text.Trim() + "'";
        // if (Library.getSingleValue(sql) != "")
        // {
        //     sql = "Select UserID from M_User Where UserID=" + txtRegID.Text.Trim() + " and RegDate <> null and ExpDate <> null";
        //     if (Library.getSingleValue(sql) != "")
        //     {
        //         sql = "Select Usertype from M_User Where UserID=" + txtRegID.Text.Trim() + " and UEmailID='" + txtEmailID.Text.Trim() + "'";
        //  if (Library.getSingleValue(sql) == "Life Membership")
        //         {
        //             sql = "Select UserID from M_User Where UserID=" + txtRegID.Text.Trim() + " and (RegDate>#" + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "#)";
        //             Session["RegID"] = txtRegID.Text.Trim();
        //             Session["EMail"] = txtEmailID.Text.Trim();
        //             Response.Redirect("Bulliten.aspx");
        //         }
        //         else
        //         {

        //             sql = "Select UserID from M_User Where UserID=" + txtRegID.Text.Trim() + " and (RegDate>#" + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "# OR ExpDate<#" + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "#)";
        //             if (Library.getSingleValue(sql) != "")
        //             {
        //                 lblMess.Text = "Subscription Date is Expiried...Kindly contact administrator to Renew accout.";

        //             }
        //             else
        //             {

        //                 sql = "Select UName from M_User Where UserID=" + txtRegID.Text.Trim() + " and Active='No'";
        //                 string sqlval = Library.getSingleValue(sql);
        //                 if (sqlval != "")
        //                 {
        //                     lblMess.Text = "Your account is not Active. Plz Contact EPILPA Administrator for further details";

        //                 }
        //                 else
        //                 {
        //                     Session["ISLogin"] = "Yes";
        //                     Session["UName"] = sqlval1;
        //                     Session["RegID"] = txtRegID.Text.Trim();
        //                     Session["EMail"] = txtEmailID.Text.Trim();
        //                     Response.Redirect("Bulliten.aspx");
        //                 }
        //             }
        //         }

        //     }
        //     else
        //     {
        //         lblMess.Text = "Your account has been expired, kindly contact epilpa office";
        //     }
        // }
        // else
        // {
        //     lblMess.Text = "Enter Valid Email ID and MemberId";
        // }
    }
    protected void btnNewUser_Click(object sender, ImageClickEventArgs e)
    {
        //string sql = "Select UName from M_User Where UserID=" + txtRegID.Text.Trim() + " and Active='No'";
        //string sqlval = Library.getSingleValue(sql);
        //Session["UName"] = sqlval;
        Response.Redirect("FRegistration.aspx");
    }

    public int validation()
    {
        if (txtEmailID.Text == "")
        {
            lblMess.Text = "Please Enter E-mail id";
            return 0;
        }
        if (txtRegID.Text == "")
        {
            lblMess.Text = "Please Enter id";
            return 0;
        }
        return 1;
    }
}
