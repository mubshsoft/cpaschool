<%@ Page Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="PostQuery.aspx.vb" Inherits="PostQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style>body>section {
    margin-top: 0;
}
</style>

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

   <section class="fullwidth banner-color">
	<h1 class="heading-color">Post Query</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default.aspx">Home</a></li> 
			<!-- <li><a href="/knowledge-corner">Knowledge Corner</a></li> -->
			<li>Post Query</li>
		</ul>
	</div>
</section>
    <!-- / .title -->
    <form id="form1" runat="server">
  
    <div onkeypress="javascript:HideMessage()">
  <section id="about-us" class="container main">
    <div class="row">&nbsp;</div>    
        <div class="row" style="margin-bottom: 20px;">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                                            <asp:Label ID="lblMessage" EnableViewState="false" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                           
                                                       </div>
                                                       </div>
                                                    <div class="row">
                                                    <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Name :</div>
                                                     <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                     <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Address :</div>
                                                     <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                     </div>
                                                     <div class="row">&nbsp;</div>  
                                                     <div class="row">
                                                     <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Contact Number :</div>
                                                    <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control"></asp:TextBox></div>
                                                     <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Email Id :<asp:Label ID="Label2" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                                                     <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtEmailId" runat="server" ErrorMessage="Required" Display="dynamic"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmailId" Display="dynamic"
                                                                ErrorMessage="<br>Invalid Email Address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                     </div>
                                                     </div>
                                                     <div class="row">&nbsp;</div>  
                                                     <div class="row">       
                                                      <div class="col-lg-2 col-md-2 col-sm-3 col-xs-3">Query :<asp:Label ID="Label4" Text="*" ForeColor="Red" runat="server"></asp:Label></div>
                                                       <div class="col-lg-4 col-md-4 col-sm-9 col-xs-9"><asp:TextBox ID="txtQuery" runat="server" CssClass="form-control" TextMode="MultiLine" Height="80px"></asp:TextBox>
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtQuery" runat="server" Display="dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator></div>
                                                       </div>
                                                       <div class="row">&nbsp;</div>  
                                                  <div class="row">       
                                                      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="text-align:center">
                                                            <asp:ImageButton ID="btnSave" runat="server"  ImageUrl="Images/Send.png"  onclick="btnSave_Click"/>&nbsp;&nbsp;<asp:ImageButton ID="btnCancel" runat="server"  ImageUrl="Images/cancel.png"/>
                                                                </div>
                                                                </div>
   
    </section>
    </div>
    </form>
    </asp:content>
