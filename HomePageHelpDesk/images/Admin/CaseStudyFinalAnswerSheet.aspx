<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CaseStudyFinalAnswerSheet.aspx.cs" Inherits="Admin_CaseStudyFinalAnswerSheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            font-family: Verdana,Arial,Tahoma;
            font-size: 10px;
            font-weight: bold;
        }
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        .style14
        {
            height: 8px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
                            <td align="center" valign="top">
                               <div id="print_grid" class="style5" runat="server" >
                                     <fieldset>
                                            <legend class="style9_sec"><b>Case Study Answer Sheet</b></legend>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                <table width="780px">
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
                                                                        Case Study Code
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
                                                                <tr id="trtimeAllotted" runat="server" >
                                                                    <td width="300" align="left" class="style5">
                                                                        Total Time Allotted
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblTimeAlloted" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trtimeTaken" runat="server" >
                                                                    <td width="300" align="left" class="style5">
                                                                        Time Taken by the Student
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                       <asp:Label ID="lblTimeTaken" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trDateofassignment" runat="server" > 
                                                                    <td width="300" align="left" class="style5">
                                                                        Date of Assignment
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblDate" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="tr1" runat="server" > 
                                                                    <td width="300" align="left" class="style5">
                                                                        Paper Checked By
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblFaculty" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table width="600" border="0" align="center">
                                                                <tr id="trSummary" runat="server">
                                                                    <td colspan="3" align="left" class="style5">
                                                                        <strong>Summary </strong>
                                                                        <br>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                       
                                        <tr align="left" valign="top" id="trManualMarks" runat="server" visible="false"  >
                                         <td colspan="2">
                                             <table width="100%" >
                                                 <tr align="left" valign="top">
                                         <td width="20%" style="padding-left:10px"> Enter Marks:&nbsp; </td>
                                         <td align="left" width="80%">
                                           <asp:TextBox runat="server" ID="txtManualAssignmentMarks"  ></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" ErrorMessage="*Required" ControlToValidate="txtManualAssignmentMarks" ForeColor="Red"></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtManualAssignmentMarks" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                                         </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                         <td colspan="2">&nbsp;</td>
                                           
                                        </tr>
                                        <tr align="left" >
                                         <td style="padding-left:10px">Enter Feedback :&nbsp;</td>
                                         <td align="left">
                                             <asp:TextBox runat="server" ID="txtManualFeedback" TextMode="MultiLine" Rows="5" Columns="5" style="border: thin solid rgb(0, 0, 0); margin: 0px 0px 10px; width: 430px; height: 80px;"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Required" ControlToValidate="txtManualFeedback" ForeColor="Red"></asp:RequiredFieldValidator>
                                         </td>
                                        </tr>
                                       
                                         <tr align="left" valign="top">
                                         <td>&nbsp;</td>
                                            <td align="left">
                                            <asp:Button runat="server" ID="btnAddMarks" Text="Add Marks" OnClick="btnAddMarks_Click" />
                                            </td>
                                        </tr>
                                             </table>
                                         </td>
                                           
                                        </tr>

                                        
                                         <tr align="left" valign="top">
                                         <td>&nbsp;</td>
                                            <td align="left" style="padding-left:40px">
                                                                               &nbsp;</td>
                                        </tr>
                                       
                                         <tr align="left" valign="top" id="trGrandTotal" runat="server" >
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
                                        <tr  valign="top" id="trAnswerSheet" runat="server" >
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
    </form>
</body>
</html>

