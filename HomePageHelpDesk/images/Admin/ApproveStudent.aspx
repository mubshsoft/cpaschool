<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="ApproveStudent.aspx.vb" Inherits="Admin_ApproveStudent" Title="Approve Student" %>

<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Approve Student</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function HideMessage()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage.ClientID%>').textContent ='';
                        }
                     }
                     
//          function openPopup(strOpen)
//                         {
//                         
//                          open(strOpen, "Info", "status=1, width=700, height=800, top=20, left=300,scrollbars=yes");
//                         }     
                         function openPopup(strOpen)
                         {
                          var options = 'scrollbars=yes,resizable=yes,status=no,toolbar=no,menubar=no,location=no';    options += ',width=' + screen.availWidth + ',height=' + screen.availHeight;    options += ',screenX=0,screenY=0,top=0,left=0';    
                          var win = window.open(strOpen, '', options);    
                          win.focus();    
                          win.moveTo(0, 0); 
                                              }         
    </script>
 <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Registration Form</h1> 
    
    </section>
 
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
  

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

        <div class="user-info media box" style="background-color:#fff;">
                 <div class="row"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                  <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Course Details</div>
                 </div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Title :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtCourseTitle" runat="server" CssClass="input-block-level" Enabled="false" MaxLength="48" ReadOnly="True"></asp:TextBox></div>
                             </div>
                             </div>
        <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Account Details</div>
                 </div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Email Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="style11feedback_sec" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
                             </div>
        <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Contact Details</div>
                 </div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">First Name :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtFirstName" runat="server" CssClass="input-block-level" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Middle Name :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMiddleName" runat="server" CssClass="input-block-level" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Last Name :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtLastName" runat="server" CssClass="input-block-level" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Date of Birth :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtDOB" runat="server" CssClass="input-block-level" Enabled="false" MaxLength="10" ReadOnly="True"></asp:TextBox></div>
                             </div>
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
                 <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Permanent Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="input-block-level" TextMode="MultiLine" Rows="4" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Correspondence Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="input-block-level" TextMode="MultiLine" Rows="4" Enabled="false" MaxLength="100" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Contact Number :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="input-block-level" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Mobile Number :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMobileNumber" runat="server" CssClass="input-block-level" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
                             </div>
        <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Personal Details</div>
                 </div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Gender :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:DropDownList ID="dllGender" runat="server" CssClass="input-block-level">
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList></div>
                            </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Applicant Category<asp:Label ID="Label13" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtApplicantCategory" runat="server" CssClass="input-block-level"  Enabled="false"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Current Profession :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtProfession" runat="server" CssClass="input-block-level"  Enabled="false"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtNationality" runat="server" CssClass="input-block-level" MaxLength="25" Enabled="false"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNationality"
                                                                ErrorMessage="Nationality  cannot be left blank." Display="Dynamic"></asp:RequiredFieldValidator></div>
                                                                </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Category :<asp:Label ID="Label10" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtCategory" runat="server" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCategory"
                                                                ErrorMessage="Category cannot be left blank." Display="Dynamic"></asp:RequiredFieldValidator></div>
                                                                </div>
                                                                </div>
        <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Educational Details</div>
                </div>
    <div class="row" style="margin-top: 20px;">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of the Univ./Board</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level" MaxLength="15" Enabled="false" ></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level" MaxLength="15" Enabled="false" ></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" MaxLength="15" Enabled="false" ></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" MaxLength="15" Enabled="false" ></asp:TextBox></div>
        </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Stream</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtStream1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtStream2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtStream3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtStream4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Marks Obtained (%)</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtMarks4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Year of Completion</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        </div>
        </div>
        <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</div>
    </div>
    <div class="row" style="margin-top: 20px; border-bottom:solid 1px #c0c0c0; margin-bottom:10px">
            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form_text field-label">Total Years of Experience</div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtTotExp" runat="server" placeholder="Total Years of Experience" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
            </div>
            <div class="row">
    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name and Address of Organisation</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg1" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="15" Enabled="false" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg2" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="15" Enabled="false" Width="100%"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg3" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="15" Enabled="false" Width="100%"></asp:TextBox></div>
        </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Phone Number</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh1" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh2" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh3" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Designation</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation1" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation2" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation3" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Years of Service</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear1" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear2" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear3" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" Width="100%" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        </div>
        </div>
        <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Declaration</div>
    </div>
     <div class="row" style="margin-top:20px">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    
                    <h6>    I hereby declare that the information furnished in the application form is complete
                                                            and accurate. I also agree that the FMSF has the right to cancel my candidature,
                                                            in case it is found that any information provided therein is incorrect, incomplete
                                                            or misleading, or ineligibility being detected before or after the selection/admission.</h6>
                                                            </div>
                    </div>
     <div class="row">&nbsp;</div>
     <div class="row">
                             <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12 form_text field-label"><span class="pull-right">Date:</span></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" align="left"><asp:TextBox ID="txtDate" runat="server" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
                             <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12"><asp:TextBox ID="txtPlace" runat="server" placeholder="Place" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
                             </div>
     <div class="row"><div class="col-lg-2 col-md-2 col-sm-12 col-xs-12" >&nbsp;</div>
                            <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12" align="left"><asp:TextBox ID="txtfeeremark" runat="server" placeholder="Remarks" ToolTip="Remarks" CssClass="input-block-level" ></asp:TextBox></div>
                             </div>
    <div class="row">&nbsp;</div>
     <div class="row">
                             <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12 form_text field-label"><span class="pull-right">Supporting Document :</span></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" align="left"><asp:FileUpload ID="Fupd" runat="server" /><asp:LinkButton ID="lnkUpload" runat="server" Text="Upload" CssClass="btn btn-primary" /></div>
                             </div>
    <div class="row">&nbsp;</div>
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                         
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                                         
                                                        <asp:CheckBox ID="chkDocumentVerified" runat="server" text="Documents Verified" AutoPostBack="true"/>
                                                         <asp:CheckBox ID="chkScreningExam" runat="server" text="Screening Exam" Visible="false" AutoPostBack="true"/>
                                                         <asp:CheckBox ID="chkFeePay" runat="server" text="Fee Pay" AutoPostBack="true"/>
                                                        <asp:CheckBox ID="chkApprove" runat="server" text="Approved"/>
                                                        </ContentTemplate>
                                                         </asp:UpdatePanel>
                                                             </div></div>
                                                        <%-- <asp:Repeater ID="rptFiles" runat="server"
                                                                OnItemDataBound="rptFiles_ItemDataBound">
                                                                <ItemTemplate>
                                                                <asp:HyperLink ID="hplFile"  runat="server" /> <br />
                                                                </ItemTemplate>
                                                                <&nbsp;</td>
                                                        <td align="left">
                                                        <%-- <asp:Repeater ID="rptFiles" runat="server"
                                                                OnItemDataBound="rptFiles_ItemDataBound">
                                                                <ItemTemplate>
                                                                <asp:HyperLink ID="hplFile"  runat="server" /> <br />
                                                                </ItemTemplate>
                                                                </asp:Repeater>--%>
                                                                <table>
                                                                <%try %>
                                                                 <%
                                                                  
                                                                   dim fiarr() As System.IO.FileInfo
                                                                    Dim strPath As String                                                                                         
                                                                    strPath = Server.MapPath("..\") & "studentDoc\" & session("email")
                                                                    dim   di as New System.IO.DirectoryInfo(strPath)
                                                                    fiArr  = di.GetFiles()
                                                                    For Each fi In fiArr %>
                                                                       <tr>
                                                                           <td>
                                                                              <a href="../DownloadDetail.aspx?fnm=<%=fi.Name %>">
                                                                              <%=fi.Name %>
                                                                              </a>
                                                                           </td>
                                                                       </tr>
                                                                   <%next%>
                                                                   
                                                                   <%catch ex as exception %>
                                                                   <%end try %>
                                                                </table>
                                                             
   <div class="row">&nbsp;</div>
      <div class="row center">
                             <asp:Button ID="btnSave" runat="server"  Text="Save" CssClass="btn btn-large btn-success"/>
                             <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-large btn-warning"/>
                             <asp:Button ID="btnPrint" runat="server" OnClientClick="return openPopup('PrintAdminRegistration.aspx');"  Text="Print" CssClass="btn btn-large btn-primary" />
                             <asp:Button ID="SendMail" runat="server" Text="Send Mail" CssClass="btn btn-large btn-danger" />
                             </div>
                             
                                </div>
                           
   
    </div>
    </div>
    </section>
   </div>
    </form>
</asp:Content>
