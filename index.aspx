<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="index.aspx.cs"
    Inherits="index" Title="EPILPA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="JavaScript">
        function isNumberKey(key, txtbox) {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            var phn = txtbox;
            //comparing pressed keycodes

            if (!(keycode == 8 || keycode == 46 || keycode == 9) && (keycode < 48 || keycode > 57) && (keycode < 35 || keycode > 40) && (keycode < 96 || keycode > 111)) {
                return false;
            }
            else {
                //Condition to check textbox contains ten numbers or not
                return true;
            }
        }
        function check() {
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtRegID').value == "") {
                document.getElementById('ctl00_ContentPlaceHolder1_txtRegID').focus();
                alert("Enter Member ID");
                return false;
            }
            if (document.getElementById('ctl00_ContentPlaceHolder1_txtEmailID').value == "") {
                document.getElementById('ctl00_ContentPlaceHolder1_txtEmailID').focus();
                alert("Enter Email ID");
                return false;
            }


        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
    </script>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <img src="images/home_pic.jpg" width="775" height="242" />
            </td>
        </tr>
        <tr>
            <td height="25" align="left" valign="bottom">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="tit">
                            &nbsp;
                        </td>
                        <td class="tit">
                            Welcome to EPILPA
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="156" valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="2%" class="tit">
                            &nbsp;
                        </td>
                        <td width="59%" valign="top">
                            <p align="justify" class="text">
                                <br />
                                We, on behalf your Association welcome the existing and potential members of the
                                Association and also the professional fraternities of the field. We hope that the
                                website developed for the use of all of you will definitely help you in your day-to-day
                                affairs and act as ready-to-use guide while on travel. The said Website will also
                                facilitate all the registered members to resolve the on-line queries and update
                                and upgrade their knowledge of the profession in which they are engaged. In near
                                future, we are planning to commence some more on-line services with payment-gateway
                                system by using advance and novel methodology. This is being the stepping stone;
                                we anticipate good luck from all of you and your professional experience to upgrade
                                the said new activity from time to time.<br />
                            </p>
                        </td>
                        <td width="39%" align="right" valign="top">
                            <table width="219" height="151" border="0" cellpadding="0" cellspacing="0" class="bg_login">
                                <tr>
                                    <td class="text">
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td width="75" align="right" class="text_home">
                                        Member's Id :
                                    </td>
                                    <td width="144" align="left">
                                        <asp:TextBox ID="txtRegID" class="box" runat="server" Width="100px" onkeydown="return isNumberKey(event,this);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="text_home">
                                        Email Id :
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtEmailID" class="box" runat="server" Width="100px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="center" valign="middle" class="text">
                                        <asp:ImageButton ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" 
                                            ImageUrl="~/images/b_submit.jpg" style="height: 17px" />
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td colspan="2" align="center" valign="middle" class="text">
                                        <asp:ImageButton ID="btnNewUser" runat="server" ImageUrl="~/images/new_user.jpg"
                                            OnClick="btnNewUser_Click" />
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td align="center" class="text" colspan="2">
                                        <asp:Label ID="lblMess" runat="server" ForeColor="#CC3300"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="middle">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="middle" class="bg_line">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <img src="images/icon_1.jpg" width="94" height="66" />
                        </td>
                        <td rowspan="5" align="center">
                            <img src="images/div_icon.jpg" width="5" height="139" />
                        </td>
                        <td align="center">
                            <img src="images/icon_2.jpg" width="81" height="66" />
                        </td>
                        <td rowspan="5" align="center">
                            <img src="images/div_icon.jpg" width="5" height="139" />
                        </td>
                        <td align="center">
                            <img src="images/icon_3.jpg" width="81" height="66" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center" class="tit_icon">
                            <%--<a href="aims.html">Aims &amp; Objects</a>--%>
                            Aims &amp; Objects
                        </td>
                        <td align="center" class="tit_icon">
                            Communication
                        </td>
                        <td align="center" class="tit_icon">
                            Events
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center" valign="top">
                            <img src="images/h_line.jpg" width="147" height="3" />
                        </td>
                        <td align="center" valign="top">
                            <img src="images/h_line.jpg" width="147" height="3" />
                        </td>
                        <td align="center" valign="top">
                            <img src="images/h_line.jpg" width="147" height="3" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center" valign="top" class="text">
                            <table width="150" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <div align="justify" class="text_home">
                                            The aim of the Association is to unite and organize the persons engaged exclusively
                                            in the practice/consultancy of ESI Act, 1948, EPF &amp; Misc. Provs. Act, 1952 and
                                            Other Industrial Laws and to initiate steps to uphold their honor, dignity and independence&hellip;</div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center" valign="top" class="text">
                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <div align="justify" class="text_home">
                                            To strive for excellence is the essence of human spirit &amp; the driving force
                                            behind professional competence.</div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center" valign="top" class="text">
                            <table width="180" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <div align="left" class="text_home">
                                            <b>
                                                <%--<marquee><span style="font-size:11px;">Auunal General Meeting to be held on 23.08.14</span></marquee>--%>
                                            </b>
                                              - <a href="PDFFiles/Epilpa_referance_order_Form_2017.doc" target="_blank" style="color: Red; font-size: 10px;"
                                                class="tit_icon">EPILPA Referance Order Form 2017</a><br /><br />
                                          <%--  - <a href="PDFFiles/EPILPA_workshop_21.10.2016.doc" target="_blank" style="color: Red; font-size: 10px;"
                                                class="tit_icon">EPILPA Workshop 21-10-16</a><br /><br />--%>

                                          <%--   - <a href="PDFFiles/EPILPA AGM.pdf" target="_blank" style="color: Red; font-size: 10px;"
                                                class="tit_icon">EPILPA AGM 20-08-16</a><br /><br />
                                                - <a href="PDFFiles/EPLIPA_ELECTION_2016.PDF" target="_blank" style="color: Red; font-size: 10px;"
                                                class="tit_icon">Epilpa Elections 2016</a>--%>                                        
                                            <%--- <a href="PDFFiles/EPILPA programme for seminar 27.2.2016.doc" target="_blank" style="color: Red; font-size: 10px;"
                                                class="tit_icon">EPILPA SEMINAR on 27.02.2016</a>--%>
                                                
                                                
                                            <%--- <a href="PDFFiles/Epilpa_AGM_2014.pdf" target="_blank" style="color: Red; font-size: 10px;"
                                                class="tit_icon">Annual General Meeting</a>--%>
                                            <%--<br />
                                            - <a href="PDFFiles/Seminar_16_Sept_2014.docx" target="_blank" style="color: Red;
                                                font-size: 10px;" class="tit_icon">Seminar 16th Sept 2014</a>
                                            <br />--%>
                                            <%-- - <a href="PDFFiles/WORKSHOP%20ON%2028_07_12.pdf" target="_blank" style="color: Red;
                                                font-size: 10px;" class="tit_icon">Workshop</a>
                                            <br />
                                            <br />
                                            - <a href="PDFFiles/Registration%20Form.pdf" target="_blank" style="color: Red;
                                                font-size: 10px;" class="tit_icon">Registration Form</a>--%>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="center">
                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right" class="text_copy">
                                        &gt;&gt; <a href="aims.aspx">Read More</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center">
                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right" class="text_copy">
                                        &gt;&gt; <a href="message.aspx">Read More</a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="center">
                            <table width="150" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right" class="text_copy">
                                        <%-- &gt;&gt; <a href="events.aspx">Read More</a>--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td valign="top">
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
