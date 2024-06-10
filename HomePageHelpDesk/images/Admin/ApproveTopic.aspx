<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ApproveTopic.aspx.vb" Inherits="Admin_ApproveTopic" %>

<%@ Register Src="~/AdminHeader.ascx"TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Approve topics</title>
 <script type="text/javascript" src="../stmenu.js"></script>
 
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
                                                            <strong class="style9_sec">Approve replies</strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                           <strong class="style9"><a href="Adminlogin.aspx"> <font color="#4b4b4b"><b>Back To 
                                                            Admin Panel</b></font></a></strong>&nbsp; <strong class="style9_sec">
                                                                    <a href="../logout.aspx" class="part1"><font color="#4b4b4b"><b>Logout</b></font></a></strong>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                                                         
                                        
                                      
                                        
                                     
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 20px; padding-bottom: 20px;">
                                                 <table width="100%">
                                     <tr>
                                        <td style="text-align: left">
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                           <b><asp:Label ID="lblNoTopic" runat="server" Text="NO TOPIC FOUND."></asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="grdTopic" runat="server" AutoGenerateColumns="False" PageSize="12"
                                                AllowPaging="true" CellPadding="1" Width="100%" OnPageIndexChanging="grdTopic_PageIndexChanging">
                                                 <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                
                                                <Columns>
                                                      
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" HeaderText="Reply">
                                                         <ItemTemplate>
                                                               <a id="anc1"> 
                                                                       <%#Replace(Replace(Replace(Replace(DataBinder.Eval(Container.DataItem, "subjectText"), "dq$", """"), "com$", ","), "q$", "'"), "amp$", "&")%>
                                                                       </a>
                                                       </ItemTemplate>
                                                    </asp:TemplateField>
                                                          <asp:TemplateField ItemStyle-Width="20%" HeaderText="Date of posting" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                             <asp:Label ID="lblDateOfPosting" runat="server" Text='<%# Bind("dateofposting") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                                                             
                                                    <asp:TemplateField HeaderText="subject id" Visible="False">
                                                         <ItemTemplate>
                                                            <asp:Label ID="lblSubjectID" runat="server" Text='<%# Bind("subjectid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="subsubjectid" Visible="False">
                                                          <ItemTemplate>
                                                            <asp:Label ID="lblSubSubjectID" runat="server" Text='<%# Bind("subsubjectid") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="User Name" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="Left">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("email") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderStyle-Width="5%">
                                                          <ItemTemplate>
                                                          <asp:HiddenField ID="hdnApStatus" runat="server" Value='<%# Bind("Approve") %>' />
                                                            <asp:CheckBox ID="deleteRec" runat="server" />
                                                          </ItemTemplate>
                                                          <HeaderStyle HorizontalAlign="Left" />
                                                      </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    
                                       <tr>
                                        <td align="center">
                                            <asp:ImageButton ID="btnSave" ImageUrl="~/Images/save.png"  runat="server"  OnClick="btnSave_Click"/>
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
