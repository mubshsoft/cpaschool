<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SupplementaryExamList.aspx.vb" Inherits="Admin_SupplementaryExamList" %>

<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add ExamSet</title>

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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
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
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width: 701px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">List Supplementary Exam</strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b">Back To 
                                                            Admin Panel</font></a></strong>&nbsp; <strong class="style9_sec"><a href="../logout.aspx"
                                                                    class="part1"><font color="#4b4b4b">Logout</font></a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 10px; padding-bottom: 20px;">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <table width="680px">
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;
                                                                    <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left">
                                                                    <fieldset>
                                                                        <legend><strong class="style9_sec">Supplementary Exam</strong></legend>
                                                                        <table width="100%">
                                                                         <tr>
                                                                <td  align="right" style="padding-right:10PX; " valign="middle"  class="style5">
                                                                    Batch Code :
                                                                </td>
                                                                <td width="300px" align="left" class="style9_sec">
                                                                    <asp:DropDownList ID="ddlbatch" runat="server" CssClass="DropDownStyle11">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="padding-right: 10PX;" class="style5">
                                                                                    &nbsp;Course Code :
                                                                                </td>
                                                                               
                                                                                <td align="left" >
                                                                                    <asp:DropDownList ID="ddlCourse" AutoPostBack="true" runat="server" CssClass="DropDownStyle11"
                                                                                        />
                                                                                    <asp:Label ID="lblreqcourse" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="padding-right: 10PX;" class="style5">
                                                                                    Semester :
                                                                                </td>
                                                                                
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlSem" AutoPostBack="true" runat="server" CssClass="DropDownStyle11"
                                                                                      />
                                                                                    <asp:Label ID="lblreqsem" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="padding-right: 10PX;" class="style5">
                                                                                    Module :
                                                                                </td>
                                                                                
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlModule" AutoPostBack="true" runat="server" CssClass="DropDownStyle11"
                                                                                         />
                                                                                    <asp:Label ID="lblreqmodule" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" style="padding-right: 10PX;" class="style5">
                                                                                    Paper :
                                                                                </td>
                                                                                
                                                                                <td align="left">
                                                                                    <asp:DropDownList ID="ddlPaper" runat="server" CssClass="DropDownStyle11" />
                                                                                    <asp:Label ID="lblreqpaper" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:HiddenField ID="hdncoursecode" runat="server" />
                                                                                </td>
                                                                                
                                                                                <td align="left">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" style="padding-left: 30px">
                                                                                    &nbsp;</td>
                                                                                
                                                                                <td align="left">
                                                                                    <asp:ImageButton ID="Imagebutton1" ImageUrl="../Images/save.png" runat="server"  />
                                                                                    &nbsp;&nbsp;&nbsp;
                                                                                    <asp:ImageButton ID="Imagebutton2" ImageUrl="../Images/cancel.png" runat="server"
                                                                                        PostBackUrl="~/Admin/Adminlogin.aspx" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" colspan="2">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </fieldset>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
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
