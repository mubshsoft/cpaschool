<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignmentInstruction.aspx.cs" Inherits="AssignmentInstruction" %>

<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Use Existing Exam</title>
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
    </script>
  <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-family:Verdana,Arial,Tahoma; font-size:10px; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}
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
                        <tr>
                            <td height="127" align="left" valign="top">
                                <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">
                                                            <asp:Label ID="lblCaption" runat="server" />
                                                            </strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b">Back To 
                                                            Admin Panel</font></a></strong>&nbsp; <strong class="style9_sec"><a href="../logout.aspx" class="part1">
                                                                    <font color="#4b4b4b">Logout</font></a></strong>
                                                        </td>
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
                                                        <td align="center"  >
                                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                    </tr>
                                                 
                                                    <tr>
                                                        <td align="center"  >
                                                            <table width="600" border="1" align="center" style="border-color:#cccccc; border-style:solid;" >
  <tr>
    <td width="300" align="left" class="style5">Course Name</td>
    <td width="300" align="left" class="style5">
        <asp:Label ID="lblCourseName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                         </td>
  </tr>
  <tr>
    <td width="300" align="left" class="style5">Course Code</td>
    <td width="300" align="left" class="style5">
        <asp:Label ID="lblCourseCode" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                         </td>
  </tr>
  <tr>
    <td width="300" align="left" class="style5">Examination</td>
    <td width="300" align="left" class="style5">
        <asp:Label ID="lblAssignmentCode" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                         </td>
  </tr>
  <tr>
    <td width="300" align="left" class="style5">Paper</td>
    <td width="300" align="left" class="style5">
        <asp:Label ID="lblPaperName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                         </td>
  </tr>
  <tr>
    <td width="300" align="left" class="style5">Name of the Student</td>
    <td width="300" align="left" class="style5">
        <asp:Label ID="lblStudentName" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                         </td>
  </tr>
  <tr>
    <td width="300" align="left" class="style5">Student Reference ID</td>
    <td width="300" align="left" class="style5"><asp:Label ID="lblStid" runat="server" Text="" Font-Bold="true"></asp:Label></td>
  </tr>
  <tr>
    <td width="300" align="left" class="style5">Total Time Allotted</td>
    <td width="300" align="left" class="style5"><asp:Label ID="lblTimeAlloted" runat="server" Text="" Font-Bold="true"></asp:Label></td>
  </tr>
  <tr>
    <td width="300" align="left" class="style5">Time Taken by the Student</td>
    <td width="300" align="left" class="style5">&nbsp;</td>
  </tr>
  <tr>
    <td width="300" align="left" class="style5">Date of Examination</td>
    <td width="300" align="left" class="style5">
        <asp:Label ID="lblDate" runat="server" Text="" Font-Bold="true"></asp:Label>
                                                                         </td>
  </tr>
</table><br />
 <table width="600" border="0" align="center">
                                            <tr>
                                              <td colspan="3" align="left" class="style5"><strong>Summary    </strong><br></td>
                                            </tr>
                                            </table>
                                                            <asp:DataList ID="dlstInstructionSummary" runat="server" Width="100%" RepeatColumns="1">
                                                            <ItemTemplate>
                                               <table width="600" border="1" align="center" style="border-color:#cccccc; border-style:solid; border-width:thin" >            
                                            
                                            <tr>
                                              <td colspan="3" align="center" class="style5"><b><%# Eval("CategoryName") %></b></td>
                                            </tr>
                                            <tr id="trFirstRow" runat="server" visible="false" >
                                         <td width="50" align="left" class="style5">a.</td>
                                              <td width="250" align="left" class="style5">Maximum No. of Questions</td>
                                              <td width="300" align="left" class="style5"><asp:Label ID="Label1" runat="server" Text='<%# Eval("MaxNoQue") %>'></asp:Label>
                                                  &nbsp;</td>
                                            </tr>
                                            <tr>
                                       <td width="50" align="left" class="style5" >a.</td>
                                              <td width="250" align="left" class="style5">Compulsory Question</td>
                                              <td width="300" align="left" class="style5"> <asp:Label ID="lblPaperName" runat="server" Text='<%# Eval("AttemptQue") %>'></asp:Label> 
                                                  out of <asp:Label ID="Label2" runat="server" Text='<%# Eval("MaxNoQue") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                            <td width="50" align="left" class="style5">b.</td>
                                              <td width="250" align="left" class="style5">Maximum Marks in Section</td>
                                              <td width="300" align="left" class="style5">&nbsp;
                                             <asp:Label ID="lblmaxquemarks" runat="server" Text='<%# Eval("MaxQueMarks") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                           <td width="50" align="left" class="style5">c.</td>
                                              <td width="250" align="left" class="style5">Marks Scored-</td>
                                              <td width="300" align="left" class="style5">&nbsp;</td>
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
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                
                                             </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" />
                                                <asp:HiddenField ID="hdnSectionId" runat="server" />
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
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
