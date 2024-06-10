<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PaymentReport.aspx.vb" Inherits="Admin_PaymentReport" %>



<%@ Register Src="../AdminHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>List of Batch</title>
 <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
    </script>
   <script language="javascript" type="text/javascript" src="../datetimepicker.js">
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
                      function closepopup()
{    
    window.close();
}
function CallPrint(strid)
  {
   var prtContent = document.getElementById(strid);
   var strOldOne=prtContent.innerHTML;
   var WinPrint = window.open('','','left=0,top=0,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
   WinPrint.document.write(prtContent.innerHTML);
   WinPrint.document.close();
   WinPrint.focus();
   WinPrint.print();
   WinPrint.close();
   prtContent.innerHTML=strOldOne;
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
    <div id='popCal' style='POSITION:absolute;visibility:hidden;border:2px ridge;width:10'>
<iframe name="popFrame" src="../UNTITLED.htm" frameborder="0" scrolling="no" width="152" height="147"></iframe>
</div>
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
                                                            <strong class="style9_sec">Payment  Reports</strong></td>
                                                        <td width="50%" align="right" style="padding-right: 10px" class="style14">
                                                            <strong class="style9"><a href="adminlogin.aspx"><font color="#4b4b4b"><b>Back To Admin
                                                                Panel</b></font></a></strong>&nbsp; <strong class="style9_sec">
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
                                                <table style="width: 80%">
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%" align="right" style="padding-right:10px">
                                                            From :
                                                        </td>
                                                        <td width="35%" align="left">
                                                             <asp:TextBox ID="txtFromDate" runat="server" CssClass="style11"></asp:TextBox>
                                                             <a href="javascript:NewCal('txtFromDate','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" style="vertical-align:bottom"></a>
                                                             &nbsp;<asp:Label ID="lblfromDate" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td>
                                                        <td width="10%" align="right" style="padding-right:10px">
                                                           To :
                                                           </td>
                                                        <td width="35%" align="left">
                                                         <asp:TextBox ID="txtToDate" runat="server" CssClass="style11"></asp:TextBox>
                                                                <a href="javascript:NewCal('txtToDate','mmddyyyy')"> <img src="../images/calender.png" width="22" height="22" border="0" alt="Pick a date" style="vertical-align:bottom"></a>

                                                         &nbsp;<asp:Label ID="lbltoDate" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                        </td> 
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td align="right" style="padding-right:10px">
                                                            Course :
                                                        </td>
                                                        <td width="35%" align="left" >
                                                            <asp:DropDownList ID="ddlCourse" runat="server" AutoPostBack="true" CssClass="DropDownStyle11">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td width="5%"></td>
                                                        <td width="35%"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" align="center" >
                                                <asp:Imagebutton ID="btnback" ImageUrl="../Images/back.png" runat="server" onclick="btnback_Click" 
                                                                />&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <hr />
                                            </td>
                                        </tr>
                                        <tr valign="top">
                                        <td></td>
                                        <td colspan="3" align="right" style="padding-right:20px" >
                                                              <%--<asp:LinkButton ID="lnkManageBatch" runat="server" 
                                                                 PostBackUrl="~/Admin/ManageBatch.aspx" Visible="true" ><font color="#4b4b4b">Assign 
                                            student in batch</font></asp:LinkButton>
                                            --%>
                                            </td>
                                                                 </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 5px; padding-bottom: 20px;">
                                              <div id="print_grid" class="style5">
                                                <asp:GridView ID="GrdPayment" AutoGenerateColumns="False" DataKeyNames="Id" Width="97%"
                                                    runat="server" AllowPaging="True" PageSize="10" OnPageIndexChanging="GrdPayment_PageIndexChanging">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                       
                                                        <asp:TemplateField HeaderText="id" ItemStyle-HorizontalAlign="Left" Visible="false"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblid" Text='<%# Eval("Id") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Full Name" ItemStyle-HorizontalAlign="Left"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblfullname" Text='<%# Eval("fullname") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblemail" Text='<%# Eval("email") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="DDNo" ItemStyle-HorizontalAlign="Left"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDDNo" Text='<%# Eval("DDNo") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Left"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" Text='<%# Eval("Amount") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="DDdate" ItemStyle-HorizontalAlign="Left"  >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDDdate" Text='<%# Eval("DDdate") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                         <asp:TemplateField HeaderText="DateOfPayment" ItemStyle-HorizontalAlign="Left" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDateOfPayment" Text='<%# Eval("DateOfPayment") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                               
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="stid" ItemStyle-HorizontalAlign="Left" Visible="false" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblstid" Text='<%# Eval("stid") %>' runat="server" CssClass="left_padding"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                </div>
                                            </td>
                                            <td width="3">
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td>
                                            </td>
                                            <td align="center" >
                                            &nbsp;&nbsp;
                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/close.png" 
                                                    Visible="False" />
                                                &nbsp;&nbsp;
                                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Print.png" tyle="text-align: left"
                                                    ToolTip="Print"  onclick="ImageButton1_Click" />
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
