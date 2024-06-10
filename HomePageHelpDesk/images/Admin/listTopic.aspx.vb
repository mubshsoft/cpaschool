
Partial Class Admin_listTopic
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If
        Try
            If Not IsPostBack Then
                MyCLS.ConOpen()

                FillDDl()
                'If Len(Request.QueryString("cid")) > 0 Then
                '    ddlCourse.SelectedIndex = ddlCourse.Items.IndexOf(ddlCourse.Items.FindByValue(Request.QueryString("cid")))
                '    'bindgrid()
                'Else
                '    bindgrid1()
                'End If
                bindgrid1()
                ViewState("chk") = 1
                MyCLS.ConClose()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FillDDl()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlCourse, "Course", "CourseID", "CourseTitle")
        MyCLS.ConClose()
    End Sub
    Private Sub FillBatch()
        Try


            Dim strBatch As String = "select distinct(batchcode),studentRegbatch.bid as bid,studentRegbatch.Courseid from studentRegbatch Inner join batch on studentRegbatch.bid=batch.bid where studentRegbatch.courseid=" & ddlCourse.SelectedValue
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strBatch)
            ddlBatch.DataSource = dsbatch
            ddlBatch.DataTextField = "BatchCode"
            ddlBatch.DataValueField = "bid"
            ddlBatch.DataBind()
            ddlBatch.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FillSem()
        Try


            Dim strBatch As String = "select * from Semester where courseid=" & ddlCourse.SelectedValue
            Dim dsSem As New DataSet()
            dsSem = CLS.fnQuerySelectDs(strBatch)
            ddlsem.DataSource = dsSem
            ddlsem.DataTextField = "SemesterTitle"
            ddlsem.DataValueField = "SemId"
            ddlsem.DataBind()
            ddlsem.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillDDlSem()
        MyCLS.ConOpen()
        MyCLS.prcFillDDL(ddlsem, "Semester", "SemID", "SemesterTitle", "courseid", ddlBatch.SelectedValue)
        ViewState("chk") = 2
        MyCLS.ConClose()
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillBatch()
        If ddlCourse.SelectedValue = "SELECT" And ddlBatch.SelectedValue = "--Select--" And ddlsem.SelectedValue = "--Select--" Then
            bindgrid1()
        End If
    End Sub

    Sub bindCourse()
        Try
            'If ddlCourse.SelectedItem.Text = "SELECT" Then
            '    lblMessage.Text = "Please select course"
            '    Exit Sub
            'End If

            'If ddlsem.SelectedItem.Text = "SELECT" Then
            '    lblMessage.Text = "Please select semester"
            '    Exit Sub
            'End If

            Dim strq As String = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic where courseid=" & ddlCourse.SelectedValue & " order by active,lastpost1 desc"
            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            GrdTopic.DataSource = dsTopic
                            GrdTopic.DataBind()
                            GrdTopic.Visible = True
                        Else
                            lblMessage.Text = "No topic exist"
                            GrdTopic.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Sub bindgrid()
        Try
            'If ddlCourse.SelectedItem.Text = "SELECT" Then
            '    lblMessage.Text = "Please select course"
            '    Exit Sub
            'End If

            'If ddlsem.SelectedItem.Text = "SELECT" Then
            '    lblMessage.Text = "Please select semester"
            '    Exit Sub
            'End If

            Dim strq As String = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic where courseid=" & ddlCourse.SelectedValue & " and semid=" & ddlsem.SelectedValue & " and batchid=" & ddlBatch.SelectedValue & " order by active,lastpost1 desc"
            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            GrdTopic.DataSource = dsTopic
                            GrdTopic.DataBind()
                            GrdTopic.Visible = True
                        Else
                            lblMessage.Text = "No topic exist"
                            GrdTopic.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub bindgrid1()
        Try
            Dim strq As String = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic order by lastpost1 desc"
            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            GrdTopic.DataSource = dsTopic
                            GrdTopic.DataBind()
                            GrdTopic.Visible = True
                        Else
                            lblMessage.Text = "No Topic exist"
                            GrdTopic.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub grdView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdTopic.PageIndex = e.NewPageIndex
        If (ViewState("chk") = 1) Then
            bindgrid1()
        ElseIf ViewState("chk") = 2 Then
            bindgrid()
        End If
    End Sub


    Protected Sub ddlsem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsem.SelectedIndexChanged
        If ddlCourse.SelectedValue = "SELECT" And ddlBatch.SelectedValue = "--Select--" And ddlsem.SelectedValue = "--Select--" Then
            bindgrid1()
        End If

        ViewState("chk") = 2
        bindgrid()


    End Sub

    Protected Sub ImgAddTopic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgAddTopic.Click
        Response.Redirect("AddTopic.aspx")
    End Sub

    Protected Sub GrdTopic_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GrdTopic.RowCommand
        Try
            If e.CommandName = "Delete" Then
                If ddlCourse.SelectedIndex > 0 And ddlsem.SelectedIndex > 0 Then
                    Session("cCid") = ddlCourse.SelectedValue
                    Session("cSid") = ddlsem.SelectedValue
                End If
                Dim id As Integer = Convert.ToInt32(e.CommandArgument)
                Dim strDelMainTopic As String = "delete from maintopic where subjectId=" & id
                Dim strDelSubSubject As String = "delete from subsubject where SubjectId=" & id
                CLS.fnExecuteQuery(strDelSubSubject)
                CLS.fnExecuteQuery(strDelMainTopic)
                If Len(Session("cCid")) > 0 Then
                    bindgrid()
                Else
                    bindgrid1()
                End If
                lblMessage.Text = "Topic deleted successfully"
                lblMessage.ForeColor = Drawing.Color.DarkGreen
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub GrdTopic_RowDeleting(ByVal sender As Object, ByVal e As GridViewDeleteEventArgs)

    End Sub

    Protected Sub GrdTopic_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdTopic.RowDataBound
        Try
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            ' Make sure we aren't in header/footer rows 
            If row.DataItem Is Nothing Then
                Exit Sub
            End If

            'Find Child GridView control 
            Dim gv As New HiddenField
            gv = DirectCast(row.FindControl("hd12"), HiddenField)

            Dim lbl12 As New Label
            lbl12 = DirectCast(row.FindControl("lbl12"), Label)


            If (gv.Value = "False") Then
                lbl12.Text = "*"
                lbl12.ForeColor = Drawing.Color.Red
                'Else
                '    lbl12.Text = "*"
                '    lbl12.ForeColor = Drawing.Color.Green
            End If

            Dim gv1 As New HiddenField
            gv1 = DirectCast(row.FindControl("hd1"), HiddenField)
            Dim strTopic As String
            strTopic = "select count(*) from subsubject where subjectid=" & gv1.Value
            Dim dsCount As DataSet
            dsCount = CLS.fnQuerySelectDs(strTopic)
            Dim intTotRep As Integer
            If dsCount IsNot Nothing Then
                If dsCount.Tables IsNot Nothing Then
                    If dsCount.Tables(0).Rows IsNot Nothing Then
                        If dsCount.Tables(0).Rows.Count > 0 Then
                            intTotRep = CInt(dsCount.Tables(0).Rows(0)(0).ToString)
                        End If
                    End If
                End If
            End If

            Dim lblTotalReply As New Label
            lblTotalReply = DirectCast(row.FindControl("lblTotalReply"), Label)



            lblTotalReply.Text = intTotRep
        Catch ex As Exception
        End Try
    End Sub

  
    Protected Sub GrdTopic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdTopic.SelectedIndexChanged

    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        If ddlCourse.SelectedValue = "SELECT" And ddlBatch.SelectedValue = "--Select--" And ddlsem.SelectedValue = "--Select--" Then
            bindgrid1()
        End If

        FillSem()
    End Sub
End Class
