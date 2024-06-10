<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="EditStudentProfile.aspx.vb" Inherits="Student_EditStudentProfile" Title="Manage Student Profile" %>

<%--
<%@ Register Src="~/StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
-
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Edit Profile</title>
--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                     
                       
                       function HideMessage2()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage2.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage2.ClientID%>').textContent ='';
                        }
                     }
                     
                       function HideMessage3()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage3.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage3.ClientID%>').textContent ='';
                        }
                     }
    </script>
     <script language="javascript" type="text/javascript">
             
          function openPopup(strOpen)
                         {
                          open(strOpen, "Info", "status=1, width=700, height=800, top=20, left=300,scrollbars=yes");
                         }              
    </script>

    <!-- Content Wrapper. Contains page content -->
      <div class="content-wrapper" onkeypress="javascript:HideMessage(),HideMessage2(),HideMessage3()">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Registration Form
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Registration Form</li>
          </ol>
        </section>
    
    
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                   
    
  
        
                   
                                <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                             
                                <div class="box box-primary">
                                <div class="box-header with-border"><h3 class="box-title">Account Details</h3></div>
                        <div class="box-body">
                             <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Email Address :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" Enabled="false" MaxLength="50"></asp:TextBox></div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Email for correspondence :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtSecondaryEmail" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox></div>
                             </div>
                             </div>
                              </div>

                              <div class="box box-primary">
                                <div class="box-header with-border"><h3 class="box-title">Contact Details</h3></div>
                             <div class="box-body">
                             <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">First Name :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" MaxLength="49" ></asp:TextBox></div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Middle Name :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" MaxLength="49" ></asp:TextBox></div>
                                        </div>
                              <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Last Name :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" MaxLength="49" ></asp:TextBox></div>
                                        </div>
                              <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Date of Birth :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" MaxLength="10" ></asp:TextBox></div>
                                        </div>  
                              <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Permanent Address :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox></div>
                             </div>                    
                       <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Correspondence Address :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="100"></asp:TextBox></div>
                             </div>
                       
                        <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Contact Number :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox> <asp:Label ID="lblMessage4" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                             </div> 
                             
                          <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Mobile Number :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" MaxLength="20" ></asp:TextBox>
                                        <asp:Label ID="lblmessage5" EnableViewState="false" runat="server" CssClass="arial" Text="" ForeColor="Red"></asp:Label></div>
                          </div>  
                          </div>
                          </div>

                          <div class="box box-primary">
                                <div class="box-header with-border"><h3 class="box-title">Personal Details</h3></div>
                             <div class="box-body">
                             <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Gender :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="dllGender" runat="server" CssClass="form-control" >
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList></div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Current Profession :</div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="dllProfession" runat="server" CssClass="form-control">
                                    <asp:ListItem>Students</asp:ListItem>
                                    <asp:ListItem>Working</asp:ListItem>
                                                               
                                </asp:DropDownList></div>
                             </div>
                             <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" CssClass="arial" runat="server"></asp:Label></div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtNationality" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNationality" Display="Dynamic"
                                    ErrorMessage="Nationality  cannot be left blank."></asp:RequiredFieldValidator></div>
                             </div>
                             <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 margin-tb">Category :<asp:Label ID="Label10" Text="*" ForeColor="Red" CssClass="arial" runat="server"></asp:Label></div>
                             <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 margin-tb"><asp:DropDownList ID="dllCategory" runat="server" CssClass="form-control" >
                                    <asp:ListItem>General</asp:ListItem>
                                    <asp:ListItem>SC/ST</asp:ListItem>
                                    <asp:ListItem>OBC</asp:ListItem>
                                    <asp:ListItem>Others</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="dllCategory"
                                    ErrorMessage="Category cannot be left blank."></asp:RequiredFieldValidator></div>
                             </div>
                             </div>
                             </div>

                             <div class="box box-primary">
                                <div class="box-header with-border"><h3 class="box-title">Educational Details</h3></div>
                            <div class="box-body">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblMessage2" EnableViewState="false" CssClass="arial"
                                    runat="server" Text="" ForeColor="Red"></asp:Label></div>
                                    </div>
                            <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of the Univ./Board</b></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtBoard1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="200"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtBoard2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="200"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtBoard3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="200"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtBoard4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="200"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Stream</b></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtStream1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="100"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtStream2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="100"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtStream3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="100"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtStream4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="100"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Marks Obtained (%)</b></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMarks1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="5"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMarks2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="5"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMarks3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="5"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMarks4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="5"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Year of Completion</b></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYears1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="40"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYears2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="40"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYears3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="40"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYears4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="40"></asp:TextBox></div>
                             </div>
                             </div>
                             </div>
                             </div>
                             </div>
                                                  
                        <%-- 
                                <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                            
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                    </asp:Table>
                                </asp:Panel>
                            --%>
                            
                       <div class="box box-primary">
                                <div class="box-header with-border"><h3 class="box-title">Work Experience (Atleast One Mandatory if Current Profession is chosen as 
                                                working) <asp:Label ID="lblMessage3" EnableViewState="false" runat="server" Text="" ForeColor="Red" CssClass="arial"></asp:Label>
                                                  
                           </h3>
                           </div>
                           <div class="box-body">
                             <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Total Years of Experience</div>
                            <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:TextBox ID="txtTotExp" runat="server" CssClass="form-control" MaxLength="4"></asp:TextBox></div>
                            </div>
                            <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of Organisation</b></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtOrg1" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb "><asp:TextBox ID="txtOrg2" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtOrg3" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Phone Number</b></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtPh1" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control"  MaxLength="50" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtPh2" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control" MaxLength="50" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtPh3" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control" MaxLength="50" Width="100%"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Designation</b></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtDesignation1" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtDesignation2" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtDesignation3" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Years of Service</b></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYear1" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYear2" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYear3" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            </div>
                            </div>
                            </div>
                       </div>
                       </div>

                       <div class="box box-primary">
                                <div class="box-header with-border"><h3 class="box-title">Declaration</h3></div>
   
    <div class="box-body">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    
                    <h5>I hereby declare that the information furnished in the application form is complete and accurate. I also agree that the FMSF has the right to cancel my candidature, in case it is found that any information provided therein is incorrect, incomplete or misleading, or ineligibility being detected before or after the selection/admission.</h5>
                    </div>
      </div>
    <div class="row">&nbsp;</div>
    <div class="row">
          <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Profile Image :</div>
         <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"> <asp:FileUpload ID="FileUpload1" runat="server" />
             <asp:HiddenField ID="hdnimage" runat="server" />
         </div>
     </div>
     <div class="row">&nbsp;</div>
     <div class="row-fluid">
                             <div class="span4" align="left"><asp:TextBox ID="txtPlace" runat="server" placeholder="Place" CssClass="form-control" MaxLength="40" Width="100%"></asp:TextBox></div>
                            <div class="span6">&nbsp;</div>
      </div>
      <div class="row">&nbsp;</div>
      <div class="row" style="text-align:center"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-large btn-success"  />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-large btn-warning"  />
                                     <asp:Button ID="btnPrint" runat="server" OnClientClick="return openPopup('PrintProfile.aspx');"  Text="Print" CssClass="btn btn-large btn-primary" /> 
                                    <asp:TextBox ID="txtStudentID" runat="server" CssClass="btn btn-primary btn-large" Enabled="false" Visible="false"></asp:TextBox>
      </div>
      </div>

   </div>   
     
                                  
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
                                                    
                     
                            
       </div>
       </div>                             
                                    
   </section>
   </div>
   <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>
