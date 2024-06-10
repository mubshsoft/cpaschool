<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="CaseStudyPanel.aspx.cs" Inherits="Admin_CaseStudyPanel" %>

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
    <h1 class="heading-color">Case Study Panel</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="Adminlogin.aspx">Admin Panel</a></li>
        <li class="active">Case Study Panel</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">

    <section class="container main m-tb">
    <div class="row">
    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

    <div class="container item-container">
                <div class="row" style="padding: 30px 0 30px 0;">
                 <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="AddCaseStudySet.aspx"><img src="../Images/AddCaseStudy.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="CaseStudyActivate.aspx"><img src="../Images/AssignCaseStudy.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="ReActivateCaseStudy.aspx"><img src="../Images/ReactivateCaseStudy.png" style="border:0px" /></a></div>
                <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 center"><a href="CaseStudyBatchList.aspx"><img src="../Images/BatchListCaseStudy.png" style="border:0px" /></a></div>
    </div>
    </div>
    </div>
    </div>
    </section>


    
    </form>

</asp:Content>


