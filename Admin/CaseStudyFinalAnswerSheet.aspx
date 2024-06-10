<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="CaseStudyFinalAnswerSheet.aspx.cs" Inherits="Admin_CaseStudyFinalAnswerSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">


    <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function HideMessage()
                    {
                   
                   
                     function CallPrint(strid)
                          {
                          debugger;
                           var prtContent = document.getElementById(strid);
                           var strOldOne=prtContent.innerHTML;
                           var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=1,status=0');
                           WinPrint.document.write(prtContent.innerHTML);
                           WinPrint.document.close();
                           WinPrint.focus();
                           WinPrint.print();
                          // WinPrint.close();
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
    .row-new 
    {
            border-bottom: dashed 1px #ccc;
    height: 25px;
    margin-bottom: 5px;
    margin-top: 5px;
    }
</style>
<section class="fullwidth banner-color">
    <h1 class="heading-color">Case Study Answer Sheet</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li><a href="CaseStudyPanel.aspx">Case Study</a></li>
        <li class="active">Case Study Answer Sheet</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <section class="container main m-tb">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                               <div id="print_grid" class="style5" runat="server" >
                               <div class="user-info media box" style="background-color:#fff;">
                                     <fieldset>
                                     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblCaption" runat="server" /></div></div>
                                     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="Label1" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div></div>
                                     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:LinkButton ID="lnkbtnexport" runat="server" OnClick="lnkbtnexport_Click" Visible="false">Export To Word</asp:LinkButton></div></div>
                                     <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Name :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Code :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Case Study Code :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblAssignmentCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Paper :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Name of the Student :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblStudentName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Student Reference ID :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12" ><asp:Label ID="lblStid" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                     <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label" id="trtimeAllotted" runat="server">Total Time Allotted :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblTimeAlloted" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label" id="trtimeTaken" runat="server" >Time Taken by the Student :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblTimeTaken" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label" id="trDateofassignment" runat="server" > Date of Assignment :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblDate" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label" id="tr1" runat="server" >Paper Checked By :</div>
                                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblFaculty" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                                    </div>
                                    <div class="row row-new">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text field-label" id="trSummary" runat="server"><h4>Summary </h4></div>
                                    </div>
                                    <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form_text field-label" id="trManualMarks" runat="server" visible="false"  >Enter Marks :</div>
                                    </div>
                                    <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox runat="server" ID="txtManualAssignmentMarks" cssclass="form-control"  ></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" ErrorMessage="*Required" display="dynamic" ControlToValidate="txtManualAssignmentMarks" ForeColor="Red"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtManualAssignmentMarks" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                         </div>
                                         </div>
                                        <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">Enter Feedback :</div>
                                    </div>
                                     <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:TextBox runat="server" ID="txtManualFeedback" cssclass="form-control" TextMode="MultiLine" Rows="5" ></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="txtManualFeedback" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </div>
                                         </div>
                                       <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button runat="server" ID="btnAddMarks" Text="Add Marks" OnClick="btnAddMarks_Click" class="btn btn-success" /></div>
                                    </div>
                                     <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trGrandTotal" runat="server" ><b>Grand Total
                                                                               <asp:Label ID="lblGrand" runat="server" />
                                                                               </b>
                                                                    </div></div>
                                         
                                        <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trAnswerSheet" runat="server" ><strong>Answer Sheet </strong>
                                                                       </div></div>
                                        <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <%--<asp:Label ID="hdnuserid" runat="server" />--%>
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" Visible="false"/>
                                                <asp:HiddenField ID="hdnTotalMarks" runat="server" Visible="false"/>
                                                <asp:HiddenField ID="hdnSectionId" runat="server" Visible="false"/>
                                               
                                           </div>
                                           </div>
                                    </fieldset>
                                </div>
                                </div>
                                </div>
                                </div>
                                </section>
                            
    </form>
</asp:Content>

