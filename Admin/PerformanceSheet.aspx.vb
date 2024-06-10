Imports System.IO

Partial Class Admin_PerformanceSheet
    Inherits System.Web.UI.Page
    Dim stidname As String
    Dim email As String
    Dim batchcode As String
    Dim coursetitle As String
    Dim dsSheet As New DataSet()
    Dim gdnumeric As Boolean

    Sub bindStudentPerformanceSheet()
        Try
            'Dim strq As String = "select  mrk.paperid,p.Papertitle,mrk.stid,mrk.bid,mrk.ExamMarks,mrk.AssignmentMarks,sm.forum,(mrk.ExamMarks + mrk.AssignmentMarks + sm.forum) as total, ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid INNER JOIN studentsemmarks sm on sm.stid=mrk.stid and sm.bid=mrk.bid where ss.feestatus = 1 And m.semid = 129 And mrk.stid = 82"
            'Dim strq As String = "select  ss.courseid,mrk.paperid,p.Papertitle,mrk.stid,mrk.bid,ISNULL(mrk.ExamMarks, 0) as ExamMarks,ISNULL(mrk.AssignmentMarks, 0) as AssignmentMarks ,ISNULL(sm.forum, 0) as forum ,(ISNULL(mrk.AssignmentMarks, 0) + ISNULL(mrk.AssignmentMarks, 0) + ISNULL(sm.forum, 0)) as total, ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid INNER JOIN studentsemmarks sm on sm.stid=mrk.stid and sm.bid=mrk.bid where ss.feestatus = 1 And m.semid =" & Request.QueryString("semid") & " And mrk.stid = " & Request.QueryString("stid") & ""

            'Dim strq As String = "select  ROW_NUMBER() OVER(ORDER BY mrk.paperid asc) AS ROWID, ss.courseid,mrk.paperid,p.Papertitle,mrk.stid,mrk.bid,ISNULL(mrk.ExamMarks, 0) as ExamMarks,ISNULL(mrk.AssignmentMarks, 0) as AssignmentMarks ,ISNULL(mrk.forum, 0) as forum , ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,ISNULL(sm.project, 0) as Project,ISNULL(sm.marks1,0) as marks1,ISNULL(sm.marks2,0) as marks2 from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid LEFT JOIN studentsemmarks sm on sm.stid=mrk.stid and sm.bid=mrk.bid where ss.feestatus = 1  And mrk.stid =" & Request.QueryString("stid") & " And mrk.bid =" & Request.QueryString("bt") 'Comment made by wahid for impementing case study marks (28 dec 2020)
            Dim strq As String = "select  ROW_NUMBER() OVER(ORDER BY mrk.paperid asc) AS ROWID, ss.courseid,mrk.paperid,p.Papertitle,mrk.stid,mrk.bid,ISNULL(mrk.ExamMarks, 0) as ExamMarks,ISNULL(mrk.AssignmentMarks, 0) as AssignmentMarks ,ISNULL(mrk.forum, 0) as forum ,ISNULL(mrk.CaseStudyMarks, 0) as CaseStudyMarks, ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,ISNULL(sm.project, 0) as Project,ISNULL(sm.marks1,0) as marks1,ISNULL(sm.marks2,0) as marks2 from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid LEFT JOIN studentsemmarks sm on sm.stid=mrk.stid and sm.bid=mrk.bid where ss.feestatus = 1  And mrk.stid =" & Request.QueryString("stid") & " And mrk.bid =" & Request.QueryString("bt")
            dsSheet = CLS.fnQuerySelectDs(strq)
            If dsSheet IsNot Nothing Then
                If dsSheet.Tables IsNot Nothing Then
                    If dsSheet.Tables(0).Rows IsNot Nothing Then
                        If dsSheet.Tables(0).Rows.Count > 0 Then
                            dlstPerformanceSheet.DataSource = dsSheet
                            dlstPerformanceSheet.DataBind()
                            dlstPerformanceSheet.Visible = True
                            GrandTotal()
                            bindColumnVisibility()
                        Else
                            tdhdngcasestudy.Visible = False
                        End If

                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub bindStudentYear()
        'Try
        '    Dim strq As String = "select datepart(year,applydate)as year from student a join studentappcourse ap on ap.aid=a.aid where a.stid =" & Request.QueryString("stid") & " And ap.courseid =" & Request.QueryString("cid")
        '    Dim dsSheet As New DataSet()
        '    dsSheet = CLS.fnQuerySelectDs(strq)
        '    If dsSheet IsNot Nothing Then
        '        If dsSheet.Tables IsNot Nothing Then
        '            If dsSheet.Tables(0).Rows IsNot Nothing Then
        '                If dsSheet.Tables(0).Rows.Count > 0 Then
        '                    lblYears.Text = dsSheet.Tables(0).Rows(0)("year").ToString

        '                End If
        '            End If
        '        End If
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
    Private Sub export()
        Response.Clear()
        Response.Buffer = True
        Response.AddHeader("content-disposition", "attachment;filename=PerformanceSheet_" + Request.QueryString("stid") + ".doc")

        Response.Charset = ""
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.ContentType = "application/vnd.ms-word "

        Dim stringWriter As New StringWriter()

        Dim htmlTextWriter As New HtmlTextWriter(stringWriter)
        Me.RenderControl(htmlTextWriter)

        Response.Write(stringWriter.ToString())
        Response.End()
    End Sub
    Sub bindStudentData()
        Try
            Dim strq As String = "select st.stid,st.firstname + ' ' + isnull(middlename,'')+ ' '+ isnull(st.lastname,'') as firstname,st.email,sr.bid,bt.batchcode,sr.courseid,co.coursecode,co.coursetitle from student st Inner jOIN studentregbatch sr on st.stid=sr.stid Inner join batch bt on bt.bid=sr.bid Inner join course co on co.courseid=sr.courseid where sr.bid=" & Request.QueryString("bt").ToString & " and st.stid=" & Request.QueryString("stid") & ""
            Dim dsSheet As New DataSet()
            dsSheet = CLS.fnQuerySelectDs(strq)
            If dsSheet IsNot Nothing Then
                If dsSheet.Tables IsNot Nothing Then
                    If dsSheet.Tables(0).Rows IsNot Nothing Then
                        If dsSheet.Tables(0).Rows.Count > 0 Then
                            lblStudentName.Text = dsSheet.Tables(0).Rows(0)("firstname").ToString
                            email = dsSheet.Tables(0).Rows(0)("email").ToString
                            lblBatchCode.Text = dsSheet.Tables(0).Rows(0)("batchcode").ToString
                            lblCourseName.Text = dsSheet.Tables(0).Rows(0)("coursetitle").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub bindColumnName()
        Try
            Dim strq As String = "select ColumnName1,ColumnName2 from evaluationcriteria where courseid=" & Request.QueryString("cid").ToString & ""
            Dim dsSheet As New DataSet()
            dsSheet = CLS.fnQuerySelectDs(strq)
            If dsSheet IsNot Nothing Then
                If dsSheet.Tables IsNot Nothing Then
                    If dsSheet.Tables(0).Rows IsNot Nothing Then
                        If dsSheet.Tables(0).Rows.Count > 0 Then

                            lblColName1.Text = dsSheet.Tables(0).Rows(0)("ColumnName1").ToString
                            lblColName2.Text = dsSheet.Tables(0).Rows(0)("ColumnName2").ToString
                            ' row visibility true false
                            If lblColName1.Text <> "" Then
                                trcolumn1.Visible = True
                            Else
                                trcolumn1.Visible = False

                            End If

                            If lblColName2.Text <> "" Then
                                trcolumn2.Visible = True
                            Else
                                trcolumn2.Visible = False

                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub bindProjectData()
        Try



            Dim gtot As Integer = GrandTotal()
            Dim strq As String = "select isnull(project,0) as project,isnull(marks1,0) as marks1,isnull(marks2,0) as marks2 from studentsemmarks where bid=" & Request.QueryString("bt").ToString & " and stid=" & Request.QueryString("stid") & ""
            Dim dsSheet As New DataSet()
            dsSheet = CLS.fnQuerySelectDs(strq)
            If dsSheet IsNot Nothing Then
                If dsSheet.Tables IsNot Nothing Then
                    If dsSheet.Tables(0).Rows IsNot Nothing Then
                        If dsSheet.Tables(0).Rows.Count > 0 Then
                            lblProject.Text = dsSheet.Tables(0).Rows(0)("project").ToString
                            lblmarks1.Text = dsSheet.Tables(0).Rows(0)("marks1").ToString
                            lblmarks2.Text = dsSheet.Tables(0).Rows(0)("marks2").ToString
                            'Dim gtot As Integer = GrandTotal()
                            lblprojectmarkshd.Visible = True

                            trproject.Visible = True
                            If (IsNumeric(lblProject.Text) And IsNumeric(lblmarks1.Text) And IsNumeric(lblmarks2.Text) And gdnumeric = False) Then

                                gdnumeric = False
                            Else
                                gdnumeric = True
                            End If
                            If (gdnumeric = False) Then
                                lblGrandTotal.Text = CInt(dsSheet.Tables(0).Rows(0)("project").ToString) + CInt(dsSheet.Tables(0).Rows(0)("marks1").ToString) + CInt(dsSheet.Tables(0).Rows(0)("marks2").ToString) + gtot
                                trgrndtotal.Visible = True

                            Else
                                lblGrandTotal.Visible = False
                                trgrndtotal.Visible = False


                            End If

                        Else
                            lblprojectmarkshd.Visible = False

                            lblGrandTotal.Text = gtot
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Len(Session("username")) <= 0 Then
            Response.Redirect("../login.aspx")
        End If

        Try
            bindStudentData()
            bindStudentYear()
            bindStudentPerformanceSheet()
            bindProjectData()
            '---------------comment next line to solve point number 3 of issue list------------- -
            bindColumnName()
            ImageButton1.Attributes.Add("onclick", "javascript:CallPrint('print_grid');")
            Dim stRefid As String = "select refrenceid from studentregcourse where Courseid=" & Request.QueryString("cid").ToString & " and stid=" & Request.QueryString("stid")
            Dim dsRefid As New DataSet

            dsRefid = CLS.fnQuerySelectDs(stRefid)
            If dsRefid IsNot Nothing Then
                If dsRefid.Tables IsNot Nothing Then
                    If dsRefid.Tables(0).Rows IsNot Nothing Then
                        If dsRefid.Tables(0).Rows.Count > 0 Then
                            lblStid.Text = dsRefid.Tables(0).Rows(0)("refrenceid").ToString
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
        End Try
        ' export()
    End Sub
    Function GrandTotal() As Integer


        Dim total As Integer = 0
        Dim gTotal As Integer = 0
        If (dsSheet.Tables(0).Rows.Count > 0) Then
            For i = 0 To dsSheet.Tables(0).Rows.Count - 1
                'lbltotal = CType(row.FindControl("lblTotal"), Label)

                If (IsNumeric(dsSheet.Tables(0).Rows(i)("ExamMarks")) And IsNumeric(dsSheet.Tables(0).Rows(i)("AssignmentMarks")) And IsNumeric(dsSheet.Tables(0).Rows(i)("forum"))) Then
                    total = CInt(dsSheet.Tables(0).Rows(i)("ExamMarks")) + CInt(dsSheet.Tables(0).Rows(i)("AssignmentMarks")) + CInt(dsSheet.Tables(0).Rows(i)("forum"))
                    gTotal += total
                    gdnumeric = False
                Else
                    gdnumeric = True
                    Return gTotal
                End If

            Next
            Return gTotal
        End If
    End Function
    Protected Sub bindColumnVisibility()
        If dlstPerformanceSheet.Items.Count > 0 Then
            For i As Integer = 0 To dlstPerformanceSheet.Items.Count - 1
                'Dim lblcatgname As Label = DirectCast(dlstPerformanceSheet.Items(i).FindControl("tdexammarks"), HtmlTableCell)
                Try
                    Dim tcexam As HtmlTableCell = DirectCast(dlstPerformanceSheet.Items(i).FindControl("tdexammarks"), HtmlTableCell)
                    Dim tcasgn As HtmlTableCell = DirectCast(dlstPerformanceSheet.Items(i).FindControl("tdasgnmarks"), HtmlTableCell)
                    Dim tcdiscussion As HtmlTableCell = DirectCast(dlstPerformanceSheet.Items(i).FindControl("tddiscussforum"), HtmlTableCell)
                    Dim tccasestudy As HtmlTableCell = DirectCast(dlstPerformanceSheet.Items(i).FindControl("tdcasestudy"), HtmlTableCell)

                    'Dim row As DataListItem = e.Item
                    'If e.Item.ItemType = ListItemType.Item Then

                    'tcexam = CType(dlstPerformanceSheet.Items(i).("tdexammarks"), HtmlTableCell)
                    'tcasgn = CType(dlstPerformanceSheet.Items(i).("tdasgnmarks"), HtmlTableCell)
                    'tcdiscussion = CType(dlstPerformanceSheet.Items(i).("tddiscussforum"), HtmlTableCell)

                    Dim lblTotal As Label
                    lblTotal = CType(dlstPerformanceSheet.Items(i).FindControl("lblTotal"), Label)
                    Dim lblforum As Label
                    lblforum = CType(dlstPerformanceSheet.Items(i).FindControl("lblforum"), Label)
                    Dim lblExamMarks As Label
                    lblExamMarks = CType(dlstPerformanceSheet.Items(i).FindControl("lblExamMarks"), Label)
                    Dim lblAssignmentMarks As Label
                    lblAssignmentMarks = CType(dlstPerformanceSheet.Items(i).FindControl("lblAssignmentMarks"), Label)

                    Dim lblcasestudy As Label
                    lblcasestudy = CType(dlstPerformanceSheet.Items(i).FindControl("lblcasestudy"), Label)

                    If (IsNumeric(lblAssignmentMarks.Text) And IsNumeric(lblExamMarks.Text) And IsNumeric(lblforum.Text) And IsNumeric(lblcasestudy.Text)) Then
                        lblTotal.Text = CInt(lblAssignmentMarks.Text) + CInt(lblExamMarks.Text) + CInt(lblforum.Text) + CInt(lblcasestudy.Text)
                    Else
                        lblTotal.Text = "Not Applicable"
                    End If

                    Try


                        Dim strq As String = "select ExamMarks,AssignmentMarks,DiscussionForumMarks,CaseStudyMarks from evaluationcriteria where courseid=" & Request.QueryString("cid").ToString & ""
                        Dim dsSheet As New DataSet()
                        dsSheet = CLS.fnQuerySelectDs(strq)
                        If dsSheet IsNot Nothing Then
                            If dsSheet.Tables IsNot Nothing Then
                                If dsSheet.Tables(0).Rows IsNot Nothing Then
                                    If dsSheet.Tables(0).Rows.Count > 0 Then
                                        'hide exam marks
                                        If (dsSheet.Tables(0).Rows(0)("ExamMarks").ToString() = False) Then
                                            tcexam.Visible = False
                                            tdhdngexammarks.Visible = False

                                        Else
                                            tcexam.Visible = True
                                            tdhdngexammarks.Visible = True
                                        End If
                                        'hide assignment mrks
                                        If (dsSheet.Tables(0).Rows(0)("AssignmentMarks").ToString() = False) Then
                                            tcasgn.Visible = False
                                            tdhdngasgnmarks.Visible = False

                                        Else
                                            tcasgn.Visible = True
                                            tdhdngasgnmarks.Visible = True
                                        End If
                                        'end assignment mrks

                                        'hide discussion forum marks
                                        If (dsSheet.Tables(0).Rows(0)("DiscussionForumMarks").ToString() = False) Then
                                            tcdiscussion.Visible = False
                                            tdhdngdiscussforum.Visible = False

                                        Else
                                            tcdiscussion.Visible = True
                                            tdhdngdiscussforum.Visible = True
                                        End If
                                        'end discussion forum marks

                                        'hide case study marks
                                        If (dsSheet.Tables(0).Rows(0)("CaseStudyMarks").ToString() = False) Then
                                            tccasestudy.Visible = False
                                            tdhdngcasestudy.Visible = False

                                        Else
                                            tccasestudy.Visible = True
                                            tdhdngcasestudy.Visible = True
                                        End If
                                        'hide case study marks

                                    End If
                                End If
                            End If
                        End If
                    Catch ex As Exception
                    End Try




                    'End If

                Catch ex As Exception
                End Try
            Next
        End If
    End Sub
    Protected Sub dlstPerformanceSheet_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlstPerformanceSheet.ItemDataBound
        

        'Try
        '    Dim row As DataListItem = e.Item
        '    If e.Item.ItemType = ListItemType.Item Then
        '        Dim lblTotal As Label
        '        lblTotal = CType(row.FindControl("lblTotal"), Label)
        '        Dim lblforum As Label
        '        lblforum = CType(row.FindControl("lblforum"), Label)
        '        Dim lblExamMarks As Label
        '        lblExamMarks = CType(row.FindControl("lblExamMarks"), Label)
        '        Dim lblAssignmentMarks As Label
        '        lblAssignmentMarks = CType(row.FindControl("lblAssignmentMarks"), Label)
        '        If (IsNumeric(lblAssignmentMarks.Text) And IsNumeric(lblExamMarks.Text) And IsNumeric(lblforum.Text)) Then
        '            lblTotal.Text = CInt(lblAssignmentMarks.Text) + CInt(lblExamMarks.Text) + CInt(lblforum.Text)
        '        Else
        '            lblTotal.Text = "Not Applicable"
        '        End If
        '        End If
        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("SelectStudentPerformance.aspx?bid=" + Request.QueryString("bt") + "&Cid=" + Request.QueryString("cid"))
    End Sub

   
End Class
