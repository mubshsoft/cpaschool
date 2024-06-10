<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile = "~/Student/StudentMaster.master" CodeFile="PostReply.aspx.vb" Inherits="PostReply" ValidateRequest="false" Title="Discussion Forum" %>

<%--<%@ Register Src="MainHeader.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
--%>
<%@ Register Src="reply.ascx" TagName="reply" TagPrefix="uc3" %>

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
    
    <%--<div onkeypress="javascript:HideMessage()"></div>--%>
        
                                <%--   <asp:SiteMapDataSource ID="_mainMenuDataSource" runat="server" ShowStartingNode="true" />
                                    <asp:SiteMapPath ID="SiteMapPath1" runat="server" CssClass="style1" RootNodeStyle-Font-Bold="true" CurrentNodeStyle-Font-Bold="true" Font-Bold="true" NodeStyle-Font-Bold="true" >
                                    </asp:SiteMapPath>--%>
                            <div class="box box-primary">
            
            <div class="box-body">
     
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" align="center">
                                             <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate >
                                                        <uc3:reply ID="reply1" runat="server" />
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