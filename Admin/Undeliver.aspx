<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Undeliver.aspx.cs" Inherits="Admin_Undeliver" %>

<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:: Administrator Zonel ::</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function ImgDOB_onclick() {


        }

// ]]>
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="TK" runat="server">
    </asp:ToolkitScriptManager>
    <div>
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
                                                    <li><a href="Manage_Members.aspx"><span>Manage Members</span></a></li>
                                                    <li><a href="Bulliten.aspx"><span>Bulletin</span></a></li>
                                                    <li><a href="Annual_Reports.aspx"><span>Annual Reports</span></a></li>
                                                    <li><a href="Change_Password.aspx"><span>Change Password </span></a></li>
                                                    <li><a href="EventSms.aspx"><span>Events SMS </span></a></li>
                                                    <li><a class="active href="Undeliver.aspx"><span>SMS Un-Delivered</span></a></li>
                                                    <li><a href="BulkMail.aspx"><span>Bulk Mail </span></a></li>
                                                    <li><a href="InfoSms.aspx"><span>Info SMS </span></a></li>
                                                    <%-- <li><a href="ExpDate.aspx"><span>Members Expiry-Date </span></a></li>--%>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10" align="left" valign="top">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="contenttable">
                                                <div align="center" style="width: 100%">
                                                    <table align="center" width="100%">
                                                        <tr>
                                                            <td align="center">
                                                                <table align="center" width="60%" style="background-color: #F0F0E0">
                                                                    <tr>
                                                                        <td align="center" style="font-size: 15px; font-weight: bold">
                                                                            Un-delivered Report
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="trdate" runat="server">
                                                                        <td align="center">
                                                                            Date:
                                                                            <asp:TextBox ID="txtDateCalender" runat="server" CssClass="textbox" OnTextChanged="txtDateCalender_TextChanged">
                                                                            </asp:TextBox>
                                                                            <asp:ImageButton ID="imgbtnCal" ImageUrl="images/calendar-2-icon.png" runat="server"
                                                                                Height="16px" OnClick="imgbtnCal_Click" />
                                                                            <asp:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDateCalender"
                                                                                PopupButtonID="imgbtnCal" TodaysDateFormat="yyyyMMdd" Format="dd/MM/yyyy">
                                                                            </asp:CalendarExtender>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Button ID="btnGo" runat="server" CssClass="Save" Text="Go" OnClick="btnGo_Click" />
                                                                            <asp:Button ID="btnViewCancel" runat="server" CssClass="Save" Text="Cancel" OnClick="btnViewCancel_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:Label ID="lblMsg" runat="server" Style="color: Red"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <div>
                                                                                <asp:GridView ID="GrdMsgStatus" runat="server" AutoGenerateColumns="false" EmptyDataText="Data Not Exist"
                                                                                    EmptyDataRowStyle-ForeColor="Red" EmptyDataRowStyle-Font-Size="Medium">
                                                                                    <Columns>
                                                                                        <asp:BoundField HeaderText="Message DateTime" DataField="MessageDateTime" />
                                                                                        <%--<asp:BoundField HeaderText="SenderIDText" DataField="SenderIDText" />--%>
                                                                                        <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                                                                                        <%--<asp:BoundField HeaderText="MessageText" DataField="MessageText" />--%>
                                                                                        <%--<asp:BoundField HeaderText="DeliveryNumber" DataField="DeliveryNumber" />--%>
                                                                                        <asp:BoundField HeaderText="Delivery Status Report" DataField="DeliveryStatusReport" />
                                                                                        <%--<asp:BoundField HeaderText="DeliveryReport" DataField="DeliveryReport" />--%>
                                                                                        <asp:BoundField HeaderText="Error Code" DataField="ErrorCode" />
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%--<td align="center" colspan="2">
                                <asp:GridView ID="grdStudentRecord" runat="server" Width="500px" AutoGenerateColumns="false"
                                    Visible="false" CssClass="border2">
                                   
                                    <RowStyle HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstudent" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Contact2") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="RollNo" DataField="RollNo" />
                                        <asp:BoundField HeaderText="Student Name" DataField="Stuname" />
                                        <asp:BoundField HeaderText="Mobile No" DataField="Contact2" />
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkStudent" runat="server" AutoPostBack="true" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <%-- <asp:GridView Width="100%" ID="grdAbsentRecord" runat="server" AutoGenerateColumns="false"
                        Visible="false">
                        <Columns>
                            <asp:BoundField HeaderText="Enrollment No" DataField="GR_No" />
                            <asp:BoundField HeaderText="Student_Name" DataField="Student_Name" />
                        </Columns>
                    </asp:GridView>
                            </td>--%>
            </tr>
            <tr>
                <%-- <td align="center" colspan="2">
                                <asp:Label ID="lblDate" runat="server" Font-Bold="true"></asp:Label>
                                <asp:ImageButton ID="ImageButton1" CausesValidation="True" CommandName="Update" runat="server"
                                    ImageUrl="images/submit.jpg" OnClick="btnSubmit_Click" />
                                <asp:ImageButton ID="ImageButton2" CausesValidation="False" CommandName="Cancel"
                                    runat="server" ImageUrl="images/cancel.jpg" OnClick="btnCancle_Click" />
                            </td>--%>
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
    </div>
    </form>
</body>
</html>
