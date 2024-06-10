<%@ Page Language="VB" AutoEventWireup="false" CodeFile="sendemail.aspx.vb" Inherits="Mob_sendemail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtEmailId" runat="server" placeholder="To"></asp:TextBox><br />
            <asp:TextBox ID="txtSubject" runat="server" placeholder="Subject"></asp:TextBox><br />
            <asp:TextBox ID="txtBody" runat="server" placeholder="Message" Rows="10" TextMode="MultiLine"></asp:TextBox><br />
            <asp:Button ID="btnSendMail" runat="server" Text="Send Mail" />
        </div>
    </form>
</body>
</html>
