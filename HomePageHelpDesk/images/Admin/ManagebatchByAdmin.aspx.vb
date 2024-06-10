
Partial Class Admin_ManagebatchByAdmin
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
                bindgrid1()
                FillDDl()
                MyCLS.ConClose()
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlBatch, "batch", "bid", "BatchCode")
    End Sub

    Sub bindgrid1()
        Try

            'Dim strq As String = "select st.stid,st.firstname,st.lastname,st.email,sr.courseid,cs.courseCode,cs.courseTitle from student st INNER JOIN  StudentRegCourse sr on st.stid=sr.stid INNER JOIN course cs on sr.courseid=cs.courseid"
            Dim strq As String = "select b.Id,b.bid as bid,b.courseid as courseid,st.stid,st.firstName,st.lastname,st.email,bt.BatchCode,b.Approve from student st INNER JOIN StudentRegbatch b on st.stid=b.stid INNER JOIN batch bt on bt.bid=b.bid where bt.bid=" & batchid & ""

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
                            lblMessage.Text = "No student has assigned for this batch"
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
            If ddlBatch.SelectedItem.Text = "SELECT" Then
                lblMessage.Text = "Please select batch"
                Exit Sub
            End If
            Dim strq As String = "select b.Id,b.bid as bid,b.courseid as courseid,st.stid,st.firstName,st.lastname,st.email,bt.BatchCode,b.Approve from student st INNER JOIN StudentRegbatch b on st.stid=b.stid INNER JOIN batch bt on bt.bid=b.bid where b.bid=" & ddlBatch.SelectedValue & ""
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
                            lblMessage.Text = "No student is assigned for this batch"
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
        Dim lblBatchId As Label
        Dim lblEmail As Label
        Dim lblbid As Label

        Try
            For Each cc1 As GridViewRow In GrdStudent.Rows
                chekw = DirectCast(cc1.FindControl("chk"), CheckBox)
                lblBatchId = DirectCast(cc1.FindControl("lblBatchId"), Label)
                lblEmail = DirectCast(cc1.FindControl("lblEmail"), Label)
                lblbid = DirectCast(cc1.FindControl("lblbid"), Label)
                If chekw.Checked Then
                    lblstid = DirectCast(cc1.FindControl("lblstid"), Label)
                    'Dim str As String = "update StudentRegBatch set Approve,stid)values( " & bid & " , " & lblstid.Text & " )"
                    Dim str As String = "update StudentRegbatch  set Approve=1 where Id=" & lblBatchId.Text & ""
                    CLS.fnExecuteQuery(str)
                    chkExamTable(lblbid.Text)
                    chkAssignmentTable(lblbid.Text)
                Else
                    'Dim str As String = "update StudentRegbatch  set Approve=0 where Id=" & lblBatchId.Text & ""
                    Dim str As String = "delete from StudentRegbatch where Id=" & lblBatchId.Text & ""
                    CLS.fnExecuteQuery(str)
                    Dim str1 As String = "delete from StudentActiveExam where UserId='" & Trim(lblEmail.Text) & "' and  bid=" & Trim(lblbid.Text) & " and Activate=0"
                    CLS.fnExecuteQuery(str1)

                    Dim str2 As String = "delete from studentactiveassignment where UserId='" & Trim(lblEmail.Text) & "' and  bid=" & Trim(lblbid.Text) & " and Activate=0"
                    CLS.fnExecuteQuery(str2)


                End If

            Next
            bindgrid1()
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

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        ViewState("chk") = 2
        bindgrid()

    End Sub

    Protected Sub GrdStudent_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdStudent.RowCommand
        Try
            If e.CommandName = "Delete" Then
                Dim row As GridViewRow = DirectCast((DirectCast(e.CommandSource, LinkButton).NamingContainer), GridViewRow)
                Dim lblemail As Label = DirectCast(row.FindControl("lblEmail"), Label)
                Dim lblbid As Label = DirectCast(row.FindControl("lblbid"), Label)
                Dim lblbatchid As Label = DirectCast(row.FindControl("lblBatchId"), Label)

                Dim str1 As String = "delete from StudentActiveExam where UserId='" & Trim(lblemail.Text) & "' and  bid=" & Trim(lblbid.Text) & " and Activate=0"
                CLS.fnExecuteQuery(str1)
                Dim str2 As String = "delete from studentactiveassignment where UserId='" & Trim(lblemail.Text) & "' and  bid=" & Trim(lblbid.Text) & " and Activate=0"
                CLS.fnExecuteQuery(str2)

                Dim str As String = "delete from StudentRegbatch where Id=" & lblbatchid.Text
                CLS.fnExecuteQuery(str)

                lblMessage.Text = "Record deleted successfully"
                lblMessage.ForeColor = Drawing.Color.DarkGreen
                If (ViewState("chk") = 1) Then
                    bindgrid1()
                Else
                    bindgrid()
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdStudent_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdStudent.RowDeleting

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
