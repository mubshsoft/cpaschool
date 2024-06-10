
Partial Class Admin_ReActivateCaseStudy
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
                'FillDDlAssignmentset()

                MyCLS.ConClose()

            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
    End Sub
    Private Sub FillDDlAssignmentset()
        ''MyCLS.prcFillDDL(ddlAssignmentset, "Assignmentset", "AsgnId", "AsgnCode")
        Try
            Dim strq As String = "select * from CaseStudyset ex inner join activateCaseStudy ax on ex.CSId = ax.CSId where active = 1 And ax.bid = " & ddlBatch.SelectedValue '& " And ex.courseid=" & ddlcourse.SelectedValue
            'Dim strq As String = "select * from  Assignmentset where active=1 order by AsgnCode"
            Dim dsasgn As New DataSet()
            dsasgn = CLS.fnQuerySelectDs(strq)
            If dsasgn IsNot Nothing Then
                If dsasgn.Tables IsNot Nothing Then
                    If dsasgn.Tables(0).Rows IsNot Nothing Then
                        If dsasgn.Tables(0).Rows.Count > 0 Then
                            ddlAssignmentset.DataTextField = "CSCode"
                            ddlAssignmentset.DataValueField = "CSId"
                            ddlAssignmentset.DataSource = dsasgn
                            ddlAssignmentset.DataBind()
                            ddlAssignmentset.Items.Insert(0, "--Select--")


                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub FillDDlbatch()
        Try
            'Dim strq As String = "select distinct(bt.BatchCode),ae.bid from StudentActiveAssignment ae INNER JOIN batch bt on ae.bid=bt.bid where ae.AsgnId=" & id
            Dim strq As String = "select b.bid,b.courseID,c.CourseTitle,b.BatchCode from batch b INNER JOIN course c on b.courseID=c.CourseID where b.courseID=" & ddlCourse.SelectedValue & " order by b.bid desc"
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
                            'lblBatchCode.Visible = False
                            'ddlBatch.Visible = False
                            GrdStudent.Visible = False
                            lblMessage.Text = "No Batch for this Assignment Set"
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddlAssignmentset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAssignmentset.SelectedIndexChanged
        'FillDDlbatch(ddlAssignmentset.SelectedValue)
        bindgrid()
    End Sub

    Sub bindgrid()
        Try
            Dim strq As String = "select ae.id,ae.CSId,ae.bid,ae.UserId,ae.Activate,ae.ActivateDate,bt.BatchCode from StudentActiveCaseStudy ae INNER JOIN batch bt on ae.bid=bt.bid where ae.CSId=" & ddlAssignmentset.SelectedValue & " and ae.bid=" & ddlBatch.SelectedValue & " and ae.Activate=1"
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
        FillDDlAssignmentset()

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

        Dim idd As Integer = e.RowIndex

        Dim lbl As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblId"), Label)
        Dim str As String = "update StudentActiveCaseStudy set Activate=0 where id=" & Convert.ToInt32(lbl.Text)
        ExeNQcomsp(str)
        bindgrid()
    End Sub


    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("CaseStudyPanel.aspx")
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillDDlbatch()
    End Sub
End Class
