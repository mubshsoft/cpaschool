<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddPaper.aspx.vb" Inherits="Admin_AddPaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Paper Info</title>
     <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
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
                     
//                     window.onload = function()
//                            {
//                                window.opener.document.body.disabled=true;
//                            }

//                        window.onunload = function()
//                            {
//                                window.opener.document.body.disabled=false;
//                                
//                            }


   
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div onkeypress="javascript:HideMessage()">
    <table width="300" border="0" cellspacing="0" cellpadding="0">
                                        <tr align="left" valign="middle">
                                            <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="50%" align="left" style="padding-left: 10px">
                                                            <strong class="style9_sec"><asp:Label ID="lblMsgPaper" runat="server" Text=""></asp:Label></strong>
                                                        </td>
                                                        <td width="50%" align="right" style="padding-right: 10px">
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td width="3" align="left">
                                            </td>
                                            <td height="100%" class="style5" align="center" style="padding-top: 2px; padding-bottom: 2px;">
                                                <table width="300px">
                                               
                                                    <tr>
                                                        <td width="150px" colspan="2" style="width: 300px;" align="center">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                         </td>
                                                    </tr>
                                                    <tr>
                                                      <td width="150px" align="right" style="padding-right:10px" class="style5" >
                                                           Enter Paper Title :
                                                        </td>
                                                        <td width="150px" align="left" class="style5" >
                                                            <asp:TextBox ID="txtPaperTitle" runat="server" CssClass="style11"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                   <%-- <tr>
                                                        <td colspan="2">
                                                            <asp:LinkButton ID="lnkDuration" runat="server" Text="Click here to enter duration of semester" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Panel ID="Panel1" runat="server">
                                                                <asp:Table CssClass="sub-heading" ID="MyTable" Width="100%" Height="50%" runat="server">
                                                                </asp:Table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>--%>
                                                     <tr>
                                                        <td width="150px" align="right" style="padding-right:20px">
                                                            &nbsp;</td>
                                                        <td width="150px" align="left">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="150px" colspan="2" style="width: 300px">
                                                            <asp:Imagebutton ID="btnSave" ImageUrl="../Images/save.png" runat="server"/>&nbsp;&nbsp;&nbsp;
                                                           <asp:Imagebutton ID="btnClose" ImageUrl="../Images/close.png" runat="server" 
                                                                />
                                                           
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
    </form>
</body>
</html>
