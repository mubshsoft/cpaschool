
Partial Class Admin_ListBatch
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
                lblMessage.Text = "Please select course"
                Exit Sub
            End If
            Dim strq As String = "select b.bid,b.courseID,c.CourseTitle,b.BatchCode from batch b INNER JOIN course c on b.courseID=c.CourseID where b.courseID=" & ddlCourse.SelectedValue & " order by b.bid desc"
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

   
    Protected Sub GrdBatch_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdBatch.RowCommand
        Try
            If e.CommandName = "Delete" Then

                Dim dsBatchSTudent As New DataSet
                Dim row As GridViewRow = DirectCast((DirectCast(e.CommandSource, LinkButton).NamingContainer), GridViewRow)
                Dim lblbid As Label = DirectCast(row.FindControl("lblBatchCode"), Label)
                Dim strq As String = "select * from studentregbatch where bid=" & lblbid.Text
                dsBatchSTudent = CLS.fnQuerySelectDs(strq)
                If dsBatchSTudent IsNot Nothing Then
                    If dsBatchSTudent.Tables IsNot Nothing Then
                        If dsBatchSTudent.Tables(0).Rows IsNot Nothing Then
                            If dsBatchSTudent.Tables(0).Rows.Count <= 0 Then
                                Dim str1 As String = "delete from batch where bid=" & Trim(lblbid.Text)
                                CLS.fnExecuteQuery(str1)
                                lblMessage.Text = "Record deleted successfully"
                                ' ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Record deleted successfully!');</script>")
                            Else
                                'ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Students exist in batch!');", True)
                                ' ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Students exist in batch!');</script>")
                                lblMessage.Text = "Students exist in batch"

                            End If
                        End If
                    End If
                End If
                If (ViewState("chk") = 1) Then
                    bindgrid1()
                Else
                    bindgrid()
                End If

            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdBatch_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdBatch.RowDeleting

    End Sub
End Class
