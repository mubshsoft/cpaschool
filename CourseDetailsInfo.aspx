<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="CourseDetailsInfo.aspx.vb"  Inherits="CourseDetailsInfo"  Title="Course Details"%>



<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
.well {border:none; background:#fff;}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color"><asp:Label ID="lblHeading" runat="server" Text=""></asp:Label></h1> 
    <div class="breadcrumbs">
	
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li> 
			<li><a href="#">Courses</a></li>
			<li></li>
		</ul>
	
</div>
</section>


    <!-- / .title -->

    <section id="about-us" class="container main" style="margin-top:10em;">
        <div class="row">
<div>
            <asp:PlaceHolder ID = "PlaceHolder1" runat="server"  />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="background:#fff;padding:2em;">


                                                                
                                                            <asp:Label ID="lblText1" runat="server" Text="" CssClass="no-margin"></asp:Label>
                                                            
            </div>
            
            </div>
            </section>
           
           
 <script type="text/javascript">
     document.getElementById('coursepage').setAttribute("class", "active");
</script>
</asp:Content>