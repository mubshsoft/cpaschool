<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FacultyDownloadmaterial.aspx.vb" Inherits="Faculty_FacultyDownloadmaterial" %>

<%@ Register src="../FacultyHeader.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Download Course material</title>
<script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
    </script>

 
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
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager></td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4" >
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">Course Content</strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"> <a href="facultypanel.aspx"><font color="#4b4b4b"><b>Back To 
                                                            Faculty Panel</b></font> </a></strong>&nbsp; <strong class="style9_sec"><a href="../logout.aspx" class="part1">
                                                                    <font color="#4b4b4b"><b>Logout</b></font> </a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td align="center" width="100%">
                                             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                            
                                               <table width="100%" cellpadding="0" cellspacing="0">
                                                 <tr>
                                                   <td colspan="4">&nbsp;</td>
                                                  
                                                 </tr>
                                                 <tr>
                                                   <td width="25%" ></td>
                                                   <td rowspan="2" align="left">
                                                   <table width="100%" cellpadding="0" cellspacing="0">
                                                   <tr><td width="20%"   align="right"  style="padding-right:40px;"  valign="middle" class="style5" >Course: </td>
                                                   <td width="30%"><asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" CssClass="DropDownStyle11">
                        </asp:DropDownList></td>
                                                   </tr>
                                                   <tr><td colspan="2">&nbsp;</td></tr>
                                                   <tr>
                                                    <td width="20%"  align="right"  style="padding-right:40px;"  valign="middle" class="style5" >Semester: </td>
                                                   <td width="30%"><asp:DropDownList ID="dllSem" runat="server" AutoPostBack="true" CssClass="DropDownStyle11">
                        </asp:DropDownList></td></tr>
                                                   </table></td>
                                                   
                                                   
                                                   <td width="25%"></td>
                                                 </tr>
                                                  <tr id="tr1" runat="server" >
                                                   <td width="25%"></td>
                                                  
                                                   <td width="25%"></td>
                                                 </tr>
                                               </table>
                                               </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                             <td width="3"></td> 
                                        </tr> 
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 20px; padding-bottom: 20px;">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                          <ContentTemplate >
                                                   <asp:GridView ID="GrdDownload" AutoGenerateColumns="false" runat="server"
                                                    Width="97%" AllowPaging="True" PageSize="10" OnPageIndexChanging="GrdDownload_PageIndexChanging">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Course Code" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseCode" Text='<%# Eval("CourseCode") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Semester Title" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsemestertitle" Text='<%# Eval("semestertitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Module Title" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmoduletitle" Text='<%# Eval("moduletitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Paper Title" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblPaperTitle" Text='<%# Eval("PaperTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%--<asp:TemplateField HeaderText="Unit Title" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblUnitTitle" Text='<%# Eval("UnitTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Unit Title" ItemStyle-HorizontalAlign="center" >
                                                            <ItemTemplate >
                                                                <a id="a1" href="../facultyDownLoadDetails.aspx?uid=<%#Container.DataItem("UnitId")%>&fid=<%#Container.DataItem("Fid")%>" >
                                                                    <%#Eval("UnitTitle")%> </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                </ContentTemplate>
    </asp:UpdatePanel>
                                            </td>
                                            <td width="3">
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
