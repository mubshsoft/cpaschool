
Partial Class Admin_AddMarksEvaluation
    Inherits System.Web.UI.Page
    Dim pid As Integer
    Dim dsStudent As New DataSet()

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
                'FillSemester()
                bindgrid()
                'ChkPaperMarks()
                chkEnableDiasable()

            End If
        Catch ex As Exception
        End Try

    End Sub
    Sub bindgrid()
        Try
            Dim strq As String
            If ViewState("chk") <> 1 Then
                'strq = "select distinct(bt.stid),st.firstname +' '+ st.lastname as fullname ,st.email,bt.bid,ss.semid,ISNULL(mrk.ExamMarks, 0) as ExamMarks,ISNULL(mrk.AssignmentMarks, 0) as AssignmentMarks,ISNULL(mrk.forum, 0) as forum,ISNULL(mrk.ExamStatus, 0) as ExamStatus,ISNULL(mrk.AssignStatus, 0) as AssignStatus from studentregbatch bt INNER JOIN student st on bt.stid=st.stid INNER JOIN studentsemester ss on ss.stid=bt.stid and ss.courseid=bt.courseid Inner join module mo on ss.semid=mo.semid INNER JOIN paper pa on pa.moduleid=mo.moduleid LEFT OUTER JOIN StudentPaperMarks mrk on mrk.bid=bt.bid and pa.paperid=mrk.paperid and mrk.stid=bt.stid where bt.bid=" & Request.QueryString("bt").ToString & " and ss.semid=" & Request.QueryString("sid").ToString & " and pa.paperid=" & Request.QueryString("pid").ToString & " and currentstatus<>0"
                strq = "select distinct(bt.stid),st.firstname +' '+ st.lastname as fullname ,st.email,bt.bid,ss.semid,ISNULL(mrk.ExamMarks, 0) as ExamMarks,ISNULL(mrk.AssignmentMarks, 0) as AssignmentMarks,ISNULL(mrk.forum, 0) as forum,mrk.ExamStatus as ExamStatus,mrk.AssignStatus as AssignStatus from studentregbatch bt INNER JOIN student st on bt.stid=st.stid INNER JOIN studentsemester ss on ss.stid=bt.stid and ss.courseid=bt.courseid Inner join module mo on ss.semid=mo.semid INNER JOIN paper pa on pa.moduleid=mo.moduleid LEFT OUTER JOIN StudentPaperMarks mrk on mrk.bid=bt.bid and pa.paperid=mrk.paperid and mrk.stid=bt.stid where bt.bid=" & Request.QueryString("bt").ToString & " and ss.semid=" & Request.QueryString("sid").ToString & " and pa.paperid=" & Request.QueryString("pid").ToString & " and currentstatus<>0"

            Else
                'strq = "select distinct(bt.stid),st.firstname +' '+ st.lastname as fullname ,st.email,bt.bid,ss.semid,ISNULL(mrk.ExamMarks, 0) as ExamMarks,ISNULL(mrk.AssignmentMarks, 0) as AssignmentMarks,ISNULL(mrk.forum, 0) as forum,ISNULL(mrk.ExamStatus, 0) as ExamStatus,ISNULL(mrk.AssignStatus, 0) as AssignStatus from studentregbatch bt INNER JOIN student st on bt.stid=st.stid INNER JOIN studentsemester ss on ss.stid=bt.stid and ss.courseid=bt.courseid Inner join module mo on ss.semid=mo.semid INNER JOIN paper pa on pa.moduleid=mo.moduleid LEFT OUTER JOIN StudentPaperMarks mrk on mrk.bid=bt.bid and pa.paperid=mrk.paperid and mrk.stid=bt.stid where  bt.bid=" & Request.QueryString("bt").ToString & " and ss.semid=" & ddlSem.SelectedValue & " and pa.paperid=" & Request.QueryString("pid").ToString & ""

            End If


            dsStudent = CLS.fnQuerySelectDs(strq)
            If dsStudent IsNot Nothing Then
                If dsStudent.Tables IsNot Nothing Then
                    If dsStudent.Tables(0).Rows IsNot Nothing Then
                        If dsStudent.Tables(0).Rows.Count > 0 Then
                            GrdStudent.DataSource = dsStudent
                            GrdStudent.DataBind()
                            GrdStudent.Visible = True
                        Else
                            GrdStudent.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            Dim pid As Integer = Request.QueryString("pid")
            Dim str As String
            Dim chekw As CheckBox
            Dim chekw1 As CheckBox
            Dim lblstid As Label
            Dim lblbid As Label
            Dim lblcourseid As Label
            Dim txtExamMarks As TextBox
            Dim txtAssignMarks As TextBox
            Dim txtForumMarks As TextBox

            For Each cc1 As GridViewRow In GrdStudent.Rows
                txtExamMarks = DirectCast(cc1.FindControl("txtExamMarks"), TextBox)
                txtAssignMarks = DirectCast(cc1.FindControl("txtAssignMarks"), TextBox)
                txtForumMarks = DirectCast(cc1.FindControl("txtforumMarks"), TextBox)

                chekw = DirectCast(cc1.FindControl("chkFail"), CheckBox)
                chekw1 = DirectCast(cc1.FindControl("chkAssignment"), CheckBox)

                lblstid = DirectCast(cc1.FindControl("lblstid"), Label)
                lblbid = DirectCast(cc1.FindControl("lblbid"), Label)
                lblcourseid = DirectCast(cc1.FindControl("lblcourseid"), Label)
                Dim strq As String = "select *from StudentPaperMarks where stid=" & lblstid.Text & " and paperId=" & pid & " and  bid=" & lblbid.Text & ""
                Dim dsmarks As New DataSet()
                dsmarks = CLS.fnQuerySelectDs(strq)
                If Request.QueryString("add") = 1 Then
                    If Len(txtExamMarks.Text) > 0 Then
                        If dsmarks IsNot Nothing Then
                            If dsmarks.Tables IsNot Nothing Then

                                If dsmarks.Tables(0).Rows IsNot Nothing Then
                                    If dsmarks.Tables(0).Rows.Count > 0 Then
                                        If chekw.Checked Then
                                            str = "update StudentPaperMarks set stid= " & lblstid.Text & " ,paperid= " & pid & ",bid=" & lblbid.Text & ",ExamMarks='" & txtExamMarks.Text & "',ExamStatus=0  where stid=" & lblstid.Text & " and paperId=" & pid & " and  bid=" & lblbid.Text & ""
                                        Else
                                            str = "update StudentPaperMarks set stid= " & lblstid.Text & " ,paperid= " & pid & ",bid=" & lblbid.Text & ",ExamMarks='" & txtExamMarks.Text & "',ExamStatus=1  where stid=" & lblstid.Text & " and paperId=" & pid & " and  bid=" & lblbid.Text & ""
                                        End If
                                    Else
                                        If chekw.Checked Then
                                            str = "insert into StudentPaperMarks(stid,paperid,bid,ExamMarks,ExamStatus)values( " & lblstid.Text & " , " & pid & "," & lblbid.Text & ",'" & txtExamMarks.Text & "',0)"
                                        Else
                                            str = "insert into StudentPaperMarks(stid,paperid,bid,ExamMarks,ExamStatus)values( " & lblstid.Text & " , " & pid & "," & lblbid.Text & ",'" & txtExamMarks.Text & "',1)"
                                        End If

                                    End If
                                    CLS.fnExecuteQuery(str)
                                    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Exam Marks  Saved Successfully!');  location.href='SelectExamSet.aspx' ;", True)
                                End If

                            End If
                        End If
                    End If
                ElseIf Request.QueryString("add2") = 2 Then
                    If Len(txtAssignMarks.Text) > 0 Then
                        If dsmarks IsNot Nothing Then
                            If dsmarks.Tables IsNot Nothing Then

                                If dsmarks.Tables(0).Rows IsNot Nothing Then
                                    If dsmarks.Tables(0).Rows.Count > 0 Then
                                        If chekw1.Checked Then
                                            str = "update StudentPaperMarks set stid= " & lblstid.Text & " ,paperid= " & pid & ",bid=" & lblbid.Text & ",AssignmentMarks='" & txtAssignMarks.Text & "',AssignStatus=0  where stid=" & lblstid.Text & " and paperId=" & pid & " and  bid=" & lblbid.Text & ""
                                        Else
                                            str = "update StudentPaperMarks set stid= " & lblstid.Text & " ,paperid= " & pid & ",bid=" & lblbid.Text & ",AssignmentMarks='" & txtAssignMarks.Text & "',AssignStatus=1  where stid=" & lblstid.Text & " and paperId=" & pid & " and  bid=" & lblbid.Text & ""

                                        End If


                                    Else
                                        If chekw1.Checked Then
                                            str = "insert into StudentPaperMarks(stid,paperid,bid,AssignmentMarks,AssignStatus)values( " & lblstid.Text & " , " & pid & "," & lblbid.Text & ",'" & txtAssignMarks.Text & "',0)"
                                        Else
                                            str = "insert into StudentPaperMarks(stid,paperid,bid,AssignmentMarks,AssignStatus)values( " & lblstid.Text & " , " & pid & "," & lblbid.Text & ",'" & txtAssignMarks.Text & "',1)"


                                        End If
                                    End If
                                End If
                                CLS.fnExecuteQuery(str)
                                ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Assignment Marks saved Successfully!');  location.href='SelectExamSet.aspx' ;", True)
                            End If

                        End If

                    End If
                ElseIf Request.QueryString("diss") = 1 Then
                    If Len(txtForumMarks.Text) > 0 Then
                        If dsmarks IsNot Nothing Then
                            If dsmarks.Tables IsNot Nothing Then

                                If dsmarks.Tables(0).Rows IsNot Nothing Then
                                    If dsmarks.Tables(0).Rows.Count > 0 Then

                                        str = "update StudentPaperMarks set stid= " & lblstid.Text & " ,paperid= " & pid & ",bid=" & lblbid.Text & ",forum='" & txtForumMarks.Text & "' where stid=" & lblstid.Text & " and paperId=" & pid & " and  bid=" & lblbid.Text & ""

                                    Else

                                        str = "insert into StudentPaperMarks(stid,paperid,bid,forum)values( " & lblstid.Text & " , " & pid & "," & lblbid.Text & ",'" & txtForumMarks.Text & "')"

                                    End If
                                    CLS.fnExecuteQuery(str)
                                    ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Forum Marks saved Successfully!');  location.href='SelectExamSet.aspx' ;", True)
                                End If
                            End If
                        End If

                    End If
                End If
                'ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Successfully!');  location.href='SelectExamSet.aspx' ;", True)

            Next
            Response.Redirect("SelectExamSet.aspx?cid=" + Request.QueryString("cid") + "&bt=" + Request.QueryString("bt") + "&sid=" + Request.QueryString("sid") + "&pid=" + Request.QueryString("pid") + "&mid=" + Request.QueryString("mid") + "&back=1")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub chkStudent(ByVal stid As Integer, ByVal bid As Integer)
        Try
            Dim strq As String = "select *from StudentPaperMarks where stid=" & stid & " and ExamMarks=" & bid & ""
            Dim dsmarks As New DataSet()
            dsmarks = CLS.fnQuerySelectDs(strq)
            If dsmarks IsNot Nothing Then
                If dsmarks.Tables IsNot Nothing Then

                    If dsmarks.Tables(0).Rows IsNot Nothing Then
                        If dsmarks.Tables(0).Rows.Count > 0 Then
                        Else
                            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Exam Marks is not assign for this student!');", True)
                            Exit Sub
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
   
    Private Sub chkEnableDiasable()
        Try
            Dim chekwExam As CheckBox
            Dim chekwAss As CheckBox
            For Each cc1 As GridViewRow In GrdStudent.Rows
                chekwExam = DirectCast(cc1.FindControl("chkFail"), CheckBox)
                chekwAss = DirectCast(cc1.FindControl("chkAssignment"), CheckBox)
                Dim ExamStatus As Label = DirectCast(cc1.FindControl("lblexamstaus"), Label)
                Dim AssignStatus As Label = DirectCast(cc1.FindControl("lblAssignStatus"), Label)
                If ExamStatus.Text = "False" Then
                    chekwExam.Checked = True
                Else
                    chekwExam.Checked = False
                End If

                If AssignStatus.Text = "False" Then
                    chekwAss.Checked = True
                Else
                    chekwAss.Checked = False
                End If

                If Request.QueryString("add") = 1 Then
                    GrdStudent.Columns(5).Visible = False
                    GrdStudent.Columns(6).Visible = False
                    GrdStudent.Columns(8).Visible = False
                    lblHeading.Text = "Add Exam Marks"
                ElseIf Request.QueryString("diss") = 1 Then
                    GrdStudent.Columns(4).Visible = False
                    GrdStudent.Columns(5).Visible = False
                    GrdStudent.Columns(7).Visible = False
                    GrdStudent.Columns(8).Visible = False
                    lblHeading.Text = "Add Forum Marks"
                ElseIf Request.QueryString("add2") = 2 Then
                    GrdStudent.Columns(4).Visible = False
                    GrdStudent.Columns(6).Visible = False
                    GrdStudent.Columns(7).Visible = False
                    lblHeading.Text = "Add Assignment Marks"

                End If

            Next
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdStudent_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdStudent.RowDataBound

        Try
            Dim row As GridViewRow = e.Row
            Dim strSort As String = String.Empty

            If row.DataItem Is Nothing Then
                Exit Sub
            End If
            Dim txtExMarks As TextBox
            Dim txtAssMarks As TextBox


            txtExMarks = DirectCast(row.FindControl("txtExamMarks"), TextBox)
            txtAssMarks = DirectCast(row.FindControl("txtAssignMarks"), TextBox)

        Catch ex As Exception
        End Try

    End Sub

    Protected Sub Imagebutton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Imagebutton1.Click

    End Sub

    Protected Sub GrdStudent_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdStudent.PageIndexChanging
        Try
            GrdStudent.PageIndex = e.NewPageIndex
            bindgrid()
            chkEnableDiasable()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim Redirecturl As String = "SelectExamSet.aspx?cid=" + Request.QueryString("cid") + "&bt=" + Request.QueryString("bt") + "&sid=" + Request.QueryString("sid") + "&pid=" + Request.QueryString("pid") + "&mid=" + Request.QueryString("mid") + "&back=1"
        Response.Redirect(Redirecturl)
        ' Response.Redirect("SelectExamSet.aspx")
    End Sub
 
End Class
