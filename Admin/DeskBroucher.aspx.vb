Imports System.Data.SqlClient
Imports System.IO
Partial Class Admin_DeskBroucher
    Inherits System.Web.UI.Page
    Dim strPath As String
    Dim Ccode As String
    Dim filepath As String

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim cid As String = Request.QueryString("cid")
            Dim strPath As String
            Dim fn As String
            Dim strPath1, strPath2, strPath3 As String
            Dim strchk As String = "select * from HelpDeskBroucher where courseid=" & cid
            Dim dschk As New DataSet()
            dschk = CLS.fnQuerySelectDs(strchk)

            If Not FileUpload1.PostedFile Is Nothing And FileUpload1.PostedFile.ContentLength > 0 Then
                If Not UCase(MyCLS.fnGetExtension(FileUpload1.PostedFile.FileName)) = "PDF" Then
                    lblMessage.Text = "File extension should be pdf."
                    lblMessage.ForeColor = Drawing.Color.Red
                    Exit Sub
                End If
            End If

            If Not FileUpload1.PostedFile Is Nothing And FileUpload1.PostedFile.ContentLength > 0 Then
                fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName)

                Dim strQ As String
                Try

                    If Request.QueryString("helpId") = 1 Then
                        strPath = Server.MapPath("..\") & "HomePageHelpDesk\" & fn
                        ViewState("FilePath") = strPath
                        If File.Exists(strPath) Then
                            lblMessage.Text = "File already exists."
                            lblMessage.ForeColor = Drawing.Color.Red
                            Exit Sub
                        Else
                            Try



                                FileUpload1.PostedFile.SaveAs(strPath)
                                If dschk.Tables(0).Rows.Count > 0 Then

                                    strPath1 = dschk.Tables(0).Rows(0)("HelpDeskFilepath").ToString
                                    strPath2 = dschk.Tables(0).Rows(0)("BroucherFilepath").ToString
                                    strPath3 = dschk.Tables(0).Rows(0)("CalendarFilepath").ToString
                                    filepath = Server.MapPath("..\") & "HomePageHelpDesk\" & strPath1
                                    If File.Exists(filepath) Then
                                        File.Delete(filepath)
                                    End If

                                    strQ = "update HelpDeskBroucher set CourseId=" & cid & ",HelpDeskFilepath='" & fn & "',BroucherFilepath=' " & Trim(strPath2) & " ',CalendarFilepath='" & Trim(strPath3) & "' where courseid=" & cid
                                Else
                                    strQ = "insert into HelpDeskBroucher(CourseId,HelpDeskFilepath) values(" & cid & ",'" & Trim(fn) & "')"

                                End If
                            Catch ex As Exception
                                File.Delete(strPath)
                            End Try


                            CLS.fnExecuteQuery(strQ)


                        End If
                    ElseIf Request.QueryString("helpId") = 2 Then

                        strPath = Server.MapPath("..\") & "HomePageBroucher\" & fn
                        ViewState("FilePath") = strPath
                        If File.Exists(strPath) Then
                            lblMessage.Text = "File already exists."
                            lblMessage.ForeColor = Drawing.Color.Red
                            Exit Sub
                        Else

                            Try


                                FileUpload1.PostedFile.SaveAs(strPath)
                                If dschk.Tables(0).Rows.Count > 0 Then
                                    strPath1 = dschk.Tables(0).Rows(0)("HelpDeskFilepath").ToString
                                    strPath2 = dschk.Tables(0).Rows(0)("BroucherFilepath").ToString
                                    strPath3 = dschk.Tables(0).Rows(0)("CalendarFilepath").ToString

                                    filepath = Server.MapPath("..\") & "HomePageBroucher\" & strPath2
                                    If File.Exists(filepath) Then
                                        File.Delete(filepath)
                                    End If
                                    strQ = "update HelpDeskBroucher set CourseId=" & cid & ",HelpDeskFilepath='" & Trim(strPath1) & "',CalendarFilepath='" & Trim(strPath3) & "',BroucherFilepath='" & Trim(fn) & "' where courseid=" & cid
                                Else
                                    strQ = "insert into HelpDeskBroucher(CourseId,BroucherFilepath) values(" & cid & ",'" & Trim(fn) & "')"
                                End If



                                CLS.fnExecuteQuery(strQ)
                            Catch ex As Exception
                                File.Delete(strPath)
                            End Try

                        End If
                    ElseIf Request.QueryString("helpId") = 3 Then
                        strPath = Server.MapPath("..\") & "HomePageCalendar\" & fn
                        ViewState("FilePath") = strPath
                        If File.Exists(strPath) Then
                            lblMessage.Text = "File already exists."
                            lblMessage.ForeColor = Drawing.Color.Red
                            Exit Sub
                        Else
                            Try


                                FileUpload1.PostedFile.SaveAs(strPath)
                                If dschk.Tables(0).Rows.Count > 0 Then
                                    strPath1 = dschk.Tables(0).Rows(0)("HelpDeskFilepath").ToString
                                    strPath2 = dschk.Tables(0).Rows(0)("BroucherFilepath").ToString
                                    strPath3 = dschk.Tables(0).Rows(0)("CalendarFilepath").ToString

                                    filepath = Server.MapPath("..\") & "HomePageCalendar\" & strPath3
                                    If File.Exists(filepath) Then
                                        File.Delete(filepath)
                                    End If
                                    strQ = "update HelpDeskBroucher set CourseId=" & cid & ",HelpDeskFilepath='" & Trim(strPath1) & "',BroucherFilepath='" & Trim(strPath2) & "',CalendarFilepath='" & Trim(fn) & "' where courseid=" & cid
                                Else
                                    strQ = "insert into HelpDeskBroucher(CourseId,CalendarFilepath) values(" & cid & ",'" & Trim(fn) & "')"
                                End If
                            Catch ex As Exception
                                File.Delete(strPath)
                            End Try


                            CLS.fnExecuteQuery(strQ)

                        End If

                    End If
                    BindGrid()
                    'Response.Redirect("ListCourseHelp.aspx")

                Catch Exc As Exception
                    Response.Write("Error: " & Exc.Message)
                End Try
            Else
                lblMessage.Text = "Please select a file to upload."
                lblMessage.ForeColor = Drawing.Color.Red
            End If

        Catch ex As Exception
        End Try

    End Sub

   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        Dim cid As String
        cid = Request.QueryString("cid")
        If Request.QueryString("helpId") = 1 Then
            lblTitle.Text = "FAQ"
        ElseIf Request.QueryString("helpId") = 2 Then
            lblTitle.Text = "Brouchure"
        ElseIf Request.QueryString("helpId") = 3 Then
            lblTitle.Text = "Calendar"
        End If
        FillData()
        BindGrid()
    End Sub

    Sub FillData()
        Dim cid As String
        cid = Request.QueryString("cid")
        Try
            Dim strq As String = "select * from Course where courseid=" & cid
            Dim dsData As New DataSet()
            dsData = CLS.fnQuerySelectDs(strq)
            If dsData IsNot Nothing Then
                If dsData.Tables IsNot Nothing Then
                    If dsData.Tables(0).Rows IsNot Nothing Then
                        If dsData.Tables(0).Rows.Count > 0 Then
                            txtTitle.Text = dsData.Tables(0).Rows(0)("CourseTitle").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ListCourseHelp.aspx")
    End Sub
    Sub BindGrid()

        Try
            Dim strq As String = "select cs.*,br.HelpDeskFilepath,br.BroucherFilepath,br.CalendarFilepath from coursedetails cs INNER JOIN HelpDeskBroucher br on br.courseid=cs.courseid"

            Dim dsNews As New DataSet()
            dsNews = CLS.fnQuerySelectDs(strq)
            If dsNews IsNot Nothing Then
                If dsNews.Tables IsNot Nothing Then
                    If dsNews.Tables(0).Rows IsNot Nothing Then
                        If dsNews.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsNews
                            GrdStudent.DataBind()

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
End Class
