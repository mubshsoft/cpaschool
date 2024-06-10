Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Security.Cryptography.X509Certificates

Partial Class Mob_sendemail
    Inherits System.Web.UI.Page


    Protected Sub btnSendMail_Click(sender As Object, e As EventArgs) Handles btnSendMail.Click
        Try
            'Dim smtp As New SmtpClient
            'Dim Mail As New MailMessage
            ''System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls

            ''SmtpMail.SmtpServer.Insert(0, "smtp.jaypeebrothers.com")            
            'smtp.UseDefaultCredentials = False
            'smtp.Credentials = New System.Net.NetworkCredential("noreply@jaypeebrothers.com", "Itdom@4321")
            'smtp.Port = 587
            'smtp.EnableSsl = True
            'smtp.Host = "smtp.office365.com"

            'Mail.From = New MailAddress("noreply@jaypeebrothers.com")
            'Mail.To.Add(txtEmailId.Text)
            'Mail.Subject = txtSubject.Text
            'Mail.IsBodyHtml = True
            'Mail.Body = txtBody.Text

            'smtp.Send(Mail)
            'Response.Write("Mail Sent Successfully")

            'Dim MailMessage As New MailMessage()
            'MailMessage.From = New MailAddress("noreply@jaypeebrothers.com")
            'MailMessage.To.Add(New MailAddress("dharmendra.jha@netsoftit.com"))
            'MailMessage.Subject = "Test Subject"
            'MailMessage.Body = "Testing Office365 Email"
            'MailMessage.IsBodyHtml = True
            'Dim client As New SmtpClient()
            'client.UseDefaultCredentials = False
            'client.Credentials = New NetworkCredential("noreply@jaypeebrothers.com", "Itdom@4321")
            'client.Port = 587
            'client.Host = "smtp.office365.com"
            'client.EnableSsl = True
            'client.Send(MailMessage)



            Dim request As WebRequest
            request = WebRequest.Create("https://api.postmarkapp.com/email")
            Dim resp As WebResponse
            Dim fromAddress As String = "dharmendra.jha@netsoftit.com"
            Dim toAddress As String = txtEmailId.Text
            Dim subject As String = txtSubject.Text
            Dim textBody As String = txtBody.Text
            Dim htmlBody As String = GenerateHtmlBody(txtBody.Text)

            Dim requestBody As String = String.Format("{{""From"": ""{0}"", ""To"": ""{1}"", ""Subject"": ""{2}"", ""TextBody"": ""{3}"", ""HtmlBody"": ""{4}"", ""MessageStream"": ""outbound""}}", fromAddress, toAddress, subject, textBody, htmlBody)

            'Dim postData As String = "{""From"": """", ""To"": ""dharmendra.jha@netsoftit.com"",""Subject"": ""Hello from Postmark"",""HtmlBody"": ""<strong>Hello</strong> dear Postmark user."",""MessageStream"": ""outbound""}"
            Dim data As Byte() = Encoding.UTF8.GetBytes(requestBody)


            request.Method = "POST"
            request.ContentType = "application/json"
            request.Headers.Add("X-Postmark-Server-Token", "27d95ef5-0e16-444d-a204-ff61108f4e8e")

            Dim stream As Stream = request.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            resp = request.GetResponse()
            Dim sr As New StreamReader(resp.GetResponseStream())


            Response.Write(sr.ReadToEnd)

        Catch ex As Exception
            Response.Write(ex.ToString())
        End Try

        'Try
        '    sendemail(txtEmailId.Text, txtSubject.Text, txtBody.Text)
        'Catch ex As Exception
        '    Response.Write(ex.ToString())
        'End Try

    End Sub
    Function GenerateHtmlBody(greeting As String) As String
        Dim html As New StringBuilder()

        html.Append("<html><body>")
        html.AppendFormat("<h1>{0}</h1>", greeting)
        html.Append("</body></html>")

        Return html.ToString()
    End Function

End Class
