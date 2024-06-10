<%@ Page Title="" Language="VB" MasterPageFile="~/HomeMaster-new.master" AutoEventWireup="false" CodeFile="PaymentResponse.aspx.vb" Inherits="PaymentResponse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" Runat="Server">
<style type="text/css">
    body>section {
        margin-top: 0;
    }
</style>

<section class="fullwidth banner-color">
	<h1 class="heading-color">Payment Response</h1> 
    <div class="breadcrumbs">
		<ul class="clearfix">
			<li><a href="Default-new.aspx">Home</a></li>
			<li>Payment Response</li>
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
                        <h4 runat="server" id="h1Message"></h4><hr />
                        <p runat="server" id="pTxnId"></p>
                        <p runat="server" id="pMode"></p>
                        <hr />
                    </div>
                </div>
            </div>
        </div> 
    </div>
 </form> 
</section>  
</asp:Content>

