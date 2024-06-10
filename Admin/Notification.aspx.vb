
Partial Class Notification
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindNews()
        If Request.QueryString("ntid") IsNot Nothing Then
            CLS.fnExecuteQuery("update [dbo].tblUserNotification set nstatus=0 where ntid=" & Request.QueryString("ntid").ToString())
        End If



        ' BindEvents()
    End Sub

    Sub BindNews()
        Dim DS As New DataSet()
        Try
            If Request.QueryString("ntid") IsNot Nothing Then
                If Request.QueryString("typ") IsNot Nothing Then
                    Dim str As String = "select descr as subject , ndate, descr as body,'admin' as sendfrom,id from [dbo].tblUserNotification where userid=" & Session("stid").ToString() & " and ntid=" & Request.QueryString("ntid") & " and mailtype='" & Request.QueryString("typ").ToString() & "'"
                    If (Request.QueryString("typ").ToString().ToLower() = "course material" Or Request.QueryString("typ").ToString().ToLower() = "exam") Then
                        str = "select subject ,CreateDate as ndate, body,sendfrom,id from Notifications where id=" & Request.QueryString("ntid")
                    ElseIf Request.QueryString("typ").ToString().ToLower() = "reminder mail" Then
                        str = "select subject ,CreateDate as ndate, body,sendfrom,id from mails where id=" & Request.QueryString("ntid")
                    ElseIf Request.QueryString("typ").ToString().ToLower() = "video conference" Then
                        str = "select subject ,CreateDate as ndate, body,sendfrom,id from VideoConfrence where id=" & Request.QueryString("ntid")
                    ElseIf Request.QueryString("typ").ToString().ToLower() = "event" Then
                        str = "select eventtitle as subject,eventdate as ndate, EventDesc as body ,'admin' as sendfrom,eventid as id from event where id=" & Request.QueryString("ntid")
                    End If
                    DS = CLS.fnQuerySelectDs(str)
                    If DS IsNot Nothing Then
                        If DS.Tables IsNot Nothing Then
                            If DS.Tables(0).Rows IsNot Nothing Then
                                If DS.Tables(0).Rows.Count > 0 Then
                                    lblbody.Text = DS.Tables(0).Rows(0)("body").ToString()
                                    lblsubject.Text = DS.Tables(0).Rows(0)("subject").ToString()
                                    lblfrom.Text = DS.Tables(0).Rows(0)("sendfrom").ToString()
                                    lbldate.Text = DS.Tables(0).Rows(0)("ndate").ToString()
                                End If
                            End If
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Response.Write(ex.InnerException)

        End Try
       



        'rptNews.DataSource = DSNews
        'rptNews.DataBind()
    End Sub

    'Sub BindEvents()
    '    Dim strq As String = "select * from event"
    '    Dim dsEvents As New DataSet()
    '    dsEvents = CLS.fnQuerySelectDs(strq)
    '    rptEvents.DataSource = dsEvents
    '    rptEvents.DataBind()
    'End Sub
End Class
