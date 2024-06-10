<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PrintProfile.aspx.vb" Inherits="Student_PrintProfile" %>

<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Registration Form</title>
    <script type="text/javascript" src="../stmenu.js"></script>
    
    
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table width="680px">
            <tr>
                <td align="center" colspan="4">
                    <img src="../images/fmsflogo.png" style="border: 0px" />
                </td>
            </tr>
            <tr style="background-color: #E4E4E4">
                <td align="left" colspan="4" style="color: Black; padding-left: 13px;" class="NormalText">
                    Account Details
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Email Address :
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtEmailAddress" runat="server" Height="18px" CssClass="style11feedback_sec"
                        Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Student ID :
                </td>
                <td align="left" colspan="2">
                    <asp:Label ID="lblApp" runat="server" CssClass="style11feedback_sec" />
                </td>
            </tr>
            <tr style="background-color: #E4E4E4">
                <td align="left" colspan="4" style="color: Black; padding-left: 13px;" class="NormalText">
                    Contact Details
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    First Name :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtFirstName" runat="server" Height="18px" CssClass="style11feedback_sec"
                        MaxLength="49"></asp:TextBox>
                </td>
                <td align="center" rowspan="4"  valign="middle" >
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Middle Name :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtMiddleName" runat="server" Height="18px" CssClass="style11feedback_sec"
                        MaxLength="49"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Last Name :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtLastName" Height="18px" runat="server" CssClass="style11feedback_sec"
                        MaxLength="49"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Date of Birth :
                </td>
                <td align="left">
                    <asp:TextBox ID="txtDOB" runat="server" Height="18px" CssClass="style11feedback_sec"
                        MaxLength="10"></asp:TextBox>
                </td>
            </tr>
            <%-- <tr>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>--%>
            <tr>
                <td align="left" valign="top">
                    &nbsp;
                </td>
                <td align="left" valign="top" class="NormalText">
                    Permanent Address :
                </td>
                <td align="left" colspan="2">
                 <asp:Label ID="txtPermanentAddress" runat="server" CssClass="style11feedback_sec" />
                   <%-- <asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="style11feedback_sec"
                        TextMode="MultiLine" Height="50px"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    &nbsp;
                </td>
                <td align="left" valign="top" class="NormalText">
                    Correspondence Address :
                </td>
                <td align="left" colspan="2">
                 <asp:Label ID="txtCorrespondenceAddress" runat="server" CssClass="style11feedback_sec" />
                   <%-- <asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="style11feedback_sec"
                        TextMode="MultiLine" Height="50px" MaxLength="100"></asp:TextBox>--%>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Contact Number :
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtContactNumber" runat="server" Height="18px" CssClass="style11feedback_sec"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Mobile Number :
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtMobileNumber" runat="server" Height="18px" CssClass="style11feedback_sec"></asp:TextBox>
                </td>
            </tr>
            <tr style="background-color: #E4E4E4">
                <td align="left" colspan="4" style="color: Black; padding-left: 13px;" class="NormalText">
                    Personal Details
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Gender :
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtGendor" runat="server" Height="18px" CssClass="style11feedback_sec "></asp:TextBox>
                    <%-- <asp:DropDownList ID="dllGender" runat="server">
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Current Profession :
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtProfession" runat="server" Height="18px" CssClass="style11feedback_sec "></asp:TextBox>
                    <%-- <asp:DropDownList ID="dllProfession" runat="server" CssClass="DropDownStyle11">
                                                                <asp:ListItem>Students</asp:ListItem>
                                                                <asp:ListItem>Working</asp:ListItem>
                                                               
                                                            </asp:DropDownList>--%>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" runat="server"></asp:Label>
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtNationality" runat="server" Height="18px" CssClass="style11feedback_sec"
                        MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Category :<asp:Label ID="Label10" Text="*" ForeColor="Red" runat="server"></asp:Label>
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtCategory" runat="server" Height="18px" CssClass="style11feedback_sec "></asp:TextBox>
                    <%--<asp:DropDownList ID="dllCategory" runat="server" CssClass="DropDownStyle11">
                                                                <asp:ListItem>General</asp:ListItem>
                                                                <asp:ListItem>SC/ST</asp:ListItem>
                                                                <asp:ListItem>OBC</asp:ListItem>
                                                                <asp:ListItem>Others</asp:ListItem>
                                                            </asp:DropDownList>--%>
                </td>
            </tr>
            <tr style="background-color: #E4E4E4">
                <td align="left" colspan="4" style="color: Black; padding-left: 13px;" class="NormalText">
                    Educational Details &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left" colspan="4">
                    <table class="style14" cellpadding="0" cellspacing="0">
                        <tr style="height: 16px;">
                            <td width="15%"  style="height: 16px;">
                                &nbsp;
                            </td>
                            <td width="23%"  class="NormalText" align="center">
                               Name of the Univ./Board
                            </td>
                            <td width="20%"   class="NormalText" align="center">
                                Stream
                            </td>
                            <td width="22%"  class="NormalText" align="center">
                               Marks Obtained (%)
                            </td>
                            <td width="20%"  class="NormalText" align="center">
                                Year of Completion
                            </td>
                        </tr>
                        <tr>
                            <td  class="NormalText" style="padding-left: 5px;">
                               10<sup>th</sup>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtBoard1" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>&nbsp;
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtStream1" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtMarks1" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtYears1" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  class="NormalText" style="padding-left: 5px;">
                               12<sup>th</sup>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtBoard2" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>&nbsp;
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtStream2" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtMarks2" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtYears2" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  class="NormalText" style="padding-left: 5px;">
                               Graduation
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtBoard3" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>&nbsp;
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtStream3" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtMarks3" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtYears3" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  class="NormalText" style="padding-left: 5px;">
                               Any Other
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtBoard4" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>&nbsp;
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtStream4" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtMarks4" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtYears4" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style15" style="padding-left: 5px;">
                                &nbsp;
                            </td>
                            <td class="style15">
                                &nbsp;
                            </td>
                            <td class="style15">
                                &nbsp;
                            </td>
                            <td class="style15">
                                &nbsp;
                            </td>
                            <td class="style15">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr style="background-color: #E4E4E4">
                <td align="left" colspan="4" style="color: Black; padding-left: 7px;" class="NormalText">
                    Work Experience (Atleast One Mandatory if Current Profession is chosen as working)
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td align="left">
                    &nbsp;
                </td>
                <td align="left" class="NormalText">
                    Total Years of Experience
                </td>
                <td align="left" colspan="2">
                    <asp:TextBox ID="txtTotExp" runat="server" Height="18px" CssClass="style11feedback_sec"
                        MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="4">
                    <table class="style14" cellpadding="0" cellspacing="0">
                        <tr style="height: 16px;">
                            <td width="25%" class="NormalText" align="center">
                                Name and Address<br /> of Organisation
                            </td>
                            <td width="25%" class="NormalText" align="center">
                               Phone Number
                            </td>
                            <td width="25%" class="NormalText" align="center">
                                Designation
                            </td>
                            <td width="25%" class="NormalText" align="center">
                               Years of Service
                            </td>
                        </tr>
                        <tr>
                            <td class="framecell">
                                <asp:TextBox ID="txtOrg1" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>&nbsp;
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtPh1" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtDesignation1" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtYear1" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="framecell">
                                <asp:TextBox ID="txtOrg2" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>&nbsp;
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtPh2" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtDesignation2" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtYear2" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="framecell">
                                <asp:TextBox ID="txtOrg3" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>&nbsp;
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtPh3" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtDesignation3" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                            <td class="framecell">
                                <asp:TextBox ID="txtYear3" runat="server" Height="18px" CssClass="style11feedback_third"
                                    MaxLength="15"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="background-color: #E4E4E4">
                            <td align="left" colspan="4" style="color: Black; padding-left: 7px;" class="NormalText">
                                Declaration
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="4" style="padding-left: 5px; padding-right: 5px; text-align: justify"
                                class="NormalText">
                                I hereby declare that the information furnished in the application form is complete
                                and accurate. I also agree that the FMSF has the right to cancel my candidature,
                                in case it is found that any information provided therein is incorrect, incomplete
                                or misleading, or ineligibility being detected before or after the selection/admission.
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="left">
                                &nbsp;
                            </td>
                            <td align="left" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <%--    <tr>
                                                        <td  >
                                                            &nbsp;</td>
                                                        <td   align="left" valign="top">
                                                            &nbsp;</td>
                                                        <td   align="left" valign="middle">
                                                        <asp:CheckBox ID="chkDocumentVerified" runat="server" text="Documents Verified" AutoPostBack="true"/>
                                                        <asp:CheckBox ID="chkApprove" runat="server" text="Approved"/>
                                                             </td>
                                                    </tr>--%>
          
           <tr><td colspan="4" align="left">
           <table cellpadding="0" cellspacing="0" >
           <tr>
                <td>
                    &nbsp;
                </td>
                <td width="25%" style="padding-left: 20px;" align="left" class="NormalText">
                    Place:
                </td>
                <td align="right">
                    <asp:TextBox ID="txtPlace" runat="server" Height="18px" CssClass="style11feedback_third"
                        MaxLength="15"></asp:TextBox>
                </td>
            </tr>
           </table></td></tr>
            
            <tr>
                <td align="center">
                </td>
                <td colspan="3" align="center">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
