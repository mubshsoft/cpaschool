<%@ Page Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true"
    CodeFile="AssignmentDownLoad.aspx.cs" Inherits="AssignmentDownLoad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .grid-header-Overtime
        {
            background: url(../images/custImg/pymnt-grid-header.jpg) repeat-x;
            height: 22px;
            color: #000000;
            font-family: Verdana,Arial,Tahoma;
            font-size: 10px;
            font-weight: bold;
        }
        
        .grid-row-Overtime
        {
            background-color: #ffffff;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
        
        .grid-altrow-Overtime
        {
            background-color: #eeeeee;
            color: #282828;
            font-size: 10px;
            height: 15px;
            font-family: Verdana,Arial,Tahoma;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">

        function openPopup(strOpen) {
            window.open(strOpen, "Info", "status=1, width=400, height=130, top=300, left=300");
        }
    
   
        
    </script>
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper" onkeypress="javascript:HideMessage(),HideMessage2(),HideMessage3()">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Assignment Set
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Assignment Set</li>
          </ol>
        </section>
        <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="box">
                <div class="box-body">
                <div class="row">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="text-align:center">
    
                                                            <asp:LinkButton ID="lnkbtndownload" runat="server" 
                                                                onclick="lnkbtndownload_Click1">
                                                       <img src="../images/download_assignment.png" style="border:0px"    /></asp:LinkButton>
                                                        </div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="text-align:center">
                                                             <asp:LinkButton ID="lnkbtnSubmit" runat="server" onclick="lnkbtnSubmit_Click">
                                                       <img src="../images/submit_assignment.png" style="border:0px"/></asp:LinkButton>
                                                  </div>

                                                  </div></div></div>
                                                  </div>
                  </div>                               
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                  <div class="box"><div class="box-body">
                <div class="row"><div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                <asp:HiddenField ID="hdnAsgnId" runat="server" /></div></div></div></div>
                                            
   
    </div>
    </div>
    </section>
    </div>
    <script src="../Calendar/jquery-1.10.2.min.js"  ></script>
</asp:Content>
