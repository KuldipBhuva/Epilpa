<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true"
    CodeFile="FRegistration.aspx.cs" Inherits="FRegistration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="//code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkDate1(txt) {
            var DOB = new Date(txt.value);
            if (DOB > new Date()) {
                txt.value = '';
                alert("You cannot select a day future than today!");
                return false;
            }

        }
        function Img2_onclick() {

        }


        function readURL(input) {
            if (input.files && input.files[0]) {
                if (input.files[0].type == "image/jpeg" || input.files[0].type == "image/pdf" || input.files[0].type == "image/gif" || input.files[0].type == "image/jpg") {
                    if (input.files[0].size < 204800) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $('#<%=Image1.ClientID %>').attr('src', e.target.result);
                        }
                        reader.readAsDataURL(input.files[0]);
                    }
                    else {
                        alert("File size exceeds maximum limit 200 KB.");
                        input.value = '';
                        $('#<%=Image1.ClientID %>').attr('src', '');
                        $('#<%=Image1.ClientID %>').attr('src', 'images/Profile.jpg');
                        return false;
                    }
                }
                else {
                    alert("Only JPEG, PDF, GIF & JPG Images are allowed");
                    input.value = '';
                    $('#<%=Image1.ClientID %>').attr('src', '');
                    $('#<%=Image1.ClientID %>').attr('src', 'images/Profile.jpg');
                    return false;
                }
            }
        }
        function readURL1(input) {
            if (input.files && input.files[0]) {
                if (input.files[0].type == "image/jpeg" || input.files[0].type == "image/pdf" || input.files[0].type == "image/gif" || input.files[0].type == "image/jpg") {
                    if (input.files[0].size < 204800) {
                        var reader = new FileReader();
                        reader.onload = function (e) {
                            $('#<%=Image2.ClientID %>').attr('src', e.target.result);
                        }
                        reader.readAsDataURL(input.files[0]);
                    }
                    else {
                        alert("File size exceeds maximum limit 200 KB.");
                        input.value = '';
                        $('#<%=Image2.ClientID %>').attr('src', '');
                        $('#<%=Image2.ClientID %>').attr('src', 'images/Profile.jpg');
                        return false;
                    }
                }
                else {
                    alert("Only JPEG, PDF, GIF & JPG Images are allowed");
                    input.value = '';
                    $('#<%=Image2.ClientID %>').attr('src', '');
                    $('#<%=Image2.ClientID %>').attr('src', 'images/Profile.jpg');
                    return false;
                }
            }
        }
    </script>
    <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#Image1').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }

        }

    </script>
    <div class="header">
        <script language="javascript" type="text/javascript">
            function divexpandcollapse(divname) {
                var div = document.getElementById(divname);
                var img = document.getElementById('img' + divname);
                if (div.style.display == "none") {
                    div.style.display = "inline";
                    img.src = "minus.gif";
                } else {
                    div.style.display = "none";
                    img.src = "plus.gif";
                }
            }
        </script>
        <h2 class="page-title" style="color: #008080; text-decoration: underline;">
            Registration Form</h2> <a style="float:right;" href="Admin/Manage_Members.aspx">Back to Admin Panel</a>
        <ul class="breadcrumb">
            <li>
                <asp:Label CssClass="text" ID="lblMess" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hdn" runat="server" />
                <asp:HiddenField ID="hdn0" runat="server" />
                <asp:HiddenField ID="hdnPhotoName" runat="server" />
                <asp:HiddenField ID="hdnPhotoType" runat="server" />
                <asp:HiddenField ID="hdnPhotoData" runat="server" />
                <asp:HiddenField ID="hdnIdname" runat="server" />
                <asp:HiddenField ID="hdnIdType" runat="server" />
                <asp:HiddenField ID="HdnIdData" runat="server" />
                <asp:Label ID="lblCredit" runat="server" Text="Label" Visible="false"></asp:Label>
                <asp:ToolkitScriptManager ID="TK" runat="server">
                </asp:ToolkitScriptManager>
            &nbsp;Items marked with an (*) are mandatory.
        </ul>
    </div>
    <div id="DivAddNew" runat="server" style="width: 100%">
        <asp:TabContainer ID="TabContainer1" runat="server" CssClass="MyTabStyle" ActiveTabIndex="0"
            Width="100%">
            </asp:TabPanel>
            <asp:TabPanel ID="Tab1" runat="server">
                <HeaderTemplate>
                    Members Details</HeaderTemplate>
                <ContentTemplate>
                    <fieldset class="fieldset">
                        <legend>Information</legend>
                        <table>
                            <tr>
                                <td style="width: 23%">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%">
                                    <span class="text"><strong>Member Details </strong>
                                </td>
                                <td class="text">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text">
                                    Application FormNo:
                                </td>
                                <td>
                                    &nbsp;<asp:TextBox class="box" ID="txtsrno" runat="server" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="trmembrid" runat="server" visible="False">
                                <td align="right" class="text" runat="server" style="height: 30px">
                                    Member Id:
                                </td>
                                <td runat="server" style="height: 30px">
                                    &nbsp;<asp:TextBox class="box" ID="txtid" runat="server" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    &nbsp;*&nbsp; Name :
                                </td>
                                <td>
                                    &nbsp;<asp:TextBox class="box" ID="txtMemberName" runat="server" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMemberName"
                                        ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    * Mobile :
                                </td>
                                <td>
                                    <asp:TextBox class="box" ID="txtMobile" runat="server" MaxLength="15"></asp:TextBox><asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobile"
                                        ErrorMessage="RegularExpressionValidator" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Sex :
                                </td>
                                <td>
                                    <asp:DropDownList class="box" ID="ddlSex" runat="server">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    &nbsp;Address :
                                </td>
                                <td>
                                    &nbsp;<asp:TextBox class="box" ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    &nbsp;*&nbsp; Email ID :
                                </td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtEmailID" class="box" runat="server" MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailID" ErrorMessage="*"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                            ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailID"
                                            ErrorMessage="Enter valid email id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            Font-Names="Verdana" Font-Size="10pt"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Membership Type :
                                </td>
                                <td>
                                    <asp:DropDownList class="box" ID="ddlMemberType" runat="server">
                                        <asp:ListItem Selected="True">Ordinary</asp:ListItem>
                                        <asp:ListItem>Associate</asp:ListItem>
                                        <asp:ListItem>Life Membership</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel4" runat="server">
                <HeaderTemplate>
                    Other Details</HeaderTemplate>
                <ContentTemplate>
                    <fieldset class="fieldset">
                        <legend>Company Details</legend>
                        <table width="100%">
                            <tr>
                                <td style="width: 23%">
                                    <span class="text"><strong>Company Details </strong></span>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Name of the firm :
                                </td>
                                <td>
                                    <asp:TextBox class="box" ID="txtCompany" runat="server" MaxLength="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Office Address :
                                </td>
                                <td>
                                    <asp:TextBox class="box" ID="txtOAddress" runat="server" MaxLength="30" TextMode="MultiLine"
                                        Height="77px" Width="224px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Year of starting business :
                                </td>
                                <td>
                                    <asp:TextBox class="box" ID="txtYearOfStart" runat="server" MaxLength="4" Width="40px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Nature of activity :
                                </td>
                                <td>
                                    <asp:TextBox class="box" ID="txtNatureOfActivity" runat="server" MaxLength="255"
                                        Width="300px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <fieldset class="fieldset">
                        <legend>Contact Information </legend>
                        <table width="100%">
                            <tr>
                                <td style="width: 23%">
                                    <span class="text"><strong>Phone Numbers</strong></span>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Office :
                                </td>
                                <td>
                                    <asp:TextBox class="box" ID="txtPhoneOffice" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Fax :
                                </td>
                                <td>
                                    <asp:TextBox class="box" ID="txtFax" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    Residence :
                                </td>
                                <td>
                                    <asp:TextBox class="box" ID="txtResidence" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    &nbsp;</ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="Tab2" runat="server">
                <HeaderTemplate>
                    Payment Information</HeaderTemplate>
                <ContentTemplate>
                    <fieldset class="fieldset">
                        <legend>Payment Details</legend>
                        <table id="tblmode" width="100%">
                            <tr>
                                <td style="width: 23%">
                                    <span class="text"><strong>Payment Details </strong></span>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    &nbsp; Payment Type:
                                </td>
                                <td>
                                    &nbsp;&nbsp;<asp:DropDownList ID="ddlpaymentMode" runat="server" Width="118px" OnSelectedIndexChanged="ddlpaymentMode_SelectedIndexChanged"
                                        AutoPostBack="True">
                                        <asp:ListItem>RTGS(NEFT)</asp:ListItem>
                                        <asp:ListItem>Cheque</asp:ListItem>
                                        <asp:ListItem>Cash</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" style="width: 23%">
                                    &nbsp;Amount :
                                </td>
                                <td>
                                    &nbsp;&nbsp;<asp:TextBox class="box" ID="txtcqAmount" runat="server" MaxLength="30"></asp:TextBox>
                                </td>
                            </tr>
                            <tr id="trutr" runat="server" visible="true">
                                <td align="right" class="text" style="width: 23%" runat="server">
                                    UTR Number :
                                </td>
                                <td runat="server">
                                    &nbsp;&nbsp;<asp:TextBox ID="txtcqAmount0" runat="server" class="box" MaxLength="30"></asp:TextBox>
                                </td>
                            </tr>
                            <div id="divtype" runat="server" visible="false">
                                <tr>
                                    <td align="right" class="text" style="width: 23%">
                                        Name of the Bank :
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;<asp:TextBox class="box" ID="txtbank" runat="server" MaxLength="30"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="text" style="width: 23%">
                                        Bank Branch:
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;<asp:TextBox class="box" ID="txtbankbranch" runat="server" MaxLength="30"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="text" style="width: 23%">
                                        &nbsp; Cheque Date :
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;<asp:TextBox class="box" ID="txtCqdate" runat="server" MaxLength="30"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" class="text" style="width: 23%">
                                        &nbsp;Cheque number :
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;<asp:TextBox class="box" ID="txtcqnumber" runat="server" MaxLength="30"></asp:TextBox>
                                    </td>
                                </tr>
                            </div>
                        </table>
                    </fieldset>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel1" runat="server">
                <HeaderTemplate>
                    Upload Identity</HeaderTemplate>
                <ContentTemplate>
                    <fieldset class="fieldset">
                        <legend>Upload Identity </legend>
                        <table width="100%">
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="font-size: small">
                                    (The File Type Should be .jpeg,.jpg or .pdf and the file size Should be less Then
                                    200 KB)
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 1%;">
                                    <strong>Upload Your Photo * </strong>
                                    <br />
                                    <br />
                                    <span style="font-size: small">(</span><span style="text-decoration: underline"><strong>Note</strong></span>:<span
                                        style="color: #CC3300"> </span><span style="font-size: small; color: #CC3300;">Upload
                                            Your Latest Passport Size Coloured Photo</span><span style="font-size: small">)</span>
                                </td>
                                <td style="height: 50px; width: 1%;">
                                    <div>
                                        <div id="profile_pic_wrapper">
                                            <asp:FileUpload ID="Upload1" runat="server" onchange="readURL(this)" CssClass="profile_pic"
                                                Style="position: absolute; z-index: 1; top: 0px; left: 1px;" />
                                            <asp:Image ID="Image1" runat="server" ImageUrl="images/Profile.jpg" CssClass="profile_pic"
                                                Style="position: absolute; z-index: 0; left: 0px; top: 0px;" />
                                        </div>
                                    </div>
                                </td>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </tr>
                            <tr>
                                <td style="height: 30px; width: 1%;">
                                    <strong>Upload Your Photo id * </strong>
                                    <br />
                                    <br />
                                    <span style="font-size: small">(</span><span style="text-decoration: underline"><strong>Note</strong></span>
                                    :<span style="color: #CC3300"> </span><span style="font-size: small; color: #CC3300;">
                                        Upload Any Of The Following Photo Id Proofs<br />
                                        - PAN Card,Aadhar Card,Valid Driving License,Valid Passport</span><span style="font-size: small">)
                                        </span>
                                </td>
                                <td style="height: 50px; width: 1%;">
                                    <div>
                                        <div id="profile_pic_wrapper">
                                            <asp:FileUpload ID="Upload2" runat="server" onchange="readURL1(this)" CssClass="profile_pic"
                                                Style="position: absolute; z-index: 1; top: 0px; left: 0px;" />
                                            <asp:Image ID="Image2" runat="server" CssClass="profile_pic" Style="position: absolute;
                                                z-index: 0; left: 0px; top: -1px;" />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr
                             <tr>
                            </tr>
                             <td>
                            </td>
                            <td>
                            </td>
                             <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="text" visible="false">
                                     <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" 
                                         Text="Submit" />
                                     <asp:Button ID="btnCancle" runat="server" CausesValidation="False" 
                                         OnClick="btnCancle_Click" Text="Cancel" />
                                </td>
                                <td align="left">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </fieldset>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
        <table width="100%" style="margin-top: 50px">
            <tr>
                <td align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
