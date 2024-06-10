<%@ Page Title="Create Upcoming Events" Language="C#" AutoEventWireup="true" CodeFile="CreateEvents.aspx.cs" Inherits="Mob_CreateEvents" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../css/bootstrap.min.css"/>
    <link rel="stylesheet" href="../css/bootstrap-responsive.min.css"/>
    <link rel="stylesheet" href="../css/font-awesome.min.css"/>
    <link rel="stylesheet" href="../css/sl-slide.css"/>
    <link rel="stylesheet" href="../css/main.css"/>
</head>
<body>
    <form id="form1" runat="server">
       <section class="title">
        <div class="container" style="margin-top:0">
            <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff"><i class="icon-calendar"></i> Create Upcoming Events</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li class="active"><a href="javascript:history.back()"><font color="#fff">Back</font></a> | </li>
                        <li class="active"><a href="../logout.aspx"><font color="#fff">Logout</font></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </section>
     <section class="container main">
        <div class="span12">
            <center><asp:Label ID="lblststus" runat="server" style="font-size:20px;line-height: 30px;"></asp:Label></center>
            <asp:TextBox ID="txtTitle" runat="server" placeholder="Event Title" required CssClass="input-block-level"></asp:TextBox>
            <asp:TextBox ID="txtEventDate" runat="server" placeholder="Event Date" required CssClass="input-block-level"></asp:TextBox>
            <asp:TextBox ID="txtMessage" runat="server" placeholder="Write Message" required TextMode="MultiLine" Rows="6" CssClass="input-block-level"></asp:TextBox>
            <asp:TextBox ID="txtRefURL" runat="server" placeholder="URL Reference[Optional]" CssClass="input-block-level"></asp:TextBox>
            <asp:Button ID="btnCreateEvent" runat="server" Text="Create Event" 
                CssClass="btn-large btn-blue" onclick="btnCreateEvent_Click"/>
        </div>
    </section>
    
</form>
</body>
</html>