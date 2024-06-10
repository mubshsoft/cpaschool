
Partial Class Student_ListCourseForfee
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        bindgrid()
    End Sub
    Sub bindgrid()
        Try
            Dim strq As String = "select st.stid,sr.courseid,c.CourseCode,c.Coursetitle,st.email,st.firstName,st.lastname from student st INNER JOIN StudentRegcourse sr on st.stid=sr.stid INNER JOIN course c on c.CourseID=sr.courseid where st.email ='" & Session("username") & "'"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdCourse.DataSource = dsCourse
                            GrdCourse.DataBind()
                            GrdCourse.Visible = True
                       
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdCourse_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdCourse.PageIndexChanging
        GrdCourse.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
End Class
