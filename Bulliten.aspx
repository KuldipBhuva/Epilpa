<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="Bulliten.aspx.cs" Inherits="Bulliten" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="6">
        <tr>
            <td height="10" class="tit">
            </td>
        </tr>
        <tr>
            <td class="tit">
                Bulletin
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
            <td style="border: thin groove #990000">
                <p class="text">
                    <asp:GridView ID="GVBulliten" runat="server" align="center" AutoGenerateColumns="false"
                        CellPadding="3" CssClass="text" DataKeyNames="BulletinID" Width="98%">
                        <Columns>
                            <asp:BoundField DataField="BulletinTitle" HeaderText="Bulletin Name"  />
                            <asp:TemplateField HeaderText="View Bulletin">
                                <ItemTemplate>
                                    <a href="admin/upload/<%# Eval("BuletinFile") %>" target="_blank">Click here</a>
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
