<%@ Page Title="Forgotten Password" Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="ForgottenPassword.aspx.cs" Inherits="ForgottenPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color">Forgot Password</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>Login</li>
		</ul>
	</div>
</section>
<form id="form1" runat="server">

    

    <section>
    <div class-"panel" align="center">
    <div class="panel-body">
        <fieldset class="registration-form" style="margin: 20px 0;">
    
        <div class="control-group">
            <div class="controls" style="font-family:arial">
                <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
        </div>
          <!-- Username -->
        <div class="control-group">
          <div class="controls">
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email Id" required height="40px" CssClass="form-control"></asp:TextBox>
          </div>
        </div>

 
         <div class="control-group">
            <div class="controls" style="font-family:arial">                                           
            <asp:Button ID="btnLogin" runat="server" Text="Send Password" CssClass="btn btn-success btn-large arial" onclick="btnLogin_Click"  />
              &nbsp;                                             
            <asp:Button ID="btnlostPassword" Text="Cancel" runat="server" 
                    CssClass="btn btn-warning btn-large arial" onclick="btnlostPassword_Click"  />
            </div>
            </div>
            <hr />
            <small>Your password will be sent on your email id. </small>
        </fieldset>

    </div>
    </div>
    </section>
    </form>
</asp:Content>

