using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for clsAnnualrpt
/// </summary>
public class clsAnnualrpt
{
    DBConnection cn;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;
    SqlDataAdapter da;
    public string Action { get; set; }
    public string AnnualReportTitle { get; set; }
    public string AnnualReportFile { get; set; }
    public int AnnualReportID { get; set; }
  
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
}