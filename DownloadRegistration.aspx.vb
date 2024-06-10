
Partial Class DownloadRegistration
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Request.QueryString("id")) >= 0 Then
                Dim Path As String
                Path = Server.MapPath("") & "\images\registration.doc"
                Dim file As System.IO.FileInfo = New System.IO.FileInfo(Path) '-- if the file exists on the server  
                If file.Exists Then 'set appropriate headers  
                    Response.Clear()
                    Response.AddHeader("Content-Disposition", "attachment; filename=Registration.doc")
                    Response.AddHeader("Content-Length", file.Length.ToString())
                    Response.ContentType = "application/octet-stream"
                    Response.WriteFile(file.FullName)
                    Response.End() 'if file does not exist  
                Else
                    Response.Write("This file does not exist.")
                End If 'nothing in the URL as HTTP GET  
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
