<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddUnit.aspx.vb" Inherits="Admin_AddUnit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Unit Info</title>
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
    <div  onkeypress="javascript:HideMessage()">
        <table width="350" border="0" cellspacing="0" cellpadding="0">
            <tr align="left" valign="middle">
                <td height="25" colspan="3" align="center" bgcolor="#E4E4E4">
                    <table width="100%">
                        <tr>
                            <td width="50%" align="left" style="padding-left: 10px; width: 100%;">
                                <strong class="style9_sec">
                                <asp:Label ID="lblUnitMsg"   runat="server" Text="">
                                </asp:Label>
                                </strong>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="left" valign="top">
                <td width="3" align="left">
                </td>
                <td height="100%" class="style5" align="center" style="padding-top: 2px; padding-bottom: 2px;">
                    <table style="width: 336px">
                        <tr>
                            <td colspan="2" align="center" class="style5" >
                                <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="150px" align="right" style="padding-right: 10px" class="style5" >
                                Name Of Unit :
                            </td>
                            <td width="150px" align="left" class="style5" >
                                <asp:TextBox ID="txtUnitName" runat="server" CssClass="style11"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td width="150px" align="right" style="padding-right: 10px" class="style5" >
                                Upload File :
                            </td>
                            <td width="150px" align="left" class="style5" >
                                <asp:FileUpload ID="FileUpload1" runat="server"  CssClass="style13" />
                            </td>
                        </tr>
                      <tr>
                            <td width="150px" align="right" style="padding-right: 20px">
                                &nbsp;
                            </td>
                            <td width="150px" align="left">
                             <asp:Label ID="lblpath" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td width="150px" colspan="2" style="width: 300px">
                                <asp:ImageButton ID="btnSave" ImageUrl="../Images/save.png" runat="server" />&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="btnClose" ImageUrl="../Images/close.png" runat="server"/>
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
