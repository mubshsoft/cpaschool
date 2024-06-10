
Partial Class DownloadHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGrid()
            chkColumnVisible()
        End If
     
    End Sub

    Sub BindGrid()

        Try
            Dim val As String
            If Request.QueryString("HelpDesk") = 1 Then
                val = "HelpDeskFilepath"
            ElseIf Request.QueryString("HelpDesk") = 2 Then
                val = "BroucherFilepath"
            ElseIf Request.QueryString("HelpDesk") = 3 Then
                val = "CalendarFilepath"
            End If
            Dim strq As String = "select cs.*,isnull(br.HelpDeskFilepath,'') as HelpDeskFilepath,isnull(br.BroucherFilepath,'') as BroucherFilepath,isnull(br.CalendarFilepath,'') as CalendarFilepath from course cs RIGHT OUTER JOIN HelpDeskBroucher br on br.courseid=cs.courseid where " & val & " is not null"
            'Dim strq As String = "select cs.*,isnull(br.HelpDeskFilepath,'') as HelpDeskFilepath,isnull(br.BroucherFilepath,'') as BroucherFilepath,isnull(br.CalendarFilepath,'') as CalendarFilepath from course cs RIGHT OUTER JOIN HelpDeskBroucher br on br.courseid=cs.courseid where " & val & " <> ''"

            Dim dsNews As New DataSet()
            dsNews = CLS.fnQuerySelectDs(strq)
            If dsNews IsNot Nothing Then
                If dsNews.Tables IsNot Nothing Then
                    If dsNews.Tables(0).Rows IsNot Nothing Then
                        If dsNews.Tables(0).Rows.Count > 0 Then
                            GrdHome.DataSource = dsNews
                            GrdHome.DataBind()

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub chkColumnVisible()
        Try

            For Each cc1 As GridViewRow In GrdHome.Rows


                If Request.QueryString("HelpDesk") = 1 Then
                    GrdHome.Columns(3).Visible = True
                    GrdHome.Columns(4).Visible = False
                    GrdHome.Columns(5).Visible = False
                    lblHeading.Text = "Frequently Asked Questions"

                ElseIf Request.QueryString("HelpDesk") = 2 Then
                    GrdHome.Columns(3).Visible = False
                    GrdHome.Columns(4).Visible = True
                    GrdHome.Columns(5).Visible = False
                    lblHeading.Text = "Brochure"

                ElseIf Request.QueryString("HelpDesk") = 3 Then
                    GrdHome.Columns(3).Visible = False
                    GrdHome.Columns(4).Visible = False
                    GrdHome.Columns(5).Visible = True
                    lblHeading.Text = "Calendar"

                End If

            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnback.Click
        Response.Redirect("Default-new.aspx")
    End Sub
End Class
