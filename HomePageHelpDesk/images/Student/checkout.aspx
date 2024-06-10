<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checkout.aspx.cs" Inherits="Student_checkout" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Jaypee Journals | Sub-merchant checkout page</title>
   <script type="text/javascript">
        function aa()
        {
            document.frm1.submit();
        }
    </script>
</head>
<body onload="aa();">
    <form name="frm1" id="frm1" method="post" action="https://www.ccavenue.com/shopzone/cc_details.jsp">
       

        
        <input id="Merchant_Id" type="hidden" name="Merchant_Id" runat="server" />
        <input id="Amount" type="hidden" name="Amount" runat="server" />
        <input id="Order_Id" type="hidden" name="Order_Id" runat="server" />
        <input id="Redirect_Url" type="hidden" name="Redirect_Url" runat="server" />
        <input id="Checksum" type="hidden" name="Checksum" runat="server" />
        <input id="billing_cust_name" type="hidden" name="billing_cust_name" runat="server" />
        <input id="billing_cust_address" type="hidden" name="billing_cust_address" runat="server" />
        <input id="billing_cust_state" type="hidden" name="billing_cust_state" runat="server" />
        <input id="billing_cust_country" type="hidden" name="billing_cust_country" runat="server" />
        <input id="billing_cust_city" type="hidden" name="billing_cust_city" runat="server" />
        <input id="billing_zip_code" type="hidden" name="billing_zip_code" runat="server" />
        <input id="billing_cust_tel" type="hidden" name="billing_cust_tel" runat="server" />
        <input id="billing_cust_email" type="hidden" name="billing_cust_email" runat="server" />
        <input id="billing_cust_notes" type="hidden" name="billing_cust_notes" runat="server" />
        <input id="delivery_cust_name" type="hidden" name="delivery_cust_name" runat="server" />
        <input id="delivery_cust_address" type="hidden" name="delivery_cust_address" runat="server" />
        <input id="delivery_cust_state" type="hidden" name="delivery_cust_state" runat="server" />
        <input id="delivery_cust_country" type="hidden" name="delivery_cust_country" runat="server" />
        <input id="delivery_cust_tel" type="hidden" name="delivery_cust_tel" runat="server" />
        <input id="delivery_cust_notes" type="hidden" name="delivery_cust_notes" runat="server" />
        <input id="Merchant_Param" type="hidden" name="Merchant_Param" runat="server" />        
        <input id="delivery_cust_city" type="hidden" name="delivery_cust_city" runat="server" />
        <input id="delivery_zip_code" type="hidden" name="delivery_zip_code" runat="server" />

        <%--<input type="submit" value="submit" runat="server" />--%>
    </form>
</body>
</html>

