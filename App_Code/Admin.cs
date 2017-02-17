using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for Admin
/// </summary>
public class Admin
{
    DBConnection cn;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;
    SqlDataAdapter da;
    public string Action { get; set; }
    public string AdminUserName { get; set; }
    public string AdminUserPassword { get; set; }
    public string UserType { get; set; }
    
    public DataSet GetAdminSetting()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            ds = new DataSet();
            cmd.CommandText = "Admin_Seetings";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@AdminUserName", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AdminUserName));
            cmd.Parameters.Add(new SqlParameter("@AdminUserPassword", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AdminUserPassword));

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
    public DataTable Logininfo()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            dt = new DataTable();
            cmd.CommandText = "Admin_Seetings";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@UserType", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserType));
            cmd.Parameters.Add(new SqlParameter("@AdminUserName", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AdminUserName));
            cmd.Parameters.Add(new SqlParameter("@AdminUserPassword", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, AdminUserPassword));

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