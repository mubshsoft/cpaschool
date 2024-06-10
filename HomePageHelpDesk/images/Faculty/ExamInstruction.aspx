<%@ Page Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="ExamInstruction.aspx.cs" Inherits="Faculty_ExamInstruction" %>
<%--<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title></title>--%>
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
</style>
    <form id="form1" runat="server">
    <div onkeypress="HideMessage()">
     <section class="title">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <h2 style="color:#fff">Exam Answer Sheet</h2>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <ul class="breadcrumb pull-right">
                        <li><a href="Adminlogin.aspx"><font color="#fff">Admin Panel</font></a> <span class="divider">/</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
                        </div>
                        </div>
   </section>
  <section class="container main m-tb">
    
        <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="pull-right">
         <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" ToolTip="Print" />
         <asp:Button ID="ImgBack" runat="server" Text="Back" CssClass="btn btn-large btn-warning" ToolTip="Back" onclick="ImgBack_Click" /></span>
         </div></div>         
         <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="print_grid">
                               <fieldset>
                               <div class="row"><asp:Label ID="lblCaption" runat="server" /></div>
                               <div class="row"><asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                               <div class="row"><asp:LinkButton ID="lnkbtnexport" runat="server" OnClick="lnkbtnexport_Click" Visible="false">Export To Word</asp:LinkButton></div>
                               <div class="user-info media box" style="background-color:#fff;">
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Name</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Course Code</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Examination</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblExamCode" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Paper</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Name of the Student</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblStudentName" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Student Reference ID</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblStid" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Total Time Allotted</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblTimeAlloted" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Time Taken by the Student</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblTimeTaken" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               <div class="row">
                               <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12 form_text field-label">Date of Examination</div>
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12"><asp:Label ID="lblDate" runat="server" Text="" Font-Bold="true"></asp:Label></div>
                               </div>
                               </div>
                                 
  <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend>Summary</legend></div></div>   
  <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
  <asp:DataList ID="dlstInstructionSummary" runat="server" Width="100%" CssClass="table"
                                                                RepeatColumns="1" OnItemDataBound="dlstInstructionSummary_ItemDataBound">
                                                                <ItemTemplate>
                                                                   <asp:Label Width="100%" CssClass="form_head" ID="lblSummaryCategoryName" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                                                  <table width="100%">
                                                                        <tr>
                                                                            <td width="50" align="left" class="style5">
                                                                                a.
                                                                            </td>
                                                                            <td width="250" align="left" class="style5">
                                                                               Maximum No. of Questions
                                                                            </td>
                                                                            <td width="300" align="left" class="style5">
                                                                                <asp:Label ID="lblPaperName" runat="server" Text='<%# Eval("AttemptQue") %>'></asp:Label>
                                                                                out of
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("MaxNoQue") %>'></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                          <tr id="trFirstRow" runat="server">
                                                                            <td width="50" align="left" class="style5">
                                                                                b.
                                                                            </td>
                                                                            <td width="250" align="left" class="style5">
                                                                                No. of Questions Attempted
                                                                            </td>
                                                                            <td width="300" align="left" class="style5">
                                                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("UserAttemptQue") %>'></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        
                                                                        <tr>
                                                                            <td width="50" align="left" class="style5">
                                                                                c.
                                                                            </td>
                                                                            <td width="250" align="left" class="style5">
                                                                                Maximum Marks in Section
                                                                            </td>
                                                                            <td width="300" align="left" class="style5">
                                                                                 <asp:Label ID="lblmaxquemarks" runat="server" Text='<%# Eval("TOTMaxQueMarks") %>'></asp:Label>
                                                                                  &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="50" align="left" class="style5">
                                                                                d.
                                                                            </td>
                                                                            <td width="250" align="left" class="style5">
                                                                                Marks Scored-
                                                                            </td>
                                                                            <td width="300" align="left" class="style5">
                                                                                 <asp:Label ID="lbltotalObjmarks" runat="server" ></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <%--  <tr>
                                              <td colspan="2" align="left" class="style5">Grand Total(Section I + II + III)</td>
											  <td>&nbsp;</td>
                                            </tr>--%>
                                                                    </table>
                                                                </ItemTemplate>
                                                              
                                                            </asp:DataList>
  </div></div>                                                     
   <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><h4>Grand Total <asp:Label ID="lblGrand" runat="server" /></h4></div></div>
   <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><legend>Answer Sheet</legend></div></div>
   <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:DataList ID="dlstanswers" runat="server" Width="100%" 
                                                    OnItemDataBound="dlstanswers_ItemDataBound">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblcategoryname" runat="server" Text=' <%#Eval("CategoryName") %>'></asp:Label>
                                                        <table Width="100%">
                                                            <tr>
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                    Question. <%#Container.ItemIndex+1 %>
                                                                        <%--<asp:Label ID="Label3" runat="server" Text="Question  <%# Container.DataItemIndex + 1 %> "></asp:Label>--%></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="lblquestiontext" runat="server" Text='<%#Eval("QuestionText") %>'></asp:Label></strong>
                                                                </td>
                                                                <td width="10%" align="left">
                                                                    (
                                                                    <asp:Label ID="lblmaxmarks" runat="server" Text='<%#Eval("maxquemarks") %>' CssClass="style9_sec"></asp:Label>
                                                                    )
                                                                </td>
                                                            </tr>
                                                            <tr id="trImage" runat="server">
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        
                                                                </td>
                                                                <td width="75%" align="left">
                                                                  <asp:Image ID="imgUploadImage" runat="server" />
                                                                  
                                                                </td>
                                                                <td width="10%" align="left">
                                                                  
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr>
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label1" runat="server" Text="Answers  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:HiddenField ID="hdnAnsid" runat="server" Value='<%#Eval("AnsId") %>' />
                                                                    <asp:Label ID="lblanstext" runat="server" Text='<%#Eval("anstext") %>' CssClass="style9_sec"></asp:Label>
                                                                    <br /> <asp:LinkButton ID="lnkfileupload" OnClick="imgFileOpenLink" runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "uploadpath")%>'
                                                                Text='<%#DataBinder.Eval(Container.DataItem, "uploadpath")%>'></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr id="trcorrectans" runat="server">
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="lblcorectanswers" runat="server" Text="Correct Answer  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:Label ID="lblcorectanswerstext" runat="server" Text='<%#Eval("answer") %>' CssClass="style9_sec"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr id="trRow3" runat="server">
                                                                <td width="15%" align="left">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label7" runat="server" Text="Marks Scored  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:Label ID="hdnquestype" runat="server" Text='<%#Eval("questype") %>' Visible="false" />
                                                                     <asp:Label ID="hdnquesid" runat="server" Text='<%#Eval("questionid") %>' Visible="false" />
                                                                    <asp:Label ID="hdnCatgId" runat="server" Text='<%#Eval("CategoryId") %>' Visible="false" />
                                                               <asp:Label ID="lblMarkscored" runat="server"  />
                                                                     <asp:TextBox ID="txtMarkscored" runat="server" Visible="false" ToolTip="Enter Marks" Text='<%#Eval("MarkGivenByFaculty") %>'  />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" ErrorMessage="*Required" ControlToValidate="txtMarkscored" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMarkscored" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr id="trRow1" runat="server"  >
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label2" runat="server" Text="Feedback  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left" >
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 120px" id="trRow2" runat="server" >
                                                            <td>&nbsp;</td>
                                                            <%--<td  style="border: thin solid #000000"> &nbsp;</td>--%>
                                                                <td>
                                                                <asp:TextBox ID="txtfeedback" runat="server" TextMode="MultiLine" Rows="5" Columns="5" Text='<%#Eval("Feedback") %>'   ToolTip='<%#Eval("questionid") %>' style="border: thin solid rgb(0, 0, 0); margin: 0px 0px 10px; width: 630px; height: 135px;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                               <tr id="trLineMain" runat="server">
                                                                <td colspan="3" >
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                          <asp:DataList ID="dlstSubanswers" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                        <table width="100%" >
                                                            <tr>
                                                                <td colspan="3" align="center">
                                                                   <%-- <strong class="style9_sec">
                                                                        <asp:Label ID="lblcategoryname" runat="server" Text=' <%#Eval("CategoryName") %>'></asp:Label>
                                                                    </strong>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label3" runat="server" Text="Sub Question  <%# Container.DataItemIndex + 1 %> "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="lblquestiontext" runat="server" Text='<%#Eval("QuestionText") %>'></asp:Label></strong>
                                                                </td>
                                                                <td width="10%" align="left">
                                                                    (
                                                                    <asp:Label ID="lblmaxmarks" runat="server" Text='<%#Eval("maxquemarks") %>' CssClass="style9_sec"></asp:Label>
                                                                    )
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr>
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label1" runat="server" Text="Answers  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:Label ID="lblanstext" runat="server" Text='<%#Eval("anstext") %>' CssClass="style9_sec"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr id="trcorrectans" runat="server">
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="lblcorectanswers" runat="server" Text="Correct Answer  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:Label ID="lblcorectanswerstext" runat="server" Text='<%#Eval("answer") %>' CssClass="style9_sec"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr>
                                                                <td width="15%" align="left">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label7" runat="server" Text="Marks Scored  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:Label ID="hdnquestype" runat="server" Text='<%#Eval("questype") %>' Visible="false" />
                                                                    <asp:Label ID="hdnCatgId" runat="server" Text='<%#Eval("CategoryId") %>' Visible="false" />
                                                                    <asp:TextBox ID="txtSubMarkscored" runat="server"  ToolTip="Enter Marks" Text='<%#Eval("MarkGivenByFaculty") %>'  />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="txtSubMarkscored" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSubMarkscored" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr id="trRow1" runat="server"  >
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label2" runat="server" Text="Feedback  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left" >
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 120px" id="trRow2" runat="server" >
                                                            <td>&nbsp;</td>
                                                            <%--<td  style="border: thin solid #000000"> &nbsp;</td>--%>
                                                                <td>
                                                                    <asp:TextBox ID="txtfeedback" runat="server" TextMode="MultiLine" Rows="5" Columns="5" Text='<%#Eval("Feedback") %>'  ToolTip='<%#Eval("questionid") %>' style="border: thin solid rgb(0, 0, 0); margin: 0px 0px 10px; width: 630px; height: 135px;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr id="trLineSub" runat="server">
                                                                <td colspan="3" >
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                    </ItemTemplate>
                                                </asp:DataList>
    </div></div>                                       
     <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <%--<asp:Label ID="hdnuserid" runat="server" />--%>
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnExamId" runat="server" Visible="false"/>
                                                <asp:HiddenField ID="hdnSectionId" runat="server" Visible="false"/>
                                                <asp:HiddenField ID="hdnTotalMarks" runat="server" Visible="false"/>
                                                <asp:Button ID="btnSave" runat="server" Text="Add Comment" OnClick="btnSave_Click" />
                                           </div></div>
                                    </fieldset>
                                    </div>
                                    
          </div>
          </section>
    </div>
    </form>

</asp:Content>

