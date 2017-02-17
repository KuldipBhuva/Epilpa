<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="inq_form.aspx.cs"
    Inherits="inq_form" Title="EPILPA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td height="10" class="tit">
            </td>
        </tr>
        <tr>
            <td class="tit">
                Inquiry
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="60%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="bg_line">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <p class="text">
                    <table border="0" cellpadding="5" cellspacing="0" width="100%">
                        <tr>
                            <td width="23%">
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr style="color: #000000">
                            <td width="23%">
                                <span class="text"></span>
                            </td>
                            <td class="text">
                                &nbsp;Items marked with an (*) are mandatory.
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="text">
                                &nbsp;* Subject :
                            </td>
                            <td>
                                <asp:TextBox ID="txtSub" runat="server" class="box" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="*" Visible="false"></asp:Label>
                                 <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSub"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" class="text">
                                * Query :
                            </td>
                            <td>
                                <asp:TextBox ID="txtQuiry" runat="server" class="box" MaxLength="50" Rows="8" TextMode="MultiLine"
                                    Width="400px"></asp:TextBox>
                                <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtQuiry"
                                      ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                                <asp:Label ID="Lblrq" runat="server" Text="*" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="text">
                            </td>
                            <td>
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                                <asp:Button ID="btnCancle" runat="server" CausesValidation="False" OnClick="btnCancle_Click"
                                    Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </p>
            </td>
        </tr>
    </table>
</asp:Content>
