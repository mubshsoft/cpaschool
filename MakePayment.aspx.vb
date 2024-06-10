Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Imports System.Security.Cryptography

Partial Class MakePayment
    Inherits System.Web.UI.Page
    Dim order_id As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Function CreateToken(ByVal message As String, ByVal secret As String) As String
        secret = If(secret, "")
        Dim encoding = New System.Text.ASCIIEncoding()
        Dim keyByte As Byte() = encoding.GetBytes(secret)
        Dim messageBytes As Byte() = encoding.GetBytes(message)

        Using hmacsha256 = New HMACSHA256(keyByte)
            Dim hashmessage As Byte() = hmacsha256.ComputeHash(messageBytes)
            Return Convert.ToBase64String(hashmessage)
        End Using
    End Function

    Private Sub btnCheckout_Click(sender As Object, e As EventArgs) Handles btnCheckout.Click
        Dim random_number As New Random()
        order_id = "Web-" + random_number.Next(1, 100000000).ToString()

        ' ---------------- Test -----------------------------------------
        'Dim secret As String = "80dc2e137a5608fdcafec2d58c6ab346bf9e5026"
        'Dim Merchantkey As String = "1875284d98f0296293691638a1825781"
        'Dim returnUrl As String = "http://localhost:50126/PaymentResponse.aspx"
        'Dim endURL As String = "https://test.cashfree.com/billpay/checkout/post/submit"
        ' ---------------------------------------------------------------

        '------------------------- Prod ---------------------------------
        Dim secret As String = "4592379f1d8d98c35eaea11b170413f5213a1d15"
        Dim Merchantkey As String = "235875de645c4eb701d54edf1f578532"
        Dim returnUrl As String = "https://www.cpaschooloflearning.org/PaymentResponse.aspx"
        Dim endURL As String = "https://www.cashfree.com/checkout/post/submit"
        '----------------------------------------------------------------

        Dim data As String = ""
        Dim formParams As SortedDictionary(Of String, String) = New SortedDictionary(Of String, String)()
        formParams.Add("appId", Merchantkey)
        formParams.Add("orderId", order_id)
        formParams.Add("orderAmount", txtAmount.Text)
        formParams.Add("customerName", txtName.Text)
        formParams.Add("customerPhone", txtMobileNumber.Text)
        formParams.Add("customerEmail", txtEmail.Text)
        formParams.Add("returnUrl", returnUrl)

        For Each kvp In formParams
            data = data & kvp.Key & kvp.Value
        Next

        Dim signature As String = CreateToken(data, secret)
        Console.Write(signature)
        Dim outputHTML As String = "<html>"
        outputHTML += "<head>"
        outputHTML += "<title>Merchant Check Out Page</title>"
        outputHTML += "</head>"
        outputHTML += "<body>"
        outputHTML += "<center>Please do not refresh this page...</center>"
        outputHTML += "<form id='redirectForm' method='post' action='" & endURL & "'>"
        outputHTML += "<input type='hidden' name='appId' value='" & Merchantkey & "'/>"
        outputHTML += "<input type='hidden' name='orderId' value='" & order_id & "'/>"
        outputHTML += "<input type='hidden' name='orderAmount' value='" & txtAmount.Text & "'/>"
        outputHTML += "<input type='hidden' name='customerName' value='" & txtName.Text & "'/>"
        outputHTML += "<input type='hidden' name='customerEmail' value='" & txtEmail.Text & "'/>"
        outputHTML += "<input type='hidden' name='customerPhone' value='" & txtMobileNumber.Text & "'/>"
        outputHTML += "<input type='hidden' name='returnUrl' value='" & returnUrl & "'/>"
        outputHTML += "<input type='hidden' name='signature' value='" & signature & "'/>"
        outputHTML += "<table border='1'>"
        outputHTML += "<tbody>"

        For Each keys As String In formParams.Keys
            outputHTML += "<input type='hidden' name='" & keys & "' value='" & formParams(keys) & "'>"
        Next

        outputHTML += "</tbody>"
        outputHTML += "</table>"
        outputHTML += "<script type='text/javascript'>"
        outputHTML += "document.getElementById('redirectForm').submit();"
        outputHTML += "</script>"
        outputHTML += "</form>"
        outputHTML += "</body>"
        outputHTML += "</html>"
        Response.Write(outputHTML)
    End Sub
End Class
