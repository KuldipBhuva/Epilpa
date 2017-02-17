using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Businessobj;
using System.IO;
using System.Drawing;
using System.ComponentModel;


public partial class Myprofile : System.Web.UI.Page
{
    Registration clsreg = new Registration();
    clsmanagemeb members = new clsmanagemeb();
    BusinessObject Library = new BusinessObject();
    DataTable objdt = new DataTable();
    ClsStandard objStd = new ClsStandard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Convert.ToString(Session["ISLogin"]) != "Yes")
            {
                Response.Redirect("index.aspx?login=no");
                Session["ISLogin"] = "No";

            }
            else
            {
                bind();
            }
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        clsreg = new Registration();
        objdt = new DataTable();
        // objds = new DataSet();
        clsreg.YearOfStart = txtYearOfStart.Text;
        clsreg.UAddress = txtAddress.Text;
        clsreg.Residence = txtResidence.Text;
        clsreg.AcYear = txtAcYear.Text;
        clsreg.AdFeeRs = txtAdFeeRs.Text;
        clsreg.Company = txtCompany.Text;
        clsreg.Fax = txtFax.Text;
        clsreg.MeFeeRs = txtMeFeeRs.Text;
        clsreg.NatureOfActivity = txtNatureOfActivity.Text;
        clsreg.OAddress = txtOAddress.Text;
        clsreg.PhoneOffice = txtPhoneOffice.Text;
        //if (Upload1.HasFile || (hdnPhotoName.Value != "" && hdnPhotoData.Value != ""))
        //{
        //    if (Upload1.HasFile)
        //    {
        //        string filename = Upload1.FileName;
        //        string ext = Path.GetExtension(filename);

        //        if (Upload1.PostedFile.InputStream != null)
        //        {
        //            #region imageconvert
        //            Stream fs = Upload1.PostedFile.InputStream;
        //            BinaryReader br = new BinaryReader(fs);
        //            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //            clsreg.PhotoData = bytes;
        //            #endregion
        //        }

        //        #region imageconvert
        //        Stream fs1 = Upload2.PostedFile.InputStream;
        //        BinaryReader br1 = new BinaryReader(fs1);
        //        Byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);
        //        clsreg.PhotoData1 = bytes1;
        //        #endregion
        //        //Stream fs = Upload1.PostedFile.InputStream;
        //        //BinaryReader br = new BinaryReader(fs);
        //        //Byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //        //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        //        //string Final = "data:image/png;base64," + base64String;
        //        //postFile = this.Upload1.PostedFile;
        //        //bt = ReadImageFile(postFile.FileName, new string[] { ".GIF", ".gif", ".jpg", ".bmp" });
        //        hdnPhotoName.Value = filename;
        //        //clsreg.PhotoData =bytes[0];
        //        hdnPhotoType.Value = ext;
        //        //Image1.ImageUrl = Final;
        //    }
        //    else
        //    {
        //        if (hdnPhotoName.Value != "" && hdnPhotoData.Value != "")
        //        {
        //            Image1.ImageUrl = hdnPhotoData.Value;
        //        }
        //    }


        clsreg.PhotoName = hdnPhotoName.Value;
        // clsreg.PhotoData = ;

        //}

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
        clsreg.Action = "UpdateProfile";
        objdt = clsreg.Registration1();
        if (objdt.Rows[0][0].ToString() == "1")
        {
            Response.Write("<script>alert('Data Update SucessFully...!!!!');</script>");
        }
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {

    }

    public void bind()
    {
        try
        {

            DataTable dt = new DataTable();
            members = new clsmanagemeb();
            members.UserID = Convert.ToInt32(Session["RegID"]);
            members.Action = "Byid";
            dt = members.FetchGrid();
            byte[] img = null;
            if (dt.Rows.Count > 0)
            {

                txtid.Text = dt.Rows[0]["UserID"].ToString();
                txtid.Enabled = false;
                txtMemberName.Text = dt.Rows[0]["UName"].ToString();
                txtAddress.Text = dt.Rows[0]["UAddress"].ToString();
                txtEmailID.Text = dt.Rows[0]["UEmailID"].ToString();
                txtEmailID.Enabled = false;
                ddlMemberType.SelectedValue = dt.Rows[0]["UserType"].ToString();
                ddlMemberType.Enabled = false;
                //lblBankName.Text = dt.Rows[0]["BankName"].ToString();
                //lblChequeNo.Text = dt.Rows[0]["ChequeNo"].ToString();
                //lblPayment.Text = dt.Rows[0]["PaymentType"].ToString();

                ddlSex.SelectedValue = dt.Rows[0]["Sex"].ToString();
                ddlSex.Enabled = false;
                txtCompany.Text = dt.Rows[0]["Company"].ToString();
                txtOAddress.Text = dt.Rows[0]["OAddress"].ToString();
                txtYearOfStart.Text = dt.Rows[0]["YearOfStart"].ToString();
                txtNatureOfActivity.Text = dt.Rows[0]["NatureOfActivity"].ToString();
                txtPhoneOffice.Text = dt.Rows[0]["PhoneOffice"].ToString();
                txtFax.Text = dt.Rows[0]["Fax"].ToString();
                txtResidence.Text = dt.Rows[0]["Residence"].ToString();

                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                txtMobile.Enabled = false;
                txtAdFeeRs.Text = dt.Rows[0]["AdFeeRs"].ToString();
                txtMeFeeRs.Text = dt.Rows[0]["MeFeeRs"].ToString();
                txtAcYear.Text = dt.Rows[0]["AcYear"].ToString();

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
}
