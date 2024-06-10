<%@ Page Language="C#" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="true" CodeFile="ScreeningLogin.aspx.cs" Inherits="ScreeningLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
    <script type="text/javascript" src="stmenu.js"></script>
       <script language="javascript" type="text/javascript">
              function HideMessage()
                    {
                   
                     if(document.all)
                        {
                         document.getElementById('<%=lblMessage.ClientID%>').innerText = '';
                        } 
                        else
                        {
                          document.getElementById('<%=lblMessage.ClientID%>').textContent ='';
                        }
                     }
      </script>
      <style>body>section {
    margin-top: 0;
}
</style>
<section class="fullwidth banner-color">
	<h1 class="heading-color">Screening Login</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>Screening Login</li>
		</ul>
	</div>
</section>
<!-- / .title -->
    <form id="form1" runat="server">
    <div  onkeypress="javascript:HideMessage()">
    <section>
    <div class-"panel" align="center">
    <div class="panel-body">
        <fieldset class="registration-form" style="margin: 20px 0;">
        <div class="control-group">
            <div class="controls" style="font-family:arial">
         <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
         </div>
         </div>
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
            <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="images/login.png"  onclick="btnLogin_Click" />
            </div>
            </div>
            </fieldset>
         </div>
         </div>
         </section>
         </div>  
    </form>
</asp:content>

