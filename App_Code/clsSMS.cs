using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Xml;
//using System.Windows.Forms;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for clsSMS
/// </summary>
public class clsSMS
{
    #region "Variable Declaration"
    DBConnection objdb;
    SqlCommand objcmd;
    DataTable objdt;
    DataSet objds;
    SqlDataAdapter objda;

    Int32 _Absent_Id;
    Int32 _Div_id;
    Int32 _Std_id;
    //Int32 _Student_Id;
    DateTime _Date;

    public Int32 id { get; set; }

    public DateTime? Msg_Date { get; set; }
    public Int32 Fee_SMS_Status { get; set; }
    public string Student_Id { get; set; }
    public DateTime? CreateDate { get; set; }
    public string Action { get; set; }

    public string MobileNO { get; set; }
    #endregion

    #region "Property Declaration"

    public Int32 Std_id
    {
        get
        {
            return _Std_id;
        }
        set
        {
            _Std_id = value;
        }
    }
    public Int32 Div_id
    {
        get
        {
            return _Div_id;
        }
        set
        {
            _Div_id = value;
        }
    }
    public Int32 Absent_Id
    {
        get
        {
            return _Absent_Id;
        }
        set
        {
            _Absent_Id = value;
        }
    }
    //public Int32 Student_Id
    //{
    //    get
    //    {
    //        return _Student_Id;
    //    }
    //    set
    //    {
    //        _Student_Id = value;
    //    }
    //}
    public DateTime Date
    {
        get
        {
            return _Date;
        }
        set
        {
            _Date = value;
        }
    }

    #endregion


    public DataTable Insert_Exam_Fee_SMS()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "[Insert_Exam_Fee_SMS]";
            objcmd.CommandType = CommandType.StoredProcedure;
            objcmd.CommandTimeout = 0;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@Std_id", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Std_id));
            objcmd.Parameters.Add(new SqlParameter("@Msg_Date", SqlDbType.DateTime, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Msg_Date));
            objcmd.Parameters.Add(new SqlParameter("@Student_Id", SqlDbType.VarChar, 1000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Student_Id));
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
}