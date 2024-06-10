
<%@ Page Title="About Us" Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="Aboutus.aspx.vb" Inherits="Aboutus"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color">About Us</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>About Us</li>
		</ul>
	</div>
</section>


    <!-- / .title -->
    <section id="about-us" class="container main">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        
                                                        <asp:Label ID="lbltext" runat="server" CssClass="no-margin" Text=""></asp:Label>
                                                    
    </div>
    </div>
    </section>
    
</asp:Content>
