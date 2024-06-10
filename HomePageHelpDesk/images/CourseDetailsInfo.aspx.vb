
Partial Class CourseDetailsInfo
    Inherits System.Web.UI.Page
    Dim cid As Integer
    Dim dsDetails As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not IsPostBack Then
                cid = Request.QueryString("cid")
                BindData()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub BindData()
        Try

            Dim strQ As String
            strQ = "select *from coursedetails where CourseId=" & Request.QueryString("cid")
            dsDetails = CLS.fnQuerySelectDs(strQ)
            If dsDetails IsNot Nothing Then
                If dsDetails.Tables IsNot Nothing Then
                    If dsDetails.Tables(0).Rows IsNot Nothing Then
                        If dsDetails.Tables(0).Rows.Count > 0 Then
                            lblHeading.Text = dsDetails.Tables(0).Rows(0)("CourseName").ToString
                            lblText1.Text = dsDetails.Tables(0).Rows(0)("Text1").ToString
                            'lblText2.Text = dsDetails.Tables(0).Rows(0)("Text2").ToString
                            'lblText3.Text = dsDetails.Tables(0).Rows(0)("Text3").ToString
                            'lblText4.Text = dsDetails.Tables(0).Rows(0)("Text4").ToString
                        End If
                    End If
                End If
            End If
          

        Catch ex As Exception
        End Try
    End Sub
End Class
