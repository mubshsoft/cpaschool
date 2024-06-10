<%@ Page Title="" Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="MakePayment.aspx.vb" Inherits="MakePayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style type="text/css">
    body>section {
        margin-top: 0;
    }
</style>

<section class="fullwidth banner-color">
	<h1 class="heading-color">Make A Payment</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li>
			<li>Make a payment</li>
		</ul>
	</div>
</section>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<section>
<form id="form1" runat="server">
    <div class="container center">
        <div class="card" style="width:500px; margin:auto; padding:40px; padding-top:20px">
            <div class="card-body" style="padding-top:120px">
                <div class="row">
                    <div class="col-md-12">
                        <h4>Please use registered Email and Contact number only.</h4>
                        <asp:TextBox ID="txtName" runat="server" placeholder="Name" CssClass="form-control" required></asp:TextBox><br />
                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control" required></asp:TextBox><br />
                        <asp:TextBox ID="txtMobileNumber" runat="server" placeholder="Mobile Number" CssClass="form-control" required></asp:TextBox><br />
                        <asp:TextBox ID="txtAmount" runat="server" placeholder="Order Amount" CssClass="form-control" required></asp:TextBox><br />
                        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" class="btn btn-primary"/>
                    </div>
                </div>
            </div>
        </div> 
    </div>
 </form> 
</section>  
</asp:Content>

