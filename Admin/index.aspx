<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>:: Administrator Zonel ::</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="1000" height="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      
      
      <tr>
        <td height="10" valign="top"><table width="98%" border="0" align="center" cellpadding="0" cellspacing="0" class="textlogin">
          <tr>
            <td width="200" height="10" valign="top">&nbsp;</td>
            <td align="center"><span class="BigText">Administrator Zone</span> </td>
            <td width="200" align="right" valign="top"><a href="logout.aspx"></a></td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td height="10" align="center" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          
          
          <tr>
            <td height="10" align="center" valign="top"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="contenttable">
              <tr>
                <td valign="top" height="13" ></td>
              </tr>
              <tr>
                <td valign="top"><table border="0" align="center" cellpadding="0" cellspacing="5" 
                        class="border2">
                  <tr>
                    <td width="11%" rowspan="3" align="right" class="Black12"><img src="images/locked.gif" width="64" height="64"></td>
                    <td width="26%" align="right" class="Black12">Login ID : </td>
                      <td width="24%">
                          <label>
                              <asp:TextBox ID="txtlogingid" runat="server" Width="100px"></asp:TextBox>
                          </label>
                      </td>
                    <td width="39%" rowspan="1" class="Black12">Use a valid username and password to gain access to the <strong>administration console</strong>.</td>
                  </tr>
                  <tr>
                    <td align="right" class="Black12">Password : </td>
                      <td>
                          <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="100px"></asp:TextBox></td>
                  </tr>
                  <tr>
                    <td align="right">&nbsp;</td>
                      <td>
                          &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/login.gif"
                              OnClick="ImageButton1_Click" /></td>
                    <td>&nbsp;</td>
                  </tr>
                </table></td>
              </tr>
            </table>
                <asp:Label ID="lblLoginError" runat="server" Font-Names="Verdana" Font-Size="10pt"
                    ForeColor="Red" Visible="False"></asp:Label></td>
          </tr>
        </table>
        </td>
      </tr>
      
      <tr>
        <td height="75" valign="bottom"><table width="1000" border="0" align="center" cellpadding="0" cellspacing="5" class="bottomtable">
          <tr>
            <td align="right" class="content-small"></td>
          </tr>
          <tr>
            <td align="right" class="content-small">Copyright   &copy; 2009-2010 <span class="colour2"> Newtech infosoft Pvt. Ltd.</span>. All rights reserved.</td>
          </tr>
        </table></td>
      </tr>
    </table></td>
  </tr>
</table>
    </form>
</body>
</html>
