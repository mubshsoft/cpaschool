
Partial Class Admin_ReActivateScreening
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

                ' FillDDlScreeningset()
                FillDDl()
                MyCLS.ConClose()

            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
    End Sub
    Private Sub FillDDlScreeningset()
        ' MyCLS.prcFillDDL(ddlScreeningset, "Screeningset", "ScrId", "ScrCode")
        Try

            Dim strq As String = "select * from  Screeningset where active=1 and courseid=" & ddlcourse.SelectedValue & " order by ScrCode"
            Dim dsexam As New DataSet()
            dsexam = CLS.fnQuerySelectDs(strq)
            If dsexam IsNot Nothing Then
                If dsexam.Tables IsNot Nothing Then
                    If dsexam.Tables(0).Rows IsNot Nothing Then
                        If dsexam.Tables(0).Rows.Count > 0 Then
                            ddlScreeningset.DataTextField = "ScrCode"
                            ddlScreeningset.DataValueField = "ScrId"
                            ddlScreeningset.DataSource = dsexam
                            ddlScreeningset.DataBind()
                            ddlScreeningset.Items.Insert(0, "--Select--")


                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Sub FillDDlbatch(ByVal id As Integer)
    '    Try

    '        Dim strq As String = "select distinct(bt.BatchCode),ae.bid from StudentActiveScreening ae INNER JOIN batch bt on ae.bid=bt.bid where ae.ScrId=" & id
    '        Dim dsBatch As New DataSet()
    '        dsBatch = CLS.fnQuerySelectDs(strq)
    '        If dsBatch IsNot Nothing Then
    '            If dsBatch.Tables IsNot Nothing Then
    '                If dsBatch.Tables(0).Rows IsNot Nothing Then
    '                    If dsBatch.Tables(0).Rows.Count > 0 Then
    '                        ddlBatch.DataTextField = "BatchCode"
    '                        ddlBatch.DataValueField = "bid"
    '                        ddlBatch.DataSource = dsBatch
    '                        ddlBatch.DataBind()
    '                        ddlBatch.Items.Insert(0, "--Select--")
    '                        lblBatchCode.Visible = True
    '                        ddlBatch.Visible = True
    '                    Else
    '                        lblBatchCode.Visible = False
    '                        ddlBatch.Visible = False
    '                        GrdStudent.Visible = False
    '                        lblMessage.Text = "No Batch for this Screening Set"
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub
    Protected Sub ddlScreeningset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlScreeningset.SelectedIndexChanged
        If ddlScreeningset.SelectedItem.Text <> "SELECT" Then
            bindgrid()
        Else
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Select screening code!');", True)
            Return

        End If


        'FillDDlbatch(ddlScreeningset.SelectedValue)
    End Sub

    Sub bindgrid()
        Try
            Dim strq As String = "select ae.id,ae.ScrId,ae.courseid,ae.UserId,ae.Activate,DATEDIFF(mi,ae.ActivateDate,ae.EndScreeningTime) as timetaken,ae.EndScreeningTime,s.FirstName +' ' +s.middlename+' '+s.lastname as stuname from StudentActiveScreening ae INNER JOIN application s on ae.UserId=s.email where ae.ScrId=" & ddlScreeningset.SelectedValue & "  and ae.Activate=1  and datepart(year,activatedate)=" & ddlyear.SelectedValue & ""
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

    'Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged


    'End Sub

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
        Dim str As String = "update StudentActiveScreening set Activate=0 where id=" & Convert.ToInt32(lbl.Text)
        ExeNQcomsp(str)
        bindgrid()
    End Sub

    Protected Sub GrdStudent_RowDelitinging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdStudent.RowDeleting

        Dim idd As Integer = e.RowIndex

        Dim lbl As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblId"), Label)
        Dim usid As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblUserId"), Label)
        Dim exid As Label = DirectCast(GrdStudent.Rows(e.RowIndex).FindControl("lblScrId"), Label)
        Dim str1 As String = "delete from Screeningques_answers  where UserId='" & (usid.Text) & "' and ScrId=" & Convert.ToInt32(exid.Text)
        Dim str2 As String = "delete from ScreeningSubques_answers where UserId='" & (usid.Text) & "' and ScrId=" & Convert.ToInt32(exid.Text)

        ExeNQcomsp(str1)
        ExeNQcomsp(str2)
        bindgrid()
    End Sub

   

    Protected Sub ddlyear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlyear.SelectedIndexChanged
        If ddlScreeningset.SelectedItem.Text <> "SELECT" Then
            bindgrid()
        Else
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Select screening code!');", True)
            Return

        End If

    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ScreeningPanel.aspx")
    End Sub

    Protected Sub ddlcourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcourse.SelectedIndexChanged
        FillDDlScreeningset()
    End Sub
End Class
