Imports System.IO
Imports System.Net.Mail
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Configuration
Partial Class Feedback
    Inherits System.Web.UI.Page

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click

        'Dim mailBody As String = ""
        'Dim m_strFromEmail As String = ConfigurationSettings.AppSettings("strFromEmail").ToString()
        'Dim m_strFromName As String = ConfigurationSettings.AppSettings("strFromName").ToString()
        'Dim m_strToMail As String = ConfigurationSettings.AppSettings("strToMail").ToString()
        'Dim m_strToName As String = ConfigurationSettings.AppSettings("strToName").ToString()

        'mailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC'  style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;' ><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name:</td> <td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Address:<br></td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtAddress.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Organization:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtOrganization.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Contact Number:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtContactNumber.Text + "</td></tr><tr><td  width='30%' bgcolor='#FFFFFF'>Email Id:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtEmailId.Text + "</td><td colspan='2' valign='top'  width='30%' bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td valign='top'  bgcolor='#FFFFFF'>Feedback<br></td> <td valign='top'  bgcolor='#FFFFFF' colspan='3' style='height:150px;'>" + txtFeedback.Text + "</td></tr><tr> <td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>  Copyright 2007, TISS AND FMSF</div></td></tr></table></body></html>"



        'Try

        '    SendMailGodady(m_strFromName, m_strFromEmail, m_strToName, m_strToMail, m_strToMail, "", _
        '    "", "FeedBack", mailBody)
        '    'CommonUtility.SendMailGmail(m_strFromName, m_strFromEmail, "tnt", "adminsmith.david@gmail.com", m_strCCEmail, "", "", "Shipment Charge Updated ", mailBody); 

        '    'ClientScript.RegisterStartupScript(GetType(), "Message", "<SCRIPT LANGUAGE='javascript'>location.href='thankyou.htm';</script>"); 


        '    ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Submitted Successfully.');</script>")
        'Catch ex As Exception
        'Finally
        '    mailBody = ""



        'End Try
        Try

            If fnvalidate() = True Then
                Dim mailBody As String = ""
                mailBody = "<html><body><table width='80%' border='0' align='center' cellpadding='5' cellspacing='1' bgcolor='#CCCCCC'  style='font-family:Verdana, Arial, Helvetica, sans-serif; font-size:11px;' ><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Name:</td> <td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtName.Text + "</td><td valign='top' bgcolor='#FFFFFF' width='15%'>Address:<br></td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtAddress.Text + "</td></tr><tr><td valign='top' width='30%' bgcolor='#FFFFFF'>Organization:</td><td valign='top'  width='30%' bgcolor='#FFFFFF'>" + txtOrganization.Text + "</td><td  valign='top' bgcolor='#FFFFFF' width='15%'>Contact Number:</td><td valign='top'  bgcolor='#FFFFFF' width='30%'>" + txtContactNumber.Text + "</td></tr><tr><td  width='30%' bgcolor='#FFFFFF'>Email Id:</td><td valign='top' width='30%' bgcolor='#FFFFFF'>" + txtEmailId.Text + "</td><td colspan='2' valign='top'  width='30%' bgcolor='#FFFFFF'>&nbsp;</td></tr><tr><td valign='top'  bgcolor='#FFFFFF'>Feedback<br></td> <td valign='top'  bgcolor='#FFFFFF' colspan='3' style='height:150px;'>" + txtFeedback.Text + "</td></tr><tr> <td valign='middle' height='30' colspan='4' bgcolor='#cccccc' style='color:#000000'><div align='center'>  FMSF</div></td></tr></table></body></html>"

                Dim m_strFromEmail As String
                Dim m_strFromName As String = ""
                Dim m_strToMail As String
                Dim m_strToCC As String

                m_strFromEmail = txtEmailId.Text
                m_strToMail = "coordinator@fmsflearningsystems.org"
                m_strToCC = ""


                SendMailMessage("fmsf@fmsflearningsystems.org", m_strToMail, m_strToCC, "FeedBack", mailBody)

                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Feedback submitted successfully!');", True)


                txtAddress.Text = ""
                txtContactNumber.Text = ""
                txtEmailId.Text = ""
                txtFeedback.Text = ""
                txtName.Text = ""
                txtOrganization.Text = ""


            End If

        Catch ex As Exception

        End Try

    End Sub

    Function fnvalidate() As Boolean

        If Len(txtName.Text) <= 0 Then
            lblMessage.Text = "Name cannot be left blank."
            Return False
        End If

        If Len(txtEmailId.Text) <= 0 Then
            lblMessage.Text = "EmailID cannot be left blank."
            Return False
        End If
        If Len(txtContactNumber.Text) <= 0 Then
            lblMessage.Text = "Contact number cannot be left blank."
            Return False
        End If

        If Len(txtFeedback.Text) <= 0 Then
            lblMessage.Text = "Feedback cannot be left blank."
            Return False
        End If

        Return True
    End Function

    Public Function SendMailGodady(ByVal m_strFromName As String, ByVal m_strFromEmail As String, ByVal m_strToName As String, ByVal m_strToEmail As String, ByVal m_strCCEmail As String, ByVal m_strBCCEmail As String, _
ByVal m_strAttachment As String, ByVal m_strSubject As String, ByVal m_strMessage As String) As [Boolean]

        Try

            Dim SERVER As String = ConfigurationSettings.AppSettings("SMTPHost").ToString()

            Dim re As New Regex("^([\w-'\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")

            Dim oMail As New MailMessage()

            oMail.From = New MailAddress(m_strFromEmail, m_strFromName)

            If m_strToEmail <> "" Then
                Dim arr As String() = m_strToEmail.Split(","c)
                For i As Integer = 0 To arr.Length - 1
                    If arr(i).ToString() <> "" Then
                        Dim match As Match = re.Match(arr(i))
                        If Not match.Success Then
                            Return False
                        Else
                            'oMail.To.Add(m_strToEmail); 


                            oMail.[To].Add(arr(i).ToString())
                        End If
                    End If

                Next
            End If

            If m_strCCEmail <> "" Then
                Dim arr As String() = m_strCCEmail.Split(","c)
                For i As Integer = 0 To arr.Length - 1
                    If arr(i).ToString() <> "" Then
                        Dim match As Match = re.Match(arr(i))
                        If Not match.Success Then
                            Return False
                        Else
                            'oMail.To.Add(m_strToEmail); 


                            oMail.CC.Add(arr(i).ToString())
                        End If
                    End If

                Next
            End If

            If m_strBCCEmail <> "" Then
                Dim arr As String() = m_strBCCEmail.Split(","c)
                For i As Integer = 0 To arr.Length - 1
                    If arr(i).ToString() <> "" Then
                        Dim match As Match = re.Match(arr(i))
                        If Not match.Success Then
                            Return False
                        Else
                            'oMail.To.Add(m_strToEmail); 


                            oMail.Bcc.Add(arr(i).ToString())
                        End If
                    End If

                Next
            End If

            oMail.CC.Add(m_strCCEmail)

            'oMail.Bcc.Add(m_strBCCEmail); 

            oMail.Subject = m_strSubject

            oMail.IsBodyHtml = True
            ' enumeration 
            oMail.Priority = MailPriority.High
            ' enumeration 
            oMail.Body = m_strMessage

            '"<html><boby>Test email subject</body></html>"; 

            Dim Client As New SmtpClient(SERVER)
            'System.Net.NetworkCredential cr = new System.Net.NetworkCredential("contactus@anukconsulting.com", "nitindheer"); 
            'Client.Credentials = cr; 

            Client.Send(oMail)



            Return True
        Catch ex As Exception

            Return False
        Finally

        End Try
    End Function
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
            'Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net", 0)
            Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net")
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            mSmtpClient.Credentials = New System.Net.NetworkCredential(from, "fmsf@123")
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCancel.Click
        Response.Redirect("default.aspx")
    End Sub
End Class
