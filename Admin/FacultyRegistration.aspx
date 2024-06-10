﻿<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="FacultyRegistration.aspx.vb" Inherits="Admin_FacultyRegistration" Title="Faculty Registration Form" %>

<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>


  <%--  <script language="javascript" type="text/javascript">
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
                     
                                         
    </script>--%>

    <asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">Faculty registration form</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
             <%If Session("role") = "Admin" Then%>
                        <li><a href="AdminLogin.aspx"><font color="#fff">Admin Panel</font></a></li>
                        <% ElseIf Session("role") = "Faculty" Then %>
                        <li><a href="../faculty/Facultypanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
                        <% ElseIf Session("role") = "Student" Then%>
                        <li><a href="../Student/StudentPanel.aspx"><font color="#fff">Student Panel</font></a></li>
                                                                    
                                                                    <%End If %>
       <li class="active">Faculty registration form</li>
		</ul>
	</div>
    </section>

    <form id="form1" runat="server" enctype="multipart/form-data">

   
    <!-- / .title -->
    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </div>
    </div>
     <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">  
                     
      
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate >
                 <div class="user-info media box" style="background-color:#fff;">
                 <div class="row">                   
                             <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                             </div>
                 <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Account Details</div></div>
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Email Address :<asp:Label ID="Label1" Text="*" ForeColor="Red" runat="server"></asp:Label> (will be the user id)</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" MaxLength="49"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailAddress"
                                                                ErrorMessage="Invalid Email Address" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                        </div>
                                                        </div>
                                                        
                             <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Password :<asp:Label ID="Label2" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" MaxLength="49"></asp:TextBox>
                                                           <%--<asp:TextBox ID="txtPassword" runat="server" CssClass="style11feedback_sec" TextMode="Password"
                                                                MaxLength="49"></asp:TextBox>--%>
                                                                </div>
                                                                </div>

                                                                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Confirm Password :<asp:Label ID="Label3" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control"
                                                                ></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password entries does not match"
                                                                ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator>
                                                                </div>
</div>
</div>
<div class="user-info media box" style="background-color:#fff; margin-top:10px">
                             <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Contact Details</div></div>
                             <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">First Name :
                                                            <asp:Label ID="Label4" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                                                            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" Display="Dynamic"
                                                                ErrorMessage="First name cannot be left blank"></asp:RequiredFieldValidator></div>
                                                                </div>

                                                                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Middle Name :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox></div>
                             </div>
                             <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Last Name :
                                                            <asp:Label ID="Label5" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                                                            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" Display="Dynamic"
                                                                ErrorMessage="Last name cannot be left blank."></asp:RequiredFieldValidator></div>
                                                                </div>

                                                                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Date of Birth :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox></div>
                             </div>
<%-- <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        --%>
                             <div class="row">
                            <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Permanent Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="form-control"
                                                                TextMode="MultiLine" Rows="4" ></asp:TextBox></div>
                                                                </div>

                                                                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Correspondence Address :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="form-control"
                                                                TextMode="MultiLine" Rows="4"></asp:TextBox></div>
                                                                </div>

                                                                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Contact Number :
                                                            <asp:Label ID="Label8" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                                                            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control"
                                                                MaxLength="15"></asp:TextBox>
                                                            <asp:Label ID="lblMessage4" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                                                            </div>

                                                            <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Mobile Number :</div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                            <asp:Label ID="lblMessage5" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                                                            </div>
                                                            </div>
<div class="user-info media box" style="background-color:#fff; margin-top:10px">
<div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_head">Personal Details</div></div>
                             <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Gender :</span></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:DropDownList ID="dllGender" runat="server" CssClass="form-control" >
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList></div>
                                                            </div>
                                                            <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" runat="server"></asp:Label></span></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtNationality" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNationality"
                                                                ErrorMessage="Nationality  cannot be left blank." Display="Dynamic"></asp:RequiredFieldValidator></div>
                                                                </div>

                                                                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Category :</span></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:DropDownList ID="dllCategory" runat="server" CssClass="form-control" >
                                                                <asp:ListItem>Select</asp:ListItem>
                                                                <asp:ListItem>General</asp:ListItem>
                                                                <asp:ListItem>SC/ST</asp:ListItem>
                                                                <asp:ListItem>OBC</asp:ListItem>
                                                                <asp:ListItem>Others</asp:ListItem>
                                                            </asp:DropDownList></div>
                                                            </div>
                                                            <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Profile :</span></div>
                             <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:TextBox ID="txtprofile" CssClass="form-control" MaxLength="1000" 
                                                                runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox></div>
                                                                </div>
     <div class="row">
          <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Profile Image :</span></div>
         <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"> <asp:FileUpload ID="FileUpload1" runat="server" />
             <asp:HiddenField ID="hdnimage" runat="server" />
         </div>
     </div>
                                                                <div class="row">&nbsp;</div>
                                                                <div class="row">
                             <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12">&nbsp;</div><div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                             <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success btn-large arial" />
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-warning btn-large arial" CausesValidation="false" />
                                                            
                                                            <asp:Button ID="btnEdit" Visible="false" Text="Edit" runat="server" CssClass="btn btn-primary btn-large arial" />
                             </div>
                             </div>

                                                  
                                                    
                                                    
                                                    
                                                    <%--                                                  <tr>
                                                   <td  >
                                                            &nbsp;</td>
                                                            
                                                  <td>
                                                        &nbsp;</td>
                                                  <td align="left"> 
                                                  <div style="width:210px; overflow-x:auto">
                                                      <asp:ListBox ID="lst" runat="server" CssClass="NormalText"  
                                                          SelectionMode="Multiple"  Height="100px" width="310px"></asp:ListBox>
                                                   </div>
                                                      </td>
                                                  </tr>--%>
                                                   </div>
   
                                                </ContentTemplate>

                 <Triggers>
<asp:PostBackTrigger ControlID="btnSave" />
</Triggers>
    </asp:UpdatePanel>
                                            
                                   
                                
    
    </div>
    </div>
    </section>



    </form>
</asp:Content>