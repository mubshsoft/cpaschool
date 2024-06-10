
Partial Class Admin_ManageStudentPromotion
    Inherits System.Web.UI.Page
    Dim batchid As String

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
            batchid = Request.QueryString("batchid")
            If Not IsPostBack Then
                MyCLS.ConOpen()
                ViewState("chk") = 1

                Dim strq As String = "select *from course where courseid in(select courseid from batch where bid=" & Request.QueryString("batchid") & ")"

                Dim dsCourse As New DataSet()
                dsCourse = CLS.fnQuerySelectDs(strq)
                If dsCourse IsNot Nothing Then
                    If dsCourse.Tables IsNot Nothing Then
                        If dsCourse.Tables(0).Rows IsNot Nothing Then
                            If dsCourse.Tables(0).Rows.Count > 0 Then
                                If dsCourse.Tables(0).Rows(0)("CourseType").ToString() = "ShortTerm" Then

                                    ddlSemListStudent.Visible = False
                                    ddlsem.Visible = False
                                    btnSave.Visible = False
                                    btncancel.Visible = False
                                    lblMessage.Visible = True
                                    lblMessage.Text = "<span style='font-size:large;text-align:center'>This is short term course. No need to promote the student in next semester..</span>"
                                Else
                                    lblMessage.Visible = False
                                End If
                            End If
                        End If
                    End If
                End If

                FillDDlSem()
                MyCLS.ConClose()
                Statusbindgrid()
            End If


        Catch ex As Exception
        End Try
    End Sub

    Sub bindgrid1()
        Try

            'Dim strq As String = "select st.stid,st.firstname,st.lastname,st.email,sr.courseid,cs.courseCode,cs.courseTitle from student st INNER JOIN  StudentRegCourse sr on st.stid=sr.stid INNER JOIN course cs on sr.courseid=cs.courseid"
            Dim strq As String = "select ROW_NUMBER() OVER(ORDER BY st.stid asc) AS ROWID, ss.promotestatus,ss.courseid,ss.Id,b.bid as bid,st.stid,st.firstName,st.lastname,st.email from student st INNER JOIN StudentRegbatch b on st.stid=b.stid INNER JOIN studentsemester ss on ss.stid=b.stid where b.bid=" & Request.QueryString("batchid") & " and currentstatus=2 and passstatus=1 and feestatus=1 and promotestatus=0"

            Dim dsStudentBatch As New DataSet()
            dsStudentBatch = CLS.fnQuerySelectDs(strq)
            If dsStudentBatch IsNot Nothing Then
                If dsStudentBatch.Tables IsNot Nothing Then
                    If dsStudentBatch.Tables(0).Rows IsNot Nothing Then
                        If dsStudentBatch.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsStudentBatch
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        Else
                            lblMessage.Text = "No record found"
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub bindgrid()
        Try
            Dim strq As String = "select ROW_NUMBER() OVER(ORDER BY st.stid asc) AS ROWID, ss.promotestatus,ss.courseid,ss.Id,b.bid as bid,st.stid,st.firstName,st.lastname,st.email from student st INNER JOIN StudentRegbatch b on st.stid=b.stid INNER JOIN studentsemester ss on ss.stid=b.stid where b.bid=" & Request.QueryString("batchid") & " and currentstatus=2 and passstatus=1 and feestatus=1 and promotestatus=0 and semid=" & ddlSemListStudent.SelectedValue
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            If dsbatch IsNot Nothing Then
                If dsbatch.Tables IsNot Nothing Then
                    If dsbatch.Tables(0).Rows IsNot Nothing Then
                        If dsbatch.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsbatch
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        Else
                            lblMessage.Text = "No record found"
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub



    Sub Statusbindgrid()
        Try
            Dim strq As String = "select ROW_NUMBER() OVER(ORDER BY st.stid asc) AS ROWID, s.semestertitle, ss.semid,ss.courseid,ss.Id,b.bid as bid,st.stid, st.firstName, st.lastname, st.email from studentsemester ss INNER JOIN StudentRegbatch b on (ss.stid=b.stid and ss.courseid=b.courseid) INNER JOIN student st on st.stid=ss.stid inner join semester s on ss.semid=s.semid  where(b.bid = " & batchid & " And currentstatus = 2)"

            Dim dsbatchStatus As New DataSet()
            dsbatchStatus = CLS.fnQuerySelectDs(strq)
            If dsbatchStatus IsNot Nothing Then
                If dsbatchStatus.Tables IsNot Nothing Then
                    If dsbatchStatus.Tables(0).Rows IsNot Nothing Then
                        If dsbatchStatus.Tables(0).Rows.Count > 0 Then
                            GrdBatchStatus.DataSource = dsbatchStatus
                            GrdBatchStatus.DataBind()
                            GrdBatchStatus.Visible = True
                        Else
                            GrdBatchStatus.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim chekw As CheckBox
        Dim lblstid As Label
        Dim lblCourseid As Label
        Dim lblsemid As Label
        Dim CurrSem, PromSem As Integer

        If ddlsem.SelectedIndex = 0 Then
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Select Semester to Promote.');", True)
            Return
        End If

        CurrSem = ddlSemListStudent.SelectedValue
        PromSem = ddlsem.SelectedValue
        If PromSem > CurrSem Then
        Else

            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Invalid Promotion criteria');", True)
        End If
        Try
            For Each cc1 As GridViewRow In GrdStudent.Rows
                chekw = DirectCast(cc1.FindControl("chk"), CheckBox)
                lblstid = DirectCast(cc1.FindControl("lblstid"), Label)
                lblCourseid = DirectCast(cc1.FindControl("lblcourseid"), Label)
                lblsemid = DirectCast(cc1.FindControl("lblsem"), Label)
                If chekw.Checked Then
                    'currentstatus =1 if semester completed,currentstatus =2 in currentsemester

                    Dim strUpdateStatusQ As String = "update studentsemester  set currentstatus=1,promotestatus=1 where stid=" & lblstid.Text & " and courseid=" & lblCourseid.Text & " and semid=" & ddlSemListStudent.SelectedValue & " and currentstatus=2"
                    Dim strUpdateCurrentStatus As String = "update studentsemester  set currentstatus=2 where stid=" & lblstid.Text & " and courseid=" & lblCourseid.Text & " and semid=" & ddlsem.SelectedValue
                    CLS.fnExecuteQuery(strUpdateStatusQ)
                    CLS.fnExecuteQuery(strUpdateCurrentStatus)

                    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Student is Promoted successfully !');", True)

                End If
            Next
            bindgrid1()
            Statusbindgrid()
            chkExamTable(batchid)
            chkAssignmentTable(batchid)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GrdStudent_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdStudent.PageIndex = e.NewPageIndex
        If (ViewState("chk") = 1) Then
            bindgrid1()
        Else
            bindgrid()
        End If
    End Sub

    Protected Sub GrdStudent_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdStudent.RowCommand
        'Try
        '    If e.CommandName = "Delete" Then
        '        Dim row As GridViewRow = DirectCast((DirectCast(e.CommandSource, LinkButton).NamingContainer), GridViewRow)
        '        Dim lblemail As Label = DirectCast(row.FindControl("lblEmail"), Label)
        '        Dim lblbid As Label = DirectCast(row.FindControl("lblbid"), Label)
        '        Dim lblbatchid As Label = DirectCast(row.FindControl("lblBatchId"), Label)

        '        Dim str1 As String = "delete from StudentActiveExam where UserId='" & Trim(lblemail.Text) & "' and  bid=" & Trim(lblbid.Text) & " and Activate=0"
        '        CLS.fnExecuteQuery(str1)
        '        Dim str2 As String = "delete from studentactiveassignment where UserId='" & Trim(lblemail.Text) & "' and  bid=" & Trim(lblbid.Text) & " and Activate=0"
        '        CLS.fnExecuteQuery(str2)

        '        Dim str As String = "delete from StudentRegbatch where Id=" & lblbatchid.Text
        '        CLS.fnExecuteQuery(str)

        '        lblMessage.Text = "Record deleted successfully"
        '        lblMessage.ForeColor = Drawing.Color.DarkGreen
        '        If (ViewState("chk") = 1) Then
        '            bindgrid1()
        '        Else
        '            bindgrid()
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub

  
    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("ListStudentPromote.aspx")
    End Sub
    Sub chkExamTable(ByVal bid As Integer)
        Dim strq As String = "select * from activateexam where DeactivateDate >= convert(varchar,getdate(),101) and bid=" & batchid
        Dim dsBatchExam As New DataSet()

        Dim i As Integer
        Dim ExamID As Integer
        Dim ActivateDate As Date
        Dim deactivateDate As Date

        dsBatchExam = CLS.fnQuerySelectDs(strq)
        If dsBatchExam IsNot Nothing Then
            If dsBatchExam.Tables IsNot Nothing Then
                If dsBatchExam.Tables(0).Rows IsNot Nothing Then
                    If dsBatchExam.Tables(0).Rows.Count > 0 Then
                        For i = 0 To dsBatchExam.Tables(0).Rows.Count - 1
                            ExamID = CInt(dsBatchExam.Tables(0).Rows(i)("Examid").ToString)
                            ActivateDate = CDate(dsBatchExam.Tables(0).Rows(i)("ActivateDate").ToString)
                            deactivateDate = CDate(dsBatchExam.Tables(0).Rows(i)("DeActivateDate").ToString)
                            CLS.UpdateStudentExam("SP_UpdateExamActivate", ExamID, bid, ActivateDate, deactivateDate)
                        Next
                    End If
                End If
            End If
        End If

    End Sub

    Sub chkAssignmentTable(ByVal bid As Integer)
        Dim strq As String = "select * from activateassignment where DeactivateDate >= convert(varchar,getdate(),101) and bid=" & batchid
        Dim dsBatchAssign As New DataSet()

        Dim i As Integer
        Dim AssignmentID As Integer
        Dim ActivateDate As Date
        Dim deactivateDate As Date

        dsBatchAssign = CLS.fnQuerySelectDs(strq)
        If dsBatchAssign IsNot Nothing Then
            If dsBatchAssign.Tables IsNot Nothing Then

                If dsBatchAssign.Tables(0).Rows IsNot Nothing Then
                    If dsBatchAssign.Tables(0).Rows.Count > 0 Then
                        For i = 0 To dsBatchAssign.Tables(0).Rows.Count - 1
                            AssignmentID = CInt(dsBatchAssign.Tables(0).Rows(i)("AsgnId").ToString)
                            ActivateDate = CDate(dsBatchAssign.Tables(0).Rows(i)("ActivateDate").ToString)
                            deactivateDate = CDate(dsBatchAssign.Tables(0).Rows(i)("DeActivateDate").ToString)
                            CLS.UpdateStudentAssignment("SP_UpdateAssignmentActivate", AssignmentID, bid, ActivateDate, deactivateDate)
                        Next
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub FillDDlSem()

        Try
            Dim courseid As Integer
            Dim strq As String = "select courseid from batch  where bid=" & Request.QueryString("batchid")
            Dim dsCourseid As New DataSet()
            dsCourseid = CLS.fnQuerySelectDs(strq)
            If dsCourseid IsNot Nothing Then
                If dsCourseid.Tables IsNot Nothing Then
                    If dsCourseid.Tables(0).Rows IsNot Nothing Then
                        If dsCourseid.Tables(0).Rows.Count > 0 Then
                            courseid = dsCourseid.Tables(0).Rows(0)("courseid")
                        Else
                            lblMessage.Text = "No record found"
                        End If
                    End If
                End If
            End If
            MyCLS.ConOpen()
            MyCLS.prcFillDDL(ddlsem, "Semester", "SemID", "SemesterTitle", "courseid", courseid)
            MyCLS.prcFillDDL(ddlSemListStudent, "Semester", "SemID", "SemesterTitle", "courseid", courseid)
            MyCLS.ConClose()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlSemListStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemListStudent.SelectedIndexChanged
        bindgrid()
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ManageStudentInfo.aspx")
    End Sub

    Protected Sub GrdBatchStatus_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdBatchStatus.PageIndexChanging
        GrdBatchStatus.PageIndex = e.NewPageIndex
        Statusbindgrid()
    End Sub
End Class



