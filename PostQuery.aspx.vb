Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Configuration
Partial Class PostQuery
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Try


            Dim mailBody As String = ""
            mailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC'  style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;' ><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name:</td> <td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Contact No:<br></td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtContactNumber.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Address:</td><td colspan='3' valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtAddress.Text + "</td></tr><tr><td  width='30%' bgcolor='#FFFFFF'>Email Id:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtEmailId.Text + "</td><td colspan='2' valign='top'  width='30%' bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td valign='top'  bgcolor='#FFFFFF'>Feedback<br></td> <td valign='top'  bgcolor='#FFFFFF' colspan='3' style='height:150px;'>" + txtQuery.Text + "</td></tr><tr> <td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>  Copyright 2007, FMSF</div></td></tr></table></body></html>"

            Dim m_strFromEmail As String
            Dim m_strFromName As String = ""
            Dim m_strToMail As String
            Dim m_strToCC As String

            m_strFromEmail = "fmsf@fmsflearningsystems.org"
            m_strToMail = "coordinator@fmsflearningsystems.org"



            SendMailMessage(m_strFromEmail, m_strToMail, "", "Post Query", mailBody)

            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Query submitted successfully!');", True)


            txtAddress.Text = ""
            txtContactNumber.Text = ""
            txtEmailId.Text = ""
            txtQuery.Text = ""
            txtName.Text = ""





        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal mailCC As String, ByVal subject As String, ByVal body As String)
        Try


            Dim mMailMessage As New MailMessage()
            mMailMessage.From = New MailAddress(from)
            mMailMessage.To.Add(New MailAddress(recepient))
            If (mailCC IsNot Nothing) AndAlso (mailCC <> String.Empty) Then

                mMailMessage.CC.Add(New MailAddress(mailCC))
            End If
            mMailMessage.Subject = subject
            mMailMessage.Body = body
            mMailMessage.IsBodyHtml = True
            mMailMessage.Priority = MailPriority.Normal
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            ' Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net")
            Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net")
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            mSmtpClient.Credentials = New System.Net.NetworkCredential(from, "fmsf@123")
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        Response.Redirect("Default-new.aspx")
    End Sub
    'Function fnvalidate() As Boolean

    '    If Len(txtName.Text) <= 0 Then
    '        lblMessage.Text = "Name cannot be left blank."
    '        Return False
    '    End If

    '    If Len(txtEmailId.Text) <= 0 Then
    '        lblMessage.Text = "EmailID cannot be left blank."
    '        Return False
    '    End If
    '    If Len(txtContactNumber.Text) <= 0 Then
    '        lblMessage.Text = "Contact number cannot be left blank."
    '        Return False
    '    End If

    '    If Len(txtQuery.Text) <= 0 Then
    '        lblMessage.Text = "Feedback cannot be left blank."
    '        Return False
    '    End If

    '    Return True
    'End Function
End Class
