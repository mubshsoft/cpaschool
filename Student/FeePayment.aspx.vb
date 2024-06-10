
Partial Class Student_FeePayment
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        FillData()

    End Sub

    Sub FillData()

        Dim stNationality As String

        Dim strq As String
        Dim dsFee As New DataSet()
        Dim dsChkStatus As New DataSet()
        Try


            Dim strNationality As String = "select * from student where stid=" & Session("stid")
            Dim DsStudentNationlityType As New DataSet()
            DsStudentNationlityType = CLS.fnQuerySelectDs(strNationality)
            If DsStudentNationlityType.Tables(0).Rows.Count > 0 Then
                stNationality = DsStudentNationlityType.Tables(0).Rows(0)("nationality").ToString
            End If


            Dim str As String = "select * from Feedetails where type='One Time Fee' and CourseId=" & Request.QueryString("courseIDFEE") & ""
            Dim DsType As New DataSet()
            DsType = CLS.fnQuerySelectDs(str)
            If DsType.Tables(0).Rows.Count > 0 Then
                If stNationality.ToLower.ToString = "india" Then
                    strq = "select sr.stid,sr.courseid,f.type,f.fee,f.applicantcategory from studentRegCourse sr Inner join FeeDetails f on sr.courseid=f.courseid inner join  student st on sr.stid=st.stid where sr.stid=" & Session("stid") & " and f.courseid=" & Request.QueryString("courseIDFEE") & "  and f.applicantcategory=st.applicantcategory and f.nationality='Indian'"
                Else
                    strq = "select sr.stid,sr.courseid,f.type,f.fee,f.applicantcategory from studentRegCourse sr Inner join FeeDetails f on sr.courseid=f.courseid inner join  student st on sr.stid=st.stid where sr.stid=" & Session("stid") & " and f.courseid=" & Request.QueryString("courseIDFEE") & "  and f.applicantcategory=st.applicantcategory and f.nationality='Others'"
                End If
            Else
                If stNationality.ToLower.ToString = "india" Then
                    strq = "select sr.stid,sr.courseid,f.type,f.fee from studentRegCourse sr Inner join studentsemester ss on sr.stid=ss.stid and sr.courseid=ss.courseid Inner join FeeDetails f on ss.semid=f.semid inner join  student st on sr.stid=st.stid where sr.stid=" & Session("stid") & " and ss.currentStatus=2 and f.courseid=" & Request.QueryString("courseIDFEE") & " and f.applicantcategory=st.applicantcategory and f.nationality='Indian'"
                Else
                    strq = "select sr.stid,sr.courseid,f.type,f.fee from studentRegCourse sr Inner join studentsemester ss on sr.stid=ss.stid and sr.courseid=ss.courseid Inner join FeeDetails f on ss.semid=f.semid inner join  student st on sr.stid=st.stid where sr.stid=" & Session("stid") & " and ss.currentStatus=2 and f.courseid=" & Request.QueryString("courseIDFEE") & " and f.applicantcategory=st.applicantcategory and f.nationality='Others'"
                End If

            End If

            If stNationality.ToLower.ToString = "india" Then
                lblfeecurrency.Text = "(in INR)"
            Else
                lblfeecurrency.Text = "(in $)"
            End If

            dsFee = CLS.fnQuerySelectDs(strq)

            Dim str1 As String = "select * from studentsemester where currentStatus=2 and feestatus=0 and stid=" & Session("stid") & " and courseid=" & Request.QueryString("courseIDFEE") & ""
            dsChkStatus = CLS.fnQuerySelectDs(str1)
            If dsChkStatus.Tables(0).Rows.Count > 0 Then
                'lblFee.Text = dsFee.Tables(0).Rows(0)("fee").ToString

                ' changed on 23 nov (wahid)
                Dim str2 As String = "select * from PaymentDetails where stid=" & Session("stid") & " and semid=0 and courseid=" & Request.QueryString("courseIDFEE")
                Dim DsChkPay As New DataSet()
                DsChkPay = CLS.fnQuerySelectDs(str2)
                If DsChkPay.Tables(0).Rows.Count > 0 Then
                    lblFee.Text = 0
                    txtPay.Enabled = False
                    btnPay.Visible = False
                    lblMessage.Text = "No Payment Due"
                Else
                    lblFee.Text = dsFee.Tables(0).Rows(0)("fee").ToString
                    ViewState("applicantcategory") = dsFee.Tables(0).Rows(0)("applicantcategory").ToString
                End If
                ' changed on 23 nov (wahid)
            Else
                'table1.Visible = False
                lblFee.Text = 0
                txtPay.Enabled = False
                btnPay.Visible = False
                lblMessage.Text = "No Payment Due"
            End If


        Catch ex As Exception
        End Try
    End Sub

   

    Protected Sub btnPay_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPay.Click
        Try
            Dim semid As Integer
            Dim fee As Integer
            Dim str As String
            Dim strq As String = "select * from Feedetails where  CourseId=" & Request.QueryString("courseIDFEE")
            Dim DsType1 As New DataSet()
            DsType1 = CLS.fnQuerySelectDs(strq)
            If DsType1.Tables(0).Rows(0)("type") = "One Time Fee" Then
                str = "select * from Feedetails where  CourseId=" & Request.QueryString("courseIDFEE") & "And applicantcategory='" & ViewState("applicantcategory") & "'"
            Else
                str = "select * from studentsemester ss inner JOIN Feedetails f on f.courseid=ss.courseid and f.semid=ss.semid where stid=" & Session("stid") & " and currentStatus=2 and ss.CourseId=" & Request.QueryString("courseIDFEE")
            End If




            Dim DsType As New DataSet()
            DsType = CLS.fnQuerySelectDs(str)
            fee = DsType.Tables(0).Rows(0)("fee").ToString
            If DsType.Tables(0).Rows.Count > 0 Then
                If txtPay.Text <> fee Then
                    lblMessage.Text = "Incorrect Amount"
                    Exit Sub
                End If

                If DsType.Tables(0).Rows(0)("type") = "One Time Fee" Then
                    'Response.Redirect("PaymentDetails.aspx?Cid=" & Request.QueryString("courseIDFEE") & "&amt=" & txtPay.Text)
                    Response.Redirect("PaymentMode.aspx?Cid=" & Request.QueryString("courseIDFEE") & "&amt=" & txtPay.Text)
                Else
                    semid = DsType.Tables(0).Rows(0)("semid").ToString
                    'Response.Redirect("PaymentDetails.aspx?Cid=" & Request.QueryString("courseIDFEE") & "&semid=" & semid & "&amt=" & txtPay.Text)
                    Response.Redirect("PaymentMode.aspx?Cid=" & Request.QueryString("courseIDFEE") & "&semid=" & semid & "&amt=" & txtPay.Text)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("ListCourseForFee.aspx")
    End Sub
End Class
