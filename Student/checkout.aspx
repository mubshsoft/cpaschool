<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="Student_checkout" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Jaypee Journals | Sub-merchant checkout page</title>
   <script type="text/javascript">
       window.onload = function () {
           var d = new Date().getTime();
           document.getElementById("tid").value = d;
       };
        function aa()
        {
            document.customerData.submit();
        }
    </script>
</head>
<body onload="aa();" >
   <form method="post" name="customerData" action="ccavRequestHandler.aspx">
       

        <table width="50%" height="100" border='1' align="center">
				<tr>
					<td>Parameter Name:</td><td>Parameter Value:</td>
				</tr>
				<tr>
					<td colspan="2"> Compulsory information</td>
				</tr>
				<tr>
                    <td>Tid</td>
                    <td><input readonly="readonly" type="hidden" name="tid" id="tid" value=""/></td>
                </tr>
				<tr>
					<td>Merchant Id	:</td><td><input type="hidden" name="merchant_id" id="merchant_id" runat="server"/></td>
				</tr>
				<tr>
					<td>Order Id	:</td><td><input type="hidden" name="order_id" id="order_id" runat="server" /></td>
				</tr>
				<tr>
					<td>Amount	:</td><td><input type="hidden" name="amount" runat="server" id="amount"/></td>
				</tr>
				<tr>
					<td>Currency	:</td><td><input type="hidden" name="currency" runat="server" id="currency"/></td>
				</tr>
				<tr>
					<td>Redirect URL	:</td><td><input type="hidden" name="redirect_url" runat="server" id="redirect_url"/></td>
				</tr>
			 	<tr>
			 		<td>Cancel URL	:</td><td><input type="hidden" name="cancel_url" runat="server" id="cancel_url"/></td>
			 	</tr>
			 	<tr>
					<td>Language	:</td><td><input type="hidden" name="language" value="EN"/></td>
				</tr>
		     	<tr>
		     		<td colspan="2">Billing information(optional):</td>
		     	</tr>
		        <tr>
		        	<td>Billing Name	:</td><td><input type="hidden" name="billing_name" runat="server" id="billing_name"/></td>
		        </tr>
		        <tr>
		        	<td>Billing Address	:</td><td><input type="hidden" name="billing_address" runat="server" id="billing_address"/></td>
		        </tr>
		        <tr>
		        	<td>Billing City	:</td><td><input type="hidden" name="billing_city" runat="server" id="billing_city"/></td>
		        </tr>
		        <tr>
		        	<td>Billing State	:</td><td><input type="hidden" name="billing_state" runat="server" id="billing_state"/></td>
		        </tr>
		        <tr>
		        	<td>Billing Zip	:</td><td><input type="hidden" name="billing_zip" runat="server" id="billing_zip"/></td>
		        </tr>
		        <tr>
		        	<td>Billing Country	:</td><td><input type="hidden" name="billing_country" runat="server" id="billing_country"/></td>
		        </tr>
		        <tr>
		        	<td>Billing Tel	:</td><td><input type="hidden" name="billing_tel" runat="server" id="billing_tel"/></td>
		        </tr>
		        <tr>
		        	<td>Billing Email	:</td><td><input type="hidden" name="billing_email" runat="server" id="billing_email"/></td>
		        </tr>
		        <tr>
		        	<td colspan="2">Shipping information(optional)</td>
		        </tr>
		        <tr>
		        	<td>Shipping Name	:</td><td><input type="hidden" name="delivery_name" runat="server" id="delivery_name"/></td>
		        </tr>
		        <tr>
		        	<td>Shipping Address	:</td><td><input type="hidden" name="delivery_address" runat="server" id="delivery_address"/></td>
		        </tr>
		        <tr>
		        	<td>shipping City	:</td><td><input type="hidden" name="delivery_city" runat="server" id="delivery_city"/></td>
		        </tr>
		        <tr>
		        	<td>shipping State	:</td><td><input type="hidden" name="delivery_state" runat="server" id="delivery_state"/></td>
		        </tr>
		        <tr>
		        	<td>shipping Zip	:</td><td><input type="hidden" name="delivery_zip" runat="server" id="delivery_zip"/></td>
		        </tr>
		        <tr>
		        	<td>shipping Country	:</td><td><input type="hidden" name="delivery_country" runat="server" id="delivery_country"/></td>
		        </tr>
		        <tr>
		        	<td>Shipping Tel	:</td><td><input type="hidden" name="delivery_tel" runat="server" id="delivery_tel"/></td>
		        </tr>
		     
				 
		       <%-- <tr>
		        	<td></td><td><INPUT TYPE="submit" value="CheckOut"></td>
		        </tr>--%>
	      	</table>
        <%--<input type="submit" value="submit" runat="server" />--%>
    </form>
</body>
</html>

