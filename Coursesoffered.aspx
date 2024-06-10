<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="Coursesoffered.aspx.vb" Inherits="Coursesoffered" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="stmenu.js"></script>
<script>
window.onload = function() {
    location.href = "http://www.fmsflearningsystems.org/Default-new.aspx";
}
</script>
  
<style>body>section {
    margin-top: 0;
}
</style>
      <section class="fullwidth banner-color">
	<h1 class="heading-color">Courses Offered</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>Courses Offered</li>
		</ul>
	</div>
</section>
    <form id="form1" runat="server">
    
    <section id="about-us" class="container main">
    <div class="row">&nbsp;</div>    
        <div class="row" style="margin-bottom: 20px;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        
                                               <p>Capacity building is one of the core competencies of FMSF. Over the past 15 years,
                                                the capacity building initiative has undergone changes. The capacity building initiative,
                                                initially was only restricted to training on EED requirements to the partner network
                                                and eventually shifted to the broader areas of financial management, governance
                                                and social accountability issues. The shift has been from an 'awareness raising'
                                                mode to 'specific tools' followed by 'Good practices'.</p>
                                                <p style="text-align:center"><img src="images/courses.jpg" /></p>
                                                <p> 
                                                At present, FMSF is focusing on capacity building through &quot;specific sustained
                                                courses&quot;.</p>
                                                
                                                <a href="DFMA.aspx" class="links">1. Diploma in Financial Management & accountability
                                                    (DFMA)</a>
                                                
                                                <br />
                                                <a href="NGMP.aspx" class="links">2. NGO Governance & Management Program</a>
                                                </div>
                                                </div>
                                                </section>
    </form>
</asp:content>