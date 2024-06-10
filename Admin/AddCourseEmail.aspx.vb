
Partial Class AddCourseEmail
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If


        If (Request.QueryString("dt") = "0") Then
            btnSave.Visible = False
        Else
            btnSave.Visible = True

        End If







    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Response.Redirect("AddFeeAndSemesterDuration.aspx?dt=" & Request.QueryString("dt") & "&cid=" & Request.QueryString("courseid"))
    End Sub
End Class
