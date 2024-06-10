
Partial Class Admin_ListEvent
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
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub
    Sub BindGrid()
        Try
            Dim strq As String = "select EventId,EventTitle,EventDesc,CONVERT(varchar, EventDate, 101) as EventDate from Event"
            Dim dsEvent As New DataSet()
            dsEvent = CLS.fnQuerySelectDs(strq)
            If dsEvent IsNot Nothing Then
                If dsEvent.Tables IsNot Nothing Then
                    If dsEvent.Tables(0).Rows IsNot Nothing Then
                        If dsEvent.Tables(0).Rows.Count > 0 Then
                            GrdEvent.DataSource = dsEvent
                            GrdEvent.DataBind()
                            GrdEvent.Visible = True
                        Else
                            GrdEvent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub
    Protected Sub GrdEvent_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "Delete" Then
            Dim id As Integer = Convert.ToInt32(e.CommandArgument)
            Dim str As String = "delete from Event where EventId=" & id
            ExeNQcomsp(str)
            BindGrid()
            lblMessage.Text = "Record deleted successfully"
            lblMessage.ForeColor = Drawing.Color.DarkGreen
        End If

    End Sub
    Protected Sub GrdEvent_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)
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


    Protected Sub GrdEvent_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdEvent.PageIndexChanging
        GrdEvent.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub
End Class
