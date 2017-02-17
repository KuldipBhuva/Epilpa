<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Manage_Members.aspx.cs" Inherits="Admin_Manage_Members"
    EnableEventValidation="false" %>

<%@ Register Src="Date.ascx" TagName="Date" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:: Administrator Zonel ::</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <script type="text/javascript">
        debugger;
        function checkDate() {

            debugger;

            var From = document.getElementById('<%=dtRegFrom.ClientID%>').value;
            var To = document.getElementById('<%=dtRegTo.ClientID %>').value;

            if (Date.parse(From) > Date.parse(To)) {

                alert("You cannot select Registration Date greater than Expiry Date");
                document.getElementById('dtRegFrom').value = "";

                return false;
            }
        }
        //            if (From != '') {
        //                
        //                if (FromDate > new Date()) {
        //                    alert("You cannot select From Date future than today!");
        //                    document.getElementById('dtRegFrom').value = "";
        //                    return false;
        //                }
        //            }

        //            if (To != '') {
        //                
        //                if (ToDate > new Date()) {
        //                    alert("You cannot select To Date future than today!");
        //                    document.getElementById('dtRegTo').value = "";
        //                   

        //                     
        //                    
        //                    return false;
        //  
        //            FromDate = new Date(From);             
        //            ToDate = new Date(To);
           
       
    </script>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
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
                                                    <li><a class="active" href="Manage_Members.aspx"><span>Manage Members</span></a></li>
                                                    <li><a href="Bulliten.aspx"><span>Bulletin</span></a></li>
                                                    <li><a href="Annual_Reports.aspx"><span>Annual Reports</span></a></li>
                                                    <li><a href="Change_Password.aspx"><span>Change Password </span></a></li>
                                                    <li><a href="EventSms.aspx"><span>Events SMS </span></a></li>
                                                    <li><a href="Undeliver.aspx"><span>SMS Un-Delivered</span></a></li>
                                                    <li><a href="BulkMail.aspx"><span>Bulk Mail </span></a></li>
                                                    <li><a href="InfoSms.aspx"><span>Info SMS </span></a></li>
                                                    <%-- <li><a href="ExpDate.aspx"><span>Expiry-Date </span></a></li>--%>
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
                                                                                Manage Members
                                                                            </td>
                                                                            <td align="right">
                                                                            <a href="../FRegistration.aspx">Add New Member</a>
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
                                                                    <asp:Panel ID="pnlEmode" runat="server" Width="100%" Visible="false">
                                                                        <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="border2">
                                                                            <tr>
                                                                                <td class="blacktext" colspan="2" height="40" bgcolor="#e2ebf0">
                                                                                    Member Details&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    Member Photo
                                                                                </td>
                                                                                <td align="center">
                                                                                    &nbsp;Member Photo Identity&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right" class="style1">
                                                                                    <div>
                                                                                        <div id="Div2">
                                                                                            <asp:Image ID="Image2" runat="server" Height="170px" Width="180px" />
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                                <td align="center" class="style1">
                                                                                    <div>
                                                                                        <div id="Div3">
                                                                                            <asp:Image ID="Image1" runat="server" Height="170px" Width="180px" />
                                                                                        </div>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" height="10">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <strong>Registration ID :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:Label ID="lblSr" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <strong>Member ID :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblMemberID" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <strong>Member Name :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblMemberName" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <strong>Member Address :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblAddress" runat="server" Height="22px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <strong>Member Email ID :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox runat="server" ID="lblEmailID"></asp:TextBox>
                                                                                    <%--<asp:Label ID="lblEmailID" runat="server" Text="Label"></asp:Label>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <strong>Member Type :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:DropDownList ID="lblMemberType" runat="server">
                                                                                        <asp:ListItem Selected="True">Ordinary</asp:ListItem>
                                                                                        <asp:ListItem>Associate</asp:ListItem>
                                                                                        <asp:ListItem>Life Membership</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Sex :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:DropDownList class="box" ID="ddlSex" runat="server">
                                                                                        <asp:ListItem>Male</asp:ListItem>
                                                                                        <asp:ListItem>Female</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Company :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblCompany" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Office Address :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblOAddress" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Year Of Start :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblYearOfStart" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Nature Of Activity :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblNatureOfActivity" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Phone Office :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox runat="server" ID="lblPhoneOffice"></asp:TextBox>
                                                                                    <%--<asp:Label ID="lblPhoneOffice" runat="server" Text="Label"></asp:Label>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Fax :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox runat="server" ID="lblFax"></asp:TextBox>
                                                                                    <%--<asp:Label ID="lblFax" runat="server" Text="Label"></asp:Label>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Phone Residence :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox runat="server" ID="lblResidence"></asp:TextBox>
                                                                                    <%--<asp:Label ID="lblResidence" runat="server" Text="Label"></asp:Label>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Mobile :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox runat="server" ID="lblMobile"></asp:TextBox>
                                                                                    <%--<asp:Label ID="lblMobile" runat="server" Text="Label"></asp:Label>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Admin Fee Rs :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblAdFeeRs" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Member Fee Rs :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblMeFeeRs" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Account Year :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="lblAcYear" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Active :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:DropDownList ID="ddlActive" runat="server" OnSelectedIndexChanged="ddlActive_SelectedIndexChanged">
                                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                                        <asp:ListItem>No</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Registration From :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="dtRegFrom" runat="server" onchange="checkDate(this);" />
                                                                                    <img src="images/calendar-2-icon.png" id="ImgFrom" runat="server" height="30" width="30"
                                                                                        alt="" />
                                                                                    <asp:CalendarExtender ID="CalendarExtenderFrom" runat="server" PopupButtonID="ImgFrom"
                                                                                        TargetControlID="dtRegFrom" TodaysDateFormat="MM dd yyyy" Format="MM dd yyyy"
                                                                                        Enabled="True">
                                                                                    </asp:CalendarExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="trexpdate" runat="server" visible="true">
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Registration To :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="dtRegTo" runat="server" onchange="checkDate(this);" />
                                                                                    <img src="images/calendar-2-icon.png" id="ImgTo" runat="server" height="30" width="30"
                                                                                        alt="" />
                                                                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImgTo"
                                                                                        TargetControlID="dtRegTo" TodaysDateFormat="MM dd yyyy" Format="MM dd yyyy" Enabled="True">
                                                                                    </asp:CalendarExtender>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" valign="top" width="23%">
                                                                                    <strong>Premium Member:</strong>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="RBLpremium" runat="server" RepeatDirection="Horizontal"
                                                                                        Style="margin-top: 0px">
                                                                                        <asp:ListItem>Yes</asp:ListItem>
                                                                                        <asp:ListItem Selected="True">No</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <td>
                                                                    </td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="23%" align="right">
                                                                    &nbsp;
                                                                </td>
                                                                <td width="77%">
                                                                    <asp:ImageButton ID="btnSubmit" CausesValidation="True" CommandName="Update" runat="server"
                                                                        ImageUrl="images/submit.jpg" OnClick="btnSubmit_Click" Height="19px" Width="63px" />
                                                                    <asp:ImageButton ID="btnCancle" CausesValidation="False" CommandName="Cancel" runat="server"
                                                                        ImageUrl="images/cancel.jpg" OnClick="btnCancle_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="10">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCredit" runat="server" Text="Label" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView align="center" ID="GVMembers" CssClass="border2" AutoGenerateColumns="false"
                                                            DataKeyNames="UserID" CellPadding="3" Width="98%" runat="server" OnRowCommand="GVMembers_RowCommand"
                                                            OnSelectedIndexChanged="GVMembers_SelectedIndexChanged" OnRowDataBound="GVMembers_RowDataBound">
                                                            <Columns>
                                                                <asp:BoundField DataField="UserID" HeaderText="Member ID" />
                                                                <asp:BoundField DataField="UName" HeaderText="Member Name" />
                                                                <asp:BoundField DataField="UEmailID" HeaderText="Email ID" />
                                                                <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                                                                <%-- <asp:BoundField DataField="BankName" HeaderText="Bank Name" />
                                          <asp:BoundField DataField="ChequeNo" HeaderText="Cheque No" />--%>
                                                                <asp:BoundField DataField="UserType" HeaderText="User Type" />
                                                                <asp:TemplateField HeaderText="Active">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Lableid" runat="server" Text='<%# Eval("Active") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="RegDate" HtmlEncode="False" DataFormatString="{0:dd/MMM/yyyy}"
                                                                    HeaderText="Registration Date" />
                                                                <asp:BoundField DataField="ExpDate" HtmlEncode="False" DataFormatString="{0:dd/MMM/yyyy}"
                                                                    HeaderText="Expiry Date" />
                                                                <%--    <asp:BoundField DataField="PaymentType" HeaderText="Payment Type" />--%>
                                                                <asp:BoundField DataField="Updated_date" HtmlEncode="False" DataFormatString="{0:dd/MMM/yyyy}"
                                                                    HeaderText="Updated Date" />
                                                                <asp:TemplateField HeaderText="ACTION">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LbtnEdit" runat="server" CommandName="Select" class="link" CausesValidation="False">Edit</asp:LinkButton>
                                                                        &nbsp;|&nbsp;
                                                                        <asp:LinkButton ID="LbtnDelete" runat="server" CommandName="Kdelete" CommandArgument='<%# Eval("UserID") %>'
                                                                            class="link" OnClientClick='return confirm("Are you sure ?")' CausesValidation="False">Delete</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle BackColor="#B7CFE3" HorizontalAlign="Left" Height="30px" />
                                                        </asp:GridView>
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
                <td>
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="Exportexcel" runat="server" ImageUrl="~/images/excel.jpg" OnClick="Exportexcel_Click" />
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
        </td> </tr> </table>
    </div>
    </form>
</body>
</html>
