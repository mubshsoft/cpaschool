<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExamSet.aspx.cs" Inherits="ExamSet" %>


<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Add Batch</title>
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
                                                            <strong class="style9_sec">Manage Exam Set</strong></td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b">Back To 
                                                            Admin Panel</font></a></strong>&nbsp; <strong class="style9_sec">
                                                                    <a href="../logout.aspx" class="part1"><font color="#4b4b4b">Logout</font></a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 10px; padding-bottom: 20px;">
                                                <table width="680px">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                            
                                                        </td>
                                                    </tr>
                                                    
                                                    
                                                 
                                                    <tr>
                                                        <td align="center"  >
                                                <asp:GridView ID="grdExamSet" runat="server" AutoGenerateColumns="False" Width="100%"
                                                    DataKeyNames="ExamID" onrowdatabound="grdExamSet_RowDataBound" >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                       
                                                       <asp:TemplateField HeaderText="Exam Code">
                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblexamcodeNo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ExamCode")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                       <asp:TemplateField HeaderText="Course">
                                                        <ItemStyle HorizontalAlign="center" Width="110px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblcourse" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="Semester">
                                                        <ItemStyle HorizontalAlign="center" Width="70px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblsem" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField >
                                                       
                                                        <asp:TemplateField HeaderText="Module">
                                                        <ItemStyle HorizontalAlign="center" Width="60px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblmodule" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                        <asp:TemplateField HeaderText="Paper" >
                                                        <ItemStyle HorizontalAlign="center" Width="110px" />
                                                       <ItemTemplate>
                                                        <asp:Label ID="lblpaper" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                      
                                                       </ItemTemplate>
                                                       </asp:TemplateField>
                                                         <asp:TemplateField>
                        <ItemStyle HorizontalAlign="center" Width="50px" />
                        <ItemTemplate>
                          <asp:HiddenField ID="hdnExamID" runat="server" Value='<%#DataBinder.Eval(Container.DataItem, "ExamId")%>' />
                          
                          <asp:LinkButton ID="lnkDetailsExam" runat="server" Font-Underline="false" 
                                Text="Details"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
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

