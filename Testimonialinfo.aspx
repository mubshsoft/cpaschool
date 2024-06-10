<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="Testimonialinfo.aspx.cs" Inherits="Testimonialinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color"><asp:Label ID="lblHeading" runat="server" Text="Testimonial"></asp:Label></h1> 
    <div class="breadcrumbs">
	
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li> 
			<li>Testimonial</li>
		</ul>
	
</div>
</section>


    <!-- / .title -->

    <section id="about-us" class="container main" style="margin-top:10em;">
        <div class="row" style="height: 25em;">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >


              <asp:Label ID="lblTestimonial" runat="server" Text="" CssClass="no-margin"></asp:Label>
                                                            
            </div>
            <div>
            <asp:PlaceHolder ID = "PlaceHolder1" runat="server"  />
            </div>
            </div>
            </section>
           
           
 <script type="text/javascript">
     document.getElementById('coursepage').setAttribute("class", "active");
</script>
</asp:Content>

