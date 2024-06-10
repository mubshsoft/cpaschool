Imports fmsf.DAL
Imports fmsf.lib
Imports System.IO
Imports Emoticons
Imports System.Collections
Imports System.Collections.Generic
Partial Class AllTopicList
    Inherits System.Web.UI.UserControl
    Dim id As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            id = Request.QueryString("id")
            ViewState("id") = id
            bindgrid()
            fillHeading()
            BindTempUploadFiles()
            If Len(Request.QueryString("o")) <= 0 Then
                updateread()
            End If
        End If
    End Sub

    Sub bindgrid()
        Try
            'Dim strST As String
            'strST = "select a.courseid as courseid ,a.stid as stid,a.semid as semid from student inner join studentSemester a " & _
            '        " on student.stid=a.stid " & _
            '        " where email='" & Session("username") & "' and a.currentStatus=2"

            'Dim iCid As Integer
            'Dim iSemid As Integer
            'Dim dsStInfo As New DataSet()
            'dsStInfo = CLS.fnQuerySelectDs(strST)
            'If dsStInfo IsNot Nothing Then
            '    If dsStInfo.Tables IsNot Nothing Then
            '        If dsStInfo.Tables(0).Rows IsNot Nothing Then
            '            If dsStInfo.Tables(0).Rows.Count > 0 Then
            '                iCid = dsStInfo.Tables(0).Rows(0)("courseid")
            '                iSemid = dsStInfo.Tables(0).Rows(0)("semid")
            '            End If
            '        End If
            '    End If
            'End If
            'Dim strq As String = "select  * from subSubject where subjectID=" & Request.QueryString("id") & " and approve=1"
            Dim strq As String = "select  * from subSubject where subjectID=" & Request.QueryString("id") & " order by subsubjectid"

            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            GrdTopic.DataSource = dsTopic
                            GrdTopic.DataBind()
                            GrdTopic.Visible = True
                            lblNoTopic.visible = False

                        Else
                            'lblMessage.Text = "No topic exist"
                            GrdTopic.Visible = False
                            lblNoTopic.visible = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Protected Sub ImgbtnPostReply_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgbtnPostReply.Click
    '    Response.Redirect("postreply.aspx?id=" & ViewState("id"))
    'End Sub


    Sub fillHeading()
        Try
            Dim strq As String = "select  Title,FilePath from maintopic where subjectID=" & Request.QueryString("id")
            Dim dsSubjectHeading As New DataSet()
            dsSubjectHeading = CLS.fnQuerySelectDs(strq)
            If dsSubjectHeading IsNot Nothing Then
                If dsSubjectHeading.Tables IsNot Nothing Then
                    If dsSubjectHeading.Tables(0).Rows IsNot Nothing Then
                        If dsSubjectHeading.Tables(0).Rows.Count > 0 Then
                            lblmainTopic.Text = dsSubjectHeading.Tables(0).Rows(0)("title").ToString
                            If Not String.IsNullOrEmpty(dsSubjectHeading.Tables(0).Rows(0)("FilePath").ToString()) Then
                                'lnkFile.Visible = True
                                lnkFile.CommandArgument = dsSubjectHeading.Tables(0).Rows(0)("FilePath").ToString()
                            Else
                                lnkFile.Visible = False
                            End If

                        End If
                    End If
                End If
            End If




        Catch ex As Exception
        End Try
    End Sub

    Sub updateread()
        Try
            Dim PrevRead As Int16 = 0
            Dim strPreviousRead As String = "select  totalread from maintopic where subjectID=" & Request.QueryString("id")
            Dim dsPrevRead As New DataSet()
            dsPrevRead = CLS.fnQuerySelectDs(strPreviousRead)
            If dsPrevRead IsNot Nothing Then
                If dsPrevRead.Tables IsNot Nothing Then
                    If dsPrevRead.Tables(0).Rows IsNot Nothing Then
                        If dsPrevRead.Tables(0).Rows.Count > 0 Then
                            PrevRead = CInt(dsPrevRead.Tables(0).Rows(0)("totalread").ToString())
                        End If
                    End If
                End If
            End If

            Dim strUpdate As String
            strUpdate = "update maintopic set totalread=" & PrevRead + 1 & " where subjectID=" & Request.QueryString("id")
            CLS.fnExecuteQuery(strUpdate)
        Catch ex As Exception
        End Try





    End Sub

    Protected Sub grdTopic_ItemDataBound(ByVal sender As Object, ByVal e As Web.UI.WebControls.RepeaterItemEventArgs)

        Try

            Dim lnkbtnreplies As LinkButton = CType(e.Item.FindControl("lnkbtnreplies"), LinkButton)
            Dim lblUserName As Label = CType(e.Item.FindControl("lblUserName"), Label)
            Dim hdnSubjectid As HiddenField = CType(e.Item.FindControl("hdnSubjectid"), HiddenField)
            Dim hdnSubSubjectid As HiddenField = CType(e.Item.FindControl("hdnSubSubjectid"), HiddenField)
            Dim username As String = Session("username")

            If lblUserName.Text = username Then
                lnkbtnreplies.Visible = True
                lnkbtnreplies.PostBackUrl = "postreply.aspx?id=" + hdnSubjectid.Value.ToString() + "&sid=" + hdnSubSubjectid.Value.ToString()
                'lnkbtnreplies.PostBackUrl = "UpdateSubSubject.aspx?tid=" + hdnSubjectid.Value.ToString() + "&sid=" + hdnSubSubjectid.Value.ToString() + "&email=" + lblUserName.Text.ToString()
            Else
                lnkbtnreplies.Visible = False
                'hypMID.NavigateUrl = "ViewResubmitManuscript.aspx?TID=" + hdnOldTitled.Value.ToString() + "&NTID=" + hdnTitleId.Value.ToString()
            End If

        Catch ex As Exception
        End Try

    End Sub


    'Protected Sub imgBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBack.Click
    '    If Session("role") = "Admin" Then
    '        Response.Redirect("admin/ListTopic.aspx")
    '    ElseIf Session("role") = "Faculty" Then
    '        Response.Redirect("MainForumPage1.aspx")
    '    ElseIf Session("role") = "Student" Then
    '        Response.Redirect("MainForumPage.aspx")
    '    End If
    'End Sub

    Protected Sub imgBack_Click(sender As Object, e As System.EventArgs) Handles imgBack.Click
        If Session("role") = "Admin" Then
            Response.Redirect("admin/ListTopic.aspx")
        ElseIf Session("role") = "Faculty" Then
            Response.Redirect("MainForumPage1.aspx")
        ElseIf Session("role") = "Student" Then
            Response.Redirect("MainForumPage.aspx")
        End If
    End Sub

    Protected Sub ImgbtnPostReply_Click(sender As Object, e As System.EventArgs) Handles ImgbtnPostReply.Click
        Response.Redirect("postreply.aspx?id=" & ViewState("id"))
    End Sub
    Protected Sub lnkFile_Click(sender As Object, e As EventArgs)
        Dim path As String = lnkFile.CommandArgument

        Dim strPath As String = Server.MapPath("\") & path
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

    End Sub

    Private Sub BindTempUploadFiles()
        Try

            Dim subjectid As String = Request.QueryString("id")
            Dim uploadFolder As String = ""
            uploadFolder = Request.PhysicalApplicationPath + "DisscussionForumFiles\" + subjectid

            If (Directory.Exists(uploadFolder)) Then


                Dim filePaths() As String = Directory.GetFiles(uploadFolder)

                Dim dirInfo As New IO.DirectoryInfo(HttpContext.Current.Server.MapPath("~/DisscussionForumFiles/" + subjectid))

                Dim wordFiles() As FileInfo = dirInfo.GetFiles("*.*")
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

                Else
                    dlstFileUpload.Visible = False

                End If
            End If
        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
    End Sub

    Protected Sub DownloadFile(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim lnk As LinkButton = CType(sender, LinkButton)

            Dim filePath As String = lnk.CommandArgument
            'Dim strPath As String = Server.MapPath("\") & Path
            Dim file1 As System.IO.FileInfo = New System.IO.FileInfo(filePath) '-- if the file exists on the server  

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
            BindTempUploadFiles()

        Catch ex As Exception
            HandleException.ExceptionLogging(ex.Source, ex.Message, True)
        End Try
    End Sub
End Class
