
Partial Class Student_ListContent
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
    Dim strCurrentSem As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If


        Try
            If Not IsPostBack Then
                cid = Request.QueryString("id")
                FillSemester()

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


             
                
                BindData()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillSemester()
        Dim strq As String = "select ss.courseid,ss.semid,sem.semestertitle from studentsemester ss INNER JOIN semester sem on sem.semid=ss.semid where ss.stid=" & Request.QueryString("sid") & " and ss.courseid=" & cid & ""
        Dim dsSemester As New DataSet()
        dsSemester = CLS.fnQuerySelectDs(strq)
        If (dsSemester.Tables(0).Rows.Count > 0) Then

            dllSem.DataTextField = "SemesterTitle"
            dllSem.DataValueField = "semid"

            dllSem.DataSource = dsSemester

            dllSem.DataBind()
            dllSem.Items.Insert(0, "--SELECT SEMESTER--")
        End If

    End Sub
    Sub BindData()
        Dim dsSemCount As DataSet
        Dim strNOSem As String = "select * from semester where courseid=" & Request.QueryString("id")
        dsSemCount = CLS.fnQuerySelectDs(strNOSem)
        If dsSemCount IsNot Nothing Then
            If dsSemCount.Tables IsNot Nothing Then
                If dsSemCount.Tables(0).Rows IsNot Nothing Then
                    If dsSemCount.Tables(0).Rows.Count > 0 Then
                        semCount = dsSemCount.Tables(0).Rows.Count
                    End If
                End If
            End If
        End If

        If ViewState("chk") <> 1 Then
            strCurrentSem = "select * from studentsemester where courseid=" & cid & " and stid=" & Request.QueryString("sid") & " and currentstatus=2 and feestatus=1"

        Else
            If dllSem.SelectedItem.Text = "--SELECT--" Then
                ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Select Semester for view course content!'); </script>")
                Exit Sub
            Else
                strCurrentSem = "select * from studentsemester where courseid=" & Request.QueryString("id") & " and stid=" & Request.QueryString("sid") & " and currentstatus in(1,2) and feestatus=1 and semid=" & dllSem.SelectedValue & ""

            End If

        End If
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

    End Sub
    Protected Sub dllSem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllSem.SelectedIndexChanged
        ViewState("chk") = 1
        ' strsem = dllSem.SelectedItem.Text

        BindData()
    End Sub


End Class
