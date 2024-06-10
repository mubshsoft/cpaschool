Imports System.IO
Partial Class Faculty_FacultyDownloadmaterial
    Inherits System.Web.UI.Page
   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")

        End If
        If Not IsPostBack Then
            DownLoad()
            ViewState("chk") = 1
            FillCourse()
            tr1.Visible = False
        End If
        'DownLoad()
    End Sub

    Sub DownLoad()
        Dim sqlStr As String = "select coursecode,semestertitle,moduletitle,PaperTitle,UnitId,UnitTitle,UploadFilePath,Fid from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId inner join unit on unit.paperid=paper.paperid inner join facultyAssign on facultyAssign.paperid=unit.paperid where facultyAssign.Fid=" & Session("fid")
        Dim dsDownload As New DataSet()
        dsDownload = CLS.fnQuerySelectDs(sqlStr)
        GrdDownload.DataSource = dsDownload
        GrdDownload.DataBind()
    End Sub
    Sub DownLoadByCourse()
        Dim sqlStr1 As String = "select coursecode,semestertitle,moduletitle,PaperTitle,UnitId,UnitTitle,UploadFilePath,Fid from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId inner join unit on unit.paperid=paper.paperid inner join facultyAssign on facultyAssign.paperid=unit.paperid where course.courseid=" & ddlCourse.SelectedValue & " and  facultyAssign.Fid =" & Session("fid")
        Dim dsDownload1 As New DataSet()
        dsDownload1 = CLS.fnQuerySelectDs(sqlStr1)
        GrdDownload.DataSource = dsDownload1
        GrdDownload.DataBind()
    End Sub
    Sub DownLoadByCourseWithSem()
        Dim sqlStr1 As String = "select coursecode,semestertitle,moduletitle,PaperTitle,UnitId,UnitTitle,UploadFilePath,Fid from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId inner join unit on unit.paperid=paper.paperid inner join facultyAssign on facultyAssign.paperid=unit.paperid where course.courseid=" & ddlCourse.SelectedValue & " and semester.semid=" & dllSem.SelectedValue & " and  facultyAssign.Fid =" & Session("fid")
        Dim dsDownload1 As New DataSet()
        dsDownload1 = CLS.fnQuerySelectDs(sqlStr1)
        GrdDownload.DataSource = dsDownload1
        GrdDownload.DataBind()
    End Sub
    Private Sub FillCourse()
        Try


            Dim strCourse As String = "select distinct(a.courseid),co.CourseTitle,a.Fid from facultyregistration inner join facultyassign a on facultyregistration.Fid=a.Fid INNER JOIN course co on co.Courseid=a.Courseid where email='" & Session("username") & "'"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strCourse)
            ddlCourse.DataSource = dsCourse
            ddlCourse.DataTextField = "CourseTitle"
            ddlCourse.DataValueField = "courseid"
            ddlCourse.DataBind()
            ddlCourse.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillSem()
        Try


            Dim strSem As String = "select a.courseid,a.semid as semid,s.semestertitle from facultyregistration inner join facultyassign a on facultyregistration.Fid=a.Fid INNER JOIN course co on co.Courseid=a.Courseid  INNER JOIN Semester s on s.semid=a.semid where a.courseid=" & ddlCourse.SelectedValue
            Dim dsSem As New DataSet()
            dsSem = CLS.fnQuerySelectDs(strSem)
            dllSem.DataSource = dsSem
            dllSem.DataTextField = "semestertitle"
            dllSem.DataValueField = "semid"
            dllSem.DataBind()
            dllSem.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ViewState("chk") = 2
        tr1.Visible = Visible
        FillSem()
        DownLoadByCourse()
    End Sub

    Protected Sub dllSem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dllSem.SelectedIndexChanged
        ViewState("chk") = 3
        DownLoadByCourseWithSem()
    End Sub
    Protected Sub GrdDownload_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdDownload.PageIndex = e.NewPageIndex
        If ViewState("chk") = 1 Then
            DownLoad()
        ElseIf ViewState("chk") = 2 Then
            DownLoadByCourse()
        ElseIf ViewState("chk") = 3 Then
            DownLoadByCourseWithSem()
        End If

    End Sub
End Class
