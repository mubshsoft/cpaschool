Imports System.IO
Partial Class Admin_AddFeeAndSemesterDuration
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


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim intColCount As Integer

        Dim dsCourseTitle As New DataSet
        Dim strCourseTitle As String

        dsCourseTitle = CLS.fnQuerySelectDs("select courseCode,noOfSem from course where courseid=" & Request.QueryString("cid"))
        strCourseTitle = dsCourseTitle.Tables(0).Rows(0)("courseCode").ToString
        noOfSem = dsCourseTitle.Tables(0).Rows(0)("noOfSem").ToString


        'fetch noof semster if in edit mode or in insertion mode
        If Request.QueryString("feedit") IsNot Nothing Then
            Dim ds As New DataSet
            Dim cou As Integer
            'ds = CLS.fnQuerySelectDs("select count(courseid)as courseid from feedetails where courseid=" & Request.QueryString("cid"))
            ds = CLS.fnQuerySelectDs("select count(distinct(s.SemId)) as SemId from semester s left JOIN feedetails f on f.courseid=s.courseid where s.courseid=" & Request.QueryString("cid"))
            cou = ds.Tables(0).Rows(0)("SemId").ToString
            intColCount = cou
        Else

            intColCount = Request.QueryString("dt")
        End If


        If ddlFeetype.SelectedItem.Text = "Select" Then
            lblMessage.Text = "Please select Fee Type"
            Exit Sub
        End If


        ' start  for validation of fees text box

        If ddlFeetype.SelectedItem.Text = "One Time Fee" Then
            If txtFee.Text.Length = 0 Then
                lblMessage.Text = "Please enter Course fee"
                Exit Sub
            Else
                Try
                    If IsNumeric(txtFee.Text) = True Then

                    Else
                        lblMessage.Text = "Please enter numeric value. "
                        Exit Sub
                    End If
                Catch ex As Exception

                End Try

            End If
        Else
            For clIndex As Integer = 0 To intColCount - 1
                Dim i As String = Request("txt_" & (clIndex + 1).ToString())
                If Len(i) > 0 Then
                    Try
                        If IsNumeric(CInt(i)) = True Then

                        Else
                            lblMessage.Text = "Please enter numeric value. "
                            CreateDyneminTextbox()
                            Exit Sub
                        End If
                    Catch ex As Exception
                        lblMessage.Text = "Please enter numeric value. "
                        CreateDyneminTextbox()
                        Exit Sub
                    End Try
                Else
                    lblMessage.Text = "Fee of Semester cannot be left blank "
                    CreateDyneminTextbox()
                    Exit Sub
                End If

            Next
        End If
        ' end  for validation of fees text box



        Dim courseid As Integer = Request.QueryString("cid")
        ' in edit mode feedit contain data

        If Request.QueryString("feedit") IsNot Nothing Then
            If intColCount > 0 Then
                If ddlFeetype.SelectedItem.Text = "One Time Fee" Then
                    txtFee.Visible = True
                    lblfeeMsg.Visible = True
                    Dim fee As Single = CInt(txtFee.Text.Trim)
                    Dim strq1 As String = "update FeeDetails set Fee=" & fee & " where courseid=" & courseid & " and applicantcategory='" & ddlapplicantCategory.SelectedItem.Text & "' and nationality='" & ddlnationality.SelectedItem.Text & "'"
                    CLS.fnExecuteQuery(strq1)
                Else
                    For clIndex As Integer = 0 To intColCount - 1
                        Dim aa As String = Request("txt_" & (clIndex + 1).ToString())

                        Dim dsSem As New DataSet
                        dsSem = CLS.fnQuerySelectDs("select SemId from semester where CourseId=" & courseid & " and Semestertitle='Semester " & clIndex + 1 & "'")
                        strSemId = dsSem.Tables(0).Rows(0)(0).ToString

                        ' change on 2 dec
                        Dim chksem As String
                        chksem = "select *from FeeDetails where courseid=" & courseid & " and SemId=" & strSemId & " and applicantcategory='" & ddlapplicantCategory.SelectedItem.Text & "' and nationality='" & ddlnationality.SelectedItem.Text & "'"
                        Dim dsChkSem As New DataSet
                        dsChkSem = CLS.fnQuerySelectDs(chksem)
                        'if semester value is missing in feedetail then insert feedetail working otherwise update
                        If dsChkSem.Tables(0).Rows.Count > 0 Then
                            Dim strq As String = "update FeeDetails set Type='Semester wise', Fee=" & aa & " where courseid=" & courseid & " and SemId=" & strSemId & " and applicantcategory='" & ddlapplicantCategory.SelectedItem.Text & "' and nationality='" & ddlnationality.SelectedItem.Text & "'"
                            CLS.fnExecuteQuery(strq)
                        Else
                            Dim strq As String = "INSERT INTO FeeDetails([CourseId],[Type],[SemId],[Fee],[applicantcategory],[nationality]) VALUES(" & courseid & ",'" & ddlFeetype.SelectedItem.Text & "'," & strSemId & "," & aa & ",'" & ddlapplicantCategory.SelectedItem.Text & "','" & ddlnationality.SelectedItem.Text & "')"
                            CLS.fnExecuteQuery(strq)
                        End If
                        ' change on 2 dec
                    Next
                End If
                If Request.QueryString("backlist") IsNot Nothing Then
                    Response.Redirect("AddFeeAndSemesterDuration.aspx?cid=" & courseid & "&feedit=1&backlist=2")
                Else
                    Response.Redirect("AddSemesterDuration.aspx?dt=" & noOfSem & "&cid=" & courseid)
                End If
                'commented by mala on 26 nov

                'Else
                '    Dim count1 As Integer
                '    Dim ds1 As New DataSet
                '    ds1 = CLS.fnQuerySelectDs("select count(courseid) as courseid from semester where courseid=" & Request.QueryString("cid"))
                '    count1 = ds1.Tables(0).Rows(0)("courseid").ToString

                '    If ddlFeetype.SelectedItem.Text = "One Time Fee" Then
                '        txtFee.Visible = True
                '        lblfeeMsg.Visible = True
                '        Dim fe As Single = CInt(txtFee.Text.Trim)
                '        Dim strq1 As String = "INSERT INTO FeeDetails([CourseId],[Type],[Fee],[applicantcategory]) VALUES(" & courseid & ",'" & ddlFeetype.SelectedItem.Text & "'," & fe & ",'" & ddlapplicantCategory.SelectedItem.Text & "')"
                '        CLS.fnExecuteQuery(strq1)
                '    Else

                '        For clIndex As Integer = 0 To count1 - 1
                '            Dim aa As String = Request("txt_" & (clIndex + 1).ToString())

                '            Dim dsSem As New DataSet
                '            dsSem = CLS.fnQuerySelectDs("select SemId from semester where CourseId=" & courseid & " and Semestertitle='Semester " & clIndex + 1 & "'")
                '            strSemId = dsSem.Tables(0).Rows(0)(0).ToString
                '            Dim strq As String = "INSERT INTO FeeDetails([CourseId],[Type],[SemId],[Fee],[applicantcategory]) VALUES(" & courseid & ",'" & ddlFeetype.SelectedItem.Text & "'," & strSemId & "," & aa & ",'" & ddlapplicantCategory.SelectedItem.Text & "')"
                '            CLS.fnExecuteQuery(strq)

                '        Next

                '    End If

                '    Response.Redirect("ListCourse.aspx")
            End If
        Else


            'Dim courseid As Integer = Request.QueryString("cid")
            If ddlFeetype.SelectedItem.Text = "One Time Fee" Then
                txtFee.Visible = True
                lblfeeMsg.Visible = True
                Dim fe As Single = CInt(txtFee.Text.Trim)

                Dim chkfee As String
                chkfee = "select * from FeeDetails where courseid=" & courseid & " and applicantcategory='" & ddlapplicantCategory.SelectedItem.Text & "' and nationality='" & ddlnationality.SelectedItem.Text & "'"
                Dim dsChkfee As New DataSet
                dsChkfee = CLS.fnQuerySelectDs(chkfee)
                If dsChkfee.Tables(0).Rows.Count <= 0 Then
                    Dim strq1 As String = "INSERT INTO FeeDetails([CourseId],[Type],[Fee],[applicantcategory],[nationality]) VALUES(" & courseid & ",'" & ddlFeetype.SelectedItem.Text & "'," & fe & ",'" & ddlapplicantCategory.SelectedItem.Text & "','" & ddlnationality.SelectedItem.Text & "')"
                    CLS.fnExecuteQuery(strq1)
                End If
            Else

                For clIndex As Integer = 0 To intColCount - 1
                    Dim aa As String = Request("txt_" & (clIndex + 1).ToString())

                    Dim dsSem As New DataSet
                    dsSem = CLS.fnQuerySelectDs("select SemId from semester where CourseId=" & courseid & " and Semestertitle='Semester " & clIndex + 1 & "'")
                    strSemId = dsSem.Tables(0).Rows(0)(0).ToString
                    'check for duplicacy
                    Dim chkfee As String
                    chkfee = "select * from FeeDetails where courseid=" & courseid & " and applicantcategory='" & ddlapplicantCategory.SelectedItem.Text & "' and semid=" & strSemId & " and nationality='" & ddlnationality.SelectedItem.Text & "'"
                    Dim dsChkfee As New DataSet
                    dsChkfee = CLS.fnQuerySelectDs(chkfee)
                    'if semester value is missing in feedetail then insert feedetail working otherwise update
                    If dsChkfee.Tables(0).Rows.Count <= 0 Then
                        Dim strq As String = "INSERT INTO FeeDetails([CourseId],[Type],[SemId],[Fee],[applicantcategory],[nationality]) VALUES(" & courseid & ",'" & ddlFeetype.SelectedItem.Text & "'," & strSemId & "," & aa & ",'" & ddlapplicantCategory.SelectedItem.Text & "','" & ddlnationality.SelectedItem.Text & "')"
                        CLS.fnExecuteQuery(strq)
                    End If

                Next

            End If
            ' ddlapplicantCategory.SelectedIndex = 0
            ' ddlnationality.SelectedIndex = 0
            ddlFeetype.SelectedIndex = 0
            txtFee.Text = ""
            '  Response.Redirect("AddSemesterDuration.aspx?dt=" & noOfSem & "&cid=" & courseid)
        End If
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
            If Request.QueryString("feedit") IsNot Nothing Then

                FillDyneminTextbox()



            Else
                If Not IsPostBack Then
                    AddSemester()
                End If
                btnBack.Visible = False
            End If

            'If Not IsPostBack Then
            '    AddSemester()
            'End If


        Catch ex As Exception
        End Try
    End Sub


    Sub AddSemester()
        Try
            Dim intColCount As Integer = intNoOfSemester
            Dim calMonths As Integer

            Dim dsCourseTitle As New DataSet
            Dim strCourseTitle As String

            dsCourseTitle = CLS.fnQuerySelectDs("select courseCode,noOfSem from course where courseid=" & Request.QueryString("cid"))
            strCourseTitle = dsCourseTitle.Tables(0).Rows(0)("courseCode").ToString
            noOfSem = dsCourseTitle.Tables(0).Rows(0)("noOfSem").ToString

            Dim dsSemTitle As New DataSet
            Dim strSem, strSemTitle As String
            strSem = "select *from semester where courseid=" & Request.QueryString("cid")
            dsSemTitle = CLS.fnQuerySelectDs(strSem)
            If dsSemTitle.Tables(0).Rows.Count > 0 Then
            Else
                For clIndex As Integer = 0 To noOfSem - 1
                    Dim aa As String = Request("txt_" & (clIndex + 1).ToString())

                    Dim strq1 As String = "insert into semester([CourseID],[SemesterTitle]) VALUES(" & Request.QueryString("cid") & ",'Semester " & clIndex + 1 & "')"
                    CLS.fnExecuteQuery(strq1)
                    Try

                        Dim strPath As String
                        strPath = Server.MapPath("../") & "upload/" & strCourseTitle & "/Semester " & clIndex + 1
                        Directory.CreateDirectory(strPath)
                    Catch ex As Exception

                    End Try


                Next
            End If

            

        Catch ex As Exception
        End Try
    End Sub
    
    Protected Sub ddlFeetype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFeetype.SelectedIndexChanged

        Dim ds1 As New DataSet
        ds1 = CLS.fnQuerySelectDs("select distinct(type) from feedetails where courseid=" & Request.QueryString("cid"))
        If ds1 IsNot Nothing Then
            If ds1.Tables IsNot Nothing Then
                If ds1.Tables(0).Rows IsNot Nothing Then
                    If ds1.Tables(0).Rows.Count >= 1 Then
                        If (ds1.Tables(0).Rows(0)("type").ToString = ddlFeetype.SelectedItem.Text) Then

                        Else
                            lblMessage.Text = "Fee validation failed.Select one type for one course"

                        End If
                    End If
                End If
            End If

        End If

        If ddlFeetype.SelectedItem.Text = "One Time Fee" Then
            Row1.Visible = True
            txtFee.Visible = True
            lblfeeMsg.Visible = True
            If (ddlnationality.SelectedItem.Text.ToLower = "indian") Then
                lblonetimecur.Text = "(in INR)"
            Else

                lblonetimecur.Text = "(in $)"
            End If
        Else
            Row1.Visible = False
            'txtFee.Visible = False
            'lblfeeMsg.Visible = False
            CreateDyneminTextbox()
        End If
    End Sub

    Sub CreateDyneminTextbox()
        Dim intColCount As Integer
        Dim count1 As Integer
        Dim ds1 As New DataSet
        ds1 = CLS.fnQuerySelectDs("select count(courseid) as courseid from Semester where courseid=" & Request.QueryString("cid"))
        count1 = ds1.Tables(0).Rows(0)("courseid").ToString
        If Request.QueryString("feedit") IsNot Nothing Then
            intColCount = count1
            intNoOfSemester = count1
        Else
            intColCount = intNoOfSemester
            intNoOfSemester = Request.QueryString("dt")
            cid = Request.QueryString("cid")
        End If


        For i As Integer = 1 To intNoOfSemester
            txt = New TextBox
            Dim lbl As New Label()
            txt.ID = "txt_" & i.ToString()
            txt.CssClass = "style11"
            lbl.Text = "Semester Fee : " & i.ToString()
            lbl.Width = Unit.Percentage(110)
            'txt.Width = Unit.Percentage(18)
            txt.EnableViewState = True
            ''txt.Text = "Sem : " & i.ToString()

            Dim rH As New TableRow()
            Dim cH As New TableCell()
            cH.Width = 125
            cH.Text = "Table Heading"
            Dim cH1 As New TableCell()
            cH1.Text = "Table Heading"

            ''''''''''''''''
            Dim lblmonth As New Label()
            If (ddlnationality.SelectedItem.Text.ToLower = "indian") Then
                lblmonth.Text = "(in INR)"
            Else

                lblmonth.Text = "(in $)"
            End If

            lblmonth.Width = Unit.Percentage(50)
            Dim cH2 As New TableCell()
            cH2.Width = 320
            cH2.HorizontalAlign = HorizontalAlign.Left

            cH2.Text = "Table Heading"
            rH.Controls.Add(cH)
            rH.Controls.Add(cH1)
            rH.Controls.Add(cH2)
            MyTable.Rows.Add(rH)
            cH.Controls.Add(lbl)
            cH1.Controls.Add(txt)
            cH2.Controls.Add(lblmonth)
        Next



    End Sub


    Sub FillDyneminTextbox()
        Dim ds As New DataSet
        Dim ds1 As New DataSet
        Dim strType As String
        Dim fee As Integer
        ds1 = CLS.fnQuerySelectDs("select * from feedetails where courseid=" & Request.QueryString("cid") & " and  applicantcategory='" & ddlapplicantCategory.SelectedItem.Text & "' and nationality='" & ddlnationality.SelectedItem.Text & "'")


        'fee = ds.Tables(0).Rows(0)("fee").ToString
        'strType = ds.Tables(0).Rows(0)("Type").ToString

        'If strType = "" Then
        fee = ds1.Tables(0).Rows(0)("fee").ToString
        strType = ds1.Tables(0).Rows(0)("Type").ToString
        'End If


        If strType = "One Time Fee" Then
            Row1.Visible = True
            lblfeeMsg.Visible = True
            txtFee.Visible = True
            ddlFeetype.SelectedIndex = 1
            ddlFeetype.Enabled = False
            txtFee.Text = fee
            ddlapplicantCategory.SelectedItem.Text = ds1.Tables(0).Rows(0)("Applicantcategory").ToString
            ddlnationality.SelectedItem.Text = ds1.Tables(0).Rows(0)("nationality").ToString
            If (ddlnationality.SelectedItem.Text.ToLower = "indian") Then
                lblonetimecur.Text = "(in INR)"
            Else

                lblonetimecur.Text = "(in $)"
            End If
        Else
            ds = CLS.fnQuerySelectDs("select s.CourseId,f.Type,isnull(s.SemId,0),isnull(f.fee,0) as fee   from semester s left JOIN feedetails f on f.courseid=s.courseid and f.semid=s.semid where s.courseid=" & Request.QueryString("cid") & " and  applicantcategory='" & ddlapplicantCategory.SelectedItem.Text & "' and nationality='" & ddlnationality.SelectedItem.Text & "'")
            If ds.Tables.Count > 0 Then
                ddlFeetype.SelectedIndex = 2
                ddlFeetype.Enabled = False
                Dim dsCount As New DataSet
                Dim count As Integer
                'Dim strCount As String = "select count(courseid) as courseid from feedetails where courseid=" & Request.QueryString("cid")
                Dim strCount As String = "select count(distinct(s.SemId)) as Semid from semester s left JOIN feedetails f on f.courseid=s.courseid where s.courseid=" & Request.QueryString("cid")

                dsCount = CLS.fnQuerySelectDs(strCount)
                count = dsCount.Tables(0).Rows(0)("Semid").ToString
                For i As Integer = 1 To count
                    txt = New TextBox
                    Dim lbl As New Label()
                    txt.ID = "txt_" & i.ToString()
                    txt.CssClass = "style11"
                    lbl.Text = "Semester Fee : " & i.ToString()
                    lbl.Width = Unit.Percentage(110)
                    'txt.Width = Unit.Percentage(18)
                    txt.EnableViewState = True
                    'txt.Text = "Sem : " & i.ToString()

                    txt.Text = ds.Tables(0).Rows(i - 1)("fee").ToString
                    Dim rH As New TableRow()
                    Dim cH As New TableCell()
                    cH.Width = 125
                    cH.Text = "Table Heading"
                    Dim cH1 As New TableCell()
                    cH1.Text = "Table Heading"

                    ''''''''''''''''
                    Dim lblmonth As New Label()
                    If (ddlnationality.SelectedItem.Text.ToLower = "indian") Then
                        lblmonth.Text = "(in INR)"
                    Else

                        lblmonth.Text = "(in $)"
                    End If

                    lblmonth.Width = Unit.Percentage(50)
                    Dim cH2 As New TableCell()
                    cH2.Width = 320
                    cH2.HorizontalAlign = HorizontalAlign.Left

                    cH2.Text = "Table Heading"
                    rH.Controls.Add(cH)
                    rH.Controls.Add(cH1)
                    rH.Controls.Add(cH2)
                    MyTable.Rows.Add(rH)
                    cH.Controls.Add(lbl)
                    cH1.Controls.Add(txt)
                    cH2.Controls.Add(lblmonth)
                Next


            End If
        End If
        

    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        If Request.QueryString("feedit") IsNot Nothing Then
            Response.Redirect("ListCourse.aspx")
        Else
        End If
    End Sub

    Protected Sub ddlapplicantCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlapplicantCategory.SelectedIndexChanged
        'Try
        '    Dim ds1 As New DataSet
        '    Dim ds As New DataSet
        '    Dim strType As String
        '    Dim fee As Integer
        '    ds1 = CLS.fnQuerySelectDs("select * from feedetails where courseid=" & Request.QueryString("cid") & " and  applicantcategory='" & ddlapplicantCategory.SelectedItem.Text & "'")

        '    ds = CLS.fnQuerySelectDs("select s.CourseId,f.Type,s.SemId,isnull(f.fee,0) as fee ,f.applicantcategory  from semester s left JOIN feedetails f on f.courseid=s.courseid and f.semid=s.semid where s.courseid=" & Request.QueryString("cid") & "")

        '    fee = ds.Tables(0).Rows(0)("fee").ToString
        '    strType = ds.Tables(0).Rows(0)("Type").ToString
        '    If strType = "" Then
        '        fee = ds1.Tables(0).Rows(0)("fee").ToString
        '        strType = ds1.Tables(0).Rows(0)("Type").ToString
        '    End If
        '    If ds.Tables.Count > 0 Then

        '        If strType = "One Time Fee" Then
        '            Row1.Visible = True
        '            lblfeeMsg.Visible = True
        '            txtFee.Visible = True
        '            ddlFeetype.SelectedIndex = 1
        '            ddlFeetype.Enabled = False
        '            txtFee.Text = fee
        '            ddlapplicantCategory.SelectedItem.Text = ds1.Tables(0).Rows(0)("Applicantcategory").ToString
        '        Else
        '            ddlFeetype.SelectedIndex = 2
        '            ddlFeetype.Enabled = False
        '            Dim dsCount As New DataSet
        '            Dim count As Integer
        '            'Dim strCount As String = "select count(courseid) as courseid from feedetails where courseid=" & Request.QueryString("cid")
        '            Dim strCount As String = "select count(distinct(s.SemId)) as Semid from semester s left JOIN feedetails f on f.courseid=s.courseid where s.courseid=" & Request.QueryString("cid")

        '            dsCount = CLS.fnQuerySelectDs(strCount)
        '            count = dsCount.Tables(0).Rows(0)("Semid").ToString
        '            For i As Integer = 1 To count
        '                txt = New TextBox
        '                Dim lbl As New Label()
        '                txt.ID = "txt_" & i.ToString()
        '                txt.CssClass = "style11"
        '                lbl.Text = "Semester Fee : " & i.ToString()
        '                lbl.Width = Unit.Percentage(110)
        '                'txt.Width = Unit.Percentage(18)
        '                txt.EnableViewState = True
        '                'txt.Text = "Sem : " & i.ToString()

        '                txt.Text = ds.Tables(0).Rows(i - 1)("fee").ToString
        '                Dim rH As New TableRow()
        '                Dim cH As New TableCell()
        '                cH.Width = 125
        '                cH.Text = "Table Heading"
        '                Dim cH1 As New TableCell()
        '                cH1.Text = "Table Heading"

        '                ''''''''''''''''
        '                Dim lblmonth As New Label()
        '                lblmonth.Text = "(in INR)"
        '                lblmonth.Width = Unit.Percentage(50)
        '                Dim cH2 As New TableCell()
        '                cH2.Width = 320
        '                cH2.HorizontalAlign = HorizontalAlign.Left

        '                cH2.Text = "Table Heading"
        '                rH.Controls.Add(cH)
        '                rH.Controls.Add(cH1)
        '                rH.Controls.Add(cH2)
        '                MyTable.Rows.Add(rH)
        '                cH.Controls.Add(lbl)
        '                cH1.Controls.Add(txt)
        '                cH2.Controls.Add(lblmonth)
        '            Next


        '        End If
        '    Else

        '    End If
        'Catch ex As Exception

        'End Try
        Try
            FillDyneminTextbox()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If (noOfSem = 0) Then
            Response.Redirect("AddSemester.aspx?&cid=" & Request.QueryString("cid"))
        Else
            Response.Redirect("AddSemesterDuration.aspx?dt=" & noOfSem & "&cid=" & Request.QueryString("cid"))
        End If

    End Sub

    Protected Sub ddlnationality_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlnationality.SelectedIndexChanged
        ddlapplicantCategory.Items.Clear()
        If ddlnationality.SelectedItem.Text = "Indian" Then

            ddlapplicantCategory.Items.Add("SELECT CATEGORY")
            ddlapplicantCategory.Items.Add("Institutional Sponsored")
            ddlapplicantCategory.Items.Add("Individual Candidate")
            ddlapplicantCategory.Items.Add("Student")
        Else
            ddlapplicantCategory.Items.Add("SELECT")
            ddlapplicantCategory.Items.Add("Applicant from developed countries")
            ddlapplicantCategory.Items.Add("Applicant from SAARC and other developing countries")

        End If
    End Sub
End Class
