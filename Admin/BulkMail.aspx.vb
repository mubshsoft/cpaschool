Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.IO
Partial Class Admin_BulkMail
    Inherits System.Web.UI.Page
    Dim st As String = ""
    Dim st1 As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
            'Else
            '    If Session("role") = "Admin" Then
            '    Else
            '        Response.Redirect("../login.aspx")
            '    End If
        End If
        If Not IsPostBack Then
            MyCLS.ConOpen()
            'BindFeeStatus()
            FillDDl()

            MyCLS.ConClose()
        End If
        If Request.QueryString("facmail") IsNot Nothing Then
            lnk.InnerText = "faculty Panel"
        End If

    End Sub
    'Sub BindFeeStatus()
    '    Dim strq As String = "select distinct(Status) from FeeStatus order by Status desc"
    '    Dim ds As New DataSet()
    '    ds = CLS.fnQuerySelectDs(strq)
    '    'Dim a As String = ReplaceStatus(ds.Tables(0).Rows(0)("Status").ToString())
    '    dllFeeStatus.DataTextField = "Status"
    '    'dllFeeStatus.DataValueField = "StFeeId"
    '    dllFeeStatus.DataSource = ds
    '    dllFeeStatus.DataBind()


    'End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlBatch, "batch", "bid", "BatchCode")
    End Sub
    Function ReplaceStatus(ByVal val As Boolean) As String
        Dim value As String
        If val = False Then
            value = "Inactive"
        Else
            value = "Active"
        End If
        ReplaceStatus = value
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim SendFrom As String = ""
            'If Request.QueryString("facmail") IsNot Nothing Then
            '    SendFrom = Session("username")
            'Else
            '    SendFrom = "test@fmsf.com"
            'End If


            SendFrom = "coordinator@fmsflearningsystems.org"

            If Request.QueryString("facmail") IsNot Nothing Then
                SendMailMessage(SendFrom, ViewState("StMail"), txtSubject.Text, MailText())
                'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Message has been sent successfully'); location.href='../faculty/Facultypanel.aspx' ;</script>")
                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Message has been sent successfully'); location.href='../faculty/Facultypanel.aspx' ;", True)
            Else
                SendMailMessage(SendFrom, ViewState("StMail"), txtSubject.Text, MailText())
                'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Message has been sent successfully'); location.href='BulkMail.aspx' ;</script>")
                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Message has been sent successfully'); location.href='BulkMail.aspx' ;", True)
            End If



        Catch ex As Exception

        End Try
    End Sub
    'Public Shared Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal subject As String, ByVal body As String)
    '    Try


    '        Dim mMailMessage As New MailMessage()
    '        mMailMessage.From = New MailAddress(from)
    '        mMailMessage.To.Add(New MailAddress(recepient))

    '        mMailMessage.Subject = subject
    '        mMailMessage.Body = body
    '        mMailMessage.IsBodyHtml = True
    '        mMailMessage.Priority = MailPriority.Normal
    '        'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
    '        Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net", 0)
    '        mSmtpClient.Send(mMailMessage)
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Public Shared Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal subject As String, ByVal body As String)
        Try
            Dim mMailMessage As New MailMessage()
            mMailMessage.From = New MailAddress(from)
            mMailMessage.To.Add(New MailAddress(recepient))

            mMailMessage.Subject = subject
            mMailMessage.Body = body
            mMailMessage.IsBodyHtml = True
            mMailMessage.Priority = MailPriority.Normal

            Dim toAddressArray As String()
            toAddressArray = recepient.ToString().Split(New Char() {","c})
            For Each a As String In toAddressArray

                'mMailMessage.To.Add(new MailAddress(a));
                mMailMessage.Bcc.Add(New MailAddress(a))
            Next
            mMailMessage.To.Add(New MailAddress("fmsf@fmsflearningsystems.org"))
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net")
            mSmtpClient.Credentials = New System.Net.NetworkCredential(from, "fmsf@123")
            mSmtpClient.Send(mMailMessage)
        Catch ex As Exception

        End Try
    End Sub
    Public Function MailText() As String
        Dim Text As String = ""
        Text = "<html>" & _
                      "<body>" & _
                      "<div align='center'>" & _
                      " <table border='0' cellpadding='0' cellspacing='0' >" & _
                      "<tr><td align='center' class='sec4'> </td></tr>" & _
                      "<tr>" & _
                        "<td align='center' class='sec4'>" & _
                          "<table width='300' border='1' cellpadding='0' cellspacing='0'>" & _
                          "<tr><td colspan='3' class='sec4'>Message from " & Session("username") & "</td></tr>" & _
                            "<tr align='left'><td width='10%'><strong><span style='font-family: Tahoma; font-size: 10px; color: #5d5d5c; font-weight: bold;'>&nbsp;</span> </strong></td> <td width='70%'> <span id='ctl00_ContentPlaceItem_lblorderid' style='font-family: Tahoma; font-size: 10px;color: #5d5d5c;'>" & txtMessage.Text & "</span> </td> <td width='10%'>&nbsp;</td></tr> " & _
                            "</table>" & _
                        "<td>" & _
                      "<table>" & _
                      "</div>" & _
                      "</body>" & _
                   "</html>"
        Return Text
    End Function



    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        Dim strCourse As String = "select st.email from batch bt INNER JOIN studentRegCourse sr on bt.courseID=sr.courseid INNER JOIN Student st on sr.stid=st.stid where bt.BatchCode='" & ddlBatch.SelectedItem.Text & "' "
        Dim dsbatch As New DataSet()
        dsbatch = CLS.fnQuerySelectDs(strCourse)

        If dsbatch.Tables(0).Rows.Count > 0 Then
            For i = 0 To dsbatch.Tables(0).Rows.Count - 1
                st = dsbatch.Tables(0).Rows(i)("email").ToString

                st1 += st.ToString() & ","

            Next i

        End If
        Dim ss As String
        ss = st1.Remove(st1.Length - 1)
        ViewState("StMail") = ss
    End Sub
End Class
