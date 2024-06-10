Imports System.IO
Partial Class Admin_AddModule
    Inherits System.Web.UI.Page
    Dim cid As Integer
    Dim semid As Integer
    Dim strCourseCode As String
    Dim strSemestertitle As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        

        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        cid = Request.QueryString("id")
        semid = Request.QueryString("semid")

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Dim i As Integer
        Dim strModuleTitle As String
        Dim arrModuletitle() As String
        Dim nToModule As Integer
        Dim nfromModule As Integer
        Dim strQ As String
        Try
            nToModule = txtNoOfModule.Text
            Dim dschkModule As New DataSet
            'fetch last module title and increment into 1
            dschkModule = CLS.fnQuerySelectDs("select ModuleTitle from module where moduleid=(select max(moduleid) from module where semid=" & semid & ")")
            If dschkModule IsNot Nothing Then
                If dschkModule.Tables IsNot Nothing Then
                    If dschkModule.Tables(0).Rows IsNot Nothing Then
                        If dschkModule.Tables(0).Rows.Count > 0 Then
                            strModuleTitle = dschkModule.Tables(0).Rows(0)(0).ToString()
                            arrModuletitle = strModuleTitle.Split(" ")
                            nfromModule = arrModuletitle(1)


                            Dim dsCourseTitle As New DataSet
                         
                            dsCourseTitle = CLS.fnQuerySelectDs("select coursecode,semestertitle from course" & _
                                                                  " inner join semester on " & _
                                                                  " course.courseid=semester.courseid" & _
                                                                  " where semester.courseid=" & cid & " and semester.semid=" & semid)

                            strCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString
                            strSemestertitle = dsCourseTitle.Tables(0).Rows(0)("semestertitle").ToString

                            For i = (nfromModule + 1) To (nfromModule + nToModule)

                                Try
                                    Dim strPath As String
                                    strPath = Server.MapPath("../") & "upload/" & strCourseCode & "/" & strSemestertitle & "/Module " & i
                                    Directory.CreateDirectory(strPath)

                                    strQ = "insert into module(semid,ModuleTitle) values(" & semid & ",'Module " & i & "')"
                                    CLS.fnExecuteQuery(strQ)
                                Catch ex As Exception

                                End Try



                            Next
                        Else
                            Dim dsCourseTitle As New DataSet
                            dsCourseTitle = CLS.fnQuerySelectDs("select coursecode,semestertitle from course" & _
                                                                  " inner join semester on " & _
                                                                  " course.courseid=semester.courseid" & _
                                                                  " where semester.courseid=" & cid & " and semester.semid=" & semid)


                            If dsCourseTitle IsNot Nothing Then
                                If dsCourseTitle.Tables IsNot Nothing Then
                                    If dsCourseTitle.Tables(0).Rows IsNot Nothing Then
                                        If dsCourseTitle.Tables(0).Rows.Count > 0 Then
                                            strCourseCode = dsCourseTitle.Tables(0).Rows(0)("coursecode").ToString
                                            strSemestertitle = dsCourseTitle.Tables(0).Rows(0)("semestertitle").ToString
                                            For i = 1 To nToModule
                                                Try
                                                    Dim strPath As String
                                                    strPath = Server.MapPath("../") & "upload/" & strCourseCode & "/" & strSemestertitle & "/Module " & i
                                                    Directory.CreateDirectory(strPath)
                                                    strQ = "insert into module(semid,ModuleTitle) values(" & semid & ",'Module " & i & "')"
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
                            Else

                            End If
            Response.Write("<script>window.opener.location.reload(); self.close();</script>")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClose.Click
        ' Response.Write("<script>window.opener.location.reload(); self.close();</script>")
        Response.Write("<script>self.close();</script>")
        'Response.Redirect("addsemester.aspx?id=" & cid & "&semid=" & semid & "&ed=1")
    End Sub
End Class
