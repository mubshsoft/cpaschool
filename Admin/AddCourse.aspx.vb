Imports fmsf.DAL
Imports fmsf.lib
Imports System.IO
Partial Class Admin_AddCourse
    Inherits System.Web.UI.Page
    Dim txt As TextBox
    Dim IcourseID As Integer
    Dim ccode As String
    Dim id1 As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If
        ' Panel1.Visible = True
        id1 = Request.QueryString("CourseId")

        If Not IsPostBack Then
            'btnSave.Visible = False
            IcourseID = Request.QueryString("id")
            If (Len(Request.QueryString("CourseId")) > 0) Then
                FillData(Request.QueryString("CourseId"))
                id1 = Request.QueryString("CourseId")
                txtCourseCode.Enabled = False
                lblCaption.Text = "Edit Course"
            Else
                lblCaption.Text = "Add Course"
            End If
        End If
    End Sub

    'Protected Sub lnkDuration_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkDuration.Click
    '    If Len(txtNoOfSem.Text) <= 0 Then
    '        lblMessage.Text = "Please enter No of semester"
    '        Exit Sub
    '    End If
    '    Dim n As Integer = txtNoOfSem.Text
    '    'Dim tblHead As New Table()

    '    For i As Integer = 1 To n
    '        'Dim txt As New TextBox()
    '        txt = New TextBox
    '        Dim lbl As New Label()
    '        txt.ID = "txt_" & i.ToString()
    '        lbl.Text = "Duration of Semester : " & i.ToString()
    '        lbl.Width = Unit.Percentage(96)
    '        txt.Width = Unit.Percentage(98)
    '        txt.EnableViewState = True
    '        ''txt.Text = "Sem : " & i.ToString()
    '        Dim rH As New TableRow()
    '        Dim cH As New TableCell()
    '        cH.Width = 132
    '        cH.Text = "Table Heading"
    '        Dim cH1 As New TableCell()
    '        cH1.Text = "Table Heading"
    '        rH.Controls.Add(cH)
    '        rH.Controls.Add(cH1)
    '        'AddHandler txt.PreRender, AddressOf Me.txt_PreRender
    '        MyTable.Rows.Add(rH)
    '        'tblHead.Rows.Add(rH)
    '        'Panel1.Controls.Add(lbl)
    '        'Panel1.Controls.Add(New LiteralControl("<br>"))
    '        'Panel2.Controls.Add(txt)
    '        'Panel2.EnableViewState = True
    '        cH.Controls.Add(lbl)
    '        cH1.Controls.Add(txt)
    '        btnSave.Visible = True

    '    Next
    'End Sub

    'Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    'fetch course sem data
    '    'Dim strSemduration As String
    '    'Dim intColCount As Integer = Convert.ToInt32(txtNoOfSem.Text.ToString().Trim())
    '    'For clIndex As Integer = 0 To intColCount
    '    '    Dim aa As String = Request("txt_" & (clIndex + 1).ToString())

    '    '    If lblDisplay.Text <> "" Then
    '    '        lblDisplay.Text += "," & aa
    '    '    Else
    '    '        lblDisplay.Text = aa
    '    '    End If
    '    'Next



    'End Sub

    Public Function fnValidate() As Object
        Dim ObjErrDal As New libErrorMsg

        If Len(txtCourseCode.Text) <= 0 Then
            ObjErrDal.errMessage = "Course code  cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If


        If Len(txtCourseTitle.Text) <= 0 Then
            ObjErrDal.errMessage = "Course title  cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If

        If Len(txtNoOfSem.Text) <= 0 Then
            ObjErrDal.errMessage = "No of semester cannot be left blank"
            ObjErrDal.ChkReturn = False
            Return ObjErrDal
        End If


        If Len(txtCourseStartDate.Text) > 0 Then
            Dim d As DateTime
            Try
                d = DateTime.Parse(txtCourseStartDate.Text)
            Catch ex As Exception
                ObjErrDal.errMessage = "Invalid date!format should be mm/dd/yyyy"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End Try
        Else
            ObjErrDal.errMessage = "Course start date cannot be left blank"
        End If

        If Len(txtCourseEndDate.Text) > 0 Then
            Dim d As DateTime
            Try
                d = DateTime.Parse(txtCourseEndDate.Text)
            Catch ex As Exception
                ObjErrDal.errMessage = "Invalid date!format should be mm/dd/yyyy"
                ObjErrDal.ChkReturn = False
                Return ObjErrDal
            End Try
        Else

        End If

        If Len(Request.QueryString("CourseId")) <= 0 Then
            If Len(txtCourseStartDate.Text) > 0 Then
                Dim d As Date
                Try
                    d = txtCourseStartDate.Text
                    If d < Date.Now.Date Then
                        'Response.Write("<script>alert('Date Of event should be equal to and greater than current date.')</script>")
                        ObjErrDal.errMessage = "Start Date should be equal to and greater than current date."
                        ObjErrDal.ChkReturn = False
                        Return ObjErrDal
                    End If
                Catch ex As Exception

                End Try
            End If
        End If

        If Len(txtCourseEndDate.Text) > 0 Then
            Dim d As Date
            Try
                d = txtCourseEndDate.Text
                If d < Date.Now.Date Then
                    'Response.Write("<script>alert('Date Of event should be equal to and greater than current date.')</script>")
                    ObjErrDal.errMessage = "End Date should be equal to and greater than current date."
                    ObjErrDal.ChkReturn = False
                    Return ObjErrDal
                End If
            Catch ex As Exception

            End Try
        End If


        'If Len(txtCourseEndDate.Text) > 0 Then
        '    Dim dtStart As New Date
        '    Dim dtEnd As New Date
        '    dtStart = CDate(txtCourseStartDate.Text)
        '    dtEnd = CDate(txtCourseEndDate.Text)
        '    If (dtStart > dtEnd) Then
        '        ' Response.Write("<Script>alert('Start Date Should be less than End Date!');</Script>")
        '        ObjErrDal.errMessage = "Start Date Should be less than End Date!"
        '        ObjErrDal.ChkReturn = False
        '        Return ObjErrDal
        '    End If
        'End If
        ObjErrDal.ChkReturn = True
        Return ObjErrDal
    End Function

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim objCourseLIBLogin As New LibAddCourse
        Dim ObjCourseDal As New DalAddCourse
        Dim ObjErrDal As New libErrorMsg
        Dim strMessage As String
        Try
            'set value in property
            ObjErrDal = fnValidate()
            If ObjErrDal.ChkReturn = True Then
                objCourseLIBLogin.CourseTitle = txtCourseTitle.Text
                objCourseLIBLogin.CourseCode = txtCourseCode.Text
                objCourseLIBLogin.NoofSem = txtNoOfSem.Text
                objCourseLIBLogin.screeningExam = chkCourse.Checked

                If Len(txtCourseStartDate.Text) > 0 Then
                    objCourseLIBLogin.CourseStartDate = CDate(txtCourseStartDate.Text)
                Else
                    lblMessage.Text = "Course start date cannot be left blank"
                    Exit Sub
                End If

                If Len(txtCourseEndDate.Text) > 0 Then
                    objCourseLIBLogin.CourseEndDate = CDate(txtCourseEndDate.Text)
                End If
                If Len(Request.QueryString("CourseId")) > 0 Then
                    'If CDate(txtCourseEndDate.Text) > CDate(txtCourseStartDate.Text) Then

                    Dim strpath As String
                    Dim strpath1 As String
                    GetData(id1)
                    strpath = Server.MapPath("../") & "upload/" & ccode
                    strpath1 = Server.MapPath("../") & "upload/" & txtCourseCode.Text
                    If Directory.Exists(strpath) = True Then
                        Dim strUpdate As String
                        If Len(txtCourseEndDate.Text) > 0 Then
                            strUpdate = "update Course set CourseTitle='" & txtCourseTitle.Text & "',cStartDate='" & txtCourseStartDate.Text & "',cEndDate='" & txtCourseEndDate.Text & "',screeningexam='" & chkCourse.Checked & "' where CourseId=" & Request.QueryString("CourseId")
                        Else
                            strUpdate = "update Course set CourseTitle='" & txtCourseTitle.Text & "',cStartDate='" & txtCourseStartDate.Text & "',screeningexam='" & chkCourse.Checked & "' where CourseId=" & Request.QueryString("CourseId")
                        End If
                        CLS.fnExecuteQuery(strUpdate)
                        If strpath <> strpath1 Then
                            Directory.Move(strpath, strpath1)
                        End If
                        lblMessage.Text = "Course Updated Succesfully"
                        lblMessage.ForeColor = Drawing.Color.Green
                        'Else
                        'lblMessage.Text = "Course end date cannot be less than start date"
                        'End If
                        Response.Redirect("ListCourse.aspx")
                    End If
                Else
                    If Len(Request.QueryString("id")) > 0 Then
                        objCourseLIBLogin.CourseID = Request.QueryString("id")
                        strMessage = ObjCourseDal.fnQuery(objCourseLIBLogin, True)
                        lblMessage.Text = strMessage
                        lblMessage.ForeColor = Drawing.Color.Green
                    Else
                        strMessage = ObjCourseDal.fnQuery(objCourseLIBLogin, False)
                        If strMessage = "Course added successfully!" Then
                            Dim dsId As New DataSet
                            dsId = CLS.fnQuerySelectDs("select IDENT_CURRENT('course')")
                            Dim Cid As Integer = CInt(dsId.Tables(0).Rows(0)(0).ToString)
                            Try
                                Dim strPath As String
                                strPath = Server.MapPath("../") & "upload/" & Trim(txtCourseCode.Text)
                                Directory.CreateDirectory(strPath)
                            Catch ex As Exception

                            End Try
                            'Response.Redirect("AddSemesterDuration.aspx?dt=" & txtNoOfSem.Text & "&cid=" & Cid)
                            Response.Redirect("AddCourseEmail.aspx?dt=" & txtNoOfSem.Text & "&courseid=" & Cid)
                        Else
                            lblMessage.Text = strMessage
                            lblMessage.ForeColor = Drawing.Color.Red
                        End If
                    End If
                End If



            Else
                lblMessage.Text = ObjErrDal.errMessage
                lblMessage.ForeColor = Drawing.Color.Red
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FillData(ByVal CourseID As String)
        Try
            'Dim strGetData As String = "select * from Course where CourseID=" & Integer.Parse(CourseID)
            Dim strGetData As String = "select CourseCode,CourseTitle,noOfSem,CONVERT(varchar, cStartDate, 101) as cStartDate,CONVERT(varchar, cEndDate, 101) as cEndDate,screeningexam from Course where CourseID=" & Integer.Parse(CourseID)


            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                txtCourseCode.Text = ds.Tables(0).Rows(0)("CourseCode").ToString()
                txtCourseTitle.Text = ds.Tables(0).Rows(0)("CourseTitle").ToString()
                txtNoOfSem.Text = ds.Tables(0).Rows(0)("noOfSem").ToString()
                txtCourseStartDate.Text = ds.Tables(0).Rows(0)("cStartDate").ToString()

                txtCourseEndDate.Text = ds.Tables(0).Rows(0)("cEndDate").ToString
                txtNoOfSem.Enabled = False

                If ds.Tables(0).Rows(0)("screeningexam").ToString = "True" Then
                    chkCourse.Checked = True
                Else
                    chkCourse.Checked = False
                End If
                'txtCourseStartDate.Enabled = False
                'txtCourseEndDate.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub GetData(ByVal cID As String)
        Try
            Dim strGetData As String = "select coursecode from course where courseid=" & Integer.Parse(cID)
            Dim ds As New DataSet()
            ds = CLS.fnQuerySelectDs(strGetData)
            If (ds.Tables(0).Rows.Count > 0) Then
                Ccode = ds.Tables(0).Rows(0)("CourseCode").ToString()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImageButton1.Click
        If Len(Request.QueryString("CourseId")) <= 0 Then
            Response.Redirect("Adminlogin.aspx")
        Else
            Response.Redirect("ListCourse.aspx")
        End If
    End Sub
End Class
