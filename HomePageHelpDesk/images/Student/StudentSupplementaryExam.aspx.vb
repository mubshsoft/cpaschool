Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Xml.Linq
Imports fmsf.DAL
Imports fmsf.lib
Imports System.Data.SqlClient


Partial Class Student_StudentSupplementaryExam
    Inherits System.Web.UI.Page
    Dim objLibSupExam As New LibSuppExam
    Dim DalSupExam As New DalAddSupExam

  

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            End If

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
   
   
    Protected Sub imgSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSave.Click
        Try
            objLibSupExam.Batchid = ddlbatch.SelectedValue
            objLibSupExam.stid = Session("stid")
            objLibSupExam.Paperid = ddlPaper.SelectedValue
            Dim retVal As Int16 = DalSupExam.InsertSuppExam(objLibSupExam)
            If (retVal >= 1) Then
                lblMessage.Text = "Registered Successfully"
            Else
                lblMessage.Text = "Registration already exist"
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
