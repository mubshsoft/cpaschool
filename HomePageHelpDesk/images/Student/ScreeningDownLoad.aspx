<%@ Page Language="C#" MasterPageFile="~/Student/StudentMaster.master" AutoEventWireup="true" CodeFile="ScreeningDownLoad.aspx.cs" Inherits="ScreeningDownLoad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
   <script type="text/javascript" src="../stmenu.js"></script>
      <script language="javascript" type="text/javascript">
   
function openPopup(strOpen)
    {
        open(strOpen, "Info", "status=1, width=400, height=130, top=20, left=300");
    }
    
   
        
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
          <h1>
            Screening
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Screening</li>
          </ol>
        </section>
        <section class="content">
        
    <div class="box">
    <div class="box-body" >
        <div class="row">
        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="text-align:center">
                                                            <asp:LinkButton ID="lnkbtndownload" runat="server" 
                                                                onclick="lnkbtndownload_Click1">
                                                       <img src="../images/download_Screening.png" style="border:0px"    /></asp:LinkButton>
                                                        </div>
                                                        <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12" style="text-align:center">
                                                             <asp:LinkButton ID="lnkbtnSubmit" runat="server" onclick="lnkbtnSubmit_Click">
                                                       <img src="../images/submit_Screening.png" style="border:0px"/></asp:LinkButton>
                                                       </div></div>
                                                    </div></div>
        <div class="row">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">   
                                                <asp:HiddenField ID="hdnScrId" runat="server" />
                                           
    </div>
    </div>
    
    </section>
    </div>
    </asp:content>
    