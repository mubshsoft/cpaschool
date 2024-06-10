
Partial Class Admin_PaymentReport
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');")
            If Not IsPostBack Then
                MyCLS.ConOpen()
                ViewState("chk") = 1
                'FillDDl()

                bindgrid()
                FillCourse()
                MyCLS.ConClose()
            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub FillCourse()
        Dim strq As String = "select distinct(cs.courseid),cs.coursetitle from PaymentDetails p INNER JOIN  Course cs on cs.courseid=p.courseid"
        Dim dsCourse As New DataSet()
        dsCourse = CLS.fnQuerySelectDs(strq)
        If (dsCourse.Tables(0).Rows.Count > 0) Then

            ddlCourse.DataTextField = "coursetitle"
            ddlCourse.DataValueField = "courseid"

            ddlCourse.DataSource = dsCourse

            ddlCourse.DataBind()
            ddlCourse.Items.Insert(0, "--SELECT--")
        End If

    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
    End Sub
    Sub bindgrid()
        Try
            
            'Dim strq As String = "select DDNo,Amount,CONVERT(varchar(25), DDdate, 101) as DDdate,CONVERT(varchar(25), DateOfPayment, 101) as DateOfPayment,stid,Courseid from PaymentDetails"
            Dim strq As String = "select p.Id,p.DDNo,p.Amount,CONVERT(varchar(25), p.DDdate, 101) as DDdate,CONVERT(varchar(25), p.DateOfPayment, 101) as DateOfPayment,p.stid,p.Courseid,(st.firstname +''+ st.lastname) as fullname,st.email from PaymentDetails p INNER JOIN student st on st.stid=p.stid"
            Dim dsPayment As New DataSet()
            dsPayment = CLS.fnQuerySelectDs(strq)
            If dsPayment IsNot Nothing Then
                If dsPayment.Tables IsNot Nothing Then
                    If dsPayment.Tables(0).Rows IsNot Nothing Then
                        If dsPayment.Tables(0).Rows.Count > 0 Then
                            GrdPayment.DataSource = dsPayment
                            GrdPayment.DataBind()

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub bindgrid1()
        Try
           
            Dim strq As String = "select DDNo,Amount,CONVERT(varchar(25), DDdate, 101) as DDdate,CONVERT(varchar(25), DateOfPayment, 101) as DateOfPayment,stid,Courseid from PaymentDetails"
            Dim dsPayment As New DataSet()
            dsPayment = CLS.fnQuerySelectDs(strq)
            If dsPayment IsNot Nothing Then
                If dsPayment.Tables IsNot Nothing Then
                    If dsPayment.Tables(0).Rows IsNot Nothing Then
                        If dsPayment.Tables(0).Rows.Count > 0 Then
                            GrdPayment.DataSource = dsPayment
                            GrdPayment.DataBind()

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdPayment_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdPayment.PageIndex = e.NewPageIndex
        If ViewState("chk") = 1 Then
            bindgrid()
        Else
            bindgrid1()
        End If
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        Dim d1, d2 As String
        d1 = txtFromDate.Text
        d2 = txtToDate.Text

        If Len(txtFromDate.Text) > 0 Then

        Else
            lblMessage.Text = "From Date cannot be left blank"
        End If

        If Len(txtToDate.Text) > 0 Then

        Else
            lblMessage.Text = "To Date cannot be left blank"
        End If
        Try

            Dim strq As String = "select p.Id,p.DDNo,p.Amount,CONVERT(varchar(25), p.DDdate, 101) as DDdate,CONVERT(varchar(25), p.DateOfPayment, 101) as DateOfPayment,p.stid,p.Courseid,(st.firstname +''+ st.lastname) as fullname,st.email from PaymentDetails p INNER JOIN student st on st.stid=p.stid where (DateOfPayment between CONVERT(varchar(25), '" & d1 & "', 101) and CONVERT(varchar(25), '" & d2 & "', 101)) and courseid=" & ddlCourse.SelectedValue & ""

            Dim dsPayment As New DataSet()
            dsPayment = CLS.fnQuerySelectDs(strq)
            If dsPayment IsNot Nothing Then
                If dsPayment.Tables IsNot Nothing Then
                    If dsPayment.Tables(0).Rows IsNot Nothing Then
                        If dsPayment.Tables(0).Rows.Count > 0 Then
                            GrdPayment.DataSource = dsPayment
                            GrdPayment.DataBind()

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnback.Click
        Response.Redirect("../Report/ReportList.aspx")
    End Sub
End Class
