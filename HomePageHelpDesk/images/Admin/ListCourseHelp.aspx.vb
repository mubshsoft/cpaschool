
Partial Class Admin_ListCourseHelp
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
            'Dim strq As String = "select *from course"

            Dim strq As String = "select cs.*,isnull(br.HelpDeskFilepath,'') as HelpDeskFilepath,isnull(br.BroucherFilepath,'') as BroucherFilepath,isnull(br.CalendarFilepath,'') as CalendarFilepath from course cs LEFT OUTER JOIN HelpDeskBroucher br on br.courseid=cs.courseid"
            Dim dsNews As New DataSet()
            dsNews = CLS.fnQuerySelectDs(strq)
            If dsNews IsNot Nothing Then
                If dsNews.Tables IsNot Nothing Then
                    If dsNews.Tables(0).Rows IsNot Nothing Then
                        If dsNews.Tables(0).Rows.Count > 0 Then
                            GrdCourse.DataSource = dsNews
                            GrdCourse.DataBind()
                            GrdLinkChange()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub GrdCourse_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdCourse.PageIndex = e.NewPageIndex
      
        BindGrid()
    End Sub

    Protected Sub GrdCourse_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdCourse.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        If row.DataItem Is Nothing Then
            Exit Sub
        End If

     

       
       
    End Sub


    Private Sub GrdLinkChange()
        Try
            Dim lblHelpDesk As LinkButton
            Dim lblBroucher As LinkButton
            Dim lblCalendar As LinkButton
            Dim hdHelpDesk As HiddenField
            Dim hdHBroucher As HiddenField
            Dim hdHCalendar As HiddenField
            For Each cc1 As GridViewRow In GrdCourse.Rows
                lblHelpDesk = CType(cc1.FindControl("lblHelpDesk"), LinkButton)
                lblBroucher = CType(cc1.FindControl("lblBroucher"), LinkButton)
                lblCalendar = CType(cc1.FindControl("lblCalendar"), LinkButton)

                hdHelpDesk = CType(cc1.FindControl("hdHelpDesk"), HiddenField)
                hdHBroucher = CType(cc1.FindControl("hdHBroucher"), HiddenField)
                hdHCalendar = CType(cc1.FindControl("hdHCalendar"), HiddenField)

                If hdHelpDesk.Value.Trim = "" Then
                    lblHelpDesk.ForeColor = Drawing.Color.Black
                Else

                    lblHelpDesk.ForeColor = Drawing.Color.Red
                End If
                If hdHBroucher.Value.Trim = "" Then
                    lblBroucher.ForeColor = Drawing.Color.Black
                Else

                    lblBroucher.ForeColor = Drawing.Color.Red
                End If
                If hdHCalendar.Value.Trim = "" Then
                    lblCalendar.ForeColor = Drawing.Color.Black
                Else

                    lblCalendar.ForeColor = Drawing.Color.Red
                End If


            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdCourse_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdCourse.RowCommand
        Dim gv As GridView = DirectCast(sender, GridView)
        Dim id As Integer = Convert.ToInt32(e.CommandArgument)
        'Dim hdnCourseId As HiddenField = DirectCast(gv.Rows(id).FindControl("hd1"), HiddenField)
        If e.CommandName = "HelpDesk" Then
            Response.Redirect("DeskBroucher.aspx?cid=" & id & "&helpId=1")
        ElseIf e.CommandName = "Broucher" Then
            Response.Redirect("DeskBroucher.aspx?cid=" & id & "&helpId=2")
        ElseIf e.CommandName = "Calendar" Then
            Response.Redirect("DeskBroucher.aspx?cid=" & id & "&helpId=3")
        End If
        
    End Sub
End Class
