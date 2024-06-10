
Partial Class Admin_ListStudentForEditprofile
    Inherits System.Web.UI.Page
    Protected cid As Integer
    Protected bid As Integer
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
                If Len(Request.QueryString("cid")) > 0 Then

                    ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(Request.QueryString("cid")))
                    FillDDlBatch()

                    ddlbatch.SelectedIndex = ddlbatch.Items.IndexOf(ddlbatch.Items.FindByText(MyCLS.fnQuerySelect1Value("batch", "batchcode", "bid", Request.QueryString("bid"))))

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
    Sub bindgrid()
        Try
            If ddlCourse.SelectedItem.Text = "SELECT" Then
                lblMessage.Text = "Please select course"
                Exit Sub
            End If
            'Dim strq As String = "select stid,courseID,email,firstname,lastname from student where courseid=" & ddlCourse.SelectedValue
            'Dim strq As String = "select distinct(student.stid),student.email,student.firstname,student.lastname from student INNER JOIN StudentRegCourse on student.stid=StudentRegCourse.stid  INNER JOIN StudentRegbatch on student.stid=StudentRegbatch.stid  where StudentRegbatch.bid=" & ddlbatch.SelectedValue & " and studentregbatch.courseid=" & ddlCourse.SelectedValue
            Dim strq As String = "select distinct(student.stid),student.email,student.firstname,student.lastname,studentregbatch.courseid,StudentRegbatch.bid,BatchCode=(select BatchCode from batch where bid=StudentRegbatch.bid) from student INNER JOIN StudentRegCourse on student.stid=StudentRegCourse.stid  INNER JOIN StudentRegbatch on student.stid=StudentRegbatch.stid  where StudentRegbatch.bid=" & ddlbatch.SelectedValue & " and studentregbatch.courseid=" & ddlCourse.SelectedValue

            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Columns(3).ShowHeader = False
                            GrdStudent.Columns(3).Visible = False
                            GrdStudent.Visible = True
                        Else
                            lblMessage.Text = "No record found"
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
            'Dim strq As String = "select distinct(student.stid),student.email,student.firstname,student.lastname from student INNER JOIN StudentRegCourse on student.stid=StudentRegCourse.stid "
            Dim strq As String = "select distinct(student.stid),student.email,student.firstname,student.lastname,studentregbatch.courseid,StudentRegbatch.bid,BatchCode=(select BatchCode from batch where bid=StudentRegbatch.bid) from student INNER JOIN StudentRegCourse on student.stid=StudentRegCourse.stid  INNER JOIN StudentRegbatch on student.stid=StudentRegbatch.stid"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Columns(0).ShowHeader = True
                            GrdStudent.Columns(0).Visible = True
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
        'bindgrid()
        FillDDlBatch()
    End Sub

   
    Protected Sub grdView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdStudent.PageIndex = e.NewPageIndex
        If (ViewState("chk") = 1) Then
            bindgrid1()
        Else
            bindgrid()
        End If
    End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        bindgrid()
    End Sub
    Private Sub FillDDlBatch()
        Try
            Dim batch As New DataSet
            batch = CLS.fnQuerySelectDs("select distinct(br.bid),bt.batchcode from batch bt INNER JOIN studentregbatch br on br.bid=bt.bid where br.courseid=" & ddlCourse.SelectedValue)
            If batch IsNot Nothing Then
                If batch.Tables IsNot Nothing Then
                    If batch.Tables(0).Rows IsNot Nothing Then
                        If batch.Tables(0).Rows.Count > 0 Then
                            ddlBatch.DataSource = batch
                            ddlBatch.DataValueField = "bid"
                            ddlBatch.DataTextField = "BatchCode"
                            ddlbatch.DataBind()
                           
                            ddlbatch.Items.Insert(0, "SELECT")

                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchName()
    End Sub

    Sub SearchName()
        Try
            Dim Data As String = txtfirstname.Text
            If txtfirstname.Text = "" Then
                lblMessage.Text = "Please Enter The Name of Student"
                Exit Sub
            End If

            'Dim strq As String = "select StudentAppCourse.stAid,application.aid,application.email,application.firstname,application.lastname,Course.courseid,Course.CourseCode,Course.CourseTitle,studentAppcourse.approve from application INNER JOIN StudentAppCourse on application.aid=StudentAppCourse.aid INNER JOIN course on StudentAppCourse.courseid=course.courseid where  application.firstname like '%" & Data & "%' or application.lastname like '%" & Data & "%'"
            Dim strq As String = "select distinct student.stid,student.email,student.firstname,student.lastname,studentregbatch.courseid,StudentRegbatch.bid,BatchCode=(select BatchCode from batch where bid=StudentRegbatch.bid) from student INNER JOIN StudentRegCourse on student.stid=StudentRegCourse.stid INNER JOIN StudentRegbatch on student.stid=StudentRegbatch.stid where  student.firstname like '%" & Data & "%' or student.lastname like '%" & Data & "%'"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then

                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Columns(3).ShowHeader = True
                            GrdStudent.Columns(3).Visible = True
                            GrdStudent.Visible = True
                        Else
                            lblMessage.Text = "No record found"
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ManageStudentInfo.aspx")
    End Sub
End Class
