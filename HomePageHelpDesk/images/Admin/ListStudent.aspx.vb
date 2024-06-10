
Partial Class Admin_ListStudent
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        Else
            If Session("role") = "Admin" Then
            Else
                Response.Redirect("../login.aspx")
            End If
        End If

        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()
                ViewState("chk") = 1
                FillDDl()
                fillddlYear()
                If Len(Request.QueryString("cid")) > 0 Then
                    ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(Request.QueryString("cid")))
                    bindgrid()
                Else
                    bindgrid1()
                End If

                MyCLS.ConClose()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillDDl()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseCode")
    End Sub

    Private Sub fillddlYear()
        Dim dsCourseTopic As New DataSet
        Dim dsDDl As New DataSet
        dsDDl = CLS.fnQuerySelectDs("select distinct year(applydate) as year  from studentappcourse where applydate is not null")
        If dsDDl IsNot Nothing Then
            If dsDDl.Tables IsNot Nothing Then
                If dsDDl.Tables(0).Rows IsNot Nothing Then
                    If dsDDl.Tables(0).Rows.Count > 0 Then
                        ddlYear.DataSource = dsDDl
                        ddlYear.DataValueField = "year"
                        ddlYear.DataTextField = "year"
                        ddlYear.DataBind()
                        ddlYear.Items.Insert(0, "SELECT")
                    End If
                End If
            End If
        End If
    End Sub



    Sub bindgrid()
        Try
            If ddlCourse.SelectedItem.Text = "SELECT" Then
                lblMessage.Text = "Please select course"
                Exit Sub
            End If
            'Dim strq As String = "select aid,email,firstname,lastname,approved from application where courseid=" & ddlCourse.SelectedValue & " order by approved"
            'Dim strq As String = "select application.email,application.firstname,application.lastname,StudentAppCourse.courseid,StudentAppCourse.approved from application INNER JOIN StudentAppCourse on application.aid=StudentAppCourse.aid where StudentAppCourse.courseid=" & ddlCourse.SelectedValue & ""
            Dim strq As String = "select StudentAppCourse.stAid,application.aid,application.email,application.firstname,application.lastname,Course.courseid,Course.CourseCode,Course.CourseTitle,studentAppcourse.approve,studentAppcourse.feeremark from application INNER JOIN StudentAppCourse on application.aid=StudentAppCourse.aid INNER JOIN course on StudentAppCourse.courseid=course.courseid where StudentAppCourse.courseid=" & ddlCourse.SelectedValue & "AND year(StudentAppCourse.applydate)='" & ddlYear.SelectedValue & "' and approve=" & ddlApproved.SelectedValue & "order by StudentAppCourse.stAid desc"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        Else
                            lblMessage.Text = "No student has applied for this course"
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub bindgrid1()
        Try
            'Dim strq As String = "select aid,email,firstname,lastname,approved from application order by approved"
            'Dim strq As String = "select application.aid,application.email,application.firstname,application.lastname,Course.CourseCode from application INNER JOIN StudentAppCourse on application.aid=StudentAppCourse.aid INNER JOIN course on StudentAppCourse.courseid=course.courseid"
            Dim strq As String = " select StudentAppCourse.stAid,application.aid,application.email,application.firstname,application.lastname,Course.courseid,Course.CourseCode,Course.CourseTitle,studentAppcourse.approve,studentAppcourse.feeremark from application INNER JOIN StudentAppCourse on application.aid=StudentAppCourse.aid INNER JOIN course on StudentAppCourse.courseid=course.courseid order by StudentAppCourse.stAid desc"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        Else
                            lblMessage.Text = "No student has applied for this course"
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SearchName()
        Try
            Dim Data As String = txtfirstname.Text
            'Dim separator As Char() = New Char() {" "}
            'Dim strSplitArr As String() = strData.Split(separator)
            'If (strSplitArr(1) = "") Then
            '    strSplitArr(1) = strSplitArr(0)
            'End If

            If txtfirstname.Text = "" Then
                lblMessage.Text = "Please Enter The Search Criteria.."
                Exit Sub
            End If
            'Dim strq As String = "select StudentAppCourse.stAid,application.aid,application.email,application.firstname,application.lastname,Course.courseid,Course.CourseCode,Course.CourseTitle,studentAppcourse.approve from application INNER JOIN StudentAppCourse on application.aid=StudentAppCourse.aid INNER JOIN course on StudentAppCourse.courseid=course.courseid where  application.firstname like '%" & strSplitArr(0) & "' or application.lastname like '%" & strSplitArr(1) & "'"
            Dim strq As String = "select StudentAppCourse.stAid,application.aid,application.email,application.firstname,application.lastname,Course.courseid,Course.CourseCode,Course.CourseTitle,studentAppcourse.approve ,studentAppcourse.feeremark from application INNER JOIN StudentAppCourse on application.aid=StudentAppCourse.aid INNER JOIN course on StudentAppCourse.courseid=course.courseid where  application.firstname like '%" & Data & "%' or application.lastname like '%" & Data & "%'"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        Else
                            lblMessage.Text = "No student has applied for this course"
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ViewState("chk") = 2
        fillddlYear()
    End Sub

    Protected Sub GrdStudent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdStudent.RowDataBound
        Try
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            ' Make sure we aren't in header/footer rows 
            If row.DataItem Is Nothing Then
                Exit Sub
            End If

            'Find Child GridView control 
            Dim gv As New HiddenField
            gv = DirectCast(row.FindControl("hd1"), HiddenField)

            Dim lbl12 As New Label
            lbl12 = DirectCast(row.FindControl("lbl"), Label)


            If (gv.Value = "False") Then
                lbl12.Text = "*"
                lbl12.ForeColor = Drawing.Color.Red
                'Else
                '    lbl12.Text = "*"
                '    lbl12.ForeColor = Drawing.Color.Green
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub GrdStudent_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdStudent.PageIndex = e.NewPageIndex
        'If (ViewState("chk") = 1) Then
        '    bindgrid1()
        'Else
        '    bindgrid()
        'End If

        If (ViewState("chk") = 1) Then
            bindgrid1()
        End If
        If (ViewState("chk") = 2) Then
            bindgrid()
        End If
    End Sub


    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchName()
    End Sub

    Protected Sub ddlApproved_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlApproved.SelectedIndexChanged
        bindgrid()
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        ddlApproved.SelectedIndex = 0
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ManageStudentInfo.aspx")
    End Sub
End Class
