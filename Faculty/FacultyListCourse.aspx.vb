
Partial Class Faculty_FacultyListCourse
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

            Dim ifacid As Integer
            Dim strFacId As String
            Dim dsFacid As New DataSet
            strFacId = "select fid from facultyregistration where email='" & mailid & "'"
            dsFacid = CLS.fnQuerySelectDs(strFacId)
            If dsFacid IsNot Nothing Then
                If dsFacid.Tables IsNot Nothing Then
                    If dsFacid.Tables(0).Rows IsNot Nothing Then
                        If dsFacid.Tables(0).Rows.Count > 0 Then
                            ifacid = dsFacid.Tables(0).Rows(0)("fid").ToString
                        End If
                    End If
                End If
            End If

            Dim strq As String = "select distinct(fa.courseid),c.coursecode,fid from facultyassign fa INNER JOIN course c on c.CourseID=fa.courseid where fa.fid =" & ifacid
            Dim dsCourse As New DataSet
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

End Class

