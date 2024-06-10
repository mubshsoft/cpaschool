Imports System.Net.Mail
Imports System.Net
Imports fmsf.lib
Partial Class Admin_ReActivateExam
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()
                FillDDl()
                'FillDDlexamset()

                MyCLS.ConClose()
               
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
    End Sub
    Private Sub FillDDlexamset()
        ''MyCLS.prcFillDDL(ddlexamset, "examset", "ExamId", "ExamCode")
        Try
            Dim strq As String = "select * from examset ex inner join activateexam ax on ex.examid = ax.examid where active = 1 And ax.bid = " & ddlBatch.SelectedValue '& " And ex.courseid=" & ddlcourse.SelectedValue
            'Dim strq As String = "select * from  examset where courseid=" & ddlcourse.SelectedValue & " and active=1 order by ExamCode"
            Dim dsexam As New DataSet()
            dsexam = CLS.fnQuerySelectDs(strq)
            If dsexam IsNot Nothing Then
                If dsexam.Tables IsNot Nothing Then
                    If dsexam.Tables(0).Rows IsNot Nothing Then
                        If dsexam.Tables(0).Rows.Count > 0 Then
                            ddlexamset.DataTextField = "ExamCode"
                            ddlexamset.DataValueField = "ExamId"
                            ddlexamset.DataSource = dsexam
                            ddlexamset.DataBind()
                            ddlexamset.Items.Insert(0, "--Select--")


                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub FillDDlbatch(ByVal id As Integer)
        Try
            ' Dim strq As String = "select distinct(bt.BatchCode),ae.bid from StudentActiveExam ae INNER JOIN batch bt on ae.bid=bt.bid where ae.ExamId=" & id
            Dim strq As String = "select b.bid,b.courseID,c.CourseTitle,b.BatchCode from batch b INNER JOIN course c on b.courseID=c.CourseID where b.courseID=" & ddlcourse.SelectedValue & " order by b.bid desc"
            Dim dsBatch As New DataSet()
            dsBatch = CLS.fnQuerySelectDs(strq)
            If dsBatch IsNot Nothing Then
                If dsBatch.Tables IsNot Nothing Then
                    If dsBatch.Tables(0).Rows IsNot Nothing Then

                        ddlBatch.DataTextField = "BatchCode"
                        ddlBatch.DataValueField = "bid"
                        ddlBatch.DataSource = dsBatch
                        ddlBatch.DataBind()
                        ddlBatch.Items.Insert(0, "--Select--")
                        lblBatchCode.Visible = True
                        ddlBatch.Visible = True
                        If dsBatch.Tables(0).Rows.Count = 0 Then
                            GrdStudent.Visible = False
                            lblMessage.Text = "No Batch for this Exam Set"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddlexamset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlexamset.SelectedIndexChanged
        bindgrid()
    End Sub

    Sub bindgrid()
        Try
            Dim strq As String = "select distinct ae.id,ae.ExamId,ae.bid,ae.UserId,ae.Activate,CONVERT(CHAR(8),ae.activateDate-ae.endexamtime,108) as timetaken,ae.endexamtime,ae.ActivateDate,s.FirstName +' ' +s.middlename+' '+s.lastname as stuname,bt.BatchCode from StudentActiveExam ae INNER JOIN batch bt on ae.bid=bt.bid INNER JOIN student s on ae.UserId=s.email where ae.ExamId=" & ddlexamset.SelectedValue & " and ae.bid=" & ddlBatch.SelectedValue & " and ae.Activate=1"
            Dim dsStudent As New DataSet()
            dsStudent = CLS.fnQuerySelectDs(strq)
            If dsStudent IsNot Nothing Then
                If dsStudent.Tables IsNot Nothing Then
                    If dsStudent.Tables(0).Rows IsNot Nothing Then
                        If dsStudent.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsStudent
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        Else
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        FillDDlexamset()

    End Sub

    Protected Sub GrdStudent_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdStudent.RowCommand
        
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

    Protected Sub GrdStudent_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GrdStudent.RowUpdating

        Dim strBody As String = ""
        Dim stid As Integer
        Dim strFrom As String = ConfigurationSettings.AppSettings("Admin").Split(New Char() {";"c})(0)
        Dim idd As Integer = e.RowIndex

        Dim lbl As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblId"), Label)
        Dim lblname As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblname"), Label)
        Dim lblUserId As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblUserId"), Label)
        Dim lblExamId As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblExamId"), Label)
        Dim hdnBatchCode As HiddenField = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("hdnBatchCode"), HiddenField)

        strBody = CommonUtility.prcFindInFile(HttpContext.Current.Server.MapPath("MailFormats/") + "ReactivateExam.htm", "#Name#", lblname.Text)
        strBody = CommonUtility.prcFindInString(strBody, "#Course#", ddlcourse.SelectedItem.Text)
        strBody = CommonUtility.prcFindInString(strBody, "#Batch#", hdnBatchCode.Value)
        strBody = CommonUtility.prcFindInString(strBody, "#email#", lblUserId.Text)


        Dim str As String = "update StudentActiveExam set Activate=0 where id=" & Convert.ToInt32(lbl.Text)
        ExeNQcomsp(str)

        Try
            Dim strq As String = "select stid from Student where email='" & lblUserId.Text & "'"
            Dim dsStid As New DataSet()
            dsStid = CLS.fnQuerySelectDs(strq)
            stid = CInt(dsStid.Tables(0).Rows(0)("stid").ToString())

        Catch ex As Exception
        End Try


        Dim Notifications As String = "insert into Notifications(Subject,Body,SendFrom,Stid,emailto)values('Exam Re-activated','" & strBody & "','" & strFrom & "'," & stid & ",'" & lblUserId.Text & "')"
        ExeNQcomsp(Notifications)

        CommonUtility.SendMail(ConfigurationSettings.AppSettings("Admin").Split(New Char() {";"c})(0), ConfigurationSettings.AppSettings("Admin").Split(New Char() {";"c})(1), lblUserId.Text, "", "", "", "Exam Re-activated for batch - " + hdnBatchCode.Value, strBody)
        bindgrid()
    End Sub

    Public Sub SendMailMessage(ByVal from As String, ByVal recepient As String, ByVal mailCC As String, ByVal subject As String, ByVal body As String)
        Try
            'Dim smtp As SmtpClient = New SmtpClient("sg2nlvphout-v01.shr.prod.sin2.secureserver.net")
            Dim smtp As SmtpClient = New SmtpClient("smtpout.secureserver.net")
            Dim myfromAddress As String = from
            Dim appSpecificPassword As String = "fmsf@123"

            'smtp.EnableSsl = true;
            smtp.Port = 25
            smtp.Credentials = New NetworkCredential(myfromAddress, appSpecificPassword)

            Dim message As MailMessage = New MailMessage()
            message.Sender = New MailAddress(myfromAddress, "")
            message.From = New MailAddress(myfromAddress, "")

            message.To.Add(New MailAddress(recepient, ""))


            message.Subject = subject
            message.Body = body

            message.IsBodyHtml = True
            smtp.Send(message)
            Response.Write("Email Sent")
        Catch ex As Exception
            Response.Write("Error: " + ex.Message.ToString())
            'lblmsg.Text = ex.Message.ToString()
        End Try

    End Sub
    Protected Sub GrdStudent_RowDelitinging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdStudent.RowDeleting

        Dim idd As Integer = e.RowIndex

        Dim lbl As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblId"), Label)
        Dim usid As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblUserId"), Label)
        Dim exid As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblExamId"), Label)
        Dim str1 As String = "delete from ques_answers  where UserId='" & usid.Text & "' and ExamId=" & Convert.ToInt32(exid.Text)
        Dim str2 As String = "delete from Subques_answers where UserId='" & usid.Text & "' and ExamId=" & Convert.ToInt32(exid.Text)

        ExeNQcomsp(str1)
        ExeNQcomsp(str2)
        bindgrid()
    End Sub

    Protected Sub GrdStudent_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdStudent.PageIndexChanging
        GrdStudent.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ExamPanel.aspx")
    End Sub

    Protected Sub ddlcourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcourse.SelectedIndexChanged
        'FillDDlbatch(ddlexamset.SelectedValue)
        FillDDlbatch(ddlcourse.SelectedValue)
    End Sub


End Class
