
Partial Class Admin_EditprofileForUnassignedStudent
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
                txtfirstname.Visible = False
                btnSearch.Visible = False
                FillDDl()
                If Len(Request.QueryString("cid")) > 0 Then

                    ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(Request.QueryString("cid")))
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

               Dim strq As String = "select student.stid,student.email,student.firstname,student.lastname,StudentRegCourse.courseid from student INNER JOIN StudentRegCourse on student.stid=StudentRegCourse.stid where  StudentRegCourse.stid not in(select stid from Studentregbatch where courseid=" & ddlCourse.SelectedValue & ") and StudentRegCourse.courseid=" & ddlCourse.SelectedValue & " order by stid desc"

            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strq)
            If dsCourse IsNot Nothing Then
                If dsCourse.Tables IsNot Nothing Then
                    If dsCourse.Tables(0).Rows IsNot Nothing Then
                        If dsCourse.Tables(0).Rows.Count > 0 Then
                            ViewState("dsCourse") = dsCourse
                            GrdStudent.DataSource = dsCourse
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                            txtfirstname.Visible = True
                            btnSearch.Visible = True
                        Else
                            lblMessage.Text = "No record found"
                            GrdStudent.Visible = False
                            txtfirstname.Visible = False
                            btnSearch.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged

        bindgrid()
    End Sub


    Protected Sub grdView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdStudent.PageIndex = e.NewPageIndex
    End Sub




    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchName()
    End Sub

    Sub SearchName()
        Try
            Dim Data As String = txtfirstname.Text

            Dim ds1 As DataSet
            ds1 = ViewState("dsCourse")

            Dim dataView As DataView = ds1.Tables(0).DefaultView
            If Not String.IsNullOrEmpty(Data) Then
                dataView.RowFilter = "firstname like '%" & Data & "%' or lastname like '%" & Data & "%' or email like '%" & Data & "%'"
            End If
            GrdStudent.DataSource = dataView
            GrdStudent.DataBind()

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("ManageStudentInfo.aspx")
    End Sub
End Class
