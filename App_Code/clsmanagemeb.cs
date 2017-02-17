using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for clsmanagemeb
/// </summary>
public class clsmanagemeb
{
    DBConnection cn;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;
    SqlDataAdapter da;
    public string Action { get; set; }
    public string AnnualReportTitle { get; set; }
    public string AnnualReportFile { get; set; }
    public string UEmailID { get; set; }
    public string PhoneOffice { get; set; }
    public string Fax { get; set; }
    public string Residence { get; set; }
    public string Mobile { get; set; }
    public string Active { get; set; }
    //public string Active { get; set; }
    //public string Active { get; set; }
    public int UserID { get; set; }
    public int AnnualReportID { get; set; }
    public DateTime? RegDate { get; set; }
    public DateTime? ExpDate { get; set; }
    public string Company { get; set; }
    public string UserType { get; set; }
    public string UAddress { get; set; }
    public string OAddress { get; set; }
    public string UName { get; set; }
    public string NatureOfActivity { get; set; }
    public string YearOfStart { get; set; }
    public string Premium_Member { get; set; }
    

    public DataSet insertAnnual()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            ds = new DataSet();
            cmd.CommandText = "Annual_Report_Upload";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@AnnualReportTitle", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AnnualReportTitle));
            cmd.Parameters.Add(new SqlParameter("@AnnualReportFile", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AnnualReportFile));
            cmd.Parameters.Add(new SqlParameter("@AnnualReportID", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AnnualReportID));

            cmd.Connection = cn.con;
            da.Fill(ds);
            return ds;

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

    public DataTable FetchGrid()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            dt = new DataTable();
            cmd.CommandText = "manage_Member";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@UEmailID", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UEmailID));
            cmd.Parameters.Add(new SqlParameter("@PhoneOffice", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, PhoneOffice));
            cmd.Parameters.Add(new SqlParameter("@Fax", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Fax));
            cmd.Parameters.Add(new SqlParameter("@Residence", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Residence));
            cmd.Parameters.Add(new SqlParameter("@Mobile", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Mobile));
            cmd.Parameters.Add(new SqlParameter("@Active", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Active));
            cmd.Parameters.Add(new SqlParameter("@RegDate", SqlDbType.DateTime, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, RegDate));
            cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserID));
            cmd.Parameters.Add(new SqlParameter("@ExpDate", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ExpDate));
            cmd.Parameters.Add(new SqlParameter("@Company", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Company));
            cmd.Parameters.Add(new SqlParameter("@UserType", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserType));
            cmd.Parameters.Add(new SqlParameter("@UAddress", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UAddress));
            cmd.Parameters.Add(new SqlParameter("@OAddress", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, OAddress));
            cmd.Parameters.Add(new SqlParameter("@UName", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UName));
            cmd.Parameters.Add(new SqlParameter("@YearOfStart", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, YearOfStart));
            cmd.Parameters.Add(new SqlParameter("@NatureOfActivity", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, NatureOfActivity));
            cmd.Parameters.Add(new SqlParameter("@Premium_Member", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Premium_Member));
           
            //  cmd.Parameters.Add(new SqlParameter("@Residence", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Residence));
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
}