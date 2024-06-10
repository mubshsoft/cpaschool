<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="AlumniSpeaks.aspx.vb" Inherits="AlumniSpeaks" Title="Alumni Speaks" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
  <style>body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color">Alumni Speaks</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li> 
			<li>Alumni Speaks</li>
		</ul>
	</div>
</section>
    <!-- / .title -->
     <section id="alumni-speak" class="container main">

      <asp:Repeater ID="rptrAlumni" runat="server">
        <ItemTemplate>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="row">
                        <div class="span2">
                            <div class="hover13">
                                <img src='<%# IIf(Eval("Image").ToString() = "", "Images/noimage.png", Eval("Image"))%>' alt="Faculty" class="image"  />
                            </div>
                        </div>
                        <div class="span10 no-margin">
                                <blockquote>
                                    <p style="text-transform:uppercase"><%# Eval("title")%> <%# Eval("name")%><br />
                                    <address><%# Eval("address")%></address>
                                    </p>
                                    <small> <cite title="Source Title"><%# Eval("batch")%></cite></small>
                                </blockquote>
                                <p style="text-align:justify"><%# Eval("desc")%></p>
                        </div>
                    </div>
                </div>
            </div>
            <hr />
        </ItemTemplate>
      </asp:Repeater>
    </section>
    
</asp:Content>    
