Imports System.Data.SqlClient
Imports System.IO
Partial Class Admin_AddUnit
    Inherits System.Web.UI.Page
    Dim semid As Integer
    Dim mid As Integer
    Dim pid As Integer
    Dim Ccode As String
    Dim Stitle As String
    Dim Mtitle As String
    Dim Ptitle As String
    Dim uid As String
    Dim strPathOld As String
    Dim strPathOld1 As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            Else
                If Session("role") = "Admin" Then
                Else
                    Response.Redirect("../login.aspx")
                End If
            End If


            pid = Request.QueryString("pid")
            semid = Request.QueryString("sid")
            mid = Request.QueryString("mid")

            If Request.QueryString("paperID") IsNot Nothing Then
                If Request.QueryString("UnitId").ToString() <> "" Then
                    lblUnitMsg.Text = "Edit Unit"
                    pid = Request.QueryString("PaperID")
                    mid = Request.QueryString("Moduleid")
                    uid = Request.QueryString("Unitid")
                End If
            Else
                lblUnitMsg.Text = "Add Unit"
            End If
            If Not IsPostBack Then
                If Request.QueryString("paperID") IsNot Nothing Then
                    If Request.QueryString("UnitId").ToString() <> "" Then
                        FillData(Request.QueryString("paperID").ToString(), Request.QueryString("UnitId").ToString())
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click

        Dim strPath As String
        Dim fn As String
        Dim strUpdate As String
        If Len(Request.QueryString("paperID")) > 0 Then
            Try
                If Request.QueryString("UnitId").ToString() <> "" Then
                    If fnValidate1() = True Then
                        GetData(mid, pid)
                        strPathOld = ViewState("path")
                        If Not FileUpload1.PostedFile Is Nothing And FileUpload1.PostedFile.ContentLength > 0 Then
                            fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
                            strPathOld1 = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Ptitle & "\" & lblpath.Text
                            Dim strPath1 As String = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Ptitle & "\" & fn                            'If ViewState("path") = strPath1 Then

                            'If UCase(MyCLS.fnGetExtension(System.IO.Path.GetFileName(strPath1))) = "PDF" Then
                            If FileUpload1.PostedFile.FileName = strPath1 Then
                            Else
                                'File.Delete(strPathOld)
                                File.Delete(strPathOld1)
                                FileUpload1.PostedFile.SaveAs(strPath1)
                            End If
                            Try
                                strUpdate = "update unit set UnitTitle='" & txtUnitName.Text & "',UploadFilePath='" & strPath1 & "' where PaperID=" & pid & " and UnitId=" & uid
                                CLS.fnExecuteQuery(strUpdate)
                            Catch ex As Exception
                                File.Delete(strPath1)
                            End Try


                            Response.Write("<script>window.opener.location.reload(); self.close();</script>")
                            ' Else
                            '    Response.Write("<script>alert('You can upload only PDF file')</script>")
                            'End If


                        Else
                            ' fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
                            'Dim strPath1 As String = Server.MapPath("../") & "upload/" & Ccode & "/" & Stitle & "/" & Mtitle & "/" & Ptitle & "/" & fn
                            Dim strPathNew As String
                            Dim arrStr() As String = strPathOld.Split("\")
                            Dim OldFileName As String
                            Dim arrFilename() As String
                            Dim l As Integer = arrStr.Length
                            OldFileName = arrStr(l - 1)
                            arrFilename = OldFileName.Split(".")
                            'Dim strExtension As String
                            'strExtension = CLS.fnGetExtension(arrStr(l - 1))
                            'strPathNew = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Ptitle & "\" & txtUnitName.Text & "." & arrFilename(1)
                            strPathNew = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Ptitle & "\" & lblpath.Text
                            'If File.Exists(strPathNew) = True Then
                            '    lblMessage.Text = "Unit already exists"
                            '    lblMessage.ForeColor = Drawing.Color.Red

                            'Else
                            'File.Move(strPathOld1, strPathNew)
                            Try
                                strUpdate = "update unit set UnitTitle='" & txtUnitName.Text & "',UploadFilePath='" & strPathNew & "' where PaperID=" & pid & " and UnitId=" & uid
                                CLS.fnExecuteQuery(strUpdate)
                            Catch ex As Exception
                                File.Move(strPathNew, strPathOld)
                            End Try
                            Response.Write("<script>window.opener.location.reload(); self.close();</script>")
                            'End If

                        End If
                    End If
                End If
            Catch Exc As Exception
                Response.Write("Error: " & Exc.Message)
            End Try
        ElseIf Len(Request.QueryString("pid")) > 0 Then
            Try
                If fnValidate() = True Then
                    If Not FileUpload1.PostedFile Is Nothing And FileUpload1.PostedFile.ContentLength > 0 Then
                        fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)
                        Dim strQ As String
                        Try
                            GetData(mid, pid)
                            strPath = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Ptitle & "\" & fn
                            ViewState("FilePath") = strPath
                            If File.Exists(strPath) Then
                                lblMessage.Text = "File already exists."
                                lblMessage.ForeColor = Drawing.Color.Red
                                Exit Sub
                            Else
                                Dim rAffected As Integer

                                '    If UCase(MyCLS.fnGetExtension(System.IO.Path.GetFileName(strPath))) = "PDF" Then

                                Try
                                    FileUpload1.PostedFile.SaveAs(strPath)
                                    strQ = "insert into unit(Paperid,UnitTitle,UploadFilepath) values(" & pid & ",'" & Trim(txtUnitName.Text) & "','" & Trim(strPath) & "')"
                                Catch ex As Exception
                                    File.Delete(strPath)
                                End Try


                                CLS.fnExecuteQuery(strQ)
                                Response.Write("<script>window.opener.location.reload(); self.close();</script>")

                                '    Else
                                '   Response.Write("<script>alert('You can upload only PDF file')</script>")
                                '  End If
                            End If

                    ' Response.Write("The file has been uploaded.")
                    'Dim filename As String = fn.ToString()
                        Catch Exc As Exception
                Response.Write("Error: " & Exc.Message)
            End Try
                    Else
                        lblMessage.Text = "Please select a file to upload."
                        lblMessage.ForeColor = Drawing.Color.Red
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClose.Click
        Response.Write("<script>self.close();</script>")
    End Sub

    Private Sub GetData(ByVal ModuleId As String, ByVal paperID As String)
        Try
            Dim strGetData As String = "select coursecode,semestertitle,moduletitle,PaperTitle from course inner join semester on course.courseid = semester.courseid inner join module on semester.semid=module.semid inner join paper on paper.ModuleId=Module.ModuleId where Module.moduleid=" & Integer.Parse(ModuleId) & " and paper.paperID=" & Integer.Parse(paperID) & ""
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                Ccode = ds.Tables(0).Rows(0)("CourseCode").ToString()
                Stitle = ds.Tables(0).Rows(0)("semestertitle").ToString()
                Mtitle = ds.Tables(0).Rows(0)("moduletitle").ToString()
                Ptitle = ds.Tables(0).Rows(0)("PaperTitle").ToString()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillData(ByVal paperID As String, ByVal UnitID As String)
        Try
            Dim strGetData As String = "select * from Unit where paperID=" & Integer.Parse(paperID) & " and UnitId=" & Integer.Parse(UnitID) & ""
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                txtUnitName.Text = ds.Tables(0).Rows(0)("UnitTitle").ToString()
                Dim arrFilename As String = ds.Tables(0).Rows(0)("UploadFilepath").ToString()
                Dim arr() As String
                arr = arrFilename.Split("\")
                Dim l As Integer
                l = arr.Length
                lblpath.Text = arr(l - 1)
                ' ViewState("path") = lblpath.Text
                ' ViewState("path") = ds.Tables(0).Rows(0)("UploadFilepath").ToString()
                strPathOld = ds.Tables(0).Rows(0)("UploadFilepath").ToString()
                ViewState("path") = ds.Tables(0).Rows(0)("UploadFilepath").ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Function fnValidate() As Boolean
        Try
            If Len(txtUnitName.Text) <= 0 Then
                lblMessage.Text = "Unit name cannot be left blank"
                Return False
            End If

            If FileUpload1.HasFile = False Then
                lblMessage.Text = "Please select filename"
                Return False
            End If

            Dim dscheck As New DataSet
            Dim strq As String
            strq = "select * from unit where Unittitle='" & Trim(txtUnitName.Text) & "' and Paperid=" & pid
            dscheck = CLS.fnQuerySelectDs(strq)
            If dscheck IsNot Nothing Then
                If dscheck.Tables IsNot Nothing Then
                    If dscheck.Tables(0).Rows IsNot Nothing Then
                        If dscheck.Tables(0).Rows.Count > 0 Then
                            lblMessage.Text = "Unit Name already exist"
                            lblMessage.ForeColor = Drawing.Color.Red
                            Return False
                        End If
                    End If
                End If
            End If
            Return True
        Catch ex As Exception
        End Try
    End Function

    Function fnValidate1() As Boolean
        Try
            If Len(txtUnitName.Text) <= 0 Then
                lblMessage.Text = "Unit name cannot be left blank"
                Return False
            End If




            'Dim dscheck As New DataSet
            'Dim strq As String
            'strq = "select * from unit where Unittitle='" & Trim(txtUnitName.Text) & "' and Paperid=" & pid
            'dscheck = CLS.fnQuerySelectDs(strq)
            'If dscheck IsNot Nothing Then
            '    If dscheck.Tables IsNot Nothing Then
            '        If dscheck.Tables(0).Rows IsNot Nothing Then
            '            If dscheck.Tables(0).Rows.Count > 0 Then
            '                lblMessage.Text = "Unit Name already exist"
            '                lblMessage.ForeColor = Drawing.Color.Red
            '                Return False
            '            End If
            '        End If
            '    End If
            'End If
            Return True
        Catch ex As Exception
        End Try
    End Function
End Class


