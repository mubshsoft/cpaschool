<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="ReportPage.aspx.vb" Inherits="Faculty_ReportPage" Title="Report Page" %>

<%--<%@ Register src="../FacultyHeader.ascx" tagname="Header" tagprefix="uc1" %>

<%@ Register Src="../Footer.ascx" TagName="Footer" TagPrefix="uc2" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="Server">
<style>body>section {
    margin-top: 0;
}
.m-tb {margin-top: 9em; margin-bottom: 1em;}
.form-control {margin:5px 0;}
input[type=checkbox], input[type=radio] {
    margin: 4px 4px 0;}
</style>

    
    <section class="fullwidth banner-color">
    <h1 class="heading-color">Faculty Reports</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
        <li><a href="FacultyPanel.aspx"><font color="#fff">Faculty Panel</font></a></li>
       <li class="active">Faculty Reports</li>
		</ul>
	</div>
    </section>
    <form id="form1" runat="server">

    
  <section class="container main m-tb">
    
        <div class="row">
     <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12"> 

     <div class="user-info media box" style="background-color:#fff;">
                 <div class="row" style="padding: 40px 0 40px 0;">
                    
                   <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><a href="FacultyIntegratedReport.aspx"><img src="../images/facreport.png" style="border:0px"/></a> </div>
                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12 center"><a href="FacBatchReport.aspx"><img src="../images/batch_report.png" style="border:0px"/></a></div>
                   
                                                        
    </div>
                                                </div>

                                                </div>
                                                </div>
                                            
    </section>
    </form>


    </asp:Content>
