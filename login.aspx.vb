Imports fmsf.lib
Imports fmsf.DAL
Imports System.Net
Partial Class login
    Inherits System.Web.UI.Page
    Dim StrchkSession As String
    Dim stid As Integer
    Dim fid As Integer
    Dim strHostName As New [String]("")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) > 0 Then
                Try
                    If Session("role") = "Admin" Then
                        Response.Redirect("admin/AdminLogin.aspx")
                    ElseIf Session("role") = "Faculty" Then
                        Response.Redirect("faculty/Facultypanel.aspx")
                    ElseIf Session("role") = "Student" Then
                        'Response.Redirect("student/Studentpanel.aspx")
                        Response.Redirect("student/StudentDashboard.aspx")
                    ElseIf Session("role") = "MobAdmin" Then
                        Response.Redirect("Mob/MobAdminPanel.aspx")
                    End If

                Catch ex As Exception

                End Try
            Else
                CLS.ConOpen()
            End If

           
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUsername.Text.Length = 0 Then
            lblMessage.Text = "Username cannot be left blank"
            Exit Sub
        End If
        If txtPassword.Text.Length = 0 Then
            lblMessage.Text = "Password cannot be left blank"
            Exit Sub
        End If
        getlogin()
    End Sub
    Protected Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        Try
            CLS.ConClose()
        Catch ex As Exception
        End Try
    End Sub

    Sub getlogin()
        'str1 = "select * from logintable where username='Main Admin' and convert(varbinary,password)=convert(varbinary,'main')"
        Dim objLIBLogin As New LibLogin
        objLIBLogin.UserName = txtUsername.Text
        objLIBLogin.Password = txtPassword.Text


        Dim objDalLogin As New DalLogin


        ' str1 = "select * from login where username='" & Trim(objLIBLogin.UserName) & "' and convert(varbinary,password)=convert(varbinary,'" & Trim(objLIBLogin.Password) & "')"
        Dim ds1 As New DataSet
        Try
            'CLS.ConOpen()
            ds1 = objDalLogin.fnValidateLogin(objLIBLogin)
            'ds1 = CLS.fnQuerySelectDs(str1)
            'Dim count As Integer
            'count = ds1.Tables(0).Rows.Count
            If ds1 IsNot Nothing Then
                If ds1.Tables IsNot Nothing Then
                    If ds1.Tables(0).Rows IsNot Nothing Then
                        If ds1.Tables(0).Rows.Count > 0 Then
                            Session.Clear()
                            Session("username") = objLIBLogin.UserName
                            Session("role") = ds1.Tables(0).Rows(0)("type").ToString

                            If ds1.Tables(0).Rows(0)(2).ToString = "Admin" Then
                                Response.Redirect("admin/AdminLogin.aspx")
                            ElseIf ds1.Tables(0).Rows(0)(2).ToString = "Faculty" Then
                                GetFacultyId()
                                LogHistoryForFaculty()
                                Response.Redirect("faculty/Facultypanel.aspx")
                            ElseIf ds1.Tables(0).Rows(0)(2).ToString = "Student" Then
                                GetStudentId()
                                LogHistoryForStudent()
                                ' Response.Redirect("student/Studentpanel.aspx")
                                Response.Redirect("student/StudentDashboard.aspx")
                            ElseIf ds1.Tables(0).Rows(0)(2).ToString = "MobAdmin" Then
                                Response.Redirect("Mob/MobAdminPanel.aspx")
                            End If
                        Else
                            lblMessage.Text = "Login failed!"
                            lblMessage.CssClass = "redcss"
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        Finally
            'CLS.ConClose()
        End Try
    End Sub

    Private Sub GetStudentId()
        Try
            Dim strq As String = "select stid from Student where email='" & txtUsername.Text & "'"
            Dim dsStid As New DataSet()
            dsStid = CLS.fnQuerySelectDs(strq)
            stid = CInt(dsStid.Tables(0).Rows(0)("stid").ToString())
            Session("stid") = stid
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LogHistoryForStudent()
        Try
            Dim strHostName As String = System.Net.Dns.GetHostName()
            Dim clientIPAddress As String = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString()

            Session("datetim") = System.DateTime.Now
            Session("IPADD") = clientIPAddress

            Dim strLogin As String = "insert into StudentLoginHistory(stid,LoginFrom,LoginDate,Status)values(" & stid & ",'" & clientIPAddress & "','" & Session("datetim") & "',1) "
            CLS.fnExecuteQuery(strLogin)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetFacultyId()
        Try
            Dim strq As String = "select Fid from FacultyRegistration where email='" & txtUsername.Text & "'"
            Dim dsCaculty As New DataSet()
            dsCaculty = CLS.fnQuerySelectDs(strq)
            fid = CInt(dsCaculty.Tables(0).Rows(0)("Fid").ToString())
            Session("fid") = fid
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LogHistoryForFaculty()
        Try
            Dim strHostName As String = System.Net.Dns.GetHostName()
            Dim clientIPAddress As String = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString()
            Session("datetim") = System.DateTime.Now
            Session("IPADD") = clientIPAddress

            Dim strLogin As String = "insert into FacultyLoginHistory(Fid,LoginFrom,LoginDate,Status)values(" & fid & ",'" & clientIPAddress & "','" & Session("datetim") & "',1) "
            CLS.fnExecuteQuery(strLogin)


        Catch ex As Exception
        End Try

    End Sub

    
   
    Protected Sub btnlostPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlostPassword.Click
        Response.Redirect("default.aspx")
    End Sub

End Class
