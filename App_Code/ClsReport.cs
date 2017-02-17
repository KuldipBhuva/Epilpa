using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ClsReport
/// </summary>
public class ClsReport
{
    DBConnection cn;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;
    SqlDataAdapter da;

    public string Action { get; set; }

    public DataTable GetReport()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            dt = new DataTable();
            cmd.CommandText = "Action_Annual_Report";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
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