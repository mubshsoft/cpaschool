Imports fmsf.DAL
Imports fmsf.lib
Partial Class Student_PaymentDetails
    Inherits System.Web.UI.Page
    Dim objLibPayment As New LIBPayment
    Dim objDalPayment As New DalAddPayment
    Dim objLibErr As New libErrorMsg

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click

        Try
            objLibErr = fnvalidate()
            If objLibErr.ChkReturn = True Then
                objLibPayment.DDNo = Trim(txtDDNumber.Text)
                objLibPayment.Amount = Trim(txtAmt.Text)
                objLibPayment.DDdate = Trim(txtDDDate.Text)
                objLibPayment.stid = Session("stid")
                objLibPayment.CourseId = Request.QueryString("Cid")


                Dim str As String
                If Request.QueryString("semid") IsNot Nothing Then
                    objLibPayment.SemId = Request.QueryString("semid")
                    str = "select * from PaymentDetails where  CourseId=" & Request.QueryString("Cid") & " and SemId=" & ViewState("semid") & " and stid=" & Session("stid")
                Else
                    objLibPayment.SemId = 0
                    str = "select * from PaymentDetails where  CourseId=" & Request.QueryString("Cid") & " and stid=" & Session("stid")
                End If

                Dim DsType As New DataSet()
                DsType = CLS.fnQuerySelectDs(str)
                If DsType.Tables(0).Rows.Count > 0 Then
                    lblMessage.Text = "Payment already submitted"
                    Exit Sub
                Else
                    Dim retVal As Int16 = objDalPayment.InsertPayment(objLibPayment)
                    Response.Redirect("StudentPanel.aspx")
                End If



                'If retVal = 1 Then
                '    lblMessage.Text = "Payment Added successfully"
                'End If
                'If retVal = -11 Then
                '    lblMessage.Text = "Event already  exist"
                '    Exit Sub
                'ElseIf retVal = -3 Then
                '    lblMessage.Text = "Event already  exist"
                '    Exit Sub
                'ElseIf retVal = 1 Then
                '    Response.Redirect("ListEvent.aspx")
                'ElseIf retVal = 2 Then
                '    Response.Redirect("ListEvent.aspx")
                'ElseIf retVal = MyCLS.EStatus.Err Then
                '    MyCLS.fnMSG("Error Occured!")
                'End If
                'Response.Redirect("StudentPanel.aspx")
            Else
                lblMessage.Text = objLibErr.errMessage
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function fnvalidate() As Object
        Dim ObjErrDal As New libErrorMsg
        If Len(Trim(txtDDNumber.Text)) <= 0 Then
            ObjErrDal.errMessage = "DD number cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If
        If Len(Trim(txtAmt.Text)) <= 0 Then
            ObjErrDal.errMessage = "DD Amount cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Len(txtDDDate.Text) > 0 Then
            Dim d As DateTime
            Try
                d = DateTime.Parse(txtDDDate.Text)
            Catch ex As Exception
                ObjErrDal.errMessage = "Invalid date!format should be mm/dd/yyyy"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End Try
        Else
            ObjErrDal.errMessage = "Date cannot be left blank"
        End If


        If Len(txtPaymentDate.Text) > 0 Then
            Dim d As Date
            Try
                d = txtPaymentDate.Text
                If d < Date.Now.Date Then
                    ObjErrDal.errMessage = "Payment Date should be greater than current date."
                    ObjErrDal.ChkReturn = False
                    Return ObjErrDal
                End If
            Catch ex As Exception

            End Try
        End If

        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If

        txtPaymentDate.Text = Date.Now.Date
        txtAmt.Text = Request.QueryString("amt")
        ViewState("semid") = Request.QueryString("semid")

    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnClose.Click
        Response.Redirect("studentpanel.aspx")
    End Sub
End Class
