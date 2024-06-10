
Partial Class Admin_ApplyAnotherCourse
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If

        Try
            If Not IsPostBack Then

            End If

        Catch ex As Exception

        End Try

    End Sub



    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchName()
    End Sub

    Sub SearchName()
        Try
            Dim Data As String = txtfirstname.Text
            If txtfirstname.Text = "" Then
                lblMessage.Text = "Please Enter Search Criteria.."
                Exit Sub
            End If
           
            Dim strq As String = "select StudentRegCourse.courseid,course.coursecode,course.CourseTitle,student.stid,student.email,student.firstname,student.lastname from student INNER JOIN StudentRegCourse on student.stid=StudentRegCourse.stid INNER JOIN Course on Course.courseid=StudentRegCourse.courseid where  student.firstname like '%" & Data & "%' or student.lastname like '%" & Data & "%' or student.email like '%" & Data & "%'"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                            lblSearchWith.Text = "Search With - " + Data
                        Else
                            lblMessage.Text = "No record found"
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
