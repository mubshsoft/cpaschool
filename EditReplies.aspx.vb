
Partial Class EditReplies
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        bindgrid()
        fillHeading()
    End Sub
    Sub bindgrid()
        Try
            Dim strq As String
            If Session("role") = "Admin" Then
                strq = "select  * from subSubject where subjectID=" & Request.QueryString("id") & " order by subsubjectid"

            Else
                strq = "select  * from subSubject where subjectID=" & Request.QueryString("id") & " and email='" & Session("username") & "' order by subsubjectid"
            End If

            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            grdTopic.DataSource = dsTopic
                            grdTopic.DataBind()
                            grdTopic.Visible = True
                        Else
                            'lblMessage.Text = "No topic exist"
                            grdTopic.Visible = False

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdTopic_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles grdTopic.RowCommand
        Try
            If e.CommandName = "Delete" Then
                Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                Dim str As String = "delete from subSubject where subsubjectid=" & id
                CLS.fnExecuteQuery(str)
                bindgrid()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdTopic_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdTopic.RowDeleting

    End Sub

    Protected Sub imgBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles imgBack.Click
        If Session("role") = "Admin" Then
            Response.Redirect("admin/ListTopic.aspx")
        ElseIf Session("role") = "Faculty" Then
            Response.Redirect("MainForumPage1.aspx")
        ElseIf Session("role") = "Student" Then
            Response.Redirect("MainForumPage.aspx")

        End If
    End Sub

    Sub fillHeading()
        Try
            Dim strq As String = "select  Title from maintopic where subjectID=" & Request.QueryString("id")
            Dim dsSubjectHeading As New DataSet()
            dsSubjectHeading = CLS.fnQuerySelectDs(strq)
            If dsSubjectHeading IsNot Nothing Then
                If dsSubjectHeading.Tables IsNot Nothing Then
                    If dsSubjectHeading.Tables(0).Rows IsNot Nothing Then
                        If dsSubjectHeading.Tables(0).Rows.Count > 0 Then
                            lblmainTopic.Text = dsSubjectHeading.Tables(0).Rows(0)("title").ToString
                        End If
                    End If
                End If
            End If




        Catch ex As Exception
        End Try
    End Sub

    Protected Sub grdTopic_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdTopic.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        If row.DataItem Is Nothing Then
            Exit Sub
        End If
        Dim lnkDelete As LinkButton
     
        'lnkDelete = CType(row.FindControl("lnkDelete"), LinkButton)
        If Session("role") = "Student" Then
            'lnkDelete.Visible = False
            grdTopic.Columns(5).Visible = False
        End If

    End Sub
End Class
