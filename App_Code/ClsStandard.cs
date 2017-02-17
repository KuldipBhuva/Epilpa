using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Xml;
//using System.Windows.Forms;
using System.Web;



public class ClsStandard
{
    #region "Variable Declaration"
    DBConnection objdb;
    SqlCommand objcmd;
    DataTable objdt;
    SqlDataAdapter objda;

    //public string Division { get; set; }
    //public int Div_id { get; set; }
    //public string Subject { get; set; }
    //public int Sub_Id { get; set; }
    //public string Exam_Type { get; set; }
    public string Action { get; set; }
    public int Std_id { get; set; }
    public string Standard { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string SchoolCode { get; set; }
    public string UserCode { get; set; }
    public int Sub_id { get; set; }
    public string Subject { get; set; }
    public string StudentCode { get; set; }
    public int id { get; set; }
    public DataTable staffdetail { get; set; }
    public string Std_Sub_Code { get; set; }
    public DataTable StaffSubjectDetail { get; set; }
    public int? StreamID { get; set; }
    public int? GroupID { get; set; }
    public int ExamType { get; set; }
    public int ExamName { get; set; }
    public DataTable Msg_Date { get; set; }
    public string Student_Id { get; set; }
    #endregion

    //public void insert(int insertflag)
    //{
    //    try
    //    {
    //        objdb = new DBConnection();
    //        objcmd = new SqlCommand();
    //        objcmd.Connection = objdb.con;
    //        objcmd.CommandText = "[Standard_Master_InsertRecord]";
    //        objcmd.CommandType = CommandType.StoredProcedure;
    //        objdb.open();
    //        objcmd.Parameters.Add(new SqlParameter("@insertflag", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, insertflag));
    //        objcmd.Parameters.Add(new SqlParameter("@School_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, School_Id));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Id));
    //        objcmd.Parameters.Add(new SqlParameter("@Standard", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Standard));
    //        objcmd.Parameters.Add(new SqlParameter("@Division", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Division));
    //        objcmd.Parameters.Add(new SqlParameter("@Subject", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Subject));
    //        objcmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Description));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Type", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Type));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Name", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Name));
    //        objcmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //    finally
    //    {
    //        objdb.close();
    //    }
    //}

    //public DataTable GetData(int gridflag, int School_Id)
    //{
    //    try
    //    {
    //        objdb = new DBConnection();
    //        objdt = new DataTable();
    //        objcmd = new SqlCommand();
    //        objcmd.CommandText = "[Standard_Master_GetData]";
    //        objcmd.CommandType = CommandType.StoredProcedure;
    //        objda = new SqlDataAdapter(objcmd);
    //        objdb.open();
    //        objcmd.Parameters.Add(new SqlParameter("@gridflag", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, gridflag));
    //        objcmd.Parameters.Add(new SqlParameter("@School_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, School_Id));
    //        objcmd.Connection = objdb.con;
    //        objda.Fill(objdt);
    //        return objdt;
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //    finally
    //    {
    //        objdb.close();
    //    }
    //}

    //public DataTable GetById(int School_Id, int getidflag, int id)
    //{
    //    try
    //    {
    //        objdb = new DBConnection();
    //        objdt = new DataTable();
    //        objcmd = new SqlCommand();
    //        objcmd.CommandText = "[Common_Master_GetById ]";
    //        objcmd.CommandType = CommandType.StoredProcedure;
    //        objda = new SqlDataAdapter(objcmd);
    //        objdb.open();
    //        objcmd.Parameters.Add(new SqlParameter("@School_Id", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, School_Id));
    //        objcmd.Parameters.Add(new SqlParameter("@getidflag", SqlDbType.Int, 5, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, getidflag));
    //        objcmd.Parameters.Add(new SqlParameter("@Div_id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
    //        objcmd.Parameters.Add(new SqlParameter("@Std_id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
    //        objcmd.Parameters.Add(new SqlParameter("@Sub_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Name_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
    //        objcmd.Connection = objdb.con;
    //        objda.Fill(objdt);
    //        return objdt;
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //    finally
    //    {
    //        objdb.close();
    //    }
    //}

    //public void Update(int updateflag)
    //{
    //    try
    //    {
    //        objdb = new DBConnection();
    //        objcmd = new SqlCommand();
    //        objcmd.Connection = objdb.con;
    //        objcmd.CommandText = "[Common_Master_UpdateRecord]";
    //        objcmd.CommandType = CommandType.StoredProcedure;
    //        objdb.open();
    //        objcmd.Parameters.Add(new SqlParameter("@updateflag", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, updateflag));
    //        objcmd.Parameters.Add(new SqlParameter("@Std_id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Std_id));
    //        objcmd.Parameters.Add(new SqlParameter("@Div_id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Div_id));
    //        objcmd.Parameters.Add(new SqlParameter("@Standard", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Standard));
    //        objcmd.Parameters.Add(new SqlParameter("@Division", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Division));
    //        objcmd.Parameters.Add(new SqlParameter("@Subject", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Subject));
    //        objcmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Description));
    //        objcmd.Parameters.Add(new SqlParameter("@Sub_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Sub_Id));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Id));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Name_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Name_Id));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Name", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Name));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Type", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Type));
    //        objcmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        objdb.close();
    //    }
    //}

    //public void Delete(int deleteflag, int id)
    //{
    //    try
    //    {
    //        objdb = new DBConnection();
    //        objcmd = new SqlCommand();
    //        objcmd.Connection = objdb.con;
    //        objcmd.CommandText = "[Common_Master_DeleteRecord]";
    //        objcmd.CommandType = CommandType.StoredProcedure;
    //        objdb.open();
    //        objcmd.Parameters.Add(new SqlParameter("@deleteflag", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, deleteflag));
    //        objcmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
    //        objcmd.ExecuteNonQuery();
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //    finally
    //    {
    //        objdb.close();
    //    }
    //}

    //public DataTable CheckData(int id, int CheckFlag, string str)
    //{
    //    try
    //    {
    //        objdb = new DBConnection();
    //        objdt = new DataTable();
    //        objcmd = new SqlCommand();
    //        objcmd.CommandText = "[Common_Master_CheckData]";
    //        objcmd.CommandType = CommandType.StoredProcedure;
    //        objda = new SqlDataAdapter(objcmd);
    //        objdb.open();
    //        objcmd.Parameters.Add(new SqlParameter("@School_Id", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
    //        objcmd.Parameters.Add(new SqlParameter("@CheckFlag", SqlDbType.Int, 5, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, CheckFlag));
    //        objcmd.Parameters.Add(new SqlParameter("@Standard", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Standard));
    //        objcmd.Parameters.Add(new SqlParameter("@Division", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Division));
    //        objcmd.Parameters.Add(new SqlParameter("@Subject", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Subject));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Type", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Type));
    //        objcmd.Parameters.Add(new SqlParameter("@Exam_Name", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Exam_Name));
    //        objcmd.Parameters.Add(new SqlParameter("@str", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, str));
    //        objcmd.Connection = objdb.con;
    //        objda.Fill(objdt);
    //        return objdt;
    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }
    //    finally
    //    {
    //        objdb.close();
    //    }
    //}

    public DataTable Action_Standard_Master()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "Action_Standard_Master";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Std_id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Std_id));
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@Standard", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Standard));
            objcmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Description));
            objcmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Status));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
            objcmd.Parameters.Add(new SqlParameter("@StreamID", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, StreamID));
            objcmd.Parameters.Add(new SqlParameter("@GroupID", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, GroupID));

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

    public DataTable GetStandardMaster()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "GetStandardMaster";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Std_id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Std_id));
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@Standard", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Standard));
            objcmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Description));
            objcmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Status));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
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


    public DataTable GetSUBJECTMaster()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "[Get_Student_Wise_Subject]";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Sub_id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Sub_id));
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@Subject", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Subject));
            objcmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Description));
            objcmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Status));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
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


    public DataTable Action_Subj_Stud_Master()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "[Action_Subject_student_Master]";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
            objcmd.Parameters.Add(new SqlParameter("@Std_id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Std_id));
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@StudentCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, StudentCode));
            objcmd.Parameters.Add(new SqlParameter("@Sub_Id", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Sub_id));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
            objcmd.Parameters.Add(new SqlParameter("@Std_Sub_Code", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Std_Sub_Code));

            //SqlParameter para = new SqlParameter();
            //para.ParameterName = "@staffdetail";
            //para.SqlDbType = SqlDbType.Structured;
            //para.Value = staffdetail;
            //para.Direction = ParameterDirection.Input;
            //objcmd.Parameters.Add(para);

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

    public DataTable GetSUBJECTMasterNEW()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "[Bind_Standard]";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Sub_id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Sub_id));
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@Standard", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Standard));
            // objcmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Description));
            // objcmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Status));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
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


    public DataTable GetClassMaster()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "GET_Class_Details";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 50, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@Division", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Standard));
            //objcmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Description));
            //objcmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Status));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            //objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
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

    public DataTable GetStreamMaster()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "Get_Stream_Data";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
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

    public DataTable GetGroupMaster()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "Get_Group_Data";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
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

    public DataTable GetClassMasterEXAM()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "GET_Class_Details";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, id));
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@Division", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Standard));
            objcmd.Parameters.Add(new SqlParameter("@ExamType", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ExamType));
            objcmd.Parameters.Add(new SqlParameter("@ExamName", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, ExamName));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
            // objcmd.Parameters.Add(new SqlParameter("@UserCode", SqlDbType.VarChar, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, UserCode));
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

    public string MessageCredit()
    {
        string str = "";
     //   Uri objURI = new Uri("http://api.urlsms.com/CustomerCredits.aspx?UserID=info@rediffmail.com&Password=newtech009");
        Uri objURI = new Uri("http://api.urlsms.com/CustomerCredits.aspx?UserID=info@epilpa.org&Password=epilpa009");
        WebRequest objWebRequest = WebRequest.Create(objURI);
        WebResponse objWebResponse = objWebRequest.GetResponse();
        Stream objStream = objWebResponse.GetResponseStream();
        StreamReader objStreamReader = new StreamReader(objStream);
        string strHTML = objStreamReader.ReadToEnd();
        int iTabInd = strHTML.IndexOf("<table");

        if (iTabInd >= 0)
        {
            string strExtract = strHTML.Substring(iTabInd).Replace("\t", "").Replace("\r", "");
            int intTotalLength = strHTML.Length;

            string[] strRows = strExtract.Split(new string[] { "<span id=\"lblMsg\">" }, StringSplitOptions.RemoveEmptyEntries);
            string[] str2 = strRows[1].Split(new string[] { "</span>" }, StringSplitOptions.RemoveEmptyEntries);
            str = str2[0].ToString();
        }
        return str;
    }

    public DataTable Insert_Regular_SMS()
    {
        try
        {
            objdb = new DBConnection();
            objdt = new DataTable();
            objcmd = new SqlCommand();
            objcmd.CommandText = "[Insert_Regular_SMS]";
            objcmd.CommandType = CommandType.StoredProcedure;
            objda = new SqlDataAdapter(objcmd);
            objdb.open();
            objcmd.Parameters.Add(new SqlParameter("@Action", SqlDbType.VarChar, 150, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Action));
            objcmd.Parameters.Add(new SqlParameter("@Std_id", SqlDbType.Int, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Std_id));
            objcmd.Parameters.Add(new SqlParameter("@Msg_Date", SqlDbType.DateTime, 500, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Msg_Date));
            objcmd.Parameters.Add(new SqlParameter("@Student_Id", SqlDbType.VarChar, 1000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, Student_Id));
            objcmd.Parameters.Add(new SqlParameter("@SchoolCode", SqlDbType.VarChar, 1000, ParameterDirection.Input, true, 0, 0, "", DataRowVersion.Proposed, SchoolCode));
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

    public DataSet SendSMSViaXML(string XMLMessage)
    {
        WebRequest req = null;
        WebResponse rsp = null;
        try
        {
            //  To send SMS 
            string uri = "http://api.urlsms.com/SendXmlsms.aspx";

            // To receive DR
            // string uri = "http://api.urlsms.com/GetXmldr.aspx";

            req = WebRequest.Create(uri);

            //req.Proxy = WebProxy.GetDefaultProxy(); // Enable if using proxy
            req.Method = "POST";        // Post method
            req.ContentType = "text/xml";     // content type

            // Wrap the request stream with a text-based writer
            StreamWriter writer = new StreamWriter(req.GetRequestStream());

            // Write the XML text into the stream
            writer.WriteLine(XMLMessage);
            writer.Close();

            // Send the data to the webserver
            rsp = req.GetResponse();
            Stream objStream = rsp.GetResponseStream();
            StreamReader objStreamReader = new StreamReader(objStream);
            string strHTML = objStreamReader.ReadToEnd();
            DataSet ds = XmlString2DataSet(strHTML);

            return ds;

            //Response.Write(strHTML);
        }
        catch (WebException webEx)
        {
            //Response.Write(webEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            //Response.Write(ex);
            return null;
        }
        finally
        {
            if (req != null) req.GetRequestStream().Close();
            if (rsp != null) rsp.GetResponseStream().Close();
        }
        return null;
    }

    private DataSet XmlString2DataSet(string xmlString)
    {
        //create a new DataSet that will hold our values
        DataSet quoteDataSet = null;

        //check if the xmlString is not blank
        if (String.IsNullOrEmpty(xmlString))
        {
            //stop the processing
            return quoteDataSet;
        }

        try
        {
            //create a StringReader object to read our xml string
            using (StringReader stringReader = new StringReader(xmlString))
            {
                //initialize our DataSet
                quoteDataSet = new DataSet();

                //load the StringReader to our DataSet
                quoteDataSet.ReadXml(stringReader);
            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
            //return null
            quoteDataSet = null;
        }
        //return the DataSet containing the stock information
        return quoteDataSet;
    }

    public DataTable NewSendSMS(string Date)
    {
        try
        {
            //string uristring = "http://api.urlsms.com/SendSMS.aspx?UserID=" + "info@perfecteducation.net" + "&Password=" + "newtech1010" + "&SenderID=" + "PERFCT" + "&MsgText=" + strMsgText + "&RecipientMobileNo=" + strRecip;
            //Uri objURI = new Uri(uristring);
            //WebRequest objWebRequest = WebRequest.Create(objURI);
            //WebResponse objWebResponse = objWebRequest.GetResponse();
            //Stream objStream = objWebResponse.GetResponseStream();
            //StreamReader objStreamReader = new StreamReader(objStream);
            //string strHTML = objStreamReader.ReadToEnd();
            //return strHTML;
            DataSet dsDLR = new DataSet();
            DataTable dtDLR = new DataTable();

            Uri objURI = new Uri("http://api.urlsms.com/DeliveryReport.aspx?UserID=modasa_engg@yahoo.co.in&Password=modasa009&Date=" + Date);

            //Uri objURI = new Uri("http://tsms.newtechinfosoft.com/DeliveryReport.aspx?UserID=info@perfecteducation.net&Password=newtech1010&Date=" + Date);
            WebRequest objWebRequest = WebRequest.Create(objURI);
            WebResponse objWebResponse = objWebRequest.GetResponse();
            Stream objStream = objWebResponse.GetResponseStream();
            StreamReader objStreamReader = new StreamReader(objStream);
            string strHTML = objStreamReader.ReadToEnd();

            int iTabInd = strHTML.IndexOf("<table cellspacing");

            if (iTabInd >= 0)
            {
                string strExtract = strHTML.Substring(iTabInd).Replace("\t", "").Replace("\r", "");
                int intTotalLength = strHTML.Length;

                string[] strRows = strExtract.Split(new string[] { "<span id=\"grv_" }, StringSplitOptions.RemoveEmptyEntries);
                int intLen = strRows.Length;
                dsDLR = new DataSet();
                dtDLR = new DataTable();
                dsDLR.Tables.Add(dtDLR);
                dtDLR.Columns.Add(new DataColumn("MessageDateTime", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("SenderIDText", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("MobileNo", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("MessageText", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("DeliveryNumber", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("DeliveryStatusReport", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("DeliveryReport", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("ErrorCode", typeof(string)));

                DataRow drTemp;
                for (int i = 1; i < strRows.Length; i++)
                {
                    //string str2 = strRows[i].Replace("</span>,", "").Substring(strRows[i].IndexOf(">") + 1).Trim();
                    //string str3 = str2.Substring(str2.IndexOf(">") + 1).Replace("</font>", "");
                    //if (str3.ToString() == "Undelivered")
                    //{
                    if (strRows[i].ToLower().Contains("lblmessagedatetime"))
                    {
                        drTemp = dtDLR.NewRow();
                        drTemp["MessageDateTime"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        drTemp["SenderIDText"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        drTemp["MobileNo"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        drTemp["MessageText"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        drTemp["DeliveryNumber"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        string str = strRows[i].Replace("</span>,", "").Substring(strRows[i].IndexOf(">") + 1).Trim();
                        drTemp["DeliveryStatusReport"] = str.Substring(str.IndexOf(">") + 1).Replace("</font>", "");
                        i++;
                        string strDLR = strRows[i].Replace("</span>", "").Substring(strRows[i].IndexOf(">") + 1).Trim().Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "").Replace("<td>", "").Trim();

                        drTemp["DeliveryReport"] = strDLR;
                        string strErrorCode = "";
                        if (strDLR.Trim().Length > 0)
                        {
                            if (strDLR.IndexOf("err:") > 0)
                            {
                                strErrorCode = strDLR.Substring(strDLR.IndexOf("err:") + 4, 3);
                                drTemp["ErrorCode"] = strErrorCode;
                            }
                        }
                        dtDLR.Rows.Add(drTemp);
                    }
                }
            }
            return dtDLR;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public DataTable NewUndeliveredSMS(string Date)
    {
        try
        {
            //string uristring = "http://api.urlsms.com/SendSMS.aspx?UserID=" + "info@perfecteducation.net" + "&Password=" + "newtech1010" + "&SenderID=" + "PERFCT" + "&MsgText=" + strMsgText + "&RecipientMobileNo=" + strRecip;
            //Uri objURI = new Uri(uristring);
            //WebRequest objWebRequest = WebRequest.Create(objURI);
            //WebResponse objWebResponse = objWebRequest.GetResponse();
            //Stream objStream = objWebResponse.GetResponseStream();
            //StreamReader objStreamReader = new StreamReader(objStream);
            //string strHTML = objStreamReader.ReadToEnd();
            //return strHTML;
            DataSet dsDLR = new DataSet();
            DataTable dtDLR = new DataTable();

            Uri objURI = new Uri("http://api.urlsms.com/DeliveryReport.aspx?UserID=reubs2@rediffmail.com&Password=newtech009&Date=" + Date);

            //Uri objURI = new Uri("http://tsms.newtechinfosoft.com/DeliveryReport.aspx?UserID=info@perfecteducation.net&Password=newtech1010&Date=" + Date);
            WebRequest objWebRequest = WebRequest.Create(objURI);
            WebResponse objWebResponse = objWebRequest.GetResponse();
            Stream objStream = objWebResponse.GetResponseStream();
            StreamReader objStreamReader = new StreamReader(objStream);
            string strHTML = objStreamReader.ReadToEnd();

            int iTabInd = strHTML.IndexOf("<table cellspacing");

            if (iTabInd >= 0)
            {
                string strExtract = strHTML.Substring(iTabInd).Replace("\t", "").Replace("\r", "");
                int intTotalLength = strHTML.Length;

                string[] strRows = strExtract.Split(new string[] { "<span id=\"grv_" }, StringSplitOptions.RemoveEmptyEntries);
                int intLen = strRows.Length;
                dsDLR = new DataSet();
                dtDLR = new DataTable();
                dsDLR.Tables.Add(dtDLR);
                dtDLR.Columns.Add(new DataColumn("MessageDateTime", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("SenderIDText", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("MobileNo", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("MessageText", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("DeliveryNumber", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("DeliveryStatusReport", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("DeliveryReport", typeof(string)));
                dtDLR.Columns.Add(new DataColumn("ErrorCode", typeof(string)));

                DataRow drTemp;
                for (int i = 1; i < strRows.Length; i++)
                {
                    //string str2 = strRows[i].Replace("</span>,", "").Substring(strRows[i].IndexOf(">") + 1).Trim();
                    //string str3 = str2.Substring(str2.IndexOf(">") + 1).Replace("</font>", "");
                    //if (str3.ToString() == "Undelivered")
                    //{
                    if (strRows[i].ToLower().Contains("lblmessagedatetime"))
                    {
                        drTemp = dtDLR.NewRow();
                        drTemp["MessageDateTime"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        drTemp["SenderIDText"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        drTemp["MobileNo"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        drTemp["MessageText"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        drTemp["DeliveryNumber"] = strRows[i].Substring(strRows[i].IndexOf(">") + 1).Replace("</span>,", "").Trim();
                        i++;
                        string str = strRows[i].Replace("</span>,", "").Substring(strRows[i].IndexOf(">") + 1).Trim();
                        drTemp["DeliveryStatusReport"] = str.Substring(str.IndexOf(">") + 1).Replace("</font>", "");
                        i++;
                        string strDLR = strRows[i].Replace("</span>", "").Substring(strRows[i].IndexOf(">") + 1).Trim().Replace("</td>", "").Replace("</tr>", "").Replace("<tr>", "").Replace("<td>", "").Trim();

                        drTemp["DeliveryReport"] = strDLR;
                        string strErrorCode = "";
                        if (strDLR.Trim().Length > 0)
                        {
                            if (strDLR.IndexOf("err:") > 0)
                            {
                                strErrorCode = strDLR.Substring(strDLR.IndexOf("err:") + 4, 3);
                                drTemp["ErrorCode"] = strErrorCode;
                            }
                        }

                        string temp = drTemp.ItemArray[5].ToString();
                        if (temp == "Undelivered")
                        {
                            dtDLR.Rows.Add(drTemp);
                        }
                    }
                }
            }
            return dtDLR;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
