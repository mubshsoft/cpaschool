
Partial Class LectureList
    Inherits System.Web.UI.Page
    Protected cid As Integer
    Protected dsSem As DataSet
    Protected dsmodule As DataSet
    Protected dspaper As DataSet
    Protected dsunit As DataSet
    Protected strCourse As String
    Protected strsem As String
    Protected strmoduleTitle As String
    Protected strpaperTitle As String
    Protected strunitTitle As String
    Protected Semid As Integer
    Protected moduleId As Integer
    Protected paperid As Integer
    Protected semCount As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If


        Try
            If Not IsPostBack Then
                cid = Request.QueryString("id")

                Dim dsCourseCode As DataSet
                Dim strCourseCode As String = "select * from course where courseid=" & cid
                dsCourseCode = CLS.fnQuerySelectDs(strCourseCode)
                If dsCourseCode IsNot Nothing Then
                    If dsCourseCode.Tables IsNot Nothing Then
                        If dsCourseCode.Tables(0).Rows IsNot Nothing Then
                            If dsCourseCode.Tables(0).Rows.Count > 0 Then
                                strCourse = dsCourseCode.Tables(0).Rows(0)("CourseCode").ToString
                            End If
                        End If
                    End If
                End If


                Dim strCurrentSem As String = "select * from studentsemester where courseid=" & cid & " and stid=" & Request.QueryString("sid") & " and currentstatus=2 and feestatus=1"
                dsSem = CLS.fnQuerySelectDs(strCurrentSem)
                If dsSem IsNot Nothing Then
                    If dsSem.Tables IsNot Nothing Then
                        If dsSem.Tables(0).Rows IsNot Nothing Then
                            If dsSem.Tables(0).Rows.Count > 0 Then
                                Dim strModule As String = "select * from module where semid=" & CInt(dsSem.Tables(0).Rows(0)("semid").ToString) & " order by moduleid"
                                dsmodule = CLS.fnQuerySelectDs(strModule)

                                Dim dsSemTitle As DataSet
                                Dim strSemQ As String = "select semesterTitle,semID from semester where semid=" & CInt(dsSem.Tables(0).Rows(0)("semid").ToString)
                                dsSemTitle = CLS.fnQuerySelectDs(strSemQ)
                                If dsSemTitle IsNot Nothing Then
                                    If dsSemTitle.Tables IsNot Nothing Then
                                        If dsSemTitle.Tables(0).Rows IsNot Nothing Then
                                            If dsSemTitle.Tables(0).Rows.Count > 0 Then
                                                semCount = dsSemTitle.Tables(0).Rows.Count
                                                strsem = dsSemTitle.Tables(0).Rows(0)("SemesterTitle").ToString
                                                Semid = dsSemTitle.Tables(0).Rows(0)("SemID").ToString
                                            End If
                                        End If
                                    End If
                                End If

                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
