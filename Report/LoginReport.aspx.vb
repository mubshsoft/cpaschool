
Partial Class Admin_LoginReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        If Not IsPostBack Then

            BindGrid()
        End If
    End Sub
    Sub BindGrid()

        Try
            'Dim strq As String = "select lh.*,(st.firstName+' '+st.lastName) as firstName from StudentLoginHistory lh INNER JOIN Student st on lh.stid=st.stid"
            Dim strq As String = "select lh.StuLogId,lh.stid,lh.LoginFrom,CONVERT(varchar, lh.LoginDate, 101) as LoginDate,Convert(char(2),DATEPART(hour, LoginDate)) + ':'+convert(char(2),datepart(mi,LoginDate)) as LoginTime,lh.LoginOut,lh.Status,(st.firstName+' '+st.lastName) as Name from StudentLoginHistory lh INNER JOIN Student st on lh.stid=st.stid"
            Dim dsLogin As New DataSet()
            dsLogin = CLS.fnQuerySelectDs(strq)
            If dsLogin IsNot Nothing Then
                If dsLogin.Tables IsNot Nothing Then
                    If dsLogin.Tables(0).Rows IsNot Nothing Then
                        If dsLogin.Tables(0).Rows.Count > 0 Then
                            GrdLoginReport.DataSource = dsLogin
                            GrdLoginReport.DataBind()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub GrdLoginReport_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdLoginReport.RowDataBound
        Try
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            ' Make sure we aren't in header/footer rows 
            If row.DataItem Is Nothing Then
                Exit Sub
            End If

            'Find Child GridView control 
            Dim gv As New HiddenField
            gv = DirectCast(row.FindControl("hd1"), HiddenField)

            Dim lbl12 As New Label
            lbl12 = DirectCast(row.FindControl("lbl"), Label)


            If (gv.Value = "True") Then
                lbl12.Text = "*"
                lbl12.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdLoginReport_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdLoginReport.RowCommand
        If e.CommandName = "Delete" Then
            Dim id As Integer = Convert.ToInt32(e.CommandArgument)
            Dim str As String = "delete from StudentLoginHistory where StuLogId=" & id
            ExeNQcomsp(str)
            BindGrid()
            lblMessage.Text = "Record deleted successfully"
            lblMessage.ForeColor = Drawing.Color.DarkGreen
        End If
    End Sub
    Protected Sub GrdLoginReport_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

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
End Class
