using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for clsbulletin
/// </summary>
public class clsbulletin
{
    DBConnection cn;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;
    SqlDataAdapter da;
    public string Action { get; set; }
    public string BulletinTitle { get; set; }
    public string catname { get; set; }
    public string BuletinFile { get; set; }
    public int BulletinID { get; set; }
    public int catid { get; set; }
    

    public DataTable GetBullettin()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            dt = new DataTable();
            cmd.CommandText = "Action_Bulletin";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@BulletinID", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, BulletinID));
            cmd.Parameters.Add(new SqlParameter("@BulletinTitle", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, BulletinTitle));
            cmd.Parameters.Add(new SqlParameter("@BuletinFile", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, BuletinFile));
            cmd.Parameters.Add(new SqlParameter("@catname", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, catname));
            cmd.Parameters.Add(new SqlParameter("@catid", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, catid));
            
                
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

    public DataSet GetButtetinn()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            ds = new DataSet();
            cmd.CommandText = "Action_Bulletin";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@BulletinID", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, BulletinID));
            cmd.Parameters.Add(new SqlParameter("@BulletinTitle", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, BulletinTitle));
            cmd.Parameters.Add(new SqlParameter("@BuletinFile", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, BuletinFile));


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