<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="Faq.aspx.cs" Inherits="Faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
   
<style>
    .bs-example{
        margin: 20px;
    }
    body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color">FAQ</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>FAQ</li>
		</ul>
	</div>
</section>
 <!-- / .title -->
    <form id="form1" runat="server">


    
     <section class="container main"> 
         <div class="row" >
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin:20px;">
                 <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red" ></asp:Label>
             </div>
         </div>
        <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin:20px;"><asp:DropDownList ID="ddlCourse" AutoPostBack="true" ToolTip="Course Code" runat="server" CssClass="input-block-level" onselectedindexchanged="ddlCourse_SelectedIndexChanged" />
                    </div>
            </div> 
       <div class="row">
           <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
               <div class="bs-example">
                 <div class="accordion" id="accordionExample">
                  <asp:PlaceHolder ID = "PlaceHolder1" runat="server"  />
    
       
                     </div>
    </div>
           </div>
       </div>
    </section> 
        </form> 
</asp:Content>



