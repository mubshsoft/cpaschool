
Partial Class Admin_SupplementaryExamList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'If Len(Session("username")) <= 0 Then
            '    Response.Redirect("../login.aspx")
            'Else
            '    If Session("role") = "Admin" Then
            '    Else
            '        Response.Redirect("../login.aspx")
            '    End If
            'End If
            If Not IsPostBack Then
                MyCLS.ConOpen()
                FillCourse()

                MyCLS.ConClose()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillCourse()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseCode")

    End Sub

    Private Sub FillDDlSem()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlSem, "Semester", "SemID", "SemesterTitle", "courseid", ddlCourse.SelectedValue)
        MyCLS.ConClose()
    End Sub
    Private Sub FillDDlModule()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlModule, "Module", "ModuleID", "ModuleTitle", "SemID", ddlSem.SelectedValue)
        MyCLS.ConClose()
    End Sub
    Private Sub FillDDlPaper()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlPaper, "paper", "PaperID", "PaperTitle", "ModuleID", ddlModule.SelectedValue)
        MyCLS.ConClose()
    End Sub

   
    Function Fillbatch() As Integer
        Try
            MyCLS.ConOpen()
            MyCLS.prcFillDDL(ddlbatch, "batch", "bid", "batchcode", "courseID", ddlCourse.SelectedValue)
            MyCLS.ConClose()
        Catch ex As Exception
        End Try
    End Function
   

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillDDlSem()
        Fillbatch()
    End Sub

    Protected Sub ddlSem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSem.SelectedIndexChanged
        FillDDlModule()
    End Sub

    Protected Sub ddlModule_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlModule.SelectedIndexChanged
        FillDDlPaper()
    End Sub

  
    Protected Sub Imagebutton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Imagebutton1.Click

    End Sub
End Class
