
Partial Class Admin_UpdatePWD
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            Else
                If Session("role") = "Admin" Then
                Else
                    Response.Redirect("../login.aspx")
                End If
            End If
            If Not IsPostBack Then
                MyCLS.ConOpen()
                FillDDl()
                bindgrid()
                MyCLS.ConClose()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlBatch, "Batch", "bid", "BatchCode")
    End Sub
    Sub bindgrid()
        Try
            Dim strq As String = "select st.stid,st.email,bt.courseid,lo.password from student st INNER JOIN login lo on lo.username=st.email INNER JOIN studentregbatch bt on st.stid=bt.stid where bt.bid=" & ddlBatch.SelectedValue & ""

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
        bindgrid()
    End Sub

    Protected Sub GrdStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdStudent.SelectedIndexChanged

    End Sub
    Protected Sub GrdStudent_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdStudent.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
End Class
