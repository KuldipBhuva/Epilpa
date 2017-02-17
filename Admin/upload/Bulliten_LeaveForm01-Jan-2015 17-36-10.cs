using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Drawing;

public partial class Admin_LeaveForm : System.Web.UI.Page
{
    DataTable objdt = new DataTable();
    DataTable objdt2 = new DataTable();
    DataTable objdt3 = new DataTable();
    DataSet objds = new DataSet();
    clsStand_Sub_Teacher objsst = new clsStand_Sub_Teacher();
    clsLeave objauth = new clsLeave();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserCode"] == null || Session["SchoolCode"] == null)
        {
            Response.Redirect("SignIn.aspx", false);
        }
        if (!IsPostBack)
        {
            Session["UploadData"] = null;
            DropdownbindTeacher();
            Gridauthorbind();
        }
    }
    protected void rbtnlArgument_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rbltype.SelectedValue == "HL")
            {
                trfromTo.Visible = true;
                trTo.Visible = false;

            }
            else if (rbltype.SelectedValue == "FL")
            {
                trTo.Visible = true;
                trfromTo.Visible = true;

            }
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    //public void NoofDays()
    //{
    //    try
    //    {
    //        if (TextBoxFromDate.Text != "" && TextBoxToDate.Text != "")
    //        {
    //            decimal a = 0;
    //            decimal b = 0;
    //            decimal c =0;

    //            a = Convert.ToDecimal( TextBoxFromDate.Text);
    //            b = Convert.ToDecimal(TextBoxToDate.Text);
    //            c = b - a;
    //            TextNoofdayz.Text = c.ToString();
    //        }
    //        else
    //        {
    //        }
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //}
    //protected void ButtonView_Click(object sender, EventArgs e)
    //{
    //    ButtonView.Visible = false;
    //    ButtonAddNew.Visible = true;
    //    DivAddNew.Visible = false;
    //}

    public void DropdownbindTeacher()
    {
        try
        {
            objsst = new clsStand_Sub_Teacher();
            objdt = new DataTable();
            objdt = new DataTable();

            objsst.SchoolCode = Convert.ToString(Session["SchoolCode"]);
            objsst.Action = "Teacher";
            objsst.UserCode = Convert.ToString(Session["UserCode"]);
            objdt = objsst.Get_TeacherDetails();
            if (objdt.Rows.Count > 0)
            {
                DDLteacher.DataSource = objdt;
                DDLteacher.DataValueField = "Teacher_Code";
                DDLteacher.DataTextField = "Name";
                DDLteacher.DataBind();

                if (objdt.Rows[0]["Status"].ToString() == "Staff")
                {
                    DDLteacher.Attributes.Add("readonly", "readonly");
                    BtnGo_Click(null, null);
                    BtnGo.Visible = false;
                }
                else
                {
                    DDLteacher.Items.Insert(0, "Select Teacher");
                    DDLteacher.Attributes.Remove("readonly");
                    BtnGo.Visible = true;
                }
            }
            else
            {
                DDLteacher.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {

    }

    protected void BtnGo_Click(object sender, EventArgs e)
    {
        DivAddNew.Visible = true;
    }

    protected void btnSaveSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (validation() == 1)
            {
                objauth = new clsLeave();
                objdt = new DataTable();
                // objds = new DataSet();

                objauth.SchoolCode = Convert.ToString(Session["SchoolCode"]);
                objauth.UserCode = Convert.ToString(Session["UserCode"]);
                //  gridrecipt1.

                objauth.type = rbltype.SelectedValue;
                objauth.Reason_type = txtReason.Text;
                objauth.Co_status = RblCo.SelectedValue;
                objauth.Prin_Status = RblPri.SelectedValue;

                if (TextBoxFromDate.Text != "")
                {
                    try
                    {
                        objauth.From_Date = Convert.ToDateTime(TextBoxFromDate.Text);

                    }
                    catch (Exception)
                    {
                        objauth.From_Date = DateTime.Parse(TextBoxFromDate.Text);

                    }
                }
                else
                {
                    TextBoxFromDate.Text = "";
                }


                if (TextBoxToDate.Text != "")
                {
                    try
                    {
                        objauth.To_Date = Convert.ToDateTime(TextBoxToDate.Text);

                    }
                    catch (Exception)
                    {
                        objauth.To_Date = DateTime.Parse(TextBoxToDate.Text);

                    }

                }
                else
                {
                    TextBoxToDate.Text = "";
                }



                objauth.Leave_Type = ddlGame.SelectedValue;
                objauth.Staff_Code = DDLteacher.SelectedValue;
                objauth.Coordinator_Verify = RblVfy.SelectedValue;

                // objFeePay.BankName = TextBoxBankName.Text;

                if (hdn.Value == "")
                {
                    objauth.Action = "Insert";
                    objdt = objauth.Insert_LeavesDetails();
                    if (objdt.Rows.Count > 0)
                    {
                        if (objdt.Rows[0][0].ToString() == "1")
                        {
                            ShowMsg("Data Insert Successfully");
                            // Gridauthorbind();
                            DivAddNew.Visible = false;
                            Gridauthorbind();
                            // DivGrid.Visible = true;
                            // Gridauthorbind();
                            //  ButtonAddNew.Visible = true;
                            //  ButtonView.Visible = false;
                            // clear();
                        }
                    }

                }
                else
                {
                    objauth.Action = "Update";
                    objauth.id = Convert.ToInt32(hdn.Value);
                    objdt = objauth.Insert_LeavesDetails();

                    if (objdt.Rows.Count > 0)
                    {
                        if (objdt.Rows[0][0].ToString() == "1")
                        {
                            ShowMsg("Data Update Successfully");
                           // clear();
                            DivAddNew.Visible = false; ;
                            DivGrid.Visible = true;
                            Gridauthorbind();
                           // ButtonAddNew.Visible = true;
                            //ButtonView.Visible = false;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    //protected void TextBoxToDate_TextChanged(object sender, EventArgs e)
    //{

    //        NoofDays();

    //}
    public int validation()
    {
        if (TextBoxFromDate.Text == "")
        {
            ShowMsg("Please Enter Author Name");
            TextBoxFromDate.Focus();
            return 0;
        }


        return 1;
    }

    public void ShowMsg(string str)
    {
        lblMsg.Visible = true;
        lblMsg.Text = str;
        lblMsg.Focus();

    }

    public void Gridauthorbind()
    {
        try
        {
            objauth = new clsLeave();
            objdt = new DataTable();
            //  objds = new DataSet();
            objauth.Action = "Grid";
            objauth.SchoolCode = Convert.ToString(Session["SchoolCode"]);
            objauth.UserCode = Convert.ToString(Session["UserCode"]);
            objdt = objauth.Insert_LeavesDetails();

            if (objdt.Rows.Count > 0)
            {
                if (objdt.Rows[0]["Status1"].ToString() == "Staff")
                {
                    gridAuthor.DataSource = objdt;
                    gridAuthor.DataBind();
                }
                else if (objdt.Rows[0]["Status1"].ToString() == "Co-Ordinator")
                {
                    gridAuthor.DataSource = objdt;
                    gridAuthor.DataBind();
                }
                else
                {
                    gridAuthor.DataSource = objdt;
                    gridAuthor.DataBind();
                }
            }
            else
            {
                gridAuthor.DataSource = null;
                gridAuthor.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gridAuthor_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdAuthor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "EditRow")
            {
                objauth = new clsLeave();
                objdt = new DataTable();
                DataTable Temp = new DataTable();
                objauth.SchoolCode = Convert.ToString(Session["SchoolCode"]);
                objauth.id = Convert.ToInt32(e.CommandArgument.ToString());
                objauth.UserCode = Convert.ToString(Session["UserCode"]);
                objauth.Action = "Gridbyid";
                objds = objauth.Grid_LeavesDetails();
                if (objds.Tables.Count > 0)
                {
                    if (objds.Tables[0].Rows.Count > 0)
                    {

                        Temp = objds.Tables[0];
                        hdn.Value = e.CommandArgument.ToString();
                        DDLteacher.SelectedValue = Temp.Rows[0]["Teacher_Code"].ToString();
                        //  DropdownTeacher_SelectedIndexChanged(sender, null);


                        //TextLessionDetails.Text = Temp.Rows[0]["LessonDetails"].ToString();
                        //   txttopics.Text = Temp.Rows[0]["Topics"].ToString();
                        TextBoxToDate.Text = Temp.Rows[0]["To_Date"].ToString();
                        TextBoxFromDate.Text = Temp.Rows[0]["From_date"].ToString();
                        rbltype.SelectedValue = Temp.Rows[0]["type"].ToString();
                        txtReason.Text = Temp.Rows[0]["Reason_type"].ToString();
                        RblPri.SelectedValue = Temp.Rows[0]["Prin_Status"].ToString();
                        RblCo.SelectedValue = Temp.Rows[0]["Co_status"].ToString();
                        RblVfy.SelectedValue = Temp.Rows[0]["Coordinator_Verify"].ToString();
                        if (Temp.Rows[0]["User_Status"].ToString() == "True")
                        {

                            trstatus.Visible = false;
                            trPrinstatus.Visible = true;
                        }
                        else if (Temp.Rows[0]["User_Status"].ToString() == "false")
                        {

                            trstatus.Visible = false;
                            trPrinstatus.Visible = false;


                        }

                        else
                        {
                            trstatus.Visible = true;
                            tr4.Visible = true;
                            trPrinstatus.Visible = false;
                        }

                        // RadioButtonListStatus.SelectedValue = Temp.Rows[0]["Status"].ToString();
                        DivAddNew.Visible = true;
                        DDLteacher.Enabled = false;
                        ddlGame.Enabled = false;
                        trfromTo.Visible = true;
                        trTo.Visible = true;
                        TextBoxFromDate.Enabled = false;
                        TextBoxToDate.Enabled = false;
                        //hdn.Value = "";
                    }

                }
            }
        }

        catch (Exception ex)
        {
            throw ex;
        }
    }
}