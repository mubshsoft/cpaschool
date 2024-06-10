<%@ Page Title="Manage Notifications" Language="C#" AutoEventWireup="true" CodeFile="AllNotification.aspx.cs" Inherits="Admin_AllNotification" %>

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
                    <h2 style="color:#fff">Manage Notifications</h2>
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
    <section id="faqs" class="container">
        <br />
        <asp:Repeater ID="rptrNotList" runat="server">
            <ItemTemplate>
                
                    <%--<span class="number"><%# Container.ItemIndex + 1 %></span>
                    <div style="border-bottom: solid 1px #3598db;width: 100%;overflow: auto;">
                        <h4><%# Eval("Title") %></h4>
                        <p style="text-align:justify; padding-right:10px"><%# Eval("Message") %></p><%# Eval("Rurl") %>
                        <span class="pull-right"><i class="icon-calendar"></i> <%# Eval("NotificationDate") %></span>
                    </div>--%>
                    <div class="user-info media box" style="background:#ffffff;word-wrap: break-word;overflow-wrap: break-word;width: 95%;">
                        <div class="pull-left">
                            <%# Container.ItemIndex + 1 %></span>
                        </div>
                        <div class="pull-right">
                            <asp:LinkButton id="lnkbtnDelNote" CommandName="Delete"  CommandArgument='<%# Eval("Id") %>' OnCommand="lnkbtnDelNote_Command" runat="server"><i class="icon-2x icon-remove" style="color:red"></i></asp:LinkButton>
                        </div>
                        <div class="media-body">
                            <h5 style="margin-top: 0"><%# Eval("Title") %></h5>
                            <p style="text-align:justify; padding-right:10px"><%# Eval("Message") %></p><%# Eval("Rurl") %>
                            <div class="author-meta">
                                <span class="pull-right"><i class="icon-calendar"></i> <%# Eval("NotificationDate") %></span>
                            </div>
                        </div>
                    </div>
                  
                
            </ItemTemplate>
        </asp:Repeater>
    <p>&nbsp;</p>
    
</section>
</form>
</asp:Content>

