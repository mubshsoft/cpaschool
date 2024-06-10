<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponseHandler.aspx.cs" Inherits="Student_ResponseHandler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
    <div>
     <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height: 100%">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td height="100%" align="left" valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="height: 100%">
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="80%" class="style5" align="center" style="padding-top: 2px; padding-bottom: 2px;border:solid 1px #cccccc; ">
                                <asp:LinkButton ID="lnkhome" runat="server" onclick="lnkhome_Click">Go to Main List</asp:LinkButton>
                                <asp:HiddenField ID="hdnWebUrl" runat="server" />
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
