<%@ Page Title="Our Faculties" Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="FacultiesDetail.aspx.vb" Inherits="FacultiesDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>
blockquote small:before
{
    content: "\f0e0";
    font-family: FontAwesome;
    color: #3598db;
}
body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color">Our Faculties</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>Our Faculties</li>
		</ul>
	</div>
</section>
 <!-- / .title -->
<form runat="server" id="frm1">

   

    <section id="alumni-speak" class="container main">
    <div class="row">&nbsp;</div>    
        <div class="row" style="margin-bottom: 20px; background: #fff; border-radius: 10px; padding: 2em;">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
        <div class="pull-right box" style="background-color:#e2e1e1">
           Select Course <asp:DropDownList ID="ddlCourseList" runat="server" AutoPostBack="true" style="width:100%">
            </asp:DropDownList>
        </div>
    </div>
      <asp:Repeater ID="rptrFaculties" runat="server">
        <ItemTemplate>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="row">
                        <div class="col-lg-2 col-md-2 col-sm-12 col-xs-12">
                            <div class="hover13">
                                <img src='<%# IIf(Eval("Images").ToString() = "", "Images/noimage.png", Eval("Images"))%>' alt="Faculty" class="image"  />
                            </div>
                        </div>
                        <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12 no-margin">
                                <blockquote>
                                    <p style="text-transform:uppercase"><%# Eval("firstName")%> <%# Eval("lastname")%></p>
                                    <small> <cite title="Source Title"><%# Eval("email")%></cite></small>
                                </blockquote>
                                <p style="text-align:justify"><%# Eval("Profile")%></p>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
        </ItemTemplate>
      </asp:Repeater>
</div></div>
    </section>
    </form>
</asp:Content>

