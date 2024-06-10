Imports System.Data.SqlClient
Partial Class FacultiesDetail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            BindCourses()
            BindFaculties()
        End If
    End Sub

    Sub BindFaculties()
        Try
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSP("Sp_GetFaculties")
            rptrFaculties.DataSource = ds
            rptrFaculties.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Sub BindCourses()
        Try
            Dim ds As New DataSet
            ds = CLS.ExecuteCLSSP("SP_FacultyByCourses")
            ddlCourseList.DataSource = ds.Tables(0)
            ddlCourseList.DataTextField = "courseTitle"
            ddlCourseList.DataValueField = "courseid"
            ddlCourseList.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlCourseList_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlCourseList.SelectedIndexChanged
        Dim courseId As Integer
        courseId = ddlCourseList.SelectedValue
        If courseId = 0 Then
            BindFaculties()
        Else
            Try
                Dim ds As New DataSet
                ds = CLS.fnQuerySelectDs("exec SP_FacultiesByCoursesId " & courseId)
                rptrFaculties.DataSource = ds
                rptrFaculties.DataBind()
            Catch ex As Exception

            End Try
        End If
    End Sub
End Class
