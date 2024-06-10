
Partial Class Admin_AdminListBatchExam
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
                ViewState("chk") = 1
                FillDDl()

                bindgrid1()

                MyCLS.ConClose()
            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
    End Sub
    Sub bindgrid()
        Try
            If ddlCourse.SelectedItem.Text = "SELECT" Then
                'lblMessage.Text = "Please select course"
                bindgrid1()
                Exit Sub
            End If
            Dim strq As String = "select b.bid,b.courseID,c.CourseTitle,b.BatchCode from batch b INNER JOIN course c on b.courseID=c.CourseID where b.courseID=" & ddlCourse.SelectedValue & " order by b.bid desc"
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            If dsbatch IsNot Nothing Then
                If dsbatch.Tables IsNot Nothing Then
                    If dsbatch.Tables(0).Rows IsNot Nothing Then

                        GrdBatch.DataSource = dsbatch
                        GrdBatch.DataBind()
                        GrdBatch.Visible = True
                        '' added by chhaya for adding batch filter
                        trbatch.Visible = True
                        ddlbatch.DataSource = dsbatch
                        ddlbatch.DataTextField = "BatchCode"
                        ddlbatch.DataValueField = "bid"
                        ddlbatch.DataBind()
                        ddlbatch.Items.Insert(0, "SELECT")

                        If dsbatch.Tables(0).Rows.Count = 0 Then
                            lblMessage.Text = "No batch is created for this course"
                            GrdBatch.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub bindgrid1()
        Try
            Dim strq As String = "select b.bid,b.courseID,c.CourseTitle,b.BatchCode from batch b INNER JOIN course c on b.courseID=c.CourseID order by b.bid desc"
            'Dim strq As String = "select * from batch"

            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            If dsbatch IsNot Nothing Then
                If dsbatch.Tables IsNot Nothing Then
                    If dsbatch.Tables(0).Rows IsNot Nothing Then
                        If dsbatch.Tables(0).Rows.Count > 0 Then
                            GrdBatch.DataSource = dsbatch
                            GrdBatch.DataBind()
                            GrdBatch.Visible = True
                        Else
                            lblMessage.Text = "No batch is created for this course"
                            'GrdBatch.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

 
    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ViewState("chk") = 2
        bindgrid()
    End Sub
    Protected Sub GrdBatch_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdBatch.PageIndex = e.NewPageIndex
        If (ViewState("chk") = 1) Then
            bindgrid1()
        Else
            bindgrid()
        End If
    End Sub
    Sub bindbatchgrid()
        Try
            'If ddlCourse.SelectedItem.Text = "SELECT" Then
            '    lblMessage.Text = "Please select course"
            '    bindgrid1()
            '    Exit Sub
            'End If
            If ddlbatch.SelectedItem.Text = "SELECT" Then
                ' lblMessage.Text = "Please select Batch"
                bindgrid()
                Exit Sub
            End If
            Dim strq As String = "select b.bid,b.courseID,c.CourseTitle,b.BatchCode from batch b INNER JOIN course c on b.courseID=c.CourseID where  b.bid=" & ddlbatch.SelectedValue & " order by b.bid desc"
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            If dsbatch IsNot Nothing Then
                If dsbatch.Tables IsNot Nothing Then
                    If dsbatch.Tables(0).Rows IsNot Nothing Then
                        If dsbatch.Tables(0).Rows.Count > 0 Then
                            GrdBatch.DataSource = dsbatch
                            GrdBatch.DataBind()
                            GrdBatch.Visible = True

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        bindbatchgrid()
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ExamPanel.aspx")
    End Sub
End Class

