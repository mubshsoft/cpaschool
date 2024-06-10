<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="CaseStudyInstruction.aspx.cs" Inherits="Faculty_CaseStudyInstruction" %>

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
   
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div class="frame">
        <section class="title">
        <div class="container">
        <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                   <%-- <h2 style="color:#fff">Case Study : List of Batch</h2>--%>
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
                             <asp:ImageButton ID="ImageButton1" runat="server"   
                                                ImageUrl="~/Images/Print.png" tyle="text-align: left" ToolTip="Print" 
                                                 />&nbsp;&nbsp;
                                                 <asp:ImageButton ID="ImgBack" runat="server"   
                                                ImageUrl="~/Images/back.png" tyle="text-align: left" 
                                    ToolTip="Back" onclick="ImgBack_Click" 
                                                 />
                                                 </td>
                             </tr>
                        <tr>
                            <td align="center" valign="top">
                               <div id="print_grid" class="style5" runat="server" >
                                     <fieldset>
                                            <legend class="style9_sec"><b>Case Study Answer Sheet</b></legend>
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
                                                                        Case Study Code
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblCode" runat="server" Text="" Font-Bold="true"></asp:Label>
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
                                                                        Date of Case Study
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblDate" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table width="800" border="0" align="center">
                                                                <tr>
                                                                    <td colspan="3" align="left" class="style5">
                                                                        <fieldset>
    <legend>Case Study - Question</legend>
            <div class="user-info media box" style="background-color:#fff;">
                <asp:Label ID="lblcaseStudy" runat="server" ></asp:Label>
          </div>
        </fieldset>
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
                                       
                                         <tr align="left" valign="top">
                                         <td>&nbsp;</td>
                                            <td align="left" style="padding-left:40px">
                                                                               &nbsp;</td>
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
                                        
                                        <tr>
                                            <td colspan="3">
                                                 <table width="800" border="0" align="center">
                                                                <tr>
                                                                    <td colspan="3" align="left" class="style5">
                                                                        <fieldset>
    <legend>Case Study - Answer</legend>
            <div class="user-info media box" style="background-color:#fff;">
                  <asp:Label ID="lblAnswers" runat="server" ></asp:Label>
          </div>
        </fieldset>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                              
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="3">
                                                 <table width="800" border="0" align="center">
                                                                <tr>
                                                                    <td colspan="3" align="left" class="style5">
                                                                        <fieldset>
    <legend>Remarks & Marks</legend>
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
               <tr align="left" valign="top">
                                         <td>&nbsp;</td>
                                            <td align="left">
                                                <asp:Label ID="lblMSG" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                </td>
                                        </tr>
                                             </table>
        </fieldset>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                              
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                <%--<asp:Label ID="hdnuserid" runat="server" />--%>
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" Visible="false"/>
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
                                                                    </div>                                                            
     
                                            </section>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            
    </form>

</asp:Content>


