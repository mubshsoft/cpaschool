
Partial Class Admin_FacultySelect
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
        bindgrid()
    End Sub
    Sub bindgrid()
        Try
            Dim strq As String = "select  ROW_NUMBER() OVER(ORDER BY fid asc) AS ROWID, Fid,email,firstName,lastname,(firstName + ' ' + lastname) as FullName from FacultyRegistration"
            Dim dsFaculty As New DataSet()
            dsFaculty = CLS.fnQuerySelectDs(strq)
            If dsFaculty IsNot Nothing Then
                If dsFaculty.Tables IsNot Nothing Then
                    If dsFaculty.Tables(0).Rows IsNot Nothing Then
                        If dsFaculty.Tables(0).Rows.Count > 0 Then
                            GrdFaculty.DataSource = dsFaculty
                            GrdFaculty.DataBind()
                            GrdFaculty.Visible = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdFaculty_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GrdFaculty.SelectedIndexChanging
        
    End Sub

    Protected Sub GrdFaculty_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdFaculty.PageIndexChanging
        GrdFaculty.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
End Class