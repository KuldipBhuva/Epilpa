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

public partial class Change_Password : System.Web.UI.Page
{
    Admin Admin = new Admin();
    DataTable objdt = new DataTable();
    BusinessObject Library = new BusinessObject();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Login_ID"] == null)
        {
            Response.Redirect("index.aspx");
        }
        DataSet objds = new DataSet();
        objdt = new DataTable();
        DataTable objdt1 = new DataTable();
        Admin = new Admin();
        Admin.Action = "ChangePass";
        //  Admin.AdminUserPassword = txtConfirmNewPassword.Text;
        objds = Admin.GetAdminSetting();
        if (objds.Tables.Count > 0)
        {
            objdt = objds.Tables[0];
            // objdt1 = objds.Tables[1];
            if (objdt.Rows.Count > 0)
            {
                HiddenField1.Value = objdt.Rows[0]["AdminUserPassword"].ToString();
            }
            // HiddenField1.Value = Library.getSingleValue("Select AdminUserPassword From AdminSetting Where AdminUserName='admin'");
            lbldupi.Visible = false;
        }
    }
    protected void InsertButton_Click(object sender, ImageClickEventArgs e)
    {
        DataSet objds = new DataSet();
        objdt = new DataTable();
        DataTable objdt1 = new DataTable();
        Admin = new Admin();
        Admin.Action = "ChangePass1";
        Admin.AdminUserPassword = txtConfirmNewPassword.Text;
        objds = Admin.GetAdminSetting();
        if (objds.Tables.Count > 0)
        {
            // objdt = objds.Tables[0];
            objdt1 = objds.Tables[0];

            if (objdt1.Rows[0][0].ToString() == "1")
            {
                //  Library.execNonQueryB("Update AdminSetting set AdminUserPassword='" + txtNewPassword.Text + "' Where AdminUserName='admin'");
                lbldupi.Text = "Password Change Successfully";
                lbldupi.Visible = true;

                txtNewPassword.Text = "";
                txtCurrentPassword.Text = "";
                txtConfirmNewPassword.Text = "";
            }
        }
    }
    protected void InsertCancelButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Change_Password.aspx");
    }
}
