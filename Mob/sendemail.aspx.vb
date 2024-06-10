Imports System.IO
Imports System.Net
Imports System.Net.Mail

Partial Class Mob_sendemail
    Inherits System.Web.UI.Page


    Protected Sub btnSendMail_Click(sender As Object, e As EventArgs) Handles btnSendMail.Click
        ' Try
        ' Working code start
        '    Dim request As WebRequest
        '    request = WebRequest.Create("https://api.postmarkapp.com/email")
        '    Dim resp As WebResponse
        '    Dim fromAddress As String = "dharmendra.jha@netsoftit.com"
        '    Dim toAddress As String = txtEmailId.Text
        '    Dim subject As String = txtSubject.Text
        '    Dim textBody As String = txtBody.Text
        '    Dim htmlBody As String = GenerateHtmlBody(txtBody.Text)

        '    Dim requestBody As String = String.Format("{{""From"": ""{0}"", ""To"": ""{1}"", ""Subject"": ""{2}"", ""TextBody"": ""{3}"", ""HtmlBody"": ""{4}"", ""MessageStream"": ""outbound""}}", fromAddress, toAddress, subject, textBody, htmlBody)

        '    Dim data As Byte() = Encoding.UTF8.GetBytes(requestBody)


        '    request.Method = "POST"
        '    request.ContentType = "application/json"
        '    request.Headers.Add("X-Postmark-Server-Token", "27d95ef5-0e16-444d-a204-ff61108f4e8e")

        '    Dim stream As Stream = request.GetRequestStream()
        '    stream.Write(data, 0, data.Length)
        '    stream.Close()

        '    resp = request.GetResponse()
        '    Dim sr As New StreamReader(resp.GetResponseStream())

        '    If sr.ReadToEnd.IndexOf("OK") Then
        '        Response.Write("Success")
        '    Else
        '        Response.Write("Failed")
        '    End If

        'Catch ex As Exception
        '    Response.Write(ex.ToString())
        'End Try
        ' working code ends

        ' Working code
        'Try
        '    Dim client = New SmtpClient("smtp.sendgrid.net", 587) With {
        '        .Credentials = New NetworkCredential("apikey", "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"),
        '        .EnableSsl = True
        '    }

        '    client.Send("noreply@jaypeebrothers.com", "dharmendra.jha@netsoftit.com", "Test Mail From Local", "This is only for testing")
        '    Response.Write("Email Sent")
        'Catch ex As Exception
        '    Response.Write(ex.ToString())
        'End Try
        ' end working code

        Try
            Dim Mail As New MailMessage()
            'System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls


            Mail.To.Add(txtEmailId.Text)         'User Email ID

            Mail.From = New MailAddress("noreply@jaypeebrothers.com")
            Mail.Subject = txtSubject.Text
            Mail.IsBodyHtml = True
            Mail.Body = txtBody.Text
            Dim smtp As New SmtpClient("smtp.sendgrid.net")
            Dim cr As New System.Net.NetworkCredential("apikey", "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")

            smtp.Port = 587
            smtp.EnableSsl = True
            smtp.Credentials = cr
            smtp.Send(Mail)
            Response.Write("Mail Sent Successfully")
        Catch ex As Exception
            Response.Write(ex.Message.ToString())
        End Try


    End Sub
    Function GenerateHtmlBody(greeting As String) As String
        Dim html As New StringBuilder()

        html.Append("<html><body>")
        html.AppendFormat("<p>{0}</p>", greeting)
        html.Append("</body></html>")

        Return html.ToString()
    End Function

End Class
