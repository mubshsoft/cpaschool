<%@ Page Language="C#" Title="End Sample Exam"  AutoEventWireup="true" MasterPageFile="~/Student/StudentMaster.master" CodeFile="EndSample.aspx.cs" Inherits="EndSample" %>
<%--<%@ Register Src="../StudentHeader.ascx" TagName="Header" TagPrefix="uc1" %>

<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title>End Exam</title>
    <script type="text/javascript" src="../stmenu.js"></script>
<style type="text/css">
.text1 {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 12px;
	font-style: normal;
	font-weight: normal;
}
.style2 {font-family: Verdana, Arial, Helvetica, sans-serif; font-size: 11px; font-style: normal; font-weight: normal; }
</style>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/JavaScript">
<!--
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
//-->
</script>

<%--<script type="text/JavaScript">

   </script>
</head>--%>
 <div class="content-wrapper" onkeypress="javascript:HideMessage(),HideMessage2(),HideMessage3()">
        <!-- Content Header (Page header) -->
        <section class="content-header">
          <h1>
            Sample Test Completed
          </h1>
          <ol class="breadcrumb">
            <li><a href="../Student/StudentDashboard.aspx"><i class="fa fa-user"></i> Student Panel</a></li>
            <li class="active">Sample Test Completed</li>
          </ol>
        </section>

    <section class="content">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <strong><asp:Label ID="lblCaption" runat="server" /></strong>
    <div class="box"><div class="box-body" style="text-align:center; padding: 10em 0">
    <h1>Thank You</h1>
    </div></div>
                                        <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
    <asp:Label ID="lbltxt" runat="server"  CssClass="style5"></asp:Label> </div></div> 
         <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                                                                                       
                                                <asp:HiddenField ID="hdnSamId" runat="server" />
                                                 <asp:HiddenField ID="hdnusername" runat="server" />
                                                 </div></div>
                                           
   </div>
    </div>
   </section>
   </div>
   </asp:Content>
