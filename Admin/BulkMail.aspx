<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BulkMail.aspx.cs" Inherits="Admin_BulkMail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>:: Administrator Zonel ::</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <style type="text/css">
        .style1
        {
            height: 304px;
        }
        .style3
        {
            height: 304px;
            width: 126px;
        }
        .style4
        {
            width: 126px;
        }
        .regularlink
        {
        }
        .style5
        {
            width: 126px;
            height: 20px;
        }
        .style6
        {
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <script language="javascript" type="text/javascript">
        function CheckAll(oCheckbox) {
            var grdEmail = document.getElementById("<%=grdEmail.ClientID %>");
            for (i = 1; i < grdEmail.rows.length; i++) {
                grdEmail.rows[i].cells[0].getElementsByTagName("INPUT")[0].checked = oCheckbox.checked;
            }
        }
        function openpopup() {

            window.open('selectFile.aspx?pagenm=bulkemail', '_blank', 'toolbar=0,location=0,menubar=0,resizable=0,width=500,height=320');


            return false;
        }

        function SelectAllCheckboxes(obj) {

            var objVal = $(obj).attr('checked');
            var cnt = 0;
            $('#<%=grdEmail.ClientID %>').find("[id*=chkData]").each(function () {

                if (cnt < 100) {

                    $(this).attr('checked', objVal);
                    cnt = parseInt(cnt) + 1;
                }
                else {

                    return false;
                }
            });
            if (objVal == false) {
                $('#<%=lblCount.ClientID %>').text('0');
            }
            else {
                $('#<%=lblCount.ClientID %>').text(cnt);
            }

        }

        function Count() {
            debugger;
            var cnt = 0;
            //            $("#<%=grdEmail.ClientID %> tbody").not('tr');
            $('#<%=grdEmail.ClientID %>').find("input:checkbox").each(function () {
                cnt = cnt + (this.checked ? true : false);
            });
            debugger;
            $('#<%=lblCount.ClientID %>').html(cnt);
        }
        function CheckMax() {
            debugger;
            if ($('#<%=lblCount .ClientID %>').html() > 100) {
                alert("Sorry, You can not mail more than 100 IDs...");
                return false;
            }
        }

        function SelectAll(id) {

        }
        function EmailCount(obj) {
            var cnt = $('#<%=lblCount.ClientID %>').text();
            if ($(obj).attr('checked') == true) {
                cnt = parseInt(cnt) + 1;
            }
            else {
                cnt = parseInt(cnt) - 1;
            }
            $('#<%=lblCount.ClientID %>').text(cnt);
        }
    </script>
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
                                                    <li><a class="active" href="BulkMail.aspx"><span>Bulk Mail </span></a></li>
                                                    <li><a href="InfoSms.aspx"><span>Info SMS </span></a>
                                                        <%--<li><a href="ExpDate.aspx"><span>Members Expiry-Date </span></a></li>--%>
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
                                                                                Bulk E-Mail
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;
                                                                    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="pnl" runat="server" Width="100%">
                                                                        <div style="float: right; background: #fff; border-bottom: 1px solid #cccccc; border-bottom: 1px solid #eee;
                                                                            border-left: 1px solid #ffffff; padding: 0em 0em 0em 0em; margin: 2.0em 5em 0em 0em;">
                                                                        </div>
                                                                        <div class="header">
                                                                            <ul class="breadcrumb">
                                                                                <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
                                                                                <asp:HiddenField ID="hdn" runat="server" />
                                                                            </ul>
                                                                        </div>
                                                                        <div id="DivAddNew" runat="server" style="width: 100%" visible="true">
                                                                            <fieldset class="fieldset">
                                                                                <legend>Email Information</legend>
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Rowtdlbl">
                                                                                            <div class="AlphabetPager">
                                                                                                <asp:Repeater ID="rptAlphabets" runat="server">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" Text='<%#Eval("Value")%>' Visible='<%# !Convert.ToBoolean(Eval("Selected"))%>'
                                                                                                            OnClick="Alphabet_Click" />
                                                                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("Value")%>' Visible='<%# Convert.ToBoolean(Eval("Selected"))%>' />
                                                                                                    </ItemTemplate>
                                                                                                </asp:Repeater>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td>
                                                                                            &nbsp;&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 10px;">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Rowtdlbl" align="center" colspan="2">
                                                                                            <asp:GridView ID="grdEmail" runat="server" Width="80%" AutoGenerateColumns="false"
                                                                                                CellPadding="5" CssClass="EU_DataTable" EmptyDataText="No Data Exists...!!!!!"
                                                                                                AllowPaging="true" OnPageIndexChanging="grdEmail_PageIndexChanging" PageSize="50">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField>
                                                                                                        <HeaderTemplate>
                                                                                                            Select All<br />
                                                                                                            <asp:CheckBox ID="chkHdr" onclick="CheckAll(this)" runat="server" />
                                                                                                        </HeaderTemplate>
                                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:CheckBox ID="chkData" CssClass="chk" onclick="javascript:EmailCount(this);"
                                                                                                                runat="server" />
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Name">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("UName") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="40%" HorizontalAlign="Left" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Email">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("UEmailID") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="30%" />
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Premium Member?">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Premium_Member") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <ItemStyle Width="10%" />
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <HeaderStyle BackColor="#B7CFE3" HorizontalAlign="Left" Height="30px" />
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="Rowtdlbl" align="center" colspan="2">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td runat="server" id="tdCount" colspan="2" visible="false">
                                                                                            Selected :
                                                                                            <asp:Label ID="lblCount" runat="server" Visible="false"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="labelStatus" runat="server" Text=""></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </fieldset>
                                                                        </div>
                                                                        <div id="DivGrid" runat="server" visible="true">
                                                                            <table>
                                                                                <tr>
                                                                                    <td class="style5">
                                                                                    </td>
                                                                                    <td class="style6">
                                                                                        <cc1:Editor ID="Editor2" runat="server" Visible="false" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style4">
                                                                                        Email Subject:
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtSubject" runat="server" Height="25px" Width="386px">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style4">
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="386px" Visible="false">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style4">
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="386px" Visible="false">
                                                                                        </asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style3">
                                                                                        Description:
                                                                                    </td>
                                                                                    <td class="style1">
                                                                                        <%--<cc1:Editor ID="Editor1" runat="server" />--%>
                                                                                        <asp:TextBox ID="Editor1" runat="server" TextMode="MultiLine" Height="201px" 
                                                                                            Width="371px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:Label ID="lblAttach" runat="server" CssClass="bigblue"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:LinkButton ID="Attachment" runat="server" CssClass="regularlink" Width="125px">Attachment</asp:LinkButton>
                                                                                        <asp:FileUpload ID="fuAttachment" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="style4">
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        <asp:ImageButton ID="btnSubmit" runat="server" CausesValidation="True" CommandName="Update"
                                                                                            ImageUrl="images/submit.jpg" OnClick="btnSubmit_Click" 
                                                                                            style="height: 19px" />
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
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
                                                                <td align="center">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    &nbsp;
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
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
