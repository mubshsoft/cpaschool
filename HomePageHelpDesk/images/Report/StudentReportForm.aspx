<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="C#" AutoEventWireup="true" CodeFile="StudentReportForm.aspx.cs" Inherits="Admin_StudentReportForm" Title="Student Form Report" %>
<%--<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title> Student Form Report</title>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
 <script type="text/javascript" src="../stmenu.js"></script>
 <script language="javascript" type="text/javascript">
  function myprint()
{   
    window.print();
}

  function closepopup()
{    
    window.close();
}
//function CallPrint(strid)

//{


//var prtContent = document.getElementById(strid);


//var WinPrint = window.open('', '', 'left=0,top=0,width=800,height=1000,status=0');

////WinPrint.document.write("<STYLE><!-- body{width:100%;margin:0;float:none;color: #000000;font-size: 11px;font-family: tahoma;word-spacing:0.5mm;} --></STYLE>");

//WinPrint.document.write(prtContent.innerHTML );

//WinPrint.document.close();

//WinPrint.focus(); 


//WinPrint.print();


////WinPrint.print();

//WinPrint.close();

// prtContent.innerHTML=strOldOne;

function CallPrint(strid)
  {
   var prtContent = document.getElementById(strid);
   var strOldOne=prtContent.innerHTML;
   var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
   WinPrint.document.write(prtContent.innerHTML);
   WinPrint.document.close();
   WinPrint.focus();
   WinPrint.print();
   WinPrint.close();
   prtContent.innerHTML=strOldOne;
  }


//}


    </script>

  <form id="form1" runat="server">
    
   <section class="title">
        <div class="container">
        <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <h2 style="color:#fff">Student Form Report</h2>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <ul class="breadcrumb pull-right">
                        <li><a href="../Admin/Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">/</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
        </div>
    </section>

    <section class="container main">
    <div class="row" ><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right"><asp:Label ID="lbldate" runat="server"  Text="DATE :" Font-Names="Tahoma"  Visible="false"
                                                                Font-Size="11px" Font-Bold ></asp:Label><asp:Label ID="lblShowDate" runat="server" ></asp:Label></span></div></div>  
                                    
                                        
     <div class="user-info media box" style="background-color:#fff;">
                 <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Course Details</div></div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Title :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtCourseTitle" runat="server" CssClass="input-block-level" placeholder="Course Title" Enabled="false" MaxLength="48" ReadOnly="True"></asp:TextBox></div>
                             </div>
                             </div>
                 <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Account Details</div>
                 </div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Email Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="input-block-level" placeholder="Email Address" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
                             </div>
                  <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Contact Details</div>
                </div>
                <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">First Name :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:TextBox ID="txtFirstName" runat="server" CssClass="input-block-level" placeholder="First Name" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">            
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Middle Name</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMiddleName" runat="server" CssClass="input-block-level" placeholder="Middle Name" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Last Name</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtLastName" runat="server" CssClass="input-block-level" placeholder="Last Name" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Date of Birth :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtDOB" runat="server" CssClass="input-block-level" placeholder="Date of Birth" Enabled="false" MaxLength="10" ReadOnly="True"></asp:TextBox></div>
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
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="input-block-level" placeholder="Permanent Address" TextMode="MultiLine" Rows="4" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
              <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Correspondence Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="input-block-level" placeholder="Correspondence Address" TextMode="MultiLine" Rows="4" Enabled="false" MaxLength="100" ReadOnly="True"></asp:TextBox></div>
                              </div>
              <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Contact Number :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="input-block-level" placeholder="Contact Number" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
              <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Mobile Number :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMobileNumber" runat="server" CssClass="input-block-level" placeholder="Mobile Number" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
              <div class="user-info media box" style="background-color:#fff;">
                <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Personal Details</div>
                </div>
                <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Gender :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtGender" runat="server" CssClass="input-block-level" placeholder="Gender" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
                <div class="row">
                              <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Current Profession :</div>
                              <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtProfession" runat="server" CssClass="input-block-level" placeholder="Current Profession" MaxLength="15" Enabled="false"></asp:TextBox></div>
                              </div>
                                                            
                <div class="row">
                              <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                              <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtNationality" runat="server" CssClass="input-block-level" placeholder="Nationality" MaxLength="25" Enabled="false"></asp:TextBox></div>
                              </div>
                 <div class="row">
                              <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Category :<asp:Label ID="Label10" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                              <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtCategory" runat="server" CssClass="input-block-level" placeholder="Category" MaxLength="15" Enabled="false"></asp:TextBox></div>
                              </div>
                   </div>  
                   </div>                                   
                 <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Educational Details :</div></div>
                <div class="row" style="margin-top: 20px;">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                    <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of the Univ./Board</b></div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard1" runat="server" Title="10th" placeholder="10th" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtBoard4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
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
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears2" runat="server" Title="12th" placeholder="12th" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYears4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
                    </div>
                    </div>
                     </div>
                     </div>                                                 
                     <div class="user-info media box" style="background-color:#fff;">
     <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</div>
                </div>
      <div class="row" style="margin-top: 20px; border-bottom:solid 1px #c0c0c0; margin-bottom:10px">
            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 form_text field-label">
                Total Years of Experience
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtTotExp" runat="server" placeholder="Total Years of Experience" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div></div>
            <div class="row">
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of Organisation</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg1" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg2" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtOrg3" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Phone Number</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh1" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh2" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtPh3" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Designation</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation1" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation2" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtDesignation3" runat="server" Title="Designation" placeholder="Designation" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Years of Service</b></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear1" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear2" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox ID="txtYear3" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="input-block-level" MaxLength="15" Enabled="false"></asp:TextBox></div>
        </div>
        </div>
        </div>
        </div>
        <div class="row">&nbsp;</div>                                          
        <div class="row center">
                    <asp:Button ID="ImageButton2" runat="server" Text="Close" CssClass="btn btn-large btn-warning" Visible="False"  onclick="ImageButton2_Click" />
                    <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" tyle="text-align: left" ToolTip="Print" Visible="false" OnClientClick="myprint()" />
                    </div>
        </section>                   
                        
    </form>
</asp:Content>
