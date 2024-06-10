<%@ Page MasterPageFile="~/HomeMaster-new.master" Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="login" Title="Login" %>

<%--<%@ Register Src="MainHeader.ascx" TagName="MainHeader" TagPrefix="uc1" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
--%>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <style>body>section {
    margin-top: 0;
}
</style>

   <section class="fullwidth banner-color">
	<h1 class="heading-color">Login</h1> 
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
            <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" height="40px" CssClass="form-control"></asp:TextBox>
          </div>
        </div>

        <div class="control-group">
          <div class="controls">
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" height="40px" placeholder="Password" CssClass="form-control"></asp:TextBox>
          </div>
        </div>

        <div class="control-group">
            <div class="controls" style="font-family:arial">
        <a href="registration1.aspx?s=3" class="input-xlarge">New User Registration?</a>
         </div>
         </div>   
         
         <div class="control-group">
            <div class="controls" style="font-family:arial">                                           
        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success btn-large arial"  />
              &nbsp;                                             
            <asp:Button ID="btnlostPassword" Text="Cancel" runat="server" CssClass="btn btn-warning btn-large arial"  />
            </div>
            </div>
            <hr />
            <a href="ForgottenPassword.aspx">Forgotten password ?</a>

    </div>
    </div>
    </section>
    </form>
    <script type="text/javascript">
        document.getElementById('loginpage').setAttribute("class", "active");
</script>    
</asp:Content>  

