<%@ Page Language="VB" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="false" CodeFile="Notification.aspx.vb" Inherits="Notification" Title="Notification List" %>




 <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
td, th {
    padding: 5px;
}
.form_head {background: #0e245d;
    color: #fff;
    border: 0;}
    .form_body {border: solid 1px #e2e2e2;
    background: #fff;}
    .date {
    font-size: 15px;
    font-weight: 400;
    margin-bottom: 15px;
}
.date span {
    padding-right: 15px;
    display: inline-block;
    min-width: 32%;
}
body{margin-top:20px;
background:#eee;
}

.senden-img{
    width:50px;
    height:50px;
}

.btn-compose-email {
    padding: 10px 0px;
    margin-bottom: 20px;
}

.btn-danger {
    background-color: #E9573F;
    border-color: #E9573F;
    color: white;
}

.panel-teal .panel-heading {
    background-color: #37BC9B;
    border: 1px solid #36b898;
    color: white;
}

.panel .panel-heading {
    padding: 5px;
    border-top-right-radius: 3px;
    border-top-left-radius: 3px;
    border-bottom: 1px solid #DDD;
    -moz-border-radius: 0px;
    -webkit-border-radius: 0px;
    border-radius: 0px;
}

.panel .panel-heading .panel-title {
    padding: 10px;
    font-size: 17px;
}

form .form-group {
    position: relative;
    margin-left: 0px !important;
    margin-right: 0px !important;
}

.inner-all {
    padding: 10px;
}

/* ========================================================================
 * MAIL
 * ======================================================================== */


.nav-email-subtitle {
  font-size: 15px;
  text-transform: uppercase;
  color: #333;
  margin-bottom: 15px;
  margin-top: 30px;
}



.view-mail {
  padding: 10px;
  font-weight: 300;
}



@media (max-width: 360px) {
  .mail-wrapper .panel-sub-heading {
    text-align: center;
  }
  .mail-wrapper .panel-sub-heading .pull-left, .mail-wrapper .panel-sub-heading .pull-right {
    float: none !important;
    display: block;
  }
  .mail-wrapper .panel-sub-heading .pull-right {
    margin-top: 10px;
  }
  .mail-wrapper .panel-sub-heading img {
    display: block;
    margin-left: auto;
    margin-right: auto;
    margin-bottom: 10px;
  }

  
}
</style>
</asp:Content>

     <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
 

 
    <div class="content-wrapper">
<!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Notification 
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active"> Notification </li>
          </ol>
        </section>
    <section class="content">
     
        <div class="row">&nbsp;</div>
         <div class="row">
                                                       <div class="col-sm-12">
        <!-- Star form compose mail -->
        <form class="form-horizontal">
            <div class="panel mail-wrapper rounded shadow">
                <!-- /.panel-heading -->
                <div class="panel-sub-heading inner-all">
                    <div class="pull-left">
                        <h3 class="lead no-margin"><asp:Label ID="lblsubject" runat="server"></asp:Label></h3>
                    </div>
                    
                    <div class="clearfix"></div>
                </div><!-- /.panel-sub-heading -->
                <div class="panel-sub-heading inner-all">
                    <div class="row">
                        <div class="col-md-8 col-sm-8 col-xs-7">
                          
                           <strong>From: </strong> <span><asp:Label ID="lblfrom" runat="server"></asp:Label></span>
                            
                            
                        </div>
                        <div class="col-md-4 col-sm-4 col-xs-5">
                            <p class="pull-right"> <asp:Label ID="lbldate" runat="server"></asp:Label></p>
                        </div>
                    </div>
                </div><!-- /.panel-sub-heading -->
                <div class="panel-body">
                    <div class="view-mail">
                        <p>
                           <asp:Label ID="lblbody" runat="server"></asp:Label>
                        </p>
                        
                    </div><!-- /.view-mail -->
                  
                </div><!-- /.panel-body -->
                <!-- /.panel-footer -->
            </div><!-- /.panel -->
        </form>
        <!--/ End form compose mail -->
    </div>
                    </div>                       
       </section>
    </div>

   
  

</asp:Content>