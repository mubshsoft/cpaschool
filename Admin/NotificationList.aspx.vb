
Partial Class NotificationList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindNews()
        ' BindEvents()
        If Request.QueryString("ntid") IsNot Nothing Then
            CLS.fnExecuteQuery("update [dbo].tblUserNotification set nstatus=0 ")
        End If

    End Sub

    Sub BindNews()
        Dim DSNews As New DataSet()
        Dim str As String = "select * from [dbo].tblUserNotification where userid =" & Session("stid").ToString() & " order by ndate desc"

        DSNews = CLS.fnQuerySelectDs(str)
      
        rptNews.DataSource = DSNews
        rptNews.DataBind()
    End Sub

    'Sub BindEvents()
    '    Dim strq As String = "select * from event"
    '    Dim dsEvents As New DataSet()
    '    dsEvents = CLS.fnQuerySelectDs(strq)
    '    rptEvents.DataSource = dsEvents
    '    rptEvents.DataBind()
    'End Sub
End Class
