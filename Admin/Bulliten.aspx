<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="Bulliten.aspx.cs"
    Inherits="Admin_Bulliten" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: Administrator Zonel ::</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
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
                                                    <li><a class="active" href="Bulliten.aspx"><span>Bulletin</span></a></li>
                                                    <li><a href="Annual_Reports.aspx"><span>Annual Reports</span></a></li>
                                                    <li><a href="Change_Password.aspx"><span>Change Password </span></a></li>
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
                                                                                Master Bulletin
                                                                            </td>
                                                                            <td align="right">
                                                                                <asp:HiddenField ID="HFCommand" runat="server" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="Lnkcategory" runat="server" class="titlefont" OnClick="Lnkcategory_Click">Add Category</asp:LinkButton>
                                                                            </td>
                                                                            <td>
                                                                                <asp:LinkButton ID="LBAdd" runat="server" class="titlefont" OnClick="LBAdd_Click">Add New</asp:LinkButton>
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
                                                                        <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="border2">
                                                                            <tr>
                                                                                <td class="blacktext" colspan="2" height="40" bgcolor="#e2ebf0">
                                                                                    <asp:Label ID="lblPnlTitle" runat="server" Font-Bold="True"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" height="10">
                                                                                    <asp:GridView align="center" ID="gvmemberEmail" CssClass="border2" AutoGenerateColumns="false"
                                                                                        CellPadding="3" Width="98%" runat="server" Visible="false">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="E-Mail">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblemail" runat="server" Text='<%# Eval("UEmailID") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle Width="10%" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <HeaderStyle BackColor="#B7CFE3" HorizontalAlign="Left" Height="30px" />
                                                                                    </asp:GridView>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    Bulletin<strong>Title :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="txtBulletinTitle" runat="server">
                                                                                    </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBulletinTitle"
                                                                                        ErrorMessage="*">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" valign="top" align="right">
                                                                                    Bulletin<strong>Description :</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:FileUpload ID="FUBuletinFile" runat="server" EnableViewState="False" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FUBuletinFile"
                                                                                        ErrorMessage="*">
                                                                                    </asp:RequiredFieldValidator>
                                                                                    <asp:HyperLink ID="hpfile" runat="server" Target="_blank">
                                                                                    </asp:HyperLink>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:ImageButton ID="btnSubmit" CausesValidation="True" CommandName="Update" runat="server"
                                                                                        ImageUrl="images/submit.jpg" OnClick="btnSubmit_Click" Style="height: 19px" />
                                                                                    <asp:ImageButton ID="btnCancle" CausesValidation="False" CommandName="Cancel" runat="server"
                                                                                        ImageUrl="images/cancel.jpg" OnClick="btnCancle_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" height="10" align="center">
                                                                                    <asp:Label ID="lblinsert" runat="server" Text="Label" Visible="false"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="pnlcategory" runat="server" Width="100%">
                                                                        <table width="90%" border="0" align="center" cellpadding="3" cellspacing="0" class="border2">
                                                                            <tr>
                                                                                <td class="blacktext" colspan="2" height="40" bgcolor="#e2ebf0">
                                                                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Category"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" height="10">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    <strong>Category Name:</strong>
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:TextBox ID="txtcatname" runat="server">
                                                                                    </asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtBulletinTitle"
                                                                                        ErrorMessage="*">
                                                                                    </asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="23%" align="right">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="77%">
                                                                                    <asp:ImageButton ID="imgsubmitcat" CausesValidation="True" CommandName="Update" runat="server"
                                                                                        ImageUrl="images/submit.jpg" Style="height: 19px" OnClick="imgsubmitcat_Click" />
                                                                                    <asp:ImageButton ID="imgcancelcat" CausesValidation="False" CommandName="Cancel"
                                                                                        runat="server" ImageUrl="images/cancel.jpg" Height="19px" OnClick="imgcancelcat_Click" />
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
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView align="center" ID="GVBulliten" CssClass="border2" AutoGenerateColumns="false"
                                                                        DataKeyNames="BulletinID" CellPadding="3" Width="98%" runat="server" OnRowCommand="GVBulliten_RowCommand"
                                                                        OnSelectedIndexChanged="GVBulliten_SelectedIndexChanged">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="BulletinID" HeaderText="Bulletin ID" />
                                                                            <asp:BoundField DataField="BulletinTitle" HeaderText="Bulletin Name" />
                                                                            <asp:BoundField DataField="Created_date" HeaderText="Uploaded Date" />
                                                                            <asp:TemplateField HeaderText="ACTION">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="LbtnEdit" runat="server" CommandName="Select" class="link" CausesValidation="False">Edit</asp:LinkButton>
                                                                                    &nbsp;|&nbsp;
                                                                                    <asp:LinkButton ID="LbtnDelete" runat="server" CommandName="Kdelete" CommandArgument='<%# Eval("BulletinID") %>'
                                                                                        class="link" OnClientClick='return confirm("Are you sure ?")' CausesValidation="False">Delete</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#B7CFE3" HorizontalAlign="Left" Height="30px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <%--   <asp:Panel ID="pnlcategorygrid" runat="server" Visible="false">--%>
                                                            <tr>
                                                                <td>
                                                                    <asp:GridView align="center" ID="grdcategory" CssClass="border2" AutoGenerateColumns="false"
                                                                        DataKeyNames="catid" CellPadding="3" Width="98%" runat="server" OnRowCommand="grdcategory_RowCommand"
                                                                        OnSelectedIndexChanged="grdcategory_SelectedIndexChanged1">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="catid" HeaderText="Category ID" />
                                                                            <asp:BoundField DataField="catname" HeaderText="Category Name" />
                                                                            <asp:TemplateField HeaderText="ACTION">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="LbtnEdit" runat="server" CommandName="Select" class="link" CausesValidation="False">Edit</asp:LinkButton>
                                                                                    &nbsp;|&nbsp;
                                                                                    <asp:LinkButton ID="LbtnDelete" runat="server" CommandName="Kdelete" CommandArgument='<%# Eval("catid") %>'
                                                                                        class="link" OnClientClick='return confirm("Are you sure ?")' CausesValidation="False">Delete</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle BackColor="#B7CFE3" HorizontalAlign="Left" Height="30px" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <%-- </asp:Panel>--%>
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
    </div>
    </form>
</body>
</html>
