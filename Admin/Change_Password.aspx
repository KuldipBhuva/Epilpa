<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Change_Password.aspx.cs"
    Inherits="Change_Password" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:: Administrator Zonel ::</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript1.2">
function Check()
{
    
    
    if(document.getElementById("txtCurrentPassword").value=="")
	{
		alert("Enter Current Password");
		return false;
	}
    if(document.getElementById("txtCurrentPassword").value!=document.getElementById("HiddenField1").value)
	{
		alert("Enter Correct Current Password");
		return false;
	}
	if(document.getElementById("txtNewPassword").value=="")
	{
		alert("Enter New Password");
		return false;
	}
	if(document.getElementById("txtConfirmNewPassword").value=="")
	{
		alert("Confirm New Password");
		return false;
	}
	if(document.getElementById("txtNewPassword").value!=document.getElementById("txtConfirmNewPassword").value)
	{
		alert("New Password And Confirm New Password Must Be A Same");
		return false;
	}
	
}
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td valign="top">
                <table width="1000" height="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="10" valign="top">
                            <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="textlogin">
                                <tr>
                                    <td width="200" height="10" valign="top">
                                        Welcome, <span class="colour2">Admin </span>
                                    </td>
                                    <td align="center">
                                        <span class="BigText">Administrator Zone</span>
                                    </td>
                                    <td width="200" align="right" valign="top">
                                        <a href="logout.aspx"><span class="colour2">logout </span></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10" align="center" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="10" align="center" valign="top">
                                        <div id="head-mainmenu">
                                            <ul>
                                                <li><a href="Manage_Members.aspx"><span>Manage Members</span></a> </li>
                                                <li><a href="Bulliten.aspx"><span>Bulletin</span></a> </li>
                                                <li><a href="Annual_Reports.aspx"><span>Annual Reports</span></a> </li>
                                                <li><a class="active" href="Change_Password.aspx"><span>Change Password </span></a>
                                                </li>
                                                <li><a href="EventSms.aspx"><span>Events SMS </span></a></li>
                                                 <li><a href="Undeliver.aspx"><span>SMS Un-Delivered</span></a></li>
                                                        <li><a href="BulkMail.aspx"><span>Bulk Mail </span></a></li>
                                                       <li><a href="InfoSms.aspx"><span>Info SMS </span></a>
                                                        <%--<li><a href="ExpDate.aspx"><span>Members Expiry-Date </span></a></li>--%>
                                            </ul>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" align="left" valign="top">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="contenttable">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                        <tr>
                                                            <td height="25" class="head_title">
                                                                <table width="98%" border="0" align="left" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td class="head_title">
                                                                        </td>
                                                                        <td align="right">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <table align="center" border="0" cellpadding="3" cellspacing="0" class="border2"
                                                                    width="90%">
                                                                    <tr>
                                                                        <td align="center" colspan="2" height="10">
                                                                            <asp:label id="lbldupi" runat="server" font-bold="True" visible="False"></asp:label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="23%">
                                                                            * CURRENT PASSWORD :
                                                                        </td>
                                                                        <td width="77%">
                                                                            <asp:textbox id="txtCurrentPassword" runat="server" maxlength="15" textmode="Password">
                                                                            </asp:textbox>
                                                                            <asp:hiddenfield id="HiddenField1" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="color: #000000">
                                                                        <td align="right" width="23%">
                                                                            * NEW PASSWORD :
                                                                        </td>
                                                                        <td width="77%">
                                                                            <asp:textbox id="txtNewPassword" runat="server" maxlength="15" textmode="Password">
                                                                            </asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" valign="top" width="23%">
                                                                            * CONFIRM NEW PASSWORD :
                                                                        </td>
                                                                        <td width="77%">
                                                                            <asp:textbox id="txtConfirmNewPassword" runat="server" maxlength="15" textmode="Password">
                                                                            </asp:textbox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right" width="23%">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td width="77%">
                                                                            <asp:imagebutton id="ImageButton1" runat="server" causesvalidation="True" imageurl="images/submit.jpg"
                                                                                onclick="InsertButton_Click" onclientclick="return Check();" />
                                                                            <asp:imagebutton id="ImageButton2" runat="server" causesvalidation="False" imageurl="images/cancel.jpg"
                                                                                onclick="InsertCancelButton_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="10">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="75" valign="bottom">
                            <table width="1000" border="0" align="center" cellpadding="0" cellspacing="5" class="bottomtable">
                                <tr>
                                    <td align="right" class="content-small">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="content-small">
                                        Copyright &copy; 2008-2009 <span class="colour2">Newtech infosoft Pvt. Ltd.</span>.
                                        All rights reserved.
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
