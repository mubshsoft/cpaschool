<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisXml.aspx.cs" Inherits="RegisXml" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    First Name : &nbsp;<asp:textbox ID="txtFname" runat="server"></asp:textbox><br /><br />
    Last Name : &nbsp;<asp:textbox ID="txtLname" runat="server"></asp:textbox><br /><br />
    Username : &nbsp;<asp:textbox ID="txtUsername" runat="server"></asp:textbox><br /><br />
    Password : &nbsp; <asp:textbox ID="txtPassword" runat="server"></asp:textbox><br /><br />
    Address : &nbsp;<asp:textbox ID="txtAddress" runat="server"></asp:textbox><br /><br />
    Mobile : &nbsp;<asp:textbox ID="txtMob" runat="server"></asp:textbox><br /><br />
    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </div>
        
    </form>
</body>

</html>
