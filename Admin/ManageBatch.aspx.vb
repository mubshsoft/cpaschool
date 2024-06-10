
Partial Class Admin_ManageBatch
    Inherits System.Web.UI.Page
    Dim bid As Integer
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
            bid = Request.QueryString("batchid")
            If Not IsPostBack Then
                MyCLS.ConOpen()
                ViewState("chk") = 1
                bindgrid()
                FillDDl()
                MyCLS.ConClose()
            End If

        Catch ex As Exception
        End Try



    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlBatch, "batch", "bid", "BatchCode")
    End Sub

    Sub bindgrid()
        Try
            '            Dim strq As String = "select st.stid,st.firstname,st.lastname,st.email,sr.courseid,cs.courseCode,cs.courseTitle from student st INNER JOIN  StudentRegCourse sr on st.stid=sr.stid INNER JOIN course cs on sr.courseid=cs.courseid where (st.stid not in(select stid from StudentRegBatch) or sr.courseid not in(select courseid from StudentRegBatch )) "
            'Dim strq As String = "select st.stid,st.firstname,st.lastname,st.email,sr.courseid,cs.courseCode,cs.courseTitle from student st INNER JOIN  StudentRegCourse sr on st.stid=sr.stid INNER JOIN course cs on sr.courseid=cs.courseid INNER JOIN  feestatus fs on fs.stid=sr.stid where ((st.stid not in(select stid from StudentRegBatch) or sr.courseid not in(select courseid from StudentRegBatch )) and (fs.feestatus=1 and fs.courseid=sr.courseid))"
            Dim strq As String = "SELECT StudentRegCourse.stid,StudentRegCourse.courseid,student.firstname,student.lastname,student.email,course.courseCode,course.courseTitle FROM StudentRegCourse INNER JOIN student on student.stid=StudentRegCourse.stid INNER JOIN course on course.courseid=StudentRegCourse.courseid inner join studentsemester on (studentsemester.stid=StudentRegCourse.stid and studentsemester.courseid=StudentRegCourse.courseid) WHERE NOT EXISTS (SELECT studentregbatch.stid,studentregbatch.courseid FROM StudentRegBatch WHERE(StudentRegBatch.stid = StudentRegCourse.stid)AND StudentRegBatch.courseid = StudentRegCourse.courseid) and (studentsemester.currentstatus=2 and studentsemester.feestatus=1 and studentsemester.courseid=StudentRegCourse.courseid)"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        Else
                            lblMessage.Text = "No student"
                            GrdStudent.Visible = False
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
        Dim lblcourseid As Label
        Dim dsChkstudent As New DataSet
        Dim count As Integer = 0
        'If Request.QueryString("batchid").ToString() <> "" Then
        If (ddlBatch.SelectedItem.Text = "SELECT") Then
            'Response.Write("<script>alert('Batch is not selected!')</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Batch is not selected!');", True)
            Exit Sub
        End If
        Try
            For Each cc1 As GridViewRow In GrdStudent.Rows
                chekw = DirectCast(cc1.FindControl("chk"), CheckBox)
                If chekw.Checked Then
                    lblstid = DirectCast(cc1.FindControl("lblstid"), Label)
                    lblcourseid = DirectCast(cc1.FindControl("lblcourseid"), Label)
                    'dsChkstudent = CLS.fnQuerySelectDs("select *from StudentRegBatch where stid=" & lblstid.Text & " and Approve=1")
                    'If dsChkstudent IsNot Nothing Then
                    '    If dsChkstudent.Tables IsNot Nothing Then
                    '        If dsChkstudent.Tables(0).Rows IsNot Nothing Then
                    '            If dsChkstudent.Tables(0).Rows.Count > 0 Then
                    '                lblMessage.Text = "Batch is alloted to student"
                    '                count = 0 + 1
                    '            Else
                    '                If count > 0 Then
                    '                    Exit Sub
                    '                Else

                    '                    Dim str As String = "insert into StudentRegBatch(bid,stid,Approve,courseid)values( " & ddlBatch.SelectedValue.ToString() & " , " & lblstid.Text & ",1," & lblcourseid.Text & ")"
                    '                    CLS.fnExecuteQuery(str)
                    '                    lblMessage.Text = "Student added successfully in this batch "
                    '                    'End If


                    '                End If
                    '            End If
                    '        End If
                    '    End If
                    'End If
                    Dim str As String = "insert into StudentRegBatch(bid,stid,Approve,courseid)values( " & ddlBatch.SelectedValue.ToString() & " , " & lblstid.Text & ",1," & lblcourseid.Text & ")"
                    CLS.fnExecuteQuery(str)
                End If
            Next
            chkExamTable(ddlBatch.SelectedValue.ToString())
            chkAssignmentTable(ddlBatch.SelectedValue.ToString())
            Response.Redirect("listbatch.aspx")
        Catch ex As Exception

        End Try
        'End If
        bindgrid()
    End Sub


    Protected Sub GrdStudent_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdStudent.PageIndex = e.NewPageIndex
        If (ViewState("chk") = 1) Then
            bindgrid()
        Else
            'bindgrid()
        End If
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        bindgrid1()
    End Sub

    Sub bindgrid1()
        Try
            If ddlBatch.SelectedItem.Text = "SELECT" Then
                lblMessage.Text = "Please select Batch"
                Exit Sub
            End If
            Dim strCourse As String = "select courseID from batch where BatchCode='" & ddlBatch.SelectedItem.Text & "' "
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strCourse)
            Dim courseid1 As String = ds.Tables(0).Rows(0)("courseID").ToString

            ' Dim strq As String = "select st.stid,st.firstname,st.lastname,st.email,sr.courseid,cs.courseCode,cs.courseTitle from student st INNER JOIN  StudentRegCourse sr on st.stid=sr.stid INNER JOIN course cs on sr.courseid=cs.courseid INNER JOIN  feestatus fs on fs.stid=sr.stid where ((st.stid not in(select stid from StudentRegBatch) or sr.courseid not in(select courseid from StudentRegBatch ))and sr.courseid=" & courseid1 & " and (fs.feestatus=1 and fs.courseid=" & courseid1 & "))"
            'Dim strq As String = "select st.stid,st.firstname,st.lastname,st.email,sr.courseid,cs.courseCode,cs.courseTitle from student st INNER JOIN  StudentRegCourse sr on st.stid=sr.stid INNER JOIN course cs on sr.courseid=cs.courseid where (st.stid not in(select stid from StudentRegBatch) or sr.courseid not in(select courseid from StudentRegBatch ))and sr.courseid=" & courseid1 & ""
            Dim strq As String = "SELECT StudentRegCourse.stid,StudentRegCourse.courseid,student.firstname,student.lastname,student.email,course.courseCode,course.courseTitle FROM StudentRegCourse INNER JOIN student on student.stid=StudentRegCourse.stid INNER JOIN course on course.courseid=StudentRegCourse.courseid inner join studentsemester on (studentsemester.stid=StudentRegCourse.stid and studentsemester.courseid=StudentRegCourse.courseid) WHERE NOT EXISTS (SELECT studentregbatch.stid,studentregbatch.courseid FROM StudentRegBatch WHERE(StudentRegBatch.stid = StudentRegCourse.stid)AND StudentRegBatch.courseid = StudentRegCourse.courseid) and (studentsemester.currentstatus=2 and studentsemester.feestatus=1 and studentsemester.courseid=" & courseid1 & ")"
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
                            lblMessage.Text = "No student remaining in this batch"
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Response.Redirect("listbatch.aspx")
    End Sub

    Sub chkExamTable(ByVal bid As Integer)
        Dim strq As String = "select * from activateexam where DeactivateDate >= convert(varchar,getdate(),101) and bid=" & bid
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
        Dim strq As String = "select * from activateassignment where DeactivateDate >= convert(varchar,getdate(),101) and bid=" & bid
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

End Class
