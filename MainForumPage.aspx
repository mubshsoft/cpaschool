<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="MainForumPage.aspx.vb"  Inherits="MainForumPage" Title="Discussion Forum" %>

<%--<%@ Register Src="MainHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>

<%@ Register Src="ForumTopic.ascx" TagName="Forum" TagPrefix="uc3" %>


<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="stylesheet/style.css" type="text/css" rel="stylesheet" />
    <link href="stylesheet/gridStyle.css" type="text/css" rel="stylesheet" />

<script type="text/javascript" src="stmenu.js"></script>
--%> 
   
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #3c8dbc;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script language="javascript" type="text/javascript">
              function openPopup(strOpen)
                {
                    open(strOpen, "Info", "status=1, width=350, height=330, top=20, left=300");
                }
           
    </script>


 <div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
          <h1>
            List of Topics
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-dashboard"></i> Home</a></li>
            <li class="active">List of Topics</li>
          </ol>
        </section>
    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">      
    
    <%--<div onkeypress="javascript:HideMessage()"></div>--%>
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            <div class="box box-primary">
            
            <div class="box-body">
     
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                             <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate >
                                                <uc3:Forum ID="Forum" runat="server" />
                                                </ContentTemplate>
</asp:UpdatePanel>
          </div>
          </div>
          </div>
          </div>                                  
    </div>
    

    </div>

     </section>

    </div>
    <script src="Calendar/jquery-1.10.2.min.js" ></script>
    <script src="Student/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>