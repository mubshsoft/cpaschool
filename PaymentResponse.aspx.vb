Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Class PaymentResponse
    Inherits System.Web.UI.Page

    Private Sub PaymentResponse_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim parameters As Dictionary(Of String, String) = New Dictionary(Of String, String)()

        For Each key As String In Request.Form.Keys
            parameters.Add(key.Trim(), Request.Form(key).Trim())
        Next
        Dim paymentStatus As String = "Invalid"
        Dim paymode As String = "N/A"
        Dim txnId As String = "N/A"
        If parameters.Count() > 1 Then
            paymentStatus = parameters("txStatus")
            paymode = parameters("paymentMode")
            txnId = parameters("orderId")
        End If

        pTxnId.InnerText = "Transaction Id : " & txnId
        h1Message.InnerText = "Your payment is " & paymentStatus
        pMode.InnerText = "Payment Mode : " & paymode
    End Sub
End Class
