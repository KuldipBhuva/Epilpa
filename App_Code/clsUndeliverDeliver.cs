using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Xml;

using System.Web;

/// <summary>
/// Summary description for clsUndeliverDeliver
/// </summary>
public class clsUndeliverDeliver
{
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

            Uri objURI = new Uri("http://api.urlsms.com/DeliveryReport.aspx?UserID=info@epilpa.org&Password=epilpa009&Date=" + Date);

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