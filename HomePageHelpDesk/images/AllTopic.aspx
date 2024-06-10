<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/Student/StudentMaster.master" CodeFile="AllTopic.aspx.vb" Inherits="AllTopic" Title="List of topics" %>

<%@ Register Src="allTopicList.ascx" TagName="Forum" TagPrefix="uc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
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

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
    <!-- Content Header (Page header) -->

    <section class="content-header">
<h1>
            List of topics
          </h1>
          <ol class="breadcrumb">
                        <%If Session("role") = "Admin" Then%>
                            <li><a href="admin/AdminLogin.aspx"><i class="fa fa-user"></i> Admin Panel</a></li>
            <li class="active">List of topics</li>
                        <% ElseIf Session("role") = "Faculty" Then %>
                            <li><a href="faculty/Facultypanel.aspx"><i class="fa fa-user"></i> Faculty Panel</a></li>
            <li class="active">List of topics</li>
                        <% ElseIf Session("role") = "Student" Then%>
                            <li><a href="Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">List of topics</li>
                        <%End If %>

                    </ol>
                
    </section>
 <section class="content">
     <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <div class="box box-primary">
            
            <div class="box-body">
    <div onkeypress="javascript:HideMessage()">
        
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <uc3:Forum ID="Forum" runat="server" />
            </div>
        </div>
      
    </div>  
                </div> 
        </div>                                 
   
</div>
</div>
</section>
</div>
<script src="Calendar/jquery-1.10.2.min.js"  ></script>
<script src="Student/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>
