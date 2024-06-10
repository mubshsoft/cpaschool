<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScreeningInstructionAdmin.aspx.cs" Inherits="Admin_ScreeningInstructionAdmin" %>


<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title></title>
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
                           var strOldOne=prtContent.innerHTML;
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
    <div onkeypress="HideMessage()">
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="703" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                        <%--<tr>
                            <td height="127" align="left" valign="top">
                               <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>--%>
                        <tr>
                            <td align="left" valign="top" height="40px">
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="center" valign="top">
                               
                                 <div id="print_grid" class="style5" runat="server" >
                                     <fieldset>
                                            <legend class="style9_sec"><b>Screening Answer Sheet</b></legend>
                                    <table width="700" border="0" cellspacing="0" cellpadding="0">
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
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:LinkButton ID="lnkbtnexport" runat="server" OnClick="lnkbtnexport_Click" Visible="false">Export To Word</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <table width="600" border="1" align="center" style="border-color: #cccccc; border-style: solid;">
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
                                                                        Screening Exam Code
                                                                    </td>
                                                                    <td width="300" align="left" class="style5">
                                                                        <asp:Label ID="lblScreeningCode" runat="server" Text="" Font-Bold="true"></asp:Label>
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
                                                                        Date of Screening
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
                                                                    <table width="600" border="1" align="center" style="border-color: #cccccc; border-style: solid;
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
                                                                                &nbsp;
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
                                                        <table width="600" class="style15" align="center">
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
                                                                        Q. <%#Container.ItemIndex+1 %>
                                                                        <%--<asp:Label ID="Label3" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>--%></strong>
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
                                                            <td  style="border: thin solid #000000"> &nbsp;</td>
                                                            </tr>
                                                               <tr id="trLineMain" runat="server">
                                                                <td colspan="3" >
                                                                    <hr />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                          <asp:DataList ID="dlstSubanswers" runat="server" Width="100%">
                                                    <ItemTemplate>
                                                        <table width="600" class="style15" align="center">
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
                                                            <td  style="border: thin solid #000000"> &nbsp;</td>
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
                                            <td>
                                                <%--<asp:Label ID="hdnuserid" runat="server" />--%>
                                                <asp:HiddenField ID="hdnuserid" runat="server" Visible="false" />
                                                <asp:HiddenField ID="hdnScrId" runat="server" Visible="false"/>
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
                             <tr>
                            <td align="center">
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
                            <td align="center">
                           
                                <uc2:Footer ID="Footer1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
