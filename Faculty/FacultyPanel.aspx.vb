
Partial Class FacultyPanel
    Inherits System.Web.UI.Page
    'Protected dsFacNews As New DataSet
    Protected strnews As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If

    End Sub

    'Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton12.Click
    '    Dim strq As String = "select Fid from FacultyRegistration where email='" & Session("username") & "'"
    '    Dim dsFac As New DataSet()
    '    dsFac = CLS.fnQuerySelectDs(strq)
    '    Dim fid As Integer = CInt(dsFac.Tables(0).Rows(0)("Fid").ToString())
    '    Dim strq1 As String = "select max(FacultyLogId) as FacultyLogId from FacultyLoginHistory where Fid=" & fid & ""
    '    Dim dsFac1 As New DataSet()
    '    dsFac1 = CLS.fnQuerySelectDs(strq1)
    '    Dim LogId As Integer = CInt(dsFac1.Tables(0).Rows(0)("FacultyLogId").ToString())
    '    Dim strLogin As String = "update FacultyLoginHistory set LoginOut='" & System.DateTime.Now & "', Status=0 where FacultyLogId=" & LogId
    '    CLS.fnExecuteQuery(strLogin)
    '    Response.Redirect("../logout.aspx")
    'End Sub

    Public Function AddSpace(ByVal totChar As Integer, ByVal chrStr As String) As String
        Dim retValue As String = "     "
        For i As Integer = 0 To totChar - 2
            retValue += chrStr
        Next
        Return retValue
    End Function
End Class
