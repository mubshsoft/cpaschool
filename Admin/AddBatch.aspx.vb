Imports System.IO
Imports fmsf.DAL
Imports fmsf.lib
Imports System.Data
Imports System.Data.SqlClient
Partial Class Admin_AddBatch
    Inherits System.Web.UI.Page
    Dim objLibST As New LibAddStudent
    Dim objDalSt As New DalAddStudent
    Dim objLibErr As New libErrorMsg

    Dim objLibStApp As New LibStudentAPP

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        If Not IsPostBack Then
            MyCLS.ConOpen()
            FillDDl()
        End If
    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        Dim CourseCode As String
        Dim DsCourseCode As New DataSet
        DsCourseCode = CLS.fnQuerySelectDs("select CourseCode from Course where CourseID=" & ddlCourse.SelectedValue)
        CourseCode = DsCourseCode.Tables(0).Rows(0)(0).ToString()


        Dim CurYear As String = Date.Now.Year
        Dim i As Integer = 1
        Dim BatchCode As String
        Dim Dsmax As New DataSet
        Dsmax = CLS.fnQuerySelectDs("select max(bid) from Batch")
        Dim max As String = Dsmax.Tables(0).Rows(0)(0).ToString()
        If max = "" Then
            BatchCode = CurYear & "-" & CourseCode & "-" & i 
        Else
            Dim val As Integer = CInt(max.Trim())
            BatchCode = CurYear & "-" & CourseCode & "-" & val + 1
        End If

        txtBatchCode.Text = BatchCode.ToString()

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim strDupliQ As String
            strDupliQ = "select * from Batch where courseid=" & ddlCourse.SelectedItem.Value & " and batchcode='" & Trim(txtBatchCode.Text) & "'"
            Dim dsDupliQ As New DataSet
            dsDupliQ = CLS.fnQuerySelectDs(strDupliQ)
            If dsDupliQ IsNot Nothing Then
                If dsDupliQ.Tables IsNot Nothing Then
                    If dsDupliQ.Tables(0).Rows IsNot Nothing Then
                        If dsDupliQ.Tables(0).Rows.Count > 0 Then
                            lblMessage.Text = "Batch code already exist"
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Dim strQ As String
            strQ = "insert into Batch(courseID,BatchCode) values(" & ddlCourse.SelectedItem.Value & ",'" & Trim(txtBatchCode.Text) & "')"
            CLS.fnExecuteQuery(strQ)
            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Batch created successfully!'); location.href='adminlogin.aspx' ;</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Batch created successfully!'); location.href='adminlogin.aspx' ;", True)







        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        txtBatchCode.Text = ""
        Response.Redirect("adminlogin.aspx")
    End Sub
End Class
