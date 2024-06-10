Imports System
Imports System.IO
'Imports iTextSharp.text
'Imports iTextSharp.text.pdf

Partial Class DownloadDetail
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("login.aspx")
            End If

            If Len(Request.QueryString("dt")) <= 0 Then
                Dim Path As String
                Path = Server.MapPath("") & "\studentDoc\" & Session("email") & "\" & Request.QueryString("fnm")
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(Path) '-- if the file exists on the server  
                If file.Exists Then 'set appropriate headers  
                    Response.Clear()
                    Response.AddHeader("Content-Disposition", "attachment; filename=" & file.Name)
                    Response.AddHeader("Content-Length", file.Length.ToString())
                    Response.ContentType = "application/octet-stream"
                    Response.WriteFile(file.FullName)
                    Response.End() 'if file does not exist  
                Else
                    Response.Write("This file does not exist.")
                End If 'nothing in the URL as HTTP GET  
            Else
                Dim cCode As String
                Dim sTitle As String
                Dim mTitle As String
                Dim pTitle As String

                Dim sqlPaper As String = "select coursecode,semestertitle,moduletitle,PaperTitle from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId where paper.paperid=" & Request.QueryString("paperid")
                Dim dsPaper As New DataSet()
                dsPaper = CLS.fnQuerySelectDs(sqlPaper)
                If (dsPaper.Tables(0).Rows.Count > 0) Then
                    cCode = dsPaper.Tables(0).Rows(0)("CourseCode").ToString()
                    sTitle = dsPaper.Tables(0).Rows(0)("semestertitle").ToString()
                    mTitle = dsPaper.Tables(0).Rows(0)("moduletitle").ToString()
                    pTitle = dsPaper.Tables(0).Rows(0)("PaperTitle").ToString()
                End If

                Dim strUnit As String
                Dim sqlUnit As String = "select * from unit where unitid=" & Request.QueryString("unitid")
                Dim dsUnit As New DataSet()
                dsUnit = CLS.fnQuerySelectDs(sqlUnit)
                If (dsUnit.Tables(0).Rows.Count > 0) Then
                    strUnit = dsUnit.Tables(0).Rows(0)("uploadfilepath").ToString()
                End If

                Dim strPath As String = Server.MapPath("") & "\upload\" & cCode & "\" & sTitle & "\" & mTitle & "\" & pTitle & "\" & strUnit
                Dim file1 As System.IO.FileInfo = New System.IO.FileInfo(strPath) '-- if the file exists on the server  

                If file1.Exists Then 'set appropriate headers  
                    Response.Clear()
                    Response.AddHeader("Content-Disposition", "attachment; filename=" & file1.Name)
                    Response.AddHeader("Content-Length", file1.Length.ToString())
                    Response.ContentType = "application/octet-stream"
                    Response.WriteFile(file1.FullName)
                    Response.End() 'if file does not exist  
                Else
                    Response.Write("This file does not exist.")
                End If 'nothing in the URL as HTTP GET  

            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
