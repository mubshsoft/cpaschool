
Partial Class Student_ChangePassword
    Inherits System.Web.UI.Page
    Dim UserName As String
    Dim pwd As String
    Dim str As String

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (ViewState("pd") = txtOld.Text) Then
            If Request.QueryString("chstudent") IsNot Nothing Then
                str = "update Student set password='" & txtNew.Text & "' where email='" & Session("username") & "' "
            ElseIf Request.QueryString("chfaculty") IsNot Nothing Then
                str = "update FacultyRegistration set password='" & txtNew.Text & "' where email='" & Session("username") & "' "
            Else

            End If
            ExeNQcomsp(str)
            Dim strsql As String = "update login set password='" & txtNew.Text & "' where username='" & Session("username") & "' "
            ExeNQcomsp(strsql)

            type()
        Else
            lblMessage.Text = "Wrong password"
        End If
    End Sub
    Sub type()
        If Request.QueryString("chstudent") IsNot Nothing Then

            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Password changed successfully!'); location.href='StudentPanel.aspx' ;</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Password changed successfully!'); location.href='StudentDashboard.aspx' ;", True)
        ElseIf Request.QueryString("chfaculty") IsNot Nothing Then
            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Password changed successfully!'); location.href='../faculty/Facultypanel.aspx' ;</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Password changed successfully!'); location.href='../faculty/Facultypanel.aspx' ;", True)
        ElseIf Request.QueryString("chadmin") IsNot Nothing Then
            'ClientScript.RegisterStartupScript([GetType](), "Message", "<SCRIPT LANGUAGE='javascript'>alert('Password changed successfully!'); location.href='../admin/AdminLogin.aspx' ;</script>")
            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Password changed successfully!'); location.href='../admin/AdminLogin.aspx' ;", True)
        Else

        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        If Not IsPostBack Then
            GetData()
        End If

        'If Request.QueryString("chstudent") IsNot Nothing Then
        '    SHeader1.Visible = True
        'ElseIf Request.QueryString("chfaculty") IsNot Nothing Then
        '    FHeader1.Visible = True
        '    'lnkBackToPannel.InnerText = "Back To faculty Panel"
        'ElseIf Request.QueryString("chadmin") IsNot Nothing Then
        '    AHeader1.Visible = True
        '    'lnkBackToPannel.InnerText = "Back To admin Panel"
        'Else

        'End If

    End Sub

    Private Sub GetData()
        Dim strq As String = "select password,type from login where username='" & Session("username") & "' "
        Dim ds As New DataSet()
        ds = CLS.fnQuerySelectDs(strq)
        pwd = ds.Tables(0).Rows(0)("password").ToString()
        ViewState("pd") = ds.Tables(0).Rows(0)("password").ToString()
        ViewState("type") = ds.Tables(0).Rows(0)("type").ToString()
    End Sub
    Public Shared Sub ExeNQcomsp(ByVal strQ As String)

        Try
            CLS.ConOpen()
            CLS.fnExecuteQuery(strQ)
            CLS.ConClose()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    'Protected Sub lnkBackToPannel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkBackToPannel.Click
    '    If Request.QueryString("chstudent") IsNot Nothing Then
    '        Response.Redirect("StudentPanel.aspx")
    '    ElseIf Request.QueryString("chfaculty") IsNot Nothing Then
    '        Response.Redirect("../faculty/Facultypanel.aspx")
    '    ElseIf Request.QueryString("chadmin") IsNot Nothing Then
    '        Response.Redirect("../admin/AdminLogin.aspx")
    '    Else

    '    End If


    'End Sub

   
    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If Request.QueryString("chstudent") IsNot Nothing Then
            Response.Redirect("StudentDashboard.aspx")
        ElseIf Request.QueryString("chfaculty") IsNot Nothing Then
            Response.Redirect("../faculty/Facultypanel.aspx")
        ElseIf Request.QueryString("chadmin") IsNot Nothing Then
            Response.Redirect("../admin/AdminLogin.aspx")
        Else

        End If
    End Sub
End Class
