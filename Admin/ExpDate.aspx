<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExpDate.aspx.cs" Inherits="Admin_ExpDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    <script type="text/javascript">
        var TotalChkBx;
        var Counter;

        window.onload = function () {
            //Get total no. of CheckBoxes in side the GridView.
            TotalChkBx = parseInt('<%= this.grdMuser.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
       document.getElementById('<%= this.grdMuser.ClientID %>');
            var TargetChildControl = "chkStudent";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

        //Reset Counter
        Counter = CheckBox.checked ? TotalChkBx : 0;
    }

    function ChildClick(CheckBox, HCheckBox) {
        //get target control.
        var HeaderCheckBox = document.getElementById(HCheckBox);

        //Modifiy Counter; 
        if (CheckBox.checked && Counter < TotalChkBx)
            Counter++;
        else if (Counter > 0)
            Counter--;

        //Change state of the header CheckBox.
        if (Counter < TotalChkBx)
            HeaderCheckBox.checked = true;
        else if (Counter == TotalChkBx)
            HeaderCheckBox.checked = false;
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
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
                                                     <li><a href="Undeliver.aspx"><span>SMS Un-Delivered</span></a></li>
                                                        <li><a href="BulkMail.aspx"><span>Bulk Mail </span></a></li>
                                                         <li> <a href="InfoSms.aspx"><span>Info SMS </span></a></li>
                                                   <%-- <li><a class="active" href="ExpDate.aspx"><span>Members Expiry-Date </span></a></li>--%>

                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10" align="left" valign="top">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="contenttable"
                                                align="center">
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0" align="center">
                                                            <tr>
                                                                <td height="25" class="head_title">
                                                                    <table border="0" align="left" cellpadding="0" cellspacing="0" style="width: 98%">
                                                                        <tr>
                                                                            <td class="head_title">
                                                                                Events SMS
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;List Of Members (Membership Expired With in 30 days)
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:panel id="pnl" runat="server" width="200%">
                                                                    </asp:panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <asp:gridview id="grdMuser" runat="server" width="500px" autogeneratecolumns="false"
                                                                        visible="false" cssclass="EU_DataTable"  EmptyDataText="Sorry No Data Exist">
                                                                        <%-- OnRowDataBound="grdStudentRecord_RowDataBound"
                          OnRowCreated="grdStudentRecord_RowCreated"--%>
                                                                        <rowstyle horizontalalign="Center" />
                                                                        <columns>
                                                                            <asp:TemplateField Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblstudent" runat="server" Text='<%# Eval("UserID") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField Visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="User ID" DataField="UserID" />
                                                                            <asp:BoundField HeaderText="Members Name" DataField="UName" />
                                                                            <asp:BoundField HeaderText="Mobile No" DataField="Mobile" />
                                                                            <asp:TemplateField HeaderText="Select">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkStudent" runat="server" AutoPostBack="true" />
                                                                                    <%-- OnCheckedChanged="chkStudent_CheckChanged"--%>
                                                                                </ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                                                                </HeaderTemplate>
                                                                            </asp:TemplateField>
                                                                        </columns>
                                                                    </asp:gridview>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:imagebutton id="btnSubmit" causesvalidation="True" commandname="Update" runat="server"
                                                                        imageurl="images/submit.jpg" onclick="btnSubmit_Click" />
                                                                    <asp:imagebutton id="btnCancle" causesvalidation="False" commandname="Cancel" runat="server"
                                                                        imageurl="images/cancel.jpg" onclick="btnCancle_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%--   <asp:Panel ID="pnlcategorygrid" runat="server" Visible="false">--%>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <%-- </asp:Panel>--%>
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
        </table>
    </div>
    </form>
</body>
</html>
