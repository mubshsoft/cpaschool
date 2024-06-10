<%@ Page Language="VB" AutoEventWireup="false" CodeFile="DownloadHome.aspx.vb" Inherits="DownloadHome" %>

<%@ Register Src="MainHeader.ascx" TagName="MainHeader" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title></title>

    <script type="text/javascript" src="stmenu.js"></script>

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
                            <td align="center">
                                <uc1:MainHeader ID="MainHeader1" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" align="left" style="padding-left:3px">
                                            <table width="701" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                                                <tr>
                                                  <td colspan="3">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                  <td colspan="3" align="right">
                                                            <asp:Imagebutton ID="btnback" ImageUrl="~/Images/Back.png" runat="server" /></td>
                                                </tr>
                                                <tr align="left">
                                                    <td width="3" valign="bottom" bgcolor="#e4e4e4">
                                                        &nbsp;
                                                    </td>
                                                    <td bgcolor="#E4E4E4" class="style7" align="center" style="padding-top: 2px; padding-bottom: 2px">
                                                        <a><strong><span style="font-size: 14px">
                                                            <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label></span></strong></a>
                                                    </td>
                                                    <td width="3" valign="bottom" bgcolor="#e4e4e4">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                         
                                                  <tr align="left" valign="top">
                                                    <td width="3" align="left" style="border-left: solid 1px #cccccc;">
                                                        &nbsp;
                                                    </td>
                                                    <td height="100%" class="style5">
                                                        <div style="padding-left: 12px; padding-top: 12px; padding-right: 10px; padding-bottom: 2px;
                                                            line-height: 15px; text-align: justify;">
                                                           <asp:GridView ID="GrdHome" AutoGenerateColumns="False" DataKeyNames="courseID" Width="100%"
                                                    runat="server" AllowPaging="True" PageSize="10"  >
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                            <EmptyDataTemplate>
                                                     <table width="100%">
                                                    <tr>
                                                       
                                                        <td width="100%" align="center"style="padding-right: 10px">
                                                           <font color="#4b4b4b"><strong>  No records </strong>
                                                           </font>
                                                        </td>
                                                    </tr>
                                                </table>
                                                    </EmptyDataTemplate>
                                                    
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="courseID" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcourseID" Text='<%# Eval("courseID") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Course Code" Visible="false"  ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="coursecode" Text='<%# Eval("coursecode") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                       </asp:TemplateField>
                                                       
                                                        
                                                      <asp:TemplateField HeaderText="Course Name" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         
                                                         <asp:TemplateField HeaderText="FAQ" ItemStyle-HorizontalAlign="center" >
                                                            <ItemTemplate >
                                                                <a id="a1" href="DownloadPDF.aspx?fnm=<%#Container.DataItem("HelpDeskFilepath")%>&HelpDesk=1" >
                                                                    <%#Replace(Eval("HelpDeskFilepath"),".pdf","")%> </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Brochure" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
<%--                                                                <asp:Label ID="lblHelpDeskFilepath" Text='<%# Eval("BroucherFilepath") %>' runat="server" CssClass="left_padding"></asp:Label>
--%>                                                                <a id="a2" href="DownloadPDF.aspx?fnm=<%#Container.DataItem("BroucherFilepath")%>&HelpDesk=2" >
                                                                    <%#Replace(Eval("BroucherFilepath"),".pdf","")%> </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Calendar" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                               <%-- <asp:Label ID="lblCalendarFilepath" Text='<%# Eval("CalendarFilepath") %>' runat="server" CssClass="left_padding"></asp:Label>--%>
                                                               <a id="a3" href="DownloadPDF.aspx?fnm=<%#Container.DataItem("CalendarFilepath")%>&HelpDesk=3" >
                                                                    <%#Replace(Eval("CalendarFilepath"),".pdf","")%> </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       
                                                       
                                                     
                                                    </Columns>
                                                </asp:GridView>
                                                            </div>
                                                    </td>
                                                    <td width="3" align="left" style="border-right: solid 1px #cccccc;">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr><td  style="border-left: solid 1px #cccccc; border-right: solid 1px #cccccc;
                                                        border-bottom: solid 5px #e4e4e4; width: 6px;" colspan="3">&nbsp;</td></tr>
                                                
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" valign="top" style="border-left: 0px solid #ffffff;
                                border-right: 0px solid #ffffff; background-position: top; background-repeat: repeat-x"
                                colspan="3">
                                <div style="padding-left: 0px; padding-top: 8px">
                                    <uc2:Footer ID="Footer1" runat="server" /></div>
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
