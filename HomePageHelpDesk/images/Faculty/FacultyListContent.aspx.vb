
Partial Class Faculty_FacultyListContent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If


        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()
                bindgrid()
                MyCLS.ConClose()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Sub bindgrid()
        Try
            Dim mailid As String = Session("username")
            Dim strq As String = "select fa.Fid,cs.CourseID,cs.CourseTitle,cs.CourseCode from Course cs Inner Join facultyAssign fa on fa.CourseID=cs.CourseID where fa.Fid=" & Session("fid")
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdCourseApply.DataSource = dsCourse
                            GrdCourseApply.DataBind()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdCourseApply_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdCourseApply.PageIndexChanging
        GrdCourseApply.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
End Class

