Imports fmsf.lib
Imports fmsf.DAL


Partial Class Admin_AdminListExamSets
    Inherits System.Web.UI.Page
    Dim batchcode As Integer
    Dim dsdate As New DataSet()
    Dim Deac As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Len(Session("username")) <= 0 Then
        '    Response.Redirect("../login.aspx")
        'Else
        '    If Session("username") = "admin" Then
        '    Else
        '        Response.Redirect("../login.aspx")
        '    End If
        'End If
        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()
                ViewState("chk") = 1
                FillDDl()
                If Len(Request.QueryString("exid")) > 0 Then
                    bindUserList()
                End If
                MyCLS.ConClose()
            End If

        Catch ex As Exception
        End Try
        batchcode = Request.QueryString("batchid")
    End Sub
    Private Sub FillDDl()
        ' MyCLS.ConOpen()
        'MyCLS.prcFillDDL(ddlListExamSet, "Activateexam", "Examcode", "ExamId", "BID", Request.QueryString("batchid"))
        'MyCLS.ConClose()
        Try

            Dim strq As String = "select Examcode, Activateexam.Examid from Activateexam join examset on Activateexam.examid=examset.examid  where bid=" & Request.QueryString("batchid")
            Dim dsBatch As New DataSet()
            dsBatch = CLS.fnQuerySelectDs(strq)
            If dsBatch IsNot Nothing Then
                If dsBatch.Tables IsNot Nothing Then
                    If dsBatch.Tables(0).Rows IsNot Nothing Then
                        If dsBatch.Tables(0).Rows.Count > 0 Then
                            ddlListExamSet.DataTextField = "ExamCode"
                            ddlListExamSet.DataValueField = "examid"
                            ddlListExamSet.DataSource = dsBatch
                            ddlListExamSet.DataBind()
                            ddlListExamSet.Items.Insert(0, "--Select--")
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
    'Private Sub FillDDl1()
    '    MyCLS.ConOpen()
    '    MyCLS.prcFillDDL(ddlActivationDate, "Activateexam", "id", "ActivateDate", "BID", Request.QueryString("batchid"))
    '    MyCLS.ConClose()
    'End Sub
    'Sub BindActivateDate()
    '    If ddlListExamSet.SelectedItem.Text = "SELECT" Then
    '        lblMessage.Text = "Please select Exam"
    '        Exit Sub
    '    End If
    '    Dim strq As String = "select id,BID,CONVERT(varchar, ActivateDate, 101) as ActivateDate,CONVERT(varchar, DeactivateDate, 101) as DeactivateDate from Activateexam where BID=" & Request.QueryString("batchid") & " and ExamId=" & ddlListExamSet.SelectedItem.Value & ""

    '    dsdate = CLS.fnQuerySelectDs(strq)
    '    ViewState("Deac1") = dsdate.Tables(0).Rows(0)("DeactivateDate")
    '    ViewState("bid") = dsdate.Tables(0).Rows(0)("BID")
    '    ddlActivationDate.DataTextField = "ActivateDate"
    '    ddlActivationDate.DataValueField = "id"
    '    ddlActivationDate.DataSource = dsdate
    '    ddlActivationDate.DataBind()
    '    ddlActivationDate.Items.Insert(0, New ListItem("--Select---", "0"))
    '    ddlActivationDate.SelectedIndex = 0
    'End Sub

    Sub bindUserList()
        Try
            'Dim date1 As String = ddlActivationDate.SelectedItem.Text
            'Dim d2 As Date = Convert.ToDateTime(ViewState("Deac1"))
            'Dim ddd As String = d2.Year & "-" & d2.Month & "-" & d2.Day
            'Dim d1 As Date = Convert.ToDateTime(date1)
            'Dim dd As String = d1.Year & "-" & d1.Month & "-" & d1.Day

            'If ddlActivationDate.SelectedItem.Text = "SELECT" Then
            '    lblMessage.Text = "Please select Activetion Date"
            '    Exit Sub
            'End If
            'Dim strq As String = "select distinct(q.Userid) from Activateexam ae INNER JOIN QUES_ANSWERS q on ae.ExamId=q.ExamId where q.ExamId=" & ddlListExamSet.SelectedItem.Text & " and q.CREATDDT between '" & dd & "' and '" & ddd & "'"
            Dim strq As String
            If Len(Request.QueryString("exid")) > 0 Then
                ' strq = "select distinct(q.Userid),q.ExamId,FirstName +' ' +middlename+' '+lastname as stuname,CONVERT(CHAR(8),activateDate-endexamtime,108) as timetaken,convert(varchar,activateDate,103) as examDate from  QUES_ANSWERS q join student s on q.userid=s.email join studentactiveexam sa on (q.userid=sa.userid and q.examid=sa.examid) where q.ExamId=" & Request.QueryString("exid") & "  and sa.BID=" & Request.QueryString("batchid") & "" comment made by wahid on 25 sept 20

                strq = "select distinct(q.Userid),q.ExamId,FirstName +' ' +middlename+' '+lastname as stuname,CONVERT(CHAR(8),activateDate-endexamtime,108) as timetaken,convert(varchar,activateDate,103) as examDate,TotalMarks,status from  QUES_ANSWERS q join student s on q.userid=s.email join studentactiveexam sa on (q.userid=sa.userid and q.examid=sa.examid) left outer join ExamFinalMarks mark on mark.UserId=q.UserId where q.ExamId=" & Request.QueryString("exid") & "  and sa.BID=" & Request.QueryString("batchid") & ""
            Else
                strq = "select distinct(q.Userid),q.ExamId,FirstName +' ' +middlename+' '+lastname as stuname,CONVERT(CHAR(8),activateDate-endexamtime,108) as timetaken,convert(varchar,activateDate,103) as examDate,TotalMarks,status from  QUES_ANSWERS q join student s on q.userid=s.email join studentactiveexam sa on (q.userid=sa.userid and q.examid=sa.examid) left outer join ExamFinalMarks mark on mark.UserId=q.UserId where q.ExamId=" & ddlListExamSet.SelectedItem.Value & "  and sa.BID=" & Request.QueryString("batchid") & ""
            End If

            Dim dsUser As New DataSet()
            dsUser = CLS.fnQuerySelectDs(strq)
            If dsUser IsNot Nothing Then
                If dsUser.Tables IsNot Nothing Then
                    If dsUser.Tables(0).Rows IsNot Nothing Then
                        If dsUser.Tables(0).Rows.Count > 0 Then
                            GrdUserList.DataSource = dsUser
                            GrdUserList.DataBind()
                            GrdUserList.Visible = True
                            bindDescriptive()
                        Else
                            lblMessage.Text = "No Student for this Exam "
                            GrdUserList.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    'Sub bindgrid1()
    '    Try
    '        Dim strq As String = "select b.bid,b.courseID,c.CourseTitle,b.BatchCode from batch b INNER JOIN course c on b.courseID=c.CourseID order by b.bid desc"
    '        'Dim strq As String = "select * from batch"

    '        Dim dsbatch As New DataSet()
    '        dsbatch = CLS.fnQuerySelectDs(strq)
    '        If dsbatch IsNot Nothing Then
    '            If dsbatch.Tables IsNot Nothing Then
    '                If dsbatch.Tables(0).Rows IsNot Nothing Then
    '                    If dsbatch.Tables(0).Rows.Count > 0 Then
    '                        GrdBatch.DataSource = dsbatch
    '                        GrdBatch.DataBind()
    '                        GrdBatch.Visible = True
    '                    Else
    '                        lblMessage.Text = "No batch is created for this course"
    '                        'GrdBatch.Visible = False
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    'Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
    '    ViewState("chk") = 2
    '    bindgrid()
    'End Sub
    'Protected Sub GrdBatch_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    GrdBatch.PageIndex = e.NewPageIndex
    '    If (ViewState("chk") = 1) Then
    '        bindgrid1()
    '    Else
    '        bindgrid()
    '    End If
    'End Sub

    Protected Sub ddlListExamSet_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlListExamSet.SelectedIndexChanged
        'BindActivateDate()
        bindUserList()
    End Sub

    

    Protected Sub GrdUserList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdUserList.PageIndexChanging
        GrdUserList.PageIndex = e.NewPageIndex
        bindUserList()
    End Sub

    Protected Sub Page_PreRenderComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRenderComplete

    End Sub

    Protected Sub GrdUserList_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdUserList.RowDataBound

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then


                Dim lnkbtnDesc As LinkButton = DirectCast(e.Row.FindControl("lnkbtnDesc"), LinkButton)
                Dim lnkbtnFacultyFeedback As LinkButton = DirectCast(e.Row.FindControl("lnkbtnFacultyFeedback"), LinkButton)
                Dim hdnuploadanspath As HiddenField = DirectCast(e.Row.FindControl("hdnuploadanspath"), HiddenField)
                Dim hdnTotalMarks As HiddenField = DirectCast(e.Row.FindControl("hdnTotalMarks"), HiddenField)
                Dim hdnstatus As HiddenField = DirectCast(e.Row.FindControl("hdnstatus"), HiddenField)

                If (hdnuploadanspath.Value = "") Then
                    lnkbtnDesc.Visible = False
                Else
                    lnkbtnDesc.Visible = True

                End If

                If (hdnstatus.Value = "True" And hdnTotalMarks.Value <> "") Then
                    lnkbtnFacultyFeedback.Visible = True
                Else
                    lnkbtnFacultyFeedback.Visible = False
                End If

            End If

        Catch ex As Exception
            ' HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try

    End Sub

    Sub bindDescriptive()
        For i As Integer = 0 To GrdUserList.Rows.Count - 1
            Try
                'Dim date1 As String = ddlActivationDate.SelectedItem.Text
                'Dim d2 As Date = Convert.ToDateTime(ViewState("Deac1"))
                'Dim ddd As String = d2.Year & "-" & d2.Month & "-" & d2.Day
                'Dim d1 As Date = Convert.ToDateTime(date1)
                'Dim dd As String = d1.Year & "-" & d1.Month & "-" & d1.Day

                'If ddlActivationDate.SelectedItem.Text = "SELECT" Then
                '    lblMessage.Text = "Please select Activetion Date"
                '    Exit Sub
                'End If
                'Dim strq As String = "select distinct(q.Userid) from Activateexam ae INNER JOIN QUES_ANSWERS q on ae.ExamId=q.ExamId where q.ExamId=" & ddlListExamSet.SelectedItem.Text & " and q.CREATDDT between '" & dd & "' and '" & ddd & "'"
                Dim lnkbtnDesc As LinkButton = DirectCast(GrdUserList.Rows(i).FindControl("lnkbtnDesc"), LinkButton)
                Dim lbluserid As Label = DirectCast(GrdUserList.Rows(i).FindControl("lbluserid"), Label)
                Dim strq As String
                If Len(Request.QueryString("exid")) > 0 Then
                    strq = "select distinct(q.Userid) as userid,'1' as descriptive from Activateexam ae INNER JOIN QUES_ANSWERS q on ae.ExamId=q.ExamId where q.ExamId=" & Request.QueryString("exid") & "  and ae.BID=" & Request.QueryString("Batchid") & " and uploadanspath<>''"
                Else
                    strq = "select distinct(q.Userid) as userid,'1' as descriptive from Activateexam ae INNER JOIN QUES_ANSWERS q on ae.ExamId=q.ExamId where q.ExamId=" & ddlListExamSet.SelectedItem.Value & "  and ae.BID=" & batchcode & " and uploadanspath<>''"

                End If
                Dim ds As New DataSet()
                ds = CLS.fnQuerySelectDs(strq)
                If ds IsNot Nothing Then
                    If ds.Tables IsNot Nothing Then
                        If ds.Tables(0).Rows IsNot Nothing Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                For j As Integer = 0 To ds.Tables(0).Rows.Count - 1

                                    If ds.Tables(0).Rows(j)("userid").ToString() = lbluserid.Text AndAlso ds.Tables(0).Rows(j)("descriptive").ToString() = "1" Then
                                        lnkbtnDesc.Visible = True


                                    End If

                                Next
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try
        Next

    End Sub



    Protected Sub lnkbtnDesc_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
        If e.CommandName.Equals("descriptive") Then
            Dim userid As String = Convert.ToString(e.CommandArgument)
            Try
                Dim strq As String = "select ROW_NUMBER() OVER(ORDER BY qa.questionid asc) AS Queno,Q.QuestionText,qa.questionid,UserId,UploadAnsPath from Ques_answers qa  join questions q on qa.questionid=q.questionid where qa.userid='" & userid & "' and qa.Examid=" & ddlListExamSet.SelectedItem.Value & " and UploadAnsPath<>''"
                Dim ds As New DataSet()
                ds = CLS.fnQuerySelectDs(strq)
                If ds IsNot Nothing Then
                    If ds.Tables IsNot Nothing Then
                        If ds.Tables(0).Rows IsNot Nothing Then
                            If ds.Tables(0).Rows.Count > 0 Then
                                GrdDescAns.DataSource = ds
                                GrdDescAns.DataBind()
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
            End Try

        End If
    End Sub

    Protected Sub lnkbtndownload_Command(ByVal sender As Object, ByVal e As CommandEventArgs)
        If e.CommandName.Equals("download") Then
            Dim filename As String = Convert.ToString(e.CommandArgument)
            If filename <> "" Then
                Dim path As String = filename
                'path = Path.Combine(path, filename);
                Dim file As New System.IO.FileInfo(path)
                If file.Exists Then
                    Session("file") = filename
                    Response.Redirect("download.aspx")
                Else
                    'Response.Write("<SCRIPT LANGUAGE='javascript'>alert('This file does not exist.'); </script>");

                    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('This file does not exist.');", True)
                End If

            End If

        End If
    End Sub
    Protected Sub lnkbtnSubmit_Click(sender As Object, e As EventArgs) Handles btnAssign.Click

        If ddlListExamSet.SelectedIndex = 0 Then
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Please select Exam List !');", True)
        Else
            Dim Examid As String = ""
            Examid = ddlListExamSet.SelectedValue

            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "window.openPopup('AssignExamToFaculty.aspx?Examid=" + Examid + "&bid=" + Request.QueryString("batchid") + "');", True)

        End If
    End Sub
End Class


