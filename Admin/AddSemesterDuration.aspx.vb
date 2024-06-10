Imports System.IO
Partial Class Admin_AddSemesterDuration
    Inherits System.Web.UI.Page
    Dim intNoOfSemester As Integer
    Dim cid As Integer
    Dim monthDiff As Integer
    Dim StartDate As DateTime
    Dim EndDate As DateTime
    Dim txt As New TextBox
    Dim y As Integer
    Dim m As Integer
    Dim strSemId As Integer
    Dim noOfSem As Integer


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnSave.Click
        Try
            Dim intColCount As Integer = intNoOfSemester
            Dim calMonths As Integer
            For clIndex As Integer = 0 To intColCount - 1
                Dim aa As String = Request("txt_" & (clIndex + 1).ToString())
                If Len(aa) > 0 Then
                    Try
                        If IsNumeric(CInt(aa)) = True Then
                            calMonths = calMonths + aa
                           
                        Else
                            lblMessage.Text = "Please enter numeric value in semester duration. "
                            Exit Sub
                        End If
                    Catch ex As Exception
                        lblMessage.Text = "Please enter numeric value in semester duration "
                        Exit Sub
                    End Try
                Else
                    lblMessage.Text = "Semester duration cannot be left blank "
                    Exit Sub
                End If
               
            Next


            'If calMonths = m Then
            'Else

            '    lblMessage.Text = "Semester Duration not valid. "
            '    Exit Sub
            'End If


            Dim dsCourseTitle As New DataSet
            Dim strCourseTitle As String

            dsCourseTitle = CLS.fnQuerySelectDs("select courseCode,noOfSem from course where courseid=" & Request.QueryString("cid"))
            strCourseTitle = dsCourseTitle.Tables(0).Rows(0)("courseCode").ToString
            noOfSem = dsCourseTitle.Tables(0).Rows(0)("noOfSem").ToString

            For clIndex As Integer = 0 To intColCount - 1
                Dim aa As String = Request("txt_" & (clIndex + 1).ToString())


                Dim dsSem As New DataSet
                dsSem = CLS.fnQuerySelectDs("select SemId from semester where CourseId=" & Request.QueryString("cid") & " and Semestertitle='Semester " & clIndex + 1 & "'")
                strSemId = dsSem.Tables(0).Rows(0)(0).ToString
                Dim strq As String = "INSERT INTO courseSemDuration([SemesterTitle],[Semesterduration],[semId]) VALUES('Semester " & clIndex + 1 & "'," & aa & "," & strSemId & ")"
                CLS.fnExecuteQuery(strq)
            Next
            Response.Redirect("AddSemester.aspx?cid=" & cid)
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Len(Session("username")) <= 0 Then
                Response.Redirect("../login.aspx")
            Else
                If Session("role") = "Admin" Then
                Else
                    Response.Redirect("../login.aspx")
                End If
            End If


            intNoOfSemester = Request.QueryString("dt")
            cid = Request.QueryString("cid")
            'Dim tblHead As New Table()
            GetDateDiff()
            For i As Integer = 1 To intNoOfSemester
                'Dim txt As New TextBox()
                txt = New TextBox
                Dim lbl As New Label()
                txt.ID = "txt_" & i.ToString()
                txt.CssClass = "style11"
                lbl.Text = "Duration of Semester : " & i.ToString()
                lbl.Width = Unit.Percentage(110)
                'txt.Width = Unit.Percentage(18)
                txt.EnableViewState = True
                ''txt.Text = "Sem : " & i.ToString()
               
                Dim rH As New TableRow()
                Dim cH As New TableCell()
                cH.Width = 150
                cH.Text = "Table Heading"
                Dim cH1 As New TableCell()
                cH1.Text = "Table Heading"

                ''''''''''''''''
                Dim lblmonth As New Label()
                lblmonth.Text = "(in months)"
                lblmonth.Width = Unit.Percentage(80)
                Dim cH2 As New TableCell()
                cH2.Width = 90
                cH2.HorizontalAlign = HorizontalAlign.Left

                cH2.Text = "Table Heading"

                '''''''''''''''''

                rH.Controls.Add(cH)
                rH.Controls.Add(cH1)
                rH.Controls.Add(cH2)
                'AddHandler txt.PreRender, AddressOf Me.txt_PreRender
                MyTable.Rows.Add(rH)
                'tblHead.Rows.Add(rH)
                'Panel1.Controls.Add(lbl)
                'Panel1.Controls.Add(New LiteralControl("<br>"))
                'Panel2.Controls.Add(txt)
                'Panel2.EnableViewState = True
                cH.Controls.Add(lbl)
                cH1.Controls.Add(txt)
                cH2.Controls.Add(lblmonth)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GetDateDiff()
        Try
           
            Dim strGetData As String = "select cStartDate,cEndDate from Course where CourseId= " & cid
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                StartDate = Convert.ToDateTime(ds.Tables(0).Rows(0)("cStartDate").ToString())
                EndDate = Convert.ToDateTime(ds.Tables(0).Rows(0)("cEndDate").ToString())
            End If
            y = EndDate.Year - StartDate.Year
            m = EndDate.Month - StartDate.Month
            m += y * 12
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnBack.Click
        Dim ds As New DataSet
        Dim cou As Integer
        ds = CLS.fnQuerySelectDs("select count(courseid)as courseid from feedetails where courseid=" & Request.QueryString("cid"))
        cou = ds.Tables(0).Rows(0)("courseid").ToString
        'Response.Redirect("AddFeeAndSemesterDuration.aspx?Cid=" & Request.QueryString("courseIDFEE") & "&semid=" & semid & "&amt=" & txtPay.Text)
        Response.Redirect("AddFeeAndSemesterDuration.aspx?dt=" & cou & "&cid=" & Request.QueryString("cid") & "&feedit=" & 1)
    End Sub
End Class
