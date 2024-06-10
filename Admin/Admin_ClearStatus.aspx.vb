
Partial Class Admin_ClearStatus
    Inherits System.Web.UI.Page
    Dim courseid As Integer
    Dim stid As Integer
    Dim batchid As Integer
    Protected semTitle As String
    Protected stEmail As String
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
            courseid = Request.QueryString("courseid")
            stid = Request.QueryString("stid")
            batchid = Request.QueryString("batchid")
            getCurrentSemid()
            If Not IsPostBack Then
                FillSemester()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Function getCurrentSemid() As Integer
        Try
            'Dim strq As String = "select ss.semid,s.Semestertitle from studentSemester ss inner join semester s on ss.semid=s.semid where ss.stid=" & Request.QueryString("stid") & " and ss.courseid=" & Request.QueryString("courseid") & " and ss.currentstatus=2"
            Dim strq As String = "select ss.semid,s.Semestertitle,st.email from studentSemester ss inner join semester s on ss.semid=s.semid INNER JOIN student st on st.stid=ss.stid where ss.stid=" & Request.QueryString("stid") & " and ss.courseid=" & Request.QueryString("courseid") & " and ss.currentstatus=2"
            Dim dsCurrentSemID As New DataSet()
            Dim i As Integer
            dsCurrentSemID = CLS.fnQuerySelectDs(strq)
            If dsCurrentSemID IsNot Nothing Then
                If dsCurrentSemID.Tables IsNot Nothing Then
                    If dsCurrentSemID.Tables(0).Rows IsNot Nothing Then
                        If dsCurrentSemID.Tables(0).Rows.Count > 0 Then
                            getCurrentSemid = CInt(dsCurrentSemID.Tables(0).Rows(i)("semid").ToString)
                            semTitle = dsCurrentSemID.Tables(0).Rows(i)("semestertitle").ToString
                            stEmail = dsCurrentSemID.Tables(0).Rows(i)("email").ToString
                        End If
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Function

    Protected Sub imgDetail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgDetail.Click
        table1.Visible = True
        tblpayment.Visible = False

        bindExamData()
        bindDissData()
    End Sub
    Private Sub FillSemester()
        Dim strq As String = "select ss.semid,se.SemesterTitle,ss.courseid,ss.stid from studentSemester ss INNER JOIN Semester se on se.SemId=ss.Semid where stid=" & stid & " and ss.courseid=" & Request.QueryString("courseid") & ""
        Dim dsSemester As New DataSet()
        dsSemester = CLS.fnQuerySelectDs(strq)
        If (dsSemester.Tables(0).Rows.Count > 0) Then

            ddlSem.DataTextField = "SemesterTitle"
            ddlSem.DataValueField = "semid"

            ddlSem.DataSource = dsSemester

            ddlSem.DataBind()
            ddlSem.Items.Insert(0, "--SELECT--")
        End If

    End Sub

    Protected Sub imgMarksComplete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMarksComplete.Click
        Try
            Dim strq As String
            If ViewState("chk") <> 1 Then
                strq = "select semid from studentSemester where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid") & " and currentstatus in(1,2)"

            Else
                strq = "select semid from studentSemester where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid") & " and currentstatus in(1,2) and semid=" & ddlSem.SelectedValue & ""

            End If
            'Dim strq As String = "select semid from studentSemester where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid") & " and currentstatus in(1,2) and semid=" & ddlSem.SelectedValue & ""
            Dim dsCurrentSemID As New DataSet()

            Dim i As Integer
            Dim SemID As Integer
            dsCurrentSemID = CLS.fnQuerySelectDs(strq)
            If dsCurrentSemID IsNot Nothing Then
                If dsCurrentSemID.Tables IsNot Nothing Then

                    If dsCurrentSemID.Tables(0).Rows IsNot Nothing Then
                        If dsCurrentSemID.Tables(0).Rows.Count > 0 Then
                            If ViewState("chk") <> 1 Then
                                SemID = getCurrentSemid()
                                CLS.UpdateStudentMarksStatus("sp_UpdateStudentMarksStatus", courseid, SemID, stid, 1)
                            Else
                                SemID = CInt(dsCurrentSemID.Tables(0).Rows(i)("semid").ToString)
                                CLS.UpdateStudentMarksStatus("sp_UpdateStudentMarksStatus", courseid, SemID, stid, 1)
                            End If

                        Else
                            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Invalid semester for this student. current semester is " + ddlSem.SelectedItem.Text + "'); ", True)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub imgMarksnotComplete_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMarksnotComplete.Click
        Try
            Dim strq As String = "select semid from studentSemester where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid") & " and currentstatus in(1,2) and semid=" & ddlSem.SelectedValue & ""
            Dim dsCurrentSemID As New DataSet()
            Dim i As Integer
            Dim SemID As Integer
            dsCurrentSemID = CLS.fnQuerySelectDs(strq)
            If dsCurrentSemID IsNot Nothing Then
                If dsCurrentSemID.Tables IsNot Nothing Then
                    If dsCurrentSemID.Tables(0).Rows IsNot Nothing Then
                        If dsCurrentSemID.Tables(0).Rows.Count > 0 Then
                            If ViewState("chk") <> 1 Then
                                SemID = getCurrentSemid()
                                CLS.UpdateStudentMarksStatus("sp_UpdateStudentMarksStatus", courseid, SemID, stid, 1)
                            Else
                                SemID = CInt(dsCurrentSemID.Tables(0).Rows(i)("semid").ToString)
                                CLS.UpdateStudentMarksStatus("sp_UpdateStudentMarksStatus", courseid, SemID, stid, 0)
                            End If

                            
                        Else
                            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Invalid semester for this student. current semester is " + ddlSem.SelectedItem.Text + "'); ", True)
                        End If
                        End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub imgFeesDetail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgFeesDetail.Click
        table1.Visible = False

        tblpayment.Visible = True
        'Response.Redirect("PaymentdetailsForCourse.aspx?&stid=" & Request.QueryString("stid") & "&courseid=" & Request.QueryString("courseid"))
        bindgridPayment()

    End Sub

    Protected Sub ImgFeesPaid_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgFeesPaid.Click
        Dim dsFee As New DataSet
        Dim i As Integer
        Dim SemID As Integer
        Try
            If ViewState("chk") <> 1 Then
            Else

            End If
            Dim str As String = "select * from Feedetails where type='One Time Fee' and courseid=" & Request.QueryString("courseid")
            Dim DsType As New DataSet()
            DsType = CLS.fnQuerySelectDs(str)
            If DsType IsNot Nothing Then
                If DsType.Tables IsNot Nothing Then
                    If DsType.Tables(0).Rows IsNot Nothing Then
                        If DsType.Tables(0).Rows.Count > 0 Then
                            CLS.UpdateStudentFeeStatusComplete("sp_UpdateStudentFeeStatusComplete", courseid, stid, 1)
                        Else
                            Dim strq As String
                            If ViewState("chk") <> 1 Then
                                strq = "select semid from studentSemester where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid") & " and currentstatus in(1,2) "
                            Else
                                strq = "select semid from studentSemester where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid") & " and currentstatus in(1,2) and semid=" & ddlSem.SelectedValue & ""
                            End If
                            'Dim strq As String = "select semid from studentSemester where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid") & " and currentstatus in(1,2) and semid=" & ddlSem.SelectedValue & ""
                            Dim dsSemID As New DataSet()
                            dsSemID = CLS.fnQuerySelectDs(strq)


                            If dsSemID IsNot Nothing Then
                                If dsSemID.Tables IsNot Nothing Then
                                    If dsSemID.Tables(0).Rows IsNot Nothing Then
                                        If dsSemID.Tables(0).Rows.Count > 0 Then
                                            If ViewState("chk") <> 1 Then
                                                SemID = getCurrentSemid()
                                                CLS.UpdateStudentFeeStatusSemester("sp_UpdateStudentFeeStatusSemester", courseid, SemID, stid, 1)
                                            Else
                                                SemID = CInt(dsSemID.Tables(0).Rows(0)("semid").ToString)
                                                CLS.UpdateStudentFeeStatusSemester("sp_UpdateStudentFeeStatusSemester", courseid, SemID, stid, 1)
                                            End If

                                        Else
                                            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Invalid semester for this student. current semester is  " + ddlSem.SelectedItem.Text + "'); ", True)
                                        End If
                                    End If
                                End If
                            End If
                            
                        End If
                    End If
                End If
            End If



        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ImgFeesUnpaid_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgFeesUnpaid.Click
        Dim dsFee As New DataSet
        Dim SemID As Integer
        Try

            Dim str As String = "select * from Feedetails where type='One Time Fee' and courseid=" & Request.QueryString("courseid")
            Dim DsType As New DataSet()
            DsType = CLS.fnQuerySelectDs(str)
            If DsType IsNot Nothing Then
                If DsType.Tables IsNot Nothing Then
                    If DsType.Tables(0).Rows IsNot Nothing Then
                        If DsType.Tables(0).Rows.Count > 0 Then
                            CLS.UpdateStudentFeeStatusComplete("sp_UpdateStudentFeeStatusComplete", courseid, stid, 0)
                        Else
                            Dim strq As String = "select semid from studentSemester where stid=" & Request.QueryString("stid") & " and courseid=" & Request.QueryString("courseid") & " and currentstatus in(1,2) and semid=" & ddlSem.SelectedValue & ""
                            Dim dsSemID As New DataSet()
                            dsSemID = CLS.fnQuerySelectDs(strq)

                           
                            If dsSemID IsNot Nothing Then
                                If dsSemID.Tables IsNot Nothing Then
                                    If dsSemID.Tables(0).Rows IsNot Nothing Then
                                        If dsSemID.Tables(0).Rows.Count > 0 Then
                                            If ViewState("chk") <> 1 Then
                                                SemID = getCurrentSemid()
                                                CLS.UpdateStudentFeeStatusSemester("sp_UpdateStudentFeeStatusSemester", courseid, SemID, stid, 0)
                                            Else
                                                SemID = CInt(dsSemID.Tables(0).Rows(0)("semid").ToString)
                                                CLS.UpdateStudentFeeStatusSemester("sp_UpdateStudentFeeStatusSemester", courseid, SemID, stid, 0)
                                            End If
                                            
                                        Else
                                            ScriptManager.RegisterStartupScript(Me, GetType(Page), UniqueID, "alert('Invalid semester for this student. current semester is  " + ddlSem.SelectedItem.Text + "'); ", True)
                                        End If
                                    End If
                                End If
                            End If

                        End If
                    End If
                End If
            End If



        Catch ex As Exception
        End Try
    End Sub
    Sub bindExamData()
        Try
            Dim strq As String
            Dim SemID As Integer
            If ViewState("chk") <> 1 Then
                SemID = getCurrentSemid()
                strq = "select  mrk.paperid,mrk.stid,mrk.bid,isnull(mrk.ExamMarks,0) as ExamMarks ,isnull(mrk.AssignmentMarks,0) as AssignmentMarks,isnull(mrk.forum,0) as forum,ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,p.PaperTitle from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid where ss.feestatus = 1 And m.semid = " & SemID & " And mrk.stid =" & Request.QueryString("stid") & ""
            Else
                If ddlSem.SelectedIndex = 0 Then
                    SemID = getCurrentSemid()
                    strq = "select  mrk.paperid,mrk.stid,mrk.bid,isnull(mrk.ExamMarks,0) as ExamMarks ,isnull(mrk.AssignmentMarks,0) as AssignmentMarks,isnull(mrk.forum,0) as forum,ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,p.PaperTitle from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid where ss.feestatus = 1 And m.semid = " & SemID & " And mrk.stid =" & Request.QueryString("stid") & ""

                Else
                    strq = "select  mrk.paperid,mrk.stid,mrk.bid,isnull(mrk.ExamMarks,0) as ExamMarks ,isnull(mrk.AssignmentMarks,0) as AssignmentMarks,isnull(mrk.forum,0) as forum,ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,p.PaperTitle from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid where ss.feestatus = 1 And m.semid = " & ddlSem.SelectedValue & " And mrk.stid =" & Request.QueryString("stid") & ""

                End If
            End If

            'Dim strq As String = "select  mrk.paperid,mrk.stid,mrk.bid,isnull(mrk.ExamMarks,0) as ExamMarks ,isnull(mrk.AssignmentMarks,0) as AssignmentMarks,isnull(mrk.forum,0) as forum,ss.SemId,(st.firstname +'  '+ st.lastname) as fullname,st.email,p.PaperTitle from studentpapermarks mrk LEFT OUTER JOIN paper p on p.paperid=mrk.paperid Inner Join module m on m.moduleid=p.moduleid INNER JOIN Student st on st.stid=mrk.stid INNER JOIN  studentsemester ss on ss.SemId=m.semid and ss.stid=mrk.stid where ss.feestatus = 1 And m.semid = " & ddlSem.SelectedValue & " And mrk.stid =" & Request.QueryString("stid") & ""
            Dim dsExam As New DataSet()
            dsExam = CLS.fnQuerySelectDs(strq)
            If dsExam IsNot Nothing Then
                If dsExam.Tables IsNot Nothing Then
                    If dsExam.Tables(0).Rows IsNot Nothing Then
                        If dsExam.Tables(0).Rows.Count > 0 Then
                            GrdPaperMarks.DataSource = dsExam
                            GrdPaperMarks.DataBind()
                            GrdPaperMarks.Visible = True
                            lblExam.Visible = True
                            tr1.Visible = True
                            tr2.Visible = True
                            tr3.Visible = True
                        Else
                            tr1.Visible = False
                            tr2.Visible = False
                            tr3.Visible = False
                            lblExam.Visible = False
                            GrdPaperMarks.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Sub bindDissData()
        Try

            Dim strq As String
            Dim SemID As Integer
            If ViewState("chk") <> 1 Then
                SemID = getCurrentSemid()
                strq = "select mrk.stid,mrk.bid,ss.semid,(st.firstname +'  '+ st.lastname) as fullname,st.email,isnull(mrk.Project,0) as Project,isnull(mrk.marks1,0) as marks1 ,isnull(mrk.marks2,0) as marks2 from studentSemmarks mrk INNER JOIN studentsemester ss on  ss.stid=mrk.stid INNER JOIN student st on st.stid=mrk.stid where ss.feestatus=1 and ss.semid=" & SemID & " and mrk.stid=" & Request.QueryString("stid") & ""
            Else
                If ddlSem.SelectedIndex = 0 Then
                    SemID = getCurrentSemid()
                    strq = "select mrk.stid,mrk.bid,ss.semid,(st.firstname +'  '+ st.lastname) as fullname,st.email,isnull(mrk.Project,0) as Project,isnull(mrk.marks1,0) as marks1 ,isnull(mrk.marks2,0) as marks2 from studentSemmarks mrk INNER JOIN studentsemester ss on  ss.stid=mrk.stid INNER JOIN student st on st.stid=mrk.stid where ss.feestatus=1 and ss.semid=" & SemID & " and mrk.stid=" & Request.QueryString("stid") & ""
                Else
                    strq = "select mrk.stid,mrk.bid,ss.semid,(st.firstname +'  '+ st.lastname) as fullname,st.email,isnull(mrk.Project,0) as Project,isnull(mrk.marks1,0) as marks1 ,isnull(mrk.marks2,0) as marks2 from studentSemmarks mrk INNER JOIN studentsemester ss on  ss.stid=mrk.stid INNER JOIN student st on st.stid=mrk.stid where ss.feestatus=1 and ss.semid=" & ddlSem.SelectedValue & " and mrk.stid=" & Request.QueryString("stid") & ""

                End If
            End If

            'Dim SemID As Integer = getCurrentSemid()
            'Dim strq As String = "select mrk.stid,mrk.bid,ss.semid,(st.firstname +'  '+ st.lastname) as fullname,st.email,mrk.forum,mrk.Project,mrk.marks1,mrk.marks2 from studentSemmarks mrk INNER JOIN studentsemester ss on ss.semid=mrk.semid and ss.stid=mrk.stid INNER JOIN student st on st.stid=mrk.stid where ss.feestatus=1 and mrk.semid=" & ddlSem.SelectedValue & " and mrk.stid=" & Request.QueryString("stid") & ""
            'Dim strq As String = "select mrk.stid,mrk.bid,ss.semid,(st.firstname +'  '+ st.lastname) as fullname,st.email,isnull(mrk.Project,0) as Project,isnull(stm.forum,0) as forum,isnull(mrk.marks1,0) as marks1 ,isnull(mrk.marks2,0) as marks2 from studentSemmarks mrk INNER JOIN studentsemester ss on  ss.stid=mrk.stid INNER JOIN student st on st.stid=mrk.stid INNER JOIN studentPapermarks stm on stm.stid=mrk.stid and stm.bid=mrk.bid where ss.feestatus=1 and ss.semid=" & ddlSem.SelectedValue & " and mrk.stid=" & Request.QueryString("stid") & ""
            'Dim strq As String = "select mrk.stid,mrk.bid,ss.semid,(st.firstname +'  '+ st.lastname) as fullname,st.email,isnull(mrk.Project,0) as Project,isnull(mrk.marks1,0) as marks1 ,isnull(mrk.marks2,0) as marks2 from studentSemmarks mrk INNER JOIN studentsemester ss on  ss.stid=mrk.stid INNER JOIN student st on st.stid=mrk.stid where ss.feestatus=1 and ss.semid=" & ddlSem.SelectedValue & " and mrk.stid=" & Request.QueryString("stid") & ""
            Dim dsDiss As New DataSet()
            dsDiss = CLS.fnQuerySelectDs(strq)
            If dsDiss IsNot Nothing Then
                If dsDiss.Tables IsNot Nothing Then
                    If dsDiss.Tables(0).Rows IsNot Nothing Then
                        If dsDiss.Tables(0).Rows.Count > 0 Then
                            GrdDisscussionMarks.DataSource = dsDiss
                            GrdDisscussionMarks.DataBind()
                            GrdDisscussionMarks.Visible = True
                            lblDisscussion.Visible = True
                            tr4.Visible = True
                            tr5.Visible = True
                            tr6.Visible = True
                        Else
                            tr4.Visible = False
                            tr5.Visible = False
                            tr6.Visible = False
                            ' table1.Visible = False
                            lblDisscussion.Visible = False
                            GrdDisscussionMarks.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub GrdDisscussionMarks_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdDisscussionMarks.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        If row.DataItem Is Nothing Then
            Exit Sub
        End If
        'Dim lblforum As Label
        Dim lblProject As Label
        Dim lblmarks1 As Label
        Dim lblmarks2 As Label
        'lblforum = CType(row.FindControl("lblforum"), Label)
        lblProject = CType(row.FindControl("lblProject"), Label)
        lblmarks1 = CType(row.FindControl("lblmarks1"), Label)
        lblmarks2 = CType(row.FindControl("lblmarks2"), Label)
        'If lblforum.Text = "" Then
        '    lblforum.Text = "--"
        'End If
        If lblProject.Text = "" Then
            lblProject.Text = "--"
        End If
        If lblmarks1.Text = "" Then
            lblmarks1.Text = "--"
        End If
        If lblmarks2.Text = "" Then
            lblmarks2.Text = "--"
        End If
    End Sub

    Protected Sub GrdPaperMarks_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdPaperMarks.RowDataBound
        Dim row As GridViewRow = e.Row
        Dim strSort As String = String.Empty

        If row.DataItem Is Nothing Then
            Exit Sub
        End If
        Dim lblExamMarks As Label
        Dim lblAssignmentMarks As Label
        Dim lblforum As Label

        lblExamMarks = CType(row.FindControl("lblExamMarks"), Label)
        lblAssignmentMarks = CType(row.FindControl("lblAssignmentMarks"), Label)
        lblforum = CType(row.FindControl("lblforum1"), Label)

        If lblExamMarks.Text = "" Then
            lblExamMarks.Text = "--"
        End If
        If lblAssignmentMarks.Text = "" Then
            lblAssignmentMarks.Text = "--"
        End If

        If lblforum.Text = "" Then
            lblforum.Text = "--"
        End If

    End Sub

    Sub bindgridPayment()
        Try
            Dim strq As String
            Dim SemID As Integer
            If ViewState("chk") <> 1 Then
                SemID = getCurrentSemid()
                strq = "select id,DDNo,Amount,DDdate,paymentdetails.Courseid,CourseTitle from paymentdetails INNER JOIN Course on paymentdetails.Courseid=Course.Courseid where  paymentdetails.stid=" & Request.QueryString("stid") & " and  paymentdetails.courseid=" & Request.QueryString("courseid") & " and paymentdetails.semid=" & SemID & ""
            Else
                If ddlSem.SelectedIndex = 0 Then
                    SemID = getCurrentSemid()
                    strq = "select id,DDNo,Amount,DDdate,paymentdetails.Courseid,CourseTitle from paymentdetails INNER JOIN Course on paymentdetails.Courseid=Course.Courseid where  paymentdetails.stid=" & Request.QueryString("stid") & " and  paymentdetails.courseid=" & Request.QueryString("courseid") & " and paymentdetails.semid=" & SemID & ""
                Else
                    strq = "select id,DDNo,Amount,DDdate,paymentdetails.Courseid,CourseTitle from paymentdetails INNER JOIN Course on paymentdetails.Courseid=Course.Courseid where  paymentdetails.stid=" & Request.QueryString("stid") & " and  paymentdetails.courseid=" & Request.QueryString("courseid") & " and paymentdetails.semid=" & ddlSem.SelectedValue & ""

                End If
            End If
            'Dim strq As String = "select id,DDNo,Amount,DDdate,paymentdetails.Courseid,CourseTitle from paymentdetails INNER JOIN Course on paymentdetails.Courseid=Course.Courseid where  paymentdetails.stid=" & Request.QueryString("stid") & " and  paymentdetails.courseid=" & Request.QueryString("courseid") & " and paymentdetails.semid=" & ddlSem.SelectedValue & ""
            Dim dsbatch As New DataSet()
            dsbatch = CLS.fnQuerySelectDs(strq)
            If dsbatch IsNot Nothing Then
                If dsbatch.Tables IsNot Nothing Then
                    If dsbatch.Tables(0).Rows IsNot Nothing Then
                        If dsbatch.Tables(0).Rows.Count > 0 Then
                            Grdpayment.DataSource = dsbatch
                            Grdpayment.DataBind()
                            Grdpayment.Visible = True
                            tblpayment.Visible = True
                        Else
                            'lblMessage.Text = "No Payment"
                            tblpayment.Visible = False
                            Grdpayment.Visible = False
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub ddlSem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSem.SelectedIndexChanged
        ViewState("chk") = 1
    End Sub

    Protected Sub imgBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgBack.Click
        Response.Redirect("AdminListFeesstudent.aspx?batchid=" & batchid)
    End Sub
End Class
