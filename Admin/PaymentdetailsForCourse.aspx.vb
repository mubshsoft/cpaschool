
Partial Class Admin_PaymentdetailsForCourse
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        bindgrid()
    End Sub

    Sub bindgrid()
        Try
         
            ' Dim strq As String = "select DDNo,Amount,DDdate,paymentdetails.Courseid,CourseTitle,semester.semestertitle from paymentdetails INNER JOIN Course on paymentdetails.Courseid=Course.Courseid INNER JOIN semester on semester.SemId=paymentdetails.SemId where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid")
            Dim strq As String = "select id,DDNo,Amount,DDdate,paymentdetails.Courseid,CourseTitle from paymentdetails INNER JOIN Course on paymentdetails.Courseid=Course.Courseid where  paymentdetails.stid=" & Request.QueryString("stid") & " and  paymentdetails.courseid=" & Request.QueryString("courseid")
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            If dsbatch IsNot Nothing Then
                If dsbatch.Tables IsNot Nothing Then
                    If dsbatch.Tables(0).Rows IsNot Nothing Then
                        If dsbatch.Tables(0).Rows.Count > 0 Then
                            Grdpayment.DataSource = dsbatch
                            Grdpayment.DataBind()
                            Grdpayment.Visible = True
                        Else
                            lblMessage.Text = "No Payment"
                            Grdpayment.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
