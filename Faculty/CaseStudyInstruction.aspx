<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="CaseStudyInstruction.aspx.cs" Inherits="Faculty_CaseStudyInstruction" %>

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
                        function CallPrint(strid)
                        {
                            
                           var prtContent = document.getElementById(strid);
                           var strOldOne = prtContent.innerHTML;
                           
                           var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
                           WinPrint.document.write(prtContent.innerHTML);
                           WinPrint.document.close();
                           WinPrint.focus();
                           WinPrint.print();
                           WinPrint.close();
                           prtContent.innerHTML=strOldOne;
                          }
    </script>

    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            height: 15px;
            
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            height: 15px;
            
        }
        
    </style>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>
   <section class="fullwidth banner-color">
    <h1 class="heading-color">Case Study Instruction</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">Case Study Instruction</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="frame">
        
    
    <section class="container main m-tb">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
       <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
      
       </div>
       </div>
      <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right">
                             <asp:Button ID="ImageButton1" runat="server" text="Print" cssclass="btn btn-primary" ToolTip="Print" /> 
                             <asp:Button ID="ImgBack" runat="server" text="Back" cssclass="btn btn-warning" ToolTip="Back" onclick="ImgBack_Click" />
                             </div></div>
       
                            
                               <div id="print_grid" class="style5" runat="server" >
                                    
                                     <fieldset>
                                         <div class="user-info media box" style="background-color:#fff;">
                                         <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
                                            <legend class="style9_sec"><b>Case Study Answer Sheet</b></legend>
                                    <asp:Label ID="lblCaption" runat="server" />
         </div>
                                             </div>
                                    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <asp:Label ID="Label1" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
         </div></div>
         <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:right">                                              
                                                            <asp:LinkButton ID="lnkbtnexport" runat="server" OnClick="lnkbtnexport_Click" Visible="false" cssclass="btn btn-warning">Export To Word</asp:LinkButton>
                                                        </div></div>
                                                    <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                                                        Course Name :</div>

                                                                    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </div></div>
                                                                <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Course Code :</div>
 <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                                                    </div>
                                         <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Case Study Code :</div>
 <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                             </div>
                                             <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Paper :</div>
<div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                                 </div>
                                         <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Name of the Student</div>
<div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblStudentName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                             </div>
                                              <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Student Reference ID :</div>
<div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblStid" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                                  </div>
                                                  <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Total Time Allotted :</div>
<div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblTimeAlloted" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                                      </div>
                                                      <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Time Taken by the Student :</div>
<div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblTimeTaken" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                                          </div>
                                                          <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">Date of Case Study :</div>
<div class="col-lg-9 col-md-9 col-sm-12 col-xs-12"><asp:Label ID="lblDate" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                                              </div>
                                                               
                                                           </div>

                                                            
                                                                        <fieldset>
                                                                            <div class="user-info media box" style="background-color:#fff;">
                                                                                <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <legend>Case Study - Question</legend>
         </div></div>
           <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 "> 
                <asp:Label ID="lblcaseStudy" runat="server" ></asp:Label>
         </div></div>
          </div>
        </fieldset>
                                                                   
                                                                        <fieldset>
                                                                            <div class="user-info media box" style="background-color:#fff;">
                                                                                <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <legend>Case Study - Answer</legend>
             </div></div>
           <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 "> 
                  <asp:Label ID="lblAnswers" runat="server" ></asp:Label>
         </div></div>
          </div>
        </fieldset>
                                                                 
                                                                        <fieldset>
                                                                            <div class="user-info media box" style="background-color:#fff;">
                                                                                <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center">
    <legend>Remarks & Marks</legend>
           </div></div>
           <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">Enter Marks :</div>
                                         <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 ">
                                             <asp:TextBox runat="server" ID="txtManualAssignmentMarks" cssclass="form-control"  ></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" ErrorMessage="*Required" ControlToValidate="txtManualAssignmentMarks" ForeColor="Red"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtManualAssignmentMarks" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                         </div>
               </div>
               <div class="row">
     <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">Enter Feedback :</div>
<div class="col-lg-9 col-md-9 col-sm-12 col-xs-12 "><asp:TextBox runat="server" ID="txtManualFeedback" TextMode="MultiLine" Rows="5" Columns="5" cssclass="form-control"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="txtManualFeedback" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </div>
                   </div>
                   <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button runat="server" ID="btnAddMarks" Text="Add Marks" cssclass="btn btn-success" OnClick="btnAddMarks_Click" />
                                            </div></div>
              <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Label ID="lblMSG" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </div></div>
                                                                                </div>
        </fieldset>
                                                                    
                                                <%--<asp:Label ID="hdnuserid" runat="server" />--%>
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" Visible="false"/>
                                                <asp:HiddenField ID="hdnSectionId" runat="server" Visible="false"/>
                                           
                                    </fieldset>
                                </div>
                                                                                      
     
                                            </section>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            
    </form>

</asp:Content>


