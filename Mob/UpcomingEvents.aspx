<%@ Page Title="Upcoming Events" Language="C#" AutoEventWireup="true" CodeFile="UpcomingEvents.aspx.cs" Inherits="Mob_UpcomingEvents" %>

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
                    <h2 style="color:#fff"><i class="icon-calendar"></i> Upcoming Events</h2>
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
    <section id="faqs" class="container" >
        <br />
       <asp:Repeater ID="rptrNotList" runat="server">
            <ItemTemplate>
        <div class="user-info media box" style="background:#ffffff;word-wrap: break-word;overflow-wrap: break-word;width: 95%;">
            <div class="pull-right">
                    <asp:LinkButton id="lnkbtnDelNote" CommandName="Delete"  CommandArgument='<%# Eval("Id") %>' OnCommand="lnkbtnDelEvent_Command" runat="server"><i class="icon-2x icon-remove" style="color:red;" title="Delete"></i></asp:LinkButton>
                </div>
            <div class="span12">
                <%--<%# Container.ItemIndex + 1 %></span>--%>
                <h5 style="margin-top: 0"><%# Eval("Title") %></h5>
            </div>
            <div class="media-body span12">
                <span style="margin-bottom: 0px;"><i class="icon-calendar" style="color:#f55928"></i> <%# Eval("EventDate") %></span>
                <hr style="margin:0px 0px 6px 0px" />
                <p style="text-align:justify; padding-right:10px"><%# Eval("Message") %></p>
                <a href="javascript:window.open('<%# Eval("Eurl") %>','_blank','location=yes');"><%# Eval("Eurl") %></a>
            </div>
        </div>
        </ItemTemplate>
        </asp:Repeater>
   
    <p>&nbsp;</p>
    
</section>
    
</form>
</body>
</html>
