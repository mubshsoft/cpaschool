<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="AssignmentInstruction.aspx.cs" Inherits="Faculty_AssignmentInstruction" EnableEventValidation="false" %>

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
    <div onkeypress="javascript:HideMessage()">
       
        <div class="frame">
        <section class="title">
        <div class="container">
        <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <h2 style="color:#fff">Answer Sheet</h2>
                </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                    <ul class="breadcrumb pull-right">
                        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a> <span class="divider">|</span></li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff"><b>Logout</b></font></a></li>
                        </ul>
                </div>
            </div>
       </div>
    </section>
    
    <section class="container main m-tb">
    <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
       <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
      
       </div>
       </div>
      <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                           <table width="100%" cellpadding="0" cellspacing="0">
         <tr>
                            <td align="right">
                             <%--<asp:ImageButton ID="ImageButton1" runat="server"   
                                                ImageUrl="~/Images/Print.png" tyle="text-align: left" ToolTip="Print" 
                                                 />&nbsp;&nbsp;--%>
                                <asp:Button ID="ImageButton1" runat="server" Text="Print" CssClass="btn btn-large btn-primary" ToolTip="Print" />&nbsp
                                <asp:Button ID="Button1" runat="server" Text="Back" CssClass="btn btn-large btn-warning" ToolTip="Back" onclick="ImgBack_Click" />
                                                <%-- <asp:Button ID="ImgBack" runat="server"   
                                                ImageUrl="~/Images/back.png" tyle="text-align: left" 
                                    ToolTip="Back" onclick="ImgBack_Click" 
                                                 />--%>
                                                 </td>
                             </tr>
                        <tr>
                            <td align="center" valign="top">
                               <div id="print_grid" class="style5" runat="server" >
                                     <fieldset>
                                            <legend class="style9_sec"><b>Assignment Answer Sheet</b></legend>
                                    <table width="900" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" >
                                                <table width="100%">
                                                    <tr>
                                                      <td colspan="2"><asp:Label ID="lblCaption" runat="server" /></td>
                                                    </tr>
                                                   
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                            </td>
                                            <td align="center">
                                                <table width="680px">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="Label1" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:LinkButton ID="lnkbtnexport" runat="server" OnClick="lnkbtnexport_Click" Visible="false">Export To Word</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table width="800" border="1" align="center" style="border-color: #cccccc; border-style: solid;">
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Course Name
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Course Code
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Assignment Code
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblAssignmentCode" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Paper
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Name of the Student
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblStudentName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Student Reference ID
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblStid" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Total Time Allotted
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblTimeAlloted" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Time Taken by the Student
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                       <asp:Label ID="lblTimeTaken" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="300" align="left" class="style5">
                                                                        Date of Assignment
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblDate" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table width="600" border="0" align="center">
                                                                <tr>
                                                                    <td colspan="3" align="left" class="style5">
                                                                        <strong>Summary </strong>
                                                                        <br>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <asp:DataList ID="dlstInstructionSummary" runat="server" Width="100%" 
                                                                RepeatColumns="1" >
                                                                <ItemTemplate>
                                                                    <table width="800" border="1" align="center" style="border-color: #cccccc; border-style: solid;
                                                                        border-width: thin">
                                                                        <tr>
                                                                            <td colspan="3" align="center" class="style5">
                                                                                <b>
                                                                                    <%# Eval("CategoryName") %></b>
                                                                            </td>
                                                                        </tr>
                                                                      
                                                                        <tr>
                                                                            <td width="50" align="left" class="style5">
                                                                                a.
                                                                            </td>
                                                                            <td width="250" align="left" class="style5">
                                                                               Maximum No. of Questions
                                                                            </td>
                                                                            <td width="300" align="left" class="style5">
                                                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("AttemptQue") %>'></asp:Label>
                                                                                out of
                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("MaxNoQue") %>'></asp:Label>
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
                                                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("UserAttemptQue") %>'></asp:Label>
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
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                       
                                         <tr align="left" valign="top">
                                         <td>&nbsp;</td>
                                            <td align="left" style="padding-left:40px">
                                                                               &nbsp;</td>
                                        </tr>
                                       
                                         <tr align="left" valign="top">
                                         <td></td>
                                            <td align="left" style="padding-left:40px">
                                                                               <b>Grand Total
                                                                               <asp:Label ID="lblGrand" runat="server" />
                                                                               </b>
                                                                    </td>
                                        </tr>
                                         <tr align="left" valign="top">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                         <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td align="center" style="text-align: left">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr  valign="top">
                                            <td colspan="3" align="center" class="style5">
                                                                        <strong>Answer Sheet </strong>
                                                                        <br>
                                                                    </td>
                                          
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                <asp:DataList ID="dlstanswers" runat="server" Width="100%" 
                                                    OnItemDataBound="dlstanswers_ItemDataBound">
                                                    <ItemTemplate>
                                                        <table width="800" class="style15" align="center">
                                                            <tr>
                                                                <td colspan="3" align="center">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="lblcategoryname" runat="server" Text=' <%#Eval("CategoryName") %>'></asp:Label>
                                                                    </strong>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        Question <asp:Label ID="Label5" runat="server" Text="<%# Container.ItemIndex + 1 %> "></asp:Label>
                                                                        <%--<asp:Label ID="Label5" runat="server" Text="Question  <%# Container.DataItemIndex + 1 %> "></asp:Label--%>

                                                                    </strong>
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
                                                                        <asp:Label ID="Label6" runat="server" Text="Answers  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:HiddenField ID="hdnAnsid" runat="server" Value='<%#Eval("AnsId") %>' />
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
                                                                        <asp:Label ID="Label8" runat="server" Text="Feedback  "></asp:Label></strong>
                                                                        
                                                                </td>
                                                                <td width="75%" align="left" >
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 120px" id="trRow2" runat="server" >
                                                            <td>&nbsp;</td>
                                                            <%--<td  style="border: thin solid #000000"> &nbsp;</td>--%>
                                                                <td>
                                                                <asp:TextBox ID="txtfeedback" runat="server" TextMode="MultiLine" Rows="5" Columns="5"  Text='<%#Eval("Feedback") %>' ToolTip='<%#Eval("questionid") %>' style="border: thin solid rgb(0, 0, 0); margin: 0px 0px 10px; width: 630px; height: 135px;"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                               <tr id="trLineMain" runat="server">
                                                                <td colspan="3" >

                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                          <asp:DataList ID="dlstSubanswers" runat="server" Width="100%" OnItemDataBound="dlstSubanswers_ItemDataBound">
                                                    <ItemTemplate>
                                                        <table width="800" class="style15" align="center">
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
                                                                         Sub Question <asp:Label ID="Label9" runat="server" Text="<%# Container.ItemIndex + 1 %>"></asp:Label>
                                                                        <%--<asp:Label ID="Label9" runat="server" Text="Sub Question  <%# Container.DataItemIndex + 1 %> "></asp:Label>--%>

                                                                    </strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label10" runat="server" Text='<%#Eval("QuestionText") %>'></asp:Label></strong>
                                                                </td>
                                                                <td width="10%" align="left">
                                                                    (
                                                                    <asp:Label ID="Label11" runat="server" Text='<%#Eval("maxquemarks") %>' CssClass="style9_sec"></asp:Label>
                                                                    )
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr>
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label12" runat="server" Text="Answers  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:Label ID="Label13" runat="server" Text='<%#Eval("anstext") %>' CssClass="style9_sec"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr id="tr1" runat="server">
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label14" runat="server" Text="Correct Answer  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:Label ID="Label15" runat="server" Text='<%#Eval("answer") %>' CssClass="style9_sec"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr>
                                                                <td width="15%" align="left">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label16" runat="server" Text="Marks Scored  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left">
                                                                    <asp:Label ID="Label17" runat="server" Text='<%#Eval("questype") %>' Visible="false" />
                                                                    <asp:Label ID="Label18" runat="server" Text='<%#Eval("CategoryId") %>' Visible="false" />
                                                                    <asp:HiddenField ID="hdnsubansid" runat="server" Value='<%#Eval("AnsId") %>' />
                                                                    <asp:HiddenField ID="hdnsubQuestionId" runat="server" Value='<%#Eval("QuestionId") %>' />
                                                                    <asp:Label ID="lblSubMarkscored" runat="server"  />
                                                                    <asp:TextBox ID="txtSubMarkscored" runat="server"  ToolTip="Enter Marks" Text='<%#Eval("MarkGivenByFaculty") %>'  />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="txtSubMarkscored" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSubMarkscored" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 8px">
                                                            </tr>
                                                            <tr id="tr2" runat="server"  >
                                                                <td width="15%" align="left" valign="top">
                                                                    <strong class="style9_sec">
                                                                        <asp:Label ID="Label19" runat="server" Text="Feedback  "></asp:Label></strong>
                                                                </td>
                                                                <td width="75%" align="left" >
                                                                </td>
                                                            </tr>
                                                            <tr style="height: 120px" id="tr3" runat="server" >
                                                            <td>&nbsp;</td>
                                                            <%--<td  style="border: thin solid #000000"> &nbsp;</td>--%>
                                                                <td>
                                                                    <asp:TextBox ID="txtfeedback" runat="server" TextMode="MultiLine" Rows="5" Columns="5" Text='<%#Eval("Feedback") %>' ToolTip='<%#Eval("questionid") %>' style="border: thin solid rgb(0, 0, 0); margin: 0px 0px 10px; width: 630px; height: 135px;"></asp:TextBox>
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
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td align="center" >
                                                <%--<asp:Label ID="hdnuserid" runat="server" />--%>
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" Visible="false"/>
                                                <asp:HiddenField ID="hdnTotalMarks" runat="server" Visible="false"/>
                                                <asp:HiddenField ID="hdnSectionId" runat="server" Visible="false"/>
                                                <asp:Button ID="btnSave" runat="server" Text="Add Comment" OnClick="btnSave_Click" />
                                            </td>
                                            <td>
                                                &nbsp;
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    </fieldset>
                                </div>
                            </td>
                        </tr>
                                                                    </table>
                                                                    </div>
                                                                    </div>                                                            
     
                                            </section>
                                            </div>
                                     
                                </div>
                            
    </form>

</asp:Content>

