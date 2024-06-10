<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Chat_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
    <link rel="stylesheet" href="css/bootstrap-responsive.min.css"/>
    <link rel="stylesheet" href="css/font-awesome.min.css"/>
    <link rel="stylesheet" href="css/main.css"/>
    <style>
        .col-md-6
        {
            margin-bottom:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <section class="title" style="background:#888">
        <div class="container" style="margin-top:0">
            <div class="row-fluid">
                <div class="span6">
                    <h2 style="color:#fff"><i class="fa fa-video-camera"></i> Video Conferencing</h2>
                </div>
                <div class="span6">
                    <span class="pull-right" style="margin:18px;">
                   <a class="btn btn-warning" href="../logout.aspx">Logout</a>
                   </span>
                </div>
            </div>
        </div>
    </section>

    <section class="container">
        <div class="row" style="margin-top: 20px;">
            <div class="col-md-12">
                
                    <div id="admin" runat="server" class="row" style="padding: 60px 0px;" visible="false">
                        <div class="col-md-6" align="center"><a href="CreateVC.aspx" class="btn btn-primary" style="padding: 40px;">Organise Confrencing</a></div>
                        <div class="col-md-6" align="center"><a href="StartVC.aspx"  class="btn btn-success"  style="padding: 40px;">Start Confrencing</a></div>
                    </div>
                    <div id="student" runat="server" class="row-fluid" style="padding: 60px 0px;" visible="false">
                        <div class="col-md-6" align="center"><a href="StartVC.aspx"  class="btn btn-success"  style="padding: 40px;">Start Confrencing</a></div>
                    </div>
                   
                
             </div>
        </div>   
    </section>
    </form>
</body>
</html>
