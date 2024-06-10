<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginXml.aspx.cs" Inherits="LoginXml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
    Username : &nbsp;<asp:textbox ID="txtUsername" runat="server"></asp:textbox><br /><br />
        Password : &nbsp;<asp:textbox ID="txtPassword" runat="server"></asp:textbox><br /><br />
         <asp:Button ID="btnLogin" runat="server" Text="Login" onClick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>
