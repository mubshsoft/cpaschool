
Partial Class DetailsNewsEvents
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        BindNews()
        ' BindEvents()
    End Sub

    Sub BindNews()
        Dim DSNews As New DataSet()
        DSNews = CLS.ExecuteCLSSP("SP_GetNewsandEvent")
        'Dim strq As String = "select NewsDesc,newsdate from News where NewsType='General' "
        'DSNews = CLS.fnQuerySelectDs(strq)
        rptNews.DataSource = dsNews
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
