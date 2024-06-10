
Partial Class ForumTopic1
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            bindgrid()
            FillCourse()
        End If
    End Sub

    Sub bindgrid()
        Try

            'Dim dt As New DataTable()
            'Dim d1 As DataColumn = New DataColumn("SubjectId")
            'd1.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d1)
            'Dim d2 As DataColumn = New DataColumn("title")
            'd2.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d2)
            'Dim d3 As DataColumn = New DataColumn("TPost")
            'd3.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d3)
            'Dim d4 As DataColumn = New DataColumn("LastPost")
            'd4.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d4)
            'Dim d5 As DataColumn = New DataColumn("Createdby")
            'd5.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d5)
            'Dim d6 As DataColumn = New DataColumn("totalread")
            'd6.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d6)

            'Dim dr As DataRow
            'Dim strST As String
            'strST = "select  distinct(a.semid) as semid, a.courseid as courseid ,a.Fid from facultyregistration inner join facultyassign a  on facultyregistration.Fid=a.Fid where email='" & Session("username") & "'"

            'Dim iCid As Integer
            'Dim iSemid As Integer
            'Dim i As Integer = 0
            'Dim j As Integer = 0
            'Dim dsStInfo As New DataSet()
            'dsStInfo = CLS.fnQuerySelectDs(strST)
            'If dsStInfo IsNot Nothing Then
            '    If dsStInfo.Tables IsNot Nothing Then
            '        If dsStInfo.Tables(0).Rows IsNot Nothing Then
            '            If dsStInfo.Tables(0).Rows.Count > 0 Then

            '                While i < dsStInfo.Tables(0).Rows.Count
            '                    iCid = dsStInfo.Tables(0).Rows(i)("courseid")
            '                    iSemid = dsStInfo.Tables(0).Rows(i)("semid")
            '                    'changed by chhaya 4 dec 2009
            '                    'Dim strq As String = "select  * from Maintopic where courseid=" & iCid & " and semid=" & iSemid & " and active=1 and CreatedBy='" & Session("username") & "' order by subjectid desc "
            'Dim strq As String = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic where courseid=" & iCid & " and semid=" & iSemid & " and active=1 order by lastpost1 desc "
            Dim strq As String

            If ViewState("b") <> 1 Then
                strq = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic where  active=1 and semid in (select  semid from facultyassign  where fid=" & Session("fid") & ") order by lastpost1 desc"
            Else
                strq = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic where  active=1 and courseid=" & ddlCourse.SelectedValue & " and batchid=" & ddlBatch.SelectedValue & " and semid in (select  semid from facultyassign  where fid=" & Session("fid") & ") order by lastpost1 desc"
            End If
            Dim dsTopic As New DataSet
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            GrdTopic.DataSource = dsTopic
                            GrdTopic.DataBind()
                        End If
                    End If
                End If
            End If




            'Dim strq As String = "select  * from Maintopic where courseid=" & iCid & " and semid=" & iSemid & " and active=1"
            'Dim dsTopic As New DataSet()
            'dsTopic = CLS.fnQuerySelectDs(strq)
            'If dsTopic IsNot Nothing Then
            '    If dsTopic.Tables IsNot Nothing Then
            '        If dsTopic.Tables(0).Rows IsNot Nothing Then
            '            If dsTopic.Tables(0).Rows.Count > 0 Then
            '                GrdTopic.DataSource = dsTopic
            '                GrdTopic.DataBind()
            '                GrdTopic.Visible = True
            '            Else
            '                lblMessage.Text = "No topic exist"
            '                GrdTopic.Visible = False
            '            End If
            '        End If
            '    End If
            'End If
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub grdView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdTopic.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    'Protected Sub GrdTopic_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdTopic.RowDataBound
    '    Try
    '        Dim row As GridViewRow = e.Row
    '        Dim strSort As String = String.Empty

    '        ' Make sure we aren't in header/footer rows 
    '        If row.DataItem Is Nothing Then
    '            Exit Sub
    '        End If

    '        'Find Child GridView control 
    '        Dim gv As New HiddenField
    '        gv = DirectCast(row.FindControl("hd1"), HiddenField)
    '        ' changed by chhaya
    '        Dim hdnsubid As New HiddenField
    '        Dim lnkbtnreplies As New LinkButton
    '        Dim lnkbtnTopics As New LinkButton

    '        hdnsubid = DirectCast(row.FindControl("hdnsubid"), HiddenField)
    '        lnkbtnreplies = DirectCast(row.FindControl("lnkbtnreplies"), LinkButton)
    '        lnkbtnTopics = DirectCast(row.FindControl("lnkbtnTopics"), LinkButton)

    '        Dim strTopic As String
    '        strTopic = "select count(*) from subsubject where subjectid=" & gv.Value
    '        Dim dsCount As DataSet
    '        dsCount = CLS.fnQuerySelectDs(strTopic)
    '        Dim intTotRep As Integer
    '        If dsCount IsNot Nothing Then
    '            If dsCount.Tables IsNot Nothing Then
    '                If dsCount.Tables(0).Rows IsNot Nothing Then
    '                    If dsCount.Tables(0).Rows.Count > 0 Then
    '                        intTotRep = CInt(dsCount.Tables(0).Rows(0)(0).ToString)
    '                    End If
    '                End If
    '            End If
    '        End If

    '        Dim lbl12 As New Label
    '        lbl12 = DirectCast(row.FindControl("lblTotalReply"), Label)



    '        lbl12.Text = intTotRep

    '        ' this code is added by chhaya
    '        Dim strq As String

    '        strq = "select  * from subSubject where subjectID=" & hdnsubid.Value & " and email='" & Session("username") & "'"


    '        Dim dsTopic As New DataSet()
    '        dsTopic = CLS.fnQuerySelectDs(strq)
    '        If dsTopic IsNot Nothing Then
    '            If dsTopic.Tables IsNot Nothing Then
    '                If dsTopic.Tables(0).Rows IsNot Nothing Then
    '                    If dsTopic.Tables(0).Rows.Count > 0 Then
    '                        lnkbtnreplies.Enabled = True
    '                        lnkbtnreplies.PostBackUrl = "EditReplies.aspx?id=" + hdnsubid.Value

    '                    Else
    '                        lnkbtnreplies.Enabled = False

    '                    End If
    '                End If
    '            End If
    '        End If


    '        Dim strq1 As String = "select  * from maintopic where subjectID=" & hdnsubid.Value & " and createdby='" & Session("username") & "'"

    '        Dim dsTopic1 As New DataSet()
    '        dsTopic1 = CLS.fnQuerySelectDs(strq1)
    '        If dsTopic1 IsNot Nothing Then
    '            If dsTopic1.Tables IsNot Nothing Then
    '                If dsTopic1.Tables(0).Rows IsNot Nothing Then
    '                    If dsTopic1.Tables(0).Rows.Count > 0 Then
    '                        lnkbtnTopics.Enabled = True

    '                        lnkbtnTopics.PostBackUrl = "AddForumTopic.aspx?id=" & hdnsubid.Value & "&EditTopic=Edit"
    '                    Else
    '                        lnkbtnTopics.Enabled = False

    '                    End If
    '                End If
    '            End If
    '        End If

    '    Catch ex As Exception
    '    End Try
    'End Sub
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
            gv = DirectCast(row.FindControl("hd1"), HiddenField)
            ' changed by chhaya
            Dim hdnsubid As New HiddenField
            Dim lnkbtnreplies As New LinkButton
            Dim lnkbtnTopics As New LinkButton

            hdnsubid = DirectCast(row.FindControl("hdnsubid"), HiddenField)
            lnkbtnreplies = DirectCast(row.FindControl("lnkbtnreplies"), LinkButton)
            lnkbtnTopics = DirectCast(row.FindControl("lnkbtnTopics"), LinkButton)

            Dim strTopic As String
            strTopic = "select count(*) from subsubject where subjectid=" & gv.Value
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

            Dim lbl12 As New Label
            lbl12 = DirectCast(row.FindControl("lblTotalReply"), Label)



            lbl12.Text = intTotRep

            ' this code is added by chhaya
            Dim strq As String

            strq = "select  * from subSubject where subjectID=" & hdnsubid.Value & " and email='" & Session("username") & "'"


            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            lnkbtnreplies.Enabled = True
                            lnkbtnreplies.PostBackUrl = "EditReplies.aspx?id=" + hdnsubid.Value

                        Else
                            lnkbtnreplies.Enabled = False

                        End If
                    End If
                End If
            End If


            Dim strq1 As String = "select  * from maintopic where subjectID=" & hdnsubid.Value & " and createdby='" & Session("username") & "'"

            Dim dsTopic1 As New DataSet()
            dsTopic1 = CLS.fnQuerySelectDs(strq1)
            If dsTopic1 IsNot Nothing Then
                If dsTopic1.Tables IsNot Nothing Then
                    If dsTopic1.Tables(0).Rows IsNot Nothing Then
                        If dsTopic1.Tables(0).Rows.Count > 0 Then
                            lnkbtnTopics.Enabled = True

                            lnkbtnTopics.PostBackUrl = "AddForumTopic.aspx?id=" & hdnsubid.Value & "&EditTopic=Edit"
                        Else
                            lnkbtnTopics.Enabled = False

                        End If
                    End If
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ImgAddTopic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgAddTopic.Click
        Response.Redirect("AddForumTopic.aspx")
    End Sub
    Protected Sub GrdTopic_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GrdTopic.PageIndex = e.NewPageIndex
      
        bindgrid()

    End Sub

   

    Private Sub FillCourse()
        Try


            Dim strCourse As String = "select distinct(a.courseid),co.CourseTitle,a.Fid from facultyregistration inner join facultyassign a  on facultyregistration.Fid=a.Fid INNER JOIN course co on co.Courseid=a.Courseid where email='" & Session("username") & "'"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strCourse)
            ddlCourse.DataSource = dsCourse
            ddlCourse.DataTextField = "CourseTitle"
            ddlCourse.DataValueField = "courseid"
            ddlCourse.DataBind()
            ddlCourse.Items.Insert(0, "--Select Course--")
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FillBatch()
        Try
            Dim strBatch As String = "select BatchCode,bid  from batch where courseid=" & ddlCourse.SelectedValue
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strBatch)

            ddlBatch.DataSource = dsbatch
            ddlBatch.DataTextField = "BatchCode"
            ddlBatch.DataValueField = "bid"
            ddlBatch.DataBind()
            ddlBatch.Items.Insert(0, "--Select Batch--")
        Catch ex As Exception

        End Try
    End Sub
    Sub bindgrid1()
        Try

            'Dim dt As New DataTable()
            'Dim d1 As DataColumn = New DataColumn("SubjectId")
            'd1.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d1)
            'Dim d2 As DataColumn = New DataColumn("title")
            'd2.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d2)
            'Dim d3 As DataColumn = New DataColumn("TPost")
            'd3.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d3)
            'Dim d4 As DataColumn = New DataColumn("LastPost")
            'd4.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d4)
            'Dim d5 As DataColumn = New DataColumn("Createdby")
            'd5.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d5)
            'Dim d6 As DataColumn = New DataColumn("totalread")
            'd6.DataType = System.Type.GetType("System.String")
            'dt.Columns.Add(d6)

            'Dim dr As DataRow
            'Dim strST As String
            'strST = "select a.courseid as courseid ,a.Fid,a.semid as semid from facultyregistration inner join facultyassign a  on facultyregistration.Fid=a.Fid where email='" & Session("username") & "'"

            'Dim iCid As Integer
            'Dim iSemid As Integer
            'Dim i As Integer = 0
            'Dim j As Integer = 0
            'Dim dsStInfo As New DataSet()
            'dsStInfo = CLS.fnQuerySelectDs(strST)
            'If dsStInfo IsNot Nothing Then
            '    If dsStInfo.Tables IsNot Nothing Then
            '        If dsStInfo.Tables(0).Rows IsNot Nothing Then
            '            If dsStInfo.Tables(0).Rows.Count > 0 Then

            '                While i < dsStInfo.Tables(0).Rows.Count
            '                    iCid = dsStInfo.Tables(0).Rows(i)("courseid")
            '                    iSemid = dsStInfo.Tables(0).Rows(i)("semid")
            '                    'changed by chhaya 4 dec 2009
            '                    'Dim strq As String = "select  * from Maintopic where courseid=" & ddlCourse.SelectedValue & " and semid=" & iSemid & " and batchid=" & ddlBatch.SelectedValue & " and active=1 and CreatedBy='" & Session("username") & "' order by subjectid desc "
            'Dim strq As String = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic where courseid=" & ddlCourse.SelectedValue & " and semid=" & iSemid & " and batchid=" & ddlBatch.SelectedValue & " and active=1  order by lastpost1 desc "
            'Dim dsTopic As New DataSet()
            'dsTopic = CLS.fnQuerySelectDs(strq)
            'If dsTopic IsNot Nothing Then
            '    If dsTopic.Tables IsNot Nothing Then
            '        If dsTopic.Tables(0).Rows IsNot Nothing Then
            '            If dsTopic.Tables(0).Rows.Count > 0 Then
            '                j = 0
            '                While j < dsTopic.Tables(0).Rows.Count
            '                    dr = dt.NewRow()
            '                    dr("SubjectId") = dsTopic.Tables(0).Rows(j)("SubjectId")
            '                    dr("title") = dsTopic.Tables(0).Rows(j)("title")
            '                    dr("TPost") = dsTopic.Tables(0).Rows(j)("TPost")
            '                    dr("LastPost") = dsTopic.Tables(0).Rows(j)("LastPost")
            '                    dr("Createdby") = dsTopic.Tables(0).Rows(j)("Createdby")
            '                    dr("totalread") = dsTopic.Tables(0).Rows(j)("totalread")
            '                    dt.Rows.Add(dr)
            '                    j = j + 1
            '                End While
            '            End If
            '        End If
            '    End If
            'End If

            '' ''Dim strq As String
            '' ''strq = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic where  active=1 and semid in (select  semid from facultyassign  where fid=" & Session("fid") & ")  where courseid=" & ddlCourse.SelectedValue & " and batchid=" & ddlBatch.SelectedValue & " and active=1 order by lastpost1 desc"
            '' ''Dim dsTopic As New DataSet
            '' ''dsTopic = CLS.fnQuerySelectDs(strq)
            '' ''If dsTopic IsNot Nothing Then
            '' ''    If dsTopic.Tables IsNot Nothing Then
            '' ''        If dsTopic.Tables(0).Rows IsNot Nothing Then
            '' ''            If dsTopic.Tables(0).Rows.Count > 0 Then
            '' ''                GrdTopic.DataSource = dsTopic
            '' ''                GrdTopic.DataBind()
            '' ''            End If
            '' ''        End If
            '' ''    End If
            '' ''End If

            'Dim strq As String = "select  * from Maintopic where courseid=" & iCid & " and semid=" & iSemid & " and active=1"
            'Dim dsTopic As New DataSet()
            'dsTopic = CLS.fnQuerySelectDs(strq)
            'If dsTopic IsNot Nothing Then
            '    If dsTopic.Tables IsNot Nothing Then
            '        If dsTopic.Tables(0).Rows IsNot Nothing Then
            '            If dsTopic.Tables(0).Rows.Count > 0 Then
            '                GrdTopic.DataSource = dsTopic
            '                GrdTopic.DataBind()
            '                GrdTopic.Visible = True
            '            Else
            '                lblMessage.Text = "No topic exist"
            '                GrdTopic.Visible = False
            '            End If
            '        End If
            '    End If
            'End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        FillBatch()
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        ViewState("b") = 1
        bindgrid()
    End Sub
End Class
