Imports fmsf.DAL
Imports fmsf.lib
Imports System.IO
Imports Emoticons
Imports System.Collections
Imports System.Collections.Generic
Partial Class UploadMultipleFiles
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Len(Session("username")) <= 0 Then
                Response.Redirect("login.aspx")
            End If
            If Len(Request.QueryString("Subjectid")) > 0 Then
                ViewState("s") = Request.QueryString("Subjectid")

                BindTempUploadFiles()
            End If

        End If
    End Sub

    Protected Sub DeleteFile(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim lnk As LinkButton = CType(sender, LinkButton)

            Dim filePath As String = lnk.CommandArgument
            File.Delete(filePath)

            lblMessage.Text = "File Deleted Successfully!"
            lblMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red")

            BindTempUploadFiles()

        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
    End Sub
    Private Sub BindTempUploadFiles()
        Try

            Dim subjectid As String = Request.QueryString("Subjectid")
            Dim uploadFolder As String = ""
            uploadFolder = Request.PhysicalApplicationPath + "DisscussionForumFiles\" + subjectid
            Dim filePaths() As String = Directory.GetFiles(uploadFolder)

            Dim dirInfo As New IO.DirectoryInfo(HttpContext.Current.Server.MapPath("~/DisscussionForumFiles/" + subjectid))
            '  Dim dirInfo As DirectoryInfo = New DirectoryInfo(@"" + HttpContext.Current.Server.MapPath("~/DisscussionForumFiles/" + 1)) 
            Dim wordFiles() As FileInfo = dirInfo.GetFiles("*.*")

            'List<ListItem> files = new List<ListItem>();
            ' Dim files As List<System.Web.UI.WebControls.ListItem>=  New List<System.Web.UI.WebControls.ListItem>() 

            Dim dt As DataTable = New DataTable()

            Dim dc As DataColumn = New DataColumn()
            dc.DataType = System.Type.GetType("System.String")
            dc.ColumnName = "Filename"

            Dim dc1 As DataColumn = New DataColumn()
            dc1.DataType = System.Type.GetType("System.String")
            dc1.ColumnName = "Filepath"

            Dim dc2 As DataColumn = New DataColumn()
            dc2.DataType = System.Type.GetType("System.String")
            dc2.ColumnName = "Filesize"

            dt.Columns.Add(dc)
            dt.Columns.Add(dc1)
            dt.Columns.Add(dc2)

            Dim file As FileInfo
            For Each file In wordFiles

                Dim dr As DataRow = dt.NewRow()
                dr("Filename") = file ' Path.GetFileName(file);
                dr("Filepath") = file.FullName

                dr("Filesize") = file.Length
                dt.Rows.Add(dr)
            Next
            If filePaths.Length > 0 Then

                dlstFileUpload.DataSource = dt
                dlstFileUpload.DataBind()
                dlstFileUpload.Visible = True
                btnclose.Visible = True
            Else
                dlstFileUpload.Visible = False
                btnclose.Visible = False
            End If
        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
    End Sub

    Protected Sub btnUpload_Click(sender As Object, e As System.EventArgs) Handles btnUpload.Click
        Try


            Dim subjectid As String = Request.QueryString("Subjectid")
            Dim uploadFolder As String = ""
            If FileUpload1.HasFile Then
                Dim fileinfo As Boolean = False
                Dim FileNumber As Integer = 0
                Dim sb As StringBuilder = New StringBuilder()
                sb.Append("You are not permited to upload this type of file(s)")
                Dim i As Integer
                For i = 0 To Request.Files.Count - 1 Step i + 1

                    Dim Up_Files1 As System.Web.HttpPostedFile = Request.Files(i)
                    Dim type As String = ""
                    Dim ext As String = Path.GetExtension(Up_Files1.FileName)

                    If Not ext Is Nothing Then
                        type = CommonUtility.GetMimeType(ext)
                    End If
                    If Up_Files1.ContentLength > 0 Then

                        Try
                            If ext.ToLower().ToString() = ".zip" Or ext.ToLower().ToString() = ".rar" Or ext.ToLower().ToString() = ".xml" Then
                                fileinfo = True
                                FileNumber = FileNumber + 1
                                sb.Append(System.Environment.NewLine)
                                sb.Append("<br/>File " + FileNumber + ": " + Up_Files1.FileName)

                            ElseIf type.ToString().Contains("video") And Up_Files1.ContentLength > 10485760 Then
                                fileinfo = True
                                sb.Append("<br/>File " + FileNumber + ": " + Up_Files1.FileName + " Video File Size is greater than 10 MB")
                            ElseIf type.ToString().Contains("image") And Up_Files1.ContentLength > 3145728 Then
                                fileinfo = True
                                sb.Append("<br/>File " + FileNumber + ": " + Up_Files1.FileName + " File Size is greater than 3 MB")
                            ElseIf Up_Files1.ContentLength > 5242880 Then
                                fileinfo = True
                                sb.Append("<br/>File " + FileNumber + ": " + Up_Files1.FileName + " File Size is greater than 5 MB")
                            Else

                                Dim strNewfilename As String = ""

                                uploadFolder = Request.PhysicalApplicationPath + "DisscussionForumFiles\\" + subjectid
                                strNewfilename = uploadFolder + "\\" + Up_Files1.FileName.ToString()

                                If System.IO.Directory.Exists(uploadFolder) Then

                                Else
                                    Directory.CreateDirectory(uploadFolder)
                                End If


                                Up_Files1.SaveAs(strNewfilename)

                            End If

                        Catch ex As Exception

                        End Try

                    End If
                Next

                If (fileinfo) Then
                    lblMessage.Text = sb.ToString()
                Else
                    lblMessage.Text = "File Added Successfully."
                    lblMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("#145A32")
                End If


                BindTempUploadFiles()
            Else
                lblMessage.Text = "Please Attach File."
                lblMessage.ForeColor = System.Drawing.ColorTranslator.FromHtml("red")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnclose_Click(sender As Object, e As System.EventArgs) Handles btnclose.Click
        Response.Write("<script>window.location.href = 'MainForumPage1.aspx';self.close();</script>")
        'ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "window.location.href = 'MainForumPage1.aspx'; self.close();", True)
    End Sub

End Class
