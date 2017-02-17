<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Annual_Reports.aspx.cs"
    Inherits="Annual_Reports" Title="EPILPA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td height="10" class="tit">
            </td>
        </tr>
        <tr>
            <td class="tit">
                Annual Reports
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
                    <asp:GridView ID="GVAnnualReport" runat="server" align="center" AutoGenerateColumns="false"
                        CellPadding="3" CssClass="text" DataKeyNames="AnnualReportID" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="AnnualReportTitle" HeaderText="Annual Report Title" />
                            <asp:TemplateField HeaderText="View Report">
                                <ItemTemplate>
                                    <a href="admin/upload/<%# Eval("AnnualReportFile") %>" target="_blank">Click here</a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Uploaded Date">
                                <ItemTemplate>
                                    <asp:Label ID="LableDate" runat="server"   Text=' <%# Eval("Created_date") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                <HeaderStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle BackColor="#990000" ForeColor="White" Height="30px" HorizontalAlign="Left" />
                    </asp:GridView>
                    &nbsp;</p>
            </td>
        </tr>
    </table>
</asp:Content>
