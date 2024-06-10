<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FacultyPaperAssign.aspx.cs" Inherits="Admin_FacultyPaperAssign" %>
<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

   
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>Faculty Report</title>
    <script type="text/javascript" src="../stmenu.js"></script>
  <%-- <script language="javascript" type="text/javascript">
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
    </script>--%>
  <style type="text/css">


.grid-header-Overtime	{background:url(../images/custImg/pymnt-grid-header.jpg) repeat-x; height:22px; color:#000000; font-family:Verdana,Arial,Tahoma; font-size:10px; font-weight:bold;}

.grid-row-Overtime		{background-color:#ffffff; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}

.grid-altrow-Overtime	{background-color:#eeeeee; color:#282828; font-size:10px; height:15px; font-family:Verdana,Arial,Tahoma;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    
  
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
                            <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                           
                                                        <ContentTemplate>--%>
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
                                            <td align="left" width="3">
                                            </td>
                                            <td align="center" class="style5" height="100%" 
                                                style="padding-top: 0px; padding-bottom: 20px;">
                                                <table width="420px">
                                                    <tr>
                                                        <td align="right" width="200px">
                                                            &nbsp;</td>
                                                        <td align="left" class="style5" width="220px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="style5" style="padding-right:10PX" width="250px">
                                                            Faculty Name :</td>
                                                        <td align="left" class="style9_sec" width="300px">
                                                          <asp:Label ID="lblFacultyName" align="left" runat="server" Visible="true" ></asp:Label>
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
                                            <td align="center">
                                                <asp:GridView ID="grdFacultyDetails" runat="server" AutoGenerateColumns="False" 
                                                    Width="100%">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Course Title"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "CourseTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField HeaderText="Semester Title"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSemesterTitle" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "SemesterTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Module Title"><%-- <ItemStyle  Width="50px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblModuleTitle" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "ModuleTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        
                                                        <asp:TemplateField HeaderText="Paper Title"><%--<ItemStyle Width="110px" />--%>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaperTitle" runat="server" 
                                                                    Text='<%#DataBinder.Eval(Container.DataItem, "PaperTitle")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                        
                                                    
                                                        
                                                      
                                                        
                                                        
                                                    </Columns>
                                                    <%--   <HeaderStyle HorizontalAlign="Left" />
                                                       <ItemStyle HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                        <tr align="center" valign="top">
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnExportToExcel" runat="server" Text="Export To Excel" 
                                                    onclick="btnExportToExcel_Click" /> 
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnExportToWord" runat="server" Text="ExportToWord" 
                                                    onclick="btnExportToWord_Click" />
                                                &nbsp;</td>
                                            <td>
                                            
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                     <%-- </ContentTemplate>
                                                            </asp:UpdatePanel>--%>
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
