Imports System.IO
Partial Class Admin_AddPaper
    Inherits System.Web.UI.Page
    Dim mid As Integer
    Dim semid As Integer
    Dim Ccode As String
    Dim Stitle As String
    Dim Mtitle As String
    Dim Ptitle As String
    Dim paperid As Integer
    Dim moduleid As Integer
    Dim strSemesterTitle As String
    Dim StrCourseCode As String
    Dim strModuleTitle As String
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
            mid = Request.QueryString("Mid")
            semid = Request.QueryString("Semid")
            paperid = Request.QueryString("paperID")
            moduleid = Request.QueryString("ModuleId")
        Catch ex As Exception
        End Try
        If Request.QueryString("paperID") IsNot Nothing Then
            If Request.QueryString("ModuleId").ToString() <> "" Then
                lblMsgPaper.Text = "Edit Paper"
            End If
        Else
            lblMsgPaper.Text = "Add Paper"
        End If

        If Not IsPostBack Then
            If Request.QueryString("paperID") IsNot Nothing Then
                If Request.QueryString("ModuleId").ToString() <> "" Then
                    FillData(Request.QueryString("paperID").ToString(), Request.QueryString("ModuleId").ToString())
                End If
            End If

        End If
    End Sub
    Private Sub FillData(ByVal paperID As String, ByVal ModuleID As String)
        Try
            Dim strGetData As String = "select * from Paper where paperID=" & Integer.Parse(paperID) & " and ModuleId=" & Integer.Parse(ModuleID) & ""
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                txtPaperTitle.Text = ds.Tables(0).Rows(0)("PaperTitle").ToString()

            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        If Len(Request.QueryString("paperID")) > 0 Then
            Try
                If Request.QueryString("ModuleId").ToString() <> "" Then
                    Try


                        Dim dspaperTitle As New DataSet
                        dspaperTitle = CLS.fnQuerySelectDs("select * from paper where papertitle='" & Trim(txtPaperTitle.Text) & "'")

                        If dspaperTitle IsNot Nothing Then
                            If dspaperTitle.Tables IsNot Nothing Then
                                If dspaperTitle.Tables(0).Rows IsNot Nothing Then
                                    If dspaperTitle.Tables(0).Rows.Count > 0 Then
                                        lblMessage.Text = "Paper title already exist"
                                        Exit Sub
                                    End If
                                End If
                            End If
                        End If

                        GetData(moduleid, paperid)
                        Dim strPath As String = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Ptitle
                        Dim strPath1 As String
                        strPath1 = Server.MapPath("..\") & "upload\" & Ccode & "\" & Stitle & "\" & Mtitle & "\" & Trim(txtPaperTitle.Text)
                        'If Directory.Exists(strPath1) = False Then
                        '    Directory.CreateDirectory(strPath1)
                        'End If

                       
                        If strPath <> strPath1 Then
                            ' for update folder solution 
                            Response.Cookies("un").Value = Session("username").ToString()
                            Response.Cookies("un").Expires.AddDays(1)
                            Response.Cookies("r").Value = Session("role").ToString()
                            Response.Cookies("r").Expires.AddDays(1)

                            Directory.Move(strPath, strPath1)
                            'MyCLS.RecursiveCopyFiles(strPath, strPath1, True)
                            ' Directory.Delete(strPath, True)
                        End If


                        Dim strUpdate As String = "update paper set PaperTitle='" & txtPaperTitle.Text & "' where PaperID=" & paperid & " and ModuleId=" & moduleid
                        CLS.fnExecuteQuery(strUpdate)
                        Response.Write("<script>window.opener.location.reload(); self.close();</script>")
                        'Else
                        'lblMessage.Text = "Paper title already exist"
                        'Exit Sub
                        'End If
                    Catch ex As Exception

                    End Try
                End If
            Catch ex As Exception

            End Try
        ElseIf Len(Request.QueryString("Mid")) > 0 Then
            Dim strQ As String
            Try
                If fnValidate() = True Then

                    Try
                        Dim dsCourseTitle As New DataSet
                        dsCourseTitle = CLS.fnQuerySelectDs("select coursecode,semestertitle,moduletitle from course inner join semester on " & _
                                                                " course.courseid = semester.courseid " & _
                                                                " inner join module on semester.semid=module.semid " & _
                                                                " where semester.semid =" & semid & " And moduleid =" & mid)

                        If dsCourseTitle IsNot Nothing Then
                            If dsCourseTitle.Tables IsNot Nothing Then
                                If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
                                    If dsCourseTitle.Tables(0).Rows.Count > 0 Then
                                        StrCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString
                                        strSemesterTitle = dsCourseTitle.Tables(0).Rows(0)("semestertitle").ToString
                                        strModuleTitle = dsCourseTitle.Tables(0).Rows(0)("Moduletitle").ToString

                                        Try

                                            Dim strPath As String
                                            strPath = Server.MapPath("..\") & "upload\" & StrCourseCode & "\" & strSemesterTitle & "\" & strModuleTitle & "\" & Trim(txtPaperTitle.Text)
                                            Directory.CreateDirectory(strPath)
                                            strQ = "insert into paper(ModuleId,PaperTitle) values(" & mid & ",'" & Trim(txtPaperTitle.Text) & "')"
                                            CLS.fnExecuteQuery(strQ)
                                        Catch ex As Exception

                                        End Try

                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                    Response.Write("<script>window.opener.location.reload(); self.close();</script>")
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClose.Click
        Response.Write("<script>self.close();</script>")
    End Sub

    Function fnValidate() As Boolean
        Try
            If Len(txtPaperTitle.Text) <= 0 Then
                lblMessage.Text = "Paper title cannot be left blank"
                Return False
            End If

            Dim dscheck As New DataSet
            Dim strq As String
            strq = "select * from paper where papertitle='" & Trim(txtPaperTitle.Text) & "' and moduleid=" & mid
            dscheck = CLS.fnQuerySelectDs(strq)
            If dscheck IsNot Nothing Then
                If dscheck.Tables IsNot Nothing Then
                    If dscheck.Tables(0).Rows IsNot Nothing Then
                        If dscheck.Tables(0).Rows.Count > 0 Then
                            lblMessage.Text = "Paper title already exist"
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
End Class
