<%@ Page Language="VB" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="false" CodeFile="ApplyCourse.aspx.vb" Inherits="Student_ApplyCourse" Title="Student Registration Form" %>

<%--<%@ Register Src="../studentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #0e245d;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
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
                     
                     function openPopup(strOpen,id)
                         {
                          open(strOpen,id, "Info", "status=1, width=700, height=800, top=20, left=300,scrollbars=yes");
                         }
    </script>

    <style type="text/css">
        .style14
        {
            height: 17px;
        }
    </style>


    
    <div class="content-wrapper" onkeypress="HideMessage()">
     <!-- Content Header (Page header) -->
    <section class="content-header">
          <h1>
            Apply another Course
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> student Panel</a></li>
            <li class="active">Apply another Course</li>
          </ol>
        </section>
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                <div class="box box-primary box-solid">
                <div class="box-header"><h3 class="box-title with-border">Course Details</h3></div>
                <div class="box-body">
                 <div class="row"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                 <div class="row" style="margin-top: 20px;">
                 <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label">Course Title :</div>
                 <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:TextBox ID="txtCourseTitle" runat="server" CssClass="form-control" Enabled="false" MaxLength="48" ReadOnly="True"></asp:TextBox></div>
                 </div>
                 </div>
                 </div>
                 <div class="box box-primary box-solid">
                <div class="box-header"><h3 class="box-title with-border">Account Details</h3></div>
                <div class="box-body">
                 <div class="row" style="margin-top: 20px;">
                             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label">Email Address :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9"><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
                  </div>
                  </div>
                  <div class="box box-primary box-solid">
                <div class="box-header"><h3 class="box-title with-border">Contact Details</h3></div>
                <div class="box-body">
                  <div class="row" style="margin-top: 20px;">
                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">First Name :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Middle Name :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Last Name :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Date of Birth :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" Enabled="false" MaxLength="10" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Permanent Address :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Correspondence Address :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="false" MaxLength="100" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Contact Number :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Mobile Number :</div>
                             <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                    </div>
                  </div>
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
                                                    
                 <div class="box box-primary box-solid">
                <div class="box-header"><h3 class="box-title with-border">Personal Details</h3></div>
                <div class="box-body">
                  <div class="row" style="margin-top: 20px;">
                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Gender :</div>
                  <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:DropDownList ID="dllGender" runat="server" CssClass="form-control">
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList></div>
                  </div>
                  <div class="row">
                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Current Profession :</div>
                  <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtProfession" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                  </div>
                  <div class="row">
                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                  <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtNationality" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNationality" Display="Dynamic"
                                                                ErrorMessage="Nationality  cannot be left blank."></asp:RequiredFieldValidator></div>
                  </div>  
                  <div class="row">
                  <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Category :<asp:Label ID="Label10" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                  <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCategory" Display="Dynamic"
                                                                ErrorMessage="Category cannot be left blank."></asp:RequiredFieldValidator></div>
                  </div> 
                  </div>
                  </div>
                  <div class="box box-primary box-solid">
                <div class="box-header"><h3 class="box-title with-border">Educational Details</h3></div> 
                <div class="box-body">  
                       <div class="row">
                             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of the Univ./Board</b></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtBoard1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtBoard2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtBoard3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtBoard4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Stream</b></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtStream1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtStream2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtStream3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtStream4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Marks Obtained (%)</b></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMarks1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMarks2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMarks3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtMarks4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                             <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Year of Completion</b></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYears1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="15"></asp:TextBox></div> 
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYears2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYears3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYears4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             </div>
                             </div> 
                             </div>
                             </div>    
                             </div>
                             
                             <div class="box box-primary box-solid">
                <div class="box-header"><h3 class="box-title with-border">Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</h3>
                            </div>
                            <div class="box-body"> 
                            <div class="row" style="margin: 20px 0;">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form_text field-label margin-tb">Total Years of Experience</div>
                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 margin-tb"><asp:TextBox ID="txtTotExp" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                            </div>
                            <div class="row">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Name of Organisation</b></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtOrg1" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtOrg2" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtOrg3" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Phone Number</b></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtPh1" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtPh2" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtPh3" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Designation</b></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtDesignation1" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtDesignation2" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtDesignation3" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                            <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text"><b>Years of Service</b></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYear1" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYear2" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 margin-tb"><asp:TextBox ID="txtYear3" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            </div>
                            </div>
                            </div>
                       </div>
                         </div>    
                             
                             <div class="box box-primary box-solid">
                <div class="box-header"><h3 class="box-title with-border">Declaration</h3>
    </div>
    <div class="box-body"> 
     <div class="row" style="margin-top:20px">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    
                    <h5>I hereby declare that the information furnished in the application form is 
                                                            complete and accurate. I also agree that the FMSF has the right to cancel my 
                                                            candidature, in case it is found that any information provided therein is 
                                                            incorrect, incomplete or misleading, or ineligibility being detected before or 
                                                            after the selection/admission.</h5>
                                                       </div>
      </div>
     <div class="row">&nbsp;</div>
     <div class="row">
                             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="left"><asp:TextBox ID="txtPlace" runat="server" placeholder="Place" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                            
      </div>
      </div>
      </div>
      <div class="row">&nbsp;</div>
      <div class="row" style="text-align:center"><asp:Button ID="btnSave" runat="server"  Text="Save" CssClass="btn btn-large btn-success"/>
                                     <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-large btn-warning"/>
                                     <asp:Button ID="btnPrint" runat="server" OnClientClick="return openPopup('PrintRegistration.aspx');" Enabled="false" Text="Print" CssClass="btn btn-large btn-primary" />

                                                    </div></div>
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
                                                                </div>
                                                                </div>
                                                                
                                                                </section>
                                                             
                                                         
    </form>
</div>

    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>