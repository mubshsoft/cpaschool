<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="ScreeningPanel.aspx.vb" Inherits="Admin_ScreeningPanel" Title="Screening Panel" %>

<%--<%@ Register src="../AdminHeader.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="../Footer.ascx" tagname="Footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />
    <title></title>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

    <script type="text/javascript" src="../stmenu.js"></script>
    <style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Screening Panel</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="../Admin/Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Screening Panel</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    <div>
       

    <section class="container main m-tb">
    <div class="row" >
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">                            
    <div class="container item-container">
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><a href="ReActivateScreening.aspx"><img src="../images/Re-Activate_Screening.png" style="border:0px" /></a></div>
                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><a href="AdminListScreeningSet.aspx"><img src="../images/Evaluate_Answer_Sheets.png"  style="border:0px" /></a></div>
                </div>
    </div>
    </div>
    </div>
    </section>
                      
    </div>
    </form>
</asp:Content>
