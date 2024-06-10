<%@ Page Title="Mob Admin" Language="C#" AutoEventWireup="true" CodeFile="MobAdminPanel.aspx.cs" Inherits="Mob_MobAdminPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <h2 style="color:#fff">Mobile Admin Panel</h2>
                </div>
                <div class="span6">
                    <ul class="breadcrumb pull-right">
                        <li class="active"><a href="../logout.aspx"><font color="#fff">Logout</font></a></li>
                    </ul>
                </div>
            </div>
        </div>
    </section>

    <section class="container main">
        <div class="row-fluid" style="margin-top: 20px;">
            <div class="span12">
                <div class="user-info media box" style="background-color:#fff">
                    <div class="row-fluid" style="padding: 60px 0px;">
                        <div class="span3" align="center"><a href="sendNotification.aspx" style="padding:40px 20px"  class="btn-large btn-blue"><i class="icon-bell"></i> Send Notification</a></div>
                        <div class="span3" align="center"><a href="AllNotification.aspx"  style="padding:40px 20px" class="btn-large btn-blue"><i class="icon-bell-alt"></i> Manage Notification</a></div>
                        <div class="span3" align="center"><a href="CreateEvents.aspx" style="padding:40px 20px" class="btn-large btn-blue"><i class="icon-calendar-empty"></i> Create Events</a></div>
                        <div class="span3" align="center"><a href="UpcomingEvents.aspx" style="padding:40px 20px" class="btn-large btn-blue"><i class="icon-calendar"></i> Manage Events</a></div>
                    </div>
                   
                </div>
             </div>
        </div>   
    </section>
    </form>
</body>
</html>
