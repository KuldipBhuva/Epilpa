using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data.SqlClient;





/// <summary>
/// Summary description for DataObject
/// </summary>
/// 

public class DataObject
{
    DBConnection cn;
    SqlCommand cmd;
    DataTable dt;
    DataSet ds;
    SqlDataAdapter da;

    public string Action { get; set; }
    public int UserID { get; set; }
    public string UEmailID { get; set; }
    public string Arg { get; set; }



    public DataSet getSingleValue()
    {
        try
        {
            cmd = new SqlCommand();
            cn = new DBConnection();
            ds = new DataSet();
            cmd.CommandText = "Action_Login";
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            cn.open();
            cmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            cmd.Parameters.Add(new SqlParameter("@Arg", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Arg));
            cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserID));
            cmd.Parameters.Add(new SqlParameter("@UEmailID", SqlDbType.NVarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UEmailID));
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

