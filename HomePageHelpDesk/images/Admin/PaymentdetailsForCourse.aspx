<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PaymentdetailsForCourse.aspx.vb" Inherits="Admin_PaymentdetailsForCourse" %>

<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Payment Details</title>
 <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
    </script>

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
        .style14
        {
            height: 23px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
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
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                   <ContentTemplate>
                                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px" class="style14">
                                                            <strong class="style9_sec">List of Payment</strong></td>
                                                        <td width="50%" align="right" style="padding-right: 10px" class="style14">
                                                            <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b"><b>Back To 
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
                                            <td height="100%" class="style5" align="center" style="padding-top: 10px; padding-bottom: 10px;">
                                                <table style="width: 50%">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                        <td></td>
                                        <td colspan="3" align="right" style="padding-right:20px" ><strong class="style9">
                                   <%--<asp:LinkButton ID="AddNew" runat="server" 
                                                                 PostBackUrl="~/Admin/AddBatch.aspx" Visible="true" >
                                                                 <font color="#4b4b4b">Create New batch</font></asp:LinkButton>--%>
                                                                 
                                                                 
                                                                 </strong>&nbsp;&nbsp;&nbsp;<strong class="style9"><a&nbsp;&nbsp;&nbsp;
                                                                 
                                                                 <strong class="style9">
                                                                 
                                                              </strong></td>
                                                                 </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 5px; padding-bottom: 20px;">
                                                <asp:GridView ID="Grdpayment" AutoGenerateColumns="False" DataKeyNames="Id" Width="97%"
                                                    runat="server" AllowPaging="True">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                        
                                                         <asp:TemplateField HeaderText="DD NO" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDDNo" Text='<%# Eval("DDNo") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" Text='<%# Eval("Amount") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="DD date" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDDdate" Text='<%# Eval("DDdate") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                       <asp:TemplateField HeaderText="CourseTitle" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCourseTitle" Text='<%# Eval("CourseTitle") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <%-- <asp:TemplateField HeaderText="SemId" ItemStyle-HorizontalAlign="Left">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSemId" Text='<%# Eval("SemId") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
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
                                     </ContentTemplate>
                                 </asp:UpdatePanel>
                    </div>
                </td>
                </tr>
                <tr>
                    <td align="center">
                        <uc2:Footer ID="Footer1" runat="server" />
                    </td>
                </tr>
                </table> </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>