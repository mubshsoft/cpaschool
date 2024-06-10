
Partial Class DownloadPDF
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Path As String
        Dim colName As String
        colName = ""
        Path = ""
        If Request.QueryString("HelpDesk") = 1 Then
            Path = Server.MapPath("") & "\HomePageHelpDesk\"
            colName = "HelpDeskFilepath"
        ElseIf Request.QueryString("HelpDesk") = 2 Then
            Path = Server.MapPath("") & "\HomePageBroucher\"
            colName = "BroucherFilepath"
        ElseIf Request.QueryString("HelpDesk") = 3 Then
            Path = Server.MapPath("") & "\HomePageCalendar\"
            colName = "CalendarFilepath"
        End If
        Dim filePath As String
        Dim ds As New DataSet()
        ds = CLS.fnQuerySelectDs("select " & colName & " from HelpDeskBroucher where CourseId = " & Request.QueryString("cid"))
        If ds.Tables(0).Rows.Count > 0 Then
            filePath = ds.Tables(0).Rows(0).Item(0).ToString()
        End If

        Path = Path & filePath

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
End Class
