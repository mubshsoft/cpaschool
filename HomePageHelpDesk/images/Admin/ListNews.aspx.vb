
Partial Class Admin_ListNews
    Inherits System.Web.UI.Page

    

    Protected Sub GrdNews_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdNews.PageIndex = e.NewPageIndex
        If (ViewState("chk") = 1) Then
            BindGrid()
        End If

    End Sub

    Sub BindGrid()

        Try
            Dim strq As String = "select * from news"
            Dim dsNews As New DataSet()
            dsNews = CLS.fnQuerySelectDs(strq)
            If dsNews IsNot Nothing Then
                If dsNews.Tables IsNot Nothing Then
                    If dsNews.Tables(0).Rows IsNot Nothing Then
                        If dsNews.Tables(0).Rows.Count > 0 Then
                            GrdNews.DataSource = dsNews
                            GrdNews.DataBind()
                            GrdNews.Visible = True
                        Else
                            GrdNews.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

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
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub
    Protected Sub GrdNews_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)
        If e.CommandName = "Delete" Then
            Dim id As Integer = Convert.ToInt32(e.CommandArgument)
            Dim str As String = "delete from news where Newsid=" & id
            ExeNQcomsp(str)
            BindGrid()
            lblMessage.Text = "Record deleted successfully"
            lblMessage.ForeColor = Drawing.Color.DarkGreen
        End If

    End Sub
    Protected Sub GrdNews_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

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
