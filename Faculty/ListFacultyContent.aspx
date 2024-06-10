<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ListFacultyContent.aspx.vb" Inherits="Faculty_ListFacultyContent" %>

<%@ Register src="../FacultyHeader.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List Content</title>
<script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
            var statusmsg=""
                function hidestatus()
                    {
                        window.status=statusmsg
                        return true
                     }

    </script>
    
   

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="703" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                        <tr>
                            <td height="127" align="centre" valign="top">
                                <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" valign="top">
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">Course Material</strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                           <strong class="style9">  <a href="facultypanel.aspx"><font color="#4b4b4b">Back To 
                                                            Faculty Panel</font> </a></strong>&nbsp; <strong class="style9_sec"><a href="../logout.aspx" class="part1">
                                                                    <font color="#4b4b4b">Logout</font> </a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                                                                        </td>
                                            <td height="100%" class="style5" align="left" style="padding-top: 10px; padding-bottom: 20px; height:20px">
                                                <%
                                                try
                                                    If dssem IsNot Nothing Then
                                                        If dssem.Tables IsNot Nothing Then
                                                            If dsSem.Tables(0).Rows IsNot Nothing Then
                                                                If dssem.Tables(0).Rows.Count > 0 Then
                                                %>
                                                <div  class="gd , style9_sec" style="padding-left:15px; height:20px; ">
                                                     <b> Course Title</b>
                                                 </div>
                                                   
                                                 <table style="width:100%;" cellpadding="0" cellspacing="0">
                                                    <%Dim i As Integer%>
                                                    <%i = 0%>
                                                    <% While i < dssem.Tables(0).Rows.Count%>
                                                    <tr>
                                                        <td width="700px" align="left" style="height:20px" >
                                                      
                                                          <div  class="style9_sec"  style="padding-left:35px; height:20px; padding-top:5px">
                                                                <%strSemesterTitle = dssem.Tables(0).Rows(i)("SemesterTitle").ToString%>
                                                                <b><%=strSemesterTitle%></b>
                                                            </div>
                                                                
                                                              <%
                                                                  Dim strModuleQ As String = "select * from module where semid=" & CInt(dssem.Tables(0).Rows(i)("SemId").ToString)
                                                                dsmodule = CLS.fnQuerySelectDs(strModuleQ)
                                                                Dim iModule As Integer
                                                                iModule = 0
                                                                If dsmodule IsNot Nothing Then
                                                                    If dsmodule.Tables IsNot Nothing Then
                                                                        If dsmodule.Tables(0).Rows IsNot Nothing Then
                                                                            If dsmodule.Tables(0).Rows.Count > 0 Then
                                                            %>
                                                            
                                                              <table style="width:100%; padding-top:5px" cellpadding="0" cellspacing="0">
                                                                <% While imodule < dsmodule.Tables(0).Rows.Count%>
                                                                <tr>
                                                                    <td width="700px" align="left" style="height:20px;">
                                                                     <div class="gd , style9_sec" style="width:648px;padding-left:50px; height:20px; border-right:1px solid #4b4b4b; border-top:1px solid #4b4b4b; border-left:1px solid #4b4b4b; padding-top:5px ">
                                                                        <%strmoduleTitle = dsmodule.Tables(0).Rows(iModule)("ModuleTitle").ToString%>
                                                                      <b>  <%=strmoduleTitle%></b>
                                                                        </div>
                                                                        
                                                                        
                                                                                <%
                                                                                    Dim strPaperQ As String = "select * from paper where moduleid=" & CInt(dsmodule.Tables(0).Rows(imodule)("ModuleId").ToString)
                                                                                    dspaper = CLS.fnQuerySelectDs(strPaperQ)
                                                                                    Dim iPaper As Integer
                                                                                    iPaper = 0
                                                                                    If dspaper IsNot Nothing Then
                                                                                        If dspaper.Tables IsNot Nothing Then
                                                                                            If dspaper.Tables(0).Rows IsNot Nothing Then
                                                                                                If dspaper.Tables(0).Rows.Count > 0 Then
                                                                                %>
                                                                                
                                                                                  <table style="width:100%; padding-top:5px" cellpadding="0" cellspacing="0">
                                                                                    <% While iPaper < dspaper.Tables(0).Rows.Count%>
                                                                                        <tr>
                                                                                            <td width="700px" align="left" style="height:20px;">
                                                                                                <div class="gd , style9_sec" style="width:648px;padding-left:50px; height:20px; border-right:1px solid #4b4b4b; border-top:1px solid #4b4b4b; border-left:1px solid #4b4b4b; padding-top:5px ">
                                                                                                    <%strpaperTitle = dspaper.Tables(0).Rows(iPaper)("Papertitle").ToString%>
                                                                                                    <b>  <%=strpaperTitle%></b>
                                                                                                </div>
                                                                                
                                                                        
                                                                        <%
                                                                            Session("strdownloadPath") = Server.MapPath("..") & "\upload\" & strCourse & "\" & strSemesterTitle & "\" & strmoduleTitle & "\" & strpaperTitle
                                                                            'Dim strUnit As String = "select * from unit where paperid=" & CInt(dspaper.Tables(0).Rows(i)("paperId").ToString)
                                                                            'dsunit = CLS.fnQuerySelectDs(strUnit)
                                                                            'Dim iUnit As Integer
                                                                            'iPaper = 0
                                                                            'If dsunit IsNot Nothing Then
                                                                            '    If dsunit.Tables IsNot Nothing Then
                                                                            '        If dsunit.Tables(0).Rows IsNot Nothing Then
                                                                            '            If dsunit.Tables(0).Rows.Count > 0 Then
                                                                          %>
                                                                           <div>
                                                                                  <table style="width:100%" cellpadding="0" cellspacing="0">
                                                                <%try %>
                                                                 <%
                                                                  
                                                                   dim fiarr() As System.IO.FileInfo
                                                                    Dim strPath As String                                                                                         
                                                                     strPath = Session("strdownloadPath")
                                                                    dim   di as New System.IO.DirectoryInfo(strPath)
                                                                    fiArr  = di.GetFiles()
                                                                    For Each fi In fiArr %>
                                                                       <tr>
                                                                       <td width="500px" align="left" style="padding-left:65px;border: 1px solid #4b4b4b; height:20px; padding-top:5px; padding-bottom:5px">
                                                                          <%Dim strFilename As String%>
                                                                                  <%strFilename=fi.Name %>
                                                                                  <%Dim strArr() As String = strFilename.Split(".")%>
                                                                                  <%=strArr(0)%>
                                                                              
                                                                             </td>
                                                               
                                                                            <td width="200px" align="left" style=" border-bottom: 1px solid #4b4b4b; border-right:1px solid #4b4b4b; border-top:1px solid #4b4b4b;padding-left:5px">
                                                                              <a href="../DownloadDetail.aspx?fnm=<%=fi.Name %>&dt=lc&dpath=<%=di.FullName%>" onMouseover="return hidestatus()" onclick="return hidestatus()">
                                                                                   Download </a>
                                                                           </td>
                                                                       </tr>
                                                                       <tr style="height:1px"></tr>
                                                                   <%next%>
                                                                   
                                                                   <%catch ex as exception %>
                                                                   <%end try %>
                                                                </table>
                                                                            </div>
                                                                        <% 'End If%>
                                                                        <% 'End If%>
                                                                        <% 'End If%>
                                                                        <% 'End If%>
                                                                    </td>
                                                                                          </tr>
                                                                                      <%iPaper = iPaper + 1%>
                                                                                     <%End While%>
                                                                                    </table>
                                                                            <%
                                                                                End If
                                                                                End If
                                                                                End If
                                                                                End If
                                                                              %>
                                                                              </td>
                                                                             </tr>
                                                                    <%iModule = iModule + 1%>
                                                    <%End While%>
                                                </table>
                                                              <%
                                                                                End If
                                                                                End If
                                                                                End If
                                                                                End If
                                                                %>                  
                                                        </td>
                                                    </tr>
                                                    <%i = i + 1%>
                                                    <%End While%>
                                                </table>
                                                <%     
                                                End If
                                            End If
                                        End If
                                    End If
                                      catch ex as exception 
                                                                   end try %>
                                             
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                &nbsp;
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
