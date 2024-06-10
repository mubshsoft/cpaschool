Imports System.IO
Partial Class Admin_AddNewSemester
    Inherits System.Web.UI.Page
    Dim cid As Integer
    Dim Ccode As String
    Dim Ctitle As String
    Dim strSemesterTitle As String
    Dim StrCourseCode As String
    Dim LastSemid As Integer
    Dim Stuid As Integer
    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClose.Click
        Response.Write("<script>self.close();</script>")
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
        cid = Request.QueryString("Courseid")
       

        
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        'Dim nFromSemester As Integer
        'Dim nToSemester As Integer
        'Dim arrSemestertitle() As String
        'Dim StrSemestertitle As String
        'Dim i As Integer
        'If fnValidate() = True Then
        '    nToSemester = txtNoOfSemester.Text
        '    Dim DsChkSemester As New DataSet
        '    DsChkSemester = CLS.fnQuerySelectDs("select SemesterTitle from semester where SemID=(select max(SemID) from  semester where CourseId=" & cid & ")")
        '    If DsChkSemester IsNot Nothing Then
        '        If DsChkSemester.Tables(0).Rows IsNot Nothing Then
        '            If DsChkSemester.Tables(0).Rows.Count > 0 Then
        '                strSemesterTitle = DsChkSemester.Tables(0).Rows(0)(0).ToString()
        '                arrSemestertitle = StrSemestertitle.Split(" ")
        '                nFromSemester = arrSemestertitle(1)
        '            End If
        '        End If
        '    End If
        '    Try
        '        Dim dsCourseTitle As New DataSet
        '        dsCourseTitle = CLS.fnQuerySelectDs("select * from Course where CourseId=" & Request.QueryString("Courseid"))

        '        If dsCourseTitle IsNot Nothing Then
        '            If dsCourseTitle.Tables IsNot Nothing Then
        '                If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
        '                    If dsCourseTitle.Tables(0).Rows.Count > 0 Then
        '                        StrCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString

        '                        For i = (nFromSemester + 1) To (nFromSemester + nToSemester)
        '                            Try

        '                                Dim strPath As String
        '                                strPath = Server.MapPath("../") & "upload/" & StrCourseCode & "/" & "/Semester " & i
        '                                Directory.CreateDirectory(strPath)
        '                                Dim strQ As String = "insert into Semester(CourseId,SemesterTitle) values(" & cid & ",'Semester " & i & "')"
        '                                CLS.fnExecuteQuery(strQ)
        '                            Catch ex As Exception

        '                            End Try
        '                        Next
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Catch ex As Exception
        '    End Try
        '    Response.Write("<script>window.opener.location.reload(); self.close();</script>")
        'End If
        Dim nFromSemester As Integer
        Dim nToSemester As Integer
        Dim arrSemestertitle() As String
        Dim StrSemestertitle As String
        Dim i As Integer

        nToSemester = txtNoOfSemester.Text
        Dim DsChkSemester As New DataSet
        DsChkSemester = CLS.fnQuerySelectDs("select SemesterTitle from semester where SemID=(select max(SemID) from  semester where CourseId=" & cid & ")")
        If DsChkSemester IsNot Nothing Then
            If DsChkSemester.Tables(0).Rows IsNot Nothing Then
                If DsChkSemester.Tables(0).Rows.Count > 0 Then
                    StrSemestertitle = DsChkSemester.Tables(0).Rows(0)(0).ToString()
                    arrSemestertitle = StrSemestertitle.Split(" ")
                    nFromSemester = arrSemestertitle(1)

                    Dim dsCourseTitle As New DataSet
                    dsCourseTitle = CLS.fnQuerySelectDs("select * from Course where CourseId=" & Request.QueryString("Courseid"))

                    If dsCourseTitle IsNot Nothing Then
                        If dsCourseTitle.Tables IsNot Nothing Then
                            If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
                                If dsCourseTitle.Tables(0).Rows.Count > 0 Then
                                    StrCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString

                                    For i = (nFromSemester + 1) To (nFromSemester + nToSemester)
                                        Try

                                            Dim strPath As String
                                            strPath = Server.MapPath("../") & "upload/" & StrCourseCode & "/" & "/Semester " & i
                                            Directory.CreateDirectory(strPath)
                                            Dim strQ As String = "insert into Semester(CourseId,SemesterTitle) values(" & cid & ",'Semester " & i & "')"
                                            CLS.fnExecuteQuery(strQ)

                                            ' change on 30 Nov

                                            Dim LastSem As String

                                            Dim dsSem As New DataSet
                                            LastSem = "select max(SemId) as semid from semester where courseid=" & cid & ""
                                            dsSem = CLS.fnQuerySelectDs(LastSem)
                                            LastSemid = dsSem.Tables(0).Rows(0)("semid").ToString()


                                            ''''''''''''''''''''''
                                            Dim j As Integer
                                            Dim Studentid As String
                                            Dim strQ1 As String

                                            Dim dsStd As New DataSet
                                            Studentid = "select distinct(stid) as stid from studentsemester where courseid=" & cid & ""
                                            dsStd = CLS.fnQuerySelectDs(Studentid)
                                            If dsStd IsNot Nothing Then
                                                If dsStd.Tables IsNot Nothing Then
                                                    If dsStd.Tables(0).Rows IsNot Nothing Then
                                                        If dsStd.Tables(0).Rows.Count > 0 Then
                                                            For j = 0 To dsStd.Tables(0).Rows.Count - 1
                                                                Stuid = dsStd.Tables(0).Rows(j)("stid").ToString
                                                                strQ1 = "insert into studentsemester(stid,CourseId,semid,currentStatus,passStatus,feestatus,promoteStatus) values(" & Stuid & "," & cid & "," & LastSemid & ",0,0,0,0)"
                                                                CLS.fnExecuteQuery(strQ1)
                                                            Next
                                                        End If
                                                    End If
                                                End If
                                            End If


                                            'change on 30 Nov
                                        Catch ex As Exception

                                        End Try
                                    Next
                                End If
                            End If
                        End If
                    End If
                    'change on 30 Nov

                    Dim dsSemCount As New DataSet
                    Dim StrSemcount As Integer

                    Dim StrCourseUpd As String

                    dsSemCount = CLS.fnQuerySelectDs("select count(Semid) as count  from semester where courseid=" & cid & "")
                    StrSemcount = dsSemCount.Tables(0).Rows(0)("count").ToString

                    StrCourseUpd = "update course set noOfSem=" & StrSemcount & " where courseid=" & cid & ""
                    CLS.fnExecuteQuery(StrCourseUpd)

                    'change on 30 Nov
                Else
                    Dim dsCourseTitle As New DataSet
                    dsCourseTitle = CLS.fnQuerySelectDs("select * from Course where CourseId=" & Request.QueryString("Courseid"))

                    If dsCourseTitle IsNot Nothing Then
                        If dsCourseTitle.Tables IsNot Nothing Then
                            If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
                                If dsCourseTitle.Tables(0).Rows.Count > 0 Then
                                    StrCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString

                                    For i = 1 To nToSemester
                                        Try

                                            Dim strPath As String
                                            strPath = Server.MapPath("../") & "upload/" & StrCourseCode & "/" & "/Semester " & i
                                            Directory.CreateDirectory(strPath)
                                            Dim strQ As String = "insert into Semester(CourseId,SemesterTitle) values(" & cid & ",'Semester " & i & "')"
                                            CLS.fnExecuteQuery(strQ)
                                        Catch ex As Exception

                                        End Try
                                    Next
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Response.Write("<script>window.opener.location.reload(); self.close();</script>")
    End Sub

    Private Sub GetData(ByVal CourseID As String)
        Try
            Dim strGetData As String = "select *from Course where CourseID=" & CourseID
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                Ccode = ds.Tables(0).Rows(0)("CourseCode").ToString()

                
            End If
        Catch ex As Exception
        End Try
    End Sub
    Function fnValidate() As Boolean
        Try
            If Len(txtNoOfSemester.Text) <= 0 Then
                lblMessage.Text = "Semester cannot be left blank"
                Return False
            End If

            Dim dscheck As New DataSet
            Dim strq As String
            strq = "select * from Semester where SemesterTitle='" & Trim(txtNoOfSemester.Text) & "' "
            dscheck = CLS.fnQuerySelectDs(strq)
            If dscheck IsNot Nothing Then
                If dscheck.Tables IsNot Nothing Then
                    If dscheck.Tables(0).Rows IsNot Nothing Then
                        If dscheck.Tables(0).Rows.Count > 0 Then
                            lblMessage.Text = "Semester Title already exist"
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

    
End Class
