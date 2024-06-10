<%@ Page MasterPageFile="~/InnerMaster.master" Language="VB" AutoEventWireup="false" CodeFile="AddCourseEmail.aspx.vb" Inherits="AddCourseEmail" Title="Admin Panel" %>

<%--<%@ Register src="../AdminHeader.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register src="../Footer.ascx" tagname="Footer" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../stylesheet/style.css" type="text/css" rel="stylesheet" />--%>
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
    <asp:Label ID="lblCaption" Visible="false" runat="server" />
    <h1 class="heading-color">Administrator Panel</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Administrator Panel</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">
    
<section class="container main m-tb">
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:Label ID="lblHeading" runat="server" ></asp:Label></div></div>
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                <div class="container item-container">
                <div class="row" style="padding: 30px 0 30px 0;">
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 center"><a href="AddCourseEmailContent.aspx?emailtype=reg&courseid=<%= Request.QueryString("courseid") %>&dt=<%= Request.QueryString("dt") %>"><img src="../images/Registration Email.png" style="border:0px" /></a></div>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 center"><a href="AddCourseEmailContent.aspx?emailtype=approv&courseid=<%= Request.QueryString("courseid") %>&dt=<%= Request.QueryString("dt") %>"><img src="../images/Approval email.png"  style="border:0px" /></a></div>
                </div>
                </div>
                </div>
                </div>
   <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 center"><asp:Button ID="btnSave" runat="server" Text="Save and Continue" CssClass="btn btn-success btn-large"  /></div>
    </div>  
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"><asp:HiddenField ID="hdncourseid" runat="server" /></div>
    </div>
                </section>                                     
                                        
                                                            
                                        
                                       
   
    </form>

    </asp:Content>

