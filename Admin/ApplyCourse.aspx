<%@ Page Language="VB" MasterPageFile="~/InnerMaster.master" AutoEventWireup="false" CodeFile="ApplyCourse.aspx.vb" Inherits="Admin_ApplyCourse" %>

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


    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">

    <section class="title">
        <div class="container">
            <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff">Apply Another Course</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a><span class="divider">/</span></li>
                        <li class="active"><a href="../logout.aspx" id="anc2" runat="server"><font color="#fff"><b>Logout</b></font></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </section>

    <section class="container main">
            <div class="row-fluid">
                <div class="span12">

                <div class="user-info media box" style="background-color:#fff;">
                 <div class="row-fluid"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                 <div class="row-fluid"><div class="span12 form_head">Course Details</div></div>
                 <div class="row-fluid" style="margin-top: 20px;">
                 <div class="span5 form_text field-label">Course Title :</div>
                 <div class="span4"> <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" required="required" placeholder="Course" title="Course"/></div>
                 </div>
                 </div>

                 <div class="user-info media box" style="background-color:#fff; margin-top:10px">
                 <div class="row-fluid"><div class="span12 form_head">Account Details</div></div>
                 <div class="row-fluid" style="margin-top: 20px;">
                             <div class="span5 form_text field-label">Email Address :</div>
                             <div class="span4"><asp:TextBox ID="txtEmailAddress" runat="server" CssClass="form-control" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                             </div>
                  </div>

                  <div class="user-info media box" style="background-color:#fff; margin-top:10px">
                  <div class="row-fluid"><div class="span12 form_head">Contact Details</div></div>
                  <div class="row-fluid" style="margin-top: 20px;">
                  <div class="span5 form_text field-label">First Name :</div>
                             <div class="span4"><asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row-fluid">
                    <div class="span5 form_text field-label">Middle Name :</div>
                             <div class="span4"><asp:TextBox ID="txtMiddleName" runat="server" CssClass="form-control" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row-fluid">
                    <div class="span5 form_text field-label">Last Name :</div>
                             <div class="span4"><asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Enabled="false" MaxLength="49" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row-fluid">
                    <div class="span5 form_text field-label">Date of Birth :</div>
                             <div class="span4"><asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" Enabled="false" MaxLength="10" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row-fluid">
                    <div class="span5 form_text field-label">Permanent Address :</div>
                             <div class="span4"><asp:TextBox ID="txtPermanentAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row-fluid">
                    <div class="span5 form_text field-label">Correspondence Address :</div>
                             <div class="span4"><asp:TextBox ID="txtCorrespondenceAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Enabled="false" MaxLength="100" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row-fluid">
                    <div class="span5 form_text field-label">Contact Number :</div>
                             <div class="span4"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" Enabled="false" ReadOnly="True"></asp:TextBox></div>
                    </div>
                    <div class="row-fluid">
                    <div class="span5 form_text field-label">Mobile Number :</div>
                             <div class="span4"><asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" Enabled="false" ReadOnly="True"></asp:TextBox></div>
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
                                                    
                 <div class="user-info media box" style="background-color:#fff; margin-top:10px">
                  <div class="row-fluid"><div class="span12 form_head">Personal Details</div></div>
                  <div class="row-fluid" style="margin-top: 20px;">
                  <div class="span5 form_text field-label">Gender :</div>
                  <div class="span4"><asp:DropDownList ID="dllGender" runat="server" CssClass="form-control">
                                                                <asp:ListItem>Male</asp:ListItem>
                                                                <asp:ListItem>Female</asp:ListItem>
                                                            </asp:DropDownList></div>
                  </div>
                  <div class="row-fluid">
                  <div class="span5 form_text field-label">Current Profession :</div>
                  <div class="span4"><asp:TextBox ID="txtProfession" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                  </div>
                  <div class="row-fluid">
                  <div class="span5 form_text field-label">Nationality :<asp:Label ID="Label9" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                  <div class="span4"><asp:TextBox ID="txtNationality" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNationality" Display="Dynamic"
                                                                ErrorMessage="Nationality  cannot be left blank."></asp:RequiredFieldValidator></div>
                  </div>  
                  <div class="row-fluid">
                  <div class="span5 form_text field-label">Category :<asp:Label ID="Label10" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                  <div class="span4"><asp:TextBox ID="txtCategory" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCategory" Display="Dynamic"
                                                                ErrorMessage="Category cannot be left blank."></asp:RequiredFieldValidator></div>
                  </div> 
                  </div>
                  <div class="user-info media box" style="background-color:#fff; margin-top:10px">
                  <div class="row-fluid"><div class="span12 form_head">Educational Details</div></div>   
                       <div class="row-fluid">
                             <div class="span3">
                             <div class="row-fluid">
                             <div class="span12 form_text"><b>Name of the Univ./Board</b></div>
                             <div class="span12"><asp:TextBox ID="txtBoard1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtBoard2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtBoard3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtBoard4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="span3">
                             <div class="row-fluid">
                             <div class="span12 form_text"><b>Stream</b></div>
                             <div class="span12"><asp:TextBox ID="txtStream1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtStream2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtStream3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtStream4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="span3">
                             <div class="row-fluid">
                             <div class="span12 form_text"><b>Marks Obtained (%)</b></div>
                             <div class="span12"><asp:TextBox ID="txtMarks1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtMarks2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtMarks3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtMarks4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             </div>
                             </div>
                             <div class="span3">
                             <div class="row-fluid">
                             <div class="span12 form_text"><b>Year of Completion</b></div>
                             <div class="span12"><asp:TextBox ID="txtYears1" runat="server" Title="10th" placeholder="10th" CssClass="form-control" MaxLength="15"></asp:TextBox></div> 
                             <div class="span12"><asp:TextBox ID="txtYears2" runat="server" Title="12th" placeholder="12th" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtYears3" runat="server" Title="Graduation" placeholder="Graduation" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             <div class="span12"><asp:TextBox ID="txtYears4" runat="server" Title="Any Other" placeholder="Any Other" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                             </div>
                             </div> 
                             </div>
                             </div>    
                             
                             
                             <div class="user-info media box" style="background-color:#fff;">
                         <div class="row-fluid">
                            <div class="span12 form_head">Work Experience (Atleast One Mandatory if Current Profession is chosen as working)</div>
                            </div>
                            <div class="row-fluid" style="margin-top: 20px; border-bottom:solid 1px #c0c0c0; margin-bottom:10px">
                            <div class="span3 form_text field-label">Total Years of Experience</div>
                            <div class="span4"><asp:TextBox ID="txtTotExp" runat="server" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                            </div>
                            <div class="row-fluid">
                            <div class="span3">
                            <div class="row-fluid">
                            <div class="span12 form_text"><b>Name of Organisation</b></div>
                            <div class="span12"><asp:TextBox ID="txtOrg1" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="span12"><asp:TextBox ID="txtOrg2" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="span12"><asp:TextBox ID="txtOrg3" runat="server" Title="Name of Organisation" placeholder="Name of Organisation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="span3">
                            <div class="row-fluid">
                            <div class="span12 form_text"><b>Phone Number</b></div>
                            <div class="span12"><asp:TextBox ID="txtPh1" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="span12"><asp:TextBox ID="txtPh2" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="span12"><asp:TextBox ID="txtPh3" runat="server" Title="Phone Number" placeholder="Phone Number" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="span3">
                            <div class="row-fluid">
                            <div class="span12 form_text"><b>Designation</b></div>
                            <div class="span12"><asp:TextBox ID="txtDesignation1" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="span12"><asp:TextBox ID="txtDesignation2" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="span12"><asp:TextBox ID="txtDesignation3" runat="server" Title="Designation" placeholder="Designation" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            </div>
                            </div>
                            <div class="span3">
                            <div class="row-fluid">
                            <div class="span12 form_text"><b>Years of Service</b></div>
                            <div class="span12"><asp:TextBox ID="txtYear1" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" width="100%" MaxLength="15"></asp:TextBox></div>
                            <div class="span12"><asp:TextBox ID="txtYear2" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            <div class="span12"><asp:TextBox ID="txtYear3" runat="server" Title="Years of Service" placeholder="Years of Service" CssClass="form-control" MaxLength="100" Width="100%"></asp:TextBox></div>
                            </div>
                            </div>
                            </div>
                       </div>
                             
                             
                             <div class="user-info media box" style="background-color:#fff;">
     <div class="row-fluid">
                <div class="span12 form_head">Declaration</div>
    </div>
     <div class="row-fluid" style="margin-top:20px">
                <div class="span12">
                    
                    <h6>I hereby declare that the information furnished in the application form is 
                                                            complete and accurate. I also agree that the FMSF has the right to cancel my 
                                                            candidature, in case it is found that any information provided therein is 
                                                            incorrect, incomplete or misleading, or ineligibility being detected before or 
                                                            after the selection/admission.</h6>
                                                       </div>
      </div>
     <div class="row-fluid">&nbsp;</div>
     <div class="row-fluid">
                             <div class="span4" align="left"><asp:TextBox ID="txtPlace" runat="server" placeholder="Place" CssClass="form-control" MaxLength="15"></asp:TextBox></div>
                            <div class="span6">&nbsp;</div>
      </div>
      <div class="row-fluid">&nbsp;</div>
      <div class="row-fluid center"><asp:Button ID="btnSave" runat="server"  Text="Save" CssClass="btn btn-large btn-success"/>
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

</asp:Content>
