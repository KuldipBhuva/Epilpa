<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InfoSms.aspx.cs" Inherits="Admin_InfoSms" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            TotalChkBx = parseInt('<%= this.griduser.Rows.Count %>');

            //Get total no. of checked CheckBoxes in side the GridView.
            Counter = 0;
        }

        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
       document.getElementById('<%= this.griduser.ClientID %>');
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
    <script type="text/javascript">
        function txtCounters(id, max_length, myelement) {
            counter = document.getElementById(id);
            field = myelement.value;
            field_length = field.length;
            if (field_length <= max_length) {
                //Calculate remaining characters
                remaining_characters = max_length - field_length;
                //Update the counter on the page
                counter.innerHTML = remaining_characters;
            }
            myelement.value = myelement.value.substring(0, max_length);
        } </script>
    <script type="text/javascript">
        // WRITE THE VALIDATION SCRIPT IN THE HEAD TAG.
        function isNumber(evt) {
            var iKeyCode = (evt.which) ? evt.which : evt.keyCode
            if (iKeyCode != 46 && iKeyCode > 31 && (iKeyCode < 48 || iKeyCode > 57))
                return false;

            return true;
        }    
    </script>
</head>
<body>
   <form id="form1" runat="server">
    <div>
        <table align="center" width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10" valign="top">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="textlogin">
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
                                                    <li><a href="Change_Password.aspx"><span>Events SMS </span></a></li>
                                                    <li><a href="Undeliver.aspx"><span>SMS Un-Delivered</span></a>
                                                        <li><a href="BulkMail.aspx"><span>Bulk Mail </span></a>
                                                         <li><a  class="active"  href="InfoSms.aspx"><span>Info SMS </span></a>
                                                            <%-- <li><a href="ExpDate.aspx"><span>Members Expiry-Date </span></a></li>--%>
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
                                                                                Information SMS
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="pnl" runat="server" Width="100%">
                                                                        <table width="290%" border="0" align="center" cellpadding="3" cellspacing="0" class="border2">
                                                                            <tr>
                                                                                <td class="blacktext" colspan="2" height="40" bgcolor="#e2ebf0">
                                                                                    <asp:Label ID="lblPnlTitle" runat="server" Font-Bold="True"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" height="10">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="style1">
                                                                                                Entry Date
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="txtDate" runat="server" CssClass="Text-control" Enabled="false">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="style1">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="Text-control" Enabled="false"
                                                                                        Visible="false">
                                                                                    </asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" valign="top" align="right">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td class="style1">
                                                                                                Message:
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <%--<asp:TextBox ID="txtDetails" runat="server" CssClass="Text-control" Enabled="true"
                                                                                        Height="80px" TextMode="MultiLine" Width="257px" onkeyup="javascript:txtCounters('txtCounter',100,this)"
                                                                                        MaxLength="100">
                                                                                    </asp:TextBox>
                                                                                    <div id="txtCounter">
                                                                                        <b>107</b></div>
                                                                                    characters remaining.--%>
                                                                                    <asp:TextBox ID="txtDetails" runat="server" CssClass="Text-control" Enabled="true"
                                                                                        Height="80px" TextMode="MultiLine" Width="257px"
                                                                                        MaxLength="100">
                                                                                    </asp:TextBox>
                                                                                    
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    &nbsp;</td>
                                                                                <td>
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                              <tr>
                                                                                <td align="right">
                                                                                    Select Category:
                                                                                </td>
                                                                                <td class="style2">
                                                                                    <asp:DropDownList ID="ddlCat" runat="server" Width="200px" 
                                                                                        onselectedindexchanged="ddlCat_SelectedIndexChanged" style="height: 22px" 
                                                                                        AutoPostBack="True">
                                                                                        <asp:ListItem Value="All">--All--</asp:ListItem>
                                                                                        <asp:ListItem Value="Ordinary ">Ordinary Member</asp:ListItem>
                                                                                        <asp:ListItem Value="Life Membership">Life Member</asp:ListItem>
                                                                                        <asp:ListItem Value="Associate">Associate Member</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right">
                                                                                    &nbsp;</td>
                                                                                <td>
                                                                                    &nbsp;</td>
                                                                            </tr>
                                                                            
                                                                            <table align="center" width="190%" style="background-color: #F0F0E0">
                                                                                <tr>
                                                                                    <td align="left" style="font-size: 15px; font-weight: bold">
                                                                                        Message
                                                                                        <asp:LinkButton ID="lnkView" runat="server" Text="View" OnClick="lnkView_Click" Font-Underline="false">
                                                                                        </asp:LinkButton>
                                                                                        <asp:Label ID="lblCredit" runat="server" Style="color: Red"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" style="font-size: 15px; font-weight: bold">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" style="font-size: 15px; font-weight: bold">
                                                                                        <asp:TextBox ID="txtMessage" Font-Size="14px" Font-Bold="true" runat="server" TextMode="MultiLine"
                                                                                            Enabled="false" Width="90%" Height="100px" Style="resize: none" CssClass="Text-Control">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="77%">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" height="10" align="center">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" colspan="2">
                                                                    <asp:GridView ID="griduser" runat="server" Width="500px" AutoGenerateColumns="false"
                                                                        Visible="false" CssClass="EU_DataTable" AllowPaging="false" OnPageIndexChanging="griduser_PageIndexChanging">
                                                                        <RowStyle HorizontalAlign="Center" />
                                                                        <Columns>
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
                                                                            <asp:BoundField HeaderText="Member ID" DataField="UserID" />
                                                                            <asp:BoundField HeaderText="Member Name" DataField="UName" />
                                                                            <asp:BoundField HeaderText="Mobile No" DataField="Mobile" />
                                                                            <asp:BoundField HeaderText="Premium Member?" DataField="Premium_Member" />
                                                                            <asp:TemplateField HeaderText="Select">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkStudent" runat="server" />
                                                                                    <%-- OnCheckedChanged="chkStudent_CheckChanged"--%>
                                                                                </ItemTemplate>
                                                                                <HeaderTemplate>
                                                                                    <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server" />
                                                                                </HeaderTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#B7CFE3" HorizontalAlign="Left" Height="30px" />
                                                                    </asp:GridView>
                                                                    <%-- <asp:GridView Width="100%" ID="grdAbsentRecord" runat="server" AutoGenerateColumns="false"
                        Visible="false">
                        <Columns>
                            <asp:BoundField HeaderText="Enrollment No" DataField="GR_No" />
                            <asp:BoundField HeaderText="Student_Name" DataField="Student_Name" />
                        </Columns>
                    </asp:GridView>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    <asp:ImageButton ID="btnSubmit" CausesValidation="True" CommandName="Update" runat="server"
                                                                        ImageUrl="images/submit.jpg" OnClick="btnSubmit_Click" 
                                                                        style="height: 19px" />
                                                                    <asp:ImageButton ID="btnCancle" CausesValidation="False" CommandName="Cancel" runat="server"
                                                                        ImageUrl="images/cancel.jpg" OnClick="btnCancle_Click" />
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
                        <tr>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
