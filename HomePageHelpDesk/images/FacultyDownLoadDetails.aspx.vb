Imports System.IO
Partial Class FacultyDownLoadDetails
    Inherits System.Web.UI.Page
    Dim semid As Integer
    Dim mid As Integer
    Dim pid As Integer
    Dim Ccode As String
    Dim Stitle As String
    Dim Mtitle As String
    Dim Ptitle As String
    Dim uTitle As String
    Dim uid As String
    Dim strPathOld As String
    Dim uploadpath As String
    Dim PFile As String
    Dim cid As Integer
    Dim strExt As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("login.aspx")
        End If
        Dim Path As String
        Path = DownLoadMaterial()
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
    End Sub

    Function DownLoadMaterial() As String
    
        Dim sqlStr As String = "select coursecode,semestertitle,moduletitle,PaperTitle,UnitId,UnitTitle,UploadFilePath from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId inner join unit on unit.paperid=paper.paperid inner join facultyAssign on facultyAssign.paperid=unit.paperid where unit.UnitId=" & Request.QueryString("uid") & " and  facultyAssign.Fid=" & Session("fid") & ""
        Dim dsDownload As New DataSet()
        dsDownload = CLS.fnQuerySelectDs(sqlStr)
        If (dsDownload.Tables(0).Rows.Count > 0) Then
            Ccode = dsDownload.Tables(0).Rows(0)("CourseCode").ToString()
            Stitle = dsDownload.Tables(0).Rows(0)("semestertitle").ToString()
            Mtitle = dsDownload.Tables(0).Rows(0)("moduletitle").ToString()
            Ptitle = dsDownload.Tables(0).Rows(0)("PaperTitle").ToString()
            uTitle = dsDownload.Tables(0).Rows(0)("UnitTitle").ToString()
            uploadpath = dsDownload.Tables(0).Rows(0)("UploadFilePath").ToString()
        End If

        Dim full As String = uploadpath
        Dim filename As String = System.IO.Path.GetFileName(full)
        Dim strext As String
        strext = MyCLS.fnGetExtension(filename)
        Dim strFileName As String
        strFileName = filename

        'Dim arr() As String
        'arr = uploadpath.Split("\")
        'Dim strFilename As String
        'strFilename = arr(arr.Length - 1)
        'strExt = MyCLS.fnGetExtension(strFilename)
        Dim strPath As String = Server.MapPath("") & "\upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Ptitle & "\" & strFileName

        'Dim arr() As String
        'arr = uploadpath.Split("\")
        'Dim strFilename As String
        'strFilename = arr(arr.Length - 2)
        'strExt = MyCLS.fnGetExtension(strFilename)
        DownLoadMaterial = strPath
    End Function
End Class
