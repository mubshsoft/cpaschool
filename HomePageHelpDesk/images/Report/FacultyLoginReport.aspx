<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FacultyLoginReport.aspx.vb" Inherits="Admin_FacultyLoginReport" %>

<%@ Register Src="~/AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Login History</title>

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
               function openPopup(id)
                     {
                    open("../Student/QueryDetails.aspx?lstquerydetails=" + id, "Info", "status=1, width=400, height=500, top=20, left=300");
                      }
      </script>
</head>
<body>
    <form id="form1" runat="server">
    <div onkeypress="javascript:HideMessage()">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
      <ContentTemplate>
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
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" >
                                    <table width="700" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec">Login History</strong></td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                            <strong class="style9"><a href="../Admin/Adminlogin.aspx"><font color="#4b4b4b">Back 
                                                            To Admin Panel</font></a></strong>&nbsp; <a href="../logout.aspx" class="part1"><strong class="style9_sec">
                                                                    <font color="#4b4b4b">Logout</font></strong></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 20px; padding-bottom: 20px;" valign="middle">
                                              <table style="width:50%">
                                              <tr>
                                              <td> <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                                              </tr>
                                              </table>
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                        <td width="3">&nbsp;</td>
                                             <td colspan="3" class="style9" align="center"><b>Faculty Login Details</b></td>
                                          <td width="3">&nbsp;</td>
                                        </tr>
                                        <tr>
                                        <td colspan="3">
                                        <hr />
                                        </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 20px; padding-bottom: 20px;">
                                                 <asp:GridView ID="GrdLoginReport" AutoGenerateColumns="false" runat="server" DataKeyNames="FacultyLogId"
                                                    Width="97%" AllowPaging="false">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                                           <ItemTemplate>
                                                              <asp:HiddenField ID="hd1" Value='<%# Eval("Status") %>' runat="server" />
                                                               <asp:Label ID="lbl" Text='' runat="server" CssClass="left_padding"></asp:Label>
                                                           </ItemTemplate>
                                                          </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="QueryId" ItemStyle-HorizontalAlign="Left" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFacultyLogId" Text='<%# Eval("FacultyLogId") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Faculty Name" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFacultyName" Text='<%# Eval("Name") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                      <asp:TemplateField HeaderText="Login From" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLoginFrom" Text='<%# Eval("LoginFrom") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Login Date" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLoginDate" Text='<%# Eval("LoginDate") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Login Time" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLoginTime" Text='<%# Eval("LoginTime") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Login Out" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblLoginOut" Text='<%# Eval("LoginOut") %>' runat="server"
                                                                    CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CommandArgument='<%# Eval("FacultyLogId") %>'>Delete</asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         
                                                         
                                                    </Columns>
                                                </asp:GridView>
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
      </ContentTemplate>
      </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
