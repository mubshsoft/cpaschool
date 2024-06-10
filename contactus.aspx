<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="contactus.aspx.vb" Inherits="contactus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">

     <script type="text/javascript" src="../stmenu.js"></script>
    <style type="text/css">
        .style14
        {
            color: #000000;
            font-size: 11px;
            font-family: tahoma;
            width: 679px;
        }
        </style>
<style>body>section {
    margin-top: 0;
}
</style>
      <section class="fullwidth banner-color">
	<h1 class="heading-color">Contact Us</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>Contact Us</li>
		</ul>
	</div>
</section>
    <!-- / .title -->
    <form id="form1" runat="server">
    <section id="about-us" class="container main">
    <div class="row">&nbsp;</div>    
        <div class="row" style="margin-bottom: 20px;">
            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">                                          
                         
                                                                        <img src="images/5_text1.jpg" width="143" height="44" />
                                                                    <br />
                                                                        <asp:Label ID="lbltext" runat="server" Text=""></asp:Label>
                                                      </div>

                                            <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">  
                                                                    <p>Please provide us with the following information so we may respond to your 
                                                                        inquiry.</p>
                                                                        <p>Please note: All fields Marked with <font color="red">*</font> are required.</p>
                                                                    
                                                                       <h4>Contact Form</h4>
                                                                       Name <font color="red">*</font>
                                                                    <asp:TextBox ID="txtFirstName" runat="server" Width="200" MaxLength="30" TabIndex="1"
                                                                            CssClass="form-control"></asp:TextBox>
                                                                   E-mail <font color="red">*</font>
                                                                   <asp:TextBox ID="TextBox1" runat="server" Width="200" MaxLength="30" TabIndex="2"
                                                                            CssClass="form-control"></asp:TextBox>
                                                                    Contact No
                                                                   <asp:TextBox ID="TextBox2" runat="server" Width="200" MaxLength="30" TabIndex="3"
                                                                            CssClass="form-control"></asp:TextBox>
                                                                   Message
                                                                    <asp:TextBox ID="txtMessage" runat="server" Height="80" TabIndex="4" Width="300"
                                                                            TextMode="MultiLine" CssClass="form-control"></asp:TextBox><br />
                                                                    <a href="#" class="btn btn-warning">Submit</a>
                                                                                    
                </div>
                </div>
                </section>
                </form>
                </asp:content>
