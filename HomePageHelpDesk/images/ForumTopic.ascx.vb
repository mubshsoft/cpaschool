
Partial Class ForumTopic
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ViewState("b") = 1
            FillCourse()
            bindgrid()
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
            Dim strST As String
            '   strST = "select a.courseid as courseid ,a.stid as stid,a.semid as semid from student inner join studentSemester a " & _
            '          " on student.stid=a.stid " & _
            '         " where email='" & Session("username") & "' and a.currentStatus=2 and a.feestatus=1"

            'If ViewState("b") = 1 Then
            '    'strST = "select sb.bid,a.courseid as courseid ,a.stid as stid,a.semid as semid " & _
            '    '        " from student inner join studentSemester a  on student.stid = a.stid " & _
            '    '        " inner join studentregbatch sb on" & _
            '    '        " (sb.stid = a.stid and sb.courseid = a.courseid)" & _
            '    '        " where email='" & Session("username") & "' and a.currentStatus = 2 And a.feestatus = 1"
            '    strST = "select sb.bid,a.courseid as courseid ,a.stid as stid,a.semid as semid " & _
            '            " from student inner join studentSemester a  on student.stid = a.stid " & _
            '            " inner join studentregbatch sb on" & _
            '            " (sb.stid = a.stid and sb.courseid = a.courseid)" & _
            '            " where email='" & Session("username") & "' And a.feestatus = 1"
            'Else
            '    strST = "select sb.bid,a.courseid as courseid ,a.stid as stid,a.semid as semid " & _
            '                        " from student inner join studentSemester a  on student.stid = a.stid " & _
            '                        " inner join studentregbatch sb on" & _
            '                        " (sb.stid = a.stid and sb.courseid = a.courseid)" & _
            '                        " where email='" & Session("username") & "' and  a.feestatus = 1 and sb.courseid=" & ddlCourse.SelectedValue
            'End If
            If ViewState("b") = 1 Then
                strST = "select * from studentregbatch where stid=" & Session("stid")
            Else
                strST = "select * from studentregbatch where stid=" & Session("stid") & " And courseid = " & ddlCourse.SelectedValue
            End If
            Dim iCid As Integer
            Dim iSemid As Integer
            Dim iBatchid As Integer
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim dsStInfo As New DataSet()
            dsStInfo = CLS.fnQuerySelectDs(strST)
            If dsStInfo IsNot Nothing Then
                If dsStInfo.Tables IsNot Nothing Then
                    If dsStInfo.Tables(0).Rows IsNot Nothing Then
                        If dsStInfo.Tables(0).Rows.Count > 0 Then

                            iCid = dsStInfo.Tables(0).Rows(i)("courseid")

                            iBatchid = dsStInfo.Tables(0).Rows(i)("bid")
                        End If

                    End If
                End If
            End If
            'Dim strq As String = "SELECT subjectId,title,TPost,convert(datetime,lastpost)as lastpost1,lastpost,CreatedBy,Active,CourseID,SemID,totalread,BatchID FROM MainTopic where courseid=" & iCid & " and batchid=" & iBatchid & " and active=1 and semid in (select semid from studentsemester where stid=" & Session("stid") & "  And feestatus = 1 and courseid=" & iCid & ") order by lastpost1 desc"
            'Dim dsTopic As New DataSet()
            'dsTopic = CLS.fnQuerySelectDs(strq)

            Dim dsTopic As New DataSet()
            Dim objParamList As New List(Of OleDbParameter)()
            objParamList.Add(New OleDbParameter("@CourseId", iCid))
            objParamList.Add(New OleDbParameter("@Bid", iBatchid))
            objParamList.Add(New OleDbParameter("@Stid", Session("stid")))
            dsTopic = CLS.ExecuteCLSSPDataSet("SP_GetAllTopics", objParamList)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        'If dsTopic.Tables(0).Rows.Count > 0 Then
                        'j = 0
                        'While j < dsTopic.Tables(0).Rows.Count
                        '    dr = dt.NewRow()
                        '    dr("SubjectId") = dsTopic.Tables(0).Rows(j)("SubjectId")
                        '    dr("title") = dsTopic.Tables(0).Rows(j)("title")
                        '    dr("TPost") = dsTopic.Tables(0).Rows(j)("TPost")
                        '    dr("LastPost") = dsTopic.Tables(0).Rows(j)("LastPost")
                        '    dr("Createdby") = dsTopic.Tables(0).Rows(j)("Createdby")
                        '    dr("totalread") = dsTopic.Tables(0).Rows(j)("totalread")
                        '    dt.Rows.Add(dr)
                        '    j = j + 1
                        'End While
                        GrdTopic.DataSource = dsTopic
                        GrdTopic.DataBind()
                        GrdTopic.Visible = True



                        'End If

                    End If
                End If
            End If







            'Dim strq As String = "Select  * from Maintopic where courseid=" & iCid & " And semid=" & iSemid & " And active=1"
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


    'Protected Sub grdView_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
    '    GrdTopic.PageIndex = e.NewPageIndex
    '    bindgrid()
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
            Dim lblUserName As New Label
            ' changed by chhaya
            Dim hdnsubid As New HiddenField
            Dim lnkbtnreplies As New LinkButton


            gv = DirectCast(row.FindControl("hd1"), HiddenField)
            lblUserName = DirectCast(row.FindControl("lblUserName"), Label)

            hdnsubid = DirectCast(row.FindControl("hdnsubid"), HiddenField)
            lnkbtnreplies = DirectCast(row.FindControl("lnkbtnreplies"), LinkButton)


            Dim strTopic As String
            strTopic = "Select count(*) from subsubject where subjectid=" & gv.Value
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

            Dim type As String
            Dim strType As String
            Dim strName As String
            Dim FullName As String
            strType = "select * from login where username='" & lblUserName.Text & "'"
            Dim dsType As DataSet
            dsType = CLS.fnQuerySelectDs(strType)

            type = dsType.Tables(0).Rows(0)("type").ToString

            If type = "Student" Then
                strName = "select * from student where email='" & lblUserName.Text & "'"
            ElseIf type = "Faculty" Then
                strName = "select * from facultyregistration where email='" & lblUserName.Text & "'"
            ElseIf type = "Admin" Then
                strName = "select * from login where username='" & lblUserName.Text & "'"
            End If


            Dim dsName As DataSet
            dsName = CLS.fnQuerySelectDs(strName)
            If dsName.Tables.Count > 0 Then
                If type = "Student" Then
                    FullName = dsName.Tables(0).Rows(0)("firstname").ToString & " " & dsName.Tables(0).Rows(0)("lastname").ToString
                    lblUserName.Text = FullName
                ElseIf type = "Faculty" Then
                    FullName = dsName.Tables(0).Rows(0)("firstname").ToString & " " & dsName.Tables(0).Rows(0)("lastname").ToString
                    lblUserName.Text = FullName
                ElseIf type = "Admin" Then
                    lblUserName.Text = dsName.Tables(0).Rows(0)("username").ToString
                End If

            End If



            Dim strq As String

            'strq = "select  * from subSubject where subjectID=" & hdnsubid.Value & " and email='" & Session("username") & "'"
            strq = "select  * from maintopic where subjectID=" & hdnsubid.Value & " and createdby='" & Session("username") & "'"

            Dim dsTopic As New DataSet()
            dsTopic = CLS.fnQuerySelectDs(strq)
            If dsTopic IsNot Nothing Then
                If dsTopic.Tables IsNot Nothing Then
                    If dsTopic.Tables(0).Rows IsNot Nothing Then
                        If dsTopic.Tables(0).Rows.Count > 0 Then
                            lnkbtnreplies.Enabled = True
                            'lnkbtnreplies.PostBackUrl = "EditReplies.aspx?id=" + hdnsubid.Value
                            lnkbtnreplies.PostBackUrl = "AddStudentTopic.aspx?id=" & hdnsubid.Value & "&EditTopic=Edit"
                        Else
                            lnkbtnreplies.Enabled = False

                        End If
                    End If
                End If
            End If
            'Dim strFaName As String
            'strFaName = "select * from facultyregistration where email='" & lblUserName.Text & "'"
            'Dim dsFaName As DataSet
            'dsFaName = CLS.fnQuerySelectDs(strFaName)
            'If dsName.Tables.Count > 0 Then
            '    lblUserName.Text = dsFaName.Tables(0).Rows(0)("firstname").ToString
            'End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ImgAddTopic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ImgAddTopic.Click
        Response.Redirect("AddStudentTopic.aspx")
    End Sub
    Protected Sub GrdTopic_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles GrdTopic.PageIndexChanging
        GrdTopic.PageIndex = e.NewPageIndex
        bindgrid()
    End Sub

    Private Sub FillCourse()
        Try
            Dim strCourse As String = "select sc.courseid,co.CourseTitle,sc.stid from studentregcourse sc inner join student a  on sc.stid=a.stid INNER JOIN course co on co.Courseid=sc.Courseid where email='" & Session("username") & "' order by courseid"
            Dim dsCourse As New DataSet()
            dsCourse = CLS.fnQuerySelectDs(strCourse)
            ddlCourse.DataSource = dsCourse
            ddlCourse.DataTextField = "CourseTitle"
            ddlCourse.DataValueField = "courseid"
            ddlCourse.DataBind()
            ddlCourse.Items.Insert(0, "--Select--")
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        If ddlCourse.SelectedItem.Text = "--Select--" Then
            ViewState("b") = 1
            bindgrid()
        Else
            ViewState("b") = 2
            bindgrid()
        End If

    End Sub
End Class
