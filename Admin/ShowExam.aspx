<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowExam.aspx.cs" Inherits="ShowExam" EnableEventValidation = "false"%>

<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="../stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />
    <title>Exam Set</title>
 <script type="text/javascript" src="../stmenu.js"></script>
    <script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
    </script>

<%--    <script language="javascript" type="text/javascript">
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
--%>
    <style type="text/css">
        .style14
        {
            height: 23px;
        }
    </style>


</head>
<body  >
    <form id="form1" runat="server">
    <div>
        <input type="hidden" id="timeAllocated" name="timeAllocated" runat="server" />
        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td width="703" height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                        <tr>
                            <td  align="left" valign="top">
                                <uc1:Header ID="Header1" runat="server" />
                            </td>
                        </tr>
                       
                        <tr>
                            <td align="center" valign="top">
                                <div class="frame" style="width:701px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    
                                                    <tr>
                                                        <td style="background-color: #ffffff;" align="left" class="style5">
                                                            &nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    
                                                    </table>
                                            </td>
                                        </tr>
                                        <tr align="center" valign="top">
                                            <td colspan="2" class="style5" align="center" style="padding-top: 5px; padding-bottom: 20px;">
                                         
                                                  <asp:GridView ID="GrdUserList" AutoGenerateColumns="False"  Width="97%"
                                                    runat="server" AllowPaging="True" PageSize="15">
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <RowStyle CssClass="grid-row-Overtime" />
                                                    <AlternatingRowStyle CssClass="grid-altrow-Overtime" />
                                                    <HeaderStyle CssClass="grid-header-Overtime" />
                                                    <Columns>
                                                     <asp:TemplateField HeaderText="Exam Set" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                           
                                                            <ItemTemplate>
                                                              <asp:Label ID="lbluserid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Examcode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                             
                                                     
                                                         <asp:TemplateField  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="250px">
                                                              <ItemTemplate>
                                                                <a id="a1" href="ShowExam1.aspx?Examid=<%#Eval ("ExamId")%>">
                                                                   Questions
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>  
                                                                                                
                                                    </Columns>
                                                </asp:GridView>
                                                    
                                            </td>
                                        </tr>
                                               
                                        <tr align="left" valign="top">
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;</td>
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
