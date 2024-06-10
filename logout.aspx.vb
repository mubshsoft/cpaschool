
Partial Class logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Session("role") = "Faculty" Then
                Dim strq As String = "select Fid from FacultyRegistration where email='" & Session("username") & "'"
                Dim dsFac As New DataSet()
                dsFac = CLS.fnQuerySelectDs(strq)
                Dim fid As Integer = CInt(dsFac.Tables(0).Rows(0)("Fid").ToString())
                Dim strq1 As String = "select max(FacultyLogId) as FacultyLogId from FacultyLoginHistory where Fid=" & fid & ""
                Dim dsFac1 As New DataSet()
                dsFac1 = CLS.fnQuerySelectDs(strq1)
                Dim LogId As Integer = CInt(dsFac1.Tables(0).Rows(0)("FacultyLogId").ToString())
                Dim strLogin As String = "update FacultyLoginHistory set LoginOut='" & System.DateTime.Now & "', Status=0 where FacultyLogId=" & LogId
                CLS.fnExecuteQuery(strLogin)
            End If
        Catch ex As Exception

        End Try


        Session.Abandon()
        Session("role") = ""
        Session("username") = ""
        Session("userEmail") = ""
        Session("userFullName") = ""
        Response.Cookies("un").Value = ""
        Response.Cookies("r").Value = ""
        Response.Cookies("un").Expires = DateTime.Now.AddDays(-1)
        Response.Cookies("r").Expires = DateTime.Now.AddDays(-1)
        If Request.Cookies("un") IsNot Nothing Then
            Session("username") = Request.Cookies("un").Value
        End If

        Response.Redirect("login.aspx")

    End Sub
End Class
