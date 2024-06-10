Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.Mail
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Net.Configuration
Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Partial Class Admin_ReminderMail
    Inherits System.Web.UI.Page
    Dim stid As String = ""
    Dim stid1 As String = ""
    Dim st As String = ""
    Dim st1 As String = ""
    Dim strEmail As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")

            End If
            If Not IsPostBack Then
                trRow1.Visible = False
                MyCLS.ConOpen()
                FillDDl()

                MyCLS.ConClose()
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub FillDDl()
        Try
            MyCLS.ConOpen()
            MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
            MyCLS.ConClose()
        Catch ex As Exception
        End Try
    End Sub
   

    Private Sub FillBatch()
        Try

       
            Dim strBatch As String = "select distinct(b.BatchCode),bt.bid from batch b INNER JOIN StudentRegBatch bt on b.bid=bt.bid where bt.courseid=" & ddlCourse.SelectedValue
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strBatch)
            ddlBatch.DataSource = dsbatch
            ddlBatch.DataTextField = "BatchCode"
            ddlBatch.DataValueField = "bid"
            ddlBatch.DataBind()
            ddlBatch.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Fillsemester()
        Try

     
            Dim strSem As String = "select distinct(s.semestertitle),ss.semid from StudentSemester ss INNER JOIN Semester s on ss.semid=s.semid INNER JOIN StudentRegCourse sr on sr.courseid=ss.courseid INNER JOIN StudentRegBatch bt on bt.courseid=sr.courseid where bt.bid=" & ddlBatch.SelectedValue
            Dim dsSem As New DataSet()
            dsSem = CLS.fnQuerySelectDs(strSem)
            ddlSemester.DataSource = dsSem
            ddlSemester.DataTextField = "semestertitle"
            ddlSemester.DataValueField = "semid"
            ddlSemester.DataBind()
            ddlSemester.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillStudent()
        Try


            Dim strStudent As String = "select distinct ss.stid,st.email,ss.semid,ss.courseid from StudentSemester ss INNER JOIN student st on ss.stid=st.stid INNER JOIN StudentRegCourse sr on sr.stid=st.stid INNER JOIN StudentRegBatch bt on bt.stid=sr.stid where currentStatus=2 and ss.semid=" & ddlSemester.SelectedValue & " and bt.bid=" & ddlBatch.SelectedValue
            'Dim strStudent As String = "select student.email,student.stid,StudentSemester.semid, StudentSemester.courseid  from StudentSemester join student on  StudentSemester.stid=student.stid  where currentStatus = 2 And semid = " & ddlSemester.SelectedValue
            Dim dsStd As New DataSet()
            dsStd = CLS.fnQuerySelectDs(strStudent)
            ddlStd.DataSource = dsStd
            ddlStd.DataTextField = "email"
            ddlStd.DataValueField = "stid"
            ddlStd.DataBind()
            ddlStd.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try

            'If ddlCourse.SelectedItem.Text = "SELECT" Then
            '    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('PLZ Select Sourse');", True)
            '    Exit Sub
            'ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedItem.Text = "--Select--" And ddlSemester.SelectedIndex = -1 And ddlStd.SelectedIndex = -1 Then

            '    strEmail = "select sr.courseid,st.stid,st.email from StudentRegCourse sr Inner join student st on st.stid=sr.stid where sr.courseid=" & ddlCourse.SelectedValue
            'ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedItem.Text = "--Select--" And ddlStd.SelectedIndex = -1 Then
            '    strEmail = "select bt.bid,bt.stid,st.firstname,st.lastname,st.email,bt.courseid from StudentRegBatch bt INNER JOIN Student st on bt.stid=st.stid INNER JOIN batch b on bt.bid=b.bid where bt.bid=" & ddlBatch.SelectedValue
            'ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedIndex <> 0 And ddlStd.SelectedItem.Text = "--Select--" Then
            '    strEmail = "select ss.stid,st.email,ss.semid,ss.courseid from StudentSemester ss INNER JOIN student st on ss.stid=st.stid INNER JOIN StudentRegCourse sr on sr.stid=st.stid INNER JOIN StudentRegBatch bt on bt.stid=sr.stid where currentStatus=2 and ss.semid=" & ddlSemester.SelectedValue
            'ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedIndex <> 0 And ddlStd.SelectedIndex <> 0 Then
            '    strEmail = "select ss.stid,st.email,ss.semid,ss.courseid from StudentSemester ss INNER JOIN student st on ss.stid=st.stid INNER JOIN StudentRegCourse sr on sr.stid=st.stid INNER JOIN StudentRegBatch bt on bt.stid=sr.stid where currentStatus=2 and ss.semid=" & ddlSemester.SelectedValue & " and ss.stid=" & ddlStd.SelectedValue & ""
            'Else
            '    Exit Sub
            'End If


            If ddlCourse.SelectedItem.Text = "SELECT" Then
                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('PLZ Select Sourse');", True)
                Exit Sub
            ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedItem.Text = "--Select--" Then

                strEmail = "select sr.courseid,st.stid,st.email from StudentRegCourse sr Inner join student st on st.stid=sr.stid where sr.courseid=" & ddlCourse.SelectedValue
            ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedItem.Text = "--Select--" Then
                strEmail = "select bt.bid,bt.stid,st.firstname,st.lastname,st.email,bt.courseid from StudentRegBatch bt INNER JOIN Student st on bt.stid=st.stid INNER JOIN batch b on bt.bid=b.bid where bt.bid=" & ddlBatch.SelectedValue
            ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedIndex <> 0 And ddlStd.SelectedItem.Text = "--Select--" Then
                strEmail = "select distinct ss.stid,st.email,ss.semid,ss.courseid from StudentSemester ss INNER JOIN student st on ss.stid=st.stid INNER JOIN StudentRegCourse sr on sr.stid=st.stid INNER JOIN StudentRegBatch bt on bt.stid=sr.stid where currentStatus=2 and ss.semid=" & ddlSemester.SelectedValue & " and bt.bid=" & ddlBatch.SelectedValue
            ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedIndex <> 0 And ddlStd.SelectedIndex <> 0 Then
                strEmail = "select ss.stid,st.email,ss.semid,ss.courseid from StudentSemester ss INNER JOIN student st on ss.stid=st.stid INNER JOIN StudentRegCourse sr on sr.stid=st.stid INNER JOIN StudentRegBatch bt on bt.stid=sr.stid where currentStatus=2 and ss.semid=" & ddlSemester.SelectedValue & " and ss.stid=" & ddlStd.SelectedValue & ""
            End If
        Catch ex As Exception

        End Try
        Dim ds As New DataSet()
        ds = CLS.fnQuerySelectDs(strEmail)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                st = ds.Tables(0).Rows(i)("email").ToString
                st1 += st.ToString() & ","


                stid = ds.Tables(0).Rows(i)("stid").ToString().Trim()  ' Added by wahid for mass mails in database (10-10-2020)
                If (stid1.Contains(stid)) Then
                Else
                    stid1 += stid.ToString() & ","
                End If

            Next i

        End If
        Dim ss As String
        ss = st1.Remove(st1.Length - 1)
        ViewState("StMail") = ss

        Dim studentid As String
        studentid = stid1.Remove(stid1.Length - 1)

        Dim strReminder As String = ""
        Dim strFrom As String = ConfigurationSettings.AppSettings("Admin").Split(New Char() {";"c})(0)
        strReminder = "insert into mails(Subject,Body,SendFrom,stid,MailType)values('" & txtSubject.Text & "','" & txtreply.Text & "','" & strFrom & "','" & studentid & "','Mass Mail')"

        ExeNQcomsp(strReminder)

        Try
            Dim SendFrom As String = ""

            SendFrom = "coordinator@fmsflearningsystems.org"

            'SendMailMessage(SendFrom, ViewState("StMail"), txtSubject.Text, txtreply.Text)

            Dim fn As String = ""
            Dim strpath As String = ""
            If Not Fupd.PostedFile Is Nothing And Fupd.PostedFile.ContentLength > 0 Then

                fn = System.IO.Path.GetFileName(Fupd.PostedFile.FileName)
                Try

                    strpath = Server.MapPath("../") & "student/BulkMailFiles/" & fn
                    If File.Exists(strpath) Then
                        lblMessage.Text = "File already exists."
                        lblMessage.ForeColor = Drawing.Color.Red
                        Exit Sub
                    Else
                        Fupd.PostedFile.SaveAs(strpath)
                    End If
                Catch ex As Exception
                End Try
            End If





            'If ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedItem.Text = "--Select--" Then
            '    strReminder = "insert into mails(Subject,Body,SendFrom,CourseId,MailType)values('" & txtSubject.Text & "','" & txtreply.Text & "','" & strFrom & "','" & ddlCourse.SelectedValue & "','Mass Mail')"
            'ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedItem.Text = "--Select--" Then
            '    strReminder = "insert into mails(Subject,Body,SendFrom,CourseId,bid,MailType)values('" & txtSubject.Text & "','" & txtreply.Text & "','" & strFrom & "','" & ddlCourse.SelectedValue & "','" & ddlBatch.SelectedValue & "','Mass Mail')"
            'ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedIndex <> 0 And ddlStd.SelectedItem.Text = "--Select--" Then
            '    strReminder = "insert into mails(Subject,Body,SendFrom,CourseId,bid,SemesterId,MailType)values('" & txtSubject.Text & "','" & txtreply.Text & "','" & strFrom & "','" & ddlCourse.SelectedValue & "','" & ddlBatch.SelectedValue & "','" & ddlSemester.SelectedValue & "','Mass Mail')"
            'ElseIf ddlCourse.SelectedIndex <> 0 And ddlBatch.SelectedIndex <> 0 And ddlSemester.SelectedIndex <> 0 And ddlStd.SelectedIndex <> 0 Then
            '    strReminder = "insert into mails(Subject,Body,SendFrom,CourseId,bid,SemesterId,stid,MailType)values('" & txtSubject.Text & "','" & txtreply.Text & "','" & strFrom & "','" & ddlCourse.SelectedValue & "','" & ddlBatch.SelectedValue & "','" & ddlSemester.SelectedValue & "','" & ddlStd.SelectedValue & "','Mass Mail')"
            'End If



            CommonUtility.SendMail(ConfigurationSettings.AppSettings("Admin").Split(New Char() {";"c})(0), ConfigurationSettings.AppSettings("Admin").Split(New Char() {";"c})(1), ViewState("StMail"), "", "", strpath, txtSubject.Text, txtreply.Text)
            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Message has been sent successfully'); location.href='BulkMail.aspx' ;</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Message has been sent successfully');", True)
            lblMessage.Text = "Message has been sent successfully"

        Catch ex As Exception

        End Try
    End Sub
    Public Shared Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal subject As String, ByVal body As String)
        Try


            Dim mMailMessage As New MailMessage()
            mMailMessage.From = New MailAddress(from)
            'mMailMessage.To.Add(New MailAddress(recepient))

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
            'mMailMessage.Bcc.Add(New MailAddress("massmail@fmsflearningsystems.org"))
            'Dim mSmtpClient As New SmtpClient("smtpout.secureserver.net")
            Dim mSmtpClient As New SmtpClient("relay-hosting.secureserver.net")
            mSmtpClient.Credentials = New System.Net.NetworkCredential(from, "fmsf@123")
            mSmtpClient.Send(mMailMessage)

        Catch ex As Exception

        End Try
    End Sub

    Public Function MailText() As String
        Dim Text As String = ""
        Try

            Text = "<html>" & _
                          "<body>" & _
                          "<div align='center'>" & _
                          " <table border='0' cellpadding='0' cellspacing='0' >" & _
                          "<tr><td align='center' class='sec4'> </td></tr>" & _
                          "<tr>" & _
                            "<td align='center' class='sec4'>" & _
                              "<table width='300' border='0' cellpadding='0' cellspacing='0'>" & _
                              "<tr>" & _
                                "<tr align='left'><td width='10%'><strong><span style='font-family: Tahoma; font-size: 10px; color: #5d5d5c; font-weight: bold;'>&nbsp;</span> </strong></td> <td width='70%'> <span id='ctl00_ContentPlaceItem_lblorderid' style='font-family: Tahoma; font-size: 10px;color: #5d5d5c;'>" & txtreply.Text & "</span> </td> <td width='10%'>&nbsp;</td></tr> " & _
                             "<tr>" & _
                              "</table>" & _
                            "<td>" & _
                          "<table>" & _
                          "</div>" & _
                          "</body>" & _
                       "</html>"
        Catch ex As Exception
        End Try
        Return Text
    End Function



    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        Try
            Fillsemester()
            If ddlBatch.SelectedItem.Text = "--Select--" Then
                ddlSemester.SelectedIndex = 0
                ddlStd.SelectedIndex = 0
            End If
            If ddlSemester.Items.Count > 0 Then
                ddlSemester.SelectedIndex = 0
            End If
            If ddlStd.Items.Count > 0 Then
                ddlStd.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        Try
            FillBatch()

            If ddlCourse.SelectedItem.Text = "--Select--" Then
                ddlBatch.SelectedIndex = 0
            End If
          
            If ddlBatch.Items.Count > 0 Then
                ddlBatch.SelectedIndex = 0
            End If
            If ddlSemester.Items.Count > 0 Then
                ddlSemester.SelectedIndex = 0
            End If
            If ddlStd.Items.Count > 0 Then
                ddlStd.SelectedIndex = 0
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
        Try
            FillStudent()

            If ddlSemester.SelectedItem.Text = "--Select--" Then
                ddlStd.SelectedIndex = 0
            End If

            If ddlStd.Items.Count > 0 Then
                ddlStd.SelectedIndex = 0
            End If

        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub ExeNQcomsp(ByVal strQ As String)

        Try

            CLS.ConOpen()
            CLS.fnExecuteQuery(strQ)
            CLS.ConClose()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Response.Redirect("adminlogin.aspx")
    End Sub
End Class
