
Partial Class Student_ApplyAnotherCourse
    Inherits System.Web.UI.Page
  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If

        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()
                bindgrid()
                BindCourse()
                MyCLS.ConClose()
            End If

        Catch ex As Exception

        End Try

    End Sub
   
    Sub bindgrid()
        Try
            'Dim strq As String = "select sr.stid,sr.courseid,st.email,st.password,st.firstName,st.middleName,st.lastname from student st INNER JOIN StudentRegCourse sr on st.stid=sr.stid where st.email='kp@k.com'"
            Dim mailid As String = Session("username")
            Dim strq As String = "select st.stid,sr.courseid,c.CourseCode,c.CourseTitle,st.email,st.firstName,st.lastname ,CONVERT(varchar, c.cStartDate, 103) as StartDate from student st INNER JOIN StudentRegCourse sr on st.stid=sr.stid INNER JOIN course c on c.CourseID=sr.courseid where st.email = '" & mailid & "'"
            'Dim strq As String = "select *from student"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdCourseApply.DataSource = dsCourse
                            GrdCourseApply.DataBind()
                        Else
                            lblMessage.Text = ""
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub BindCourse()
        Try
            'Dim strq As String = "select CourseID,CourseCode,CourseTitle,CONVERT(varchar, cStartDate, 101) as cStartDate, CONVERT(varchar, cEndDate, 101) as cEndDate from course"
            Dim emailid As String = Session("username")
            Dim strq As String = "select stid from student where email='" & emailid & "'"
            Dim dsStid As New DataSet
            dsStid = CLS.fnQuerySelectDs(strq)
            Dim strq1 As String = "SELECT c.courseid,c.coursecode,c.CourseTitle,CONVERT(varchar, c.cStartDate, 101) as cStartDate, CONVERT(varchar, c.cEndDate, 103) as cEndDate FROM COURSE C " & _
                                   " WHERE c.Courseid not in(select courseid from studentregcourse where stid=" & CInt(dsStid.Tables(0).Rows(0)("stid").ToString) & ")"

            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq1)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdCourse.DataSource = dsCourse
                            GrdCourse.DataBind()
                        Else
                            lblMessage.Text = "No Course found.you had already registered for all available courses."
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdCourse_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GrdCourse.PageIndexChanging
        GrdCourse.PageIndex = e.NewPageIndex
        BindCourse()

    End Sub
    
    Protected Sub GrdCourseApply_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdCourseApply.PageIndexChanging
        GrdCourseApply.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
End Class
